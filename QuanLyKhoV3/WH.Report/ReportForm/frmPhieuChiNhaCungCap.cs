using System;
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
using WH.Service.Service;

namespace WH.Report.ReportForm
{
    public partial class FrmDoanhThuNhaCungCap : MetroForm
    {
        private readonly ReportRules _exe;
        private readonly string codeNCC;
        private DateTime dtFrom;
        private DataTable dtMain;

        private DateTime dtTo;

        //////////////////////Copy Here////////////////////////////////
        private IUnitOfWorkAsync unitOfWorkAsync;

        public FrmDoanhThuNhaCungCap(DateTime dateFrom, DateTime dateTo, string CodeNCC)
        {
            InitializeComponent();
            dtFrom = dateFrom;
            dtTo = dateTo;
            codeNCC = CodeNCC;
            if (dtFrom == null || dtTo == null || codeNCC == "")
            {
                MessageBox.Show("Một trong các dữ liệu Ngày Từ hoặc Ngày Đến hoặc NCC chưa được chọn.");
                Close();
            }

            _exe = new ReportRules();
        }

        protected DataTable GetBills(string soLuongHdLoad, string maNcc, string batDau, string ketThuc)
        {
            var data = _exe.Cmd_GetPaymentBills_ByNCC(soLuongHdLoad, maNcc, batDau, ketThuc);
            return data;
        }

        private DataTable GetTop10(string maNcc)
        {
            return GetBills("TOP 10", maNcc, "", "");
        }

        private DataTable GetTop50(string maNcc)
        {
            return GetBills("TOP 50", maNcc, "", "");
        }

        private DataTable GetByTime(string maNcc)
        {
            var frm = new FrmSelectDate();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var data = GetBills("", maNcc, FrmSelectDate.DateFrom.ToString("yyyy/MM/dd HH:mm:ss"),
                    FrmSelectDate.DateTo.ToString("yyyy/MM/dd HH:mm:ss"));
                return data;
            }

            return null;
        }

        private DataTable GetAll(string maNcc)
        {
            return GetBills("", maNcc, "", "");
        }

