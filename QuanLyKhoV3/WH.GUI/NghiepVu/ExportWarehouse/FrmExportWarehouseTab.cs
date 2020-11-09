using ComponentFactory.Krypton.Navigator;
using System.Windows.Forms;

namespace WH.GUI.ExportWarehouse
{
    public partial class FrmExportWarehouseTab : Form
    {
        private int _count = 1;
        public FrmExportWarehouseTab()
        {
            InitializeComponent();
            AddNewTab();
        }

        private void AddNewTab()
        {
            KryptonPage newPage = new KryptonPage();

            // Populate with text and image
            newPage.Text = "Page " + _count.ToString();
            newPage.TextTitle = "Page " + _count.ToString() + " Title";
            newPage.TextDescription = "Page " + _count.ToString() + " Description";
            _count++;

            // Append to end of the pages collection
            tabExportWarehouse.Pages.Add(newPage);

            // Select the new page
            tabExportWarehouse.SelectedPage = newPage;
        }
    }
}
