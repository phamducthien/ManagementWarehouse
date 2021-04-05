using System;
using System.Linq;
using System.Windows.Forms;
using Util.Pattern;
using WH.Model;
using WH.Report.ReportForm;

namespace WH.Report
{
    public partial class ucMain : UserControl
    {
        public ucMain()
        {
            InitializeComponent();
            btnTienLai.Visible = SessionModel.CurrentSession.User.NGUOIDUNG_QUYENHAN.Count(s => s.QUYENXEM == true) == 6;
        }

        private void btnDoanhThu_KhachHang_Click(object sender, EventArgs e)
        {
            Hide();
            var frm = new FrmSelectDate();
            var frmKhachHang = new FrmSelectKhachHang();
            if (frm.ShowDialog() == DialogResult.OK)
                if (frmKhachHang.ShowDialog() == DialogResult.OK)
                {
                    var frm1 = new frmPhieuThuKhachHang(FrmSelectDate.DateFrom, FrmSelectDate.DateTo,
                        frmKhachHang.Model.CODEKHACHHANG);
                    frm1.ShowDialog();
                }
                else
                {
                    MessageBox.Show(@"Bạn cần chọn khách hàng trước.");
                }
            else
                MessageBox.Show(@"Bạn cần chọn ngày tháng trước.");

            Show();
            //btnDoanhThu_KhachHang.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Standalone;
        }

        private void btnDoanhThu_NCC_Click(object sender, EventArgs e)
        {
            Hide();
            var frm = new FrmSelectDate();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var frmNCC = new FrmSelectNhaCungCap();
                frmNCC.ShowDialog();
                if (!frmNCC.Model.isNull())
                {
                    var frm1 = new FrmDoanhThuNhaCungCap(FrmSelectDate.DateFrom, FrmSelectDate.DateTo,
                        frmNCC.Model.MANHACUNGCAP.ToString());
                    frm1.ShowDialog();
                }
                else
                {
                    MessageBox.Show(@"Bạn cần chọn NCC trước.");
                }
            }
            else
            {
                MessageBox.Show(@"Bạn cần chọn ngày tháng trước.");
            }

            Show();
        }

        private void btnCongNo_KhachHang_Click(object sender, EventArgs e)
        {
            Hide();
            var frm = new FrmCongNoKhangHang();
            frm.ShowDialog();
            Show();
        }

        private void btnCongNo_NCC_Click(object sender, EventArgs e)
        {
            Hide();
            var frm = new FrmCongNoNhaCungCap();
            frm.ShowDialog();
            Show();
        }

        private void btnSanPham_KhachHang_Click(object sender, EventArgs e)
        {
            Hide();
            var frm = new FrmSelectDate();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var frm1 = new frmChiTietBanSi(FrmSelectDate.DateFrom, FrmSelectDate.DateTo, true);
                frm1.ShowDialog();
            }

            Show();
        }

        private void btnTopDoanhThu_KhachHang_Click(object sender, EventArgs e)
        {
            Hide();
            var frm = new frmPosTopProfix(false);
            frm.ShowDialog();
            Show();
        }

        private void btnTopDoanhThu_POS_Click(object sender, EventArgs e)
        {
            Hide();
            var frm = new frmPosTopProfix(true);
            frm.ShowDialog();
            Show();
        }

        //Sư dung
        private void btnDoanhThu_POS_Click(object sender, EventArgs e)
        {
            Hide();
            //var frm = new frmPhieuThuKhachHang();
            //frm.ShowDialog();
            Show();
        }

        private void btnSanPham_POS_Click(object sender, EventArgs e)
        {
            Hide();
            var frm = new FrmSelectDate();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var frm1 = new frmChiTietBanLe(FrmSelectDate.DateFrom, FrmSelectDate.DateTo, true);
                frm1.ShowDialog();
            }

            Show();
        }

        private void btnSanPham_NCC_Click(object sender, EventArgs e)
        {
            Hide();
            var frm = new FrmSelectDate();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var frm1 = new frmChiTietBanLe(FrmSelectDate.DateFrom, FrmSelectDate.DateTo, false);
                frm1.ShowDialog();
            }

            Show();
        }

        private void btnHoaDon_NCC_Click(object sender, EventArgs e)
        {
        }

        private void btnHoaDonXuatKhachHang_Click(object sender, EventArgs e)
        {
        }

        private void btnHoaDonHangTra_Click(object sender, EventArgs e)
        {
            Hide();
            var frm = new frmHangTraKhachHang();
            frm.ShowDialog();
            Show();
        }

        private void btnSanPhamDaTra_Click(object sender, EventArgs e)
        {
            Hide();
            var frm = new FrmSelectDate();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var frm1 = new frmSanPhamHoanTra(FrmSelectDate.DateFrom, FrmSelectDate.DateTo);
                frm1.ShowDialog();
            }

            Show();
        }

        private void btnTienLai_Click(object sender, EventArgs e)
        {
            Hide();
            var frm = new FrmSelectDate();
            if (frm.ShowDialog() == DialogResult.OK)
            {

                var frm1 = new frmTienLai(FrmSelectDate.DateFrom, FrmSelectDate.DateTo);
                frm1.ShowDialog();
            }

            Show();
        }
    }
}
