using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WH.Entity;
using WH.Service;
using WH.Service.Repository.Core;

namespace WH.Report.ReportForm
{
    public partial class frmChiTietHoaDonBanHang : Form
    {
        private IUnitOfWorkAsync unitOfWorkAsync;

        public frmChiTietHoaDonBanHang(HOADONXUATKHO hdXuatKho, List<HOADONXUATKHOCHITIET> lsthdXuatKhoChiTiet)
        {
            InitializeComponent();

            if (hdXuatKho != null && lsthdXuatKhoChiTiet != null)
            {
                lblNgayTaoHoaDon.Text = hdXuatKho.NGAYTAOHOADON?.ToString("dd/MM/yyyy");
                lblTenKhachHang.Text = hdXuatKho.KHACHHANG?.TENKHACHHANG;
                labTongTien.Values.ExtraText = hdXuatKho.SOTIENTHANHTOAN_HD.ToString();
                txtTienChi.Text = hdXuatKho.SOTIENKHACHDUA_HD.ToString();
                txtGhiChu.Text = hdXuatKho.GHICHU_HD;

                ReloadUnitOfWork();
                IXuatKhoService service = new XuatKhoService(unitOfWorkAsync);
                var dt = service.DanhSachChiTietXuat(hdXuatKho.MAHOADONXUAT);
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
