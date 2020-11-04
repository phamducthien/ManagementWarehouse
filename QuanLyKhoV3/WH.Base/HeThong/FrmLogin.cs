using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using MetroUI.Forms;
using Service.Pattern;
using WH.Service.Service;

namespace WH.Base.UI.HeThong
{
    public partial class FrmLogin : KryptonForm
    {
        private readonly List<KryptonTextBox> _listKryptonTextBox;
        private readonly BaseForm _baseForm;
        public bool IsSuccessful { get; set; }
        public FrmLogin()
        {
            InitializeComponent();
            _listKryptonTextBox = gbxInfo.Panel.Controls.OfType<KryptonTextBox>().ToList();
            foreach (KryptonTextBox txt in _listKryptonTextBox)
            {
                txt.Enter += txt_Enter;
                txt.Leave += txt_Leave;
                txt.KeyPress += txt_KeyPress;
            }
            _baseForm = new BaseForm();
            IsSuccessful = false;
            txtPass.Text = "123456";
            txtUser.Text = "ADMIN1";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ActionLogin();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void txt_Enter(object sender, EventArgs e)
        {
            UiHelper.txt_Enter(sender, e);
        }

        private void txt_Leave(object sender, EventArgs e)
        {
            UiHelper.txt_Leave(sender, e);
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            var txt = sender as KryptonTextBox;
            int count = _listKryptonTextBox.Count - 1;

            if (count > 0)
            {

                for (int i = 0; i < count; i++)
                {
                    if (txt != null && txt.Name == _listKryptonTextBox[i].Name)
                        UiHelper.txt_KeyPress(sender, _listKryptonTextBox[i + 1], e);
                }
            }

            if (txt != null && txt.Name == txtPass.Name)
                UiHelper.txt_KeyPress(sender, btnLuu, e);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            return CmdKey(keyData);
        }

        private bool CmdKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:
                   btnLuu.PerformClick();
                    return true;

                case Keys.Escape:
                    btnHuy.PerformClick();
                    return true;
            }
            return false;
        }

        private void ActionLogin()
        {
            _baseForm.ReloadUnitOfWork();
            ISessionService service = new SessionService(_baseForm.UnitOfWorkAsync);
            string username = txtUser.Text.Trim();
            string password = txtPass.Text.Trim();
            MethodResult result = service.Login(username, password);
            if (result != MethodResult.Succeed)
            {
                _baseForm.ShowMessage(IconMessageBox.Error, service.ErrMsg);
                UiHelper.LoadFocus(txtPass);
                return;
                //Environment.Exit(0);
            }
            IsSuccessful = true;
            Close();
        }
    }
}
