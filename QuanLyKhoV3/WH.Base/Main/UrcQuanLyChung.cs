using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WH.Entity;
using WH.Service.Service;

namespace WH.Base.UI
{
    public partial class UrcQuanLyChung : UserControl
    {
        private BaseForm _baseForm;
        public UrcQuanLyChung()
        {
            InitializeComponent();
            _baseForm = new BaseForm();
            LoadTree();
        }

        private void LoadTree()
        {
            int count = 0;
              _baseForm.ReloadUnitOfWork();
            IDONVIService service = new DONVIService(_baseForm.UnitOfWorkAsync);
            List<DONVI> list = service.FindAll();
            if (list != null)
            {
                count = list.Count;
                treeDanhMuc.Nodes.Add("dv", "ĐƠN VỊ  ("+count+")");
                foreach (DONVI obj in list)
                {
                    count = obj.MATHANGs == null ? 0 : obj.MATHANGs.Count;
                    treeDanhMuc.Nodes["dv"].Nodes.Add(obj.IDUnit, obj.TENDONVI + " :" + count + " Mặt hàng.");
                    //if (count>0)
                    //{
                    //    foreach (MATHANG objmh in obj.MATHANGs)
                    //    {
                    //        treeDanhMuc.Nodes[obj.IDUnit].Nodes.Add(objmh.IDUnit, objmh.TENMATHANG);
                    //    }
                    //}
                }
            }
            ILOAIMATHANGService servicelmh = new LOAIMATHANGService(_baseForm.UnitOfWorkAsync);
            List<LOAIMATHANG> listLmh = servicelmh.FindAll();
            if (listLmh != null)
            {
                count = listLmh.Count;
                treeDanhMuc.Nodes.Add("lmh", "LOẠI MẶT HÀNG (" + count + ")");
                foreach (LOAIMATHANG obj in listLmh)
                {
                    count = obj.MATHANGs == null ? 0 : obj.MATHANGs.Count;
                    treeDanhMuc.Nodes["lmh"].Nodes.Add(obj.IDUnit, obj.TENLOAIMATHANG + " :" + count + " Mặt hàng.");
                }
            }
            IKHACHHANGKHUVUCService servicekv = new KHACHHANGKHUVUCService(_baseForm.UnitOfWorkAsync);
            List<KHACHHANGKHUVUC> listKv = servicekv.FindAll();
            if (listKv != null)
            {
                count = listKv.Count;
                treeDanhMuc.Nodes.Add("kv", "KHU VỰC (" + count + ")");
                foreach (KHACHHANGKHUVUC obj in listKv)
                {
                    count = obj.KHACHHANGs == null ? 0 : obj.KHACHHANGs.Count;
                    treeDanhMuc.Nodes["kv"].Nodes.Add(obj.IDUnit, obj.TEN + " :" + count + " đối tác.");
                }
            }
        }
        private void kryptonCheckButton1_Click(object sender, EventArgs e)
        {
            FrmDonVi frm = new FrmDonVi();
            frm.ShowDialog();
        }

        private void kryptonCheckButton2_Click(object sender, EventArgs e)
        {
            FrmLoaiMatHang frm = new FrmLoaiMatHang();
            frm.ShowDialog();
        }

        private void kryptonCheckButton3_Click(object sender, EventArgs e)
        {
            var frm = new FrmKhuVuc();
            frm.ShowDialog();
        }

        private void kryptonCheckButton4_Click(object sender, EventArgs e)
        {
            var frm = new FrmMayIn();
            frm.ShowDialog();
        }
    }
}
