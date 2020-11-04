using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using ClosedXML.Excel;
using HLVControl.Grid;
using HLVControl.Grid.Data;
using MetroUI.Forms;
using Repository.Pattern.UnitOfWork;
using WH.Report.ReportFunction;
using WH.Service.Repository.Core;

namespace WH.Report.ReportForm
{
    // ReSharper disable once InconsistentNaming
    public partial class frmChiTietBanSi : MetroForm
    {
        private readonly DateTime _batdau;
        private readonly ReportRules _exe;
        private readonly bool _isKhachHang;
        private readonly DateTime _ketthuc;
        private IUnitOfWorkAsync unitOfWorkAsync;

        public frmChiTietBanSi(DateTime batDau, DateTime ketThuc, bool isKhachHang)
        {
            InitializeComponent();
            dgvHoaDon.AutoGenerateColumns = false;
            _exe = new ReportRules();
            _batdau = batDau;
            _ketthuc = ketThuc;
            _isKhachHang = isKhachHang;
        }

        private void ReloadUnitOfWork()
        {
            if (unitOfWorkAsync != null) unitOfWorkAsync.Dispose();
            unitOfWorkAsync = null;
            unitOfWorkAsync = UnitOfWorkFactory.MakeUnitOfWork();
        }

        private List<DataTable> GetBills(string soLuongHdLoad, string macodekhachhang, DateTime batDau,
            DateTime ketThuc)
        {
            try
            {
                var dsData = new List<DataTable>();
                var data = _exe.Cmd_GetExportDetails(soLuongHdLoad, "", macodekhachhang,
                    batDau.ToString("yyyy/MM/dd"), ketThuc.ToString("yyyy/MM/dd"),
                    batDau.ToString("yyyy/MM/dd"));
                data.TableName = batDau.ToString("dd_MM");
                dsData.Add(data);

                //for (var date = batDau.AddDays(1); date <= ketThuc; date = date.AddDays(1))
                //{
                //    data = _exe.Cmd_GetExportDetails(soLuongHdLoad, "", macodekhachhang,
                //        batDau.ToString("yyyy/MM/dd"), ketThuc.ToString("yyyy/MM/dd"),
                //        date.ToString("yyyy/MM/dd"));
                //    data.TableName = date.ToString("dd_MM");
                //    dsData.Add(data);
                //}
                return dsData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Không có dữ liệu!");
                Close();
            }

            return null;
        }

        //private bool KiemTraKhachHang(string macodekhachhang)
        //{
        //    if (macodekhachhang == "") return true;
        //    var exeKhachhang = new KHACHHANG(StaticVar.ServerConnection) { CODEKHACHHANG = macodekhachhang };
        //    KHACHHANG objKhachhang = exeKhachhang.Cmd_SearchObjectByCondition(exeKhachhang);
        //    return objKhachhang != null;
        //}

        //Load Data To GUI
        private void LoadBill(string soLuongHdLoad, string macodekhachhang, DateTime batDau, DateTime ketThuc)
        {
            try
            {
                dgvHoaDon.Rows.Clear();
                var count = 0;

                var dsTables = GetBills(soLuongHdLoad, macodekhachhang, batDau, ketThuc);

                if (dsTables == null) return;
                if (dsTables.Count == 0) return;

                dgvHoaDon.DataSource = dsTables[0];
                dgvHoaDon.Columns[3].HeaderText = batDau.ToString("dd/MM/yyyy") + "-" + ketThuc.ToString("dd/MM/yyyy");
                dgvHoaDon.Refresh();
                //foreach (DataRow datarow in dsTables[0].Rows)
                //{
                //    //var soLuong = Convert.ToInt32(datarow[3].ToString());
                //    var row = treeDanhMuc.CreateRow();
                //    row.Cells.Add(new TreeListCell(count + 1));
                //    row.Cells.Add(new TreeListCell(datarow[0].ToString()));//MaMATHANG
                //    row.Cells.Add(new TreeListCell(datarow[1].ToString()));//TENMATHANG
                //    row.Cells.Add(new TreeListCell(datarow[3].ToString()));//SOLUONGBAN
                //    row.Cells.Add(new TreeListCell(datarow[4].ToString()));//TONGTIENBAN

                //    treeDanhMuc.Rows.Add(row);
                //    row.Tag = count;
                //    count++;
                //}

                //treeDanhMuc.Refresh();
                //treeDanhMuc.RefreshGrouping();
            }
            catch (Exception ex)
            {
                throw new Exception("LoadBill\n" + ex.Message);
            }
        }

