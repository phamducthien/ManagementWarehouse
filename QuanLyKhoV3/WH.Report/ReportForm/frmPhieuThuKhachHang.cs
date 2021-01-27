using ClosedXML.Excel;
using MetroUI.Forms;
using Repository.Pattern.UnitOfWork;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using WH.Model;
using WH.Report.ReportFunction;
using WH.Service.Repository.Core;
using WH.Service.Service;

namespace WH.Report.ReportForm
{
    // ReSharper disable once InconsistentNaming
    public partial class frmPhieuThuKhachHang : MetroForm
    {
        private readonly ReportRules _exe;

        private string _filenameSaveDefaultExcel = Path.Combine(StaticGlobalVariables.PathDesktop,
            "DoanhThuKhachHang" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xlsx");

        private string _filenameSaveTempExcel = Path.Combine(StaticGlobalVariables.PathTempFolder,
            DateTime.Now.ToString("ddMMyyyyHHmmss") + ".temp");


        private string _filenameTemplateExcel =
            Path.Combine(StaticGlobalVariables.PathExcelTemp, "DoanhThuKhachHang.xlsx");

        private readonly string codeKH;
        private DateTime dtFrom;
        private DataTable dtMain;
        private DateTime dtTo;

        //////////////////////Copy Here////////////////////////////////
        private IUnitOfWorkAsync unitOfWorkAsync;

        public frmPhieuThuKhachHang(DateTime dateFrom, DateTime dateTo, string CodeKhachHang)
        {
            InitializeComponent();
            dtFrom = dateFrom;
            dtTo = dateTo;
            codeKH = CodeKhachHang;
            if (dtFrom == null || dtTo == null || codeKH == "")
            {
                MessageBox.Show(@"Một trong các dữ liệu Ngày Từ hoặc Ngày Đến hoặc Khách Hàng chưa được chọn.");
                Close();
            }

            _exe = new ReportRules();
        }

        private void ReloadUnitOfWork()
        {
            if (unitOfWorkAsync != null) unitOfWorkAsync.Dispose();
            unitOfWorkAsync = null;
            unitOfWorkAsync = UnitOfWorkFactory.MakeUnitOfWork();
        }

        //SELECT TOP 10 kv.TEN as KHUVUC,kh.TENKHACHHANG,kh.DIACHI,kh.DIENTHOAI, pt.MAHOADONTHU as MAPHIEUTHU,pt.MAHOADONXUATKHO as MAHOADON, hd.THANHTIENCHUACK_HD as TIENHOADON, hd.SOTIENTHANHTOAN_HD as CONLAI,pt.TIENTHANHTOAN as DATHU, pt.NGAYTHANHTOAN as NGAYTHANHTOAN,pt.DIENGIAI as GHICHU, kh.CODEKHACHHANG, kh.MABARCODE, nv.TENNGUOIDUNG,HD.TIENCHIETKHAU_HD AS GIAMGIA  FROM PHIEUTHU pt, KHACHHANG kh, KHACHHANGKHUVUC kv, HOADONXUATKHO hd, NGUOIDUNG nv WHERE pt.MAHOADONXUATKHO=hd.MAHOADONXUAT and hd.MAKHACHHANG=kh.MAKHACHHANG and kh.MAKHUVUC = kv.MAKHUVUC and nv.MANGUOIDUNG=hd.NGUOITAO AND pt.MAHOADONTHU like 'PT%'  ORDER BY PT.NGAYTHANHTOAN DESC
        private DataTable GetBills(string soLuongHdLoad, string macodekhachhang, string batDau, string ketThuc)
        {
            var data = _exe.Cmd_GetReceiptBills_ByKhachHang(macodekhachhang, batDau, ketThuc);
            return data;
        }

        private void Control()
        {
            var kq = KiemTraKhachHang(codeKH);
            if (!kq)
            {
                MsgBox.Show("Mã code không đúng, vui lòng nhập chính xác mã code khách hàng", "Thông Báo",
                    MsgBox.Buttons.OK, MsgBox.IconMsgBox.Warning);
                return;
            }

            var data = GetBills("", codeKH, dtFrom.ToString("yyyy/MM/dd HH:mm:ss"),
                dtTo.ToString("yyyy/MM/dd HH:mm:ss"));
            LoadBill(data);
            dtMain = data;
        }

        private bool KiemTraKhachHang(string macodekhachhang)
        {
            if (macodekhachhang == "") return true;
            ReloadUnitOfWork();
            IKHACHHANGService service = new KHACHHANGService(unitOfWorkAsync);
            var objKhachhang = service.Find(p => p.CODEKHACHHANG == macodekhachhang);
            return objKhachhang != null;
        }

        //Load Data To GUI
        private void LoadBill(DataTable data)
        {
            dgv.Rows.Clear();
            dgv.AutoGenerateColumns = false;
            try
            {
                CalBill(data);
                if (data == null) return;
                if (data.Rows.Count == 0) return;
                var count = 0;
                foreach (DataRow drow in data.Rows)
                {
                    dgv.Rows.Insert(count, count + 1, drow[6].ToString(), drow[1].ToString(), drow[2].ToString(),
                        drow[3].ToString(), drow[4].ToString(), decimal.Parse(drow[5].ToString()).ToString("N"));
                    count++;
                }

                dgv.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải dữ liệu đã chọn. " + "\r\n" + ex.Message);
            }
        }

        private void CalBill(DataTable data)
        {
            if (data != null && data.Rows.Count > 0)
            {
                var dathu = _exe.Cmd_CalDaThu_DoanhThu1KhachHang(data);
                //decimal conlai = _exe.Cmd_CalConLai_DoanhThuKhachHang(data);
                //decimal tongtienhoadon = _exe.Cmd_calTongTienHoaDon_DoanhThuKhachHang(data);
                //decimal giamgia = _exe.Cmd_calGiamGia_DoanhThuKhachHang(data);
                var sdathu = @" -> Đã thu : " + dathu.ToString("N");
                //string sConLai = @" - Tiền khách nợ: " + string.Format("{0:####,0 đ}", conlai);
                //string sTienHoaDon = @"Tiền hóa đơn: " + string.Format("{0:####,0 đ}", tongtienhoadon);
                //string sTienGiamGia = @" - Giảm giá: " + string.Format("{0:####,0 đ}", giamgia);
                labDoanhThu.Text = sdathu; //sTienHoaDon + sTienGiamGia + +sConLai;
            }
            else
            {
                labDoanhThu.Text = @"Không có dữ liệu!";
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmDoanhThuKhachHang_Load(object sender, EventArgs e)
        {
            Control();
        }

        private void btnPrinter_Click(object sender, EventArgs e)
        {
            XuatExcel();
            //if (dgv.Rows.Count <= 0) return;
            //DataTable dt = new DataTable();
            //foreach (DataGridViewColumn column in dgv.Columns)
            //{
            //    dt.Columns.Add(column.HeaderText, column.ValueType ?? typeof(string));
            //}

            ////Adding the Rows
            //foreach (DataGridViewRow row in dgv.Rows)
            //{
            //    dt.Rows.Add();
            //    foreach (DataGridViewCell cell in row.Cells)
            //    {
            //        dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
            //    }
            //}

            ////Exporting to Excel
            //string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //if (!Directory.Exists(folderPath))
            //{
            //    Directory.CreateDirectory(folderPath);
            //}
            //using (XLWorkbook wb = new XLWorkbook())
            //{
            //    wb.Worksheets.Add(dt, "Danh Sách Phiếu Thu");

            //    //save file region here
            //    SaveFileDialog dialog = new SaveFileDialog();
            //    dialog.InitialDirectory = folderPath;
            //    dialog.DefaultExt = "xlsx";
            //    dialog.Filter = "Excel File |*.xls|Excel WorkBook (*.xslx)|*.xslx";
            //    dialog.AddExtension = true;
            //    dialog.RestoreDirectory = true;
            //    dialog.Title = "Lưu File Tại";
            //    dialog.FileName = @"PhieuThu" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";

            //    if (dialog.ShowDialog() == DialogResult.OK)
            //    {
            //        wb.SaveAs(dialog.FileName);
            //        MessageBox.Show("Đã xuất file tại :" + dialog.FileName);
            //        dialog.Dispose();
            //        dialog = null;
            //    }
            //    //Hết savedialog
            //}
            ////bool KQ = XuatExcel(_filenameSaveDefaultExcel);
            ////if (KQ)
            ////    MessageBox.Show("Xuất thành công.");
            ////else
            ////    MessageBox.Show("Xuất thất bại.");
        }

        public bool XuatExcel()
        {
            if (dgv.RowCount <= 0) return false;
            var dt = new DataTable();

            foreach (DataGridViewColumn column in dgv.Columns)
                dt.Columns.Add(column.HeaderText);

            //Adding the Rows
            foreach (DataGridViewRow row in dgv.Rows)
            {
                dt.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells)
                    dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
            }

            //Exporting to Excel
            var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);
            using (var wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Danh Sách Doanh Thu Công Nợ");

                //save file region here
                var dialog = new SaveFileDialog();
                dialog.InitialDirectory = folderPath;
                dialog.DefaultExt = "xlsx";
                dialog.Filter = "Excel WorkBook (*.xlsx)|*.xlsx";
                dialog.AddExtension = true;
                dialog.RestoreDirectory = true;
                dialog.Title = "Lưu File Tại";
                dialog.FileName = @"DSDoanhThuCongNo_" + DateTime.Now.ToString("yyyyMMddHHmmss");

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    wb.SaveAs(dialog.FileName);
                    MessageBox.Show("Đã xuất file tại :" + dialog.FileName);
                    dialog.Dispose();
                    dialog = null;
                }

                //Hết savedialog
            }

            return true;
            //bool res;
            //try
            //{
            //    var indexRow = 3;
            //    File.Copy(_filenameTemplateExcel, _filenameSaveTempExcel, true);

            //    SLDocument sl = new SLDocument(_filenameSaveTempExcel, "DoanhThuKhachHang")
            //    {
            //        DocumentProperties =
            //        {
            //            Title = "DoanhThuKhachHang",
            //            Subject = "Xuất Excel Doanh Thu Theo Khách Hàng",
            //            Category = "Báo Cáo",
            //            Creator = "Cong Ty Phat Trien Thuong Mai Dich Vu.",
            //            ContentStatus = "Doanh Thu Khách Hàng",
            //            Description = "Doanh Thu Tổng Hợp Theo Khách Hàng Và Số Lượng Mặt Hàng."
            //        }
            //    };

            //    DataTable data = dtMain;
            //    int count = 1;
            //    foreach (DataRow row in data.Rows)
            //    {
            //        //index++;
            //        sl.set("A" + indexRow.ToString(), count++.ToString() ?? "");
            //        sl.SetCellValue("B" + indexRow, row[0]?.ToString() ?? "");
            //        sl.SetCellValue("C" + indexRow, row[1].ToString() ?? "");
            //        sl.SetCellValue("D" + indexRow, row[2]?.ToString() ?? "");
            //        sl.SetCellValue("E" + indexRow, row[3]?.ToString() ?? "");
            //        sl.SetCellValue("F" + indexRow, row[4]?.ToString() ?? "");
            //        sl.SetCellValue("G" + indexRow, Decimal.Parse(row[5]?.ToString() ?? "0"));
            //        //sl.SetCellValue("H" + indexRow, row[index++]?.ToString() ?? "");
            //        //sl.SetCellValue("I" + indexRow, row[index++]?.ToString() ?? "");
            //        //sl.SetCellValue("J" + indexRow, row[index++]?.ToString() ?? "");
            //        //sl.SetCellValue("K" + indexRow, row[index++]?.ToString() ?? "");
            //        //sl.SetCellValue("L" + indexRow, row[index++]?.ToString() ?? "");
            //        //sl.SetCellValue("M" + indexRow, row[index++]?.ToString() ?? "");
            //        //sl.SetCellValue("N" + indexRow, row[index++]?.ToString() ?? "");
            //        //sl.SetCellValue("O" + indexRow, row[index++]?.ToString() ?? "");
            //        //sl.SetCellValue("P" + indexRow, row[index++]?.ToString() ?? "");
            //        //sl.SetCellValue("Q" + indexRow, row[index++]?.ToString() ?? "");
            //        count++;
            //        indexRow++;
            //    }
            //    sl.SetCellValue("F" + indexRow, "Tổng Cộng:");
            //    sl.SetCellValue("G" + indexRow, labDoanhThu.Text);

            //    sl.Save();
            //    sl.Dispose();
            //    File.Copy(_filenameSaveTempExcel, pathSave, true);
            //    res = true;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Không thể xuất file excel \r\n" +  ex.Message);
            //    res = false;
            //}
            //return res;
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
