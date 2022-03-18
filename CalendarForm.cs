using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using LicenseContext = OfficeOpenXml.LicenseContext;
using HtmlAgilityPack;
using System.Linq;
using System.Net;
using OfficeSoftware.Model;

namespace OfficeSoftware
{
    public partial class CalendarForm : Form
    {
        int DTGVRow;
        int ScrollOffset = 0;
        string birthdayString;
        int DTGVShowTurn = 0;
        protected List<List<string>> DataRaw;
        public CalendarForm()
        {
            InitializeComponent();
        }

        private async void CalendarForm_Load(object sender, EventArgs e)
        {
            #region configure dataGridView
            this.CalendarDTGV.DefaultCellStyle.Font = new Font("Tahoma", 15);
            this.CalendarDTGV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.CalendarDTGV.DefaultCellStyle.Padding = new Padding(6);
            this.CalendarDTGV.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 11);
            this.CalendarDTGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //var CalendarLabelLocation = (this.Parent.Width) / 2;
            //label1.Location = new System.Drawing.Point(960, 10);
            #endregion

            try
            {
                #region get web data
                var html = new HtmlWeb();
                var doc = html.Load("http://10.67.0.6/lichtuan/");
                var birthdayMarquee = html.Load("http://10.67.0.4/pecc4/GUI/Pages/Article.aspx");
                //var doc = html.Load("http://113.160.248.233/lichtuan/")  http://10.67.0.6/lichtuan/;

                var birthdayHTML = birthdayMarquee.DocumentNode.SelectSingleNode("//marquee");
                var birthdayRaw = birthdayHTML.Descendants("font")
                            .Select(td => WebUtility.HtmlDecode(td.InnerText.Trim()))
                            .ToList();

                birthdayString = "Chúc Mừng Sinh Nhật:&nbsp&nbsp&nbsp";
                foreach (var item in birthdayRaw)
                {
                    var indexTemp = item.IndexOf(')');
                    var stringItem = item.Substring(indexTemp + 2);
                    birthdayString += stringItem;
                    birthdayString += "&nbsp&nbsp&nbsp&#127873;&nbsp&nbsp&nbsp";
                }

                var table = doc.DocumentNode.SelectSingleNode("//table[@id='RadGrid5_ctl00']");
                DataRaw = table.Descendants("tr")
                            .Skip(1)
                            .Select(tr => tr.Descendants("td")
                                            .Select(td => WebUtility.HtmlDecode(td.InnerText).Trim())
                                            .ToList())
                            .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng kiểm tra kết nối VPN trước khi chạy phần mềm","Lỗi khởi tạo", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

            var CalendarRawList = new List<Calendar>();
            string dayTemp = "";

            foreach (var item in DataRaw)
            {
                if (item.Count == 9)
                {
                    dayTemp = item[0];

                    CalendarRawList.Add(new Calendar
                    {
                        Date = item[0],
                        Time = item[1],
                        Room = item[2],
                        Content = item[3],
                        Prepare = item[4],
                        Host = item[5],
                        Participants = item[6]
                    });
                }
                if (item.Count == 8)
                {
                    CalendarRawList.Add(new Calendar
                    {
                        Date = dayTemp,
                        Time = item[0],
                        Room = item[1],
                        Content = item[2],
                        Prepare = item[3],
                        Host = item[4],
                        Participants = item[5]
                    });
                }
            }
            #endregion

            #region DTGV data
            FileInfo existingFile = new FileInfo(Directory.GetCurrentDirectory() + "\\" + "Lichtuan_autoUpdateFromWebData.xlsx");

            CalendarDTGV.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.CalendarDTGV.RowsDefaultCellStyle.BackColor = Color.FromArgb(228, 251, 255);
            //this.CalendarDTGV.AlternatingRowsDefaultCellStyle.BackColor = Color.Linen;
            CalendarDTGV.RowHeadersVisible = false;

            var dataTbl = new DataTable();
            DataTable DataTableShow = new DataTable();

            DataColumn dc = new DataColumn("Thứ /Ngày", typeof(String));
            dataTbl.Columns.Add(dc);

            dc = new DataColumn("T.Gian", typeof(String));
            dataTbl.Columns.Add(dc);

            dc = new DataColumn("Địa điểm", typeof(String));
            dataTbl.Columns.Add(dc);

            dc = new DataColumn("Nội dung", typeof(String));
            dataTbl.Columns.Add(dc);

            dc = new DataColumn("Chuẩn bị", typeof(String));
            dataTbl.Columns.Add(dc);

            dc = new DataColumn("Chủ trì", typeof(String));
            dataTbl.Columns.Add(dc);

            dc = new DataColumn("Thành phần", typeof(String));
            dataTbl.Columns.Add(dc);

            DataColumn dc1 = new DataColumn("Thứ /Ngày", typeof(String));
            DataTableShow.Columns.Add(dc1);

            dc1 = new DataColumn("T.Gian", typeof(String));
            DataTableShow.Columns.Add(dc1);

            dc1 = new DataColumn("Địa điểm", typeof(String));
            DataTableShow.Columns.Add(dc1);

            dc1 = new DataColumn("Nội dung", typeof(String));
            DataTableShow.Columns.Add(dc1);

            dc1 = new DataColumn("Chuẩn bị", typeof(String));
            DataTableShow.Columns.Add(dc1);

            dc1 = new DataColumn("Chủ trì", typeof(String));
            DataTableShow.Columns.Add(dc1);

            dc1 = new DataColumn("Thành phần", typeof(String));
            DataTableShow.Columns.Add(dc1);
            #endregion

            foreach (var calendarItem in CalendarRawList)
            {

                DataRow dr = dataTbl.NewRow();
                dr[0] = calendarItem.Date;
                dr[1] = calendarItem.Time;
                dr[2] = calendarItem.Room;
                dr[3] = calendarItem.Content;
                dr[4] = calendarItem.Prepare;
                dr[5] = calendarItem.Host;
                dr[6] = calendarItem.Participants;
                dataTbl.Rows.Add(dr);
            }

            // all table
            var rows = dataTbl.AsEnumerable();
            //filter
            var date = DateTime.Now.DayOfWeek.ToString();

            if (date == "Tuesday")
            {
                rows = rows.Where(r => r.Field<string>("Thứ /Ngày").Contains("Thứ 3") || r.Field<string>("Thứ /Ngày").Contains("Thứ 4") ||
                r.Field<string>("Thứ /Ngày").Contains("Thứ 5") || r.Field<string>("Thứ /Ngày").Contains("Thứ 6") ||
                r.Field<string>("Thứ /Ngày").Contains("Thứ 7"));
                if (rows.Count() > 1)
                {
                    dataTbl = rows.CopyToDataTable();
                }
            }

            if (date == "Wednesday")
            {
                rows = rows.Where(r => r.Field<string>("Thứ /Ngày").Contains("Thứ 4") || r.Field<string>("Thứ /Ngày").Contains("Thứ 5") ||
                r.Field<string>("Thứ /Ngày").Contains("Thứ 6") || r.Field<string>("Thứ /Ngày").Contains("Thứ 7"));
                if (rows.Count() > 1)
                {
                    dataTbl = rows.CopyToDataTable();
                }
            }

            if (date == "Thursday")
            {
                rows = rows.Where(r => r.Field<string>("Thứ /Ngày").Contains("Thứ 5") || r.Field<string>("Thứ /Ngày").Contains("Thứ 6") ||
                r.Field<string>("Thứ /Ngày").Contains("Thứ 7"));
                if (rows.Count() > 1)
                {
                    dataTbl = rows.CopyToDataTable();
                }
            }

            if (date == "Friday")
            {
                rows = rows.Where(r => r.Field<string>("Thứ /Ngày").Contains("Thứ 6") || r.Field<string>("Thứ /Ngày").Contains("Thứ 7")
                );

                if (rows.Count() > 1)
                {
                    dataTbl = rows.CopyToDataTable();
                }

            }

            if (date == "Saturday")
            {
                rows = rows.Where(r => r.Field<string>("Thứ /Ngày").Contains("Thứ 7"));
                if (rows.Count() > 1)
                {
                    dataTbl = rows.CopyToDataTable();
                }
            }

            if (rows.Count() > 1)
            {
                dataTbl.AcceptChanges();
                DataTableShow = dataTbl;

                CalendarDTGV.DataSource = DataTableShow;
            }
            else
            {
                DataRow dr = DataTableShow.NewRow();

                dr[3] = "Không có lịch từ hôm nay đến hết tuần";
                DataTableShow.Rows.Add(dr);
                DataTableShow.AcceptChanges();
                CalendarDTGV.DataSource = DataTableShow;
            }

            #region DTGV table setup
            //dataTbl.AcceptChanges();
            //CalendarDTGV.DataSource = dataTbl;

            DataGridViewColumn calendarColumnDate = CalendarDTGV.Columns[0];
            DataGridViewColumn calendarColumnTime = CalendarDTGV.Columns[1];
            DataGridViewColumn calendarColumnRoom = CalendarDTGV.Columns[2];
            DataGridViewColumn calendarColumnContent = CalendarDTGV.Columns[3];
            DataGridViewColumn calendarColumnPrepare = CalendarDTGV.Columns[4];
            DataGridViewColumn calendarColumnHost = CalendarDTGV.Columns[5];
            DataGridViewColumn calendarColumnParticipant = CalendarDTGV.Columns[6];

            calendarColumnDate.Width = 55;
            calendarColumnTime.Width = 28;
            calendarColumnRoom.Width = 45;
            calendarColumnContent.Width = 235;
            calendarColumnPrepare.Width = 40;
            calendarColumnHost.Width = 48;
            calendarColumnParticipant.Width = 195;


            #endregion
            try { 
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

                #endregion
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi :" + ex.Message.ToString(),"Thông báo", MessageBoxButtons.OK);
            }
        }
        

