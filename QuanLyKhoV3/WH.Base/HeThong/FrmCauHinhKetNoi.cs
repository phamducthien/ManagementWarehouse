using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MetroUI.Forms;
using Util.Pattern;
using WH.Service.Service;

namespace WH.Base.UI
{
    public partial class FrmCauHinhKetNoi : MetroForm
    {
        private readonly BaseForm _baseForm;
        public FrmCauHinhKetNoi()
        {
            InitializeComponent();
            _baseForm = new BaseForm();
            fn_LoadThongSo();
        }

        private void fn_LoadThongSo()
        {
            IConfigurationService service = new ConfigurationService();
            var model = service.ReadConfig();
            txtMayChu.Text = model.Server;
            txtTaiKhoan.Text = model.UserName;
            txtMatKhau.Text = model.PlainPassword;
            txtDuLieu.Text = model.DbName;
        }

        private void fn_SaveThongSo()
        {
            IConfigurationService service = new ConfigurationService();
            string sServer = txtMayChu.Text;
            string sDatabase = txtDuLieu.Text;
            string sUserName = txtTaiKhoan.Text;
            string sPass = txtMatKhau.Text;
            if (sServer == "" || sDatabase == "" || sUserName == "" || sPass == "")
            {
                MessageBox.Show(@"Vui lòng điền đầy đủ thông tin");
                return;
            }
            try
            {
                var model = service.ReadConfig();
                model.DbName = sDatabase;
                model.Server = sServer;
                model.UserName = sUserName;
                model.PlainPassword = sPass;
                bool bKq = service.WriteConfig(model);
                if (!bKq)
                {
                    _baseForm.ShowMessage(IconMessageBox.Information,@"Thông tin cấu hình không phù hợp");
                }
                else
                {
                    _baseForm.ShowMessage(IconMessageBox.Information, "Cấu hình kết nối thành công!\nchương trình sẽ tự động đóng lại!!!");
                    Application.Restart();//Environment.Exit(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            fn_SaveThongSo();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}