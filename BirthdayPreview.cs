using OfficeOpenXml;
using OfficeSoftware.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace OfficeSoftware
{
    public partial class BirthdayPreview : Form
    {
        protected int imageIndex = 0;
        protected int imageCount = 0;
        protected string[] fileEntries;
        List<BirthdayEntity> birthdayList = new List<BirthdayEntity>();
        List<BirthdayEntity> birthdayShowList = new List<BirthdayEntity>();
        protected int EntityCount = 0;
        protected int currentEntity = 0;
        protected int timeSwitchInterval = 0;
        public BirthdayPreview()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void BirthdayForm_Load(object sender, EventArgs e)
        {
            CultureInfo ci = CultureInfo.CurrentCulture;
            DateTimeFormatInfo datetimeformatInfo = ci.DateTimeFormat;

            dayNow.Text = DateTime.Now.Day.ToString();
            monthNow.Text = DateTime.Now.Month.ToString();
            yearNow.Text = DateTime.Now.Year.ToString();

            label1.Location = new System.Drawing.Point(((this.Parent.Width) / 2 - 300 - label1.Width) / 2, this.Parent.Height / 8);
            NameLabel.Location = new System.Drawing.Point(((this.Parent.Width) / 2 - 300 - NameLabel.Width) / 2, this.Parent.Height / 4);
            PositionLabel.Location = new System.Drawing.Point(((this.Parent.Width) / 2 - 300 - PositionLabel.Width) / 2, this.Parent.Height / 3 + 20);
            DepartmentLable.Location = new System.Drawing.Point(((this.Parent.Width) / 2 - 300 - DepartmentLable.Width) / 2, this.Parent.Height / 2 - this.Parent.Height / 16 + 40);
            label2.Location = new System.Drawing.Point(0, this.Parent.Height / 2 + this.Parent.Height / 16 + 50);
            dayNow.Location = new System.Drawing.Point(label2.Width, this.Parent.Height / 2 + this.Parent.Height / 16 + 50);
            label3.Location = new System.Drawing.Point(label2.Width + dayNow.Width, this.Parent.Height / 2 + this.Parent.Height / 16 + 50);
            monthNow.Location = new System.Drawing.Point(label3.Location.X + label3.Width, this.Parent.Height / 2 + this.Parent.Height / 16 + 50);
            label4.Location = new System.Drawing.Point(monthNow.Location.X + monthNow.Width, this.Parent.Height / 2 + this.Parent.Height / 16 + 50);
            yearNow.Location = new System.Drawing.Point(label4.Location.X + label4.Width, this.Parent.Height / 2 + this.Parent.Height / 16 + 50);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CloseFormTimer_Tick(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void slideTimer_Tick(object sender, EventArgs e)
        {
            slideTimer.Stop();

            if ((imageCount - 1) == imageIndex)
            {
                imageIndex = 0;
            }
            else
                imageIndex++;

            ImageSlider.ImageLocation = fileEntries[imageIndex];
            slideTimer.Start();
        }



        private void ImgSlideEnTimer_Tick(object sender, EventArgs e)
        {
            ImgSlideEnTimer.Enabled = false;
            ImageSlider.Visible = true;
        }
    }
}