        private void CalendarDTGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            CalendarDTGV.ClearSelection();
            DTGVRow = CalendarDTGV.Rows.Count;
            ScrollOffset = DTGVRow / 3;
            CalendarDTGV.FirstDisplayedScrollingRowIndex = 0;
            ScrollTimer.Enabled = true;
        }

        private void CalendarDTGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CalendarDTGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ScrollTimer_Tick(object sender, EventArgs e)
        {
            ScrollTimer.Enabled = false;
            DTGVShowTurn++;
            if (DTGVShowTurn == 3)
            {
                DTGVShowTurn = 0;
                CalendarDTGV.FirstDisplayedScrollingRowIndex = 0;
            }
            else
                CalendarDTGV.FirstDisplayedScrollingRowIndex += ScrollOffset;
            ScrollTimer.Enabled = true;
        }

       

        private void CalendarDTGV_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            }
            else
            {
                e.AdvancedBorderStyle.Top = CalendarDTGV.AdvancedCellBorderStyle.Top;
            }
        }

        private void CalendarDTGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }

        bool IsTheSameCellValue(int column, int row)
        {
            DataGridViewCell cell1 = CalendarDTGV[column, row];
            DataGridViewCell cell2 = CalendarDTGV[column, row - 1];
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();
        }

    }
}
