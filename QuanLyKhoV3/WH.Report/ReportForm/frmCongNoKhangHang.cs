using ClosedXML.Excel;
using HLVControl.Grid;
using HLVControl.Grid.Data;
using HLVControl.Grid.Events;
using MetroUI.Forms;
using Repository.Pattern.UnitOfWork;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WH.Report.ReportFunction;
using WH.Service;
using WH.Service.Repository.Core;

namespace WH.Report.ReportForm
{
    /// <summary>
    ///     Mô tả danh sách hóa đơn xuất kho
    /// </summary>
    public partial class FrmCongNoKhangHang : MetroForm
    {
        private readonly ReportRules _exe;
        private IUnitOfWorkAsync unitOfWorkAsync;

        public FrmCongNoKhangHang()
        {
            InitializeComponent();
            _exe = new ReportRules();
        }

        private void ReloadUnitOfWork()
        {
            if (unitOfWorkAsync != null) unitOfWorkAsync.Dispose();
            unitOfWorkAsync = null;
            unitOfWorkAsync = UnitOfWorkFactory.MakeUnitOfWork();
        }

        private DataTable GetBills(string soLuongHdLoad, string batDau, string ketThuc)
        {
            var data = _exe.Cmd_GetExportBills_ByKhachHang(soLuongHdLoad, "", batDau, ketThuc,
                StateBill.ChuaThanhToan);
            return data;
        }

        private DataTable GetTop10()
        {
            return GetBills("TOP 10", "", "");
        }

        private DataTable GetTop50()
        {
            return GetBills("TOP 50", "", "");
        }

        private DataTable GetByTime()
        {
            var frm = new FrmSelectDate();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var data = GetBills("", FrmSelectDate.DateFrom.ToString("yyyy/MM/dd HH:mm:ss"),
                    FrmSelectDate.DateTo.ToString("yyyy/MM/dd HH:mm:ss"));
                return data;
            }

            return null;
        }

        private DataTable GetAll()
        {
            return GetBills("", "", "");
        }

        //Load Data To GUI
        private void LoadBill(DataTable data)
        {
            treeDanhMuc.Rows.Clear();
            try
            {
                CalBill(data);
                if (data == null) return;
                if (data.Rows.Count == 0) return;
                var count = 0;
                foreach (DataRow drow in data.Rows)
                {
                    var row = treeDanhMuc.CreateRow();
                    row.Cells.Add(new TreeListCell(count + 1));
                    row.Cells.Add(new TreeListCell(drow[0].ToString()));
                    row.Cells.Add(new TreeListCell(drow[5]));
                    row.Cells.Add(new TreeListCell(drow[7].ToString())); // MaCodeKhach hang
                    row.Cells.Add(new TreeListCell(drow[8].ToString())); // barcode Khach Hang
                    row.Cells.Add(new TreeListCell(drow[9].ToString())); // Ten Khach hang
                    row.Cells.Add(new TreeListCell(drow[1].ToString()));
                    row.Cells.Add(new TreeListCell(drow[2].ToString()));
                    row.Cells.Add(new TreeListCell(drow[3].ToString()));
                    row.Cells.Add(new TreeListCell(drow[4].ToString()));
                    row.Cells.Add(new TreeListCell(drow[8].ToString()));
                    row.Tag = count;

                    treeDanhMuc.Rows.Add(row);
                    count++;
                }

                treeDanhMuc.Refresh();
                treeDanhMuc.RefreshGrouping();
            }
            catch (Exception)
            {
                MessageBox.Show(@"Không thể tải thông tin!");
            }
        }

