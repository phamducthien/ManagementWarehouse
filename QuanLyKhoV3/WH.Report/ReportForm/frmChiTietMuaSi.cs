using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using HLVControl.Grid;
using HLVControl.Grid.Data;
using MetroUI.Forms;
using WH.Report.ReportFunction;

namespace WH.Report.ReportForm
{
    // ReSharper disable once InconsistentNaming
    public partial class frmChiTietMuaSi : MetroForm
    {
        private readonly DateTime _batdau;
        private readonly ReportRules _exe;
        private readonly DateTime _ketthuc;

        public frmChiTietMuaSi(DateTime batDau, DateTime ketThuc)
        {
            InitializeComponent();
            _exe = new ReportRules();
            _batdau = batDau;
            _ketthuc = ketThuc;
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

                for (var date = batDau.AddDays(1); date <= ketThuc; date = date.AddDays(1))
                {
                    data = _exe.Cmd_GetExportDetails(soLuongHdLoad, "", macodekhachhang,
                        batDau.ToString("yyyy/MM/dd"), ketThuc.ToString("yyyy/MM/dd"),
                        date.ToString("yyyy/MM/dd"));
                    data.TableName = date.ToString("dd_MM");
                    dsData.Add(data);
                }

                return dsData;
            }
            catch
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
            treeDanhMuc.Rows.Clear();
            try
            {
                var count = 0;
                var dsTables = GetBills(soLuongHdLoad, macodekhachhang, batDau, ketThuc);

                if (dsTables == null) return;
                if (dsTables.Count == 0) return;
                foreach (DataRow datarow in dsTables[0].Rows)
                {
                    var row = treeDanhMuc.CreateRow();
                    row.Cells.Add(new TreeListCell(count + 1));
                    row.Cells.Add(new TreeListCell(datarow[0].ToString()));
                    row.Cells.Add(new TreeListCell(datarow[1].ToString()));
                    row.Cells.Add(new TreeListCell(datarow[2].ToString()));

                    for (var date = batDau.AddDays(1); date <= ketThuc; date = date.AddDays(1))
                    {
                        var data = dsTables.Find(s => s.TableName == date.ToString("dd_MM"));
                        if (data != null) row.Cells.Add(new TreeListCell(data.Rows[count][2].ToString()));
                    }

                    treeDanhMuc.Rows.Add(row);
                    row.Tag = count;
                    count++;
                }

                treeDanhMuc.Refresh();
                treeDanhMuc.RefreshGrouping();
            }
            catch (Exception)
            {
                throw new Exception("LoadBill");
            }
        }

        private void LoadColToDgv(DateTime startTime, DateTime endTime)
        {
            treeDanhMuc.DataSource = null;
            treeDanhMuc.TreeColumn = null;
            treeDanhMuc.Columns.Clear();
            treeDanhMuc.Refresh();
            treeDanhMuc.RefreshGrouping();

            if (endTime < startTime)
            {
                MessageBox.Show(@"Ngày bắt đầu phải nhỏ hơn ngày kết thúc!");
                return;
            }

            var colStt = new TreeListColumn
            {
                Index = 0,
                Name = "colStt",
                Text = "Stt",
                Visible = true,
                AlignCellHorizontal = StringAlignment.Near,
                AlignCellVertical = StringAlignment.Center,
                AlignHeaderHorizontal = StringAlignment.Center,
                AlignHeaderVertical = StringAlignment.Center,
                Width = 40,
                AllowEdit = false,
                AllowResize = false
            };
            treeDanhMuc.Columns.Add(colStt);

            var colId = new TreeListColumn {Index = 1, Name = "colID", Text = "ID", Visible = false, Width = 0};
            treeDanhMuc.Columns.Add(colId);

            var colName = new TreeListColumn
            {
                Index = 2,
                Name = "colSanPham",
                Text = "Sản phẩm",
                Visible = true,
                AlignCellHorizontal = StringAlignment.Near,
                AlignCellVertical = StringAlignment.Center,
                AlignHeaderHorizontal = StringAlignment.Center,
                AlignHeaderVertical = StringAlignment.Center,
                AllowEdit = false,
                AllowResize = true
            };
            treeDanhMuc.Columns.Add(colName);

            var coltime = new TreeListColumn
            {
                Index = 3,
                Name = "col" + startTime.ToString("dd_MM"),
                Text = startTime.ToString("dd/MM"),
                Visible = true,
                AlignCellHorizontal = StringAlignment.Center,
                AlignCellVertical = StringAlignment.Center,
                AlignHeaderHorizontal = StringAlignment.Center,
                AlignHeaderVertical = StringAlignment.Center,
                Width = 55,
                AllowEdit = false,
                AllowResize = false
            };
            treeDanhMuc.Columns.Add(coltime);

            var index = 4;
            for (var date = startTime.AddDays(1); date <= endTime; date = date.AddDays(1))
            {
                coltime = new TreeListColumn
                {
                    Index = index,
                    Name = "col" + date.ToString("dd_MM"),
                    Text = date.ToString("dd/MM"),
                    Visible = true,
                    AlignCellHorizontal = StringAlignment.Center,
                    AlignCellVertical = StringAlignment.Center,
                    AlignHeaderHorizontal = StringAlignment.Center,
                    AlignHeaderVertical = StringAlignment.Center,
                    Width = 55,
                    AllowEdit = false,
                    AllowResize = false
                };

                treeDanhMuc.Columns.Add(coltime);
                index++;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmDoanhThuKhachHang_Load(object sender, EventArgs e)
        {
            LoadColToDgv(_batdau, _ketthuc);
            LoadBill("", "", _batdau, _ketthuc);
        }

        private void btnPrinter_Click(object sender, EventArgs e)
        {
            if (treeDanhMuc.Rows.Count > 0)
            {
                var export = new FrmDmExportExcel("DOANHTHUKHACHHANG_" + DateTime.Now.ToString("ddMMyyyy_HHmm"),
                    treeDanhMuc);
                if (export.ShowDialog() == DialogResult.OK)
                {
                }
            }
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
                    if (treeDanhMuc.Focused)
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
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}