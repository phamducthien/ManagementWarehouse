using System;
using System.Windows.Forms;
using Util.Pattern.Contain;
using WH.GUI.ExportWarehouse;
using WH.GUI.ReturnGoodsSupplier;
using WH.Model;
using WH.Report;

namespace WH.GUI
{
    public partial class FrmMain : FrmBase
    {
        public FrmMain()
        {
            InitializeComponent();
            Load += FrmMain_Load;
            btnThoat.Click += BtnThoat_Click;
            btnMatHang.Click += BtnMatHang_Click;
            btnCauHinhKetNoi.Click += BtnCauHinhKetNoi_Click;
            btnDoiTac.Click += BtnDoiTac_Click;
            btnXuatKho.Click += BtnXuatKho_Click;
            btnNhapKho.Click += BtnNhapKho_Click;
            btnBaoCao.Click += BtnBaoCao_Click;
            btnDanhMuc.Click += BtnDanhMuc_Click;
            btnKiemKe.Click += BtnKiemKe_Click;
            btnTraHang.Click += BtnTraHang_Click;
            btnListExportWarehouse.Click += btnListExportWarehouse_Click;
            btnThncc.Click += btnThncc_Click;
        }

        private void BtnTraHang_Click(object sender, EventArgs e)
        {
            if (CheckQuyen("XUẤT KHO - BÁN HÀNG"))
            {
                Hide();
                var frm = new FrmTraHang();
                frm.ShowDialog();
                Show();
                Activate();
            }
        }

        private bool ActionCheckLogin()
        {
            var frm = new FrmLogin();
            frm.ShowDialog(this);
            if (!frm.IsSuccessful) Environment.Exit(0);
            return frm.IsSuccessful;
        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            //foreach (UserControl u in grpMainApp.Panel.Controls.OfType<UserControl>())
            //{
            //    u.Size = grpMainApp.Panel.Size;
            //    u.ResumeLayout(true);
            //}
        }

        #region Events

        private void BtnKiemKe_Click(object sender, EventArgs e)
        {
            //foreach (UserControl u in grpMainApp.Panel.Controls.OfType<UserControl>())
            //{
            //    u.Dispose();
            //}
            //FrmKiemKeKhoiTao frm = new FrmKiemKeKhoiTao();
            //frm.ShowDialog();
        }

        private void BtnDoiTac_Click(object sender, EventArgs e)
        {
            if (CheckQuyen("ĐỐI TÁC"))
            {
                Hide();
                var frm = new FrmKhachHang();
                frm.ShowDialog();
                Show();
                Activate();
            }
        }

        private void BtnMatHang_Click(object sender, EventArgs e)
        {
            if (CheckQuyen("MẶT HÀNG"))
            {
                Hide();
                var frm = new FrmMatHang();
                frm.ShowDialog();
                Show();
                Activate();
            }
        }

        private void BtnXuatKho_Click(object sender, EventArgs e)
        {
            if (CheckQuyen("XUẤT KHO - BÁN HÀNG"))
            {
                var fc = Application.OpenForms;
                var isOpen = false;
                foreach (Form frm in fc)
                {
                    if (frm.Name != "FrmExportWarehouseTab") continue;
                    frm.Focus();
                    isOpen = true;
                }

                if (isOpen) return;
                {
                    Hide();
                    var frm = new FrmExportWarehouseTab();
                    frm.ShowDialog();
                    Show();
                    Activate();
                    var opacity = 0.00;
                    while (opacity < 1)
                    {
                        frm.Opacity = opacity;
                        opacity += 0.04;
                    }
                    frm.Opacity = 1.00;
                }
            }
        }

        private void BtnNhapKho_Click(object sender, EventArgs e)
        {
            if (CheckQuyen("NHẬP KHO"))
            {
                Hide();
                var frm = new FrmNhapKho();
                frm.ShowDialog();
                Show();
                Activate();
            }
        }

        private void BtnDanhMuc_Click(object sender, EventArgs e)
        {
            if (CheckQuyen("QUẢN LÝ CHUNG"))
            {
                Hide();
                var uc = new UrcQuanLyChung();
                var frm = new FrmUserControl(uc);
                frm.ShowDialog();
                Show();
                Activate();
            }
        }

        private void BtnCauHinhKetNoi_Click(object sender, EventArgs e)
        {
            if (CheckQuyen("QUẢN LÝ CHUNG"))
            {
            }
        }

        private void BtnBaoCao_Click(object sender, EventArgs e)
        {
            if (!CheckQuyen("BÁO CÁO")) return;

            Hide();
            var uc = new ucMain();
            var frm = new FrmUserControl(uc);
            frm.ShowDialog();
            Show();
            Activate();
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            StaticGlobalVariables.CheckTemps(false);
            Application.Exit();
        }

        private void btnListExportWarehouse_Click(object sender, EventArgs e)
        {
            var checkRole = CheckRole(Functions.XuatKhoBanHang, Role.QuyenSua);

            if (!checkRole) return;

            Hide();
            var frm = new FrmListExportWarehouse();
            frm.ShowDialog();
            Show();
            Activate();
        }

        private void btnThncc_Click(object sender, EventArgs e)
        {
            if (!CheckQuyen(Functions.XuatKhoBanHang)) return;

            Hide();
            var frm = new FrmReturnGoodsSupplier();
            frm.ShowDialog();
            Show();
            Activate();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Hide();
            try
            {
                var kq = ActionCheckLogin();
                if (kq)
                {
                    StaticGlobalVariables.CheckTemps(true);
                    labUsername.Text = SessionModel.CurrentSession.User.TENNGUOIDUNG.ToUpper();
                }
            }
            catch (Exception)
            {
            }

            // hide button list export Warehouse if do not have role
            var checkRole = CheckRole(Functions.XuatKhoBanHang, Role.QuyenSua);
            if (!checkRole)
            {
                btnListExportWarehouse.Visible = false;
            }

            // hide button Report if do not have role
            if (!CheckQuyen("BÁO CÁO"))
            {
                btnBaoCao.Visible = false;
            }

            // hide button Đối tác if do not have role
            if (!CheckQuyen("ĐỐI TÁC"))
            {
                btnDoiTac.Visible = false;
            }

            // hide button Mặt hàng if do not have role
            if (!CheckQuyen("MẶT HÀNG"))
            {
                btnMatHang.Visible = false;
            }

            // hide button Xuất Kho if do not have role
            if (!CheckQuyen("XUẤT KHO - BÁN HÀNG"))
            {
                btnXuatKho.Visible = false;
                btnTraHang.Visible = false;
            }

            // hide button Nhập Kho if do not have role
            if (!CheckQuyen("NHẬP KHO"))
            {
                btnNhapKho.Visible = false;
            }

            // hide button QUẢN LÝ CHUNG if do not have role
            if (!CheckQuyen("QUẢN LÝ CHUNG"))
            {
                btnDanhMuc.Visible = false;
            }

            Show();
            Activate();
        }

        #endregion
    }
}
