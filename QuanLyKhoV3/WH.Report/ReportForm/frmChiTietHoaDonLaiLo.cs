using Repository.Pattern.UnitOfWork;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Util.Pattern;
using WH.Model;
using WH.Service.Repository.Core;

namespace WH.Report.ReportForm
{
    public partial class frmChiTietHoaDonLaiLo : Form
    {
        private IUnitOfWorkAsync unitOfWorkAsync;

        public frmChiTietHoaDonLaiLo(PriceCalculateModelCollection collection)
        {
            InitializeComponent();

            if (collection != null)
            {
                lblNgayTaoHoaDon.Text = collection.NgayLap.ToString("dd/MM/yyyy HH:mm:ss");
                lblTenKhachHang.Text = collection.TenKhachHang;
                labTongTien.Values.ExtraText = collection.ThanhTienSauChietKhau.ToString();
                labTongTienNhap.Values.ExtraText = collection.ThanhTienNhap.ToString();
                txtTienLai.Text = collection.TienLai_HD.ToString();
                pictureTrangThai.Image = collection.HinhAnhDanhGia_HD;

                DataTable dt = null;
                try
                {
                    dt = collection.Collection.OrderBy(s => s.GhiChu_CT.ToInt()).ToDatatable();
                }
                catch (Exception e)
                {
                    dt = collection.Collection.OrderBy(s => s.GhiChu_CT).ToDatatable();
                }

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
