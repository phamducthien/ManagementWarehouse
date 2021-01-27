using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WH.Entity;
using WH.Service;
using WH.Service.Repository.Core;

namespace WH.Report.ReportForm
{
    public partial class frmChiTietHoaDonNhapHang : Form
    {
        private IUnitOfWorkAsync unitOfWorkAsync;

        public frmChiTietHoaDonNhapHang(HOADONNHAPKHO hdNhapKho, List<HOADONHAPKHOCHITIET> lsthdXuatKhoChiTiet)
        {
            InitializeComponent();

            if (hdNhapKho != null && lsthdXuatKhoChiTiet != null)
            {
                lblNgayTaoHoaDon.Text = hdNhapKho.NGAYTAOHOADON?.ToString("dd/MM/yyyy HH:mm:ss");
                lblTenKhachHang.Text = hdNhapKho.NHACUNGCAP?.TENNHACUNGCAP;
                labTongTien.Values.ExtraText = hdNhapKho.SOTIENTHANHTOAN_HD.ToString();
                txtTienChi.Text = hdNhapKho.SOTIENCHI.ToString();
                txtGhiChu.Text = hdNhapKho.GHICHU_HD;

                ReloadUnitOfWork();
                INhapKhoService service = new NhapKhoService(unitOfWorkAsync);
                var dt = service.DanhSachChiTietNhap(hdNhapKho.MAHOADONNHAP);

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
