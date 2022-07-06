using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using LicenseContext = OfficeOpenXml.LicenseContext;
using System.Net.NetworkInformation;
using System.Drawing;
using System.Drawing.Drawing2D;
using OfficeSoftware.Model;
using System.Globalization;
using HtmlAgilityPack;
using System.Net;
using System.Data.SqlClient;

namespace OfficeSoftware
{
    public partial class Form1 : Form
    {
        string birthdayString;
        private Form currentChildForm;
        WebBrowser wb;
        public BirthdayForm bdform = new BirthdayForm();
        protected bool slideShowEnable = false;
        protected int currentForm;  // the form is openning
        protected int calendarTime;
        protected int birthdayTime;
        protected int badnewsTime;
        protected int eventTime;
        protected int imageTime;
        protected bool isBadnewsShow;
        protected bool isEventShow;
        protected bool isImageSlideShow;
        string connectString = @"server=TVD4SRVR04\SQLSERVER2K8R2;multipleactiveresultsets=true;database=Pecc4Web;user id=sa;password=abc@123";

        //@"Data Source=TVD4SRVR04\SQLSERVER2K8R2;multipleactiveresultsets=true;Initial Catalog=Pecc4Web;User ID=sa;Password=abc@123;Integrated Security=true";
        List<BirthdayEntity> EmployeeBirthdayList = new List<BirthdayEntity>();

        FileInfo existingFile = new FileInfo(Directory.GetCurrentDirectory() + "\\" + "Lichtuan_autoUpdateFromWebData.xlsx");

        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            var connection = new SqlConnection(connectString);
            var sql = "SELECT EmployeeName, Department, CONVERT(VARCHAR(10),dbo.Employee.BirthDay ,103) AS Birthday FROM dbo.Employee";

            SqlDataAdapter employeeData = new SqlDataAdapter(sql, connection);
            var dtEmployee = new DataTable();

            employeeData.Fill(dtEmployee);

            
            foreach(DataRow dataRow in dtEmployee.Rows)
            {
                EmployeeBirthdayList.Add(new BirthdayEntity {
                Name = $"{ dataRow["EmployeeName"]}",
                Department = $"{dataRow["Department"] }",
                Date = $"{dataRow["Birthday"]}"

                });
            }    

            AutoHideTimer.Enabled = true;
            ShowBtn.Text = "Dừng";
            ShowBtn.BackColor = Color.Red;
            slideShowEnable = true;

            CalendarButton.Enabled = false;
            birthdayButton.Enabled = false;
            badNewsButton.Enabled = false;
            EventButton.Enabled = false;
            ImageSlideButton.Enabled = false;
            ImageSettingButton.Enabled = false;

            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                //get the first worksheet in the workbook
                ExcelWorksheet TimeSheet = package.Workbook.Worksheets[5];

                int rowCount = TimeSheet.Dimension.End.Row;
                calendarTime = Int32.Parse(TimeSheet.Cells[2, 1].Value.ToString().Trim());
                birthdayTime = Int32.Parse(TimeSheet.Cells[2, 2].Value.ToString().Trim());
                badnewsTime = Int32.Parse(TimeSheet.Cells[2, 3].Value.ToString().Trim());
                eventTime = Int32.Parse(TimeSheet.Cells[2, 4].Value.ToString().Trim());
                imageTime = Int32.Parse(TimeSheet.Cells[2, 8].Value.ToString().Trim());

                if (TimeSheet.Cells[2, 5].Value.ToString().Trim() == "true")
                    isBadnewsShow = true;
                else
                    isBadnewsShow = false;

                if (TimeSheet.Cells[2, 6].Value.ToString().Trim() == "true")
                    isEventShow = true;
                else
                    isEventShow = false;

                if (TimeSheet.Cells[2, 7].Value.ToString().Trim() == "true")
                    isImageSlideShow = true;
                else
                    isImageSlideShow = false;

                package.Dispose();
            }

            OpenChildForm(new CalendarForm());

            if (slideShowEnable)
            {
                currentForm = 1;
                SlideTimer.Interval = calendarTime * 1000;
                SlideTimer.Enabled = true;
            }

            var html = new HtmlWeb();
            //var birthdayMarquee = html.Load("http://10.67.0.4/pecc4/GUI/Pages/Article.aspx");
            //var birthdayHTML = birthdayMarquee.DocumentNode.SelectSingleNode("//marquee");
            //var birthdayRaw = birthdayHTML.Descendants("font")
            //            .Select(td => WebUtility.HtmlDecode(td.InnerText.Trim()))
            //            .ToList();

