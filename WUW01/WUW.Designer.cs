namespace WUW01
{
    partial class WUW
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxDisplay = new System.Windows.Forms.PictureBox();
            this.tabSettings = new System.Windows.Forms.TabControl();
            this.tabPageCamera = new System.Windows.Forms.TabPage();
            this.lblRecord = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnRecord = new System.Windows.Forms.Button();
            this.groupBoxCameraInfo = new System.Windows.Forms.GroupBox();
            this.checkBoxCameraFPSLimit = new System.Windows.Forms.CheckBox();
            this.labelCameraFPSValue = new System.Windows.Forms.Label();
            this.numericUpDownCameraFPSLimit = new System.Windows.Forms.NumericUpDown();
            this.labelCameraFPS = new System.Windows.Forms.Label();
            this.buttonCameraProperties = new System.Windows.Forms.Button();
            this.comboBoxCameras = new System.Windows.Forms.ComboBox();
            this.tabPageTokens = new System.Windows.Forms.TabPage();
            this.buttonLoadMarkers = new System.Windows.Forms.Button();
            this.buttonSaveMarkers = new System.Windows.Forms.Button();
            this.lblMarkerCount = new System.Windows.Forms.Label();
            this.lblTotalMarker = new System.Windows.Forms.Label();
            this.groupBoxMarkerControl = new System.Windows.Forms.GroupBox();
            this.numericUpDownMarkerThresh = new System.Windows.Forms.NumericUpDown();
            this.labelMarkerThresh = new System.Windows.Forms.Label();
            this.checkBoxMarkerSmoothing = new System.Windows.Forms.CheckBox();
            this.checkBoxMarkerHighlight = new System.Windows.Forms.CheckBox();
            this.labelMarkerData = new System.Windows.Forms.RichTextBox();
            this.buttonMarkerRemove = new System.Windows.Forms.Button();
            this.comboBoxMarkers = new System.Windows.Forms.ComboBox();
            this.buttonMarkerAdd = new System.Windows.Forms.Button();
            this.tabPageApps = new System.Windows.Forms.TabPage();
            this.checkBox_F = new System.Windows.Forms.CheckBox();
            this.buttonEffectsDemo = new System.Windows.Forms.Button();
            this.buttonTestDemo = new System.Windows.Forms.Button();
            this.buttonGlobeDemo = new System.Windows.Forms.Button();
            this.buttonStockDemo = new System.Windows.Forms.Button();
            this.buttonGalleryDemo = new System.Windows.Forms.Button();
            this.buttonBookDemo = new System.Windows.Forms.Button();
            this.buttonMailDemo = new System.Windows.Forms.Button();
            this.buttonNewsPaperDemo = new System.Windows.Forms.Button();
            this.buttonWeatherDemo = new System.Windows.Forms.Button();
            this.buttonMenuDemo = new System.Windows.Forms.Button();
            this.buttonClockDemo = new System.Windows.Forms.Button();
            this.buttonPhotoDemo = new System.Windows.Forms.Button();
            this.buttonGestureDemo = new System.Windows.Forms.Button();
            this.buttonMapDemo = new System.Windows.Forms.Button();
            this.buttonDrawDemo = new System.Windows.Forms.Button();
            this.labelDemoInstructions = new System.Windows.Forms.RichTextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnShowHide = new System.Windows.Forms.Button();
            this.elementHostDraw = new System.Windows.Forms.Integration.ElementHost();
            this.labelM = new System.Windows.Forms.Label();
            this.labelN = new System.Windows.Forms.Label();
            this.labelO = new System.Windows.Forms.Label();
            this.labelP = new System.Windows.Forms.Label();
            this.labelDemoName = new System.Windows.Forms.Label();
            this.photoDemo_TakePhoto = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.pictureBoxAlbum = new System.Windows.Forms.PictureBox();
            this.drawPanel = new System.Windows.Forms.Panel();
            this.inkCanvasGreen = new System.Windows.Forms.Button();
            this.inkCanvasRed = new System.Windows.Forms.Button();
            this.inkCanvasYellow = new System.Windows.Forms.Button();
            this.inkCanvasWhite = new System.Windows.Forms.Button();
            this.inkCanvasToggle = new System.Windows.Forms.Button();
            this.inkCanvasThicker = new System.Windows.Forms.Button();
            this.inkCanvasThinner = new System.Windows.Forms.Button();
            this.elementHostClock = new System.Windows.Forms.Integration.ElementHost();
            this.elementHostWeather = new System.Windows.Forms.Integration.ElementHost();
            this.elementHostMenu = new System.Windows.Forms.Integration.ElementHost();
            this.elementHostStock = new System.Windows.Forms.Integration.ElementHost();
            this.elementHostNewsPaper = new System.Windows.Forms.Integration.ElementHost();
            this.webBrowserGallery = new System.Windows.Forms.WebBrowser();
            this.pictureBoxTestDemo = new System.Windows.Forms.PictureBox();
            this.elementHostMail = new System.Windows.Forms.Integration.ElementHost();
            this.webBrowserMap = new System.Windows.Forms.WebBrowser();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.buttonPreviewDemo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisplay)).BeginInit();
            this.tabSettings.SuspendLayout();
            this.tabPageCamera.SuspendLayout();
            this.groupBoxCameraInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCameraFPSLimit)).BeginInit();
            this.tabPageTokens.SuspendLayout();
            this.groupBoxMarkerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMarkerThresh)).BeginInit();
            this.tabPageApps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlbum)).BeginInit();
            this.drawPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTestDemo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxDisplay
            // 
            this.pictureBoxDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxDisplay.BackColor = System.Drawing.Color.Black;
            this.pictureBoxDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxDisplay.Location = new System.Drawing.Point(375, 239);
            this.pictureBoxDisplay.Name = "pictureBoxDisplay";
            this.pictureBoxDisplay.Size = new System.Drawing.Size(640, 480);
            this.pictureBoxDisplay.TabIndex = 0;
            this.pictureBoxDisplay.TabStop = false;
            this.pictureBoxDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxDisplay_MouseMove);
            this.pictureBoxDisplay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxDisplay_MouseDown);
            this.pictureBoxDisplay.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxDisplay_MouseUp);
            // 
            // tabSettings
            // 
            this.tabSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tabSettings.Controls.Add(this.tabPageCamera);
            this.tabSettings.Controls.Add(this.tabPageTokens);
            this.tabSettings.Controls.Add(this.tabPageApps);
            this.tabSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabSettings.ItemSize = new System.Drawing.Size(81, 25);
            this.tabSettings.Location = new System.Drawing.Point(375, 22);
            this.tabSettings.Multiline = true;
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Drawing.Point(0, 0);
            this.tabSettings.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabSettings.SelectedIndex = 0;
            this.tabSettings.Size = new System.Drawing.Size(640, 217);
            this.tabSettings.TabIndex = 2;
            this.tabSettings.SelectedIndexChanged += new System.EventHandler(this.tabSettings_SelectedIndexChanged);
            // 
            // tabPageCamera
            // 
            this.tabPageCamera.Controls.Add(this.lblRecord);
            this.tabPageCamera.Controls.Add(this.btnClear);
            this.tabPageCamera.Controls.Add(this.btnView);
            this.tabPageCamera.Controls.Add(this.btnLoad);
            this.tabPageCamera.Controls.Add(this.btnRecord);
            this.tabPageCamera.Controls.Add(this.groupBoxCameraInfo);
            this.tabPageCamera.Controls.Add(this.comboBoxCameras);
            this.tabPageCamera.Location = new System.Drawing.Point(4, 29);
            this.tabPageCamera.Name = "tabPageCamera";
            this.tabPageCamera.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCamera.Size = new System.Drawing.Size(632, 184);
            this.tabPageCamera.TabIndex = 0;
            this.tabPageCamera.Text = "CAMERA";
            this.tabPageCamera.UseVisualStyleBackColor = true;
            // 
            // lblRecord
            // 
            this.lblRecord.BackColor = System.Drawing.Color.Transparent;
            this.lblRecord.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecord.ForeColor = System.Drawing.Color.Firebrick;
            this.lblRecord.Location = new System.Drawing.Point(366, 9);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(168, 24);
            this.lblRecord.TabIndex = 26;
            this.lblRecord.Text = "[Recording]";
            this.lblRecord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRecord.Visible = false;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(413, 123);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 25;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(413, 94);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 23);
            this.btnView.TabIndex = 24;
            this.btnView.Text = "VIEW";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(413, 65);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 23;
            this.btnLoad.Text = "LOAD";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnRecord
            // 
            this.btnRecord.Location = new System.Drawing.Point(413, 36);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(75, 23);
            this.btnRecord.TabIndex = 22;
            this.btnRecord.Text = "RECORD";
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // groupBoxCameraInfo
            // 
            this.groupBoxCameraInfo.Controls.Add(this.checkBoxCameraFPSLimit);
            this.groupBoxCameraInfo.Controls.Add(this.labelCameraFPSValue);
            this.groupBoxCameraInfo.Controls.Add(this.numericUpDownCameraFPSLimit);
            this.groupBoxCameraInfo.Controls.Add(this.labelCameraFPS);
            this.groupBoxCameraInfo.Controls.Add(this.buttonCameraProperties);
            this.groupBoxCameraInfo.Enabled = false;
            this.groupBoxCameraInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCameraInfo.Location = new System.Drawing.Point(3, 36);
            this.groupBoxCameraInfo.Name = "groupBoxCameraInfo";
            this.groupBoxCameraInfo.Size = new System.Drawing.Size(267, 142);
            this.groupBoxCameraInfo.TabIndex = 21;
            this.groupBoxCameraInfo.TabStop = false;
            this.groupBoxCameraInfo.Text = "No Camera Selected";
            // 
            // checkBoxCameraFPSLimit
            // 
            this.checkBoxCameraFPSLimit.AutoSize = true;
            this.checkBoxCameraFPSLimit.Location = new System.Drawing.Point(9, 72);
            this.checkBoxCameraFPSLimit.Name = "checkBoxCameraFPSLimit";
            this.checkBoxCameraFPSLimit.Size = new System.Drawing.Size(185, 21);
            this.checkBoxCameraFPSLimit.TabIndex = 21;
            this.checkBoxCameraFPSLimit.Text = "Limit Frames Per Second";
            this.checkBoxCameraFPSLimit.UseVisualStyleBackColor = true;
            this.checkBoxCameraFPSLimit.CheckedChanged += new System.EventHandler(this.checkBoxCameraFPSLimit_CheckedChanged);
            // 
            // labelCameraFPSValue
            // 
            this.labelCameraFPSValue.AutoSize = true;
            this.labelCameraFPSValue.Location = new System.Drawing.Point(101, 50);
            this.labelCameraFPSValue.Name = "labelCameraFPSValue";
            this.labelCameraFPSValue.Size = new System.Drawing.Size(36, 17);
            this.labelCameraFPSValue.TabIndex = 20;
            this.labelCameraFPSValue.Text = "0.00";
            // 
            // numericUpDownCameraFPSLimit
            // 
            this.numericUpDownCameraFPSLimit.Enabled = false;
            this.numericUpDownCameraFPSLimit.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownCameraFPSLimit.Location = new System.Drawing.Point(198, 70);
            this.numericUpDownCameraFPSLimit.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDownCameraFPSLimit.Name = "numericUpDownCameraFPSLimit";
            this.numericUpDownCameraFPSLimit.Size = new System.Drawing.Size(50, 23);
            this.numericUpDownCameraFPSLimit.TabIndex = 19;
            this.numericUpDownCameraFPSLimit.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDownCameraFPSLimit.Visible = false;
            this.numericUpDownCameraFPSLimit.ValueChanged += new System.EventHandler(this.numericUpDownCameraFPSLimit_ValueChanged);
            // 
            // labelCameraFPS
            // 
            this.labelCameraFPS.AutoSize = true;
            this.labelCameraFPS.Location = new System.Drawing.Point(6, 50);
            this.labelCameraFPS.Name = "labelCameraFPS";
            this.labelCameraFPS.Size = new System.Drawing.Size(89, 17);
            this.labelCameraFPS.TabIndex = 0;
            this.labelCameraFPS.Text = "Current FPS:";
            // 
            // buttonCameraProperties
            // 
            this.buttonCameraProperties.Location = new System.Drawing.Point(6, 22);
            this.buttonCameraProperties.Name = "buttonCameraProperties";
            this.buttonCameraProperties.Size = new System.Drawing.Size(242, 26);
            this.buttonCameraProperties.TabIndex = 17;
            this.buttonCameraProperties.Text = "Adjust Camera Properties";
            this.buttonCameraProperties.UseVisualStyleBackColor = true;
            this.buttonCameraProperties.Click += new System.EventHandler(this.buttonCameraProperties_Click);
            // 
            // comboBoxCameras
            // 
            this.comboBoxCameras.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCameras.FormattingEnabled = true;
            this.comboBoxCameras.Location = new System.Drawing.Point(3, 6);
            this.comboBoxCameras.Name = "comboBoxCameras";
            this.comboBoxCameras.Size = new System.Drawing.Size(267, 24);
            this.comboBoxCameras.TabIndex = 15;
            this.comboBoxCameras.Text = "Select A Camera";
            this.comboBoxCameras.SelectedIndexChanged += new System.EventHandler(this.comboBoxCameras_SelectedIndexChanged);
            this.comboBoxCameras.DropDown += new System.EventHandler(this.comboBoxCameras_DropDown);
            // 
            // tabPageTokens
            // 
            this.tabPageTokens.Controls.Add(this.buttonLoadMarkers);
            this.tabPageTokens.Controls.Add(this.buttonSaveMarkers);
            this.tabPageTokens.Controls.Add(this.lblMarkerCount);
            this.tabPageTokens.Controls.Add(this.lblTotalMarker);
            this.tabPageTokens.Controls.Add(this.groupBoxMarkerControl);
            this.tabPageTokens.Controls.Add(this.comboBoxMarkers);
            this.tabPageTokens.Controls.Add(this.buttonMarkerAdd);
            this.tabPageTokens.Location = new System.Drawing.Point(4, 29);
            this.tabPageTokens.Name = "tabPageTokens";
            this.tabPageTokens.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTokens.Size = new System.Drawing.Size(632, 184);
            this.tabPageTokens.TabIndex = 1;
            this.tabPageTokens.Text = "TOKENS";
            this.tabPageTokens.UseVisualStyleBackColor = true;
            // 
            // buttonLoadMarkers
            // 
            this.buttonLoadMarkers.Location = new System.Drawing.Point(515, 6);
            this.buttonLoadMarkers.Name = "buttonLoadMarkers";
            this.buttonLoadMarkers.Size = new System.Drawing.Size(111, 26);
            this.buttonLoadMarkers.TabIndex = 30;
            this.buttonLoadMarkers.Text = "Load Markers";
            this.buttonLoadMarkers.UseVisualStyleBackColor = true;
            this.buttonLoadMarkers.Click += new System.EventHandler(this.buttonLoadMarkers_Click);
            // 
            // buttonSaveMarkers
            // 
            this.buttonSaveMarkers.Location = new System.Drawing.Point(401, 6);
            this.buttonSaveMarkers.Name = "buttonSaveMarkers";
            this.buttonSaveMarkers.Size = new System.Drawing.Size(108, 26);
            this.buttonSaveMarkers.TabIndex = 29;
            this.buttonSaveMarkers.Text = "Save Markers";
            this.buttonSaveMarkers.UseVisualStyleBackColor = true;
            this.buttonSaveMarkers.Click += new System.EventHandler(this.buttonSaveMarkers_Click);
            // 
            // lblMarkerCount
            // 
            this.lblMarkerCount.AutoSize = true;
            this.lblMarkerCount.Location = new System.Drawing.Point(379, 10);
            this.lblMarkerCount.Name = "lblMarkerCount";
            this.lblMarkerCount.Size = new System.Drawing.Size(16, 17);
            this.lblMarkerCount.TabIndex = 28;
            this.lblMarkerCount.Text = "0";
            // 
            // lblTotalMarker
            // 
            this.lblTotalMarker.AutoSize = true;
            this.lblTotalMarker.Location = new System.Drawing.Point(274, 10);
            this.lblTotalMarker.Name = "lblTotalMarker";
            this.lblTotalMarker.Size = new System.Drawing.Size(99, 17);
            this.lblTotalMarker.TabIndex = 27;
            this.lblTotalMarker.Text = "Total markers:";
            // 
            // groupBoxMarkerControl
            // 
            this.groupBoxMarkerControl.Controls.Add(this.numericUpDownMarkerThresh);
            this.groupBoxMarkerControl.Controls.Add(this.labelMarkerThresh);
            this.groupBoxMarkerControl.Controls.Add(this.checkBoxMarkerSmoothing);
            this.groupBoxMarkerControl.Controls.Add(this.checkBoxMarkerHighlight);
            this.groupBoxMarkerControl.Controls.Add(this.labelMarkerData);
            this.groupBoxMarkerControl.Controls.Add(this.buttonMarkerRemove);
            this.groupBoxMarkerControl.Enabled = false;
            this.groupBoxMarkerControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxMarkerControl.Location = new System.Drawing.Point(3, 39);
            this.groupBoxMarkerControl.Name = "groupBoxMarkerControl";
            this.groupBoxMarkerControl.Size = new System.Drawing.Size(623, 141);
            this.groupBoxMarkerControl.TabIndex = 26;
            this.groupBoxMarkerControl.TabStop = false;
            this.groupBoxMarkerControl.Text = "No Marker Selected";
            // 
            // numericUpDownMarkerThresh
            // 
            this.numericUpDownMarkerThresh.Location = new System.Drawing.Point(149, 104);
            this.numericUpDownMarkerThresh.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownMarkerThresh.Name = "numericUpDownMarkerThresh";
            this.numericUpDownMarkerThresh.Size = new System.Drawing.Size(47, 23);
            this.numericUpDownMarkerThresh.TabIndex = 5;
            this.numericUpDownMarkerThresh.ValueChanged += new System.EventHandler(this.numericUpDownMarkerThresh_ValueChanged);
            // 
            // labelMarkerThresh
            // 
            this.labelMarkerThresh.AutoSize = true;
            this.labelMarkerThresh.Location = new System.Drawing.Point(7, 106);
            this.labelMarkerThresh.Name = "labelMarkerThresh";
            this.labelMarkerThresh.Size = new System.Drawing.Size(124, 17);
            this.labelMarkerThresh.TabIndex = 4;
            this.labelMarkerThresh.Text = "Marker Threshold:";
            // 
            // checkBoxMarkerSmoothing
            // 
            this.checkBoxMarkerSmoothing.AutoSize = true;
            this.checkBoxMarkerSmoothing.Checked = true;
            this.checkBoxMarkerSmoothing.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMarkerSmoothing.Location = new System.Drawing.Point(10, 82);
            this.checkBoxMarkerSmoothing.Name = "checkBoxMarkerSmoothing";
            this.checkBoxMarkerSmoothing.Size = new System.Drawing.Size(157, 21);
            this.checkBoxMarkerSmoothing.TabIndex = 3;
            this.checkBoxMarkerSmoothing.Text = "Smooth Marker Data";
            this.checkBoxMarkerSmoothing.UseVisualStyleBackColor = true;
            this.checkBoxMarkerSmoothing.CheckedChanged += new System.EventHandler(this.checkBoxMarkerSmoothing_CheckedChanged);
            // 
            // checkBoxMarkerHighlight
            // 
            this.checkBoxMarkerHighlight.AutoSize = true;
            this.checkBoxMarkerHighlight.Checked = true;
            this.checkBoxMarkerHighlight.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMarkerHighlight.Location = new System.Drawing.Point(10, 59);
            this.checkBoxMarkerHighlight.Name = "checkBoxMarkerHighlight";
            this.checkBoxMarkerHighlight.Size = new System.Drawing.Size(130, 21);
            this.checkBoxMarkerHighlight.TabIndex = 2;
            this.checkBoxMarkerHighlight.Text = "Highlight Marker";
            this.checkBoxMarkerHighlight.UseVisualStyleBackColor = true;
            this.checkBoxMarkerHighlight.CheckedChanged += new System.EventHandler(this.checkBoxMarkerHighlight_CheckedChanged);
            // 
            // labelMarkerData
            // 
            this.labelMarkerData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelMarkerData.Location = new System.Drawing.Point(202, 22);
            this.labelMarkerData.Name = "labelMarkerData";
            this.labelMarkerData.ReadOnly = true;
            this.labelMarkerData.Size = new System.Drawing.Size(412, 108);
            this.labelMarkerData.TabIndex = 1;
            this.labelMarkerData.Text = "";
            // 
            // buttonMarkerRemove
            // 
            this.buttonMarkerRemove.Location = new System.Drawing.Point(10, 25);
            this.buttonMarkerRemove.Name = "buttonMarkerRemove";
            this.buttonMarkerRemove.Size = new System.Drawing.Size(186, 26);
            this.buttonMarkerRemove.TabIndex = 0;
            this.buttonMarkerRemove.Text = "Remove This Marker";
            this.buttonMarkerRemove.UseVisualStyleBackColor = true;
            this.buttonMarkerRemove.Click += new System.EventHandler(this.buttonMarkerRemove_Click);
            // 
            // comboBoxMarkers
            // 
            this.comboBoxMarkers.Enabled = false;
            this.comboBoxMarkers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxMarkers.FormattingEnabled = true;
            this.comboBoxMarkers.Location = new System.Drawing.Point(120, 6);
            this.comboBoxMarkers.Name = "comboBoxMarkers";
            this.comboBoxMarkers.Size = new System.Drawing.Size(146, 24);
            this.comboBoxMarkers.TabIndex = 24;
            this.comboBoxMarkers.Text = "Edit Existing Marker";
            this.comboBoxMarkers.SelectedIndexChanged += new System.EventHandler(this.comboBoxMarkers_SelectedIndexChanged);
            this.comboBoxMarkers.DropDown += new System.EventHandler(this.comboBoxMarkers_DropDown);
            // 
            // buttonMarkerAdd
            // 
            this.buttonMarkerAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMarkerAdd.Location = new System.Drawing.Point(6, 5);
            this.buttonMarkerAdd.Name = "buttonMarkerAdd";
            this.buttonMarkerAdd.Size = new System.Drawing.Size(108, 26);
            this.buttonMarkerAdd.TabIndex = 23;
            this.buttonMarkerAdd.Text = "New Markers";
            this.buttonMarkerAdd.UseVisualStyleBackColor = true;
            this.buttonMarkerAdd.Click += new System.EventHandler(this.buttonMarkerAdd_Click);
            // 
            // tabPageApps
            // 
            this.tabPageApps.Controls.Add(this.buttonPreviewDemo);
            this.tabPageApps.Controls.Add(this.checkBox_F);
            this.tabPageApps.Controls.Add(this.buttonEffectsDemo);
            this.tabPageApps.Controls.Add(this.buttonTestDemo);
            this.tabPageApps.Controls.Add(this.buttonGlobeDemo);
            this.tabPageApps.Controls.Add(this.buttonStockDemo);
            this.tabPageApps.Controls.Add(this.buttonGalleryDemo);
            this.tabPageApps.Controls.Add(this.buttonBookDemo);
            this.tabPageApps.Controls.Add(this.buttonMailDemo);
            this.tabPageApps.Controls.Add(this.buttonNewsPaperDemo);
            this.tabPageApps.Controls.Add(this.buttonWeatherDemo);
            this.tabPageApps.Controls.Add(this.buttonMenuDemo);
            this.tabPageApps.Controls.Add(this.buttonClockDemo);
            this.tabPageApps.Controls.Add(this.buttonPhotoDemo);
            this.tabPageApps.Controls.Add(this.buttonGestureDemo);
            this.tabPageApps.Controls.Add(this.buttonMapDemo);
            this.tabPageApps.Controls.Add(this.buttonDrawDemo);
            this.tabPageApps.Controls.Add(this.labelDemoInstructions);
            this.tabPageApps.Location = new System.Drawing.Point(4, 29);
            this.tabPageApps.Name = "tabPageApps";
            this.tabPageApps.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageApps.Size = new System.Drawing.Size(632, 184);
            this.tabPageApps.TabIndex = 2;
            this.tabPageApps.Text = "APPS";
            this.tabPageApps.UseVisualStyleBackColor = true;
            // 
            // checkBox_F
            // 
            this.checkBox_F.AutoSize = true;
            this.checkBox_F.Location = new System.Drawing.Point(591, 154);
            this.checkBox_F.Name = "checkBox_F";
            this.checkBox_F.Size = new System.Drawing.Size(35, 21);
            this.checkBox_F.TabIndex = 46;
            this.checkBox_F.Text = "F";
            this.checkBox_F.UseVisualStyleBackColor = true;
            // 
            // buttonEffectsDemo
            // 
            this.buttonEffectsDemo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonEffectsDemo.Location = new System.Drawing.Point(118, 146);
            this.buttonEffectsDemo.Name = "buttonEffectsDemo";
            this.buttonEffectsDemo.Size = new System.Drawing.Size(106, 29);
            this.buttonEffectsDemo.TabIndex = 45;
            this.buttonEffectsDemo.Text = "Effects";
            this.buttonEffectsDemo.UseVisualStyleBackColor = true;
            this.buttonEffectsDemo.Click += new System.EventHandler(this.buttonEffectsDemo_Click);
            // 
            // buttonTestDemo
            // 
            this.buttonTestDemo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonTestDemo.Location = new System.Drawing.Point(6, 6);
            this.buttonTestDemo.Name = "buttonTestDemo";
            this.buttonTestDemo.Size = new System.Drawing.Size(106, 29);
            this.buttonTestDemo.TabIndex = 44;
            this.buttonTestDemo.Text = "Test";
            this.buttonTestDemo.UseVisualStyleBackColor = true;
            this.buttonTestDemo.Click += new System.EventHandler(this.buttonTestDemo_Click);
            // 
            // buttonGlobeDemo
            // 
            this.buttonGlobeDemo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonGlobeDemo.Location = new System.Drawing.Point(118, 6);
            this.buttonGlobeDemo.Name = "buttonGlobeDemo";
            this.buttonGlobeDemo.Size = new System.Drawing.Size(106, 29);
            this.buttonGlobeDemo.TabIndex = 43;
            this.buttonGlobeDemo.Text = "Globe";
            this.buttonGlobeDemo.UseVisualStyleBackColor = true;
            this.buttonGlobeDemo.Click += new System.EventHandler(this.buttonGlobeDemo_Click);
            // 
            // buttonStockDemo
            // 
            this.buttonStockDemo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonStockDemo.Location = new System.Drawing.Point(118, 111);
            this.buttonStockDemo.Name = "buttonStockDemo";
            this.buttonStockDemo.Size = new System.Drawing.Size(106, 29);
            this.buttonStockDemo.TabIndex = 42;
            this.buttonStockDemo.Text = "Stock";
            this.buttonStockDemo.UseVisualStyleBackColor = true;
            this.buttonStockDemo.Click += new System.EventHandler(this.buttonStockDemo_Click);
            // 
            // buttonGalleryDemo
            // 
            this.buttonGalleryDemo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonGalleryDemo.Location = new System.Drawing.Point(6, 146);
            this.buttonGalleryDemo.Name = "buttonGalleryDemo";
            this.buttonGalleryDemo.Size = new System.Drawing.Size(106, 29);
            this.buttonGalleryDemo.TabIndex = 41;
            this.buttonGalleryDemo.Text = "Gallery";
            this.buttonGalleryDemo.UseVisualStyleBackColor = true;
            this.buttonGalleryDemo.Click += new System.EventHandler(this.buttonGalleryDemo_Click);
            // 
            // buttonBookDemo
            // 
            this.buttonBookDemo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonBookDemo.Location = new System.Drawing.Point(230, 41);
            this.buttonBookDemo.Name = "buttonBookDemo";
            this.buttonBookDemo.Size = new System.Drawing.Size(106, 29);
            this.buttonBookDemo.TabIndex = 40;
            this.buttonBookDemo.Text = "Book";
            this.buttonBookDemo.UseVisualStyleBackColor = true;
            this.buttonBookDemo.Click += new System.EventHandler(this.buttonBookDemo_Click);
            // 
            // buttonMailDemo
            // 
            this.buttonMailDemo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonMailDemo.Location = new System.Drawing.Point(118, 41);
            this.buttonMailDemo.Name = "buttonMailDemo";
            this.buttonMailDemo.Size = new System.Drawing.Size(106, 29);
            this.buttonMailDemo.TabIndex = 39;
            this.buttonMailDemo.Text = "Mail";
            this.buttonMailDemo.UseVisualStyleBackColor = true;
            this.buttonMailDemo.Click += new System.EventHandler(this.buttonMailDemo_Click);
            // 
            // buttonNewsPaperDemo
            // 
            this.buttonNewsPaperDemo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonNewsPaperDemo.Location = new System.Drawing.Point(230, 6);
            this.buttonNewsPaperDemo.Name = "buttonNewsPaperDemo";
            this.buttonNewsPaperDemo.Size = new System.Drawing.Size(106, 29);
            this.buttonNewsPaperDemo.TabIndex = 38;
            this.buttonNewsPaperDemo.Text = "NewsPaper";
            this.buttonNewsPaperDemo.UseVisualStyleBackColor = true;
            this.buttonNewsPaperDemo.Click += new System.EventHandler(this.buttonNewsPaperDemo_Click);
            // 
            // buttonWeatherDemo
            // 
            this.buttonWeatherDemo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonWeatherDemo.Location = new System.Drawing.Point(118, 76);
            this.buttonWeatherDemo.Name = "buttonWeatherDemo";
            this.buttonWeatherDemo.Size = new System.Drawing.Size(106, 29);
            this.buttonWeatherDemo.TabIndex = 37;
            this.buttonWeatherDemo.Text = "Weather";
            this.buttonWeatherDemo.UseVisualStyleBackColor = true;
            this.buttonWeatherDemo.Click += new System.EventHandler(this.buttonWeatherDemo_Click);
            // 
            // buttonMenuDemo
            // 
            this.buttonMenuDemo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonMenuDemo.Location = new System.Drawing.Point(230, 111);
            this.buttonMenuDemo.Name = "buttonMenuDemo";
            this.buttonMenuDemo.Size = new System.Drawing.Size(106, 29);
            this.buttonMenuDemo.TabIndex = 36;
            this.buttonMenuDemo.Text = "Menu";
            this.buttonMenuDemo.UseVisualStyleBackColor = true;
            this.buttonMenuDemo.Click += new System.EventHandler(this.buttonMenuDemo_Click);
            // 
            // buttonClockDemo
            // 
            this.buttonClockDemo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonClockDemo.Location = new System.Drawing.Point(230, 76);
            this.buttonClockDemo.Name = "buttonClockDemo";
            this.buttonClockDemo.Size = new System.Drawing.Size(106, 29);
            this.buttonClockDemo.TabIndex = 35;
            this.buttonClockDemo.Text = "Clock";
            this.buttonClockDemo.UseVisualStyleBackColor = true;
            this.buttonClockDemo.Click += new System.EventHandler(this.buttonClockDemo_Click);
            // 
            // buttonPhotoDemo
            // 
            this.buttonPhotoDemo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonPhotoDemo.Location = new System.Drawing.Point(6, 111);
            this.buttonPhotoDemo.Name = "buttonPhotoDemo";
            this.buttonPhotoDemo.Size = new System.Drawing.Size(74, 29);
            this.buttonPhotoDemo.TabIndex = 34;
            this.buttonPhotoDemo.Text = "Photo";
            this.buttonPhotoDemo.UseVisualStyleBackColor = true;
            this.buttonPhotoDemo.Click += new System.EventHandler(this.buttonPhotoDemo_Click);
            // 
            // buttonGestureDemo
            // 
            this.buttonGestureDemo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonGestureDemo.Location = new System.Drawing.Point(230, 146);
            this.buttonGestureDemo.Name = "buttonGestureDemo";
            this.buttonGestureDemo.Size = new System.Drawing.Size(106, 29);
            this.buttonGestureDemo.TabIndex = 33;
            this.buttonGestureDemo.Text = "Gesture";
            this.buttonGestureDemo.UseVisualStyleBackColor = true;
            this.buttonGestureDemo.Click += new System.EventHandler(this.buttonGestureDemo_Click);
            // 
            // buttonMapDemo
            // 
            this.buttonMapDemo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonMapDemo.Location = new System.Drawing.Point(6, 76);
            this.buttonMapDemo.Name = "buttonMapDemo";
            this.buttonMapDemo.Size = new System.Drawing.Size(106, 29);
            this.buttonMapDemo.TabIndex = 32;
            this.buttonMapDemo.Text = "Map";
            this.buttonMapDemo.UseVisualStyleBackColor = true;
            this.buttonMapDemo.Click += new System.EventHandler(this.buttonMapDemo_Click);
            // 
            // buttonDrawDemo
            // 
            this.buttonDrawDemo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonDrawDemo.Location = new System.Drawing.Point(6, 41);
            this.buttonDrawDemo.Name = "buttonDrawDemo";
            this.buttonDrawDemo.Size = new System.Drawing.Size(106, 29);
            this.buttonDrawDemo.TabIndex = 31;
            this.buttonDrawDemo.Text = "Draw";
            this.buttonDrawDemo.UseVisualStyleBackColor = true;
            this.buttonDrawDemo.Click += new System.EventHandler(this.buttonDrawDemo_Click);
            // 
            // labelDemoInstructions
            // 
            this.labelDemoInstructions.BackColor = System.Drawing.SystemColors.Control;
            this.labelDemoInstructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelDemoInstructions.Enabled = false;
            this.labelDemoInstructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDemoInstructions.Location = new System.Drawing.Point(342, 6);
            this.labelDemoInstructions.Name = "labelDemoInstructions";
            this.labelDemoInstructions.ReadOnly = true;
            this.labelDemoInstructions.Size = new System.Drawing.Size(284, 134);
            this.labelDemoInstructions.TabIndex = 29;
            this.labelDemoInstructions.Text = "";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.DimGray;
            this.btnExit.Location = new System.Drawing.Point(928, 10);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(45, 33);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnShowHide
            // 
            this.btnShowHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowHide.BackColor = System.Drawing.Color.Transparent;
            this.btnShowHide.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnShowHide.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnShowHide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowHide.ForeColor = System.Drawing.Color.DimGray;
            this.btnShowHide.Location = new System.Drawing.Point(980, 10);
            this.btnShowHide.Name = "btnShowHide";
            this.btnShowHide.Size = new System.Drawing.Size(33, 33);
            this.btnShowHide.TabIndex = 0;
            this.btnShowHide.UseVisualStyleBackColor = false;
            this.btnShowHide.Click += new System.EventHandler(this.btnShowHide_Click);
            this.btnShowHide.MouseHover += new System.EventHandler(this.btnShowHide_Hover);
            // 
            // elementHostDraw
            // 
            this.elementHostDraw.BackColor = System.Drawing.Color.Transparent;
            this.elementHostDraw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHostDraw.Location = new System.Drawing.Point(0, 0);
            this.elementHostDraw.Name = "elementHostDraw";
            this.elementHostDraw.Size = new System.Drawing.Size(1024, 768);
            this.elementHostDraw.TabIndex = 12;
            this.elementHostDraw.Text = "elementHostDraw";
            this.elementHostDraw.Child = null;
            // 
            // labelM
            // 
            this.labelM.AutoSize = true;
            this.labelM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelM.ForeColor = System.Drawing.Color.White;
            this.labelM.Location = new System.Drawing.Point(35, 9);
            this.labelM.Margin = new System.Windows.Forms.Padding(0);
            this.labelM.Name = "labelM";
            this.labelM.Padding = new System.Windows.Forms.Padding(3);
            this.labelM.Size = new System.Drawing.Size(22, 19);
            this.labelM.TabIndex = 13;
            this.labelM.Text = "M";
            // 
            // labelN
            // 
            this.labelN.AutoSize = true;
            this.labelN.BackColor = System.Drawing.Color.Maroon;
            this.labelN.ForeColor = System.Drawing.Color.White;
            this.labelN.Location = new System.Drawing.Point(35, 35);
            this.labelN.Margin = new System.Windows.Forms.Padding(0);
            this.labelN.Name = "labelN";
            this.labelN.Padding = new System.Windows.Forms.Padding(3);
            this.labelN.Size = new System.Drawing.Size(21, 19);
            this.labelN.TabIndex = 14;
            this.labelN.Text = "N";
            // 
            // labelO
            // 
            this.labelO.AutoSize = true;
            this.labelO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelO.ForeColor = System.Drawing.Color.White;
            this.labelO.Location = new System.Drawing.Point(9, 9);
            this.labelO.Margin = new System.Windows.Forms.Padding(0);
            this.labelO.Name = "labelO";
            this.labelO.Padding = new System.Windows.Forms.Padding(3);
            this.labelO.Size = new System.Drawing.Size(21, 19);
            this.labelO.TabIndex = 15;
            this.labelO.Text = "O";
            // 
            // labelP
            // 
            this.labelP.AutoSize = true;
            this.labelP.BackColor = System.Drawing.Color.Maroon;
            this.labelP.ForeColor = System.Drawing.Color.White;
            this.labelP.Location = new System.Drawing.Point(9, 35);
            this.labelP.Margin = new System.Windows.Forms.Padding(0);
            this.labelP.Name = "labelP";
            this.labelP.Padding = new System.Windows.Forms.Padding(3);
            this.labelP.Size = new System.Drawing.Size(20, 19);
            this.labelP.TabIndex = 16;
            this.labelP.Text = "P";
            // 
            // labelDemoName
            // 
            this.labelDemoName.AutoSize = true;
            this.labelDemoName.BackColor = System.Drawing.Color.Black;
            this.labelDemoName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDemoName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.labelDemoName.Location = new System.Drawing.Point(60, 9);
            this.labelDemoName.Name = "labelDemoName";
            this.labelDemoName.Size = new System.Drawing.Size(44, 16);
            this.labelDemoName.TabIndex = 17;
            this.labelDemoName.Text = "WUW";
            // 
            // photoDemo_TakePhoto
            // 
            this.photoDemo_TakePhoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.photoDemo_TakePhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.photoDemo_TakePhoto.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.photoDemo_TakePhoto.Location = new System.Drawing.Point(776, 688);
            this.photoDemo_TakePhoto.Name = "photoDemo_TakePhoto";
            this.photoDemo_TakePhoto.Size = new System.Drawing.Size(239, 71);
            this.photoDemo_TakePhoto.TabIndex = 3;
            this.photoDemo_TakePhoto.Text = "Take Picture";
            this.photoDemo_TakePhoto.UseVisualStyleBackColor = true;
            this.photoDemo_TakePhoto.MouseHover += new System.EventHandler(this.photoDemo_TakePhoto_Hover);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.BackColor = System.Drawing.Color.Black;
            this.lblResult.ForeColor = System.Drawing.Color.White;
            this.lblResult.Location = new System.Drawing.Point(138, 9);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(28, 13);
            this.lblResult.TabIndex = 21;
            this.lblResult.Text = "Test";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBoxAlbum
            // 
            this.pictureBoxAlbum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxAlbum.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxAlbum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxAlbum.Location = new System.Drawing.Point(200, 50);
            this.pictureBoxAlbum.Name = "pictureBoxAlbum";
            this.pictureBoxAlbum.Size = new System.Drawing.Size(640, 480);
            this.pictureBoxAlbum.TabIndex = 23;
            this.pictureBoxAlbum.TabStop = false;
            // 
            // drawPanel
            // 
            this.drawPanel.Controls.Add(this.inkCanvasGreen);
            this.drawPanel.Controls.Add(this.inkCanvasRed);
            this.drawPanel.Controls.Add(this.inkCanvasYellow);
            this.drawPanel.Controls.Add(this.inkCanvasWhite);
            this.drawPanel.Controls.Add(this.inkCanvasToggle);
            this.drawPanel.Controls.Add(this.inkCanvasThicker);
            this.drawPanel.Controls.Add(this.inkCanvasThinner);
            this.drawPanel.Location = new System.Drawing.Point(957, 361);
            this.drawPanel.Name = "drawPanel";
            this.drawPanel.Size = new System.Drawing.Size(58, 399);
            this.drawPanel.TabIndex = 24;
            // 
            // inkCanvasGreen
            // 
            this.inkCanvasGreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.inkCanvasGreen.BackColor = System.Drawing.Color.Green;
            this.inkCanvasGreen.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.inkCanvasGreen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.YellowGreen;
            this.inkCanvasGreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.inkCanvasGreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inkCanvasGreen.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.inkCanvasGreen.Location = new System.Drawing.Point(3, 173);
            this.inkCanvasGreen.Name = "inkCanvasGreen";
            this.inkCanvasGreen.Size = new System.Drawing.Size(50, 50);
            this.inkCanvasGreen.TabIndex = 32;
            this.inkCanvasGreen.UseVisualStyleBackColor = false;
            this.inkCanvasGreen.MouseHover += new System.EventHandler(this.inkCanvasColor_Hover);
            // 
            // inkCanvasRed
            // 
            this.inkCanvasRed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.inkCanvasRed.BackColor = System.Drawing.Color.Firebrick;
            this.inkCanvasRed.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.inkCanvasRed.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.inkCanvasRed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.inkCanvasRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inkCanvasRed.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.inkCanvasRed.Location = new System.Drawing.Point(3, 61);
            this.inkCanvasRed.Name = "inkCanvasRed";
            this.inkCanvasRed.Size = new System.Drawing.Size(50, 50);
            this.inkCanvasRed.TabIndex = 31;
            this.inkCanvasRed.UseVisualStyleBackColor = false;
            this.inkCanvasRed.MouseHover += new System.EventHandler(this.inkCanvasColor_Hover);
            // 
            // inkCanvasYellow
            // 
            this.inkCanvasYellow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.inkCanvasYellow.BackColor = System.Drawing.Color.RoyalBlue;
            this.inkCanvasYellow.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.inkCanvasYellow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.inkCanvasYellow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.inkCanvasYellow.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inkCanvasYellow.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.inkCanvasYellow.Location = new System.Drawing.Point(3, 117);
            this.inkCanvasYellow.Name = "inkCanvasYellow";
            this.inkCanvasYellow.Size = new System.Drawing.Size(50, 50);
            this.inkCanvasYellow.TabIndex = 30;
            this.inkCanvasYellow.UseVisualStyleBackColor = false;
            this.inkCanvasYellow.MouseHover += new System.EventHandler(this.inkCanvasColor_Hover);
            // 
            // inkCanvasWhite
            // 
            this.inkCanvasWhite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.inkCanvasWhite.BackColor = System.Drawing.Color.Yellow;
            this.inkCanvasWhite.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.inkCanvasWhite.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.inkCanvasWhite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.inkCanvasWhite.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inkCanvasWhite.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.inkCanvasWhite.Location = new System.Drawing.Point(3, 5);
            this.inkCanvasWhite.Name = "inkCanvasWhite";
            this.inkCanvasWhite.Size = new System.Drawing.Size(50, 50);
            this.inkCanvasWhite.TabIndex = 29;
            this.inkCanvasWhite.Tag = "White";
            this.inkCanvasWhite.UseVisualStyleBackColor = false;
            this.inkCanvasWhite.MouseHover += new System.EventHandler(this.inkCanvasColor_Hover);
            // 
            // inkCanvasToggle
            // 
            this.inkCanvasToggle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.inkCanvasToggle.BackColor = System.Drawing.Color.Black;
            this.inkCanvasToggle.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.inkCanvasToggle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.inkCanvasToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.inkCanvasToggle.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.inkCanvasToggle.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.inkCanvasToggle.Location = new System.Drawing.Point(3, 340);
            this.inkCanvasToggle.Name = "inkCanvasToggle";
            this.inkCanvasToggle.Size = new System.Drawing.Size(50, 50);
            this.inkCanvasToggle.TabIndex = 28;
            this.inkCanvasToggle.Text = "x";
            this.inkCanvasToggle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.inkCanvasToggle.UseVisualStyleBackColor = false;
            this.inkCanvasToggle.MouseHover += new System.EventHandler(this.inkCanvasToggle_Hover);
            // 
            // inkCanvasThicker
            // 
            this.inkCanvasThicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.inkCanvasThicker.BackColor = System.Drawing.Color.Black;
            this.inkCanvasThicker.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.inkCanvasThicker.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.inkCanvasThicker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.inkCanvasThicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inkCanvasThicker.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.inkCanvasThicker.Location = new System.Drawing.Point(3, 284);
            this.inkCanvasThicker.Name = "inkCanvasThicker";
            this.inkCanvasThicker.Size = new System.Drawing.Size(50, 50);
            this.inkCanvasThicker.TabIndex = 27;
            this.inkCanvasThicker.Text = "+";
            this.inkCanvasThicker.UseVisualStyleBackColor = false;
            this.inkCanvasThicker.Click += new System.EventHandler(this.inkCanvasThicker_Click);
            this.inkCanvasThicker.MouseHover += new System.EventHandler(this.inkCanvasThicker_Hover);
            // 
            // inkCanvasThinner
            // 
            this.inkCanvasThinner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.inkCanvasThinner.BackColor = System.Drawing.Color.Black;
            this.inkCanvasThinner.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.inkCanvasThinner.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.inkCanvasThinner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.inkCanvasThinner.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inkCanvasThinner.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.inkCanvasThinner.Location = new System.Drawing.Point(3, 229);
            this.inkCanvasThinner.Name = "inkCanvasThinner";
            this.inkCanvasThinner.Size = new System.Drawing.Size(50, 50);
            this.inkCanvasThinner.TabIndex = 26;
            this.inkCanvasThinner.Text = "-";
            this.inkCanvasThinner.UseVisualStyleBackColor = false;
            this.inkCanvasThinner.Click += new System.EventHandler(this.inkCanvasThinner_Click);
            this.inkCanvasThinner.MouseHover += new System.EventHandler(this.inkCanvasThinner_Hover);
            // 
            // elementHostClock
            // 
            this.elementHostClock.BackColor = System.Drawing.Color.Yellow;
            this.elementHostClock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHostClock.Location = new System.Drawing.Point(0, 0);
            this.elementHostClock.Name = "elementHostClock";
            this.elementHostClock.Size = new System.Drawing.Size(1024, 768);
            this.elementHostClock.TabIndex = 26;
            this.elementHostClock.Text = "elementHostClock";
            this.elementHostClock.Child = null;
            // 
            // elementHostWeather
            // 
            this.elementHostWeather.BackColor = System.Drawing.Color.OliveDrab;
            this.elementHostWeather.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHostWeather.Location = new System.Drawing.Point(0, 0);
            this.elementHostWeather.Name = "elementHostWeather";
            this.elementHostWeather.Size = new System.Drawing.Size(1024, 768);
            this.elementHostWeather.TabIndex = 27;
            this.elementHostWeather.Text = "elementHostWeather";
            this.elementHostWeather.Child = null;
            // 
            // elementHostMenu
            // 
            this.elementHostMenu.BackColor = System.Drawing.Color.Indigo;
            this.elementHostMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHostMenu.Location = new System.Drawing.Point(0, 0);
            this.elementHostMenu.Name = "elementHostMenu";
            this.elementHostMenu.Size = new System.Drawing.Size(1024, 768);
            this.elementHostMenu.TabIndex = 28;
            this.elementHostMenu.Text = "elementHostMenu";
            this.elementHostMenu.Child = null;
            // 
            // elementHostStock
            // 
            this.elementHostStock.BackColor = System.Drawing.Color.HotPink;
            this.elementHostStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHostStock.Location = new System.Drawing.Point(0, 0);
            this.elementHostStock.Name = "elementHostStock";
            this.elementHostStock.Size = new System.Drawing.Size(1024, 768);
            this.elementHostStock.TabIndex = 34;
            this.elementHostStock.Text = "elementHostStock";
            this.elementHostStock.Child = null;
            // 
            // elementHostNewsPaper
            // 
            this.elementHostNewsPaper.BackColor = System.Drawing.Color.DarkSlateGray;
            this.elementHostNewsPaper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHostNewsPaper.Location = new System.Drawing.Point(0, 0);
            this.elementHostNewsPaper.Name = "elementHostNewsPaper";
            this.elementHostNewsPaper.Size = new System.Drawing.Size(1024, 768);
            this.elementHostNewsPaper.TabIndex = 35;
            this.elementHostNewsPaper.Child = null;
            // 
            // webBrowserGallery
            // 
            this.webBrowserGallery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserGallery.IsWebBrowserContextMenuEnabled = false;
            this.webBrowserGallery.Location = new System.Drawing.Point(0, 0);
            this.webBrowserGallery.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserGallery.Name = "webBrowserGallery";
            this.webBrowserGallery.ScrollBarsEnabled = false;
            this.webBrowserGallery.Size = new System.Drawing.Size(1024, 768);
            this.webBrowserGallery.TabIndex = 36;
            this.webBrowserGallery.TabStop = false;
            // 
            // pictureBoxTestDemo
            // 
            this.pictureBoxTestDemo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxTestDemo.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxTestDemo.Name = "pictureBoxTestDemo";
            this.pictureBoxTestDemo.Size = new System.Drawing.Size(1024, 768);
            this.pictureBoxTestDemo.TabIndex = 37;
            this.pictureBoxTestDemo.TabStop = false;
            // 
            // elementHostMail
            // 
            this.elementHostMail.BackColor = System.Drawing.Color.Orchid;
            this.elementHostMail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHostMail.Location = new System.Drawing.Point(0, 0);
            this.elementHostMail.Name = "elementHostMail";
            this.elementHostMail.Size = new System.Drawing.Size(1024, 768);
            this.elementHostMail.TabIndex = 38;
            this.elementHostMail.Text = "elementHost1";
            this.elementHostMail.Child = null;
            // 
            // webBrowserMap
            // 
            this.webBrowserMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserMap.IsWebBrowserContextMenuEnabled = false;
            this.webBrowserMap.Location = new System.Drawing.Point(0, 0);
            this.webBrowserMap.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserMap.Name = "webBrowserMap";
            this.webBrowserMap.ScriptErrorsSuppressed = true;
            this.webBrowserMap.ScrollBarsEnabled = false;
            this.webBrowserMap.Size = new System.Drawing.Size(1024, 768);
            this.webBrowserMap.TabIndex = 39;
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxPreview.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(1024, 768);
            this.pictureBoxPreview.TabIndex = 40;
            this.pictureBoxPreview.TabStop = false;
            // 
            // buttonPreviewDemo
            // 
            this.buttonPreviewDemo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonPreviewDemo.Location = new System.Drawing.Point(86, 111);
            this.buttonPreviewDemo.Name = "buttonPreviewDemo";
            this.buttonPreviewDemo.Size = new System.Drawing.Size(26, 29);
            this.buttonPreviewDemo.TabIndex = 47;
            this.buttonPreviewDemo.Text = "Preview";
            this.buttonPreviewDemo.UseVisualStyleBackColor = true;
            this.buttonPreviewDemo.Click += new System.EventHandler(this.buttonPreviewDemo_Click);
            // 
            // WUW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.pictureBoxDisplay);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.photoDemo_TakePhoto);
            this.Controls.Add(this.labelDemoName);
            this.Controls.Add(this.labelP);
            this.Controls.Add(this.labelO);
            this.Controls.Add(this.labelN);
            this.Controls.Add(this.labelM);
            this.Controls.Add(this.btnShowHide);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.tabSettings);
            this.Controls.Add(this.pictureBoxAlbum);
            this.Controls.Add(this.drawPanel);
            this.Controls.Add(this.pictureBoxPreview);
            this.Controls.Add(this.pictureBoxTestDemo);
            this.Controls.Add(this.elementHostMail);
            this.Controls.Add(this.elementHostStock);
            this.Controls.Add(this.elementHostDraw);
            this.Controls.Add(this.elementHostClock);
            this.Controls.Add(this.elementHostWeather);
            this.Controls.Add(this.elementHostMenu);
            this.Controls.Add(this.elementHostNewsPaper);
            this.Controls.Add(this.webBrowserGallery);
            this.Controls.Add(this.webBrowserMap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "WUW";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "WUW v01";
            this.Load += new System.EventHandler(this.WUW_Load);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WUW_MouseUp);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.WUW_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WUW_MouseDown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WUW_FormClosing);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WUW_MouseMove);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WUW_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisplay)).EndInit();
            this.tabSettings.ResumeLayout(false);
            this.tabPageCamera.ResumeLayout(false);
            this.groupBoxCameraInfo.ResumeLayout(false);
            this.groupBoxCameraInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCameraFPSLimit)).EndInit();
            this.tabPageTokens.ResumeLayout(false);
            this.tabPageTokens.PerformLayout();
            this.groupBoxMarkerControl.ResumeLayout(false);
            this.groupBoxMarkerControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMarkerThresh)).EndInit();
            this.tabPageApps.ResumeLayout(false);
            this.tabPageApps.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlbum)).EndInit();
            this.drawPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTestDemo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxDisplay;
        private System.Windows.Forms.TabControl tabSettings;
        private System.Windows.Forms.TabPage tabPageCamera;
        private System.Windows.Forms.TabPage tabPageTokens;
        private System.Windows.Forms.TabPage tabPageApps;
        private System.Windows.Forms.ComboBox comboBoxCameras;
        private System.Windows.Forms.GroupBox groupBoxCameraInfo;
        private System.Windows.Forms.CheckBox checkBoxCameraFPSLimit;
        private System.Windows.Forms.Label labelCameraFPSValue;
        private System.Windows.Forms.NumericUpDown numericUpDownCameraFPSLimit;
        private System.Windows.Forms.Label labelCameraFPS;
        private System.Windows.Forms.Button buttonCameraProperties;
        private System.Windows.Forms.ComboBox comboBoxMarkers;
        private System.Windows.Forms.Button buttonMarkerAdd;
        private System.Windows.Forms.GroupBox groupBoxMarkerControl;
        private System.Windows.Forms.NumericUpDown numericUpDownMarkerThresh;
        private System.Windows.Forms.Label labelMarkerThresh;
        private System.Windows.Forms.CheckBox checkBoxMarkerSmoothing;
        private System.Windows.Forms.CheckBox checkBoxMarkerHighlight;
        private System.Windows.Forms.RichTextBox labelMarkerData;
        private System.Windows.Forms.Button buttonMarkerRemove;
        private System.Windows.Forms.RichTextBox labelDemoInstructions;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnShowHide;
        private System.Windows.Forms.Label lblTotalMarker;
        private System.Windows.Forms.Label lblMarkerCount;
        private System.Windows.Forms.Integration.ElementHost elementHostDraw;
        private System.Windows.Forms.Button buttonDrawDemo;
        private System.Windows.Forms.Label labelM;
        private System.Windows.Forms.Label labelN;
        private System.Windows.Forms.Label labelO;
        private System.Windows.Forms.Label labelP;
        private System.Windows.Forms.Label labelDemoName;
        private System.Windows.Forms.Button buttonMapDemo;
        private System.Windows.Forms.Button photoDemo_TakePhoto;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.Button buttonGestureDemo;
        private System.Windows.Forms.PictureBox pictureBoxAlbum;
        private System.Windows.Forms.Button buttonPhotoDemo;
        private System.Windows.Forms.Panel drawPanel;
        private System.Windows.Forms.Button inkCanvasToggle;
        private System.Windows.Forms.Button inkCanvasThicker;
        private System.Windows.Forms.Button inkCanvasThinner;
        private System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.Button inkCanvasGreen;
        private System.Windows.Forms.Button inkCanvasRed;
        private System.Windows.Forms.Button inkCanvasYellow;
        private System.Windows.Forms.Button inkCanvasWhite;
        private System.Windows.Forms.Integration.ElementHost elementHostClock;
        private System.Windows.Forms.Button buttonClockDemo;
        private System.Windows.Forms.Button buttonWeatherDemo;
        private System.Windows.Forms.Button buttonMenuDemo;
        private System.Windows.Forms.Integration.ElementHost elementHostWeather;
        private System.Windows.Forms.Integration.ElementHost elementHostMenu;
        private System.Windows.Forms.Button buttonNewsPaperDemo;
        private System.Windows.Forms.Integration.ElementHost elementHostStock;
        private System.Windows.Forms.Button buttonMailDemo;
        private System.Windows.Forms.Button buttonBookDemo;
        private System.Windows.Forms.Integration.ElementHost elementHostNewsPaper;
        private System.Windows.Forms.Button buttonGalleryDemo;
        private System.Windows.Forms.Button buttonStockDemo;
        private System.Windows.Forms.Button buttonTestDemo;
        private System.Windows.Forms.Button buttonGlobeDemo;
        private System.Windows.Forms.Button buttonEffectsDemo;
        private System.Windows.Forms.WebBrowser webBrowserGallery;
        private System.Windows.Forms.Button buttonLoadMarkers;
        private System.Windows.Forms.Button buttonSaveMarkers;
        private System.Windows.Forms.PictureBox pictureBoxTestDemo;
        private System.Windows.Forms.Integration.ElementHost elementHostMail;
        private System.Windows.Forms.WebBrowser webBrowserMap;
        private System.Windows.Forms.CheckBox checkBox_F;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private System.Windows.Forms.Button buttonPreviewDemo;        
    }
}

