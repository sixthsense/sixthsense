using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace WUW01
{
    public class Category
    {
        private string      _name;
        private ArrayList   _prototypes;

        public Category(string name)
        {
            _name = name;
            _prototypes = null;
        }

        public Category(string name, Gesture firstExample)
        {
            _name = name;
            _prototypes = new ArrayList();
            AddExample(firstExample);
        }
        
        public Category(string name, ArrayList examples)
        {
            _name = name;
            _prototypes = new ArrayList(examples.Count);
            for (int i = 0; i < examples.Count; i++)
            {
                Gesture p = (Gesture) examples[i];
                AddExample(p);
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public int NumExamples
        {
            get
            {
                return _prototypes.Count;
            }
        }

        /// <summary>
        /// Indexer that returns the prototype at the given index within
        /// this gesture category, or null if the gesture does not exist.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Gesture this[int i]
        {
            get
            {
                if (0 <= i && i < _prototypes.Count)
                {
                    return (Gesture) _prototypes[i];
                }
                else
                {
                    return null;
                }
            }
        }

        public void AddExample(Gesture p)
        {
            bool success = true;
            try
            {
                // first, ensure that p's name is right
                string name = ParseName(p.Name);
                if (name != _name)
                    throw new ArgumentException("Prototype name does not equal the name of the category to which it was added.");

                // second, ensure that it doesn't already exist
                for (int i = 0; i < _prototypes.Count; i++)
                {
                    Gesture p0 = (Gesture) _prototypes[i];
                    if (p0.Name == p.Name)
                        throw new ArgumentException("Prototype name was added more than once to its category.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                success = false;
            }
            if (success)
            {
                _prototypes.Add(p);
            }
        }

        /// <summary>
        /// Pulls the category name from the gesture name, e.g., "circle" from "circle03".
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ParseName(string s)
        {
            string category = String.Empty;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (!Char.IsDigit(s[i]))
                {
                    category = s.Substring(0, i + 1);
                    break;
                }
            }
            return category;
        }

    }
}
