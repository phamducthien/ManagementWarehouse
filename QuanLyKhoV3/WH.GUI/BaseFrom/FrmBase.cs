using ComponentFactory.Krypton.Toolkit;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Util.Pattern;
using Util.Pattern.Encryptor;
using WH.GUI.Properties;
using WH.Model;
using WH.Service.Repository.Core;

namespace WH.GUI
{
    public partial class FrmBase : KryptonForm
    {
        protected readonly string UserId = SessionModel.CurrentSession?.UserId;
        private string keyEncrypt = "G8_4<A~!7X_tL04";
        private bool MbLayoutCalled;

        protected DateTime MDt;
        //protected readonly BaseForm BaseForm;

        protected Control TxtMacDinh;
        protected IUnitOfWorkAsync UnitOfWorkAsync;

        protected FrmBase()
        {
            InitializeComponent();
            //CheckQuyen();
        }

        protected ThaoTac ThaoTac { get; set; }
        protected DataGridViewRow CurrentRow { get; set; }
        protected DataGridViewRow CurrentRow2 { get; set; }

        protected bool IsSelect { get; set; }
        protected bool IsSelect2 { get; set; }

        public bool IsSuccessfully { get; set; }
        protected string ErrMsg { get; set; }
        public bool IsChange { get; set; }
        protected string VietNamMsg { get; set; }
        protected string EnglishMsg { get; set; }
        protected bool IsVietNamLanguage { get; set; }
        protected KryptonCheckButton BtnLuu { get; set; }
        protected KryptonTextBox TxtSearch { get; set; }
        protected KryptonDataGridView DgView { get; set; }
        protected KryptonDataGridView DgView2 { get; set; }
        protected KryptonForm Frm { get; set; }
        protected KryptonGroupBox GbxInfo { get; set; }
        protected KryptonGroupBox GbxList { get; set; }
        protected KryptonSplitContainer SplitContainer { get; set; }
        protected KryptonPanel PnlMenu { get; set; }

        protected string Encrypt(string input)
        {
            return StringCryptographyUtil.Encrypt(input, keyEncrypt);
        }

        protected string Decrypt(string input)
        {
            try
            {
                return StringCryptographyUtil.Decrypt(input, keyEncrypt);
            }
            catch
            {
                return "";
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool MessageBeep(uint type);

        private void FrmBase_Layout(object sender, LayoutEventArgs e)
        {
            if (MbLayoutCalled) return;
            MbLayoutCalled = true;
            MDt = DateTime.Now;
            SplashScreenChild.CloseForm();
            ResumeLayout(true);
            MessageBeep(0);
            Activate();
        }

        protected void txt_Enter(object sender, EventArgs e)
        {
            UiHelper.txt_Enter(sender, e);
        }

        protected void txt_Leave(object sender, EventArgs e)
        {
            UiHelper.txt_Leave(sender, e);
        }

        protected void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            var txt = sender as KryptonTextBox;
            if (txt != null)
            {
                var parent = txt.Parent;
                var listKryptonTextBox = parent.Controls.OfType<KryptonTextBox>().ToList();
                var count = listKryptonTextBox.Count - 1;

                if (count > 0)
                    for (var i = 0; i < count; i++)
                        if (txt.Name == listKryptonTextBox[i].Name)
                            UiHelper.txt_KeyPress(sender, listKryptonTextBox[i + 1], e);

                if (txt.Name == listKryptonTextBox[count].Name)
                    if (BtnLuu != null)
                        UiHelper.txt_KeyPress(sender, BtnLuu, e);
            }

            if (txt != null && txt.Name == TxtSearch.Name)
                UiHelper.txt_KeyPress(sender, TxtSearch, e);
        }

        protected void btnUp_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var parent = btn.Parent;
            var numeric =
                parent.Controls.OfType<KryptonNumericUpDown>().FirstOrDefault(s => Equals(s.Name, (string)btn.Tag));
            if (numeric != null)
            {
                numeric.UpButton();
                numeric.Select(numeric.ToString().Length, 0);
            }
        }

        protected void btnDown_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var parent = btn.Parent;
            var numeric =
                parent.Controls.OfType<KryptonNumericUpDown>().FirstOrDefault(s => Equals(s.Name, (string)btn.Tag));
            if (numeric != null)
            {
                numeric.DownButton();
                numeric.Select(numeric.ToString().Length, 0);
            }
        }

        protected void SelectedRow(DataGridViewRow rowData)
        {
            if (rowData == null) return;
            if (DgView.RowCount <= 0) return;
            DgView.Rows[rowData.Index].Selected = true;
            DgView.FirstDisplayedScrollingRowIndex = rowData.Index;
            DgView.Refresh();
        }

        protected void ReloadUnitOfWork()
        {
            UnitOfWorkAsync?.Dispose();
            UnitOfWorkAsync = null;
            UnitOfWorkAsync = UnitOfWorkFactory.MakeUnitOfWork();
        }

