using ComponentFactory.Krypton.Toolkit;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WH.Service;

namespace WH.GUI
{
    public partial class FrmLogin : FrmBase
    {
        private readonly BaseForm _baseForm;
        private readonly List<KryptonTextBox> _listKryptonTextBox;

        public FrmLogin()
        {
            InitializeComponent();
            _listKryptonTextBox = gbxInfo.Panel.Controls.OfType<KryptonTextBox>().ToList();
            foreach (var txt in _listKryptonTextBox)
            {
                txt.Enter += txt_Enter;
                txt.Leave += txt_Leave;
                txt.KeyPress += txt_KeyPress;
            }

            _baseForm = new BaseForm();
            IsSuccessful = false;

            //txtPass.Text = "123456";
            //txtUser.Text = "ADMIN";
        }

        public bool IsSuccessful { get; set; }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ActionLogin();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
            //Environment.Exit(0);
        }

        private new void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            var txt = sender as KryptonTextBox;
            var count = _listKryptonTextBox.Count - 1;

            if (count > 0)
                for (var i = 0; i < count; i++)
                    if (txt != null && txt.Name == _listKryptonTextBox[i].Name)
                        UiHelper.txt_KeyPress(sender, _listKryptonTextBox[i + 1], e);

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
            var username = txtUser.Text.Trim();
            var password = txtPass.Text.Trim();
            var result = service.Login(username, password);
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
