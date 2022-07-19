using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OfficeSoftware
{
    public partial class ImageGallery : Form
    {
        public ImageGallery()
        {
            InitializeComponent();
        }

        private void AddImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "Chọn các hình cần trình chiếu";
            openDialog.Multiselect = true;
            openDialog.Filter = "File hình ảnh|*.png;*.jpeg; *.jpg; *.bmp";

            var ImagePath = Directory.GetCurrentDirectory() + "\\ImageSlider\\";

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                for (int i = imagePanel.Controls.Count - 1; i >= 0; i--)
                {
                    if (imagePanel.Controls[i] is PictureBox)
                    {
                        imagePanel.Controls[i].Dispose();
                    }
                }
                string[] files = Directory.GetFiles(ImagePath);
                if(files.Length >0)
                {
                    foreach (var file in files)
                    {
                        File.Delete(file);
                    }
                }   
                
                foreach (var item in openDialog.FileNames)
                {
                    string[] fileDir = item.Split("\\");
                    string fileName = fileDir[(fileDir.Length) - 1];

                    //fileName = $"{imageNum}"
                    var DetailImagePath = ImagePath + fileName;
                    File.Copy(item, DetailImagePath, true);

                }

                #region Load uploaded images
                var currentImagePath = Directory.GetCurrentDirectory() + "\\ImageSlider\\";
                string[] currentImages = Directory.GetFiles(currentImagePath);
                int x = 20;
                int y = 160;
                int maxHeight = -1;

                foreach (var item in currentImages)
                {
                    PictureBox pic = new PictureBox();
                    Image tempImage = Image.FromFile(item);
                    Bitmap tempBitmap = new Bitmap(tempImage);
                    pic.Image = tempBitmap;
                    pic.Size = new Size(260, 180);
                    pic.Location = new Point(x, y);
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    x += pic.Width + 15;
                    maxHeight = Math.Max(pic.Height, maxHeight);
                    if (x > this.ClientSize.Width - 10)
                    {
                        x = 30;
                        y += maxHeight + 60;
                    }

                    imagePanel.Controls.Add(pic);
                    tempImage.Dispose();
                }
                #endregion

                MessageBox.Show("Upload hình ảnh thành công", "Cập nhật hình ảnh trình chiếu");
            }
        }

        private void ImageForm_Load(object sender, EventArgs e)
        {
            var ImagePath = Directory.GetCurrentDirectory() + "\\ImageSlider\\";
            string[] files = Directory.GetFiles(ImagePath);
            int x = 20;
            int y = 160;
            int maxHeight = -1;

            foreach(var file in files)
            {
                PictureBox pic = new PictureBox();
                Image tempImage = Image.FromFile(file);
                Bitmap tempBitmap = new Bitmap(tempImage);
                pic.Image = tempBitmap;
                pic.Size = new Size(200,160);
                pic.Location = new Point(x, y);
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                x += pic.Width+10;
                maxHeight = Math.Max(pic.Height, maxHeight);
                if(x > Screen.PrimaryScreen.Bounds.Width - 150)
                {
                    x = 20;
                    y += maxHeight+40;
                }

                imagePanel.Controls.Add(pic);
                tempImage.Dispose();
            }    
        }
    }
}
