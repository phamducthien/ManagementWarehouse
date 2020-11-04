using System;
using System.Linq;
using System.Windows.Forms;
using WH.Model;
using WH.Report;

namespace WH.GUI
{
    public partial class FrmMain1 : FrmBase
    {
        private readonly BaseForm _baseForm;

        public FrmMain1()
        {
            InitializeComponent();
            _baseForm = new BaseForm();
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
        }


        private bool ActionCheckLogin()
        {
            var frm = new FrmLogin();
            frm.ShowDialog(this);
            return frm.IsSuccessful;
        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            foreach (var u in grpMainApp.Panel.Controls.OfType<UserControl>())
            {
                u.Size = grpMainApp.Panel.Size;
                u.ResumeLayout(true);
            }
        }

        #region Events

        private void BtnKiemKe_Click(object sender, EventArgs e)
        {
            foreach (var u in grpMainApp.Panel.Controls.OfType<UserControl>()) u.Dispose();
            //FrmKiemKeKhoiTao frm = new FrmKiemKeKhoiTao();
            //frm.ShowDialog();
        }

        private void BtnDoiTac_Click(object sender, EventArgs e)
        {
            foreach (var u in grpMainApp.Panel.Controls.OfType<UserControl>()) u.Dispose();
            var frm = new FrmKhachHang();
            frm.ShowDialog();
        }

        private void BtnMatHang_Click(object sender, EventArgs e)
        {
            foreach (var u in grpMainApp.Panel.Controls.OfType<UserControl>()) u.Dispose();
            var frm = new FrmMatHang();
            frm.Activate();
            frm.ShowDialog();
        }

        private void BtnXuatKho_Click(object sender, EventArgs e)
        {
            var frm = new FrmXuatKho();
            frm.ShowDialog();
        }

        private void BtnNhapKho_Click(object sender, EventArgs e)
        {
            var frm = new FrmNhapKho();
            frm.ShowDialog();
        }

        private void BtnDanhMuc_Click(object sender, EventArgs e)
        {
            foreach (var u in grpMainApp.Panel.Controls.OfType<UserControl>()) u.Dispose();
            var uc = new UrcQuanLyChung {Size = grpMainApp.Panel.Size};
            grpMainApp.Panel.Controls.Add(uc);
            uc.ResumeLayout(false);
        }

        private void BtnCauHinhKetNoi_Click(object sender, EventArgs e)
        {
        }

        private void BtnBaoCao_Click(object sender, EventArgs e)
        {
            foreach (var u in grpMainApp.Panel.Controls.OfType<UserControl>()) u.Dispose();
            var uc = new ucMain
            {
                Size = grpMainApp.Panel.Size
            };
            grpMainApp.Panel.Controls.Add(uc);
            uc.ResumeLayout(true);
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            StaticGlobalVariables.CheckTemps(false);
            Close();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Hide();
            var kq = ActionCheckLogin();
            if (kq) StaticGlobalVariables.CheckTemps(true);
            Show();
        }

        #endregion
    }
}