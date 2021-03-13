using Repository.Pattern.UnitOfWork;
using System.Collections.Generic;
using System.Windows.Forms;
using WH.Entity;

namespace WH.GUI.NghiepVu.ExportWarehouse
{
    public partial class FrmEditExportWarehouse : Form
    {
        public FrmEditExportWarehouse(HOADONXUATKHO hdXuatKho, List<HOADONXUATKHOCHITIET> hoaDonXuatKhoChiTiets, IUnitOfWorkAsync unitOfWorkAsync)
        {
            InitializeComponent();
        }
    }
}