            //birthdayString = "CHÚC MỪNG SINH NHẬT:&nbsp&nbsp&nbsp&#127873&nbsp&nbsp&nbsp";
            //birthdayString += "Lê Dũng-ĐKS(1/3)&nbsp&nbsp&nbsp&#127873;&nbsp&nbsp&nbsp";
            //birthdayString += "Hoàng Quốc Khải-P3(1/3)&nbsp&nbsp&nbsp&#127873;&nbsp&nbsp&nbsp";
            //birthdayString += "Trần Trương Hân-P6(1/3)&nbsp&nbsp&nbsp&#127873;&nbsp&nbsp&nbsp";
            //birthdayString += "Trần Thanh Trường-VP(2/3)&nbsp&nbsp&nbsp&#127873;&nbsp&nbsp&nbsp";

            var BirthdayInMonthList = EmployeeBirthdayList.Where(x => (Convert.ToDateTime(x.Date).Month == DateTime.Now.Month) &&
                (Convert.ToDateTime(x.Date).Day >= DateTime.Now.Day)).ToList();

            foreach (var item in BirthdayInMonthList)
            {
                

                birthdayString += item.Name+"-"+item.Department + " ("+ item.Date.Substring(0,5) +")";
                birthdayString += "&nbsp&nbsp&nbsp&#127873;&nbsp&nbsp&nbsp";
            }

