namespace Security_Camera
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.Camera = new System.Windows.Forms.PictureBox();
            this.CaptureButton = new Guna.UI2.WinForms.Guna2Button();
            this.RecordButton = new Guna.UI2.WinForms.Guna2Button();
            this.RebootButton = new Guna.UI2.WinForms.Guna2Button();
            this.AlarmSoundButton = new Guna.UI2.WinForms.Guna2Button();
            this.AlarmDetectionButton = new Guna.UI2.WinForms.Guna2Button();
            this.EmailAlertButton = new Guna.UI2.WinForms.Guna2Button();
            this.CloudUploadButton = new Guna.UI2.WinForms.Guna2Button();
            this.CloseButton = new Guna.UI2.WinForms.Guna2Button();
            this.TextToSpeechButton = new Guna.UI2.WinForms.Guna2Button();
            this.TextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.LoadingCamera = new Guna.UI2.WinForms.Guna2WinProgressIndicator();
            ((System.ComponentModel.ISupportInitialize)(this.Camera)).BeginInit();
            this.SuspendLayout();
            // 
            // Camera
            // 
            this.Camera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Camera.Enabled = false;
            this.Camera.ErrorImage = null;
            this.Camera.InitialImage = null;
            this.Camera.Location = new System.Drawing.Point(0, 0);
            this.Camera.Margin = new System.Windows.Forms.Padding(0);
            this.Camera.Name = "Camera";
            this.Camera.Size = new System.Drawing.Size(640, 480);
            this.Camera.TabIndex = 1;
            this.Camera.TabStop = false;
            this.Camera.WaitOnLoad = true;
            this.Camera.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Camera_MouseDown);
            this.Camera.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Camera_MouseMove);
            this.Camera.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Camera_MouseUp);
            // 
            // CaptureButton
            // 
            this.CaptureButton.Animated = true;
            this.CaptureButton.BorderRadius = 20;
            this.CaptureButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.CaptureButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.CaptureButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.CaptureButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.CaptureButton.FillColor = System.Drawing.Color.DodgerBlue;
            this.CaptureButton.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.CaptureButton.ForeColor = System.Drawing.Color.White;
            this.CaptureButton.Location = new System.Drawing.Point(48, 497);
            this.CaptureButton.Name = "CaptureButton";
            this.CaptureButton.Size = new System.Drawing.Size(100, 40);
            this.CaptureButton.TabIndex = 3;
            this.CaptureButton.Text = "Capture";
            this.CaptureButton.Click += new System.EventHandler(this.CaptureButton_Click);
            // 
            // RecordButton
            // 
            this.RecordButton.Animated = true;
            this.RecordButton.BorderRadius = 20;
            this.RecordButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.RecordButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.RecordButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.RecordButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.RecordButton.FillColor = System.Drawing.Color.DodgerBlue;
            this.RecordButton.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.RecordButton.ForeColor = System.Drawing.Color.White;
            this.RecordButton.Location = new System.Drawing.Point(193, 497);
            this.RecordButton.Name = "RecordButton";
            this.RecordButton.Size = new System.Drawing.Size(100, 40);
            this.RecordButton.TabIndex = 4;
            this.RecordButton.Text = "Record";
            this.RecordButton.Click += new System.EventHandler(this.RecordButton_Click);
            // 
            // RebootButton
            // 
            this.RebootButton.Animated = true;
            this.RebootButton.BorderRadius = 20;
            this.RebootButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.RebootButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.RebootButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.RebootButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.RebootButton.FillColor = System.Drawing.Color.DodgerBlue;
            this.RebootButton.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.RebootButton.ForeColor = System.Drawing.Color.White;
            this.RebootButton.Location = new System.Drawing.Point(343, 497);
            this.RebootButton.Name = "RebootButton";
            this.RebootButton.Size = new System.Drawing.Size(100, 40);
            this.RebootButton.TabIndex = 5;
            this.RebootButton.Text = "Reboot";
            this.RebootButton.Click += new System.EventHandler(this.RebootButton_Click);
            // 
            // AlarmSoundButton
            // 
            this.AlarmSoundButton.Animated = true;
            this.AlarmSoundButton.BorderRadius = 20;
            this.AlarmSoundButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.AlarmSoundButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.AlarmSoundButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.AlarmSoundButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.AlarmSoundButton.FillColor = System.Drawing.Color.DodgerBlue;
            this.AlarmSoundButton.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.AlarmSoundButton.ForeColor = System.Drawing.Color.White;
            this.AlarmSoundButton.Location = new System.Drawing.Point(48, 552);
            this.AlarmSoundButton.Name = "AlarmSoundButton";
            this.AlarmSoundButton.Size = new System.Drawing.Size(100, 40);
            this.AlarmSoundButton.TabIndex = 6;
            this.AlarmSoundButton.Text = "Alarm Sound";
            this.AlarmSoundButton.Click += new System.EventHandler(this.AlarmSoundButton_Click);
            // 
            // AlarmDetectionButton
            // 
            this.AlarmDetectionButton.Animated = true;
            this.AlarmDetectionButton.BorderRadius = 20;
            this.AlarmDetectionButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.AlarmDetectionButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.AlarmDetectionButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.AlarmDetectionButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.AlarmDetectionButton.FillColor = System.Drawing.Color.DodgerBlue;
            this.AlarmDetectionButton.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.AlarmDetectionButton.ForeColor = System.Drawing.Color.White;
            this.AlarmDetectionButton.Location = new System.Drawing.Point(193, 552);
            this.AlarmDetectionButton.Name = "AlarmDetectionButton";
            this.AlarmDetectionButton.Size = new System.Drawing.Size(100, 40);
            this.AlarmDetectionButton.TabIndex = 7;
            this.AlarmDetectionButton.Text = "Alarm Detection";
            this.AlarmDetectionButton.Click += new System.EventHandler(this.AlarmDetectionButton_Click);
            // 
            // EmailAlertButton
            // 
            this.EmailAlertButton.Animated = true;
            this.EmailAlertButton.BorderRadius = 20;
            this.EmailAlertButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.EmailAlertButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.EmailAlertButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.EmailAlertButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.EmailAlertButton.FillColor = System.Drawing.Color.DodgerBlue;
            this.EmailAlertButton.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.EmailAlertButton.ForeColor = System.Drawing.Color.White;
            this.EmailAlertButton.Location = new System.Drawing.Point(343, 552);
            this.EmailAlertButton.Name = "EmailAlertButton";
            this.EmailAlertButton.Size = new System.Drawing.Size(100, 40);
            this.EmailAlertButton.TabIndex = 8;
            this.EmailAlertButton.Text = "Email Alert";
            this.EmailAlertButton.Click += new System.EventHandler(this.EmailAlertButton_Click);
            // 
            // CloudUploadButton
            // 
            this.CloudUploadButton.Animated = true;
            this.CloudUploadButton.BorderRadius = 20;
            this.CloudUploadButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.CloudUploadButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.CloudUploadButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.CloudUploadButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.CloudUploadButton.FillColor = System.Drawing.Color.DodgerBlue;
            this.CloudUploadButton.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.CloudUploadButton.ForeColor = System.Drawing.Color.White;
            this.CloudUploadButton.Location = new System.Drawing.Point(495, 552);
            this.CloudUploadButton.Name = "CloudUploadButton";
            this.CloudUploadButton.Size = new System.Drawing.Size(100, 40);
            this.CloudUploadButton.TabIndex = 9;
            this.CloudUploadButton.Text = "Cloud Upload";
            this.CloudUploadButton.Click += new System.EventHandler(this.CloudUploadButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Animated = true;
            this.CloseButton.BorderRadius = 20;
            this.CloseButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.CloseButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.CloseButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.CloseButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.CloseButton.FillColor = System.Drawing.Color.DodgerBlue;
            this.CloseButton.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.CloseButton.ForeColor = System.Drawing.Color.White;
            this.CloseButton.Location = new System.Drawing.Point(495, 497);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(100, 40);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "Close";
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // TextToSpeechButton
            // 
            this.TextToSpeechButton.Animated = true;
            this.TextToSpeechButton.BorderRadius = 20;
            this.TextToSpeechButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.TextToSpeechButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.TextToSpeechButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.TextToSpeechButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.TextToSpeechButton.FillColor = System.Drawing.Color.DodgerBlue;
            this.TextToSpeechButton.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.TextToSpeechButton.ForeColor = System.Drawing.Color.White;
            this.TextToSpeechButton.Location = new System.Drawing.Point(495, 607);
            this.TextToSpeechButton.Name = "TextToSpeechButton";
            this.TextToSpeechButton.Size = new System.Drawing.Size(100, 40);
            this.TextToSpeechButton.TabIndex = 10;
            this.TextToSpeechButton.Text = "Text To Speech";
            this.TextToSpeechButton.Click += new System.EventHandler(this.TextToSpeechButton_Click);
            // 
            // TextBox
            // 
            this.TextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.TextBox.BorderColor = System.Drawing.Color.DodgerBlue;
            this.TextBox.BorderRadius = 15;
            this.TextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBox.DefaultText = "";
            this.TextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.TextBox.ForeColor = System.Drawing.Color.Black;
            this.TextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TextBox.Location = new System.Drawing.Point(49, 609);
            this.TextBox.MaxLength = 100;
            this.TextBox.Name = "TextBox";
            this.TextBox.PasswordChar = '\0';
            this.TextBox.PlaceholderText = "";
            this.TextBox.SelectedText = "";
            this.TextBox.Size = new System.Drawing.Size(394, 35);
            this.TextBox.TabIndex = 2;
            this.TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.TextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TextBox_MouseDown);
            // 
            // LoadingCamera
            // 
            this.LoadingCamera.AutoStart = true;
            this.LoadingCamera.BackColor = System.Drawing.Color.Transparent;
            this.LoadingCamera.CircleSize = 1F;
            this.LoadingCamera.Location = new System.Drawing.Point(285, 185);
            this.LoadingCamera.Name = "LoadingCamera";
            this.LoadingCamera.ProgressColor = System.Drawing.Color.DodgerBlue;
            this.LoadingCamera.Size = new System.Drawing.Size(76, 72);
            this.LoadingCamera.TabIndex = 25;
            this.LoadingCamera.UseTransparentBackground = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(640, 550);
            this.Controls.Add(this.LoadingCamera);
            this.Controls.Add(this.TextBox);
            this.Controls.Add(this.TextToSpeechButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.CloudUploadButton);
            this.Controls.Add(this.EmailAlertButton);
            this.Controls.Add(this.AlarmDetectionButton);
            this.Controls.Add(this.AlarmSoundButton);
            this.Controls.Add(this.RebootButton);
            this.Controls.Add(this.RecordButton);
            this.Controls.Add(this.CaptureButton);
            this.Controls.Add(this.Camera);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Security Camera";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Main_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Main_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Main_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.Camera)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Camera;
        private Guna.UI2.WinForms.Guna2Button CaptureButton;
        private Guna.UI2.WinForms.Guna2Button RecordButton;
        private Guna.UI2.WinForms.Guna2Button RebootButton;
        private Guna.UI2.WinForms.Guna2Button AlarmSoundButton;
        private Guna.UI2.WinForms.Guna2Button AlarmDetectionButton;
        private Guna.UI2.WinForms.Guna2Button EmailAlertButton;
        private Guna.UI2.WinForms.Guna2Button CloudUploadButton;
        private Guna.UI2.WinForms.Guna2Button CloseButton;
        private Guna.UI2.WinForms.Guna2Button TextToSpeechButton;
        private Guna.UI2.WinForms.Guna2TextBox TextBox;
        private Guna.UI2.WinForms.Guna2WinProgressIndicator LoadingCamera;
    }
}

