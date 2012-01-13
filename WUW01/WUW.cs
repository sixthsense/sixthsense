//*****************************************************************************************
//  SixthSense v0.1 beta
//  (WUW - Wear Ur World)
//
//  Pranav Mistry (pranav@mit.edu)
//  www.pranavmistry.com
//
//  MIT Media Lab 2008, 2009, 2010, 2011, 2012
//  Fluid Interfaces 
//
//  WUW.cs
//  
//*****************************************************************************************


using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices; 
using System.Text;
using System.Windows.Forms;
using System.Windows.Ink;
using System.Windows.Media.Imaging;

using TouchlessLib;

using System.Threading;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using NyARToolkitCSUtils.Capture;
using NyARToolkitCSUtils.Direct3d;
using NyARToolkitCSUtils.NyAR;
using jp.nyatla.nyartoolkit.cs;
using jp.nyatla.nyartoolkit.cs.core;
using jp.nyatla.nyartoolkit.cs.detector;

namespace WUW01
{   
    public partial class WUW : Form
    {

		#region Global Variables
        
        //Demo mode
        private bool reverse = true; //true for Pendant       
        
        //NYAR Toolkit Globals
        private const int SCREEN_WIDTH = 320;
        private const int SCREEN_HEIGHT = 240;
        private const String AR_CODE_FILE1 = "patt.sample1";
        private const String AR_CODE_FILE2 = "patt.sample2";
        private const String AR_CODE_FILE3 = "patt.hiro";
        private const String AR_CODE_FILE4 = "patt.kanji";
        private const String AR_CAMERA_FILE = "camera_para.dat";
        private NyARSingleDetectMarker _ar1;
        private NyARSingleDetectMarker _ar2;
        private NyARSingleDetectMarker _ar3;
        private NyARSingleDetectMarker _ar4;
        private NyARSingleDetectMarker _arFinal;
        private DsBGRX32Raster _raster;
        bool is_marker_enable;

        private Microsoft.DirectX.Matrix __MainLoop_trans_matrix = new Microsoft.DirectX.Matrix();
        private NyARTransMatResult __MainLoop_nyar_transmat = new NyARTransMatResult();
        private NyARD3dUtil _utils;

        //Touchless
        private TouchlessMgr _touchlessMgr;
        private static DateTime _dtFrameLast;
        private static int _nFrameCount;
        private static Point _markerCenter;
        private static float _markerRadius;
        private static Marker _markerSelected;
        private static bool _fAddingMarker;
        private static int _addedMarkerCount;        
        private static bool _fUpdatingMarkerUI;
        private static Image _latestFrame;
        private static bool _drawSelectionAdornment;        
        private static int _ratioScreenCameraHeight;
        private static int _ratioScreenCameraWidth;

        private static DateTime _latestFrameTime;
        private static bool _latestFrameTimeSegment;

        //Gesture 
        private GeometricRecognizer	_rec;
		private bool				_recording;
		private bool				_isDown;
		private ArrayList			_points;
		private ViewForm			_viewFrm;

