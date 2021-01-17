using System.Windows.Forms;

namespace WH.GUI.ExportWarehouse
{
    public partial class FrmListExportWarehouse : Form
    {
        private readonly BaseForm _baseForm;

        public FrmListExportWarehouse()
        {
            InitializeComponent();
            _baseForm = new BaseForm();
        }
    }
}
