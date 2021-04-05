using Repository.Pattern.UnitOfWork;
using System;
using System.Windows.Forms;
using WH.Service;
using WH.Service.Repository.Core;

namespace WH.Report.ReportForm
{
    public partial class frmChiTietHoaDonNhapXuat : Form
    {
        private IUnitOfWorkAsync unitOfWorkAsync;

        public frmChiTietHoaDonNhapXuat(string MaHoaDon, string TenKhachHang)
        {
            InitializeComponent();

            if (MaHoaDon != null)
            {
                ReloadUnitOfWork();
                INhapXuatService service = new NhapXuatService(unitOfWorkAsync);
                var model = service.Find(MaHoaDon);

                lblNgayTaoHoaDon.Text = model.NGAYTAOHOADON?.ToString("dd/MM/yyyy HH:mm:ss");
                lblTenKhachHang.Text = TenKhachHang;
                labTongTien.Values.ExtraText = model.SOTIENTHANHTOAN_HD.ToString();
                txtTienChi.Text = model.SOTIENKHACHDUA_HD.ToString();
                txtGhiChu.Text = model.GHICHU_HD;

                var dt = service.DanhSachChiTietNhapXuat(MaHoaDon);
                dgvHoaDon.DataSource = null;
                dgvHoaDon.AutoGenerateColumns = false;
                dgvHoaDon.DataSource = dt;
            }
            else
            {
                MessageBox.Show(@"Hóa đơn này không tồn tại. Vui lòng chọn lại hóa đơn mới.");
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
    }
}
