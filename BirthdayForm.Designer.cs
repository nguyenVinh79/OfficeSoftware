namespace OfficeSoftware
{
    partial class BirthdayForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BirthdayForm));
            this.label1 = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.DepartmentLable = new System.Windows.Forms.Label();
            this.ImgSlideEnTimer = new System.Windows.Forms.Timer(this.components);
            this.ImageSlider = new System.Windows.Forms.PictureBox();
            this.slideTimer = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dayNow = new System.Windows.Forms.Label();
            this.monthNow = new System.Windows.Forms.Label();
            this.switchEntityTimer = new System.Windows.Forms.Timer(this.components);
            this.PositionLabel = new System.Windows.Forms.Label();
            this.yearNow = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ImageSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 42.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(215, 231);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(911, 100);
            this.label1.TabIndex = 1;
            this.label1.Text = "CHÚC MỪNG SINH NHẬT";
            // 
            // NameLabel
            // 
            this.NameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NameLabel.BackColor = System.Drawing.Color.Transparent;
            this.NameLabel.Font = new System.Drawing.Font("Times New Roman", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.NameLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.NameLabel.Location = new System.Drawing.Point(128, 359);
            this.NameLabel.MaximumSize = new System.Drawing.Size(1100, 80);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(1100, 80);
            this.NameLabel.TabIndex = 1;
            this.NameLabel.Text = "Ông Họ Và Tên";
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.NameLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // DepartmentLable
            // 
            this.DepartmentLable.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DepartmentLable.BackColor = System.Drawing.Color.Transparent;
            this.DepartmentLable.Font = new System.Drawing.Font("Times New Roman", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DepartmentLable.ForeColor = System.Drawing.Color.DarkBlue;
            this.DepartmentLable.Location = new System.Drawing.Point(105, 586);
            this.DepartmentLable.MaximumSize = new System.Drawing.Size(1172, 125);
            this.DepartmentLable.Name = "DepartmentLable";
            this.DepartmentLable.Size = new System.Drawing.Size(1172, 125);
            this.DepartmentLable.TabIndex = 1;
            this.DepartmentLable.Text = "Phòng ban";
            this.DepartmentLable.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.DepartmentLable.Click += new System.EventHandler(this.label2_Click);
            // 
            // ImgSlideEnTimer
            // 
            this.ImgSlideEnTimer.Tick += new System.EventHandler(this.ImgSlideEnTimer_Tick);
            // 
            // ImageSlider
            // 
            this.ImageSlider.BackColor = System.Drawing.Color.Transparent;
            this.ImageSlider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageSlider.Location = new System.Drawing.Point(0, 0);
            this.ImageSlider.Name = "ImageSlider";
            this.ImageSlider.Size = new System.Drawing.Size(1440, 832);
            this.ImageSlider.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImageSlider.TabIndex = 3;
            this.ImageSlider.TabStop = false;
            // 
            // slideTimer
            // 
            this.slideTimer.Interval = 3000;
            this.slideTimer.Tick += new System.EventHandler(this.slideTimer_Tick);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(388, 668);
            this.label3.MaximumSize = new System.Drawing.Size(190, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 60);
            this.label3.TabIndex = 1;
            this.label3.Text = "THÁNG";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Click += new System.EventHandler(this.label2_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(601, 668);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 60);
            this.label4.TabIndex = 1;
            this.label4.Text = "NĂM";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Click += new System.EventHandler(this.label2_Click);
            // 
            // dayNow
            // 
            this.dayNow.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dayNow.BackColor = System.Drawing.Color.Transparent;
            this.dayNow.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dayNow.ForeColor = System.Drawing.Color.Red;
            this.dayNow.Location = new System.Drawing.Point(325, 668);
            this.dayNow.Name = "dayNow";
            this.dayNow.Size = new System.Drawing.Size(62, 60);
            this.dayNow.TabIndex = 1;
            this.dayNow.Text = "10";
            this.dayNow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dayNow.Click += new System.EventHandler(this.label2_Click);
            // 
            // monthNow
            // 
            this.monthNow.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.monthNow.BackColor = System.Drawing.Color.Transparent;
            this.monthNow.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.monthNow.ForeColor = System.Drawing.Color.Red;
            this.monthNow.Location = new System.Drawing.Point(543, 668);
            this.monthNow.MaximumSize = new System.Drawing.Size(200, 60);
            this.monthNow.Name = "monthNow";
            this.monthNow.Size = new System.Drawing.Size(69, 60);
            this.monthNow.TabIndex = 1;
            this.monthNow.Text = "10";
            this.monthNow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.monthNow.Click += new System.EventHandler(this.label2_Click);
            // 
            // switchEntityTimer
            // 
            this.switchEntityTimer.Interval = 5000;
            this.switchEntityTimer.Tick += new System.EventHandler(this.switchEntityTimer_Tick);
            // 
            // PositionLabel
            // 
            this.PositionLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PositionLabel.BackColor = System.Drawing.Color.Transparent;
            this.PositionLabel.Font = new System.Drawing.Font("Times New Roman", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PositionLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.PositionLabel.Location = new System.Drawing.Point(105, 461);
            this.PositionLabel.MaximumSize = new System.Drawing.Size(1172, 125);
            this.PositionLabel.Name = "PositionLabel";
            this.PositionLabel.Size = new System.Drawing.Size(1172, 125);
            this.PositionLabel.TabIndex = 1;
            this.PositionLabel.Text = "Chức vụ";
            this.PositionLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.PositionLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // yearNow
            // 
            this.yearNow.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.yearNow.BackColor = System.Drawing.Color.Transparent;
            this.yearNow.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.yearNow.ForeColor = System.Drawing.Color.Red;
            this.yearNow.Location = new System.Drawing.Point(715, 668);
            this.yearNow.Name = "yearNow";
            this.yearNow.Size = new System.Drawing.Size(103, 60);
            this.yearNow.TabIndex = 1;
            this.yearNow.Text = "2022";
            this.yearNow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.yearNow.Click += new System.EventHandler(this.label2_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(215, 668);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 60);
            this.label2.TabIndex = 1;
            this.label2.Text = "NGÀY";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // BirthdayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1440, 832);
            this.ControlBox = false;
            this.Controls.Add(this.dayNow);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.yearNow);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.monthNow);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.PositionLabel);
            this.Controls.Add(this.DepartmentLable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ImageSlider);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BirthdayForm";
            this.Text = "BirthdayForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.BirthdayForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ImageSlider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label DepartmentLable;
        private System.Windows.Forms.Timer CloseForm;
        private System.Windows.Forms.Timer ImgSlideEnTimer;
        private System.Windows.Forms.PictureBox ImageSlider;
        private System.Windows.Forms.Timer slideTimer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label dayNow;
        private System.Windows.Forms.Label monthNow;
        private System.Windows.Forms.Timer switchEntityTimer;
        private System.Windows.Forms.Label PositionLabel;
        private System.Windows.Forms.Label yearNow;
        private System.Windows.Forms.Label label2;
    }
}