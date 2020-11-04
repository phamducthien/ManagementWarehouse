using System;
using System.Linq;
using System.Windows.Forms;
using WH.Service.Service;

namespace WH.GUI
{
    public partial class UrcQuanLyChung : UserControl
    {
        private readonly BaseForm _baseForm;

        public UrcQuanLyChung()
        {
            InitializeComponent();
            _baseForm = new BaseForm();
            LoadTree();
        }

        private void LoadTree()
        {
            var count = 0;
            _baseForm.ReloadUnitOfWork();
            IDONVIService service = new DONVIService(_baseForm.UnitOfWorkAsync);
            var list = service.FindAll();
            if (list != null)
            {
                count = list.Count;
                treeDanhMuc.Nodes.Add("dv", "ĐƠN VỊ  (" + count + ")");
                foreach (var obj in list)
                    if (obj.ISUSE == true)
                    {
                        count = obj.MATHANGs == null ? 0 : obj.MATHANGs.Count(s => s.ISDELETE == false);
                        treeDanhMuc.Nodes["dv"].Nodes.Add(obj.IDUnit, obj.TENDONVI + " :" + count + " Mặt hàng.");
                    }
                //if (count>0)
                //{
                //    foreach (MATHANG objmh in obj.MATHANGs)
                //    {
                //        treeDanhMuc.Nodes[obj.IDUnit].Nodes.Add(objmh.IDUnit, objmh.TENMATHANG);
                //    }
                //}
            }

            ILOAIMATHANGService servicelmh = new LOAIMATHANGService(_baseForm.UnitOfWorkAsync);
            var listLmh = servicelmh.FindAll();
            if (listLmh != null)
            {
                count = listLmh.Count;
                treeDanhMuc.Nodes.Add("lmh", "LOẠI MẶT HÀNG (" + count + ")");
                foreach (var obj in listLmh)
                {
                    count = obj.MATHANGs?.Count(s => s.ISDELETE == false) ?? 0;
                    treeDanhMuc.Nodes["lmh"].Nodes.Add(obj.IDUnit, obj.TENLOAIMATHANG + " :" + count + " Mặt hàng.");
                }
            }

            IKHACHHANGKHUVUCService servicekv = new KHACHHANGKHUVUCService(_baseForm.UnitOfWorkAsync);
            var listKv = servicekv.FindAll();
            if (listKv != null)
            {
                count = listKv.Count;
                treeDanhMuc.Nodes.Add("kv", "KHU VỰC (" + count + ")");
                foreach (var obj in listKv)
                    if (obj.ISUSE == true)
                    {
                        count = obj.KHACHHANGs?.Count(s => s.ISDELETE == false) ?? 0;
                        treeDanhMuc.Nodes["kv"].Nodes.Add(obj.IDUnit, obj.TEN + " :" + count + " đối tác.");
                    }
            }
        }

        private void kryptonCheckButton1_Click(object sender, EventArgs e)
        {
            var frm = new FrmDonVi();
            frm.ShowDialog();
        }

        private void kryptonCheckButton2_Click(object sender, EventArgs e)
        {
            var frm = new FrmLoaiMatHang();
            frm.ShowDialog();
        }

        private void kryptonCheckButton3_Click(object sender, EventArgs e)
        {
            var frm = new FrmKhuVuc();
            frm.ShowDialog();
        }

        private void kryptonCheckButton4_Click(object sender, EventArgs e)
        {
            var frm = new FrmMayInBill();
            frm.ShowDialog();
        }

        private void btnNguoiDung_Click(object sender, EventArgs e)
        {
            var frm = new FrmPhanQuyen();
            frm.ShowDialog();
        }

        private void btnNhapExcelHoaDon_Click(object sender, EventArgs e)
        {
            //var frm = new FrmImportExcelHoaDon();
            //frm.ShowDialog();
        }
    }
}