        private List<DataTable> GetBillsNCC(string soLuongHdLoad, string macodekhachhang, DateTime batDau,
            DateTime ketThuc)
        {
            try
            {
                var dsData = new List<DataTable>();
                var data = _exe.Cmd_GetPosImportDetails(soLuongHdLoad, "", macodekhachhang,
                    batDau.ToString("yyyy/MM/dd"), ketThuc.ToString("yyyy/MM/dd"),
                    batDau.ToString("yyyy/MM/dd"));
                data.TableName = batDau.ToString("dd_MM");
                dsData.Add(data);

                for (var date = batDau.AddDays(1); date <= ketThuc; date = date.AddDays(1))
                {
                    data = _exe.Cmd_GetPosImportDetails(soLuongHdLoad, "", macodekhachhang,
                        batDau.ToString("yyyy/MM/dd"), ketThuc.ToString("yyyy/MM/dd"),
                        date.ToString("yyyy/MM/dd"));
                    data.TableName = date.ToString("dd_MM");
                    dsData.Add(data);
                }

                return dsData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Không có dữ liệu!");
                Close();
            }

            return null;
        }

        private void LoadBillNCC(string soLuongHdLoad, string macodekhachhang, DateTime batDau, DateTime ketThuc)
        {
            dgvHoaDon.Rows.Clear();
            try
            {
                var count = 0;
                var dsTables = GetBillsNCC(soLuongHdLoad, macodekhachhang, batDau, ketThuc);

                if (dsTables == null) return;
                if (dsTables.Count == 0) return;
                dgvHoaDon.DataSource = dsTables[0];
                dgvHoaDon.Columns[3].HeaderText = batDau.ToString("dd/MM/yyyy") + "-" + ketThuc.ToString("dd/MM/yyyy");
                dgvHoaDon.Refresh();
                //foreach (DataRow datarow in dsTables[0].Rows)
                //{
                //    var row = treeDanhMuc.CreateRow();
                //    row.Cells.Add(new TreeListCell(count + 1));
                //    row.Cells.Add(new TreeListCell(datarow[0].ToString()));
                //    row.Cells.Add(new TreeListCell(datarow[1].ToString()));
                //    row.Cells.Add(new TreeListCell(datarow[2].ToString()));

                //    for (var date = batDau.AddDays(1); date <= ketThuc; date = date.AddDays(1))
                //    {
                //        var data = dsTables.Find(s => s.TableName == date.ToString("dd_MM"));
                //        if (data != null) row.Cells.Add(new TreeListCell(data.Rows[count][2].ToString()));
                //    }

                //    treeDanhMuc.Rows.Add(row);
                //    row.Tag = count;
                //    count++;
                //}

                //treeDanhMuc.Refresh();
                //treeDanhMuc.RefreshGrouping();
            }
            catch (Exception ex)
            {
                throw new Exception("LoadBill", ex);
            }
        }

