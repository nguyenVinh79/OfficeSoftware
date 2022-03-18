namespace OfficeSoftware
{
    partial class AnnouncementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnnouncementForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NameText = new System.Windows.Forms.Label();
            this.TypeText = new System.Windows.Forms.Label();
            this.DepartmentText = new System.Windows.Forms.Label();
            this.showTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(407, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(455, 81);
            this.label1.TabIndex = 1;
            this.label1.Text = "CHÀO MỪNG";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(14, 365);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 60);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ông/bà:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NameText
            // 
            this.NameText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NameText.BackColor = System.Drawing.Color.Transparent;
            this.NameText.Font = new System.Drawing.Font("Tahoma", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NameText.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.NameText.Location = new System.Drawing.Point(216, 365);
            this.NameText.MaximumSize = new System.Drawing.Size(1000, 60);
            this.NameText.Name = "NameText";
            this.NameText.Size = new System.Drawing.Size(973, 60);
            this.NameText.TabIndex = 1;
            this.NameText.Text = "Họ và Tên";
            this.NameText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TypeText
            // 
            this.TypeText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TypeText.BackColor = System.Drawing.Color.Transparent;
            this.TypeText.Font = new System.Drawing.Font("Tahoma", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TypeText.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TypeText.Location = new System.Drawing.Point(13, 483);
            this.TypeText.MaximumSize = new System.Drawing.Size(1150, 60);
            this.TypeText.Name = "TypeText";
            this.TypeText.Size = new System.Drawing.Size(1140, 60);
            this.TypeText.TabIndex = 1;
            this.TypeText.Text = "ĐÃ GIA NHẬP CÔNG TY, VÀ CHÍNH THỨC CÔNG TÁC TẠI ";
            this.TypeText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DepartmentText
            // 
            this.DepartmentText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DepartmentText.BackColor = System.Drawing.Color.Transparent;
            this.DepartmentText.Font = new System.Drawing.Font("Tahoma", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DepartmentText.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DepartmentText.Location = new System.Drawing.Point(12, 598);
            this.DepartmentText.MaximumSize = new System.Drawing.Size(1100, 130);
            this.DepartmentText.Name = "DepartmentText";
            this.DepartmentText.Size = new System.Drawing.Size(1100, 120);
            this.DepartmentText.TabIndex = 1;
            this.DepartmentText.Text = "Phòng ban";
            // 
            // showTimer
            // 
            this.showTimer.Interval = 5000;
            this.showTimer.Tick += new System.EventHandler(this.showTimer_Tick);
            // 
            // AnnouncementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1558, 812);
            this.Controls.Add(this.DepartmentText);
            this.Controls.Add(this.TypeText);
            this.Controls.Add(this.NameText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "AnnouncementForm";
            this.Text = "Announcement";
            this.Load += new System.EventHandler(this.Announcement_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label NameText;
        private System.Windows.Forms.Label TypeText;
        private System.Windows.Forms.Label DepartmentText;
        private System.Windows.Forms.Timer showTimer;
    }
}