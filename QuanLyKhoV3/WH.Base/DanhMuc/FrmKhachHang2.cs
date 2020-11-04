using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using MetroUI.Forms;

namespace WH.Base.UI
{
    public partial class FrmKhachHang : MetroForm
    {
        public FrmKhachHang()
        {
            InitializeComponent();
        }

        #region Extends
        private void btnKhuVuc_Click(object sender, EventArgs e)
        {
            
        }

        private void btnUpTien_Click(object sender, EventArgs e)
        {
            numNoXauChoPhep.UpButton();
            numNoXauChoPhep.Select(numNoXauChoPhep.ToString().Length, 0);
        }

        private void btnDownTien_Click(object sender, EventArgs e)
        {
            numNoXauChoPhep.DownButton();
            numNoXauChoPhep.Select(numNoXauChoPhep.ToString().Length, 0);
        }

        private void btnUpNumber_Click(object sender, EventArgs e)
        {
            NumSoNgayNoXau.UpButton();
            NumSoNgayNoXau.Select(NumSoNgayNoXau.ToString().Length, 0);
        }

        private void btnDownNumber_Click(object sender, EventArgs e)
        {
            NumSoNgayNoXau.DownButton();
            NumSoNgayNoXau.Select(NumSoNgayNoXau.ToString().Length, 0);
        }
        #endregion
    }
}