        private void LoadColToDgv(DateTime startTime, DateTime endTime)
        {
            //treeDanhMuc.DataSource = null;
            //treeDanhMuc.TreeColumn = null;
            //treeDanhMuc.Columns.Clear();
            //treeDanhMuc.Refresh();
            //treeDanhMuc.RefreshGrouping();

            if (endTime < startTime)
            {
                MessageBox.Show(@"Ngày bắt đầu phải nhỏ hơn ngày kết thúc!");
            }

            //var colStt = new TreeListColumn
            //{
            //    Index = 0,
            //    Name = "colStt",
            //    Text = "Stt",
            //    Visible = true,
            //    AlignCellHorizontal = StringAlignment.Near,
            //    AlignCellVertical = StringAlignment.Center,
            //    AlignHeaderHorizontal = StringAlignment.Center,
            //    AlignHeaderVertical = StringAlignment.Center,
            //    Width = 40,
            //    WordWrap = true,
            //    AllowEdit = false,
            //    AllowResize = false
            //};
            //treeDanhMuc.Columns.Add(colStt);

            //var colId = new TreeListColumn {Index = 1, Name = "colID", Text = "ID", Visible = false, Width = 0};
            //treeDanhMuc.Columns.Add(colId);

            //var colName = new TreeListColumn
            //{
            //    Index = 2,
            //    Name = "colSanPham",
            //    Text = "Sản phẩm",
            //    Visible = true,
            //    AlignCellHorizontal = StringAlignment.Near,
            //    AlignCellVertical = StringAlignment.Center,
            //    AlignHeaderHorizontal = StringAlignment.Center,
            //    AlignHeaderVertical = StringAlignment.Center,
            //    WordWrap = true,
            //    Width = 300,
            //    AllowEdit = false,
            //    AllowResize = true,

            //};
            //treeDanhMuc.Columns.Add(colName);

            //var coltime = new TreeListColumn
            //{
            //    Index = 3,
            //    Name = "col" + startTime.ToString("dd_MM"),
            //    Text = startTime.ToString("dd/MM/yyyy") + "-" + endTime.ToString("dd/MM/yyyy"),
            //    Visible = true,
            //    AlignCellHorizontal = StringAlignment.Center,
            //    AlignCellVertical = StringAlignment.Center,
            //    AlignHeaderHorizontal = StringAlignment.Center,
            //    AlignHeaderVertical = StringAlignment.Center,
            //    WordWrap = true,
            //    Width = 250,
            //    AllowEdit = false,
            //    AllowResize = false
            //};
            //treeDanhMuc.Columns.Add(coltime);

            ////var index = 4;
            ////for (var date = startTime.AddDays(1); date <= endTime; date = date.AddDays(1))
            ////{
            ////    coltime = new TreeListColumn
            ////    {
            ////        Index = index,
            ////        Name = "col" + date.ToString("dd_MM"),
            ////        Text = date.ToString("dd/MM"),
            ////        Visible = true,
            ////        AlignCellHorizontal = StringAlignment.Center,
            ////        AlignCellVertical = StringAlignment.Center,
            ////        AlignHeaderHorizontal = StringAlignment.Center,
            ////        AlignHeaderVertical = StringAlignment.Center,
            ////        Width = 55,
            ////        AllowEdit = false,
            ////        AllowResize = false
            ////    };

            ////    treeDanhMuc.Columns.Add(coltime);
            ////    index++;
            ////}
            //var colSum = new TreeListColumn
            //{
            //    Index = 4,
            //    Name = "colThanhTien",
            //    Text = "Tổng tiền",
            //    Visible = true,
            //    AlignCellHorizontal = StringAlignment.Near,
            //    AlignCellVertical = StringAlignment.Center,
            //    AlignHeaderHorizontal = StringAlignment.Center,
            //    AlignHeaderVertical = StringAlignment.Center,
            //    WordWrap = true,
            //    AllowEdit = false,
            //    AllowResize = true
            //};
            //treeDanhMuc.Columns.Add(colSum);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmDoanhThuKhachHang_Load(object sender, EventArgs e)
        {
            LoadColToDgv(_batdau, _ketthuc);
            if (_isKhachHang)
                LoadBill("", "", _batdau, _ketthuc);
            else
                LoadBillNCC("", "", _batdau, _ketthuc);
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
                wb.Worksheets.Add(dt, "Danh Sách Sản Phẩm Đã Bán");

                //save file region here
                var dialog = new SaveFileDialog();
                dialog.InitialDirectory = folderPath;
                dialog.DefaultExt = "xlsx";
                dialog.Filter = "Excel WorkBook (*.xlsx)|*.xlsx";
                dialog.AddExtension = true;
                dialog.RestoreDirectory = true;
                dialog.Title = "Lưu File Tại";
                dialog.FileName = @"DSSanPhamDaBan_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";

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
            //    var export = new FrmDmExportExcel("DOANHTHUKHACHHANG_" + DateTime.Now.ToString("ddMMyyyy_HHmm"),
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
            if (dgv.SelectedElements.Count <= 0) return;

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

            if (currRow == null) return;
            currRow.IsSelected = true;
            dgv.ScrollIntoView(currRow);
            dgv.Select();
            dgv.Focus();
            dgv.Refresh();
        }

        //==============================================================

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:
                    //if (treeDanhMuc.Focused)
                    //    btnPrinter.PerformClick();

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
                    //SelectNextControl(treeDanhMuc, false);
                    return true;

                case Keys.Down:
                    //SelectNextTreeList(treeDanhMuc, true);
                    return true;

                case Keys.Escape:
                    btnExit.PerformClick();
                    return true;

                case Keys.Alt | Keys.F4:
                    btnExit.PerformClick();
                    return true;

                case Keys.Tab:

                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void dgvHoaDon_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                //dgvHoaDon.Refresh();
                //TreeListRow row = e.RelatedElement as TreeListRow;
                var row = dgvHoaDon.SelectedRows[0];
                if (row != null)
                {
                    var ID = row.Cells["colMaSanPham"].Value.ToString();
                    var TongTien = row.Cells["colThanhTien"].Value.ToString();
                    ReloadUnitOfWork();
                    if (ID != null)
                    {
                        var frm = new frmChiTietSanPhamDaBan(_batdau, _ketthuc, ID, TongTien);
                        frm.ShowDialog(this);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: Không thể chọn dữ liệu." + " " + ex.Message);
            }
        }
    }
}