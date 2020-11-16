using ComponentFactory.Krypton.Navigator;
using ComponentFactory.Krypton.Toolkit;
using System.Drawing;
using System.Windows.Forms;

namespace WH.GUI.ExportWarehouse
{
    public partial class FrmExportWarehouseTab : Form
    {
        public FrmExportWarehouseTab()
        {
            InitializeComponent();
            AddNewTab();
            tabExportWarehouse.Pages.Inserted += OnPageInsertRemove;
            tabExportWarehouse.Pages.Removed += OnPageInsertRemove;
        }

        private void AddNewTab()
        {
            var newPage = new KryptonPage
            {
                Text = "Đơn hàng"
            };

            var frmExportWarehouse = new FrmXuatKho
            {
                TopLevel = false,
                Dock = DockStyle.Fill,
                WindowState = FormWindowState.Maximized,
                Size = new Size(100, 100),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };

            frmExportWarehouse.Show();

            // Add form to tab
            newPage.Controls.Add(frmExportWarehouse);

            // Append to end of the pages collection
            tabExportWarehouse.Pages.Add(newPage);

            // Select the new page
            tabExportWarehouse.SelectedPage = newPage;
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
            btnRemove.Enabled = (tabExportWarehouse.SelectedPage != null);
        }

        private void btnRemove_Click(object sender, System.EventArgs e)
        {
            tabExportWarehouse.Pages.Remove(tabExportWarehouse.SelectedPage);
        }
    }
}
