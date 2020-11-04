using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using ClosedXML.Excel;
using ComponentFactory.Krypton.Toolkit;
using MetroUI.Forms;
using Repository.Pattern.UnitOfWork;
using WH.Service;
using WH.Service.Repository.Core;

namespace WH.Report.ReportForm
{
    public partial class frmSanPhamHoanTra : MetroForm
    {
        private readonly DateTime _batdau;
        private readonly DateTime _ketthuc;
        private INhapXuatService service;

        private IUnitOfWorkAsync unitOfWorkAsync;

        public frmSanPhamHoanTra(DateTime batDau, DateTime ketThuc)
        {
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
            service = new NhapXuatService(unitOfWorkAsync);
            //LoadColToDgv(_batdau, _ketthuc);
            LoadBill(_batdau, _ketthuc);
        }

        //private void LoadColToDgv(DateTime startTime, DateTime endTime)
        //{
        //    dgvHoaDon.DataSource = null;
        //    dgvHoaDon.Columns.Clear();
        //    dgvHoaDon.Refresh();

        //    if (endTime <= startTime)
        //    {
        //        MessageBox.Show(@"Ngày bắt đầu phải nhỏ hơn ngày kết thúc!");
        //        return;
        //    }

        //    var colStt = new DataGridViewColumn
        //    {
        //        DisplayIndex = 0,
        //        Name = "colStt",
        //        HeaderText = "Stt",
        //        AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
        //        DataPropertyName = "STT",
        //        Width = 40,
        //        Visible = true,
        //        ReadOnly = true
        //    };
        //    dgvHoaDon.Columns.Add(colStt);

        //    var colId = new DataGridViewColumn
        //    {
        //        DisplayIndex = 1,
        //        Name = "colID",
        //        HeaderText = "MaMatHang",
        //        AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
        //        DataPropertyName = "MAMATHANG",
        //        Width = 40,
        //        Visible = false,
        //        ReadOnly = true
        //    };
        //    dgvHoaDon.Columns.Add(colId);

        //    var colName = new DataGridViewColumn
        //    {
        //        DisplayIndex = 2,
        //        Name = "colSanPham",
        //        HeaderText = "Sản phẩm",
        //        AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
        //        DataPropertyName = "TENMATHANG",
        //        Width = 40,
        //        Visible = true,
        //        ReadOnly = true
        //    };
        //    dgvHoaDon.Columns.Add(colName);

        //    var coltime = new DataGridViewColumn
        //    {
        //        DisplayIndex = 3,
        //        Name = "col" + startTime.ToString("dd_MM"),
        //        HeaderText = startTime.ToString("dd/MM/yyyy") + "-" + endTime.ToString("dd/MM/yyyy"),
        //        AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
        //        DataPropertyName = "SOLUONGBAN",
        //        Width = 40,
        //        Visible = true,
        //        ReadOnly = true
        //    };
        //    dgvHoaDon.Columns.Add(coltime);

        //    var colSum = new DataGridViewColumn
        //    {
        //        DisplayIndex = 4,
        //        Name = "colThanhTien",
        //        HeaderText = "Tổng tiền",
        //        AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
        //        DataPropertyName = "TONGTIENBAN",
        //        Width = 40,
        //        Visible = true,
        //        ReadOnly = true
        //    };
        //    dgvHoaDon.Columns.Add(colSum);
        //}
        private void LoadBill(DateTime batDau, DateTime ketThuc)
        {
            //dgvHoaDon.Rows.Clear();
            try
            {
                var count = 1;
                var dsTables = GetBills(batDau, ketThuc);
                foreach (DataRow dr in dsTables.Rows) dr["STT"] = count++;
                if (dsTables == null) return;
                if (dsTables.Rows.Count == 0) return;
                dgvHoaDon.DataSource = null;
                dgvHoaDon.AutoGenerateColumns = false;
                dgvHoaDon.DataSource = dsTables;
                dgvHoaDon.Columns["colSoLuongHoanTra"].HeaderText =
                    _batdau.ToString("dd/MM/yyyy") + "-" + _ketthuc.ToString("dd/MM/yyyy");
                dgvHoaDon.Refresh();
            }
            catch (Exception ex)
            {
                throw new Exception("Load Bill Error");
            }
        }

        private DataTable GetBills(DateTime batDau, DateTime ketThuc)
        {
            try
            {
                var dsData = new List<DataTable>();
                var data = service.DanhSachSanPhamHoanTra(Convert.ToDateTime(batDau.ToString("yyyy/MM/dd HH:mm:ss")),
                    Convert.ToDateTime(ketThuc.ToString("yyyy/MM/dd HH:mm:ss")));
                return data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Không có dữ liệu!");
                Close();
            }

            return null;
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
                wb.Worksheets.Add(dt, "Danh Sách Sản Phẩm Đã Trả");

                //save file region here
                var dialog = new SaveFileDialog();
                dialog.InitialDirectory = folderPath;
                dialog.DefaultExt = "xlsx";
                dialog.Filter = "Excel WorkBook (*.xlsx)|*.xlsx";
                dialog.AddExtension = true;
                dialog.RestoreDirectory = true;
                dialog.Title = "Lưu File Tại";
                dialog.FileName = @"SanPhamTra_" + DateTime.Now.ToString("yyyyMMddHHmmss");

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

        private void dgvHoaDon_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                ReloadUnitOfWork();
                service = new NhapXuatService(unitOfWorkAsync);
                var Ma = dgvHoaDon.SelectedRows[0].Cells["colMaMatHang"].Value.ToString();
                var frm = new frmChiTietSanPhamTraHang(_batdau, _ketthuc, Ma);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }
    }
}