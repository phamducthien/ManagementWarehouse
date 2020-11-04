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
using WH.Service.Repository.Core;
using WH.Service.Service;

namespace WH.Report.ReportForm
{
    // ReSharper disable once InconsistentNaming
    public partial class frmTienLai : MetroForm
    {
        private readonly DateTime _batdau;

        private readonly DateTime _ketthuc;

        //private IXuatKhoService service;
        private ITienLaiService service;
        //private ProfitModel model;

        private IUnitOfWorkAsync unitOfWorkAsync;

        public frmTienLai(DateTime batDau, DateTime ketThuc)
        {
            FrmFlash.ShowSplash();
            Application.DoEvents();

            InitializeComponent();

            _batdau = batDau;
            _ketthuc = ketThuc;
        }

        private void ReloadUnitOfWork()
        {
            if (unitOfWorkAsync != null) unitOfWorkAsync.Dispose();
            unitOfWorkAsync = null;
            unitOfWorkAsync = UnitOfWorkFactory.MakeUnitOfWork();
        }

        private void frmSanPhamHoanTra_Load(object sender, EventArgs e)
        {
            ReloadUnitOfWork();
            //service = new XuatKhoService(unitOfWorkAsync);
            service = new TienLaiService(unitOfWorkAsync);
            GetBills(_batdau, _ketthuc);
            FrmFlash.CloseSplash();
        }

        private void GetBills(DateTime batDau, DateTime ketThuc)
        {
            dgvHoaDon.Rows.Clear();
            try
            {
                //var lstHoaDon = service.GetListHoaDonXuatKhoTheoNgay(Convert.ToDateTime(batDau.ToString("yyyy/MM/dd HH:mm:ss")), Convert.ToDateTime(ketThuc.ToString("yyyy/MM/dd HH:mm:ss")));
                //if (lstHoaDon == null) return;
                //if (lstHoaDon.Count == 0) return;

                //model = new ProfitModel(lstHoaDon);

                //dgvHoaDon.DataSource = null;
                //dgvHoaDon.AutoGenerateColumns = false;
                //dgvHoaDon.DataSource = model.dtOutput;
                //dgvHoaDon.Refresh();


                var dt = service.DanhSachTienLaiTheoKhachHang(
                    Convert.ToDateTime(batDau.ToString("yyyy/MM/dd HH:mm:ss")),
                    Convert.ToDateTime(ketThuc.ToString("yyyy/MM/dd HH:mm:ss")));
                if (dt == null) return;
                if (dt.Rows.Count == 0) return;
                dgvHoaDon.DataSource = null;
                dgvHoaDon.AutoGenerateColumns = false;
                dgvHoaDon.DataSource = dt;
                dgvHoaDon.Refresh();

                lblTongTienNhap.Text = dt.AsEnumerable().Sum(r => r.Field<decimal>("TONGTIENNHAP")).ToString("N2");
                lblTongTienBan.Text = dt.AsEnumerable().Sum(r => r.Field<decimal>("TONGTIENBAN")).ToString("N2");
                labTongTienTra.Text = dt.AsEnumerable().Sum(r => r.Field<decimal>("TONGTIENTRA")).ToString("N2");
                var tongLai = dt.AsEnumerable().Sum(r => r.Field<decimal>("TONGTIENLAI"));
                lblTongTienLai.Text = tongLai.ToString("N2");
                pictureTrangThai.Image = tongLai == 0 ? Resources.status3 :
                    tongLai < 0 ? Resources.status1 : Resources.status2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Không có dữ liệu!\n" + ex.Message);
                this.DialogResult = DialogResult.Cancel;
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
                if (column is DataGridViewImageColumn)
                    dt.Columns.Add(column.HeaderText, typeof(string));
                else
                    dt.Columns.Add(column.HeaderText, column.ValueType);
            }

            //Adding the Rows
            foreach (DataGridViewRow row in dgvHoaDon.Rows)
            {
                if (!row.Visible) continue;
                dt.Rows.Add();
                var i = 0;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (!cell.Visible) continue;
                    if (cell is DataGridViewImageCell)
                    {
                        var TienLai = Convert.ToDecimal(row.Cells["colTienLai"].Value.ToString());
                        if (TienLai < 0)
                            dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = "Lỗ";
                        else if (TienLai > 0)
                            dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = "Lãi";
                        else
                            dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = "Huề";
                    }
                    else
                    {
                        dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                    }

                    i++;
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
                dialog.Filter = "Excel WorkBook (*.xlsx)|*.xlsx";
                dialog.AddExtension = true;
                dialog.RestoreDirectory = true;
                dialog.Title = "Lưu File Tại";
                dialog.FileName = @"TienLai_" + DateTime.Now.ToString("yyyyMMddHHmmss");

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

        private void dgvHoaDon_CellMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                //string Ma = dgvHoaDon.SelectedRows[0].Cells["colMaHoaDon"].Value.ToString();
                //PriceCalculateModelCollection collection = model.lstCollection.FirstOrDefault(x => x.MaHoaDon == Ma);
                //frmChiTietHoaDonLaiLo frm = new frmChiTietHoaDonLaiLo(collection);
                //frm.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }
    }
}