        protected DialogResult ShowMessage(IconMessageBox typeBox, string message)
        {
            var result = DialogResult.None;
            switch (typeBox)
            {
                case IconMessageBox.Information:
                    MsgBox.Show(message, IsVietNamLanguage ? "Thông Báo" : "Notice", MsgBox.Buttons.Ok,
                        MsgBox.IconMsgBox.Info);
                    break;

                case IconMessageBox.Warning:
                    MsgBox.Show(message, IsVietNamLanguage ? "Thông Báo" : "Notice", MsgBox.Buttons.Ok,
                        MsgBox.IconMsgBox.Warning);
                    break;

                case IconMessageBox.Error:
                    MsgBox.Show(message, IsVietNamLanguage ? "Thông Báo" : "Notice", MsgBox.Buttons.Ok,
                        MsgBox.IconMsgBox.Error);
                    break;

                case IconMessageBox.Question:
                    result = MsgBox.Show(message, IsVietNamLanguage ? "Thông Báo" : "Notice", MsgBox.Buttons.YesNo,
                        MsgBox.IconMsgBox.Question);
                    break;
            }

            return result;
        }

        protected void SetTextReadOnly(bool isReadOnly)
        {
            foreach (var obj in GbxInfo.Panel.Controls.OfType<Control>()
                .Where(obj => !(obj is KryptonTextBox) && !(obj is KryptonCheckButton))) obj.Enabled = !isReadOnly;

            TxtSearch.ReadOnly = !isReadOnly;
            foreach (var btn in TxtSearch.ButtonSpecs)
                btn.Enabled = isReadOnly ? ButtonEnabled.True : ButtonEnabled.False;

            foreach (var obj in GbxInfo.Panel.Controls.OfType<KryptonTextBox>())
            {
                obj.ReadOnly = isReadOnly || obj.ButtonSpecs.Count > 0;
                foreach (var btn in obj.ButtonSpecs)
                    btn.Enabled = isReadOnly ? ButtonEnabled.False : ButtonEnabled.True;
            }

            foreach (var obj in GbxInfo.Panel.Controls.OfType<KryptonDataGridView>()) obj.Enabled = true;
        }

        protected void SetDataDefault()
        {
            foreach (var obj in GbxInfo.Panel.Controls.OfType<KryptonTextBox>()) obj.Text = string.Empty;

            foreach (var obj in GbxInfo.Panel.Controls.OfType<KryptonNumericUpDown>()) obj.Value = obj.Minimum;

            foreach (var obj in GbxInfo.Panel.Controls.OfType<KryptonCheckBox>()) obj.CheckState = CheckState.Checked;

            foreach (var obj in GbxInfo.Panel.Controls.OfType<KryptonCheckButton>()) obj.Checked = false;

            TxtSearch.Select();
            ThaoTac = ThaoTac.Xem;
        }

        protected void SetStateButton(bool isButtonFunction)
        {
            foreach (var btn in GbxList.Panel.Controls.OfType<KryptonPanel>()
                .SelectMany(pnl => pnl.Controls.OfType<KryptonButton>())) btn.Enabled = isButtonFunction;
            foreach (var btn in GbxInfo.Panel.Controls.OfType<KryptonCheckButton>()) btn.Visible = !isButtonFunction;
        }

        protected void LoadData<T>(List<T> list)
        {
            try
            {
                IsSelect = false;
                DgView.AutoGenerateColumns = false;
                DgView.SuspendLayout();
                DgView.DataSource = list;
                DgView.Refresh();
                DgView.ResumeLayout(true);
                IsSelect = true;
            }
            catch (Exception exception)
            {
                ErrMsg = exception.Message;
            }
        }

        protected void LoadData2<T>(List<T> list)
        {
            try
            {
                IsSelect2 = false;
                DgView2.AutoGenerateColumns = false;
                DgView2.SuspendLayout();
                DgView2.DataSource = list;
                DgView2.Refresh();
                DgView2.ResumeLayout(false);
                IsSelect2 = true;
            }
            catch (Exception exception)
            {
                ErrMsg = exception.Message;
            }
        }

        protected void LoadData(DataTable list)
        {
            try
            {
                DgView.AutoGenerateColumns = false;
                DgView.SuspendLayout();
                IsSelect = false;
                DgView.DataSource = list;
                DgView.Refresh();
                DgView.ResumeLayout(false);
                IsSelect = true;
            }
            catch (Exception exception)
            {
                ErrMsg = exception.Message;
            }
        }

        protected void LoadData2(DataTable list)
        {
            try
            {
                IsSelect2 = false;
                DgView2.AutoGenerateColumns = false;
                DgView2.SuspendLayout();
                DgView2.DataSource = list;
                DgView2.Refresh();
                DgView2.ResumeLayout(true);
                IsSelect2 = true;
            }
            catch (Exception exception)
            {
                ErrMsg = exception.Message;
            }
        }

