using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using WH.Base.UI.HeThong;
using WH.Base.UI.Main;
using WH.Base.UI.NghiepVu;
using WH.Model;

namespace WH.Base.UI
{
    public partial class FrmMain : KryptonForm
    {
        private readonly BaseForm _baseForm;
        public FrmMain()
        {
            InitializeComponent();
            _baseForm = new BaseForm();
            this.Load += FrmMain_Load;
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
            FrmLogin frm = new FrmLogin();
            frm.ShowDialog(this);
            return frm.IsSuccessful;
        }
        #region Events
        private void BtnKiemKe_Click(object sender, EventArgs e)
        {
            foreach (UserControl u in grpMainApp.Panel.Controls.OfType<UserControl>())
            {
                u.Dispose();
            }
            //FrmKiemKeKhoiTao frm = new FrmKiemKeKhoiTao();
            //frm.ShowDialog();
        }
        private void BtnDoiTac_Click(object sender, EventArgs e)
        {
            foreach (UserControl u in grpMainApp.Panel.Controls.OfType<UserControl>())
            {
                u.Dispose();
            }
            FrmKhachHang frm = new FrmKhachHang();
            frm.ShowDialog();
        }

        private void BtnMatHang_Click(object sender, EventArgs e)
        {
            foreach (UserControl u in grpMainApp.Panel.Controls.OfType<UserControl>())
            {
                u.Dispose();
            }
            FrmMatHang frm = new FrmMatHang();
            frm.Activate();
            frm.ShowDialog();
        }

        private void BtnXuatKho_Click(object sender, EventArgs e)
        {
           // throw new NotImplementedException();
        }

        private void BtnNhapKho_Click(object sender, EventArgs e)
        {
           // throw new NotImplementedException();
        }

        private void BtnDanhMuc_Click(object sender, EventArgs e)
        {
            foreach (UserControl u in grpMainApp.Panel.Controls.OfType<UserControl>())
            {
                u.Dispose();
            }
            var uc = new UrcQuanLyChung { Size = grpMainApp.Panel.Size };
            grpMainApp.Panel.Controls.Add(uc);
            uc.ResumeLayout(true);
        }

        private void BtnCauHinhKetNoi_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnBaoCao_Click(object sender, EventArgs e)
        {
            foreach (UserControl u in grpMainApp.Panel.Controls.OfType<UserControl>())
            {
                u.Dispose();
            }
            var uc = new UrcBaoCao()
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
            this.Hide();
            bool kq = ActionCheckLogin();
            if (kq)
            {
                StaticGlobalVariables.CheckTemps(true);
                //FrmFlash.ShowSplash();
                //Application.DoEvents();
                //btnDanhMuc.PerformClick();
                //FrmFlash.CloseSplash();
            }
            this.Show();
        }

        #endregion

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            foreach (UserControl u in grpMainApp.Panel.Controls.OfType<UserControl>())
            {
                u.Size = grpMainApp.Panel.Size;
                u.ResumeLayout(true);
            }
        }
    }
}
