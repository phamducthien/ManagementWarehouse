using ClosedXML.Excel;
using Repository.Pattern.UnitOfWork;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using WH.Service;
using WH.Service.Repository.Core;

namespace WH.Report.ReportForm
{
    public partial class frmChiTietSanPhamDaBan : Form
    {
        private IUnitOfWorkAsync unitOfWorkAsync;

        public frmChiTietSanPhamDaBan(DateTime batdau, DateTime KetThuc, string ID, string TongTien)
        {
            InitializeComponent();

            if (ID != null)
            {
                //lblNgayTaoHoaDon.Text = hdXuatKho.NGAYTAOHOADON?.ToString("dd/MM/yyyy");
                //lblTenKhachHang.Text = hdXuatKho.KHACHHANG?.TENKHACHHANG;
                //labTongTien.Values.ExtraText = hdXuatKho.SOTIENTHANHTOAN_HD.ToString();
                //txtTienChi.Text = hdXuatKho.SOTIENKHACHDUA_HD.ToString();
                //txtGhiChu.Text = hdXuatKho.GHICHU_HD;

                ReloadUnitOfWork();
                IXuatKhoService service = new XuatKhoService(unitOfWorkAsync);
                var dt = service.GetListMatHangTheoNgay(batdau, KetThuc, Convert.ToInt32(ID));
                dgvHoaDon.DataSource = null;
                dgvHoaDon.AutoGenerateColumns = false;
                dgvHoaDon.DataSource = dt;

                txtTienChi.Text = TongTien;
            }
            else
            {
                MessageBox.Show(@"Sản phầm này không tồn tại. Vui lòng chọn lại hóa đơn mới.");
            }
        }

        private void ReloadUnitOfWork()
        {
            if (unitOfWorkAsync != null) unitOfWorkAsync.Dispose();
            unitOfWorkAsync = null;
            unitOfWorkAsync = UnitOfWorkFactory.MakeUnitOfWork();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
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
                wb.Worksheets.Add(dt, "Danh Sách Hóa Đơn Đã Bán");

                //save file region here
                var dialog = new SaveFileDialog();
                dialog.InitialDirectory = folderPath;
                dialog.DefaultExt = "xlsx";
                dialog.Filter = "Excel WorkBook (*.xlsx)|*.xlsx";
                dialog.AddExtension = true;
                dialog.RestoreDirectory = true;
                dialog.Title = "Lưu File Tại";
                dialog.FileName = @"HoaDonDaBan" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";

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
    }
}
