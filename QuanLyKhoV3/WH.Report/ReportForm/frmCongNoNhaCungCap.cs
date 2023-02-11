﻿using ClosedXML.Excel;
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
    public partial class frmCongNoNhaCungCap : MetroForm
    {
        private readonly ReportRules _exe;
        private IUnitOfWorkAsync _unitOfWorkAsync;

        public frmCongNoNhaCungCap()
        {
            InitializeComponent();
            _exe = new ReportRules();
        }

        private void ReloadUnitOfWork()
        {
            if (_unitOfWorkAsync != null) _unitOfWorkAsync.Dispose();
            _unitOfWorkAsync = null;
            _unitOfWorkAsync = UnitOfWorkFactory.MakeUnitOfWork();
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
                if (data == null) return;
                if (data.Rows.Count == 0) return;
                CalBill(data);
                var count = 0;
                foreach (DataRow dataRow in data.Rows)
                {
                    var row = treeDanhMuc.CreateRow();
                    row.Cells.Add(new TreeListCell(count + 1));
                    row.Cells.Add(new TreeListCell(dataRow[0].ToString()));
                    row.Cells.Add(new TreeListCell(dataRow[1]));
                    row.Cells.Add(new TreeListCell(dataRow[2].ToString())); // MaCodeKhach hang
                    row.Cells.Add(new TreeListCell(dataRow[3].ToString())); // barcode Khach Hang
                    row.Cells.Add(new TreeListCell(dataRow[4].ToString())); // Ten Khach hang
                    row.Cells.Add(new TreeListCell(dataRow[5].ToString()));
                    row.Cells.Add(new TreeListCell(dataRow[6].ToString()));
                    row.Cells.Add(new TreeListCell(dataRow[7].ToString()));
                    var tinhTrang = "Chưa Thanh Toán";
                    var soTienThanhToan = decimal.Parse(dataRow[8].ToString());
                    var tongTienThu = decimal.Parse(dataRow[9].ToString());
                    var congNo = soTienThanhToan - tongTienThu;
                    if (congNo <= 0)
                    {
                        tinhTrang = "Đã Thanh Toán";
                    }
                    row.Cells.Add(new TreeListCell(congNo));
                    row.Cells.Add(new TreeListCell(tinhTrang));
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
                if (e.RelatedElement is TreeListRow row)
                {
                    var id = row.Cells["_colBillID"].Value.ToString();
                    ReloadUnitOfWork();
                    IXuatKhoService service = new XuatKhoService(_unitOfWorkAsync);
                    var hdKho = service.GetModelHoaDonXuat(id);
                    if (hdKho != null)
                    {
                        var lst = hdKho.HOADONXUATKHOCHITIETs.ToList();
                        var frm = new frmChiTietHoaDonBanHang(hdKho, lst)
                        {
                            StartPosition = FormStartPosition.Manual
                        };
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
                if (e.RelatedElement is TreeListRow row)
                {
                    var id = row.Cells["_colBillID"].Value.ToString();
                    ReloadUnitOfWork();
                    IXuatKhoService service = new XuatKhoService(_unitOfWorkAsync);
                    var hdKho = service.GetModelHoaDonXuat(id);
                    btnXemChiTiet.Enabled = true;
                }
            }
            catch (Exception)
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
                if (!(treeDanhMuc.SelectedElements[0] is TreeListRow row)) return;
                var id = row.Cells["_colBillID"].Value.ToString();
                ReloadUnitOfWork();
                IXuatKhoService service = new XuatKhoService(_unitOfWorkAsync);
                var hdKho = service.GetModelHoaDonXuat(id);
            }
            catch (Exception)
            {
                //MessageBox.Show("Lỗi: Không thể chọn dữ liệu." + " " + ex.Message);
                MessageBox.Show(@"Bạn hãy chọn lại hóa đơn cần xem.");
            }
        }
    }
}
