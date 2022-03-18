using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace OfficeSoftware
{
    public partial class ImageSlide : Form
    {
        protected int imageIndex = 0;
        protected int imageCount = 0;
        protected string[] fileEntries;
        public ImageSlide()
        {
            InitializeComponent();
        }

        private void ImageSlide_Load(object sender, EventArgs e)
        {
            #region Configure image slider

            var directory = Directory.GetCurrentDirectory();
            var ImagePath = Directory.GetCurrentDirectory() + "\\ImageSlider\\";

            fileEntries = Directory.GetFiles(ImagePath);
            if (fileEntries.Length > 0)
            {
                ImageBox.ImageLocation = fileEntries[0];
                imageCount = fileEntries.Length;


                SlideTimer.Enabled = true;
                SlideTimer.Start();
            }
            #endregion
        }

        private void SlideTimer_Tick(object sender, EventArgs e)
        {
            SlideTimer.Stop();

            if ((imageCount - 1) == imageIndex)
            {
                imageIndex = 0;
            }
            else
                imageIndex++;

            ImageBox.ImageLocation = fileEntries[imageIndex];
            SlideTimer.Start();
        }
    
    }
}
