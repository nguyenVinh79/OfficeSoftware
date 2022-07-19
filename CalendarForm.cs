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
using Newtonsoft.Json;
using System.Globalization;
using System.Threading.Tasks;

namespace OfficeSoftware
{
    public partial class CalendarForm : Form
    {
        int DTGVRow;
        int ScrollOffset = 0;
        string birthdayString;
        int DTGVShowTurn = 0;
        protected List<List<string>> DataRaw;
        List<MeetingCalendar> CalendarRawList = new List<MeetingCalendar>();
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

            await Task.Run(() => LoadingCalendarTable());
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

        private async Task LoadingCalendarTable()
        {
            try
            {
                #region get web data

                WebClient client = new WebClient();
                var userDataPara = new UserLoginDOffice()
                {
                    username = "pecc4\\vinhnn",
                    password = "pecc4evn",
                    expiration = 60,
                    deviceInfo = new DeviceInfoDoffice()
                    {
                        deviceId = "test",
                        deviceType = "crawlData",
                        appId = "DOFFICE",
                        appVersion = "v2.0.0"
                    }
                };
                string data = JsonConvert.SerializeObject(userDataPara);
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                string respond = client.UploadString("https://gwdoffice.pecc4.vn/v2/auth/Auth/DAuth", "POST", data);

                UserInfo userInfo = JsonConvert.DeserializeObject<UserInfo>(respond);

                client.Headers[HttpRequestHeader.Authorization] = "Bearer " + userInfo.Data.accessToken;
                client.Headers[HttpRequestHeader.ContentType] = "application/json";

                string currentDay = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssZ");
                string sevenDayafter = DateTime.Now.AddDays(7.0).ToString("yyyy-MM-ddTHH:mm:ssZ");

                CalendarRequest calendarRequest = new CalendarRequest()
                {
                    ID_DV = "404",
                    TU_NGAY = currentDay,
                    DEN_NGAY = sevenDayafter,
                    LOAI_LICH = "Lịch Ban",
                    TINH_TRANG = "DA_DUYET",
                    ID_PB_DK = 0,
                    ID_NV_DK = 0,
                    HNTH = 0,
                    MAY_CHIEU = 0,
                    CHU_TRI = "ALL",
                    ID_CHU_TRI = 0,
                    THANH_PHAN = "ALL",
                    ID_THANH_PHAN = 0,
                    CHUAN_BI = "ALL",
                    ID_CHUAN_BI = 0
                };

                CalendarRequest editedCalendarRequest = new CalendarRequest()
                {
                    ID_DV = "404",
                    TU_NGAY = currentDay,
                    DEN_NGAY = sevenDayafter,
                    LOAI_LICH = "Lịch Ban",
                    TINH_TRANG = "BO_SUNG",
                    ID_PB_DK = 0,
                    ID_NV_DK = 0,
                    HNTH = 0,
                    MAY_CHIEU = 0,
                    CHU_TRI = "ALL",
                    ID_CHU_TRI = 0,
                    THANH_PHAN = "ALL",
                    ID_THANH_PHAN = 0,
                    CHUAN_BI = "ALL",
                    ID_CHUAN_BI = 0
                };

                string editedCalendarRequestJson = JsonConvert.SerializeObject(editedCalendarRequest);
                string editedCalendarResultString = client.UploadString("https://gwdoffice.pecc4.vn/v1/lichtuan/LichTuan/SelectLichTuan", "POST", editedCalendarRequestJson);

                client.Headers[HttpRequestHeader.Authorization] = "Bearer " + userInfo.Data.accessToken;
                client.Headers[HttpRequestHeader.ContentType] = "application/json";

                string calendarRequestJson = JsonConvert.SerializeObject(calendarRequest);
                string CalendarResultString = client.UploadString("https://gwdoffice.pecc4.vn/v1/lichtuan/LichTuan/SelectLichTuan", "POST", calendarRequestJson);


                CalendarDetailInfo CalendarObj = JsonConvert.DeserializeObject<CalendarDetailInfo>(CalendarResultString);
                CalendarDetailInfo EditedCalendarObj = JsonConvert.DeserializeObject<CalendarDetailInfo>(editedCalendarResultString);

                if (EditedCalendarObj.Data != null)
                {
                    CalendarObj.Data.AddRange(EditedCalendarObj.Data);
                }

                List<ProcessedCalendarData> calendarProcessedData = new List<ProcessedCalendarData>();

                if (CalendarObj.Data != null)
                {
                    if (CalendarObj.Message == "200")
                    {
                        if (CalendarObj.Data.Count > 0)
                        {
                            foreach (var calendarRawItem in CalendarObj.Data)
                            {
                                if (calendarRawItem.TINH_TRANG == "DA_DUYET")
                                {
                                    calendarProcessedData.Add(new ProcessedCalendarData
                                    {
                                        NOI_DUNG = calendarRawItem.NOI_DUNG,
                                        THOI_GIAN_BD = DateTime.ParseExact(calendarRawItem.THOI_GIAN_BD, "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture).ToUniversalTime(),
                                        THOI_GIAN_KT = DateTime.ParseExact(calendarRawItem.THOI_GIAN_KT, "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture).ToUniversalTime(),
                                        NGAY_HOP = DateTime.ParseExact(calendarRawItem.NGAY_HOP, "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture).ToUniversalTime(),
                                        CHU_TRI = calendarRawItem.CHU_TRI,
                                        CHUAN_BI = calendarRawItem.CHUAN_BI,
                                        THANH_PHAN = calendarRawItem.THANH_PHAN,
                                        ID_PHONG_HOP = calendarRawItem.ID_PHONG_HOP,
                                        PHONG_HOP = calendarRawItem.PHONG_HOP
                                    });
                                }
                                else if (calendarRawItem.TINH_TRANG == "BO_SUNG")
                                {
                                    calendarProcessedData.Add(new ProcessedCalendarData
                                    {
                                        NOI_DUNG = calendarRawItem.NOI_DUNG,
                                        THOI_GIAN_BD = DateTime.ParseExact(calendarRawItem.THOI_GIAN_BD, "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture).ToUniversalTime(),
                                        THOI_GIAN_KT = DateTime.ParseExact(calendarRawItem.THOI_GIAN_KT, "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture).ToUniversalTime(),
                                        NGAY_HOP = DateTime.ParseExact(calendarRawItem.NGAY_HOP, "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture).ToUniversalTime(),
                                        CHU_TRI = calendarRawItem.CHU_TRI,
                                        CHUAN_BI = calendarRawItem.CHUAN_BI,
                                        THANH_PHAN = calendarRawItem.THANH_PHAN,
                                        ID_PHONG_HOP = calendarRawItem.ID_PHONG_HOP,
                                        PHONG_HOP = calendarRawItem.ID_PHONG_HOP.TEN_PHONG
                                    });
                                }
                            }

                            calendarProcessedData = calendarProcessedData.OrderBy(x => x.NGAY_HOP).ToList();

                            foreach (var calendarItem in calendarProcessedData)
                            {
                                DateTime startTime = calendarItem.THOI_GIAN_BD;
                                var meetingDay = ((DayDetail)((int)startTime.DayOfWeek)).GetEnumDescription();
                                meetingDay += $" ({startTime.Day}/{startTime.Month})";
                                string minuteMeeting = startTime.Minute < 10 ? "0" + startTime.Minute.ToString() : startTime.Minute.ToString();
                                string meetingTime = $"{startTime.Hour}h{minuteMeeting}";
                                string meetingPrepare = "";
                                string meetingHost = calendarItem.CHU_TRI;
                                string meetingParticipant = "";

                                //foreach (var prepareItem in calendarItem.CHUAN_BI)
                                //{
                                //    meetingPrepare += prepareItem.TEN + "\r\n";
                                //}

                                meetingPrepare = calendarItem.CHUAN_BI[0].TEN;

                                foreach (var participantItem in calendarItem.THANH_PHAN)
                                {
                                    meetingParticipant += participantItem.TEN + "\r\n";
                                }

                                CalendarRawList.Add(new MeetingCalendar
                                {
                                    Date = meetingDay,
                                    Time = meetingTime,
                                    Room = calendarItem.PHONG_HOP,
                                    Content = calendarItem.NOI_DUNG,
                                    Prepare = meetingPrepare,
                                    Host = meetingHost,
                                    Participants = meetingParticipant
                                });
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng kiểm tra kết nối VPN trước khi chạy phần mềm", "Lỗi khởi tạo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            #endregion

            #region DTGV data
            FileInfo existingFile = new FileInfo(Directory.GetCurrentDirectory() + "\\" + "Lichtuan_autoUpdateFromWebData.xlsx");

            CalendarDTGV.Invoke((MethodInvoker)(() => CalendarDTGV.DefaultCellStyle.WrapMode = DataGridViewTriState.True));
            CalendarDTGV.Invoke((MethodInvoker)(() => this.CalendarDTGV.RowsDefaultCellStyle.BackColor = Color.FromArgb(228, 251, 255)));
            CalendarDTGV.Invoke((MethodInvoker)(() => CalendarDTGV.RowHeadersVisible = false));
            //this.CalendarDTGV.AlternatingRowsDefaultCellStyle.BackColor = Color.Linen;


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
                if (rows.Count() >= 1)
                {
                    dataTbl = rows.CopyToDataTable();
                }
            }

            if (date == "Wednesday")
            {
                rows = rows.Where(r => r.Field<string>("Thứ /Ngày").Contains("Thứ 4") || r.Field<string>("Thứ /Ngày").Contains("Thứ 5") ||
                r.Field<string>("Thứ /Ngày").Contains("Thứ 6") || r.Field<string>("Thứ /Ngày").Contains("Thứ 7"));
                if (rows.Count() >= 1)
                {
                    dataTbl = rows.CopyToDataTable();
                }
            }

            if (date == "Thursday")
            {
                rows = rows.Where(r => r.Field<string>("Thứ /Ngày").Contains("Thứ 5") || r.Field<string>("Thứ /Ngày").Contains("Thứ 6") ||
                r.Field<string>("Thứ /Ngày").Contains("Thứ 7"));
                if (rows.Count() >= 1)
                {
                    dataTbl = rows.CopyToDataTable();
                }
            }

            if (date == "Friday")
            {
                rows = rows.Where(r => r.Field<string>("Thứ /Ngày").Contains("Thứ 6") || r.Field<string>("Thứ /Ngày").Contains("Thứ 7")
                );

                if (rows.Count() >= 1)
                {
                    dataTbl = rows.CopyToDataTable();
                }

            }

            if (date == "Saturday")
            {
                rows = rows.Where(r => r.Field<string>("Thứ /Ngày").Contains("Thứ 7"));
                if (rows.Count() >= 1)
                {
                    dataTbl = rows.CopyToDataTable();
                }
            }

            if (rows.Count() >= 1)
            {
                dataTbl.AcceptChanges();
                DataTableShow = dataTbl;
                CalendarDTGV.Invoke((MethodInvoker)(() => CalendarDTGV.DataSource = DataTableShow));
            }
            else
            {
                DataRow dr = DataTableShow.NewRow();

                dr[3] = "Không có lịch từ hôm nay đến hết tuần";
                DataTableShow.Rows.Add(dr);
                DataTableShow.AcceptChanges();
                CalendarDTGV.Invoke((MethodInvoker)(() => CalendarDTGV.DataSource = DataTableShow));
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


            CalendarDTGV.Invoke((MethodInvoker)(() => calendarColumnDate.Width = (int)(CalendarDTGV.Width * 0.06)));
            CalendarDTGV.Invoke((MethodInvoker)(() => calendarColumnTime.Width = (int)(CalendarDTGV.Width * 0.06)));
            CalendarDTGV.Invoke((MethodInvoker)(() => calendarColumnRoom.Width = (int)(CalendarDTGV.Width * 0.1)));
            CalendarDTGV.Invoke((MethodInvoker)(() => calendarColumnContent.Width = (int)(CalendarDTGV.Width * 0.26)));
            CalendarDTGV.Invoke((MethodInvoker)(() => calendarColumnPrepare.Width = (int)(CalendarDTGV.Width * 0.16)));
            CalendarDTGV.Invoke((MethodInvoker)(() => calendarColumnHost.Width = (int)(CalendarDTGV.Width * 0.16)));
            CalendarDTGV.Invoke((MethodInvoker)(() => calendarColumnParticipant.Width = (int)(CalendarDTGV.Width * 0.2)));


            #endregion
        }

    }
}
