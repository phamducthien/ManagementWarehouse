using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Repository.Pattern.UnitOfWork;
using Util.Pattern.Encryptor;
using WH.GUI.Properties;
using WH.Model;
using WH.Service.Repository.Core;

namespace WH.GUI
{
    public partial class usrcBase : UserControl
    {
        protected readonly string UserId = SessionModel.CurrentSession?.UserId;

        protected string keyEncrypt = "G8_4<A~!7X_tL04";
        protected IUnitOfWorkAsync UnitOfWorkAsync;

        protected usrcBase()
        {
            InitializeComponent();
            //this.Dock = DockStyle.Fill;
        }

        protected KryptonDataGridView DgView { get; set; }
        public DataGridViewRow CurrentRow { get; set; }
        protected KryptonGroupBox GbxList { get; set; }
        public bool IsSuccessfuly { get; set; }
        protected string ErrMsg { get; set; }
        protected bool IsSelect { get; set; }


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

        protected void ReloadUnitOfWork()
        {
            UnitOfWorkAsync?.Dispose();
            UnitOfWorkAsync = null;
            UnitOfWorkAsync = UnitOfWorkFactory.MakeUnitOfWork();
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

        protected void LoadData(DataTable list)
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

        protected void LoadData<T>(IEnumerable<T> list)
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

        protected void btnUp_Click(object sender, EventArgs e)
        {
            var btn = (Button) sender;
            var parent = btn.Parent;
            var numeric =
                parent.Controls.OfType<KryptonNumericUpDown>().FirstOrDefault(s => Equals(s.Name, (string) btn.Tag));
            if (numeric != null)
            {
                numeric.UpButton();
                numeric.Select(numeric.ToString().Length, 0);
            }
        }

        protected void btnDown_Click(object sender, EventArgs e)
        {
            var btn = (Button) sender;
            var parent = btn.Parent;
            var numeric =
                parent.Controls.OfType<KryptonNumericUpDown>().FirstOrDefault(s => Equals(s.Name, (string) btn.Tag));
            if (numeric != null)
            {
                numeric.DownButton();
                numeric.Select(numeric.ToString().Length, 0);
            }
        }

        #region PnlLoad

        protected PictureBox ptbLoad;
        protected Label labMessage;
        protected KryptonPanel pnlLoad;

        protected void LoadShowSplash()
        {
            ptbLoad = new PictureBox();
            labMessage = new Label();
            pnlLoad = new KryptonPanel();
            ((ISupportInitialize) ptbLoad).BeginInit();
            ((ISupportInitialize) pnlLoad).BeginInit();
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
            ((ISupportInitialize) ptbLoad).EndInit();
            ((ISupportInitialize) pnlLoad).EndInit();
            Controls.Add(pnlLoad);
            pnlLoad.ResumeLayout(true);
            ResumeLayout(true);
        }

        protected void ShowLoad()
        {
            LoadShowSplash();
            GbxList.Visible = false;
            pnlLoad.Visible = true;
        }

        protected void CloseLoad()
        {
            GbxList.Visible = true;
            pnlLoad.Visible = false;
        }

        #endregion
    }
}