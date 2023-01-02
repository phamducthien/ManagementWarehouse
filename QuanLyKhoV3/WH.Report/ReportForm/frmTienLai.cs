using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;
using ComponentFactory.Krypton.Toolkit;
using MetroUI.Forms;
using Repository.Pattern.UnitOfWork;
using WH.Model.Properties;
using WH.Service;
using WH.Service.Repository.Core;

namespace WH.Report.ReportForm
{
    // ReSharper disable once InconsistentNaming
    public partial class frmTienLai : MetroForm
    {
        private readonly DateTime _batDau;
        private readonly DateTime _ketThuc;
        private ITienLaiService _service;
        private IUnitOfWorkAsync _unitOfWorkAsync;

        public frmTienLai(DateTime batDau, DateTime ketThuc)
        {
            FrmFlash.ShowSplash();
            Application.DoEvents();

            InitializeComponent();

            this._batDau = batDau;
            this._ketThuc = ketThuc;
        }

        private void ReloadUnitOfWork()
        {
            if (_unitOfWorkAsync != null) _unitOfWorkAsync.Dispose();
            _unitOfWorkAsync = null;
            _unitOfWorkAsync = UnitOfWorkFactory.MakeUnitOfWork();
        }

        private void frmSanPhamHoanTra_Load(object sender, EventArgs e)
        {
            ReloadUnitOfWork();
            _service = new TienLaiService(_unitOfWorkAsync);
            GetBills(_batDau, _ketThuc);
            FrmFlash.CloseSplash();
        }

        private void GetBills(DateTime batDau, DateTime ketThuc)
        {
            dgvHoaDon.Rows.Clear();
            try
            {
                var tienLais = _service.DanhSachTienLaiTheoKhachHang(
                    Convert.ToDateTime(batDau.ToString("yyyy/MM/dd HH:mm:ss")),
                    Convert.ToDateTime(ketThuc.ToString("yyyy/MM/dd HH:mm:ss")));
                if (tienLais == null) return;
                if (tienLais.Count == 0) return;
                dgvHoaDon.DataSource = null;
                dgvHoaDon.AutoGenerateColumns = false;
                dgvHoaDon.DataSource = tienLais;
                dgvHoaDon.Refresh();

                lblTongTienNhap.Text = tienLais.AsEnumerable().Sum(x=>x.TongTienNhap).ToString("N2");
                lblTongTienBan.Text = tienLais.AsEnumerable().Sum(x=>x.TongTienBan).ToString("N2");
                labTongTienTra.Text = tienLais.AsEnumerable().Sum(x=>x.TongTienTra).ToString("N2");
                var tongLai = tienLais.AsEnumerable().Sum(x=>x.TongTienLai);
                lblTongTienLai.Text = tongLai.ToString("N2");
                pictureTrangThai.Image = tongLai == 0 ? Resources.status3 :
                    tongLai < 0 ? Resources.status1 : Resources.status2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Không có dữ liệu!\n" + ex.Message);
                DialogResult = DialogResult.Cancel;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPrinter_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.Rows.Count <= 0) return;
            var dt = new DataTable();

            foreach (DataGridViewColumn column in dgvHoaDon.Columns)
            {
                if (!column.Visible) continue;
                dt.Columns.Add(column.HeaderText,
                    column is DataGridViewImageColumn ? typeof(string) : column.ValueType);
            }

            //Adding the Rows
            foreach (DataGridViewRow row in dgvHoaDon.Rows)
            {
                if (!row.Visible) continue;
                dt.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (!cell.Visible) continue;
                    if (cell is DataGridViewImageCell)
                    {
                        var tienLai = Convert.ToDecimal(row.Cells["colTienLai"].Value.ToString());
                        if (tienLai < 0)
                            dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = "Lỗ";
                        else if (tienLai > 0)
                            dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = "Lãi";
                        else
                            dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = "Huề";
                    }
                    else
                    {
                        dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                    }
                }
            }

            //Exporting to Excel
            var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);
            using (var wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Danh Sách Tiền Lãi Lỗ");

                //save file region here
                var dialog = new SaveFileDialog();
                dialog.InitialDirectory = folderPath;
                dialog.DefaultExt = "xlsx";
                dialog.Filter = @"Excel WorkBook (*.xlsx)|*.xlsx";
                dialog.AddExtension = true;
                dialog.RestoreDirectory = true;
                dialog.Title = @"Lưu File Tại";
                dialog.FileName = @"TienLai_" + DateTime.Now.ToString("yyyyMMddHHmmss");

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    wb.SaveAs(dialog.FileName);
                    MessageBox.Show(@"Đã xuất file tại :" + dialog.FileName);
                    dialog.Dispose();
                }

                //Hết save dialog
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

            currRow.Selected = true;
            dgv.FirstDisplayedScrollingRowIndex = currRow.Index;
            dgv.Select();
            dgv.Focus();
            dgv.Refresh();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:
                    if (dgvHoaDon.Focused)
                        btnPrinter.PerformClick();
                    return true;

                case Keys.F2:
                    return true;

                case Keys.F6:
                    return true;

                case Keys.F5:
                    return true;

                case Keys.F4:
                    return true;

                case Keys.F3:
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
    }
}