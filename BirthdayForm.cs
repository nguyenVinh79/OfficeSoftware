using OfficeOpenXml;
using OfficeSoftware.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;
using System.Windows.Forms;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace OfficeSoftware
{
    public partial class BirthdayForm : Form
    {
        protected int imageIndex = 0;
        protected int imageCount = 0;
        protected string[] fileEntries;
        List<BirthdayEntity> birthdayList = new List<BirthdayEntity>();
        List<BirthdayEntity> birthdayShowList = new List<BirthdayEntity>();
        protected int EntityCount = 0;
        protected int currentEntity = 0;
        protected int timeSwitchInterval=0;
        public BirthdayForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void BirthdayForm_Load(object sender, EventArgs e)
        {

            //FileInfo existingFile = new FileInfo(@"D:\Pecc4\Lichtuan_autoUpdateFromWebData.xlsx");
            
            FileInfo existingFile = new FileInfo(Directory.GetCurrentDirectory()+"\\"+"Lichtuan_autoUpdateFromWebData.xlsx");
            List<RemindDate> RemindDateList = new List<RemindDate>();

            dayNow.Text = DateTime.Now.Day.ToString();
            monthNow.Text = DateTime.Now.Month.ToString();
            yearNow.Text = DateTime.Now.Year.ToString();
            ImageSlider.Visible = false;

            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                //get the first worksheet in the workbook
                ExcelWorksheet BirthdaySheet = package.Workbook.Worksheets[2];
                ExcelWorksheet settingSheet = package.Workbook.Worksheets[5];
                ExcelWorksheet RemindSheet = package.Workbook.Worksheets[6];

                int colCount = BirthdaySheet.Dimension.End.Column;  //get Column Count
                int rowCount = BirthdaySheet.Dimension.End.Row;     //get row count

                int remindRowCount = RemindSheet.Dimension.End.Row;
                bool imageSlideEnable = false ;

                timeSwitchInterval = Int32.Parse(settingSheet.Cells[2, 2].Value.ToString().Trim()) * 1000 ;

                if (settingSheet.Cells[2, 7].Value.ToString().Trim() == "true")
                {
                    imageSlideEnable = true;
                }
                else
                    imageSlideEnable = false;
  
                for (int row =2; row <= remindRowCount; row++)
                {
                    RemindDateList.Add(new RemindDate
                    {
                        Day = Int32.Parse(RemindSheet.Cells[row, 1].Value.ToString().Trim()),
                        Month = Int32.Parse(RemindSheet.Cells[row, 2].Value.ToString().Trim())
                    });
                }    

                for (int row = 1; row <= rowCount; row++)
                {
                    birthdayList.Add(new BirthdayEntity{
                    Name = BirthdaySheet.Cells[row, 1].Value.ToString().Trim(),
                    Date = BirthdaySheet.Cells[row, 2].Value.ToString().Trim(),
                    Department= BirthdaySheet.Cells[row, 4].Value == null ? string.Empty : BirthdaySheet.Cells[row, 4].Value.ToString().Trim(),
                    Position = BirthdaySheet.Cells[row, 3].Value == null ? string.Empty : BirthdaySheet.Cells[row, 3].Value.ToString().Trim()
                    });
                }


                foreach(var item in birthdayList)
                {
                    var itemBirthdayDay = Convert.ToDateTime(item.Date).Day;
                    var itemBirthdayMonth = Convert.ToDateTime(item.Date).Month;

                    #region birthday in weekend 

                    if ((int)DateTime.Now.DayOfWeek == 1)
                    {
                        var sunday = DateTime.Now.AddDays(-1).Date;
                        var saturday = DateTime.Now.AddDays(-1).Date;

                        if ((itemBirthdayDay == saturday.Day) && (itemBirthdayMonth == saturday.Month))
                        {
                            birthdayShowList.Add(new BirthdayEntity
                            {
                                Name = item.Name,
                                Date = item.Date,
                                Department = item.Department,
                                Position = item.Position
                            });
                        }

                        if ((itemBirthdayDay == sunday.Day) && (itemBirthdayMonth == sunday.Month))
                        {
                            birthdayShowList.Add(new BirthdayEntity
                            {
                                Name = item.Name,
                                Date = item.Date,
                                Department = item.Department,
                                Position = item.Position
                            });
                        }
                    }
                    #endregion

                    #region Birthday in vacation
                    if((int)DateTime.Now.DayOfWeek >= 1 && (int)DateTime.Now.DayOfWeek < 6)
                    {
                        for(int i=7; i>0 ; i--)
                        {
                            var RemindDayCheck = DateTime.Now.AddDays(-i).Day;
                            var RemindMonthCheck = DateTime.Now.AddDays(-i).Month;
                            foreach(var itemRemindDate in RemindDateList)
                            {
                                if ((itemRemindDate.Day == RemindDayCheck) && (itemRemindDate.Month == RemindMonthCheck))
                                {
                                    if ((itemBirthdayDay == RemindDayCheck) && (itemBirthdayMonth == RemindMonthCheck))
                                    {
                                        birthdayShowList.Add(new BirthdayEntity
                                        {
                                            Name = item.Name,
                                            Date = item.Date,
                                            Department = item.Department,
                                            Position = item.Position
                                        });
                                    }
                                }
                            }
                        }    
                    }    

                    #endregion

                    if ((itemBirthdayDay == DateTime.Now.Day) && (itemBirthdayMonth == DateTime.Now.Month))
                    {
                        birthdayShowList.Add(new BirthdayEntity { 
                            Name = item.Name,
                            Date = item.Date,
                            Department = item.Department,
                            Position = item.Position
                        });
                    }

                }

                if (birthdayShowList.Count>0)
                {
                    NameLabel.Text = birthdayShowList[0].Name;
                    DepartmentLable.Text = birthdayShowList[0].Department;
                    PositionLabel.Text = birthdayShowList[0].Position;
                }
                package.Dispose();
            }
            #region Configure image slider

            var directory = Directory.GetCurrentDirectory();
            var ImagePath = Directory.GetCurrentDirectory() + "\\ImageSlider\\";

            fileEntries = Directory.GetFiles(ImagePath);
            if (fileEntries.Length > 0)
            {
                ImageSlider.ImageLocation = fileEntries[0];
                imageCount = fileEntries.Length;

                

                #region Configure image slider timer

                slideTimer.Enabled = false;
                //slideTimer.Start();
                #endregion
            }
            #endregion

            ImgSlideEnTimer.Interval = timeSwitchInterval;
            ImgSlideEnTimer.Enabled = false;

            if (birthdayShowList.Count > 1)
            {
                
                EntityCount = birthdayShowList.Count;
                timeSwitchInterval = timeSwitchInterval/EntityCount;
                currentEntity = 0;
                switchEntityTimer.Interval = timeSwitchInterval;
                switchEntityTimer.Enabled = true;
            }

            #region Configure component location
            if (!String.IsNullOrEmpty(DepartmentLable.Text.Trim()))
            {
                label1.Location = new System.Drawing.Point(((this.Parent.Width) / 2 - 300 - label1.Width) / 2, this.Parent.Height / 8);
                NameLabel.Location = new System.Drawing.Point(((this.Parent.Width) / 2 - 300 - NameLabel.Width) / 2, this.Parent.Height / 4);
                PositionLabel.Location = new System.Drawing.Point(((this.Parent.Width) / 2 - 300 - PositionLabel.Width) / 2, this.Parent.Height / 3 + 20);
                DepartmentLable.Location = new System.Drawing.Point(((this.Parent.Width) / 2 - 300 - DepartmentLable.Width) / 2, this.Parent.Height / 2 - this.Parent.Height / 16 + 40);
                label2.Location = new System.Drawing.Point(0, this.Parent.Height / 2 + this.Parent.Height/16 + 50);
                dayNow.Location = new System.Drawing.Point(label2.Width, this.Parent.Height / 2 + this.Parent.Height / 16 + 50);
                label3.Location = new System.Drawing.Point(label2.Width + dayNow.Width, this.Parent.Height / 2 + this.Parent.Height / 16 + 50);
                monthNow.Location = new System.Drawing.Point(label3.Location.X + label3.Width, this.Parent.Height / 2 + this.Parent.Height / 16 + 50);
                label4.Location = new System.Drawing.Point(monthNow.Location.X + monthNow.Width, this.Parent.Height / 2 + this.Parent.Height / 16 + 50);
                yearNow.Location = new System.Drawing.Point(label4.Location.X + label4.Width, this.Parent.Height / 2 + this.Parent.Height / 16 + 50);
            }
            else 
            {
                label1.Location = new System.Drawing.Point(((this.Parent.Width) / 2 - 300 - label1.Width) / 2, this.Parent.Height / 8);
                NameLabel.Location = new System.Drawing.Point(((this.Parent.Width) / 2 - 300 - NameLabel.Width) / 2, this.Parent.Height / 4 +30);
                PositionLabel.Location = new System.Drawing.Point(((this.Parent.Width) / 2 - 300 - PositionLabel.Width) / 2, this.Parent.Height / 3 + 50);
                DepartmentLable.Location = new System.Drawing.Point(((this.Parent.Width) / 2 - 300 - DepartmentLable.Width) / 2, this.Parent.Height / 2 - this.Parent.Height / 16 + 40);
                label2.Location = new System.Drawing.Point(0, this.Parent.Height / 2 - this.Parent.Height / 16 + 100);
                dayNow.Location = new System.Drawing.Point(label2.Width, this.Parent.Height / 2 - this.Parent.Height / 16 + 100);
                label3.Location = new System.Drawing.Point(label2.Width + dayNow.Width, this.Parent.Height / 2 - this.Parent.Height / 16 + 100);
                monthNow.Location = new System.Drawing.Point(label3.Location.X + label3.Width, this.Parent.Height / 2 - this.Parent.Height/16 + 100);
                label4.Location = new System.Drawing.Point(monthNow.Location.X + monthNow.Width, this.Parent.Height / 2 - this.Parent.Height/16 + 100);
                yearNow.Location = new System.Drawing.Point(label4.Location.X + label4.Width, this.Parent.Height / 2 - this.Parent.Height/16 + 100);
            }

            #endregion
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

        private void switchEntityTimer_Tick(object sender, EventArgs e)
        {
            switchEntityTimer.Enabled = false;
            currentEntity++;
            if(currentEntity >= EntityCount)
            {
                currentEntity = 0;
            }

            NameLabel.Text = birthdayShowList[currentEntity].Name;
            DepartmentLable.Text = birthdayShowList[currentEntity].Department;

            #region Configure component location
            if (!String.IsNullOrEmpty(DepartmentLable.Text.Trim()))
            {
                label1.Location = new System.Drawing.Point(((this.Parent.Width) / 2 - 300 - label1.Width) / 2, this.Parent.Height / 8);
                NameLabel.Location = new System.Drawing.Point(((this.Parent.Width) / 2 - 300 - NameLabel.Width) / 2, this.Parent.Height / 4);
                PositionLabel.Location = new System.Drawing.Point(((this.Parent.Width) / 2 - 300 - PositionLabel.Width) / 2, this.Parent.Height / 3 + 20);
                DepartmentLable.Location = new System.Drawing.Point(((this.Parent.Width) / 2 - 300 - DepartmentLable.Width) / 2, this.Parent.Height / 2 - this.Parent.Height / 16 + 40);
                label2.Location = new System.Drawing.Point(0, this.Parent.Height/2 + this.Parent.Height/16 + 50);
                dayNow.Location = new System.Drawing.Point(label2.Width, this.Parent.Height / 2 + this.Parent.Height / 16 + 50);
                label3.Location = new System.Drawing.Point(label2.Width + dayNow.Width, this.Parent.Height / 2 + this.Parent.Height / 16 + 50);
                monthNow.Location = new System.Drawing.Point(label3.Location.X + label3.Width, this.Parent.Height / 2 + this.Parent.Height / 16 + 50);
                label4.Location = new System.Drawing.Point(monthNow.Location.X + monthNow.Width, this.Parent.Height / 2 + this.Parent.Height / 16 + 50);
                yearNow.Location = new System.Drawing.Point(label4.Location.X + label4.Width, this.Parent.Height / 2 + this.Parent.Height / 16 + 50);
            }
            else
            {
                label1.Location = new System.Drawing.Point(((this.Parent.Width) / 2 - 300 - label1.Width) / 2, this.Parent.Height / 8);
                NameLabel.Location = new System.Drawing.Point(((this.Parent.Width) / 2 - 300 - NameLabel.Width) / 2, this.Parent.Height / 4 + 30);
                PositionLabel.Location = new System.Drawing.Point(((this.Parent.Width) / 2 - 300 - PositionLabel.Width) / 2, this.Parent.Height / 3 + 50);
                DepartmentLable.Location = new System.Drawing.Point(((this.Parent.Width) / 2 - 300 - DepartmentLable.Width) / 2, this.Parent.Height / 2 - this.Parent.Height / 16 + 50);
                label2.Location = new System.Drawing.Point(0, this.Parent.Height / 2 - this.Parent.Height / 16 + 100);
                dayNow.Location = new System.Drawing.Point(label2.Width, this.Parent.Height / 2 - this.Parent.Height / 16 + 100);
                label3.Location = new System.Drawing.Point(label2.Width + dayNow.Width, this.Parent.Height / 2 - this.Parent.Height / 16 + 100);
                monthNow.Location = new System.Drawing.Point(label3.Location.X + label3.Width, this.Parent.Height / 2 - this.Parent.Height / 16 + 100);
                label4.Location = new System.Drawing.Point(monthNow.Location.X + monthNow.Width, this.Parent.Height / 2 - this.Parent.Height / 16 + 100);
                yearNow.Location = new System.Drawing.Point(label4.Location.X + label4.Width, this.Parent.Height / 2 - this.Parent.Height / 16 + 100);
            }

            #endregion

            switchEntityTimer.Interval = timeSwitchInterval;
            switchEntityTimer.Enabled = true;

        }

        private void ImgSlideEnTimer_Tick(object sender, EventArgs e)
        {
            ImgSlideEnTimer.Enabled = false;
            ImageSlider.Visible = true;
        }
    }
}