        private void Control(TypeGetBill typeGet, string macodekhachhang)
        {
            var kq = KiemTraNcc(macodekhachhang);
            if (!kq)
            {
                MsgBox.Show("Mã không đúng, vui lòng nhập chính xác mã NCC", "Thông Báo",
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
            }

            LoadBill(data);
        }

        private void ReloadUnitOfWork()
        {
            if (unitOfWorkAsync != null) unitOfWorkAsync.Dispose();
            unitOfWorkAsync = null;
            unitOfWorkAsync = UnitOfWorkFactory.MakeUnitOfWork();
        }

        private bool KiemTraNcc(string manhacungcap)
        {
            if (manhacungcap == "") return true;
            var id = int.Parse(manhacungcap);
            ReloadUnitOfWork();
            INHACUNGCAPService service = new NHACUNGCAPService(unitOfWorkAsync);
            var objNcc = service.Find(p => p.IDUnit == manhacungcap);
            return objNcc != null;
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
                    row.Cells.Add(
                        new TreeListCell(string.Format("{0:####,0.00} đ", decimal.Parse(drow[5].ToString()))));
                    row.Cells.Add(
                        new TreeListCell(string.Format("{0:####,0.00} đ", decimal.Parse(drow[6].ToString()))));
                    row.Cells.Add(
                        new TreeListCell(string.Format("{0:####,0.00} đ", decimal.Parse(drow[7].ToString()))));
                    try
                    {
                        var time = DateTime.Parse(drow[8].ToString());
                        row.Cells.Add(new TreeListCell(time.ToString("dd/MM/yyyy")));
                    }
                    catch
                    {
                        row.Cells.Add(new TreeListCell(drow[8].ToString()));
                    }

                    row.Cells.Add(new TreeListCell(drow[9].ToString()));
                    //row.Cells.Add(new TreeListCell(drow[10].ToString()));
                    row.Tag = count;

                    treeDanhMuc.Rows.Add(row);
                    count++;
                }

                treeDanhMuc.Refresh();
                treeDanhMuc.RefreshGrouping();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CalBill(DataTable data)
        {
            if (data != null && data.Rows.Count > 0)
            {
                var dathu = _exe.Cmd_CalDaChi_DoanhThuNhaCungCap(data);
                //decimal conlai = _exe.Cmd_CalConLai_DoanhThuNhaCungCap(data);
                //decimal tongtienhoadon = _exe.Cmd_calTongTienHoaDon_DoanhThuNhaCungCap(data);
                //decimal giamgia = _exe.Cmd_calGiamGia_DoanhThuNhaCungCap(data);
                var sdathu = @" -> Đã chi : " + string.Format("{0:####,0 đ}", dathu);
                //string sConLai = @" - Tiền nợ : " + string.Format("{0:####,0 đ}", conlai);
                //string sTienHoaDon = @"Tiền hóa đơn : " + string.Format("{0:####,0 đ}", tongtienhoadon);
                //string sTienGiamGia = @" - Giảm giá : " + string.Format("{0:####,0 đ}", giamgia);
                labDoanhThu.Text = sdathu; //sTienHoaDon + sTienGiamGia + sConLai + 
            }
            else
            {
                labDoanhThu.Text = @"Không có dữ liệu!";
            }
        }

        private void btnTheoNgay_Click(object sender, EventArgs e)
        {
            Control(TypeGetBill.GetByTime, txtNhaCungCap.Text.Trim());
        }

        private void btnTop10_Click(object sender, EventArgs e)
        {
            Control(TypeGetBill.GetTop10, txtNhaCungCap.Text.Trim());
        }

        private void btnTop50_Click(object sender, EventArgs e)
        {
            Control(TypeGetBill.GetTop50, txtNhaCungCap.Text.Trim());
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            Control(TypeGetBill.GetAll, txtNhaCungCap.Text.Trim());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool KiemTraNCC(string macode)
        {
            if (macode == "") return true;
            ReloadUnitOfWork();
            INHACUNGCAPService service = new NHACUNGCAPService(unitOfWorkAsync);
            var objKhachhang = service.Find(p => p.MANHACUNGCAP.ToString() == macode);
            return objKhachhang != null;
        }


        private void Control()
        {
            var kq = KiemTraNCC(codeNCC);
            if (!kq)
            {
                MsgBox.Show("Mã code không đúng, vui lòng nhập chính xác mã NCC", "Thông Báo",
                    MsgBox.Buttons.OK, MsgBox.IconMsgBox.Warning);
                return;
            }

            var data = GetBills("", codeNCC, dtFrom.ToString("yyyy/MM/dd HH:mm:ss"),
                dtTo.ToString("yyyy/MM/dd HH:mm:ss"));
            LoadBill(data);
            dtMain = data;
        }

        private void frmDoanhThuKhachHang_Load(object sender, EventArgs e)
        {
            Control();
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
                wb.Worksheets.Add(dt, "Danh Sách Phiếu Chi");

                //save file region here
                var dialog = new SaveFileDialog();
                dialog.InitialDirectory = folderPath;
                dialog.DefaultExt = "xlsx";
                dialog.Filter = "Excel WorkBook (*.xlsx)|*.xlsx";
                dialog.AddExtension = true;
                dialog.RestoreDirectory = true;
                dialog.Title = "Lưu File Tại";
                dialog.FileName = @"PhieuChi_" + DateTime.Now.ToString("yyyyMMddHHmmss");

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    wb.SaveAs(dialog.FileName);
                    MessageBox.Show("Đã xuất file tại :" + dialog.FileName);
                    dialog.Dispose();
                    dialog = null;
                }

                //Hết savedialog
            }

            //if (treeDanhMuc.Rows.Count <= 0) return;
            //var export = new FrmDmExportExcel("DOANHTHUNHACUNGCAP_" + DateTime.Now.ToString("ddMMyyyy_HHmm"),
            //    treeDanhMuc);
            //if (export.ShowDialog() == DialogResult.OK)
            //{
            //}
        }

        //==============================================================
        private void SelectNextTreeList(TreeListView dgv, bool isDown)
        {
            TreeListRow currRow = null;
            int index;
            try
            {
                currRow = dgv.SelectedElements[0] as TreeListRow;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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
                    return true;

                case Keys.F2:
                    txtNhaCungCap.Select();
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

        private enum TypeGetBill
        {
            GetTop10,
            GetTop50,
            GetByTime,
            GetAll
        }
    }
}