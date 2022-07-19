using OfficeOpenXml;
using OfficeSoftware.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace OfficeSoftware
{
    public partial class Setting : Form
    {
        protected FileInfo excelImportedFile;
        //protected FileInfo sourceFile = new FileInfo(@"D:\Pecc4\Lichtuan_autoUpdateFromWebData.xlsx");
        protected FileInfo sourceFile = new FileInfo(Directory.GetCurrentDirectory() + "\\" + "Lichtuan_autoUpdateFromWebData.xlsx");
        protected int indexRow;
        public Setting()
        {
            InitializeComponent();
        }

        private void ImageImportBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "Chọn các hình cần trình chiếu";
            openDialog.Multiselect = true;
            openDialog.Filter = "jpg |*.jpg|jpeg |*.jpeg|png |*.png";

            var ImagePath = Directory.GetCurrentDirectory() + "\\ImageSlider\\";

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var item in openDialog.FileNames)
                {

                    string[] fileDir = item.Split("\\");
                    string fileName = fileDir[(fileDir.Length) - 1];


                    //fileName = $"{imageNum}"
                    var DetailImagePath = ImagePath + fileName;
                    File.Copy(item, DetailImagePath, true);
                }

                MessageBox.Show("Upload hình ảnh thành công", "Cập nhật hình ảnh trình chiếu");
            }

        }

        private void BirthdayImport_Click(object sender, EventArgs e)
        {
            try
            {
                CultureInfo ci = CultureInfo.CurrentCulture;
                DateTimeFormatInfo dtfi = ci.DateTimeFormat;
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Chọn file excel";
                openFileDialog.Multiselect = false;
                openFileDialog.Filter = "Excel Files(*.xlsx ; *.csv)|*.xlsx;*.csv";
                var employee = new List<BirthdayEntity>();

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    excelImportedFile = new FileInfo(openFileDialog.FileName);

                    using (ExcelPackage package = new ExcelPackage(excelImportedFile))
                    {

                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                        //get the first worksheet in the workbook

                        ExcelWorksheet BirthdaySheet = package.Workbook.Worksheets[0];

                        int colCount = BirthdaySheet.Dimension.End.Column;  //get Column Count
                        int rowCount = BirthdaySheet.Dimension.End.Row;     //get row count


                        for (int row = 5; row <= rowCount; row++)
                        {
                            //Console.WriteLine(" Row:" + row + " column:" + col + " Value:" + BirthdaySheet.Cells[row, col].Value?.ToString().Trim());
                            employee.Add(new BirthdayEntity
                            {
                                Name = BirthdaySheet.Cells[row, 2].Value?.ToString().Trim(),
                                Date = DateTime.FromOADate(Convert.ToUInt64(BirthdaySheet.Cells[row, 11].Value?.ToString().Trim())).ToString("dd/MM/yyyy"),
                                Position = BirthdaySheet.Cells[row, 8].Value?.ToString().Trim(),
                                Department = BirthdaySheet.Cells[row, 4].Value == null ? string.Empty : BirthdaySheet.Cells[row, 4].Value.ToString().Trim(),
                                Gender = BirthdaySheet.Cells[row, 31].Value == null ? string.Empty : BirthdaySheet.Cells[row, 31].Value.ToString().Trim()
                            });
                        }
                        package.Dispose();
                    }

                    var sourceFile = new FileInfo(Directory.GetCurrentDirectory() + "\\" + "Lichtuan_autoUpdateFromWebData.xlsx");
                    int excelRow = 1;

                    using (ExcelPackage package = new ExcelPackage(sourceFile))
                    {
                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                        //get the first worksheet in the workbook

                        ExcelWorksheet BirthdaySheet = package.Workbook.Worksheets[2];


                        foreach (var item in employee)
                        {
                            BirthdaySheet.Cells[excelRow, 2].Value = item.Date;
                            BirthdaySheet.Cells[excelRow, 3].Value = item.Position;
                            BirthdaySheet.Cells[excelRow, 4].Value = item.Department;
                            BirthdaySheet.Cells[excelRow, 5].Value = item.Gender;
                            excelRow++;
                        }

                        package.Save();
                        package.Dispose();
                    }

                    MessageBox.Show("Nhập dữ liệu thành công", "Cập nhật danh sách ngày sinh",MessageBoxButtons.OK ,MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Nhập dữ liệu bị gián đoạn, thông tin lỗi :"+ex.Message.ToString(), "Cập nhật danh sách ngày sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BadNewsSaveBtn_Click(object sender, EventArgs e)
        {
            var sourceFile = new FileInfo(Directory.GetCurrentDirectory() + "\\" + "Lichtuan_autoUpdateFromWebData.xlsx");
            int excelRow = 1;

            using (ExcelPackage package = new ExcelPackage(sourceFile))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                //get the first worksheet in the workbook

                ExcelWorksheet BadNewsSheet = package.Workbook.Worksheets[3];

                BadNewsSheet.Cells[excelRow, 1].Value = string.IsNullOrEmpty(BadName.Text) ? "" : BadName.Text;
                BadNewsSheet.Cells[excelRow, 2].Value = string.IsNullOrEmpty(BadYear.Text) ? "" : BadYear.Text;
                BadNewsSheet.Cells[excelRow, 3].Value = string.IsNullOrEmpty(BadPosition.Text) ? "" : BadPosition.Text;
                BadNewsSheet.Cells[excelRow, 4].Value = string.IsNullOrEmpty(BadTime.Text) ? "" : BadTime.Text;
                BadNewsSheet.Cells[excelRow, 5].Value = string.IsNullOrEmpty(BadVisit.Text) ? "" : BadVisit.Text;
                BadNewsSheet.Cells[excelRow, 6].Value = string.IsNullOrEmpty(BadBury.Text) ? "" : BadBury.Text;
                BadNewsSheet.Cells[excelRow, 7].Value = string.IsNullOrEmpty(PositionTb.Text) ? "" : PositionTb.Text;
                BadNewsSheet.Cells[excelRow, 8].Value = ImageBadNewsCheck.Checked == true ? "true" : "false";

                package.Save();
                package.Dispose();
            }
            MessageBox.Show("Lưu thông tin thành công", "Cập nhật thông báo tin buồn");
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            try
            {
                int excelRow = 1;

                using (ExcelPackage package = new ExcelPackage(sourceFile))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    //get the first worksheet in the workbook

                    ExcelWorksheet BadNewsSheet = package.Workbook.Worksheets[3];

                    BadName.Text = string.IsNullOrEmpty(BadNewsSheet.Cells[excelRow, 1].Value.ToString().Trim()) ? "" : BadNewsSheet.Cells[excelRow, 1].Value.ToString().Trim();
                    BadYear.Text = string.IsNullOrEmpty(BadNewsSheet.Cells[excelRow, 2].Value.ToString().Trim()) ? "" : BadNewsSheet.Cells[excelRow, 2].Value.ToString().Trim(); ;
                    BadPosition.Text = string.IsNullOrEmpty(BadNewsSheet.Cells[excelRow, 3].Value.ToString().Trim()) ? " " : BadNewsSheet.Cells[excelRow, 3].Value.ToString().Trim(); ;
                    BadTime.Text = string.IsNullOrEmpty(BadNewsSheet.Cells[excelRow, 4].Value.ToString().Trim()) ? " " : BadNewsSheet.Cells[excelRow, 4].Value.ToString().Trim(); ;
                    BadVisit.Text = string.IsNullOrEmpty(BadNewsSheet.Cells[excelRow, 5].Value.ToString().Trim()) ? " " : BadNewsSheet.Cells[excelRow, 5].Value.ToString().Trim(); ;
                    BadBury.Text = string.IsNullOrEmpty(BadNewsSheet.Cells[excelRow, 6].Value.ToString().Trim()) ? " " : BadNewsSheet.Cells[excelRow, 6].Value.ToString().Trim(); ;
                    PositionTb.Text = string.IsNullOrEmpty(BadNewsSheet.Cells[excelRow, 7].Value.ToString().Trim()) ? " " : BadNewsSheet.Cells[excelRow, 7].Value.ToString().Trim(); ;
                    var ImageShowCheck = string.IsNullOrEmpty(BadNewsSheet.Cells[excelRow, 8].Value.ToString().ToLower().Trim()) ? "false" : BadNewsSheet.Cells[excelRow, 8].Value.ToString().Trim().ToLower();

                    if (ImageShowCheck == "true")
                    {
                        ImageBadNewsCheck.Checked = true;
                    }
                    else
                        ImageBadNewsCheck.Checked = false;

                    package.Dispose();
                }

                //load badnews image
                var currentImagePath = Directory.GetCurrentDirectory() + "\\BadNewsImage\\";
                string[] currentImages = Directory.GetFiles(currentImagePath);

                if (currentImages.Length >= 1)
                {
                    Image tempImage = Image.FromFile(currentImages[0]);
                    badnewsPicBox.Image = tempImage;
                }

                eventDTGV.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                this.eventDTGV.RowsDefaultCellStyle.BackColor = Color.White;
                this.eventDTGV.AlternatingRowsDefaultCellStyle.BackColor = Color.Linen;
                eventDTGV.RowHeadersVisible = false;


                var dataTbl = new DataTable();
                DataColumn dc = new DataColumn("Loại thông báo", typeof(String));
                dataTbl.Columns.Add(dc);

                dc = new DataColumn("Họ Tên", typeof(String));
                dataTbl.Columns.Add(dc);

                dc = new DataColumn("Phòng ban", typeof(String));
                dataTbl.Columns.Add(dc);

                using (ExcelPackage package = new ExcelPackage(sourceFile))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    //get the first worksheet in the workbook
                    ExcelWorksheet EventSheet = package.Workbook.Worksheets[4];
                    ExcelWorksheet TimeSheet = package.Workbook.Worksheets[5];
                    ExcelWorksheet RemindSheet = package.Workbook.Worksheets[6];

                    int colCount = EventSheet.Dimension.End.Column;  //get Column Count
                    int rowCount = EventSheet.Dimension.End.Row;     //get row count

                    for (int row = 2; row <= rowCount; row++)
                    {

                        DataRow dr = dataTbl.NewRow();
                        dr[0] = EventSheet.Cells[row, 1].Value.ToString().Trim();
                        dr[1] = EventSheet.Cells[row, 2].Value.ToString().Trim();
                        dr[2] = EventSheet.Cells[row, 3].Value.ToString().Trim();
                        dataTbl.Rows.Add(dr);
                    }

                    int rowTimeCount = TimeSheet.Dimension.End.Row;

                    if (rowTimeCount > 1)
                    {
                        CalenderTimeTb.Text = TimeSheet.Cells[2, 1].Value.ToString().Trim();
                        BirthdayTimeTb.Text = TimeSheet.Cells[2, 2].Value.ToString().Trim();
                        BadnewsTimeTb.Text = TimeSheet.Cells[2, 3].Value.ToString().Trim();
                        EventTimeTb.Text = TimeSheet.Cells[2, 4].Value.ToString().Trim();
                        ImageSlideTb.Text = TimeSheet.Cells[2, 8].Value.ToString().Trim();

                        if (TimeSheet.Cells[2, 5].Value.ToString().Trim() == "true")
                            BadnewsCheckBox.Checked = true;
                        else
                            BadnewsCheckBox.Checked = false;

                        if (TimeSheet.Cells[2, 6].Value.ToString().Trim() == "true")
                            EventcheckBox.Checked = true;
                        else
                            EventcheckBox.Checked = false;

                        if (TimeSheet.Cells[2, 7].Value.ToString().Trim() == "true")
                            ImageSlideCheckBox.Checked = true;
                        else
                            ImageSlideCheckBox.Checked = false;

                    }


                    #region Remind Date loading
                    RemindDayDTGV.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    this.RemindDayDTGV.RowsDefaultCellStyle.BackColor = Color.White;
                    this.RemindDayDTGV.AlternatingRowsDefaultCellStyle.BackColor = Color.Linen;
                    RemindDayDTGV.RowHeadersVisible = false;

                    var RemindTbl = new DataTable();
                    DataColumn dcol = new DataColumn("Ngày", typeof(String));
                    RemindTbl.Columns.Add(dcol);

                    dcol = new DataColumn("Tháng", typeof(String));
                    RemindTbl.Columns.Add(dcol);


                    int rowRemindCount = RemindSheet.Dimension.End.Row;     //get row count

                    for (int row = 2; row <= rowRemindCount; row++)
                    {
                        DataRow dr = RemindTbl.NewRow();
                        dr[0] = RemindSheet.Cells[row, 1].Value.ToString().Trim();
                        dr[1] = RemindSheet.Cells[row, 2].Value.ToString().Trim();
                        RemindTbl.Rows.Add(dr);
                    }

                    #endregion

                    package.Dispose();
                    eventDTGV.DataSource = dataTbl;
                    RemindDayDTGV.DataSource = RemindTbl;

                    eventDTGV.ReadOnly = true;
                    DataGridViewColumn eventTypeColumn = eventDTGV.Columns[0];
                    DataGridViewColumn eventNameColumn = eventDTGV.Columns[1];
                    DataGridViewColumn eventDepartmentColumn = eventDTGV.Columns[2];
                    eventTypeColumn.Width = 200;
                    eventNameColumn.Width = 350;
                    eventDepartmentColumn.Width = 500;

                    RemindDayDTGV.ReadOnly = true;
                    DataGridViewColumn RemindDayColumn = RemindDayDTGV.Columns[0];
                    DataGridViewColumn RemindMonthColumn = RemindDayDTGV.Columns[1];
                    RemindDayColumn.Width = 120;
                    RemindMonthColumn.Width = 120;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void AddEBtn_Click(object sender, EventArgs e)
        {
            if (typeCbBox.SelectedItem.ToString()!= null && NameTextbox.Text != null && DepartTextbox.Text != null)
            {
                DataTable dataTable = (DataTable)eventDTGV.DataSource;
                var dataTbl = new DataTable();
                dataTable.Rows.Add(typeCbBox.SelectedItem.ToString(), NameTextbox.Text, DepartTextbox.Text);
                eventDTGV.DataSource = dataTable;
                /*
                DataColumn dc = new DataColumn("Loại thông báo", typeof(String));
                dataTbl.Columns.Add(dc);

                dc = new DataColumn("Họ Tên", typeof(String));
                dataTbl.Columns.Add(dc);

                dc = new DataColumn("Phòng ban", typeof(String));
                dataTbl.Columns.Add(dc);

                using (ExcelPackage package = new ExcelPackage(sourceFile))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    //get the first worksheet in the workbook
                    ExcelWorksheet EventSheet = package.Workbook.Worksheets[4];

                    int colCount = EventSheet.Dimension.End.Column;  //get Column Count
                    int rowCount = EventSheet.Dimension.End.Row;     //get row count

                    for (int row = 2; row <= rowCount; row++)
                    {

                        DataRow dr = dataTbl.NewRow();
                        dr[0] = EventSheet.Cells[row, 1].Value.ToString().Trim();
                        dr[1] = EventSheet.Cells[row, 2].Value.ToString().Trim();
                        dr[2] = EventSheet.Cells[row, 3].Value.ToString().Trim();
                        dataTbl.Rows.Add(dr);
                    }

                    DataRow drow = dataTbl.NewRow();
                    drow[0] = typeCbBox.SelectedItem.ToString();
                    drow[1] = NameTextbox.Text;
                    drow[2] = DepartTextbox.Text;
                }
                */
            }
            else
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //eventDTGV.Rows.Add(typeCbBox.SelectedItem.ToString(), NameTextbox.Text, DepartTextbox.Text);

        }

        private void SaveEBtn_Click(object sender, EventArgs e)
        {
            DataTable dataTable = (DataTable)eventDTGV.DataSource;
            if (dataTable.Rows.Count > 0)
            {
                using (ExcelPackage package = new ExcelPackage(sourceFile))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                    ExcelWorksheet EventSheet = package.Workbook.Worksheets[4];
                    int rowCount = EventSheet.Dimension.End.Row;
                    EventSheet.DeleteRow(2, rowCount);

                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        DataRow dr = dataTable.Rows[i];
                        // do something with dr

                        EventSheet.Cells[i + 2, 1].Value = dr[0];
                        EventSheet.Cells[i + 2, 2].Value = dr[1];
                        EventSheet.Cells[i + 2, 3].Value = dr[2];

                    }

                    package.Save();
                    package.Dispose();
                }

                MessageBox.Show("Thao tác thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void EditEBtn_Click(object sender, EventArgs e)
        {
            DataGridViewRow currentRowData = eventDTGV.Rows[indexRow];
            currentRowData.Cells[0].Value = typeCbBox.SelectedItem.ToString();
            currentRowData.Cells[1].Value = NameTextbox.Text;
            currentRowData.Cells[2].Value = DepartTextbox.Text;
        }
        private void DeleteEBtn_Click(object sender, EventArgs e)
        {
            int SelectedRowIndex = eventDTGV.CurrentRow.Index;
            eventDTGV.Rows.RemoveAt(SelectedRowIndex);
        }

        private void eventDTGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            if (eventDTGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                eventDTGV.CurrentCell.Selected = true;
                NameTextbox.Text = eventDTGV.Rows[e.RowIndex].Cells["Họ Tên"].FormattedValue.ToString();
                DepartTextbox.Text = eventDTGV.Rows[e.RowIndex].Cells["Phòng ban"].FormattedValue.ToString();
                string annType = eventDTGV.Rows[e.RowIndex].Cells["Loại thông báo"].FormattedValue.ToString().Trim();

                if(annType == "Phỏng vấn")
                {
                    typeCbBox.SelectedIndex = 0;
                }
                if (annType == "Thử việc")
                {
                    typeCbBox.SelectedIndex = 1;
                }
                if (annType == "Gia nhập")
                {
                    typeCbBox.SelectedIndex = 2;
                }
            }    
        }

        private void SaveTimeSettingBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CalenderTimeTb.Text))
            {
                MessageBox.Show("Vui lòng nhập thời gian hiển thị lịch tuần", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (string.IsNullOrEmpty(BirthdayTimeTb.Text))
            {
                MessageBox.Show("Vui lòng nhập thời gian hiển thị bảng sinh nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (string.IsNullOrEmpty(BadnewsTimeTb.Text))
            {
                MessageBox.Show("Vui lòng nhập thời gian hiển thị tin buồn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (string.IsNullOrEmpty(EventTimeTb.Text))
            {
                MessageBox.Show("Vui lòng nhập thời gian hiển thị lịch tuần", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (string.IsNullOrEmpty(ImageSlideTb.Text))
            {
                MessageBox.Show("Vui lòng nhập thời gian hiển thị hình ảnh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            using (ExcelPackage package = new ExcelPackage(sourceFile))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                ExcelWorksheet timeSheet = package.Workbook.Worksheets[5];
                int rowCount = timeSheet.Dimension.End.Row;

                timeSheet.Cells[2, 1].Value = CalenderTimeTb.Text;
                timeSheet.Cells[2, 2].Value = BirthdayTimeTb.Text;
                timeSheet.Cells[2, 3].Value = BadnewsTimeTb.Text;
                timeSheet.Cells[2, 4].Value = EventTimeTb.Text;
                timeSheet.Cells[2, 4].Value = ImageSlideTb.Text;

                if (ImageSlideCheckBox.Checked)
                {
                    timeSheet.Cells[2, 7].Value = "true";
                }
                else
                    timeSheet.Cells[2, 7].Value = "false";

                if (BadnewsCheckBox.Checked)
                {
                    timeSheet.Cells[2, 5].Value = "true";
                }
                else
                    timeSheet.Cells[2, 5].Value = "false";

                if(EventcheckBox.Checked)
                {
                    timeSheet.Cells[2, 6].Value = "true";
                }    
                else
                    timeSheet.Cells[2, 6].Value = "false";


                package.Save();
                package.Dispose();

                MessageBox.Show("Thao tác thành công", "Lưu thông số trình chiếu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        
        }

        private void CalenderTimeTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void BirthdayTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void BadnewsTimeTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void EventTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void AddRemindBtn_Click(object sender, EventArgs e)
        {
            DataTable dataTable = (DataTable)RemindDayDTGV.DataSource;
            var dataTbl = new DataTable();
            dataTable.Rows.Add(RemindDay.Text,RemindMonth.Text);
            RemindDayDTGV.DataSource = dataTable;
        }

        private void DeleteRemindBtn_Click(object sender, EventArgs e)
        {
            int SelectedRowIndex = RemindDayDTGV.CurrentRow.Index;
            RemindDayDTGV.Rows.RemoveAt(SelectedRowIndex);
        }

        private void EditRemindBtn_Click(object sender, EventArgs e)
        {
            DataGridViewRow currentRowData = RemindDayDTGV.Rows[indexRow];
            currentRowData.Cells[0].Value = RemindDay.Text;
            currentRowData.Cells[1].Value = RemindMonth.Text;
        }

        private void SaveRemindBtn_Click(object sender, EventArgs e)
        {
            DataTable dataTable = (DataTable)RemindDayDTGV.DataSource;
            if (dataTable.Rows.Count > 0)
            {
                using (ExcelPackage package = new ExcelPackage(sourceFile))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                    ExcelWorksheet RemindSheet = package.Workbook.Worksheets[6];
                    int rowCount = RemindSheet.Dimension.End.Row;
                    RemindSheet.DeleteRow(2, rowCount);

                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        DataRow dr = dataTable.Rows[i];
                        // do something with dr

                        RemindSheet.Cells[i + 2, 1].Value = dr[0];
                        RemindSheet.Cells[i + 2, 2].Value = dr[1];
                    }

                    package.Save();
                    package.Dispose();
                }

                MessageBox.Show("Thao tác thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RemindDay_TextChanged(object sender, EventArgs e)
        {
            int inputValue = 0;
            Int32.TryParse(RemindDay.Text, out inputValue);
            if(inputValue < 1 && RemindDay.Text != "")
            {
                RemindDay.Text = "1";
                MessageBox.Show("Vui lòng nhập giá trị từ 1 đến 31");
            }
            if (inputValue > 31 && RemindDay.Text != "")
            {
                RemindDay.Text = "31";
                MessageBox.Show("Vui lòng nhập giá trị từ 1 đến 31");
            }
        }

        private void CalenderTimeTb_TextChanged(object sender, EventArgs e)
        {
            int inputValue = 0;
            Int32.TryParse(CalenderTimeTb.Text, out inputValue);
            if (inputValue < 1 && CalenderTimeTb.Text != "")
            {
                CalenderTimeTb.Text = "1";
                MessageBox.Show("Vui lòng nhập giá trị số nguyên");
            }
        }

        private void RemindDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void RemindMonth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void RemindMonthTb_TextChanged(object sender, EventArgs e)
        {
            int inputValue = 0;
            Int32.TryParse(RemindMonth.Text, out inputValue);
            if (inputValue < 1 && RemindMonth.Text != "")
            {
                RemindMonth.Text = "1";
                MessageBox.Show("Vui lòng nhập giá trị từ 1 đến 12");
            }
            if (inputValue > 12 && RemindMonth.Text != "")
            {
                RemindMonth.Text = "12";
                MessageBox.Show("Vui lòng nhập giá trị từ 1 đến 12");
            }
        }

        private void RemindDayDTGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            if (RemindDayDTGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                RemindDayDTGV.CurrentCell.Selected = true;
                RemindDay.Text = RemindDayDTGV.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                RemindMonth.Text = RemindDayDTGV.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
            }
        }

        private void BirthdayTimeTb_TextChanged(object sender, EventArgs e)
        {
            int inputValue = 0;
            Int32.TryParse(BirthdayTimeTb.Text, out inputValue);
            if (inputValue < 1 && BirthdayTimeTb.Text != "")
            {
                BirthdayTimeTb.Text = "1";
                MessageBox.Show("Vui lòng nhập giá trị số nguyên lớn hơn 1");
            }
        }

        private void BadnewsTimeTb_TextChanged(object sender, EventArgs e)
        {
            int inputValue = 0;
            Int32.TryParse(BadnewsTimeTb.Text, out inputValue);
            if (inputValue < 1 && BadnewsTimeTb.Text != "")
            {
                BadnewsTimeTb.Text = "1";
                MessageBox.Show("Vui lòng nhập giá trị số nguyên lớn hơn 1");
            }
        }

        private void EventTimeTb_TextChanged(object sender, EventArgs e)
        {
            int inputValue = 0;
            Int32.TryParse(EventTimeTb.Text, out inputValue);
            if (inputValue < 1 && EventTimeTb.Text != "")
            {
                EventTimeTb.Text = "1";
                MessageBox.Show("Vui lòng nhập giá trị số nguyên lớn hơn 1");
            }
        }

        private void ImageSlideTb_TextChanged(object sender, EventArgs e)
        {
            int inputValue = 0;
            Int32.TryParse(ImageSlideTb.Text, out inputValue);
            if (inputValue < 1 && ImageSlideTb.Text != "")
            {
                ImageSlideTb.Text = "1";
                MessageBox.Show("Vui lòng nhập giá trị số nguyên lớn hơn 1");
            }
        }

        private void ImageSlideTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void AddBadNewsImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "Chọn hình cần trình chiếu";
            openDialog.Multiselect = true;
            openDialog.Filter = "File hình ảnh|*.png;*.jpeg; *.jpg; *.bmp";

            var ImagePath = Directory.GetCurrentDirectory() + "\\BadNewsImage\\";

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                string[] files = Directory.GetFiles(ImagePath);

                for (int i = BadNewsImgPanel.Controls.Count - 1; i >= 0; i--)
                {
                    if (BadNewsImgPanel.Controls[i] is PictureBox)
                    {
                        BadNewsImgPanel.Controls[i].Dispose();
                    }
                }

                if (files.Length > 0)
                {
                    badnewsPicBox.Image.Dispose();
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
                var currentImagePath = Directory.GetCurrentDirectory() + "\\BadNewsImage\\";
                string[] currentImages = Directory.GetFiles(currentImagePath);

                badnewsPicBox.Visible = true;

                if(currentImages.Length>=1)
                {
                    PictureBox pic = new PictureBox();
                    pic.Size = BadNewsImgPanel.Size;
                    pic.Dock = DockStyle.Fill;
                    pic.Location = new Point(0, 0);
                    pic.SizeMode = PictureBoxSizeMode.Zoom;

                    Image tempImage = Image.FromFile(currentImages[0]);
                    Bitmap tempBitmap = new Bitmap(tempImage);
                    pic.Image = tempBitmap;
                    BadNewsImgPanel.Controls.Add(pic);
                    //badnewsPicBox.Update();
                    //badnewsPicBox.Refresh();
                    tempImage.Dispose();
                    
                }

                #endregion

                MessageBox.Show("Upload hình ảnh thành công", "Cập nhật hình ảnh tin buồn");
                //badnewsPicBox.Image = Image.FromFile(currentImages[0]);
            }
        }
    }
}
