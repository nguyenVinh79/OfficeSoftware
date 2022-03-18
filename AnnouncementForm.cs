using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using LicenseContext = OfficeOpenXml.LicenseContext;
using OfficeOpenXml;
using OfficeSoftware.Model;

namespace OfficeSoftware
{
    public partial class AnnouncementForm : Form
    {
        protected int currentPerson;
        protected int personQuantity;
        protected int showTimeInterval = 5000;
        List<Announcement> announcementList = new List<Announcement>();

        public AnnouncementForm()
        {
            InitializeComponent();
        }

        private void Announcement_Load(object sender, EventArgs e)
        {
            FileInfo existingFile = new FileInfo(Directory.GetCurrentDirectory() + "\\" + "Lichtuan_autoUpdateFromWebData.xlsx");
            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                //get the first worksheet in the workbook
                ExcelWorksheet AnnSheet = package.Workbook.Worksheets[4];
                ExcelWorksheet timeSheet = package.Workbook.Worksheets[5];

                int colCount = AnnSheet.Dimension.End.Column;  //get Column Count
                int rowCount = AnnSheet.Dimension.End.Row;     //get row count

                showTimeInterval = Int32.Parse(timeSheet.Cells[2, 4].Value.ToString().Trim())*1000;

                if (rowCount > 1)
                {
                    for (int row = 2; row <= rowCount; row++)
                    {
                        announcementList.Add(new Announcement
                        {
                            Type = AnnSheet.Cells[row, 1].Value.ToString().Trim(),
                            Name = AnnSheet.Cells[row, 2].Value.ToString().Trim(),
                            Department = AnnSheet.Cells[row, 3].Value.ToString().Trim()
                        });
                    }

                    currentPerson = 0;
                    personQuantity = announcementList.Count;

                    showTimeInterval = showTimeInterval/personQuantity;

                    NameText.Text = announcementList[0].Name;
                    DepartmentText.Text = announcementList[0].Department;

                    if (announcementList[0].Type.Trim() == "Phỏng vấn")
                    {
                        TypeText.Text = "ĐẾN THAM GIA PHỎNG VẤN TẠI TRUNG TÂM/BAN";
                    }
                    if (announcementList[0].Type.Trim() == "Thử việc")
                    {
                        TypeText.Text = "ĐẾN THỬ VIỆC TẠI TRUNG TÂM/BAN";
                    }
                    if (announcementList[0].Type.Trim() == "Gia nhập")
                    {
                        TypeText.Text = "ĐÃ GIA NHẬP CÔNG TY, VÀ CHÍNH THỨC CÔNG TÁC TẠI TRUNG TÂM/BAN";
                    }

                    package.Dispose();

                    showTimer.Interval = showTimeInterval;
                    showTimer.Enabled = true;
                }
            }
        }

        private void showTimer_Tick(object sender, EventArgs e)
        {
            showTimer.Enabled = false;

            currentPerson++;

            if(currentPerson == personQuantity)
            {
                currentPerson = 0;
            }

            NameText.Text = announcementList[currentPerson].Name;
            DepartmentText.Text = announcementList[currentPerson].Department;

            if (announcementList[currentPerson].Type.Trim() == "Phỏng vấn")
            {
                TypeText.Text = "ĐẾN THAM GIA PHỎNG VẤN TẠI TRUNG TÂM/BAN";
            }
            if (announcementList[currentPerson].Type.Trim() == "Thử việc")
            {
                TypeText.Text = "ĐẾN THỬ VIỆC TẠI TRUNG TÂM/BAN";
            }
            if (announcementList[currentPerson].Type.Trim() == "Gia nhập")
            {
                TypeText.Text = "ĐÃ GIA NHẬP CÔNG TY, VÀ CHÍNH THỨC CÔNG TÁC TẠI TRUNG TÂM/BAN";
            }

            showTimer.Interval = showTimeInterval;
            showTimer.Enabled = true;
        }
    }
}