        private void FrmBase_Resize(object sender, EventArgs e)
        {
            //if (SplitContainer == null) return;
            //this.SplitContainer.Panel2MinSize = Width - SplitContainer.Panel1MinSize - 500;
        }

        protected void ShowLoad()
        {
            LoadShowSplash();
            if (SplitContainer != null)
                SplitContainer.Visible = false;
            //GbxList.Visible = false;
            pnlLoad.Visible = true;
            pnlLoad.BringToFront();
        }

        protected void CloseLoad()
        {
            if (SplitContainer != null)
                SplitContainer.Visible = true;
            //GbxList.Visible = true;
            // pnlLoad.Visible = false;
            pnlLoad?.Dispose();
        }

        protected bool CheckQuyen(string nameFunction = "")
        {
            var nameFrm = nameFunction;
            if (nameFunction.IsBlank()) nameFrm = Frm.Tag.ToString();

            var objNguoidungQuyenHan =
                SessionModel.CurrentSession.User.NGUOIDUNG_QUYENHAN.FirstOrDefault(
                    s => s.CHUCNANG.TENCHUCNANG == nameFrm);

            if (!objNguoidungQuyenHan?.QUYENXEM ?? false)
            {
                ShowMessage(IconMessageBox.Information,
                    "Bạn không có quyền truy cập " + nameFrm + ".\nVui lòng liên hệ ADMIN.");
                return false;
            }

            if (PnlMenu != null)
                foreach (var btn in PnlMenu.Controls.OfType<KryptonButton>())
                    switch (btn.Text)
                    {
                        case "Thêm":
                            btn.Visible = objNguoidungQuyenHan?.QUYENIN ?? false;
                            break;

                        case "Xóa":
                            btn.Visible = objNguoidungQuyenHan?.QUYENXOA ?? false;
                            break;

                        case "Sửa":
                            btn.Visible = objNguoidungQuyenHan?.QUYENSUA ?? false;
                            break;

                        case "Nhập":
                            btn.Visible = objNguoidungQuyenHan?.QUYENTIMKIEM ?? false;
                            break;

                        case "Xuất":
                            btn.Visible = objNguoidungQuyenHan?.QUYENXUATFILE ?? false;
                            break;
                    }
            return true;
        }

        protected static bool CheckRole(string function, string role)
        {
            if (string.IsNullOrWhiteSpace(function) || string.IsNullOrWhiteSpace(role))
            {
                return false;
            }

            var existFunctionRole =
                SessionModel.CurrentSession.User.NGUOIDUNG_QUYENHAN.First(
                    s => s.CHUCNANG.TENCHUCNANG == function);

            var result = false;
            switch (role)
            {
                case "QUYENIN":
                    result = (bool)existFunctionRole.QUYENIN;
                    break;

                case "QUYENXOA":
                    result = (bool)existFunctionRole.QUYENXOA;
                    break;

                case "QUYENSUA":
                    result = (bool)existFunctionRole.QUYENSUA;
                    break;

                case "QUYENTIMKIEM":
                    result = (bool)existFunctionRole.QUYENTIMKIEM;
                    break;

                case "QUYENXUATFILE":
                    result = (bool)existFunctionRole.QUYENXUATFILE;
                    break;
            }
            return result;
        }

        private void FrmBase_FormClosed(object sender, FormClosedEventArgs e)
        {
            Events.Dispose();
        }

        #region PnlLoad

        private PictureBox ptbLoad;
        private Label labMessage;
        private KryptonPanel pnlLoad;

        private void LoadShowSplash()
        {
            ptbLoad = new PictureBox();
            labMessage = new Label();
            pnlLoad = new KryptonPanel();
            ((ISupportInitialize)ptbLoad).BeginInit();
            ((ISupportInitialize)pnlLoad).BeginInit();
            pnlLoad.SuspendLayout();
            SuspendLayout();

            // 
            // ptbLoad
            // 
            ptbLoad.Image = Resources.Loader;
            ptbLoad.Name = "ptbLoad";
            ptbLoad.TabStop = false;
            ptbLoad.UseWaitCursor = true;
            // 
            // labMessage
            // 
            labMessage.BackColor = Color.Transparent;
            labMessage.ForeColor = Color.FromArgb(0, 64, 0);
            labMessage.Name = "labMessage";
            labMessage.UseWaitCursor = true;
            // 
            // pnlLoad
            // 
            pnlLoad.Controls.Add(labMessage);
            pnlLoad.Controls.Add(ptbLoad);
            pnlLoad.Name = "pnlLoad";
            pnlLoad.StateCommon.Color1 = Color.Transparent;
            pnlLoad.UseWaitCursor = true;
            //
            ((ISupportInitialize)ptbLoad).EndInit();
            ((ISupportInitialize)pnlLoad).EndInit();
            Controls.Add(pnlLoad);
            pnlLoad.ResumeLayout(true);
            ResumeLayout(true);
        }

        #endregion
    }
}
