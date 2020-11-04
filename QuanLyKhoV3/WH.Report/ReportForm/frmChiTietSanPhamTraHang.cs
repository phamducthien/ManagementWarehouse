using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Repository.Pattern.UnitOfWork;
using WH.Service;
using WH.Service.Repository.Core;

namespace WH.Report.ReportForm
{
    public partial class frmChiTietSanPhamTraHang : Form
    {
        private IUnitOfWorkAsync _unitOfWorkAsync;

        public frmChiTietSanPhamTraHang(DateTime batdau, DateTime KetThuc, string ID)
        {
            InitializeComponent();

            if (ID != null)
            {
                ReloadUnitOfWork();
                INhapXuatService service = new NhapXuatService(_unitOfWorkAsync);
                var dt = service.DanhSachGetListMatHangTheoNgay(batdau, KetThuc, Convert.ToInt32(ID));
                dgvHoaDon.DataSource = null;
                dgvHoaDon.AutoGenerateColumns = false;
                dgvHoaDon.DataSource = dt;

                CalBill(dt);
            }
            else
            {
                MessageBox.Show("Sản phầm này không tồn tại. Vui lòng chọn lại hóa đơn mới.");
            }
        }

        private void ReloadUnitOfWork()
        {
            _unitOfWorkAsync?.Dispose();
            _unitOfWorkAsync = null;
            _unitOfWorkAsync = UnitOfWorkFactory.MakeUnitOfWork();
        }

        private void CalBill(DataTable data)
        {
            if (data != null && data.Rows.Count > 0)
            {
                var sum = data.AsEnumerable().Sum(dr => dr.Field<decimal>("THANHTIEN"));
                var sSum = @" -> Tiền hoàn trả: " + sum.ToString("N");
                txtTienChi.Text = sSum;
            }
            else
            {
                txtTienChi.Text = @"Không có dữ liệu!";
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

 
    }
}