        private void CalBill(DataTable data)
        {
            if (data != null && data.Rows.Count > 0)
            {
                //decimal dathu = _exe.Cmd_CalDaThu_CongNoKhachHang(data);
                var conlai = _exe.Cmd_CalConLai_CongNoKhachHang(data);
                //decimal tongtienhoadon = _exe.Cmd_calTongTienHoaDon_CongNoKhachHang(data);
                //decimal giamgia = _exe.Cmd_calGiamGia_CongNoKhachHang(data);
                //string sdathu = @" - Đã thu : " + string.Format("{0:####,0 đ}", dathu);
                var sConLai = @" -> Tiền khách nợ: " + conlai.ToString("N");
                //string sTienHoaDon = @"Tiền hóa đơn: " + string.Format("{0:####,0 đ}", tongtienhoadon);
                //string sTienGiamGia = @" - Giảm giá: " + string.Format("{0:####,0 đ}", giamgia);
                labDoanhThu.Text = sConLai; //sTienHoaDon + sTienGiamGia + sdathu + sConLai;
            }
            else
            {
                labDoanhThu.Text = @"Không có dữ liệu!";
            }
        }

        private void btnTheoNgay_Click(object sender, EventArgs e)
        {
            LoadBill(GetByTime());
        }

        private void btnTop10_Click(object sender, EventArgs e)
        {
            LoadBill(GetTop10());
        }

        private void btnTop50_Click(object sender, EventArgs e)
        {
            LoadBill(GetTop50());
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            LoadBill(GetAll());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmCongNoKhachHang_Load(object sender, EventArgs e)
        {
            btnXemChiTiet.Enabled = true;
            LoadBill(GetTop10());
        }

        private void btnPrinter_Click(object sender, EventArgs e)
        {
            if (treeDanhMuc.Rows.Count <= 0) return;
            var dt = new DataTable();
            var numCol = treeDanhMuc.Columns.Count;
            foreach (TreeListColumn column in treeDanhMuc.Columns) dt.Columns.Add(column.Text, typeof(string));

            //Adding the Rows
            foreach (TreeListRow row in treeDanhMuc.Rows)
            {
                dt.Rows.Add();
                var cellIndex = 0;
                foreach (TreeListCell cell in row.Cells)
                {
                    dt.Rows[dt.Rows.Count - 1][cellIndex++] = cell.Value.ToString();
                    if (cellIndex == numCol)
                        cellIndex = 0;
                }
            }

            //Exporting to Excel
            var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);
            using (var wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Danh Sách Hóa Đơn Xuất");

                //save file region here
                var dialog = new SaveFileDialog();
                dialog.InitialDirectory = folderPath;
                dialog.DefaultExt = "xlsx";
                dialog.Filter = "Excel WorkBook (*.xlsx)|*.xlsx";
                dialog.AddExtension = true;
                dialog.RestoreDirectory = true;
                dialog.Title = "Lưu File Tại";
                dialog.FileName = @"DSHoaDonXuatKho_" + DateTime.Now.ToString("yyyyMMddHHmmss");

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    wb.SaveAs(dialog.FileName);
                    MessageBox.Show("Đã xuất file tại :" + dialog.FileName);
                    dialog.Dispose();
                    dialog = null;
                }

                //Hết savedialog
            }

