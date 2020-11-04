using System;
using System.Data;
using System.Windows.Forms;
using HLVControl.Grid;
using HLVControl.Grid.Data;
using MetroUI.Forms;
using Repository.Pattern.UnitOfWork;
using WH.Report.ReportFunction;
using WH.Service.Repository.Core;
using WH.Service.Service;

namespace WH.Report.ReportForm
{
    // ReSharper disable once InconsistentNaming
    public partial class frmPosPhieuThuKhachHang : MetroForm
    {
        private readonly ReportRules _exe;

        //////////////////////Copy Here////////////////////////////////
        private IUnitOfWorkAsync unitOfWorkAsync;
        //private TypeGetBill _typeGetBill;

        public frmPosPhieuThuKhachHang()
        {
            InitializeComponent();
            _exe = new ReportRules();
        }

        private DataTable GetBills(string soLuongHdLoad, string macodekhachhang, string batDau, string ketThuc,
            bool groupbyKhachHang)
        {
            var data = _exe.Cmd_GetPosReceiptBills_ByKhachHang(soLuongHdLoad, macodekhachhang, batDau, ketThuc,
                groupbyKhachHang);
            return data;
        }

        private DataTable GetTop10(string macodekhachhang)
        {
            return GetBills("TOP 10", macodekhachhang, "", "", false);
        }

        private DataTable GetTop50(string macodekhachhang)
        {
            return GetBills("TOP 50", macodekhachhang, "", "", false);
        }

        private DataTable GetByTime(string macodekhachhang)
        {
            var frm = new FrmSelectDate();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var data = GetBills("", macodekhachhang, FrmSelectDate.DateFrom.ToString("yyyy/MM/dd HH:mm:ss"),
                    FrmSelectDate.DateTo.ToString("yyyy/MM/dd HH:mm:ss"), false);
                return data;
            }

            return null;
        }

        private DataTable GetAll(string macodekhachhang)
        {
            return GetBills("", macodekhachhang, "", "", false);
        }

        private DataTable GetTop(string macodekhachhang)
        {
            var frm = new FrmSelectTop();
            frm.ShowDialog(this);
            if (frm.top > 0)
            {
                var data = GetBills(frm.top.ToString(), macodekhachhang, "", "", true);
                return data;
            }

            return null;
        }

        private void Control(TypeGetBill typeGet, string macodekhachhang)
        {
            var kq = KiemTraKhachHang(macodekhachhang);
            if (!kq)
            {
                MsgBox.Show("Mã code không đúng, vui lòng nhập chính xác mã code khách hàng", "Thông Báo",
                    MsgBox.Buttons.OK, MsgBox.IconMsgBox.Warning);
                return;
            }

            DataTable data = null;
            switch (typeGet)
            {
                case TypeGetBill.GetAll:
                    data = GetAll(macodekhachhang);
                    break;

                case TypeGetBill.GetTop10:
                    data = GetTop10(macodekhachhang);
                    break;

                case TypeGetBill.GetTop50:
                    data = GetTop50(macodekhachhang);
                    break;

                case TypeGetBill.GetByTime:
                    data = GetByTime(macodekhachhang);
                    break;

                case TypeGetBill.GetTop:
                    data = GetTop(macodekhachhang);
                    break;
            }

            //_typeGetBill = typeGet;
            LoadBill(data);
        }

        private void ReloadUnitOfWork()
        {
            if (unitOfWorkAsync != null) unitOfWorkAsync.Dispose();
            unitOfWorkAsync = null;
            unitOfWorkAsync = UnitOfWorkFactory.MakeUnitOfWork();
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
                    row.Cells.Add(new TreeListCell(drow[1].ToString()));
                    row.Cells.Add(new TreeListCell(drow[2].ToString()));
                    row.Cells.Add(new TreeListCell(drow[3].ToString()));
                    row.Cells.Add(new TreeListCell(drow[4].ToString()));
                    row.Cells.Add(new TreeListCell(drow[5].ToString()));
                    row.Cells.Add(new TreeListCell($"{decimal.Parse(drow[6].ToString()):####,0}"));
                    row.Cells.Add(new TreeListCell($"{decimal.Parse(drow[7].ToString()):####,0}"));
                    row.Cells.Add(new TreeListCell($"{decimal.Parse(drow[8].ToString()):####,0}"));
                    row.Cells.Add(new TreeListCell(drow[9].ToString()));
                    row.Cells.Add(new TreeListCell(drow[10].ToString()));
                    row.Cells.Add(new TreeListCell(drow[11].ToString()));
                    row.Cells.Add(new TreeListCell(drow[12].ToString()));
                    row.Cells.Add(new TreeListCell(drow[13].ToString()));
                    row.Tag = count;

                    treeDanhMuc.Rows.Add(row);
                    count++;
                }

                treeDanhMuc.Refresh();
                treeDanhMuc.RefreshGrouping();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"LoadBill:" + ex.Message);
            }
        }

        private void CalBill(DataTable data)
        {
            if (data != null && data.Rows.Count > 0)
            {
                var dathu = _exe.Cmd_CalDaThu_DoanhThuKhachHang(data);
                //decimal conlai = _exe.Cmd_CalConLai_DoanhThuKhachHang(data);
                //decimal tongtienhoadon = _exe.Cmd_calTongTienHoaDon_DoanhThuKhachHang(data);
                //decimal giamgia = _exe.Cmd_calGiamGia_DoanhThuKhachHang(data);
                var sdathu = @" -> Đã thu : " + $"{dathu:####,0 đ}";
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

        private void btnTheoNgay_Click(object sender, EventArgs e)
        {
            Control(TypeGetBill.GetByTime, txtMaKH.Text.Trim());
        }

        private void btnTop10_Click(object sender, EventArgs e)
        {
            Control(TypeGetBill.GetTop10, txtMaKH.Text.Trim());
        }

        private void btnTop50_Click(object sender, EventArgs e)
        {
            Control(TypeGetBill.GetTop50, txtMaKH.Text.Trim());
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            Control(TypeGetBill.GetAll, txtMaKH.Text.Trim());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmDoanhThuKhachHang_Load(object sender, EventArgs e)
        {
            Control(TypeGetBill.GetTop10, txtMaKH.Text.Trim());
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
                    txtMaKH.Text = "";
                    txtMaKH.Select();
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
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnTopKhachHang_Click(object sender, EventArgs e)
        {
            GetTop("");
        }

        //private void btnTimKiem_Click(object sender, EventArgs e)
        //{
        //    Control(_typeGetBill, txtMaKH.Text.Trim());
        //}

        private enum TypeGetBill
        {
            GetTop,
            GetTop10,
            GetTop50,
            GetByTime,
            GetAll
        }
    }
}