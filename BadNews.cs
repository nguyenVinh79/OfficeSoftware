﻿using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace OfficeSoftware
{
    public partial class BadNews : Form
    {
        public BadNews()
        {
            InitializeComponent();
        }

        private void BadNews_Load(object sender, EventArgs e)
        {
            FileInfo existingFile = new FileInfo(Directory.GetCurrentDirectory() + "\\" + "Lichtuan_autoUpdateFromWebData.xlsx");
            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                //get the first worksheet in the workbook
                ExcelWorksheet BadnewsSheet = package.Workbook.Worksheets[3];
                int rowCount = BadnewsSheet.Dimension.End.Row;     //get row count

                NameText.Text = BadnewsSheet.Cells[1, 1].Value.ToString().Trim();
                YearText.Text = BadnewsSheet.Cells[1, 2].Value.ToString().Trim();
                RelateText.Text = BadnewsSheet.Cells[1, 3].Value.ToString().Trim();
                MatTimeText.Text = BadnewsSheet.Cells[1, 4].Value.ToString().Trim();
                ViengTimeText.Text = BadnewsSheet.Cells[1, 5].Value.ToString().Trim();
                DiTimeText.Text = BadnewsSheet.Cells[1, 6].Value.ToString().Trim();
                PositionText.Text = BadnewsSheet.Cells[1, 7].Value.ToString().Trim();
                PositionText.Visible = true;
                var ImageShowCheck = BadnewsSheet.Cells[1, 8].Value.ToString().Trim().ToLower();

                if (string.IsNullOrEmpty(PositionText.Text))
                {
                    PositionText.Visible = false;
                    label5.Location = new System.Drawing.Point(43, 348 - 46);
                    RelateText.Location = new System.Drawing.Point(92, 348 - 46);
                    MatTimeText.Location = new System.Drawing.Point(43, 446 - 46);
                    label7.Location = new System.Drawing.Point(49, 538 - 46);
                    ViengTimeText.Location = new System.Drawing.Point(109, 526 - 46);
                    label9.Location = new System.Drawing.Point(49, 669 - 46);
                    DiTimeText.Location = new System.Drawing.Point(109, 652 - 46);
                }   
                else
                {
                    label5.Location = new System.Drawing.Point(43, 348);
                    RelateText.Location = new System.Drawing.Point(92, 348);
                    MatTimeText.Location = new System.Drawing.Point(43, 446);
                    label7.Location = new System.Drawing.Point(49, 538);
                    ViengTimeText.Location = new System.Drawing.Point(109, 526);
                    label9.Location = new System.Drawing.Point(49, 669);
                    DiTimeText.Location = new System.Drawing.Point(109, 652);
                }    

                if(ImageShowCheck =="true")
                {
                    ImageBox.BringToFront();
                    var currentImagePath = Directory.GetCurrentDirectory() + "\\BadNewsImage\\";
                    string[] currentImages = Directory.GetFiles(currentImagePath);

                    if (currentImages.Length >= 1)
                    {
                        Image tempImage = Image.FromFile(currentImages[0]);
                        ImageBox.Image = tempImage;
                    }
                }
                else
                {
                    ImageBox.Visible = false;
                }    
                
                package.Dispose();
            }
        
        }

        private void BadNews_Paint(object sender, PaintEventArgs e)
        {
            Graphics gp = e.Graphics;
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0),4);
            gp.DrawLine(pen, 0, 150, 150, 0);
            gp.DrawLine(pen, 0, 0, this.Width, 0);
            gp.DrawLine(pen, this.Width, 0, this.Width, this.Height);
            gp.Dispose();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