            //if (treeDanhMuc.Rows.Count > 0)
            //{
            //    var export = new FrmDmExportExcel("CONGNOKHACHHANG_" + DateTime.Now.ToString("ddMMyyyy_HHmm"),
            //        treeDanhMuc);
            //    if (export.ShowDialog() == DialogResult.OK)
            //    {
            //    }
            //}
        }

        //==============================================================
        private void SelectNextTreeList(TreeListView dgv, bool isDown)
        {
            int index;

            var currRow = dgv.SelectedElements[0] as TreeListRow;

            if (!isDown)
            {
                if (currRow != null)
                {
                    currRow.IsSelected = false;

                    index = currRow.SelectionIndex - 1;
                    currRow = index >= 1 ? dgv.Rows[index] : dgv.Rows[0];
                }
                else
                {
                    currRow = dgv.Rows[0];
                }
            }
            else
            {
                if (currRow != null)
                {
                    currRow.IsSelected = false;
                    index = currRow.SelectionIndex + 1;
                    currRow = index < dgv.Rows.Count - 1 ? dgv.Rows[index] : dgv.Rows[dgv.Rows.Count - 1];
                }
                else
                {
                    currRow = dgv.Rows[dgv.Rows.Count - 1];
                }
            }

            if (currRow != null)
            {
                currRow.IsSelected = true;
                dgv.ScrollIntoView(currRow);
                dgv.Select();
                dgv.Focus();
                dgv.Refresh();
            }
        }

        //==============================================================

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:
                    if (treeDanhMuc.Focused)
                        btnPrinter.PerformClick();
                    if (txtTimKiem.Focused)
                        btnTimKiem.PerformClick();
                    return true;

                case Keys.F2:
                    txtTimKiem.Select();
                    btnTimKiem.PerformClick();
                    return true;

                case Keys.F6:
                    btnAll.PerformClick();
                    return true;

                case Keys.F5:
                    btnTheoNgay.PerformClick();
                    return true;

                case Keys.F4:
                    btnTop50.PerformClick();
                    return true;

                case Keys.F3:
                    btnTop10.PerformClick();
                    return true;

                case Keys.Up:
                    SelectNextTreeList(treeDanhMuc, false);
                    return true;

                case Keys.Down:
                    SelectNextTreeList(treeDanhMuc, true);
                    return true;

                case Keys.Escape:
                    btnExit.PerformClick();
                    return true;

                case Keys.Alt | Keys.F4:
                    btnExit.PerformClick();
                    return true;

                case Keys.Tab:

                    return true;

                default:
                    Debug.Assert(true);
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            SearchProvider.SmartSearch(treeDanhMuc, txtTimKiem.Text.Trim());
        }

        private void treeDanhMuc_DoubleClickElement(object sender, TreeListElementEventArgs e)
        {
            try
            {
                treeDanhMuc.Refresh();
                var row = e.RelatedElement as TreeListRow;
                if (row != null)
                {
                    var ID = row.Cells["_colBillID"].Value.ToString();
                    ReloadUnitOfWork();
                    IXuatKhoService service = new XuatKhoService(unitOfWorkAsync);
                    var hdKho = service.GetModelHoaDonXuat(ID);
                    if (hdKho != null)
                    {
                        var lst = hdKho.HOADONXUATKHOCHITIETs.ToList();
                        var frm = new frmChiTietHoaDonBanHang(hdKho, lst);
                        frm.StartPosition = FormStartPosition.Manual;
                        frm.ShowDialog(this);
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Lỗi: Không thể chọn dữ liệu." + " " + ex.Message);
                MessageBox.Show(@"Bạn hãy chọn lại hóa đơn cần xem.");
            }
        }

        private void treeDanhMuc_AfterSelectionChange(object sender, TreeListElementEventArgs e)
        {
            try
            {
                treeDanhMuc.Refresh();
                var row = e.RelatedElement as TreeListRow;
                if (row != null)
                {
                    var ID = row.Cells["_colBillID"].Value.ToString();
                    ReloadUnitOfWork();
                    IXuatKhoService service = new XuatKhoService(unitOfWorkAsync);
                    var hdKho = service.GetModelHoaDonXuat(ID);
                    btnXemChiTiet.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Bạn hãy chọn lại hóa đơn cần xem.");
                //MessageBox.Show("Lỗi: Không thể chọn dữ liệu." + " " + ex.Message);
            }
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            try
            {
                treeDanhMuc.Refresh();
                var row = treeDanhMuc.SelectedElements[0] as TreeListRow;
                if (row != null)
                {
                    var ID = row.Cells["_colBillID"].Value.ToString();
                    ReloadUnitOfWork();
                    IXuatKhoService service = new XuatKhoService(unitOfWorkAsync);
                    var hdKho = service.GetModelHoaDonXuat(ID);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Lỗi: Không thể chọn dữ liệu." + " " + ex.Message);
                MessageBox.Show(@"Bạn hãy chọn lại hóa đơn cần xem.");
            }
        }
    }
}
