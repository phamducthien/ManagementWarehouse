using System;
using System.Windows.Forms;
using WH.Service;

namespace WH.GUI
{
    public partial class FrmCauHinhKetNoi : FrmBase
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
            var sServer = txtMayChu.Text;
            var sDatabase = txtDuLieu.Text;
            var sUserName = txtTaiKhoan.Text;
            var sPass = txtMatKhau.Text;
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
                var bKq = service.WriteConfig(model);
                if (!bKq)
                {
                    _baseForm.ShowMessage(IconMessageBox.Information, @"Thông tin cấu hình không phù hợp");
                }
                else
                {
                    _baseForm.ShowMessage(IconMessageBox.Information,
                        "Cấu hình kết nối thành công!\nchương trình sẽ tự động đóng lại!!!");
                    Application.Restart(); //Environment.Exit(0);
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

        private void txtMayChu_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
