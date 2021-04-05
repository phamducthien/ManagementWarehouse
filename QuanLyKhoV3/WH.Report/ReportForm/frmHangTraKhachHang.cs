using ClosedXML.Excel;
using ComponentFactory.Krypton.Toolkit;
using MetroFramework.Forms;
using Repository.Pattern.UnitOfWork;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WH.Service;
using WH.Service.Repository.Core;
//using DocumentFormat.OpenXml.Wordprocessing;

namespace WH.Report.ReportForm
{
    public partial class frmHangTraKhachHang : MetroForm
    {
        private INhapXuatService service;

        private IUnitOfWorkAsync unitOfWorkAsync;

        public frmHangTraKhachHang()
        {
            InitializeComponent();
        }

        private void ReloadUnitOfWork()
        {
            if (unitOfWorkAsync != null) unitOfWorkAsync.Dispose();
            unitOfWorkAsync = null;
            unitOfWorkAsync = UnitOfWorkFactory.MakeUnitOfWork();
        }

        private DataTable GetTop10()
        {
            return service.DanhSachHoaDonNhapXuat(new DateTime(1990, 1, 1), new DateTime(1990, 1, 1), 10);
        }

        private DataTable GetTop50()
        {
            return service.DanhSachHoaDonNhapXuat(new DateTime(1990, 1, 1), new DateTime(1990, 1, 1), 50);
        }

        private DataTable GetByTime()
        {
            var frm = new FrmSelectDate();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var data = service.DanhSachHoaDonNhapXuat(
                    Convert.ToDateTime(FrmSelectDate.DateFrom.ToString("yyyy/MM/dd HH:mm:ss")),
                    Convert.ToDateTime(FrmSelectDate.DateTo.ToString("yyyy/MM/dd HH:mm:ss")), 0);
                return data;
            }

            return null;
        }

        private DataTable GetAll()
        {
            return service.DanhSachHoaDonNhapXuat(new DateTime(1990, 1, 1), new DateTime(1990, 1, 1), 0);
        }

        private void frmHangTraKhachHang_Load(object sender, EventArgs e)
        {
            ReloadUnitOfWork();
            service = new NhapXuatService(unitOfWorkAsync);
            LoadBill(GetTop10());
        }

        private void LoadBill(DataTable data)
        {
            //dgvHoaDon.Rows.Clear();
            try
            {
                CalBill(data);
                var count = 1;
                foreach (DataRow dr in data.Rows) dr["STT"] = count++;
                if (data == null) return;
                if (data.Rows.Count == 0) return;

                dgvHoaDon.DataSource = null;
                dgvHoaDon.AutoGenerateColumns = false;
                dgvHoaDon.DataSource = data;

                dgvHoaDon.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Không thể tải thông tin!");
            }
        }

        private void CalBill(DataTable data)
        {
            if (data != null && data.Rows.Count > 0)
            {
                var sum = data.AsEnumerable().Sum(dr => dr.Field<decimal>("TONGTIENHOANTRA"));
                var sSum = @" -> Tiền hoàn trả: " + sum.ToString("N");
                labDoanhThu.Text = sSum;
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

        private void btnPrinter_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.RowCount <= 0) return;
            var dt = new DataTable();
            foreach (DataGridViewColumn column in dgvHoaDon.Columns)
                dt.Columns.Add(column.HeaderText, column.ValueType);

            //Adding the Rows
            foreach (DataGridViewRow row in dgvHoaDon.Rows)
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
                wb.Worksheets.Add(dt, "Danh Sách Hóa Đơn Hàng Trả");

                //save file region here
                var dialog = new SaveFileDialog();
                dialog.InitialDirectory = folderPath;
                dialog.DefaultExt = "xlsx";
                dialog.Filter = "Excel WorkBook (*.xlsx)|*.xlsx";
                dialog.AddExtension = true;
                dialog.RestoreDirectory = true;
                dialog.Title = "Lưu File Tại";
                dialog.FileName = @"HoaDonHangTra_" + DateTime.Now.ToString("yyyyMMddHHmmss");

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    wb.SaveAs(dialog.FileName);
                    MessageBox.Show("Đã xuất file tại :" + dialog.FileName);
                    dialog.Dispose();
                    dialog = null;
                }

                //Hết savedialog
            }
        }

        private void SelectNextTreeList(KryptonDataGridView dgv, bool isDown)
        {
            int index;

            var currRow = dgv.SelectedRows[0];

            if (!isDown)
            {
                if (currRow != null)
                {
                    currRow.Selected = false;

                    index = currRow.Index - 1;
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
                    currRow.Selected = false;
                    index = currRow.Index + 1;
                    currRow = index < dgv.Rows.Count - 1 ? dgv.Rows[index] : dgv.Rows[dgv.Rows.Count - 1];
                }
                else
                {
                    currRow = dgv.Rows[dgv.Rows.Count - 1];
                }
            }

            if (currRow != null)
            {
                currRow.Selected = true;
                dgv.FirstDisplayedScrollingRowIndex = currRow.Index;
                dgv.Select();
                dgv.Focus();
                dgv.Refresh();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:
                    if (dgvHoaDon.Focused)
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
                    SelectNextTreeList(dgvHoaDon, false);
                    return true;

                case Keys.Down:
                    SelectNextTreeList(dgvHoaDon, true);
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
            SearchProvider.SmartSearch(dgvHoaDon, txtTimKiem.Text.Trim());
        }

        private void dgvHoaDon_SelectionChanged(object sender, EventArgs e)
        {
            //if(dgvHoaDon.Rows)
        }

        private void dgvHoaDon_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                ReloadUnitOfWork();
                service = new NhapXuatService(unitOfWorkAsync);
                var MaHoaDon = dgvHoaDon.SelectedRows[0].Cells["colMaHoaDon"].Value.ToString();
                var TenKhachHang = dgvHoaDon.SelectedRows[0].Cells["colTenKhachHang"].Value.ToString();
                var frm = new frmChiTietHoaDonNhapXuat(MaHoaDon, TenKhachHang);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