        //TestDemo Control
        int[,] mouseData = new int[4, 2] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } };
        SolidBrush[] brushData = new SolidBrush[4] { new SolidBrush(Color.Red), new SolidBrush(Color.Yellow), new SolidBrush(Color.Blue), new SolidBrush(Color.Green) };
        int dirX = new int();
        int dirY = new int();
        int magX = new int();
        int magY = new int();
                
        //DrawDemo Control
        System.Windows.Controls.InkCanvas inkCanvas1;

        //DrawDemoNew Control
        WpfUserControlInkPlaying01.UserControl1 Control_ink = new WpfUserControlInkPlaying01.UserControl1();

        //MapDemo Control

        //map control unit goes here

        //stem.AccessViolationException kk = System.AccessViolationException();
        


        //PhotoDemo Control
        System.Windows.Forms.Timer Timer;
        int timerSum = 0;
        double photoTaken = 0.0;
        bool photo_clicked = false;

        //PreviewDemo Control
        private Bitmap _image;
        private int _captureWidth, _captureHeight;
        private int _displayWidth, _displayHeight;
        private float _displayScale;
        private Point[] _destPoints;
        private int _imageWidth, _imageHeight;
        private float _imageDiagonal, _imageScale;
        private float _imageDiagonalAngle;
        Graphics graphics;

        //GalleryDemo Control

        //MailDemo Control        
        WpfUserControl_Mail01.UserControl1 Control_mail = new WpfUserControl_Mail01.UserControl1();
        
        //WeatherDemo Control        
        WPFControl_Weather01.UserControl1 Control_weather;
        //WPFControl_Weather01.UserControl1 Control_weather = new WPFControl_Weather01.UserControl1();
        
        //StockDemo Control        
        WpfUserControl_Stock01.UserControl1 Control_stock = new WpfUserControl_Stock01.UserControl1();
                
        //EffectsDemo Control
        AxShockwaveFlashObjects.AxShockwaveFlash EffectsDemo_Flash = new AxShockwaveFlashObjects.AxShockwaveFlash();

        //GlobeDemo Control
        AxShockwaveFlashObjects.AxShockwaveFlash GlobeDemo_Flash = new AxShockwaveFlashObjects.AxShockwaveFlash(); 
       
        //NewsPaperDemo Control        
        double x1, x2, y1, y2;
        double new_x1, new_x2, new_y1, new_y2;
        double Theta, distance;
        double new_Theta, new_distance;
        System.Windows.Controls.MediaElement mediaElement1 = new System.Windows.Controls.MediaElement();

        //BookDemo Control        

        //ClockDemo Control
        WPFControl_Clock01.UserControl1 Control_clock = new WPFControl_Clock01.UserControl1();

        //Menu Control        
        WpfUserControlMenu03.UserControl1 Control_menu = new WpfUserControlMenu03.UserControl1();       
        
        //WUW
        Marker m, n, o, p;

        //Menu Timer for handSign_Menu()
        double? menuStart = null;
        
        
        //Booleans to signify application statuses.
        private bool testDemo = false;
        private bool drawDemo = false;
        private bool mapDemo = false;        
        private bool photoDemo = false;
        private bool previewDemo = false;
        private bool galleryDemo = false;

        private bool globeDemo = false;
        private bool mailDemo = false;
        private bool weatherDemo = false;
        private bool stockDemo = false;
        private bool effectsDemo = false;

        private bool newspaperDemo = false;
        private bool bookDemo = false;
        private bool clockDemo = false;
        
        private bool menuDemo = false;
        private bool gestureDemo = true; //this is always true        

        //Toggles for various functions
        private bool _show_settings = false;
        private bool _mousedown = false;

        //marker save load function
        float[] markerSaveArray = new float[12];

		#endregion Global Variables

        #region Simulate MOUSE & KEYBOARD Events

        //keyboard event
        [DllImport("User32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);
      
        //mouse event
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(long dwFlags, long dx, long dy, long cButtons, long dwExtraInfo);

        private const byte VK_LSHIFT = 0xA0; // left shift key
        private const int KEYEVENTF_EXTENDEDKEY = 0x01;
        private const int KEYEVENTF_KEYUP = 0x02;
        
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;
        private const int MOUSEEVENTF_MOVE = 0x0001;
        private const int MOUSEEVENTF_ABSOLUTE = 0x8000;
        private const int MOUSEEVENTF_WHEEL = 0x0800;        

        #endregion Simulate MOUSE & KEYBOARD Events

        #region Environment

        private void btnExit_Click(object sender, EventArgs e)
        {
            StopOtherApps(this, e);
            
            if (_touchlessMgr.MarkerCount >= 4)
            {
                m.OnChange -= new EventHandler<MarkerEventArgs>(m_OnChange);
                n.OnChange -= new EventHandler<MarkerEventArgs>(n_OnChange);
                o.OnChange -= new EventHandler<MarkerEventArgs>(o_OnChange);
                p.OnChange -= new EventHandler<MarkerEventArgs>(p_OnChange);
                m = null;
                n = null;
                o = null;
                p = null;
            }            

            Environment.Exit(0);
        }

        private void btnShowHide_Click(object sender, EventArgs e)
        {
            if (_show_settings)
            {
                tabSettings.Hide();
                pictureBoxDisplay.Hide();
                btnExit.Hide();
                _show_settings = false;
            }
            else
            {
                tabSettings.Show();
                pictureBoxDisplay.Show();
                btnExit.Show();
                _show_settings = true;
            }
        }
        private void btnShowHide_Hover(object sener, EventArgs e)
        {
            //do nothing
        }
        private void ResetEnvironment()
        {
            labelM.Left = 35;
            labelM.Top = 9;

            labelN.Left = 35;
            labelN.Top = 35;

            labelO.Left = 9;
            labelO.Top = 9;

            labelP.Left = 9;
            labelP.Top = 35;

            gestureDemo = true;

            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            _mousedown = false;

            tabSettings.Hide();
            pictureBoxDisplay.Hide();
            btnExit.Hide();
            _show_settings = false;

        }
        private void StopOtherApps(Object sender, EventArgs e)
        {
            if (testDemo)
            {
                buttonTestDemo_Click(this, e);
            }
            
            if (drawDemo)
            {
                buttonDrawDemo_Click(this, e);
            }

            if (mapDemo)
            {
                buttonMapDemo_Click(this, e);
            }

            if (photoDemo)
            {
                buttonPhotoDemo_Click(this, e);
            }

            if (previewDemo)
            {
                buttonPreviewDemo_Click(this, e);
            }

            if (galleryDemo)
            {
                buttonGalleryDemo_Click(this, e);
            }

            //

            if (weatherDemo)
            {
                buttonWeatherDemo_Click(this, e);
            }

            //

            if (globeDemo)
            {
                buttonGlobeDemo_Click(this, e);
            }

            if (mailDemo)
            {
                buttonMailDemo_Click(this, e);
            }

            if (weatherDemo)
            {
                buttonWeatherDemo_Click(this, e);
            }

            if (stockDemo)
            {
                buttonStockDemo_Click(this, e);
            }

            if (effectsDemo)
            {
                buttonEffectsDemo_Click(this, e);
            }

            //

            if (newspaperDemo)
            {
                buttonNewsPaperDemo_Click(this, e);
            }

            if (bookDemo)
            {
                buttonBookDemo_Click(this, e);
            }
            
            if (clockDemo)
            {
                buttonClockDemo_Click(this, e);
            }
            
            //

            if (menuDemo)
            {
                buttonMenuDemo_Click(this, e);
            }

            tabSettings.Hide();
            pictureBoxDisplay.Hide();
            btnExit.Hide();
            _show_settings = false;

        }

        #endregion Environment

        #region Keyboard Events

        private void WUW_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Decimal:
                    //MessageBox.Show("Gesture");
                    buttonGestureDemo_Click(sender, e);
                    break;
                
                case Keys.NumPad0:
                    //MessageBox.Show("MENU");
                    buttonMenuDemo_Click(sender, e);
                    break;
                case Keys.NumPad1:
                    //MessageBox.Show("Demo 1");
                    buttonTestDemo_Click(sender, e);
                    break;
                
                case Keys.NumPad2:
                    //MessageBox.Show("Demo 2");
                    buttonDrawDemo_Click(sender, e);
                    break;
                case Keys.NumPad3:
                    //MessageBox.Show("Demo 3");
                    buttonMapDemo_Click(sender, e);
                    break;
                case Keys.NumPad4:
                    //MessageBox.Show("Demo 4");
                    buttonPhotoDemo_Click(sender, e);
                    break;
                case Keys.NumPad5:
                    //MessageBox.Show("Demo 5");
                    buttonGalleryDemo_Click(sender, e);
                    break;

                case Keys.NumPad6:
                    //MessageBox.Show("Demo 6");
                    buttonGlobeDemo_Click(sender, e);
                    break;

                    //Mail, Weather, Stock

                case Keys.NumPad7:
                    //MessageBox.Show("Demo 7");
                    buttonEffectsDemo_Click(sender, e);
                    break;
                case Keys.NumPad8:
                    //MessageBox.Show("Demo 8");
                    buttonNewsPaperDemo_Click(sender, e);
                    break;                    

                case Keys.NumPad9:
                    //MessageBox.Show("Demo 9");
                    buttonBookDemo_Click(sender, e);
                    break;

                    //Clock

                case Keys.Back:
                    //MessageBox.Show("Back");
                    break;    
          
                case Keys.Tab:
                    //MessageBox.Show("Tab");
                    break;
                case Keys.Divide:
                    //MessageBox.Show("Devide");
                    break;
                case Keys.Multiply:
                    //MessageBox.Show("Multiply");
                    break;
                case Keys.Add:
                    //MessageBox.Show("Add");
                    break;
                case Keys.Subtract:
                    //MessageBox.Show("Subtract");
                    break;
                case Keys.Enter:
                    //MessageBox.Show("Enter");
                    break;
            }
                
        }

        void inkCanvas1_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            switch (e.Key)
            {
                case System.Windows.Input.Key.Decimal:
                    //MessageBox.Show("Gesture");
                    buttonGestureDemo_Click(sender, e);
                    break;

                case System.Windows.Input.Key.NumPad0:
                    //MessageBox.Show("MENU");
                    buttonMenuDemo_Click(sender, e);
                    break;
                case System.Windows.Input.Key.NumPad1:
                    //MessageBox.Show("Demo 1");
                    buttonTestDemo_Click(sender, e);
                    break;

                case System.Windows.Input.Key.NumPad2:
                    //MessageBox.Show("Demo 2");
                    buttonDrawDemo_Click(sender, e);
                    break;
                case System.Windows.Input.Key.NumPad3:
                    //MessageBox.Show("Demo 3");
                    buttonMapDemo_Click(sender, e);
                    break;
                case System.Windows.Input.Key.NumPad4:
                    //MessageBox.Show("Demo 4");
                    buttonPhotoDemo_Click(sender, e);
                    break;
                case System.Windows.Input.Key.NumPad5:
                    //MessageBox.Show("Demo 5");
                    buttonGalleryDemo_Click(sender, e);
                    break;

                case System.Windows.Input.Key.NumPad6:
                    //MessageBox.Show("Demo 6");
                    buttonGlobeDemo_Click(sender, e);
                    break;

                //Mail, Weather, Stock

                case System.Windows.Input.Key.NumPad7:
                    //MessageBox.Show("Demo 7");
                    buttonEffectsDemo_Click(sender, e);
                    break;
                case System.Windows.Input.Key.NumPad8:
                    //MessageBox.Show("Demo 8");
                    buttonNewsPaperDemo_Click(sender, e);
                    break;

                case System.Windows.Input.Key.NumPad9:
                    //MessageBox.Show("Demo 9");
                    buttonBookDemo_Click(sender, e);
                    break;

                //Clock

                case System.Windows.Input.Key.Back:
                    //MessageBox.Show("Back");
                    break;

                case System.Windows.Input.Key.Tab:
                    //MessageBox.Show("Tab");
                    break;
                case System.Windows.Input.Key.Divide:
                    //MessageBox.Show("Devide");
                    break;
                case System.Windows.Input.Key.Multiply:
                    //MessageBox.Show("Multiply");
                    break;
                case System.Windows.Input.Key.Add:
                    //MessageBox.Show("Add");
                    break;
                case System.Windows.Input.Key.Subtract:
                    //MessageBox.Show("Subtract");
                    break;
                case System.Windows.Input.Key.Enter:
                    //MessageBox.Show("Enter");
                    break;
            }
        }       
        

        #endregion Keyboard Events

        #region WUW Management
               
        public WUW()
        {
            InitializeComponent();
            
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);            
            _rec = new GeometricRecognizer();
            _points = new ArrayList(256);
            _viewFrm = null;            
        }

        private void WUW_Load(object sender, EventArgs e)
        {            
            // Make a new TouchlessMgr for library interaction                    
            _touchlessMgr = new TouchlessMgr();

            // Initialize some members
            _dtFrameLast = DateTime.Now;
            _latestFrameTime = DateTime.Now;
            _latestFrameTimeSegment = false; //liyanchang
            _fAddingMarker = false;            
            _markerSelected = null;
            _addedMarkerCount = 0;
            lblMarkerCount.Text = _touchlessMgr.MarkerCount.ToString();

            //Hide Settings
            if (!_show_settings)
            {
                _show_settings = true;
                btnShowHide_Hover(this, e);
            }


            // Put the app in camera mode and select the first camera by default
            tabSettings.SelectedTab = tabPageCamera;
            foreach (Camera cam in _touchlessMgr.Cameras)
            {
                comboBoxCameras.Items.Add(cam);
            }

            if (comboBoxCameras.Items.Count > 0)
            {
                comboBoxCameras.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("WUW was unable to find a webcam. Please make sure that a camera is connected and installed.", "WUW Camera Error");
                Environment.Exit(0);
            }

            // Try going directly to the markers tab
            tabSettings.SelectedTab = tabPageTokens;



            //APPLICATION


            //Initialize TestDemo Controls
            pictureBoxTestDemo.Hide();
            
            //Initialize DrawDemo Controls
            drawPanel.Hide();
            elementHostDraw.Hide();            
            
            //Initialize MapDemo Controls
            webBrowserMap.Hide();           

            //Initialize PhotoDemo Controls
            photoDemo_TakePhoto.Hide();
            pictureBoxAlbum.Hide();
            
            //Initialize PreviewDemo Controls
            pictureBoxPreview.Hide();
            graphics = pictureBoxPreview.CreateGraphics();

            //Initialize GalleryDemo Controls        
            webBrowserGallery.Hide();
            
            
            //Initialize GlobeDemo Controls          
            this.Hide();
            this.Controls.Add(GlobeDemo_Flash);
            this.Show();
            GlobeDemo_Flash.Dock = DockStyle.Fill;
            GlobeDemo_Flash.SendToBack();
            GlobeDemo_Flash.Hide();
            //GlobeDemo_Flash.LoadMovie(0, "http://localhost/SWF/dof05_02reverse.swf"); //uncomment this before demo
                        
            //Initialize MailDemo Controls          
            elementHostMail.Hide();

            //Initialize WeatherDemo Controls          
            elementHostWeather.Hide();

            //Initialize StockDemo Controls          
            elementHostStock.Hide();

            //Initialize EffectsDemo Controls          
            this.Hide();
            this.Controls.Add(EffectsDemo_Flash);
            this.Show();            
            EffectsDemo_Flash.Dock = DockStyle.Fill;
            EffectsDemo_Flash.SendToBack();
            EffectsDemo_Flash.Hide();
            
            //Initialize NewsPaperDemo Controls      
            elementHostNewsPaper.Hide();
            x1 = 200; y1 = 200;
            x2 = 840; y2 = 680;

            Theta = Math.Atan2((y2 - y1), (x2 - x1)) - Math.Atan2(768, 1024);
            distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));

            System.Windows.Media.TransformGroup group1 = new System.Windows.Media.TransformGroup();

            group1.Children.Add(new System.Windows.Media.ScaleTransform(distance / 1280, distance / 1280, 0, 0));
            group1.Children.Add(new System.Windows.Media.RotateTransform(Theta / Math.PI * 180));
            group1.Children.Add(new System.Windows.Media.TranslateTransform(x1, y1));

            mediaElement1.RenderTransform = group1;            
                        
            //Initialize ClockDemo Controls        
            elementHostClock.Hide();

            //Initialize BookDemo Controls        


            //Initialize MenuDemo Controls      
            Control_menu.AppListSelectionChanged += new EventHandler(Control_menu_AppListSelectionChanged);           
            elementHostMenu.Hide();
            
            //Initialize GestureDemo Controls
            gestureLoad();                                          
            
        }

        private void WUW_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Dispose of the TouchlessMgr object
            if (_touchlessMgr != null)
            {
                _touchlessMgr.Dispose();
                _touchlessMgr = null;
            }
        }
        private void WUW_Paint(object sender, PaintEventArgs e)
        {
            if (_points.Count > 0)
            {
                PointF p0 = (PointF)(PointR)_points[0]; // draw the first point bigger
                e.Graphics.FillEllipse(_recording ? Brushes.Firebrick : Brushes.DarkBlue, p0.X - 5f, p0.Y - 5f, 10f, 10f);
            }
            foreach (PointR r in _points)
            {
                PointF p = (PointF)r; // cast
                e.Graphics.FillEllipse(_recording ? Brushes.Firebrick : Brushes.DarkBlue, p.X - 2f, p.Y - 2f, 4f, 4f);
            }
        }
        private void tabSettings_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set or unset the picturebox mouse interaction handlers
            if (tabSettings.SelectedTab == tabPageTokens)
            {
                pictureBoxDisplay.MouseDown += new MouseEventHandler(pictureBoxDisplay_MouseDown);
                pictureBoxDisplay.MouseMove += new MouseEventHandler(pictureBoxDisplay_MouseMove);
                pictureBoxDisplay.MouseUp += new MouseEventHandler(pictureBoxDisplay_MouseUp);
            }
            else
            {
                pictureBoxDisplay.MouseDown -= new MouseEventHandler(pictureBoxDisplay_MouseDown);
                pictureBoxDisplay.MouseMove -= new MouseEventHandler(pictureBoxDisplay_MouseMove);
                pictureBoxDisplay.MouseUp -= new MouseEventHandler(pictureBoxDisplay_MouseUp);
            }            
        }

        #endregion WUW Management

        #region Touchless Event Handling

        private void drawLatestImage(object sender, PaintEventArgs e)
        {
            if (_latestFrame != null)
            {
                // Draw the latest image from the active camera
                e.Graphics.DrawImage(_latestFrame, 0, 0, pictureBoxDisplay.Width, pictureBoxDisplay.Height);

                // Draw the selection adornment
                if (_drawSelectionAdornment)
                {
                    Pen penRed = new Pen(Brushes.Red, 1);
                    e.Graphics.DrawEllipse(penRed, _markerCenter.X - _markerRadius, _markerCenter.Y - _markerRadius, 2 * _markerRadius, 2 * _markerRadius);
                }

                if (_latestFrameTimeSegment)
                {
                    e.Graphics.FillRectangle(Brushes.LightGray, 0, 0, 640, 480);
                }

            }
        }
        public void OnImageCaptured(object sender, CameraEventArgs args)
        {
            // Calculate FPS (only update the display once every second)
            _nFrameCount++;
            double milliseconds = (DateTime.Now.Ticks - _dtFrameLast.Ticks) / TimeSpan.TicksPerMillisecond;
            if (milliseconds >= 1000)
            {
                this.BeginInvoke(new Action<double>(UpdateFPSInUI), new object[] { _nFrameCount * 1000.0 / milliseconds });
                _nFrameCount = 0;
                _dtFrameLast = DateTime.Now;
            }


            double markerWait = (DateTime.Now.Ticks - _latestFrameTime.Ticks) / TimeSpan.TicksPerMillisecond;

            // Save the latest image for drawing
            if (!_fAddingMarker)
            {
                // Cause display update
                _latestFrame = args.Image;
                pictureBoxDisplay.Invalidate();
                //set time
                _latestFrameTime = DateTime.Now;
            }
            else if (_fAddingMarker && markerWait <= 5000)
            {
                // Cause display update
                _latestFrame = args.Image;
                pictureBoxDisplay.Invalidate();
                //start timer by not setting time.

                if (markerWait % 1000 < 250)
                {
                    _latestFrameTimeSegment = true;
                }
                else
                {
                    _latestFrameTimeSegment = false;
                }
            }
        }
        private void UpdateFPSInUI(double fps)
        {
            labelCameraFPSValue.Text = "" + Math.Round(fps, 2);

            //NYAR For updating the NYAR toolkit with the latest image.
            if (bookDemo)
            {
                nyar();
            }
        }
        public void OnSelectedMarkerUpdate(object sender, MarkerEventArgs args)
        {
            this.BeginInvoke(new Action<MarkerEventData>(UpdateMarkerDataInUI), new object[] { args.EventData });
        }
        private void UpdateMarkerDataInUI(MarkerEventData data)
        {
            if (data.Present)
            {
                labelMarkerData.Text =
                      "Center X:  " + data.X + "\n"
                    + "Center Y:  " + data.Y + "\n"
                    + "DX:        " + data.DX + "\n"
                    + "DY:        " + data.DY + "\n"
                    + "Area:      " + data.Area + "\n"
                    + "Left:      " + data.Bounds.Left + "\n"
                    + "Right:     " + data.Bounds.Right + "\n"
                    + "Top:       " + data.Bounds.Top + "\n"
                    + "Bottom:    " + data.Bounds.Bottom + "\n";
            }
            else
                labelMarkerData.Text = "Marker not present";
        }

        #endregion Touchless Event Handling

        #region Camera Mode

        private void comboBoxCameras_DropDown(object sender, EventArgs e)
        {
            // Refresh the list of available cameras
            comboBoxCameras.Items.Clear();
            foreach (Camera cam in _touchlessMgr.Cameras)
                comboBoxCameras.Items.Add(cam);
        }
        private void comboBoxCameras_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Early return if we've selected the current camera
            if (_touchlessMgr.CurrentCamera == (Camera)comboBoxCameras.SelectedItem)
                return;

            // Trash the old camera
            if (_touchlessMgr.CurrentCamera != null)
            {
                _touchlessMgr.CurrentCamera.OnImageCaptured -= new EventHandler<CameraEventArgs>(OnImageCaptured);
                _touchlessMgr.CurrentCamera.Dispose();
                _touchlessMgr.CurrentCamera = null;
                comboBoxCameras.Text = "Select A Camera";
                groupBoxCameraInfo.Enabled = false;
                groupBoxCameraInfo.Text = "No Camera Selected";
                labelCameraFPSValue.Text = "0.00";
                pictureBoxDisplay.Paint -= new PaintEventHandler(drawLatestImage);
            }

            if (comboBoxCameras.SelectedIndex < 0)
            {
                pictureBoxDisplay.Paint -= new PaintEventHandler(drawLatestImage);
                comboBoxCameras.Text = "Select A Camera";
                return;
            }

            try
            {
                Camera c = (Camera)comboBoxCameras.SelectedItem;
                c.OnImageCaptured += new EventHandler<CameraEventArgs>(OnImageCaptured);
                c.CaptureWidth = 320; //320; //640; //960;
                c.CaptureHeight = 240; //240; //480; //720;
                _touchlessMgr.CurrentCamera = c;
                _dtFrameLast = DateTime.Now;

                groupBoxCameraInfo.Enabled = true;
                groupBoxCameraInfo.Text = c.ToString();

                // Allow access to the marker mode once a camera has been activated
                // TODO: allow immediate access to the demo if we already have some markers set?

                pictureBoxDisplay.Paint += new PaintEventHandler(drawLatestImage);
            }
            catch (Exception ex)
            {
                comboBoxCameras.Text = "Select A Camera";
                MessageBox.Show(ex.Message);
            }
        }
        private void buttonCameraProperties_Click(object sender, EventArgs e)
        {
            if (comboBoxCameras.SelectedIndex < 0)
                return;

            Camera c = (Camera)comboBoxCameras.SelectedItem;
            c.ShowPropertiesDialog(this.Handle);
        }

        private void checkBoxCameraFPSLimit_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownCameraFPSLimit.Visible = numericUpDownCameraFPSLimit.Enabled = checkBoxCameraFPSLimit.Checked;
            Camera c = (Camera)comboBoxCameras.SelectedItem;
            c.Fps = checkBoxCameraFPSLimit.Checked ? (int)numericUpDownCameraFPSLimit.Value : -1;
        }
        private void numericUpDownCameraFPSLimit_ValueChanged(object sender, EventArgs e)
        {
            if (comboBoxCameras.SelectedIndex < 0)
                return;

            Camera c = (Camera)comboBoxCameras.SelectedItem;
            c.Fps = (int)numericUpDownCameraFPSLimit.Value;
        }

        #endregion Camera Mode

        #region Marker Mode

        #region Marker Buttons

        private void buttonMarkerAdd_Click(object sender, EventArgs e)
        {
            if (_touchlessMgr.MarkerCount < 4)
            {
                _fAddingMarker = !_fAddingMarker;
                buttonMarkerAdd.Text = _fAddingMarker ? "Cancel Adding Marker" : "Add A New Marker";
            }
            else
            {
                removeMarkers();
            }
        }
        private void comboBoxMarkers_DropDown(object sender, EventArgs e)
        {
            // Refresh the marker dropdown list.
            comboBoxMarkers.Items.Clear();
            foreach (Marker marker in _touchlessMgr.Markers)
                comboBoxMarkers.Items.Add(marker);
        }
        private void comboBoxMarkers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_markerSelected != null)
                _markerSelected.OnChange -= new EventHandler<MarkerEventArgs>(OnSelectedMarkerUpdate);

            if (comboBoxMarkers.SelectedIndex < 0)
            {
                comboBoxMarkers.Text = "Edit An Existing Marker";
                groupBoxMarkerControl.Enabled = false;
                groupBoxMarkerControl.Text = "No Marker Selected";
                return;
            }

            _markerSelected = (Marker)comboBoxMarkers.SelectedItem;
            _markerSelected.OnChange += new EventHandler<MarkerEventArgs>(OnSelectedMarkerUpdate);

            groupBoxMarkerControl.Text = _markerSelected.Name;
            groupBoxMarkerControl.Enabled = true;
            _fUpdatingMarkerUI = true;
            checkBoxMarkerHighlight.Checked = _markerSelected.Highlight;
            checkBoxMarkerSmoothing.Checked = _markerSelected.SmoothingEnabled;
            numericUpDownMarkerThresh.Value = _markerSelected.Threshold;
            _fUpdatingMarkerUI = false;
        }

        #endregion Marker Buttons

        #region UI Marker Editing

        private void checkBoxMarkerHighlight_CheckedChanged(object sender, EventArgs e)
        {
            if (_fUpdatingMarkerUI)
                return;

            ((Marker)comboBoxMarkers.SelectedItem).Highlight = checkBoxMarkerHighlight.Checked;
        }
        private void checkBoxMarkerSmoothing_CheckedChanged(object sender, EventArgs e)
        {
            if (_fUpdatingMarkerUI)
                return;

            ((Marker)comboBoxMarkers.SelectedItem).SmoothingEnabled = checkBoxMarkerSmoothing.Checked;
        }
        private void numericUpDownMarkerThresh_ValueChanged(object sender, EventArgs e)
        {
            ((Marker)comboBoxMarkers.SelectedItem).Threshold = (int)numericUpDownMarkerThresh.Value;
        }
        private void buttonMarkerRemove_Click(object sender, EventArgs e)
        {
            _touchlessMgr.RemoveMarker(comboBoxMarkers.SelectedIndex);
            comboBoxMarkers.Items.RemoveAt(comboBoxMarkers.SelectedIndex);
            comboBoxMarkers.SelectedIndex = -1;
            comboBoxMarkers.Text = "Edit An Existing Marker";
            groupBoxMarkerControl.Enabled = false;
            groupBoxMarkerControl.Text = "No Marker Selected";
            if (comboBoxMarkers.Items.Count == 0)
            {
                //radioButtonDemo.Enabled = false;
                comboBoxMarkers.Enabled = false;
            }
            lblMarkerCount.Text = _touchlessMgr.MarkerCount.ToString();
        }


        // REMOVE MARKERS
        private void removeMarkers()
        {
            if (_touchlessMgr.MarkerCount >= 4)
            {

                while (_touchlessMgr.MarkerCount != 0)
                {
                    _touchlessMgr.RemoveMarker(0);
                    comboBoxMarkers.Items.RemoveAt(0);
                }

                comboBoxMarkers.SelectedIndex = -1;
                comboBoxMarkers.Text = "Edit An Existing Marker";
                groupBoxMarkerControl.Enabled = false;
                groupBoxMarkerControl.Text = "No Marker Selected";

                comboBoxMarkers.Enabled = false;

                lblMarkerCount.Text = _touchlessMgr.MarkerCount.ToString();

                m.OnChange -= new EventHandler<MarkerEventArgs>(m_OnChange);
                n.OnChange -= new EventHandler<MarkerEventArgs>(n_OnChange);
                o.OnChange -= new EventHandler<MarkerEventArgs>(o_OnChange);
                p.OnChange -= new EventHandler<MarkerEventArgs>(p_OnChange);
                m = null;
                n = null;
                o = null;
                p = null;

                markerSaveArray = new float[12];
                _addedMarkerCount = 0;
                buttonMarkerAdd.Text = "Add Marker";
            }
        }

        // SAVE MARKERS
        private void buttonSaveMarkers_Click(object sender, EventArgs e)
        {
            if (_touchlessMgr.MarkerCount >= 4)
            {
                //Write data from array to the file.
                TextWriter tw = new StreamWriter("markerSave.txt");
                foreach (float num in markerSaveArray)
                {
                    tw.WriteLine(num.ToString());
                }
                tw.Close();

                // Write data from temp images to real images.
                new Bitmap("marker1temp.bmp").Save("marker1.bmp");
                new Bitmap("marker2temp.bmp").Save("marker2.bmp");
                new Bitmap("marker3temp.bmp").Save("marker3.bmp");
                new Bitmap("marker4temp.bmp").Save("marker4.bmp");


                TextWriter tw2 = new StreamWriter("markerThresholdSave.txt");
                tw2.WriteLine(m.Threshold);
                tw2.WriteLine(n.Threshold);
                tw2.WriteLine(o.Threshold);
                tw2.WriteLine(p.Threshold);
                tw2.Close();

            }
            else
            {
                MessageBox.Show("No Marker Data Saved. Please note that 4 markers are required to save.");
            }       
        }

        // LOAD MARKERS
        private void buttonLoadMarkers_Click(object sender, EventArgs e)
        {

            if (_touchlessMgr.MarkerCount != 0)
            {
                removeMarkers();
            }

            //Get array data.
            StreamReader read = File.OpenText("markerSave.txt");
            for (int x = 0; x < 12; x++)
            {
                markerSaveArray[x] = (float)System.Convert.ToSingle(read.ReadLine());
            }
            read.Dispose();


            for (int count = 1; count <= 4; count++)
            {
                // Add the marker
                Bitmap frame = new Bitmap("marker" + count + ".bmp");
                Marker newMarker = _touchlessMgr.AddMarker("Marker #" + ++_addedMarkerCount, frame, new Point(Convert.ToInt32(markerSaveArray[count * 3 - 3]), Convert.ToInt32(markerSaveArray[count * 3 - 2])), markerSaveArray[count * 3 - 1]);

                lblMarkerCount.Text = _touchlessMgr.MarkerCount.ToString();
                comboBoxMarkers.Items.Add(newMarker);

                // Restore the app to its normal state and clear the selection area adorment
                _fAddingMarker = false;
                buttonMarkerAdd.Text = "Remove";
                _markerCenter = new Point();
                _drawSelectionAdornment = false;
                pictureBoxDisplay.Image = new Bitmap(pictureBoxDisplay.Width, pictureBoxDisplay.Height);

                // Enable the demo and marker editing             
                comboBoxMarkers.Enabled = true;
            }

            //dddddd
            StreamReader read2 = File.OpenText("markerThresholdSave.txt");
            string[] markerThresholdSaveArray = new string[4];
            for (int x = 0; x < 4; x++)
            {
                markerThresholdSaveArray[x] = read2.ReadLine();
            }
            read2.Dispose();

            _touchlessMgr.Markers.ElementAt(0).Threshold = Convert.ToInt32(markerThresholdSaveArray[0]);
            _touchlessMgr.Markers.ElementAt(1).Threshold = Convert.ToInt32(markerThresholdSaveArray[1]);
            _touchlessMgr.Markers.ElementAt(2).Threshold = Convert.ToInt32(markerThresholdSaveArray[2]);
            _touchlessMgr.Markers.ElementAt(3).Threshold = Convert.ToInt32(markerThresholdSaveArray[3]);

            //checks if there are 4 markers and name them
            nameMarkers();

        }


        #endregion UI Marker Editing

        #region Display Interaction

        private void pictureBoxDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            // If we are adding a marker - get the marker center on mouse down
            if (_fAddingMarker)
            {
                _markerCenter = e.Location;
                _markerRadius = 0;

                // Begin drawing the selection adornment
                _drawSelectionAdornment = true;
            }
        }
        private void pictureBoxDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            // If the user is selecting a marker, draw a circle of their selection as a selection adornment
            if (_fAddingMarker && !_markerCenter.IsEmpty)
            {
                // Get the current radius
                int dx = e.X - _markerCenter.X;
                int dy = e.Y - _markerCenter.Y;
                _markerRadius = (float)Math.Sqrt(dx * dx + dy * dy);

                // Cause display update
                pictureBoxDisplay.Invalidate();
            }
        }
        private void pictureBoxDisplay_MouseUp(object sender, MouseEventArgs e)
        {
            // If we are adding a marker - get the marker radius on mouse up, add the marker
            if (_fAddingMarker && !_markerCenter.IsEmpty)
            {
                int dx = e.X - _markerCenter.X;
                int dy = e.Y - _markerCenter.Y;
                _markerRadius = (float)Math.Sqrt(dx * dx + dy * dy);

                // Adjust for the image/display scaling (assumes proportional scaling)
                _markerCenter.X = (_markerCenter.X * _latestFrame.Width) / pictureBoxDisplay.Width;
                _markerCenter.Y = (_markerCenter.Y * _latestFrame.Height) / pictureBoxDisplay.Height;
                _markerRadius = (_markerRadius * _latestFrame.Height) / pictureBoxDisplay.Height;

                // Add the marker
                Marker newMarker = _touchlessMgr.AddMarker("Marker #" + ++_addedMarkerCount, (Bitmap)_latestFrame, _markerCenter, _markerRadius);
                lblMarkerCount.Text = _touchlessMgr.MarkerCount.ToString();
                comboBoxMarkers.Items.Add(newMarker);

                //save the temp images and temp array.
                Bitmap frame = (Bitmap)_latestFrame;
                frame.Save("marker" + _addedMarkerCount + "temp.bmp");
                markerSaveArray[_addedMarkerCount * 3 - 3] = _markerCenter.X;
                markerSaveArray[_addedMarkerCount * 3 - 2] = _markerCenter.Y;
                markerSaveArray[_addedMarkerCount * 3 - 1] = _markerRadius;

                // Restore the app to its normal state and clear the selection area adorment
                //Liyan Chang.
                //Only if there are four.

                _markerCenter = new Point(); //remove the old point
                _drawSelectionAdornment = false;
                pictureBoxDisplay.Invalidate(); //to clear up ellipses.

                if (_touchlessMgr.MarkerCount == 4)
                {
                    _fAddingMarker = false;
                    buttonMarkerAdd.Text = "Add A New Marker";
                    pictureBoxDisplay.Image = new Bitmap(pictureBoxDisplay.Width, pictureBoxDisplay.Height);

                    // Enable the demo and marker editing             
                    comboBoxMarkers.Enabled = true;
                }

                //checks if there are 4 markers and name them
                nameMarkers();
                
            }
        }

        #endregion Display Interaction

        #endregion Marker Mode

        #region Marker Functions

        #region Marker Initial Functions

        private void nameMarkers()
        {
            //This function is to name the added markers to m,n,o,p.
            if (_touchlessMgr.MarkerCount == 4)
            {
                m = _touchlessMgr.Markers.ElementAt(0);
                n = _touchlessMgr.Markers.ElementAt(1);
                o = _touchlessMgr.Markers.ElementAt(2);
                p = _touchlessMgr.Markers.ElementAt(3);

                m.OnChange += new EventHandler<MarkerEventArgs>(m_OnChange);
                n.OnChange += new EventHandler<MarkerEventArgs>(n_OnChange);
                o.OnChange += new EventHandler<MarkerEventArgs>(o_OnChange);
                p.OnChange += new EventHandler<MarkerEventArgs>(p_OnChange);

                _ratioScreenCameraHeight = 768/ _touchlessMgr.CurrentCamera.CaptureHeight;
                _ratioScreenCameraWidth = 1024/ _touchlessMgr.CurrentCamera.CaptureWidth;

                buttonMarkerAdd.Text = "Remove Markers";
            }

        }

        #endregion Marker Initial Functions

        #region Marker_OnChange

        void m_OnChange(object sender, MarkerEventArgs e)
        {            
            updatelabelMLocation(new Point(e.EventData.X * _ratioScreenCameraWidth, e.EventData.Y * _ratioScreenCameraHeight));
            Cursor.Position = new Point(labelM.Location.X - 1, labelM.Location.Y - 1);
            
            
            //What is NoN?
            //If the N marker is not present, the mouse will left click.
            //handSign_NoN();    
                    
            
            //NAMASTE (everyone requires this except menuDemo)
            if (!menuDemo && handSign_Menu())
            {
                RunMenuGesture(new EventArgs());
            }            

            //...............Specific........................
                     
            //TEST Demo  (no need of NoN)
            if (testDemo)
            {
                PainterForm_MouseMove(0, labelM.Location.X, labelM.Location.Y);
                PainterForm_MouseMove(1, labelN.Location.X, labelN.Location.Y);
                PainterForm_MouseMove(2, labelO.Location.X, labelO.Location.Y);
                PainterForm_MouseMove(3, labelP.Location.X, labelP.Location.Y);
            }

            //MAP Demo  
            else if (mapDemo)
            {
                handSign_NoN();
                mapDemo_OnChange();
            }        

            //PHOTO Demo  (no need of NoN)
            else if (photoDemo && handSign_TakePicture())
            {
                photo_clicked = true;
                RunPhotoGesture(new EventArgs());
            }

            //PRVIEW Demo
            else if (previewDemo)
            {
                updateImageM(this, e);
                if (handSign_PreviewTrigger())
                {
                    //buttonGalleryDemo_Click(this, new EventArgs());
                    RunGalleryDemo(new EventArgs());
                }
            }

            //NEWSPAPER Demo (no need of NoN)
            else if (newspaperDemo)
            {
                newspaperDemo_OnChange();
            }

            //.................no need of anything.................

            //GLOBE DEMO (no need of NoN)                
            //WEATHER Demo (no need of NoN)
            //BOOK Demo (no need of NoN)
            //CLOCK Demo (no need of NoN)            

            else if (globeDemo || weatherDemo || bookDemo || clockDemo)
            {
                //do nothing
            }

            //....................NoN.........................

            //DRAW Demo  
            //GALLERY Demo
            //MAIL Demo
            //STOCK Demo 
            //EFFECTS Demo
            //MENU Demo
            //GESTURE Demo

            else
            {
                handSign_NoN();
            }           
        }

        //OLD m_onchange

        //void m_OnChange(object sender, MarkerEventArgs e)
        //{
        //    updatelabelMLocation(new Point(e.EventData.X * _ratioScreenCameraWidth, e.EventData.Y * _ratioScreenCameraHeight));
        //    Cursor.Position = new Point(labelM.Location.X - 1, labelM.Location.Y - 1);

        //    //If the N marker is not present, the mouse will left click.
        //    handSign_NoN();

        //    //TEST Demo  (no need of NoN)
        //    if (testDemo)
        //    {
        //        PainterForm_MouseMove(0, labelM.Location.X, labelM.Location.Y);
        //        PainterForm_MouseMove(1, labelN.Location.X, labelN.Location.Y);
        //        PainterForm_MouseMove(2, labelO.Location.X, labelO.Location.Y);
        //        PainterForm_MouseMove(3, labelP.Location.X, labelP.Location.Y);
        //    }


        //    //DRAW Demo  

        //    //MAP Demo  
        //    if (mapDemo)
        //        mapDemo_OnChange();

        //    //PHOTO Demo  (no need of NoN)
        //    if (photoDemo && handSign_TakePicture())
        //        RunPhotoGesture(new EventArgs());

        //    //GALLERY Demo

        //    //MAIL Demo

        //    //WEATHER Demo (no need of NoN)

        //    //STOCK Demo 

        //    //EFFECTS Demo

        //    //NEWSPAPER Demo
        //    if (newspaperDemo)
        //        newspaperDemo_OnChange();

        //    //BOOK Demo (no need of NoN)

        //    //CLOCK Demo (no need of NoN)

        //    //MENU DEMO 
        //    if (!menuDemo && handSign_Menu())
        //        RunMenuGesture(new EventArgs());

        //}        

        void n_OnChange(object sender, MarkerEventArgs e)
        {
            updatelabelNLocation(new Point(e.EventData.X * _ratioScreenCameraWidth, e.EventData.Y * _ratioScreenCameraHeight));
        }
        void o_OnChange(object sender, MarkerEventArgs e)
        {
            updatelabelOLocation(new Point(e.EventData.X * _ratioScreenCameraWidth, e.EventData.Y * _ratioScreenCameraHeight));

            if (previewDemo)
            {
                updateImageO(this, e);
            }
        
        }
        void p_OnChange(object sender, MarkerEventArgs e)
        {
            updatelabelPLocation(new Point(e.EventData.X * _ratioScreenCameraWidth, e.EventData.Y * _ratioScreenCameraHeight));
        }

        #endregion Marker_OnChange

        #region UpdateLabelLocation

        delegate void updateLabelLocationDelegate(Point newPoint);
        delegate void runMenuGestureDelegate(EventArgs newe);
        delegate void runPhotoGestureDelegate(EventArgs newe);
        delegate void runNewsPaperGestureDelegate(EventArgs newe);
        delegate void runTimerDelegate(EventArgs moree);

        delegate void runGalleryDemoDelegate(EventArgs newe);

        private void RunMenuGesture(EventArgs newe)
        {
            if (buttonMenuDemo.InvokeRequired)
            {
                runMenuGestureDelegate delMenu = new runMenuGestureDelegate(RunMenuGesture);
                buttonMenuDemo.Invoke(delMenu, new object[] { newe });
            }
            else
            {
                buttonMenuDemo_Click(this, newe);
            }
        }
        private void RunPhotoGesture(EventArgs photoe)
        {
            if (photoDemo_TakePhoto.InvokeRequired)
            {
                runPhotoGestureDelegate delPhoto = new runPhotoGestureDelegate(RunPhotoGesture);
                photoDemo_TakePhoto.Invoke(delPhoto, new object[] { photoe });
            }
            else
            {
                photoDemo_TakePhoto_Hover(this, photoe);
            }
        }

        private void RunGalleryDemo(EventArgs newe)
        {
            if (buttonGalleryDemo.InvokeRequired)
            {
                //runPhotoGestureDelegate delPhoto = new runPhotoGestureDelegate(RunPhotoGesture);
                //photoDemo_TakePhoto.Invoke(delPhoto, new object[] { newe });
                runGalleryDemoDelegate delGallery = new runGalleryDemoDelegate(RunGalleryDemo);
                buttonGalleryDemo.Invoke(delGallery, new object[] { newe });
            }
            else
            {
                buttonGalleryDemo_Click(this, newe);
                //photoDemo_TakePhoto_Hover(this, newe);
            }
        }




        private void updatelabelMLocation(Point newPoint)
        {
            if (labelM.InvokeRequired)
            {
                updateLabelLocationDelegate del = new updateLabelLocationDelegate(updatelabelMLocation);
                labelM.Invoke(del, new object[] { newPoint });
            }
            else
            {
                labelM.Location = newPoint;
            }

        }
        private void updatelabelNLocation(Point newPoint)
        {
            if (labelN.InvokeRequired)
            {
                updateLabelLocationDelegate del = new updateLabelLocationDelegate(updatelabelNLocation);
                labelN.Invoke(del, new object[] { newPoint });
            }
            else
            {
                labelN.Location = newPoint;
            }
        }
        private void updatelabelOLocation(Point newPoint)
        {
            if (labelO.InvokeRequired)
            {
                updateLabelLocationDelegate del = new updateLabelLocationDelegate(updatelabelOLocation);
                labelO.Invoke(del, new object[] { newPoint });
            }
            else
            {
                labelO.Location = newPoint;
            }
        }
        private void updatelabelPLocation(Point newPoint)
        {
            if (labelP.InvokeRequired)
            {
                updateLabelLocationDelegate del = new updateLabelLocationDelegate(updatelabelPLocation);
                labelP.Invoke(del, new object[] { newPoint });
            }
            else
            {
                labelP.Location = newPoint;
            }
        }

        #endregion UpdateLabelLocation

        #region Gesture Helper Functions

        private long calculateDistance(Point a, Point b)
        {
            long distance =
                Math.Abs(
                    (a.X - b.X) ^ 2 +
                    (a.Y - b.Y) ^ 2
                    );
            return distance;
        }
        private long calculateDistance(int aX, int aY, int bX, int bY)
        {
            long distance =
                Math.Abs(
                    (aX - bX) ^ 2 +
                    (aY - bY) ^ 2
                    );
            return distance;
        }
        
        #endregion Gesture Helper Functions

        #region Gesture HandSigns Functions

        private bool handSign_NoN()
        {
            if (!n.PreviousData.Present && !_mousedown)
            {
                mouse_event(MOUSEEVENTF_LEFTDOWN, labelM.Location.X - 10, labelM.Location.Y - 10, 0, 0);
                _mousedown = true;
                return true;
            }
            else if (n.PreviousData.Present && _mousedown)
            {
                mouse_event(MOUSEEVENTF_LEFTUP, labelM.Location.X - 10, labelM.Location.Y - 10, 0, 0);
                _mousedown = false;
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool handSign_Menu()
        {

            if (((DateTime.Now.Ticks - menuStart) / TimeSpan.TicksPerMillisecond) > 2000)
            {
                menuStart = null;
                return true;
            }

            long distance1 = calculateDistance(labelM.Location, labelO.Location);
            long distance2 = calculateDistance(labelN.Location, labelP.Location);
            long distanceBetweenPairs = calculateDistance(labelM.Location, labelN.Location);

            if (distance1 < 150 && distance2 < 150 && distanceBetweenPairs > 100)
            {
                if (menuStart == null)
                    menuStart = DateTime.Now.Ticks;
                return false;
            }
            else
            {
                menuStart = null;
                return false;
            }
        }
        
        long previous_distance = 0;
        long current_distance = 0;
        long pinch_distance = 100;

        void handSign_scaleMap()
        {
            System.Threading.Thread.Sleep(20);

            current_distance = calculateDistance(labelM.Location, labelO.Location);
            pinch_distance = calculateDistance(labelM.Location, labelN.Location);

            if (pinch_distance < 100)
            {
                if ((current_distance - previous_distance) > 25)
                {
                    mouse_event(MOUSEEVENTF_LEFTDOWN, labelM.Location.X + current_distance / 2, labelM.Location.Y, 0, 0);
                    mouse_event(MOUSEEVENTF_LEFTUP, labelM.Location.X + current_distance / 2, labelM.Location.Y, 0, 0);

                    previous_distance = current_distance;
                }
                else if ((previous_distance - current_distance) > 25)
                {
                    //SHIFT KEY DOWN
                    keybd_event(VK_LSHIFT, 0x45, 0, 0);

                    mouse_event(MOUSEEVENTF_LEFTDOWN, labelM.Location.X + current_distance / 2, labelM.Location.Y, 0, 0);
                    mouse_event(MOUSEEVENTF_LEFTUP, labelM.Location.X + current_distance / 2, labelM.Location.Y, 0, 0);

                    //SHIFT KEY UP
                    keybd_event(VK_LSHIFT, 0x45, KEYEVENTF_KEYUP, 0);

                    previous_distance = current_distance;
                }
            }  
        }
        
        bool handSign_TakePicture()
        {
            if (!photo_clicked)
            {
                double timeElapsed = (DateTime.Now.Ticks - photoTaken) / TimeSpan.TicksPerMillisecond;

                long distance = calculateDistance(labelN.Location, labelO.Location) +
                    calculateDistance(labelM.Location, labelP.Location);

                if (distance < 150 && timeElapsed > 12000)
                {
                    photoTaken = DateTime.Now.Ticks;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private bool handSign_PreviewTrigger()
        {
            if (calculateDistance(labelM.Location, labelO.Location) < 50)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        void handSign_trackVideo()
        {
            //MessageBox.Show("changed");
            new_x1 = 0;
            new_y1 = 0;
            new_x2 = 500;
            new_y2 = 400;

            new_Theta = Math.Atan2(new_y2 - new_y1, new_x2 - new_x1) - Math.Atan2(y2 - y1, x2 - x1);
            new_distance = Math.Sqrt((new_x2 - new_x1) * (new_x2 - new_x1) + (new_y2 - new_y1) * (new_y2 - new_y1));

            System.Windows.Media.TransformGroup group = new System.Windows.Media.TransformGroup();

            group.Children.Add(new System.Windows.Media.ScaleTransform(new_distance / distance, new_distance / distance, x1, y1));
            group.Children.Add(new System.Windows.Media.RotateTransform(new_Theta / Math.PI * 180));
            group.Children.Add(new System.Windows.Media.TranslateTransform(new_x1 - x1, new_y1 - y1));

            mediaElement1.RenderTransform = group;

            x1 = new_x1;
            y1 = new_y1;
            x2 = new_x2;
            y2 = new_y2;
            Theta = new_Theta;
            distance = new_distance;                
        }

        #endregion Gesture HandSigns Functions

        #endregion Marker Functions

        #region Gesture Buttons

        private void btnRecord_Click(object sender, EventArgs e)
        {
            _points.Clear();
            Invalidate();
            _recording = !_recording; // recording will happen on mouse-up
            lblRecord.Visible = _recording;
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Gestures (*.xml)|*.xml";
            dlg.Title = "Load Gestures";
            dlg.Multiselect = true;
            dlg.RestoreDirectory = false;
            dlg.InitialDirectory = "Gestures";


            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;
                for (int i = 0; i < dlg.FileNames.Length; i++)
                {
                    string name = dlg.FileNames[i];
                    _rec.LoadGesture(name);
                }
                ReloadViewForm();
                Cursor.Current = Cursors.Default;
            }

        }
        private void btnView_Click(object sender, EventArgs e)
        {
            if (_viewFrm != null && !_viewFrm.IsDisposed)
            {
                _viewFrm.Close();
                _viewFrm = null;
            }
            else
            {
                Cursor.Current = Cursors.WaitCursor;
                _viewFrm = new ViewForm(_rec.Gestures);
                _viewFrm.Owner = this;
                _viewFrm.Show();
                Cursor.Current = Cursors.Default;
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "This will clear all loaded gestures. (It will not delete any XML files.)", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                _rec.ClearGestures();
                ReloadViewForm();
            }
        }

        #endregion Gesture Buttons

        #region Gesture Functions

        private void ReloadViewForm()
        {
            if (_viewFrm != null && !_viewFrm.IsDisposed)
            {
                _viewFrm.Close();
                _viewFrm = new ViewForm(_rec.Gestures);
                _viewFrm.Owner = this;
                _viewFrm.Show();
            }
        }
        private void gestureLoad()
        {
            string folderName = "Gestures";
            string[] filePath = Directory.GetFiles(folderName, "*.xml");

            foreach(string fileName in filePath)
                _rec.LoadGesture(fileName);

            ReloadViewForm();
            Cursor.Current = Cursors.Default;

        }

        #endregion Gesture Functions

        #region Gesture Mouse Events

        private void WUW_MouseDown(object sender, MouseEventArgs e)
        {
            _isDown = true;
            _points.Clear();
            _points.Add(new PointR(e.X, e.Y, Environment.TickCount));
            Invalidate();
        }
        private void WUW_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDown)
			{
				_points.Add(new PointR(e.X, e.Y, Environment.TickCount));
				Invalidate(new Rectangle(e.X - 2, e.Y - 2, 4, 4));
			}
		}
        private void WUW_MouseUp(object sender, MouseEventArgs e)
        {
            if (_isDown)
            {
                _isDown = false;

                if (_points.Count >= 5) // require 5 points for a valid gesture
                {
                    if (_recording)
                    {
                        SaveFileDialog dlg = new SaveFileDialog();
                        dlg.Filter = "Gestures (*.xml)|*.xml";
                        dlg.Title = "Save Gesture As";
                        dlg.AddExtension = true;
                        dlg.RestoreDirectory = false;
                        dlg.InitialDirectory = "Gestures";

                        if (dlg.ShowDialog(this) == DialogResult.OK)
                        {
                            _rec.SaveGesture(dlg.FileName, _points);  // resample, scale, translate to origin
                            ReloadViewForm();
                        }

                        dlg.Dispose();
                        _recording = false;
                        lblRecord.Visible = false;
                        Invalidate();
                    }
                    else if (_rec.NumGestures > 0) // not recording, so testing
                    {                        
                        Application.DoEvents(); // forces label to display

                        NBestList result = _rec.Recognize(_points); // where all the action is!!
                        lblResult.Text = String.Format("{0}: {1} ({2}px, {3}{4})",
                            result.Name,
                            Math.Round(result.Score, 2),
                            Math.Round(result.Distance, 2),
                            Math.Round(result.Angle, 2), (char)176);

                        switch (result.Name)
                        {
                            case "clock1":
                            case "clock2":
                                buttonClockDemo_Click(this, e);
                                break;
                            case "draw1":
                            case "draw2":
                            case "draw3":
                            case "draw4":
                                buttonDrawDemo_Click(this, e);
                                break;
                            case "email":
                                break;
                            case "map1":
                            case "map2":
                                buttonMapDemo_Click(this, e);
                                break;
                            case "menu1":
                            case "menu2":
                            case "menuSQ1":
                            case "menuSQ1b":
                            case "menuSQ2":
                                buttonMenuDemo_Click(this, e);
                                break;
                            case "photo1":
                            case "photo2":
                            case "photo3":
                            case "photo4":
                            case "photo5":
                            case "photo6":
                                buttonPhotoDemo_Click(this, e);
                                break;
                            case "weather1":
                            case "weather2":
                                buttonWeatherDemo_Click(this, e);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

		#endregion Gesture Mouse Events

        #region Demo Mode

        // 1st column

        #region Test Demo

        private void buttonTestDemo_Click(object sender, EventArgs e)
        {
            if (testDemo == false)
            {
                StopOtherApps(this, e);                
                testDemo = true;
                labelDemoName.Text = "Test";
                buttonTestDemo.Text = "Stop Test";
                pictureBoxTestDemo.Show();
                labelDemoInstructions.Enabled = true;
                labelDemoInstructions.Text = "Test Demo Instructions:\n\n"
                    + "Test that 4 fingers are tracked.\n";

                updatelabelMLocation(new Point(35, 9));
                updatelabelNLocation(new Point(35, 35));
                updatelabelOLocation(new Point(9, 9));
                updatelabelPLocation(new Point(9, 35));

            }
            else
            {
                testDemo = false;
                labelDemoName.Text = "WUW";
                buttonTestDemo.Text = "Test";                
                Cursor = Cursors.Arrow;
                pictureBoxTestDemo.Hide();
                labelDemoInstructions.Enabled = false;
                labelDemoInstructions.Text = "";
                ResetEnvironment();
            }
        }

        private void PainterForm_MouseMove(int index, int newX, int newY)
        {

            magX = Math.Min(100, 5 * (int)Math.Pow(Math.Abs(newX - mouseData[index, 0]), .5));
            magY = Math.Min(100, 5 * (int)Math.Pow(Math.Abs(newY - mouseData[index, 1]), .5));

            dirX = -1 * Math.Sign(newX - mouseData[index, 0]);
            dirY = -1 * Math.Sign(newX - mouseData[index, 1]);

            //make the cleaner. key to making the fade.
            SolidBrush cleanBrush = new SolidBrush(Color.FromArgb(25, 0, 0, 0));

            //LinearGradientBrush gradBrush = new
            //LinearGradientBrush(new Rectangle(0, 0, 1024, 768), Color.FromArgb(10, Color.Black), Color.FromArgb(10, Color.Black), 90, false);

            Graphics graphics = pictureBoxTestDemo.CreateGraphics();

            //lets draw some circles.
            // need to offset
            //graphics.FillEllipse(brushData[index], newX+50, newY+50, 15, 15);

            //create random generator for randomness

            Random randomGenerator = new Random();
            for (int i = 0; i < 20; i++)
            {
                graphics.FillRectangle(brushData[index], newX + dirX * randomGenerator.Next(0, magX), newY + dirY * randomGenerator.Next(0, magY), 30, 30);
            }

            if (index == 0)
            {
                graphics.FillRectangle(cleanBrush, 0, 0, 1024, 768);
            }
            //clean up
            graphics.Dispose();

            //get ready for next time.
            mouseData[index, 0] = newX;
            mouseData[index, 1] = newY;
        }

        #endregion Test Demo

        #region Draw Demo

        private void buttonDrawDemo_Click(object sender, EventArgs e)
        {
                if (drawDemo == false)
                {
                    StopOtherApps(this, e);
                    inkCanvas1 = new System.Windows.Controls.InkCanvas();
                    inkCanvas1.KeyDown += new System.Windows.Input.KeyEventHandler(inkCanvas1_KeyDown);
                    inkCanvas1.Background = System.Windows.Media.Brushes.Black;
                    inkCanvas1.DefaultDrawingAttributes.Color = System.Windows.Media.Colors.White;
                    inkCanvas1.DefaultDrawingAttributes.Width = 16;
                    inkCanvas1.DefaultDrawingAttributes.Height = 16;                    

                    elementHostDraw.Child = inkCanvas1;
                    
                    drawDemo = true;
                    labelDemoName.Text = "Draw";
                    buttonDrawDemo.Text = "Stop Draw";
                    //inkCanvasLoad();
                    elementHostDraw.Show();                                        
                    drawPanel.Show();
                    labelDemoInstructions.Enabled = true;
                    labelDemoInstructions.Text = "Draw Demo Instructions:\n\n"
                        + "Draws with Marker M when N is not\n"
                        + "present."; 

                }
                else
                {
                    drawDemo = false;
                    labelDemoName.Text = "WUW";
                    buttonDrawDemo.Text = "Draw";
                    //inkCanvasSaveJpeg();
                    elementHostDraw.Hide();
                    drawPanel.Hide();
                    Cursor = Cursors.Arrow;
                    labelDemoInstructions.Enabled = false;
                    labelDemoInstructions.Text = "";
                    ResetEnvironment();
                }
        }

        private void inkCanvasColor_Hover(object sender, EventArgs e)
        {
            Color inkColor = ((Control)sender).BackColor;
            inkCanvas1.DefaultDrawingAttributes.Color = System.Windows.Media.Color.FromArgb(inkColor.A, inkColor.R, inkColor.G, inkColor.B);
        }
        private void inkCanvasThinner_Hover(object sender, EventArgs e)
        {
            if (inkCanvas1.EditingMode != System.Windows.Controls.InkCanvasEditingMode.EraseByPoint)
            {
                if (inkCanvas1.DefaultDrawingAttributes.Height >= 4)
                {
                    inkCanvas1.DefaultDrawingAttributes.Height -= 2;
                    inkCanvas1.DefaultDrawingAttributes.Width -= 2;
                }
            }
            else
            {
                if (inkCanvas1.EraserShape.Height >= 2)
                    inkCanvas1.EraserShape = new System.Windows.Ink.RectangleStylusShape(inkCanvas1.EraserShape.Height - 2, inkCanvas1.EraserShape.Width - 2);
            }
        }
        private void inkCanvasThinner_Click(object sender, EventArgs e)
        {
            if (inkCanvas1.EditingMode != System.Windows.Controls.InkCanvasEditingMode.EraseByPoint)
            {
                if (inkCanvas1.DefaultDrawingAttributes.Height >= 14)
                {
                    inkCanvas1.DefaultDrawingAttributes.Height -= 10;
                    inkCanvas1.DefaultDrawingAttributes.Width -= 10;
                }
            }
            else
            {
                if (inkCanvas1.EraserShape.Height >= 10)
                    inkCanvas1.EraserShape = new System.Windows.Ink.RectangleStylusShape(inkCanvas1.EraserShape.Height - 10, inkCanvas1.EraserShape.Width - 10);
            }
        }
        private void inkCanvasThicker_Hover(object sender, EventArgs e)
        {
            if (inkCanvas1.EditingMode != System.Windows.Controls.InkCanvasEditingMode.EraseByPoint)
            {
                inkCanvas1.DefaultDrawingAttributes.Height += 2;
                inkCanvas1.DefaultDrawingAttributes.Width += 2;
            }
            else
            {
                inkCanvas1.EraserShape = new System.Windows.Ink.RectangleStylusShape(inkCanvas1.EraserShape.Height + 2, inkCanvas1.EraserShape.Width + 2);
            }
        }
        private void inkCanvasThicker_Click(object sender, EventArgs e)
        {
            if (inkCanvas1.EditingMode != System.Windows.Controls.InkCanvasEditingMode.EraseByPoint)
            {
                inkCanvas1.DefaultDrawingAttributes.Height += 10;
                inkCanvas1.DefaultDrawingAttributes.Width += 10;
            }
            else
            {
                inkCanvas1.EraserShape = new System.Windows.Ink.RectangleStylusShape(inkCanvas1.EraserShape.Height + 10, inkCanvas1.EraserShape.Width + 10);
            }
        }
        private void inkCanvasToggle_Hover(object sender, EventArgs e)
        {
            if (inkCanvas1.EditingMode != System.Windows.Controls.InkCanvasEditingMode.EraseByPoint)
            {
                inkCanvas1.EditingMode = System.Windows.Controls.InkCanvasEditingMode.EraseByPoint;
                inkCanvasToggle.Text = "!";
                //#
            }
            else
            {
                inkCanvas1.EditingMode = System.Windows.Controls.InkCanvasEditingMode.Ink;
                inkCanvasToggle.Text = "x";
                //%
            }
        }
        
        #region inksaveload

        //private void inkCanvasSave()
        //{
        //    // Specify the folder and file your ink data will be stored in 
        //    string folderName = "Inkings";
        //    string filePath = folderName + "\\savedInkStrokes.ink";

        //    // Check if directory exists 
        //    if (!Directory.Exists(folderName))
        //    {
        //        Directory.CreateDirectory(folderName);
        //    }

        //    // Create a new file (or overwrite an existing one) to store our data 
        //    FileStream inkCanvasFileStream = new FileStream(filePath, FileMode.Create);

        //    // Transfer your data and close the file. 
        //    inkCanvas1.Strokes.Save(inkCanvasFileStream);
        //    inkCanvasFileStream.Close();
        //}
        
        //private void inkCanvasSaveJpeg()
        //{
        //    //This will save two 

        //    // Specify the folder and file your ink data will be stored in 
        //    string folderName = "Inkings";
        //    string filePath;

        //    if (Directory.Exists(folderName))
        //    {
        //        filePath = folderName + "\\" + Directory.GetFiles(folderName).Length.ToString();
        //        if (File.Exists(filePath + ".ink"))
        //        { 
        //            filePath += "(copy)"; 
        //        }
        //    }
        //    else
        //    {
        //        Directory.CreateDirectory("Inkings");
        //        filePath = folderName + "\\1";
        //    }

        //    //save the strokes
        //    FileStream inkCanvasFileStreamInk = new FileStream(filePath + ".ink", FileMode.Create);
        //    inkCanvas1.Strokes.Save(inkCanvasFileStreamInk);
        //    inkCanvasFileStreamInk.Close();

        //    //render the strokes for JPEG
        //    FileStream inkCanvasFileStream = new FileStream(filePath+".jpg", FileMode.Create);
        //    int marg = int.Parse(this.inkCanvas1.Margin.Left.ToString());
        //    RenderTargetBitmap rtb =
        //            new RenderTargetBitmap((int)this.inkCanvas1.ActualWidth - marg,
        //                    (int)this.inkCanvas1.ActualHeight - marg, 0, 0,
        //                System.Windows.Media.PixelFormats.Default);
        //    rtb.Render(this.inkCanvas1);
        //    BmpBitmapEncoder encoder = new BmpBitmapEncoder();
        //    encoder.Frames.Add(BitmapFrame.Create(rtb));
        //    encoder.Save(inkCanvasFileStream);
        //    inkCanvasFileStream.Close();
            
        //}

        //private void inkCanvasLoad(string filePath)
        //{

        //    // If our file exists, 
        //    if (File.Exists(filePath))
        //    {
        //        FileStream inkCanvasFileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        //        StrokeCollection savedInkStrokes = new StrokeCollection(inkCanvasFileStream);
        //        inkCanvasFileStream.Close();

        //        inkCanvas1.Strokes = savedInkStrokes;
        //    }
        //}
        #endregion inksaveload

        #endregion Draw Demo

        #region Map Demo

        private void buttonMapDemo_Click(object sender, EventArgs e)
        {
                if (mapDemo == false)
                {
                    StopOtherApps(this, e);
                    webBrowserMap.Url = new Uri("http://localhost//MAP//DeepZoomProjectTestPage.html");
                    mapDemo = true;
                    labelDemoName.Text = "Map";
                    buttonMapDemo.Text = "Stop Map";                    
                    webBrowserMap.Show();
                    Cursor = Cursors.Hand;
                    labelDemoInstructions.Enabled = true;
                    labelDemoInstructions.Text = "Map Demo Instructions:\n";
                }
                else
                {
                    mapDemo = false;
                    labelDemoName.Text = "WUW";
                    buttonMapDemo.Text = "Map";
                    webBrowserMap.Url = null;
                    webBrowserMap.Hide();                    
                    Cursor = Cursors.Arrow;
                    labelDemoInstructions.Enabled = false;
                    labelDemoInstructions.Text = "";
                    ResetEnvironment();
                }
        }
        private void mapDemo_OnChange()
        {
            handSign_scaleMap();
        }        

        #endregion Map Demo

        #region Photo Demo

        private void buttonPhotoDemo_Click(object sender, EventArgs e)
        {
            if (photoDemo == false)
            {
                StopOtherApps(this, e);                                
                photoDemo_TakePhoto.Show();
                photoDemo = true;
                labelDemoName.Text = "Photo";
                buttonPhotoDemo.Text = "Stop Photo";
                pictureBoxAlbum.Show();                
                Cursor = Cursors.Hand;
                labelDemoInstructions.Enabled = true;
                labelDemoInstructions.Text = "Photo Demo Instructions:\n\n"
                    + "Use two markers to move two pointers.\n"
                    + "Move them close together to click.";                    
            }
            else
            {
                photoDemo = false;
                labelDemoName.Text = "WUW";
                buttonPhotoDemo.Text = "Photo";
                pictureBoxAlbum.Hide();
                photoDemo_TakePhoto.Hide();
                photo_clicked = false;
                Cursor = Cursors.Arrow;
                labelDemoInstructions.Enabled = false;
                labelDemoInstructions.Text = "";
                ResetEnvironment();
            }
        }
        void PhotoDemo_TakePicture()
        {
            Bitmap _latestFrame_Resize = new Bitmap(_latestFrame, 640, 480);
            pictureBoxAlbum.Image = _latestFrame_Resize;
            if (Directory.Exists("pics"))
            {
                //saves in pic folder
                string newimage = "pics//" + Directory.GetFiles("pics").Length.ToString() + ".jpg";                
                _latestFrame.Save(newimage, System.Drawing.Imaging.ImageFormat.Jpeg);                
            }
            else
            {
                Directory.CreateDirectory("pics");
                _latestFrame.Save("pics//1.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            }

            //saves in Media folder of Gallery
            string galleryimgae = "E://WUWdata//WUWweb//Media//img8.jpg";
            _latestFrame_Resize.Save(galleryimgae, System.Drawing.Imaging.ImageFormat.Jpeg);       

        }
        private void photoDemo_TakePhoto_Hover(object sender, EventArgs e)
        {         
            Timer = new System.Windows.Forms.Timer();
            Timer.Interval = 1000;
            Timer.Start();
            Timer.Tick += new EventHandler(Timer_Tick);
            photoDemo_TakePhoto.Hide();
        }
        public void Timer_Tick(object sender, EventArgs eArgs)
        {
            if (timerSum >= 3)
            {
                Timer.Stop();
                Timer.Dispose();
                timerSum = 0;
                System.Media.SystemSounds.Asterisk.Play();
                PhotoDemo_TakePicture();
                buttonGalleryDemo_Click(this, eArgs);
            }
            else
            {
                System.Media.SystemSounds.Beep.Play();
                timerSum++;
            }
        }

        #endregion Photo Demo

        #region Preview Demo

        private void buttonPreviewDemo_Click(object sender, EventArgs e)
        {

            if (previewDemo == false)
            {
                StopOtherApps(this, e);
                previewDemo = true;
                labelDemoName.Text = "Preview";
                buttonPreviewDemo.Text = "Stop Preview";
                labelDemoInstructions.Enabled = true;
                labelDemoInstructions.Text = "Preview Demo Instructions:\n\n"
                    + "Preivew.\n";

                if (_touchlessMgr.MarkerCount >= 2)
                {

                    //Set the images
                    _image = new Bitmap("pics/0.jpg");
                    _imageWidth = _image.Width;
                    _imageHeight = _image.Height;

                    // Initialize the bounds
                    _captureWidth = _touchlessMgr.CurrentCamera.CaptureWidth;
                    _captureHeight = _touchlessMgr.CurrentCamera.CaptureHeight;
                    _displayWidth = 1024;
                    _displayHeight = 768;
                    _displayScale = _displayWidth / _touchlessMgr.CurrentCamera.CaptureWidth;

                    // Initialize the points used for placing the image
                    _destPoints = new Point[3];
                    _destPoints[0] = new Point();
                    _destPoints[1] = new Point();
                    _destPoints[2] = new Point();

                    // Calculate the image's diagonal length
                    _imageDiagonal = (float)Math.Sqrt(_imageWidth * _imageWidth + _imageHeight * _imageHeight);
                    // The angle from the lower-left corner to the upper right corner (from North)
                    _imageDiagonalAngle = (float)Math.Atan2(_imageWidth, _imageHeight);
                    
                    //draw here
                    pictureBoxPreview.Show();
                    pictureBoxPreview.Paint += new PaintEventHandler(updateImage);
                }
                else
                {
                    MessageBox.Show("Need 2 markers");
                    buttonPreviewDemo_Click(this, e);
                }
            }
            else
            {

                previewDemo = false;
                labelDemoName.Text = "WUW";
                buttonPreviewDemo.Text = "Preview";
                pictureBoxPreview.Hide();
                Cursor = Cursors.Arrow;
                labelDemoInstructions.Enabled = false;
                labelDemoInstructions.Text = "";
                ResetEnvironment();
            }

        }

        private void recalculateTransformation()
        {
            // Make sure the other two points are valid
            if (_destPoints[2].IsEmpty || _destPoints[1].IsEmpty)
                return;

            // Make local copies of the other two points
            Point upperRight = _destPoints[1];
            Point lowerLeft = _destPoints[2];

            // Determine the image scale based on the distance between the points and the base diagonal
            int dx = upperRight.X - lowerLeft.X;
            int dy = lowerLeft.Y - upperRight.Y;
            float scaledDiagonal = (float)Math.Sqrt(dx * dx + dy * dy);
            _imageScale = scaledDiagonal / _imageDiagonal;

            // Find the scaled height
            float scaledHeight = _imageHeight * _imageScale;

            // Find the current diagonal angle (from East)
            float currDiagAngle = (float)Math.Atan2(dy, dx);

            // Find the current left edge angle (from West)
            float currLeftEdgeAngle = (float)Math.PI - (currDiagAngle + _imageDiagonalAngle);

            // Find the x difference from the lower-left to the upper-left
            float diffX = (float)(Math.Cos(currLeftEdgeAngle) * scaledHeight);
            float diffY = (float)(Math.Sin(currLeftEdgeAngle) * scaledHeight);

            // Find the upper-left point
            _destPoints[0].X = (int)(lowerLeft.X - diffX);
            _destPoints[0].Y = (int)(lowerLeft.Y - diffY);

            pictureBoxPreview.Invalidate();
        }

        private void updateImageM(object sender, MarkerEventArgs args)
        {
            // Set the lower-left point
            _destPoints[2].X = (int)(args.EventData.X * _displayScale);
            _destPoints[2].Y = (int)(args.EventData.Y * _displayScale);

            // Recalculate the upper-left point
            recalculateTransformation();
        }

        private void updateImageO(object sender, MarkerEventArgs args)
        {
            // Set the upper-right point
            _destPoints[1].X = (int)(args.EventData.X * _displayScale);
            _destPoints[1].Y = (int)(args.EventData.Y * _displayScale);

            // Recalculate the upper-left point
            recalculateTransformation();
        }

        private void updateImage(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(_image, _destPoints);
        }

        #endregion Preview Demo

        #region Gallery Demo

        private void buttonGalleryDemo_Click(object sender, EventArgs e)
        {
            if (galleryDemo == false)
            {
                StopOtherApps(this, e);
                webBrowserGallery.Url = new Uri("http://localhost//Default.aspx");
                galleryDemo = true;
                labelDemoName.Text = "Gallery";
                buttonGalleryDemo.Text = "Stop Gallery";
                webBrowserGallery.Show();
                labelDemoInstructions.Enabled = true;
                labelDemoInstructions.Text = "Gallery Demo Instructions:\n\n"
                    + "Photo Gallery.\n";
            }
            else
            {
                galleryDemo = false;
                labelDemoName.Text = "WUW";
                buttonGalleryDemo.Text = "Gallery";
                webBrowserGallery.Hide();
                Cursor = Cursors.Arrow;
                labelDemoInstructions.Enabled = false;
                labelDemoInstructions.Text = "";
                ResetEnvironment();
            }

        }

        #endregion Gallery Demo

        // 2nd column

        #region Globe Demo

        private void buttonGlobeDemo_Click(object sender, EventArgs e)
        {
            if (globeDemo == false)
            {
                StopOtherApps(this, e);
                GlobeDemo_Flash.LoadMovie(0, "http://localhost/SWF/dof05reverse.swf");
                globeDemo = true;
                labelDemoName.Text = "Globe";
                buttonGlobeDemo.Text = "Stop Globe";
                GlobeDemo_Flash.Show();
                labelDemoInstructions.Enabled = true;
                labelDemoInstructions.Text = "Globe Demo Instructions:\n\n"
                    + "3D Globe.\n";
            }
            else
            {
                globeDemo = false;
                labelDemoName.Text = "WUW";
                buttonGlobeDemo.Text = "Globe";
                GlobeDemo_Flash.Hide();
                Cursor = Cursors.Arrow;
                labelDemoInstructions.Enabled = false;
                labelDemoInstructions.Text = "";
                ResetEnvironment();
            }

        }

        #endregion Globe Demo
        
        #region Mail Demo

        private void buttonMailDemo_Click(object sender, EventArgs e)
        {
            if (mailDemo == false)
            {
                StopOtherApps(this, e);
                elementHostMail.Child = Control_mail;
                mailDemo = true;
                labelDemoName.Text = "Mail";
                buttonMailDemo.Text = "Stop Mail";
                elementHostMail.Show();
                labelDemoInstructions.Enabled = true;
                labelDemoInstructions.Text = "Mail Demo Instructions:\n\n"
                    + "Check Mails.\n";
            }
            else
            {
                mailDemo = false;
                labelDemoName.Text = "WUW";
                buttonMailDemo.Text = "Mail";
                elementHostMail.Hide();
                Cursor = Cursors.Arrow;
                labelDemoInstructions.Enabled = false;
                labelDemoInstructions.Text = "";
                ResetEnvironment();
            }
        }

        #endregion Mail Demo

        #region Weather Demo

        private void buttonWeatherDemo_Click(object sender, EventArgs e)
        {

            if (weatherDemo == false && InternetConnectionExists())
            {
                StopOtherApps(this, e);
                Control_weather = new WPFControl_Weather01.UserControl1();
                elementHostWeather.Child = Control_weather;
                weatherDemo = true;
                labelDemoName.Text = "Weather";
                buttonWeatherDemo.Text = "Stop Weather";
                elementHostWeather.Show();
                labelDemoInstructions.Enabled = true;
                labelDemoInstructions.Text = "Weather Demo Instructions:\n\n"
                    + "Weather Demo";

            }
            else
            {
                weatherDemo = false;
                labelDemoName.Text = "WUW";
                buttonWeatherDemo.Text = "Weather";
                Control_weather = null;
                elementHostWeather.Hide();
                Cursor = Cursors.Arrow;
                labelDemoInstructions.Enabled = false;
                labelDemoInstructions.Text = "";
                ResetEnvironment();
            }
        }

        bool InternetConnectionExists()
        {
            try
            {
                System.Net.Sockets.TcpClient clnt = new System.Net.Sockets.TcpClient("www.google.com", 80);
                clnt.Close();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        #endregion Weather Demo

        #region Stock Demo
        
        private void buttonStockDemo_Click(object sender, EventArgs e)
        {
            if (stockDemo == false)
            {
                StopOtherApps(this, e);                
                elementHostStock.Child = Control_stock;
                stockDemo = true;
                labelDemoName.Text = "Stock";
                buttonStockDemo.Text = "Stop Stock";
                elementHostStock.Show();
                labelDemoInstructions.Enabled = true;
                labelDemoInstructions.Text = "Stock Demo Instructions:\n\n"
                    + "Shows stocks from internet.\n";
            }
            else
            {
                stockDemo = false;
                labelDemoName.Text = "WUW";
                buttonStockDemo.Text = "Stock";
                elementHostStock.Hide();
                Cursor = Cursors.Arrow;
                labelDemoInstructions.Enabled = false;
                labelDemoInstructions.Text = "";
                ResetEnvironment();
            }

        }

        #endregion Stock Demo

        #region Effects Demo

        private void buttonEffectsDemo_Click(object sender, EventArgs e)
        {
            if (effectsDemo == false)
            {
                StopOtherApps(this, e);                
                EffectsDemo_Flash.LoadMovie(0, "http://localhost/SWF/neave_imagination.swf");
                effectsDemo = true;
                labelDemoName.Text = "Effects";
                buttonEffectsDemo.Text = "Stop Effects";
                EffectsDemo_Flash.Show();
                labelDemoInstructions.Enabled = true;
                labelDemoInstructions.Text = "Effects Demo Instructions:\n\n"
                    + "Interactive Visual Effects.\n";
            }
            else
            {
                effectsDemo = false;
                labelDemoName.Text = "WUW";
                buttonEffectsDemo.Text = "Effects";
                EffectsDemo_Flash.Hide();
                Cursor = Cursors.Arrow;
                labelDemoInstructions.Enabled = false;
                labelDemoInstructions.Text = "";
                ResetEnvironment();
            }

        }

        #endregion Effects Demo

        // 3rd column

        #region NewsPaper Demo

        private void buttonNewsPaperDemo_Click(object sender, EventArgs e)
        {         
            if (newspaperDemo == false)
            {
                
                StopOtherApps(this, e);                
                newspaperDemo = true;
                labelDemoName.Text = "NewsPaper";
                buttonNewsPaperDemo.Text = "Stop NewsPaper";                
                labelDemoInstructions.Enabled = true;
                labelDemoInstructions.Text = "NewsPaper Demo Instructions:\n\n"
                    + "NewsPaper Video.\n";

                System.Windows.Controls.MediaElement mediaElement1 = new System.Windows.Controls.MediaElement();
                

                mediaElement1.Source = new Uri("C:\\Users\\Public\\Videos\\Sample Videos\\Lake.wmv");
                mediaElement1.Height = 768;
                mediaElement1.Width = 1024;

                //new code
                //new_x1 = 0;
                //new_y1 = 0;
                //new_x2 = 500;
                //new_y2 = 400;

                //new_Theta = Math.Atan2(new_y2 - new_y1, new_x2 - new_x1) - Math.Atan2(y2 - y1, x2 - x1);
                //new_distance = Math.Sqrt((new_x2 - new_x1) * (new_x2 - new_x1) + (new_y2 - new_y1) * (new_y2 - new_y1));

                //group.Children.Add(new System.Windows.Media.ScaleTransform(new_distance / distance, new_distance / distance, x1, y1));
                //group.Children.Add(new System.Windows.Media.RotateTransform(new_Theta / Math.PI * 180));
                //group.Children.Add(new System.Windows.Media.TranslateTransform(new_x1 - x1, new_y1 - y1));

                //mediaElement1.RenderTransform = group;

                //x1 = new_x1;
                //y1 = new_y1;
                //x2 = new_x2;
                //y2 = new_y2;
                //Theta = new_Theta;
                //distance = new_distance;
                                
                elementHostNewsPaper.Child = mediaElement1;

                elementHostNewsPaper.Show();
            }
            else
            {
                newspaperDemo = false;
                labelDemoName.Text = "WUW";
                buttonNewsPaperDemo.Text = "NewsPaper";
                elementHostNewsPaper.Hide();
                Cursor = Cursors.Arrow;
                labelDemoInstructions.Enabled = false;
                labelDemoInstructions.Text = "";
                ResetEnvironment();
            }

        }

        private void newspaperDemo_OnChange()
        {
            handSign_trackVideo();
        }

        #endregion NewsPaper Demo

        #region Book Demo

        private void buttonBookDemo_Click(object sender, EventArgs e)
        {
            if (bookDemo == false)
            {
                StopOtherApps(this, e);                
                bookDemo = true;
                labelDemoName.Text = "Book";
                buttonBookDemo.Text = "Stop Book";
                labelDemoInstructions.Enabled = true;
                labelDemoInstructions.Text = "Book Demo Instructions:\n\n"
                    + "Book \n";

                //pictureBoxAlbum.Show();
                lblResult.Hide();

                //NYAR
                //initialize nyar components.
                NyARParam ap = new NyARParam();
                ap.loadARParamFromFile(AR_CAMERA_FILE);
                ap.changeScreenSize(SCREEN_WIDTH, SCREEN_HEIGHT);
                _raster = new DsBGRX32Raster(SCREEN_WIDTH, SCREEN_HEIGHT, SCREEN_WIDTH * 32 / 8);
                _utils = new NyARD3dUtil();

                // For each pattern
                NyARCode code1 = new NyARCode(16, 16);
                code1.loadARPattFromFile(AR_CODE_FILE1);
                _ar1 = new NyARSingleDetectMarker(ap, code1, 80.0);
                _ar1.setContinueMode(false);

                NyARCode code2 = new NyARCode(16, 16);
                code2.loadARPattFromFile(AR_CODE_FILE2);
                _ar2 = new NyARSingleDetectMarker(ap, code2, 80.0);
                _ar2.setContinueMode(false);

                NyARCode code3 = new NyARCode(16, 16);
                code3.loadARPattFromFile(AR_CODE_FILE3);
                _ar3 = new NyARSingleDetectMarker(ap, code3, 80.0);
                _ar3.setContinueMode(false);

                NyARCode code4 = new NyARCode(16, 16);
                code4.loadARPattFromFile(AR_CODE_FILE4);
                _ar4 = new NyARSingleDetectMarker(ap, code4, 80.0);
                _ar4.setContinueMode(false);
            }
            else
            {
                bookDemo = false;
                labelDemoName.Text = "WUW";
                buttonBookDemo.Text = "Book";
                Cursor = Cursors.Arrow;
                labelDemoInstructions.Enabled = false;
                labelDemoInstructions.Text = "";
                ResetEnvironment();

                //pictureBoxAlbum.Hide();
                lblResult.Show();
            }

        }

        private void nyar()
        {
            // - load the image to a bitmap
            Bitmap _latestFrameBitmap = (Bitmap)_latestFrame;

            // - create a new bitmap with diff. file format. PixelFormat.Format32bppArbg
            Bitmap _latestFrameShift = new Bitmap(_latestFrameBitmap.Width, _latestFrameBitmap.Height, PixelFormat.Format32bppArgb);
            _latestFrameShift.SetResolution(_latestFrameBitmap.HorizontalResolution, _latestFrameBitmap.VerticalResolution);

            // - copy the data from first bitmap to second.
            Graphics g = Graphics.FromImage(_latestFrameShift);
            g.DrawImage(_latestFrameBitmap, 0, 0);
            g.Dispose();

            // - change the bitmap into an intptr
            Rectangle _latestFrameShiftRect = new Rectangle(0, 0, _latestFrameShift.Width, _latestFrameShift.Height);
            BitmapData _latestFrameShiftData = _latestFrameShift.LockBits(_latestFrameShiftRect, ImageLockMode.ReadWrite, _latestFrameShift.PixelFormat);
            IntPtr fakeBuffer = _latestFrameShiftData.Scan0;

            _latestFrameShift.UnlockBits(_latestFrameShiftData);

            // - use the fake buffer
            _raster.setBuffer(fakeBuffer);

            //Begin to DETECT.

            //Try all three.
            _ar1.detectMarkerLite(_raster, 110);
            _ar2.detectMarkerLite(_raster, 110);
            _ar3.detectMarkerLite(_raster, 110);
            _ar4.detectMarkerLite(_raster, 110);

            NyARSingleDetectMarker[] _arArray = new NyARSingleDetectMarker[4] { _ar1, _ar2, _ar3, _ar4 };
            _arFinal = largestNyar(_arArray);

            is_marker_enable = _arFinal.detectMarkerLite(_raster, 110);

            if (is_marker_enable && _arFinal.getConfidence() > 0.3)
            {
                labelDemoName.Text = "Pattern #" + largestNyarIndex(_arArray) + "[" + _arFinal.getConfidence().ToString() + "]";
            }
            else
            {
                labelDemoName.Text = "No Pattern";
            }

            //display some feedback.            
            pictureBoxAlbum.Image = _latestFrameShift;
        }

        private NyARSingleDetectMarker largestNyar(NyARSingleDetectMarker[] nyarArray)
        {
            NyARSingleDetectMarker maxNyar = nyarArray[0];
            double maxConfidence = 0;
            for (int i = 0; i < nyarArray.Length; i++)
            {
                if (nyarArray[i].getConfidence() > maxConfidence)
                {
                    maxConfidence = nyarArray[i].getConfidence();
                    maxNyar = nyarArray[i];
                }
            }
            return maxNyar;
        }

        private int largestNyarIndex(NyARSingleDetectMarker[] nyarArray)
        {
            int maxIndex = 0;
            double maxConfidence = 0;
            for (int i = 0; i < nyarArray.Length; i++)
            {
                if (nyarArray[i].getConfidence() > maxConfidence)
                {
                    maxConfidence = nyarArray[i].getConfidence();
                    maxIndex = i;
                }
            }
            return maxIndex;
        }

        #endregion Book Demo
        
        #region Clock Demo

        private void buttonClockDemo_Click(object sender, EventArgs e)
        {
            if (clockDemo == false)
            {
                StopOtherApps(this, e);
                //elementHostClock.Child = Control_clock;
                elementHostClock.Child = Control_ink;
                clockDemo = true;
                labelDemoName.Text = "Clock";
                buttonClockDemo.Text = "Stop Clock";
                elementHostClock.Show();
                labelDemoInstructions.Enabled = true;
                labelDemoInstructions.Text = "Clock Demo Instructions:\n\n"
                    + "Clock follows Marker M.";                
                
                System.Windows.RoutedEventArgs x = new System.Windows.RoutedEventArgs();

                Control_ink.ClearInk(sender, x);
                
                if (checkBox_F.Checked)
                {                    
                    Control_ink.PlayBackInk(sender, x);
                    checkBox_F.Checked = false;
                }
            }
            else
            {
                clockDemo = false;
                labelDemoName.Text = "WUW";
                buttonClockDemo.Text = "Clock";
                elementHostClock.Hide();
                Cursor = Cursors.Arrow;
                labelDemoInstructions.Enabled = false;
                labelDemoInstructions.Text = "";
                ResetEnvironment();
            }
        }
        #endregion Clock Demo
        
        //

        #region Menu Demo

        private void buttonMenuDemo_Click(object sender, EventArgs e)
        {
            if (menuDemo == false)
            {
                StopOtherApps(this, e);
                elementHostMenu.Child = Control_menu;
                menuDemo = true;
                labelDemoName.Text = "Menu";
                buttonMenuDemo.Text = "Stop Menu";
                elementHostMenu.Show();
                labelDemoInstructions.Enabled = true;
                labelDemoInstructions.Text = "Menu Demo Instructions:\n\n"
                    + "Mail Menu of WUW\n";
            }
            else
            {
                menuDemo = false;
                labelDemoName.Text = "WUW";
                buttonMenuDemo.Text = "Menu";
                elementHostMenu.Hide();
                Cursor = Cursors.Arrow;
                labelDemoInstructions.Enabled = false;
                labelDemoInstructions.Text = "";
                ResetEnvironment();
                Control_menu.SelectedAppNumber = -1; // Deselects the last selection
            }
        }

        void Control_menu_AppListSelectionChanged(object sender, EventArgs e)
        {
            switch (Control_menu.SelectedAppNumber)
            {
                //DRAW
                case 0:
                    buttonDrawDemo_Click(sender, e);
                    return;

                //MAP
                case 1:
                    buttonMapDemo_Click(sender, e);
                    return;
                
                //PHOTO
                case 2:
                    buttonPhotoDemo_Click(sender, e);
                    return;

                //GLOBE
                case 3:
                    buttonGlobeDemo_Click(sender, e);                    
                    return;

                //MAIL
                case 4:
                    buttonMailDemo_Click(sender, e);
                    return;

                //WEATHER
                case 5:
                    buttonWeatherDemo_Click(sender, e);
                    return;

                //STOCK
                case 6:
                    buttonStockDemo_Click(sender, e);
                    return;

                //CLOCK
                case 7:
                    buttonClockDemo_Click(sender, e);
                    return;

                //GESTURE
                case 8:
                    buttonGestureDemo_Click(sender, e);
                    return;
            }           
            
        }

        #endregion Menu Demo

        #region Gesture Demo

        private void buttonGestureDemo_Click(object sender, EventArgs e)
        {
            //if (gestureDemo == false)
            //{
            //    StopOtherApps(this, e);
            //    gestureDemo = true;
            //    labelDemoName.Text = "Gesture";
            //    buttonMenuDemo.Text = "Stop Gesture";                
            //    labelDemoInstructions.Enabled = true;
            //    labelDemoInstructions.Text = "Gesture Demo Instructions:\n\n"
            //        + "Gesture Demo\n";
            //}
            //else
            //{
            //    //gestureDemo = false;
            //    labelDemoName.Text = "WUW";
            //    buttonGestureDemo.Text = "Gesture";                
            //    Cursor = Cursors.Arrow;
            //    labelDemoInstructions.Enabled = false;
            //    labelDemoInstructions.Text = "";
            //    ResetEnvironment();                 
            //}
            StopOtherApps(this, e);
        }

        #endregion Gesture Demo





        #endregion Demo Mode

    }
}

       		

        