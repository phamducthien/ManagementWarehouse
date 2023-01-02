using HLVControl.Grid;
using HLVControl.Grid.Data;
using HLVControl.Grid.Events;
using MetroUI.Forms;
using Repository.Pattern.UnitOfWork;
using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using WH.Report.ReportForm;
using WH.Report.ReportFunction;
using WH.Service;
using WH.Service.Repository.Core;

namespace WH.GUI.ExportWarehouse
{
    /// <summary>
    ///     Mô tả danh sách hóa đơn xuất kho
    /// </summary>
    public partial class FrmListExportWarehouse : MetroForm
    {
        private readonly ReportRules _exe;
        private IUnitOfWorkAsync unitOfWorkAsync;

        public FrmListExportWarehouse()
        {
            InitializeComponent();
            _exe = new ReportRules();
        }

        private void ReloadUnitOfWork()
        {
            unitOfWorkAsync?.Dispose();
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
                if (data == null) return;
                if (data.Rows.Count == 0) return;
                var count = 0;
                foreach (DataRow drow in data.Rows)
                {
                    var row = treeDanhMuc.CreateRow();
                    row.Cells.Add(new TreeListCell(count + 1));
                    row.Cells.Add(new TreeListCell(drow[0].ToString()));

                    row.Cells.Add(new TreeListCell(drow[1]));
                    row.Cells.Add(new TreeListCell(drow[2].ToString())); // MaCodeKhach hang
                    row.Cells.Add(new TreeListCell(drow[3].ToString())); // barcode Khach Hang
                    row.Cells.Add(new TreeListCell(drow[4].ToString())); // Ten Khach hang
                    row.Cells.Add(new TreeListCell(drow[5].ToString()));
                    row.Cells.Add(new TreeListCell(drow[6].ToString()));
                    row.Cells.Add(new TreeListCell(drow[7].ToString()));
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
            LoadBill(GetTop10());
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
                    IXuatKhoService service = new XuatKhoService(unitOfWorkAsync);
                    var hdKho = service.GetModelHoaDonXuat(id);
                    if (hdKho == null) return;
                    var lst = hdKho.HOADONXUATKHOCHITIETs.ToList();
                    var frm = new FrmEditExportWarehouse(hdKho, lst, unitOfWorkAsync);
                    frm.ShowDialog(this);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(@"Bạn hãy chọn lại hóa đơn cần xem.");
            }
        }

        private void treeDanhMuc_AfterSelectionChange(object sender, TreeListElementEventArgs e)
        {
            try
            {
                treeDanhMuc.Refresh();
                if (e.RelatedElement is TreeListRow)
                {
                    ReloadUnitOfWork();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(@"Bạn hãy chọn lại hóa đơn cần xem.");
            }
        }
    }
}
