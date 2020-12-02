﻿using ComponentFactory.Krypton.Navigator;
using ComponentFactory.Krypton.Toolkit;
using System.Windows.Forms;

namespace WH.GUI.ExportWarehouse
{
    public partial class FrmExportWarehouseTab : Form
    {
        public FrmExportWarehouseTab()
        {
            InitializeComponent();
            AddNewTab();
            kryptonNavExportWarehouse.Pages.Inserted += OnPageInsertRemove;
            kryptonNavExportWarehouse.Pages.Removed += OnPageInsertRemove;
        }

        private void AddNewTab()
        {
            var kryptonPage = new KryptonPage { Text = "Đơn hàng" };
            kryptonPage.AutoScroll = true;
            kryptonPage.Dock = DockStyle.Fill;
            kryptonPage.AutoSize = true;
            kryptonPage.AutoSizeMode = AutoSizeMode.GrowOnly;
            //kryptonPage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Left;

            var frmExportWarehouse = new FrmXuatKho
            {
                TopLevel = false,
                Visible = true,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowOnly
            };
            kryptonPage.Controls.Add(frmExportWarehouse);

            kryptonNavExportWarehouse.Pages.Add(kryptonPage);
            kryptonNavExportWarehouse.SelectedPage = kryptonPage;

            frmExportWarehouse.Show();
        }

        private void btnAddExportWarehouse_Click(object sender, System.EventArgs e)
        {
            AddNewTab();
        }

        void OnPageInsertRemove(object sender, TypedCollectionEventArgs<KryptonPage> e)
        {
            UpdateButtonState();
        }

        private void UpdateButtonState()
        {
            // Can only remove if a page is selected
            btnRemove.Enabled = (kryptonNavExportWarehouse.SelectedPage != null);
        }

        private void btnRemove_Click(object sender, System.EventArgs e)
        {
            kryptonNavExportWarehouse.Pages.Remove(kryptonNavExportWarehouse.SelectedPage);
        }
    }
}
