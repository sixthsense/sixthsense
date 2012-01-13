using System;
using System.IO;
using System.Xml;
using System.Drawing;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace WUW01
{
	public class GeometricRecognizer
	{
		#region Members

        public const int NumResamplePoints = 64;
        private const double DX = 250.0;
        public static readonly SizeR ResampleScale = new SizeR(DX, DX);
        public static readonly double Diagonal = Math.Sqrt(DX * DX + DX * DX);
        public static readonly double HalfDiagonal = 0.5 * Diagonal;
        public static readonly PointR ResampleOrigin = new PointR(0, 0);
        private static readonly double Phi = 0.5 * (-1 + Math.Sqrt(5)); // Golden Ratio

        //dc
        public double tolerance = 0.75;

        // batch testing
        private const int NumRandomTests = 100;
        public event ProgressEventHandler ProgressChangedEvent;

		private Hashtable _gestures;

		#endregion

		#region Constructor
	
		public GeometricRecognizer()
		{
            _gestures = new Hashtable(256);
		}

		#endregion

		#region Recognition

        public NBestList Recognize(ArrayList points) // candidate points
        {
            // resample to a common number of points
            points = Utils.Resample(points, NumResamplePoints);

            // rotate so that the centroid-to-1st-point is at zero degrees
            double radians = Utils.AngleInRadians(Utils.Centroid(points), (PointR) points[0], false); // indicative angle
            points = Utils.RotateByRadians(points, -radians); // undo angle

            // scale to a common (square) dimension
            points = Utils.ScaleTo(points, ResampleScale);

            // translate to a common origin
            points = Utils.TranslateCentroidTo(points, ResampleOrigin);

            NBestList nbest = new NBestList();
            foreach (Gesture p in _gestures.Values)
            {
                double[] best = GoldenSectionSearch(
                    points,                 // to rotate
                    p.Points,               // to match
                    Utils.Deg2Rad(-45.0),   // lbound
                    Utils.Deg2Rad(+45.0),   // ubound
                    Utils.Deg2Rad(2.0));    // threshold

                double score = 1d - best[0] / HalfDiagonal;
                nbest.AddResult(p.Name, score, best[0], best[1]); // name, score, distance, angle
            }
            nbest.AddResult("Try Again", tolerance, 0.0, 0.0);
            nbest.SortDescending(); // sort so that nbest[0] is best result
            return nbest;
        }

        // From http://www.math.uic.edu/~jan/mcs471/Lec9/gss.pdf
        private double[] GoldenSectionSearch(ArrayList pts1, ArrayList pts2, double a, double b, double threshold)
        {
            double x1 = Phi * a + (1 - Phi) * b;
            ArrayList newPoints = Utils.RotateByRadians(pts1, x1);
            double fx1 = Utils.PathDistance(newPoints, pts2);

            double x2 = (1 - Phi) * a + Phi * b;
            newPoints = Utils.RotateByRadians(pts1, x2);
            double fx2 = Utils.PathDistance(newPoints, pts2);

            double i = 2.0; // calls
            while (Math.Abs(b - a) > threshold)
            {
                if (fx1 < fx2)
                {
                    b = x2;
                    x2 = x1;
                    fx2 = fx1;
                    x1 = Phi * a + (1 - Phi) * b;
                    newPoints = Utils.RotateByRadians(pts1, x1);
                    fx1 = Utils.PathDistance(newPoints, pts2);
                }
                else
                {
                    a = x1;
                    x1 = x2;
                    fx1 = fx2;
                    x2 = (1 - Phi) * a + Phi * b;
                    newPoints = Utils.RotateByRadians(pts1, x2);
                    fx2 = Utils.PathDistance(newPoints, pts2);
                }
                i++;
            }
            return new double[3] { Math.Min(fx1, fx2), Utils.Rad2Deg((b + a) / 2.0), i }; // distance, angle, calls to pathdist
        }

        // continues to rotate 'pts1' by 'step' degrees as long as points become ever-closer 
        // in path-distance to pts2. the initial distance is given by D. the best distance
        // is returned in array[0], while the angle at which it was achieved is in array[1].
        // array[3] contains the number of calls to PathDistance.
        private double[] HillClimbSearch(ArrayList pts1, ArrayList pts2, double D, double step)
        {
            double i = 0.0;
            double theta = 0.0;
            double d = D;
            do
            {
                D = d; // the last angle tried was better still
                theta += step;
                ArrayList newPoints = Utils.RotateByDegrees(pts1, theta);
                d = Utils.PathDistance(newPoints, pts2);
                i++;
            }
            while (d <= D);
            return new double[3] { D, theta - step, i }; // distance, angle, calls to pathdist
        }

        private double[] FullSearch(ArrayList pts1, ArrayList pts2, StreamWriter writer)
        {
            double bestA = 0d;
            double bestD = Utils.PathDistance(pts1, pts2);

            for (int i = -180; i <= +180; i++)
            {
                ArrayList newPoints = Utils.RotateByDegrees(pts1, i);
                double d = Utils.PathDistance(newPoints, pts2);
                if (writer != null)
                {
                    writer.WriteLine("{0}\t{1:F3}", i, Math.Round(d, 3));
                }
                if (d < bestD)
                {
                    bestD = d;
                    bestA = i;
                }
            }
            writer.WriteLine("\nFull Search (360 rotations)\n{0:F2}{1}\t{2:F3} px", Math.Round(bestA, 2), (char) 176, Math.Round(bestD, 3)); // calls, angle, distance
            return new double[3] { bestD, bestA, 360.0 }; // distance, angle, calls to pathdist
        }

        #endregion

        #region Gestures & Xml

        public int NumGestures
		{
			get
			{
                return _gestures.Count;
			}
		}

        public ArrayList Gestures
        {
            get
            {
                ArrayList list = new ArrayList(_gestures.Values);
                list.Sort();
                return list;
            }
        }

		public void ClearGestures()
		{
            _gestures.Clear();
		}

		public bool SaveGesture(string filename, ArrayList points)
		{
			// add the new prototype with the name extracted from the filename.
            string name = Gesture.ParseName(filename);
            if (_gestures.ContainsKey(name))
                _gestures.Remove(name);
			Gesture newPrototype = new Gesture(name, points);
            _gestures.Add(name, newPrototype);

            // figure out the duration of the gesture
            PointR p0 = (PointR) points[0];
            PointR pn = (PointR) points[points.Count - 1];

			// do the xml writing
			bool success = true;
			XmlTextWriter writer = null;
			try
			{
				// save the prototype as an Xml file
				writer = new XmlTextWriter(filename, Encoding.UTF8);
				writer.Formatting = Formatting.Indented;
				writer.WriteStartDocument(true);
				writer.WriteStartElement("Gesture");
				writer.WriteAttributeString("Name", name);
				writer.WriteAttributeString("NumPts", XmlConvert.ToString(points.Count));
                writer.WriteAttributeString("Millseconds", XmlConvert.ToString(pn.T - p0.T));
                writer.WriteAttributeString("AppName", Assembly.GetExecutingAssembly().GetName().Name);
				writer.WriteAttributeString("AppVer", Assembly.GetExecutingAssembly().GetName().Version.ToString());
				writer.WriteAttributeString("Date", DateTime.Now.ToLongDateString());
				writer.WriteAttributeString("TimeOfDay", DateTime.Now.ToLongTimeString());

				// write out the raw individual points
				foreach (PointR p in points)
				{
					writer.WriteStartElement("Point");
					writer.WriteAttributeString("X", XmlConvert.ToString(p.X));
					writer.WriteAttributeString("Y", XmlConvert.ToString(p.Y));
                    writer.WriteAttributeString("T", XmlConvert.ToString(p.T));
					writer.WriteEndElement(); // <Point />
				}

				writer.WriteEndDocument(); // </Gesture>
			}
			catch (XmlException xex)
			{
				Console.Write(xex.Message);
				success = false;
			}
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                success = false;
            }
			finally
			{
				if (writer != null)
					writer.Close();
			}
			return success; // Xml file successfully written (or not)
		}

		public bool LoadGesture(string filename)
		{
			bool success = true;
			XmlTextReader reader = null;
            try
            {
                reader = new XmlTextReader(filename);
                reader.WhitespaceHandling = WhitespaceHandling.None;
                reader.MoveToContent();

                Gesture p = ReadGesture(reader);

                // remove any with the same name and add the prototype gesture
                if (_gestures.ContainsKey(p.Name))
                    _gestures.Remove(p.Name);
                _gestures.Add(p.Name, p);
            }
            catch (XmlException xex)
            {
                Console.Write(xex.Message);
                success = false;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                success = false;
            }
			finally
			{
				if (reader != null)
					reader.Close();
			}
			return success;
		}

        // assumes the reader has been just moved to the head of the content.
        private Gesture ReadGesture(XmlTextReader reader)
        {
            Debug.Assert(reader.LocalName == "Gesture");
            string name = reader.GetAttribute("Name");
            
            ArrayList points = new ArrayList(XmlConvert.ToInt32(reader.GetAttribute("NumPts")));
            
            reader.Read(); // advance to the first Point
            Debug.Assert(reader.LocalName == "Point");

            while (reader.NodeType != XmlNodeType.EndElement)
            {
                PointR p = PointR.Empty;
                p.X = XmlConvert.ToDouble(reader.GetAttribute("X"));
                p.Y = XmlConvert.ToDouble(reader.GetAttribute("Y"));
                p.T = XmlConvert.ToInt32(reader.GetAttribute("T"));
                points.Add(p);
                reader.ReadStartElement("Point");
            }

            return new Gesture(name, points);
        }

        #endregion

        #region Batch Processing

        /// <summary>
        /// Assemble the gesture filenames into categories that contain 
        /// potentially multiple examples of the same gesture.
        /// </summary>
        /// <param name="filenames"></param>
        /// <returns>A 1D arraylist of category instances that each
        /// contain the same number of examples, or <b>null</b> if an
        /// error occurs.</returns>
        /// <remarks>
        /// See the comments above MainForm.BatchProcess_Click.
        /// </remarks>
        public ArrayList AssembleBatch(string[] filenames)
        {
            Hashtable categories = new Hashtable();

            for (int i = 0; i < filenames.Length; i++)
            {
                string filename = filenames[i];

                XmlTextReader reader = null;
                try
                {
                    reader = new XmlTextReader(filename);
                    reader.WhitespaceHandling = WhitespaceHandling.None;
                    reader.MoveToContent();
                    
                    Gesture p = ReadGesture(reader);
                    string catName = Category.ParseName(p.Name);
                    if (categories.ContainsKey(catName))
                    {
                        Category cat = (Category) categories[catName];
                        cat.AddExample(p); // if the category has been made before, just add to it
                    }
                    else // create new category
                    {
                        categories.Add(catName, new Category(catName, p));
                    }
                }
                catch (XmlException xex)
                {
                    Console.Write(xex.Message);
                    categories.Clear();
                    categories = null;
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    categories.Clear();
                    categories = null;
                }
                finally
                {
                    if (reader != null)
                        reader.Close();
                }
            }

            // now make sure that each category has the same number of elements in it
            ArrayList list = null;
            if (categories != null)
            {
                list = new ArrayList(categories.Values);
                int numExamples = ((Category) list[0]).NumExamples;
                foreach (Category c in list)
                {
                    if (c.NumExamples != numExamples)
                    {
                        Console.WriteLine("Different number of examples in gesture categories.");
                        list.Clear();
                        list = null;
                        break;
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// Tests an entire batch of files. See comments atop MainForm.TestBatch_Click().
        /// </summary>
        /// <param name="subject">Subject number.</param>
        /// <param name="speed">"fast", "medium", or "slow"</param>
        /// <param name="categories">A list of gesture categories that each contain lists of
        /// prototypes (examples) within that gesture category.</param>
        /// <param name="dir">The directory into which to write the output files.</param>
        /// <returns>True if successful; false otherwise.</returns>
        public bool TestBatch(int subject, string speed, ArrayList categories, string dir)
        {
            bool success = true;
            StreamWriter mainWriter = null;
            StreamWriter recWriter = null;
            try
            {
                //
                // set up a main results file and detailed recognition results file
                //
                int start = Environment.TickCount;
                string mainFile = String.Format("{0}\\geometric_main_{1}.txt", dir, start);
                string recFile = String.Format("{0}\\geometric_data_{1}.txt", dir, start);

                mainWriter = new StreamWriter(mainFile, false, Encoding.UTF8);
                mainWriter.WriteLine("Subject = {0}, Recognizer = geometric, Speed = {1}, StartTime(ms) = {2}", subject, speed, start);
                mainWriter.WriteLine("Subject Recognizer Speed NumTraining GestureType RecognitionRate\n");

                recWriter = new StreamWriter(recFile, false, Encoding.UTF8);
                recWriter.WriteLine("Subject = {0}, Recognizer = geometric, Speed = {1}, StartTime(ms) = {2}", subject, speed, start);
                recWriter.WriteLine("Correct? NumTrain Tested 1stCorrect Pts Ms Angle : (NBestNames) [NBestScores]\n");

                //
                // determine the number of gesture categories and the number of examples in each one
                //
                int numCategories = categories.Count;
                int numExamples = ((Category) categories[0]).NumExamples;
                double totalTests = (numExamples - 1) * NumRandomTests;

                //
                // outermost loop: trains on N=1..9, tests on 10-N (for e.g., numExamples = 10)
                //
                for (int n = 1; n <= numExamples - 1; n++)
                {
                    // storage for the final avg results for each category for this N
                    double[] results = new double[numCategories];

                    //
                    // run a number of tests at this particular N number of training examples
                    //
                    for (int r = 0; r < NumRandomTests; r++)
                    {
                        _gestures.Clear(); // clear any (old) loaded prototypes

                        // load (train on) N randomly selected gestures in each category
                        for (int i = 0; i < numCategories; i++)
                        {
                            Category c = (Category) categories[i]; // the category to load N examples for
                            int[] chosen = Utils.Random(0, numExamples - 1, n); // select N unique indices
                            for (int j = 0; j < chosen.Length; j++)
                            {
                                Gesture p = c[chosen[j]]; // get the prototype from this category at chosen[j]
                                _gestures.Add(p.Name, p); // load the randomly selected test gestures into the recognizer
                            }
                        }

                        //
                        // testing loop on all unloaded gestures in each category. creates a recognition
                        // rate (%) by averaging the binary outcomes (correct, incorrect) for each test.
                        //
                        for (int i = 0; i < numCategories; i++)
                        {
                            // pick a random unloaded gesture in this category for testing
                            // instead of dumbly picking, first find out what indices aren't
                            // loaded, and then randomly pick from those.
                            Category c = (Category) categories[i];
                            int[] notLoaded = new int[numExamples - n];
                            for (int j = 0, k = 0; j < numExamples; j++)
                            {
                                Gesture g = c[j];
                                if (!_gestures.ContainsKey(g.Name))
                                    notLoaded[k++] = j; // jth gesture in c is not loaded
                            }
                            int chosen = Utils.Random(0, notLoaded.Length - 1); // index
                            Gesture p = c[notLoaded[chosen]]; // gesture to test
                            Debug.Assert(!_gestures.ContainsKey(p.Name));
                            
                            // do the recognition!
                            ArrayList testPts = Utils.RotateByDegrees(p.RawPoints, Utils.Random(0, 359));
                            NBestList result = this.Recognize(testPts);
                            string category = Category.ParseName(result.Name);
                            int correct = (c.Name == category) ? 1 : 0;

                            recWriter.WriteLine("{0} {1} {2} {3} {4} {5} {6:F1}{7} : ({8}) [{9}]",
                                correct,                            // Correct?
                                n,                                  // NumTrain 
                                p.Name,                             // Tested 
                                FirstCorrect(p.Name, result.Names), // 1stCorrect
                                p.RawPoints.Count,                  // Pts
                                p.Duration,                         // Ms 
                                Math.Round(result.Angle, 1), (char) 176, // Angle tweaking :
                                result.NamesString,                 // (NBestNames)
                                result.ScoresString);               // [NBestScores]

                            results[i] += correct;
                        }

                        // provide feedback as to how many tests have been performed thus far.
                        double testsSoFar = ((n - 1) * NumRandomTests) + r;
                        ProgressChangedEvent(this, new ProgressEventArgs(testsSoFar / totalTests)); // callback
                    }

                    //
                    // now create the final results for this N and write them to a file
                    //
                    for (int i = 0; i < numCategories; i++)
                    {
                        results[i] /= (double) NumRandomTests; // normalize by the number of tests at this N
                        Category c = (Category) categories[i];
                        // Subject Recognizer Speed NumTraining GestureType RecognitionRate
                        mainWriter.WriteLine("{0} geometric {1} {2} {3} {4:F3}", subject, speed, n, c.Name, Math.Round(results[i], 3));
                    }
                }

                // time-stamp the end of the processing
                int end = Environment.TickCount;
                mainWriter.WriteLine("\nEndTime(ms) = {0}, Minutes = {1:F2}", end, Math.Round((end - start) / 60000.0, 2));
                recWriter.WriteLine("\nEndTime(ms) = {0}, Minutes = {1:F2}", end, Math.Round((end - start) / 60000.0, 2));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                success = false;
            }
            finally
            {
                if (mainWriter != null)
                    mainWriter.Close();
                if (recWriter != null)
                    recWriter.Close();
            }
            return success;
        }

        private int FirstCorrect(string name, string[] names)
        {
            string category = Category.ParseName(name);
            for (int i = 0; i < names.Length; i++)
            {
                string c = Category.ParseName(names[i]);
                if (category == c)
                {
                    return i + 1;
                }
            }
            return -1;
        }

        #endregion

        #region Rotation Graph

        public bool CreateRotationGraph(string file1, string file2, string dir, bool similar)
        {
            bool success = true;
            StreamWriter writer = null;
            XmlTextReader reader = null;
            try
            {
                // read gesture file #1
                reader = new XmlTextReader(file1);
                reader.WhitespaceHandling = WhitespaceHandling.None;
                reader.MoveToContent();
                Gesture g1 = ReadGesture(reader);
                reader.Close();

                // read gesture file #2
                reader = new XmlTextReader(file2);
                reader.WhitespaceHandling = WhitespaceHandling.None;
                reader.MoveToContent();
                Gesture g2 = ReadGesture(reader);

                // create output file for results
                string outfile = String.Format("{0}\\{1}({2}, {3})_{4}.txt", dir, similar ? "o" : "x", g1.Name, g2.Name, Environment.TickCount);
                writer = new StreamWriter(outfile, false, Encoding.UTF8);
                writer.WriteLine("Rotated: {0} --> {1}. {2}, {3}\n", g1.Name, g2.Name, DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString());

                // do the full 360 degree rotations
                double[] full = FullSearch(g1.Points, g2.Points, writer);

                // use bidirectional hill climbing to do it again
                double init = Utils.PathDistance(g1.Points, g2.Points); // initial distance
                double[] pos = HillClimbSearch(g1.Points, g2.Points, init, 1d);
                double[] neg = HillClimbSearch(g1.Points, g2.Points, init, -1d);
                double[] best = new double[3];
                best = (neg[0] < pos[0]) ? neg : pos; // min distance
                writer.WriteLine("\nHill Climb Search ({0} rotations)\n{1:F2}{2}\t{3:F3} px", pos[2] + neg[2] + 1, Math.Round(best[1], 2), (char) 176, Math.Round(best[0], 3)); // calls, angle, distance

                // use golden section search to do it yet again
                double[] gold = GoldenSectionSearch(
                    g1.Points,              // to rotate
                    g2.Points,              // to match
                    Utils.Deg2Rad(-45.0),   // lbound
                    Utils.Deg2Rad(+45.0),   // ubound
                    Utils.Deg2Rad(2.0));    // threshold
                writer.WriteLine("\nGolden Section Search ({0} rotations)\n{1:F2}{2}\t{3:F3} px", gold[2], Math.Round(gold[1], 2), (char) 176, Math.Round(gold[0], 3)); // calls, angle, distance

                // for pasting into Excel
                writer.WriteLine("\n{0} {1} {2:F2} {3:F2} {4:F3} {5:F3} {6} {7:F2} {8:F2} {9:F3} {10} {11:F2} {12:F2} {13:F3} {14}",
                    g1.Name,                    // rotated
                    g2.Name,                    // into
                    Math.Abs(Math.Round(full[1], 2)), // |angle|
                    Math.Round(full[1], 2),     // Full Search angle
                    Math.Round(full[0], 3),     // Full Search distance
                    Math.Round(init, 3),        // Initial distance w/o any search
                    full[2],                    // Full Search iterations
                    Math.Abs(Math.Round(best[1], 2)), // |angle|
                    Math.Round(best[1], 2),     // Bidirectional Hill Climb Search angle
                    Math.Round(best[0], 3),     // Bidirectional Hill Climb Search distance
                    pos[2] + neg[2] + 1,        // Bidirectional Hill Climb Search iterations
                    Math.Abs(Math.Round(gold[1], 2)), // |angle|
                    Math.Round(gold[1], 2),     // Golden Section Search angle
                    Math.Round(gold[0], 3),     // Golden Section Search distance
                    gold[2]);                   // Golden Section Search iterations
            }
            catch (XmlException xml)
            {
                Console.Write(xml.Message);
                success = false;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                success = false;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (writer != null)
                    writer.Close();
            }
            return success;
        }

        #endregion
    }
}