namespace OfficeSoftware
{
    partial class ImageGallery
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
            this.label1 = new System.Windows.Forms.Label();
            this.AddImage = new FontAwesome.Sharp.IconButton();
            this.imagePanel = new System.Windows.Forms.Panel();
            this.imagePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(18, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản lý Hình ảnh";
            // 
            // AddImage
            // 
            this.AddImage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddImage.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.AddImage.IconColor = System.Drawing.Color.Black;
            this.AddImage.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.AddImage.IconSize = 30;
            this.AddImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddImage.Location = new System.Drawing.Point(20, 55);
            this.AddImage.Name = "AddImage";
            this.AddImage.Size = new System.Drawing.Size(142, 47);
            this.AddImage.TabIndex = 1;
            this.AddImage.Text = "    Thêm ảnh";
            this.AddImage.UseVisualStyleBackColor = true;
            this.AddImage.Click += new System.EventHandler(this.AddImage_Click);
            // 
            // imagePanel
            // 
            this.imagePanel.Controls.Add(this.AddImage);
            this.imagePanel.Controls.Add(this.label1);
            this.imagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imagePanel.Location = new System.Drawing.Point(0, 0);
            this.imagePanel.Name = "imagePanel";
            this.imagePanel.Size = new System.Drawing.Size(1319, 696);
            this.imagePanel.TabIndex = 2;
            // 
            // ImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1319, 696);
            this.Controls.Add(this.imagePanel);
            this.Name = "ImageForm";
            this.Text = "ImageForm";
            this.Load += new System.EventHandler(this.ImageForm_Load);
            this.imagePanel.ResumeLayout(false);
            this.imagePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton AddImage;
        private System.Windows.Forms.Panel imagePanel;
    }
}