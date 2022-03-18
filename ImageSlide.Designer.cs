namespace OfficeSoftware
{
    partial class ImageSlide
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.ImageBox = new System.Windows.Forms.PictureBox();
            this.SlideTimer = new System.Windows.Forms.Timer(this.components);
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.ImageBox);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1233, 552);
            this.mainPanel.TabIndex = 0;
            // 
            // ImageBox
            // 
            this.ImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageBox.Location = new System.Drawing.Point(0, 0);
            this.ImageBox.Name = "ImageBox";
            this.ImageBox.Size = new System.Drawing.Size(1233, 552);
            this.ImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImageBox.TabIndex = 0;
            this.ImageBox.TabStop = false;
            // 
            // SlideTimer
            // 
            this.SlideTimer.Interval = 4900;
            this.SlideTimer.Tick += new System.EventHandler(this.SlideTimer_Tick);
            // 
            // ImageSlide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1233, 552);
            this.Controls.Add(this.mainPanel);
            this.Name = "ImageSlide";
            this.Text = "Media";
            this.Load += new System.EventHandler(this.ImageSlide_Load);
            this.mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.PictureBox ImageBox;
        private System.Windows.Forms.Timer SlideTimer;
    }
}