            try
            {
                #region Webview configurations
                //to top right, #ffff66 12%, #00ff99 99%
                var htmlRaw = @"<html> <head>
                <title>Basic Web Page</title>
                <style>
                body {
                height: 46px;
                overflow: hidden;
                background: linear-gradient(to top right, #ffffff 12%, #33ccff 76%)
                </style>
                </head> 
                <body>
                      <marquee width='100%' direction='left' height='200px' loop='' bgcolor='' style='padding-top: 10px;'>
                <font face = 'Verdana' size = '4'>" + birthdayString + "</font></marquee></body> </html>";

                await webView21.EnsureCoreWebView2Async();
                webView21.NavigateToString(htmlRaw);

                /* panel1.BringToFront();*/
                
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi :" + ex.Message.ToString(), "Thông báo", MessageBoxButtons.OK);
            }
            
        }

        private void BirthdayTimer_Tick(object sender, EventArgs e)
        {
            BirthdayTimer.Enabled = false;
            bdform.TopMost = true;
            bdform.Show();


            #region Dialog pop up
            /*
            BirthdayForm BirthdayPopUp = new BirthdayForm();
            BirthdayPopUp.ShowDialog();
            if (DialogResult.OK.Equals(1))
            {
                BDshowTimer.Interval = 5000;
                BDshowTimer.Enabled = true;
            }
            
            Form formBackground = new Form();
            using (BirthdayForm popupForm = new BirthdayForm())
            {
                formBackground.StartPosition = FormStartPosition.Manual;
                formBackground.FormBorderStyle = FormBorderStyle.None;
                formBackground.Opacity = .80d;
                formBackground.BackColor = Color.Black;
                formBackground.WindowState = FormWindowState.Maximized;
                formBackground.TopMost = true;
                formBackground.Location = this.Location;
                formBackground.ShowInTaskbar = false;
                formBackground.Show();

                popupForm.Owner = formBackground;
                popupForm.StartPosition = FormStartPosition.CenterScreen;
                popupForm.ShowDialog();

                formBackground.Dispose();     
            } 
            */
            #endregion
        }


        private void BDshowTimer_Tick(object sender, EventArgs e)
        {
            BDshowTimer.Enabled = false;
            /*
            OpenChildForm(new CalendarForm());
            BirthdayTimer.Interval = 5000;
            BirthdayTimer.Enabled = true;
            */
        }
        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }

            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            MainPanel.Controls.Add(childForm);
            MainPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            if (childForm.Name == "BadNews" || childForm.Name == "ImageGallery" || childForm.Name == "Setting")
            {

            }
            else
                panel1.BringToFront();
        }
        private void OpenAnnounceForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }

            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.None;
            childForm.Location = new System.Drawing.Point((MainPanel.Width - childForm.Width) / 2, (MainPanel.Height - childForm.Height) / 2);
            childForm.Anchor = AnchorStyles.None;

            MainPanel.Controls.Add(childForm);
            MainPanel.Tag = childForm;
            MainPanel.BackColor = Color.FromArgb(80, Color.Transparent);
            childForm.BringToFront();
            childForm.Show();
        }

        private void birthdayBtn_Click(object sender, EventArgs e)
        {
            //bdform = new BirthdayForm();
            //bdform.Show();
            //bdform.WindowState = FormWindowState.Maximized;
            OpenChildForm(new BirthdayForm());
        }

        private void SettingBtn_Click(object sender, EventArgs e)
        {
            if (slideShowEnable)
            {
                SlideTimer.Enabled = false;
                ShowBtn.Text = "Trình Chiếu";
                ShowBtn.BackColor = Color.Lime;
                slideShowEnable = false;

                CalendarButton.Enabled = true;
                birthdayButton.Enabled = true;
                badNewsButton.Enabled = true;
                EventButton.Enabled = true;
                ImageSlideButton.Enabled = true;
                ImageSettingButton.Enabled = true;
            }

            OpenChildForm(new Setting());
        }

        private void saveExcel_Tick(object sender, EventArgs e)
        {
            /*
            saveExcelTimer.Enabled = false;
            Workbook workBook = _excel.Workbooks.Open(@"D:\Pecc4\Lichtuan_autoUpdateFromWebTest.xlsx");
            workBook.RefreshAll();
            workBook.Save();
            BDshowTimer.Interval = 1000;
            BDshowTimer.Enabled = true;
            */

        }

        private void CalendarBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CalendarForm());
        }

        private void eventBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AnnouncementForm());
        }

        private void BadnewsBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BadNews());
        }

        private void SlideTimer_Tick(object sender, EventArgs e)
        {
            SlideTimer.Enabled = false;

            if (currentForm == 1)
            {
                var birthdayList = new List<BirthdayEntity>();
                var birthdayShowList = new List<BirthdayEntity>();

                using (ExcelPackage package = new ExcelPackage(existingFile))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    //get the first worksheet in the workbook
                    ExcelWorksheet BirthdaySheet = package.Workbook.Worksheets[2];
                    ExcelWorksheet AnnSheet = package.Workbook.Worksheets[4];

                    int rowEventCount = AnnSheet.Dimension.End.Row;
                    int colCount = BirthdaySheet.Dimension.End.Column;  //get Column Count
                    int rowCount = BirthdaySheet.Dimension.End.Row;     //get row count

                    for (int row = 1; row <= rowCount; row++)
                    {
                        birthdayList.Add(new BirthdayEntity
                        {
                            Name = BirthdaySheet.Cells[row, 1].Value.ToString().Trim(),
                            Date = BirthdaySheet.Cells[row, 2].Value.ToString().Trim(),
                            Department = BirthdaySheet.Cells[row, 4].Value == null ? string.Empty : BirthdaySheet.Cells[row, 4].Value.ToString().Trim(),
                            Position = BirthdaySheet.Cells[row, 3].Value == null ? string.Empty : BirthdaySheet.Cells[row, 3].Value.ToString().Trim()
                        });
                    }

                    foreach (var item in birthdayList)
                    {
                        int itemBirthdayDay;
                        int itemBirthdayMonth;

                        itemBirthdayDay = Convert.ToDateTime(item.Date).Day;
                        itemBirthdayMonth = Convert.ToDateTime(item.Date).Month;

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
                                    Department = item.Department
                                });
                            }

                            if ((itemBirthdayDay == sunday.Day) && (itemBirthdayMonth == sunday.Month))
                            {
                                birthdayShowList.Add(new BirthdayEntity
                                {
                                    Name = item.Name,
                                    Date = item.Date,
                                    Department = item.Department
                                });
                            }
                        }
                        #endregion

                        if ((itemBirthdayDay == DateTime.Now.Day) && (itemBirthdayMonth == DateTime.Now.Month))
                        {
                            birthdayShowList.Add(new BirthdayEntity
                            {
                                Name = item.Name,
                                Date = item.Date,
                                Department = item.Department
                            });
                        }

                    }

                    package.Dispose();

                    if (birthdayShowList.Count < 1)
                    {
                        if (isBadnewsShow)
                        {
                            currentForm = 3;
                            SlideTimer.Interval = badnewsTime * 1000;
                            OpenChildForm(new BadNews());
                            SlideTimer.Enabled = true;
                        }

                        if (isEventShow && !isBadnewsShow)
                        {
                            if (rowEventCount > 1)
                            {
                                currentForm = 4;
                                SlideTimer.Interval = eventTime * 1000;
                                OpenChildForm(new AnnouncementForm());
                                SlideTimer.Enabled = true;
                            }
                        }

                        if (!isBadnewsShow && !isEventShow && isImageSlideShow)
                        {
                            currentForm = 5; // image slide show stage
                            SlideTimer.Interval = imageTime * 1000;
                            OpenChildForm(new ImageSlide());
                            SlideTimer.Enabled = true;
                        }
                    }
                    else
                    {
                        currentForm = 2;
                        SlideTimer.Interval = birthdayTime * 1000;

                        //bdform = new BirthdayForm();
                        //bdform.Show();
                        //bdform.WindowState = FormWindowState.Maximized;
                        OpenChildForm(new BirthdayForm());

                        SlideTimer.Enabled = true;
                    }
                }

                if (currentForm == 1)
                {
                    SlideTimer.Interval = calendarTime * 1000;
                    OpenChildForm(new CalendarForm());
                    SlideTimer.Enabled = true;
                }

                return;
            }

            if (currentForm == 2)
            {
                if (isBadnewsShow)
                {
                    currentForm = 3;
                    SlideTimer.Interval = badnewsTime * 1000;
                    OpenChildForm(new BadNews());
                    SlideTimer.Enabled = true;
                }

                if (isEventShow)
                {
                    using (ExcelPackage package = new ExcelPackage(existingFile))
                    {
                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                        //get the first worksheet in the workbook
                        ExcelWorksheet AnnSheet = package.Workbook.Worksheets[4];

                        int rowEventCount = AnnSheet.Dimension.End.Row;

                        if (rowEventCount > 1)
                        {
                            currentForm = 4;
                            SlideTimer.Interval = eventTime * 1000;
                            OpenChildForm(new AnnouncementForm());
                            SlideTimer.Enabled = true;
                        }

                        package.Dispose();
                    }
                }
                if (!isBadnewsShow && !isEventShow)
                {
                    currentForm = 1;
                    SlideTimer.Interval = calendarTime * 1000;
                    OpenChildForm(new CalendarForm());
                    SlideTimer.Enabled = true;
                }

                return;
            }

            if (currentForm == 3)
            {
                if (isEventShow)
                {
                    using (ExcelPackage package = new ExcelPackage(existingFile))
                    {
                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                        //get the first worksheet in the workbook
                        ExcelWorksheet AnnSheet = package.Workbook.Worksheets[4];

                        int rowEventCount = AnnSheet.Dimension.End.Row;

                        if (rowEventCount > 1)
                        {
                            currentForm = 4;
                            SlideTimer.Interval = eventTime * 1000;
                            OpenChildForm(new AnnouncementForm());
                            SlideTimer.Enabled = true;
                        }

                        package.Dispose();
                    }
                }
                else
                {
                    currentForm = 1;
                    SlideTimer.Interval = calendarTime * 1000;
                    OpenChildForm(new CalendarForm());
                    SlideTimer.Enabled = true;
                }
                return;
            }

            if (currentForm == 4)
            {
                if (isImageSlideShow)
                {
                    var directory = Directory.GetCurrentDirectory();
                    var ImagePath = Directory.GetCurrentDirectory() + "\\ImageSlider\\";

                    string[] ImageFiles = Directory.GetFiles(ImagePath);
                    if (ImageFiles.Length > 0)
                    {
                        currentForm = 5;
                        SlideTimer.Interval = imageTime * 1000;
                        OpenChildForm(new AnnouncementForm());
                        SlideTimer.Enabled = true;
                    }

                }
                else
                {
                    currentForm = 1;
                    SlideTimer.Interval = calendarTime * 1000;
                    OpenChildForm(new CalendarForm());
                    SlideTimer.Enabled = true;
                }
            }

            if (currentForm == 5)
            {
                currentForm = 1;
                SlideTimer.Interval = calendarTime * 1000;
                OpenChildForm(new CalendarForm());
                SlideTimer.Enabled = true;
            }
        }

        private void ShowBtn_Click(object sender, EventArgs e)
        {
            if (slideShowEnable)
            {
                ShowBtn.Enabled = false;

                slideShowEnable = false;
                SlideTimer.Enabled = false;
                currentForm = 1;
                OpenChildForm(new CalendarForm());
                ShowBtn.Text = "Trình Chiếu";
                ShowBtn.BackColor = Color.Lime;

                CalendarButton.Enabled = true;
                birthdayButton.Enabled = true;
                badNewsButton.Enabled = true;
                EventButton.Enabled = true;
                ImageSlideButton.Enabled = true;
                ImageSettingButton.Enabled = true;

                ShowBtn.Enabled = true;
            }
            else
            {
                ShowBtn.Enabled = false;

                slideShowEnable = true;
                currentForm = 1;

                using (ExcelPackage package = new ExcelPackage(existingFile))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    //get the first worksheet in the workbook
                    ExcelWorksheet TimeSheet = package.Workbook.Worksheets[5];

                    int rowCount = TimeSheet.Dimension.End.Row;
                    calendarTime = Int32.Parse(TimeSheet.Cells[2, 1].Value.ToString().Trim());
                    birthdayTime = Int32.Parse(TimeSheet.Cells[2, 2].Value.ToString().Trim());
                    badnewsTime = Int32.Parse(TimeSheet.Cells[2, 3].Value.ToString().Trim());
                    eventTime = Int32.Parse(TimeSheet.Cells[2, 4].Value.ToString().Trim());
                    imageTime = Int32.Parse(TimeSheet.Cells[2, 8].Value.ToString().Trim());

                    if (TimeSheet.Cells[2, 5].Value.ToString().Trim() == "true")
                        isBadnewsShow = true;
                    else
                        isBadnewsShow = false;

                    if (TimeSheet.Cells[2, 6].Value.ToString().Trim() == "true")
                        isEventShow = true;
                    else
                        isEventShow = false;

                    if (TimeSheet.Cells[2, 7].Value.ToString().Trim() == "true")
                        isImageSlideShow = true;
                    else
                        isImageSlideShow = false;

                    package.Dispose();
                }

                OpenChildForm(new CalendarForm());
                SlideTimer.Interval = calendarTime * 1000;
                SlideTimer.Enabled = true;

                CalendarButton.Enabled = false;
                CalendarButton.Enabled = false;
                birthdayButton.Enabled = false;
                badNewsButton.Enabled = false;
                EventButton.Enabled = false;
                ImageSlideButton.Enabled = false;
                ImageSettingButton.Enabled = false;
                ShowBtn.Text = "Dừng";
                ShowBtn.BackColor = Color.Red;
                ShowBtn.Enabled = true;


            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void MainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Y < 10)
            {
                TaskbarPanel.Visible = true;
            }

            if (e.Y > 20)
            {
                TaskbarPanel.Visible = false;
            }
        }

        private void TaskbarPanel_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void AutoHideTimer_Tick(object sender, EventArgs e)
        {
            AutoHideTimer.Enabled = false;

            var p = this.PointToClient(MousePosition);
            if (this.ClientRectangle.Contains(p) && p.Y < 32)
                this.TaskbarPanel.Visible = true;
            else
                this.TaskbarPanel.Visible = false;

            AutoHideTimer.Enabled = true;
        }

        private void WindowCloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void WindowMaximizeBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void WindowMinimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void imageSetBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ImageGallery());
        }

        private void ImageSildeBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ImageSlide());
        }

        private void TaskbarPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Pen pen = new Pen(Color.FromArgb(0, 255, 153), 1);
            Rectangle area = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            LinearGradientBrush linearGradient = new LinearGradientBrush(area, Color.FromArgb(0, 255, 153), Color.FromArgb(255, 255, 51), LinearGradientMode.BackwardDiagonal);
            graphics.FillRectangle(linearGradient, area);
            graphics.DrawRectangle(pen, area);
        }

        private void CalendarButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CalendarForm());
        }

        private void birthdayButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BirthdayPreview());
        }

        private void badNewsButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BadNews());
        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void EventButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AnnouncementForm());
        }

        private void ImageSlideButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ImageSlide());
        }

        private void ImageSettingButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ImageGallery());
        }

        private void SettingButton_Click(object sender, EventArgs e)
        {
            if (slideShowEnable)
            {
                SlideTimer.Enabled = false;
                ShowBtn.Text = "Trình Chiếu";
                ShowBtn.BackColor = Color.Lime;
                slideShowEnable = false;

                CalendarButton.Enabled = true;
                birthdayButton.Enabled = true;
                badNewsButton.Enabled = true;
                EventButton.Enabled = true;
                ImageSlideButton.Enabled = true;
                ImageSettingButton.Enabled = true;
            }

            OpenChildForm(new Setting());

        }
    }
}
