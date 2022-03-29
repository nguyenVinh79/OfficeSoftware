namespace OfficeSoftware
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TaskbarPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SettingButton = new OfficeSoftware.CustomButtom();
            this.ImageSettingButton = new OfficeSoftware.CustomButtom();
            this.ImageSlideButton = new OfficeSoftware.CustomButtom();
            this.EventButton = new OfficeSoftware.CustomButtom();
            this.badNewsButton = new OfficeSoftware.CustomButtom();
            this.birthdayButton = new OfficeSoftware.CustomButtom();
            this.CalendarButton = new OfficeSoftware.CustomButtom();
            this.WindowMinimizeButton = new System.Windows.Forms.Button();
            this.WindowMaximizeBtn = new System.Windows.Forms.Button();
            this.WindowCloseBtn = new System.Windows.Forms.Button();
            this.ShowBtn = new System.Windows.Forms.Button();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.BirthdayTimer = new System.Windows.Forms.Timer(this.components);
            this.BDshowTimer = new System.Windows.Forms.Timer(this.components);
            this.saveExcelTimer = new System.Windows.Forms.Timer(this.components);
            this.SlideTimer = new System.Windows.Forms.Timer(this.components);
            this.AutoHideTimer = new System.Windows.Forms.Timer(this.components);
            this.TaskbarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.MainPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
            this.SuspendLayout();
            // 
            // TaskbarPanel
            // 
            this.TaskbarPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TaskbarPanel.Controls.Add(this.pictureBox1);
            this.TaskbarPanel.Controls.Add(this.SettingButton);
            this.TaskbarPanel.Controls.Add(this.ImageSettingButton);
            this.TaskbarPanel.Controls.Add(this.ImageSlideButton);
            this.TaskbarPanel.Controls.Add(this.EventButton);
            this.TaskbarPanel.Controls.Add(this.badNewsButton);
            this.TaskbarPanel.Controls.Add(this.birthdayButton);
            this.TaskbarPanel.Controls.Add(this.CalendarButton);
            this.TaskbarPanel.Controls.Add(this.WindowMinimizeButton);
            this.TaskbarPanel.Controls.Add(this.WindowMaximizeBtn);
            this.TaskbarPanel.Controls.Add(this.WindowCloseBtn);
            this.TaskbarPanel.Controls.Add(this.ShowBtn);
            this.TaskbarPanel.Location = new System.Drawing.Point(0, 0);
            this.TaskbarPanel.Name = "TaskbarPanel";
            this.TaskbarPanel.Size = new System.Drawing.Size(1522, 52);
            this.TaskbarPanel.TabIndex = 0;
            this.TaskbarPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.TaskbarPanel_Paint);
            this.TaskbarPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TaskbarPanel_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(5, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(138, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // SettingButton
            // 
            this.SettingButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.SettingButton.BackgroundColor = System.Drawing.SystemColors.Highlight;
            this.SettingButton.BorderColor = System.Drawing.Color.LavenderBlush;
            this.SettingButton.BorderRadius = 20;
            this.SettingButton.BorderSize = 0;
            this.SettingButton.FlatAppearance.BorderSize = 0;
            this.SettingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SettingButton.ForeColor = System.Drawing.Color.White;
            this.SettingButton.Location = new System.Drawing.Point(1007, 4);
            this.SettingButton.Name = "SettingButton";
            this.SettingButton.Size = new System.Drawing.Size(116, 42);
            this.SettingButton.TabIndex = 0;
            this.SettingButton.Text = "Cài Đặt";
            this.SettingButton.TextColor = System.Drawing.Color.White;
            this.SettingButton.UseVisualStyleBackColor = false;
            this.SettingButton.Click += new System.EventHandler(this.SettingButton_Click);
            // 
            // ImageSettingButton
            // 
            this.ImageSettingButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.ImageSettingButton.BackgroundColor = System.Drawing.SystemColors.Highlight;
            this.ImageSettingButton.BorderColor = System.Drawing.Color.LavenderBlush;
            this.ImageSettingButton.BorderRadius = 20;
            this.ImageSettingButton.BorderSize = 0;
            this.ImageSettingButton.FlatAppearance.BorderSize = 0;
            this.ImageSettingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ImageSettingButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ImageSettingButton.ForeColor = System.Drawing.Color.White;
            this.ImageSettingButton.Location = new System.Drawing.Point(875, 4);
            this.ImageSettingButton.Name = "ImageSettingButton";
            this.ImageSettingButton.Size = new System.Drawing.Size(116, 42);
            this.ImageSettingButton.TabIndex = 0;
            this.ImageSettingButton.Text = "T.Viện Ảnh";
            this.ImageSettingButton.TextColor = System.Drawing.Color.White;
            this.ImageSettingButton.UseVisualStyleBackColor = false;
            this.ImageSettingButton.Click += new System.EventHandler(this.ImageSettingButton_Click);
            // 
            // ImageSlideButton
            // 
            this.ImageSlideButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.ImageSlideButton.BackgroundColor = System.Drawing.SystemColors.Highlight;
            this.ImageSlideButton.BorderColor = System.Drawing.Color.LavenderBlush;
            this.ImageSlideButton.BorderRadius = 20;
            this.ImageSlideButton.BorderSize = 0;
            this.ImageSlideButton.FlatAppearance.BorderSize = 0;
            this.ImageSlideButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ImageSlideButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ImageSlideButton.ForeColor = System.Drawing.Color.White;
            this.ImageSlideButton.Location = new System.Drawing.Point(752, 4);
            this.ImageSlideButton.Name = "ImageSlideButton";
            this.ImageSlideButton.Size = new System.Drawing.Size(107, 42);
            this.ImageSlideButton.TabIndex = 0;
            this.ImageSlideButton.Text = "Hình Ảnh";
            this.ImageSlideButton.TextColor = System.Drawing.Color.White;
            this.ImageSlideButton.UseVisualStyleBackColor = false;
            this.ImageSlideButton.Click += new System.EventHandler(this.ImageSlideButton_Click);
            // 
            // EventButton
            // 
            this.EventButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.EventButton.BackgroundColor = System.Drawing.SystemColors.Highlight;
            this.EventButton.BorderColor = System.Drawing.Color.LavenderBlush;
            this.EventButton.BorderRadius = 20;
            this.EventButton.BorderSize = 0;
            this.EventButton.FlatAppearance.BorderSize = 0;
            this.EventButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EventButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EventButton.ForeColor = System.Drawing.Color.White;
            this.EventButton.Location = new System.Drawing.Point(629, 4);
            this.EventButton.Name = "EventButton";
            this.EventButton.Size = new System.Drawing.Size(107, 42);
            this.EventButton.TabIndex = 0;
            this.EventButton.Text = "Sự Kiện";
            this.EventButton.TextColor = System.Drawing.Color.White;
            this.EventButton.UseVisualStyleBackColor = false;
            this.EventButton.Click += new System.EventHandler(this.EventButton_Click);
            // 
            // badNewsButton
            // 
            this.badNewsButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.badNewsButton.BackgroundColor = System.Drawing.SystemColors.Highlight;
            this.badNewsButton.BorderColor = System.Drawing.Color.LavenderBlush;
            this.badNewsButton.BorderRadius = 20;
            this.badNewsButton.BorderSize = 0;
            this.badNewsButton.FlatAppearance.BorderSize = 0;
            this.badNewsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.badNewsButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.badNewsButton.ForeColor = System.Drawing.Color.White;
            this.badNewsButton.Location = new System.Drawing.Point(506, 4);
            this.badNewsButton.Name = "badNewsButton";
            this.badNewsButton.Size = new System.Drawing.Size(107, 42);
            this.badNewsButton.TabIndex = 0;
            this.badNewsButton.Text = "Tin Buồn";
            this.badNewsButton.TextColor = System.Drawing.Color.White;
            this.badNewsButton.UseVisualStyleBackColor = false;
            this.badNewsButton.Click += new System.EventHandler(this.badNewsButton_Click);
            // 
            // birthdayButton
            // 
            this.birthdayButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.birthdayButton.BackgroundColor = System.Drawing.SystemColors.Highlight;
            this.birthdayButton.BorderColor = System.Drawing.Color.LavenderBlush;
            this.birthdayButton.BorderRadius = 20;
            this.birthdayButton.BorderSize = 0;
            this.birthdayButton.FlatAppearance.BorderSize = 0;
            this.birthdayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.birthdayButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.birthdayButton.ForeColor = System.Drawing.Color.White;
            this.birthdayButton.Location = new System.Drawing.Point(383, 4);
            this.birthdayButton.Name = "birthdayButton";
            this.birthdayButton.Size = new System.Drawing.Size(107, 42);
            this.birthdayButton.TabIndex = 0;
            this.birthdayButton.Text = "Sinh Nhật";
            this.birthdayButton.TextColor = System.Drawing.Color.White;
            this.birthdayButton.UseVisualStyleBackColor = false;
            this.birthdayButton.Click += new System.EventHandler(this.birthdayButton_Click);
            // 
            // CalendarButton
            // 
            this.CalendarButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.CalendarButton.BackgroundColor = System.Drawing.SystemColors.Highlight;
            this.CalendarButton.BorderColor = System.Drawing.Color.LavenderBlush;
            this.CalendarButton.BorderRadius = 20;
            this.CalendarButton.BorderSize = 0;
            this.CalendarButton.FlatAppearance.BorderSize = 0;
            this.CalendarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CalendarButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CalendarButton.ForeColor = System.Drawing.Color.White;
            this.CalendarButton.Location = new System.Drawing.Point(260, 4);
            this.CalendarButton.Name = "CalendarButton";
            this.CalendarButton.Size = new System.Drawing.Size(107, 42);
            this.CalendarButton.TabIndex = 0;
            this.CalendarButton.Text = "Lịch Tuần";
            this.CalendarButton.TextColor = System.Drawing.Color.White;
            this.CalendarButton.UseVisualStyleBackColor = false;
            this.CalendarButton.Click += new System.EventHandler(this.CalendarButton_Click);
            // 
            // WindowMinimizeButton
            // 
            this.WindowMinimizeButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.WindowMinimizeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("WindowMinimizeButton.BackgroundImage")));
            this.WindowMinimizeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.WindowMinimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WindowMinimizeButton.ForeColor = System.Drawing.Color.Transparent;
            this.WindowMinimizeButton.Location = new System.Drawing.Point(1387, 6);
            this.WindowMinimizeButton.Name = "WindowMinimizeButton";
            this.WindowMinimizeButton.Size = new System.Drawing.Size(40, 39);
            this.WindowMinimizeButton.TabIndex = 0;
            this.WindowMinimizeButton.UseVisualStyleBackColor = true;
            this.WindowMinimizeButton.Click += new System.EventHandler(this.WindowMinimizeButton_Click);
            // 
            // WindowMaximizeBtn
            // 
            this.WindowMaximizeBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.WindowMaximizeBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("WindowMaximizeBtn.BackgroundImage")));
            this.WindowMaximizeBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.WindowMaximizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WindowMaximizeBtn.ForeColor = System.Drawing.Color.Transparent;
            this.WindowMaximizeBtn.Location = new System.Drawing.Point(1433, 6);
            this.WindowMaximizeBtn.Name = "WindowMaximizeBtn";
            this.WindowMaximizeBtn.Size = new System.Drawing.Size(40, 39);
            this.WindowMaximizeBtn.TabIndex = 0;
            this.WindowMaximizeBtn.UseVisualStyleBackColor = true;
            this.WindowMaximizeBtn.Click += new System.EventHandler(this.WindowMaximizeBtn_Click);
            // 
            // WindowCloseBtn
            // 
            this.WindowCloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.WindowCloseBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("WindowCloseBtn.BackgroundImage")));
            this.WindowCloseBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.WindowCloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WindowCloseBtn.ForeColor = System.Drawing.Color.Transparent;
            this.WindowCloseBtn.Location = new System.Drawing.Point(1479, 6);
            this.WindowCloseBtn.Name = "WindowCloseBtn";
            this.WindowCloseBtn.Size = new System.Drawing.Size(40, 39);
            this.WindowCloseBtn.TabIndex = 0;
            this.WindowCloseBtn.UseVisualStyleBackColor = true;
            this.WindowCloseBtn.Click += new System.EventHandler(this.WindowCloseBtn_Click);
            // 
            // ShowBtn
            // 
            this.ShowBtn.BackColor = System.Drawing.Color.Lime;
            this.ShowBtn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ShowBtn.Location = new System.Drawing.Point(1139, 4);
            this.ShowBtn.Name = "ShowBtn";
            this.ShowBtn.Size = new System.Drawing.Size(123, 42);
            this.ShowBtn.TabIndex = 5;
            this.ShowBtn.Text = "Trình chiếu";
            this.ShowBtn.UseVisualStyleBackColor = false;
            this.ShowBtn.Click += new System.EventHandler(this.ShowBtn_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.panel1);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1522, 1000);
            this.MainPanel.TabIndex = 3;
            this.MainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.MainPanel_Paint);
            this.MainPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainPanel_MouseMove);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.webView21);
            this.panel1.Location = new System.Drawing.Point(0, 927);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1522, 71);
            this.panel1.TabIndex = 3;
            // 
            // webView21
            // 
            this.webView21.CreationProperties = null;
            this.webView21.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView21.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.webView21.Location = new System.Drawing.Point(0, 0);
            this.webView21.Name = "webView21";
            this.webView21.Size = new System.Drawing.Size(1522, 71);
            this.webView21.TabIndex = 2;
            this.webView21.ZoomFactor = 1D;
            // 
            // BirthdayTimer
            // 
            this.BirthdayTimer.Interval = 2000;
            this.BirthdayTimer.Tick += new System.EventHandler(this.BirthdayTimer_Tick);
            // 
            // BDshowTimer
            // 
            this.BDshowTimer.Tick += new System.EventHandler(this.BDshowTimer_Tick);
            // 
            // saveExcelTimer
            // 
            this.saveExcelTimer.Interval = 60000;
            this.saveExcelTimer.Tick += new System.EventHandler(this.saveExcel_Tick);
            // 
            // SlideTimer
            // 
            this.SlideTimer.Tick += new System.EventHandler(this.SlideTimer_Tick);
            // 
            // AutoHideTimer
            // 
            this.AutoHideTimer.Interval = 200;
            this.AutoHideTimer.Tick += new System.EventHandler(this.AutoHideTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1522, 1000);
            this.Controls.Add(this.TaskbarPanel);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(1250, 1000);
            this.Name = "Form1";
            this.Text = "PECC4";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.TaskbarPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.MainPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer BirthdayTimer;
        private System.Windows.Forms.Timer BDshowTimer;
        private System.Windows.Forms.Timer saveExcel;
        private System.Windows.Forms.Timer saveExcelTimer;
        private System.Windows.Forms.Button ShowBtn;
        private System.Windows.Forms.Timer SlideTimer;
        private System.Windows.Forms.Panel TaskbarPanel;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Timer AutoHideTimer;
        private System.Windows.Forms.Button WindowMinimizeButton;
        private System.Windows.Forms.Button WindowMaximizeBtn;
        private System.Windows.Forms.Button WindowCloseBtn;
        private CustomButtom CalendarButton;
        private CustomButtom birthdayButton;
        private CustomButtom badNewsButton;
        private CustomButtom EventButton;
        private CustomButtom ImageSlideButton;
        private CustomButtom ImageSettingButton;
        private CustomButtom SettingButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private System.Windows.Forms.Panel panel1;
    }
}

