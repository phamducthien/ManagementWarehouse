using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using Util.Pattern;
using WH.Entity;
using WH.Service.Service;

namespace WH.GUI
{
    public partial class UsrcDgvMatHang : usrcBase
    {
        private readonly Expression<Func<MATHANG, bool>> _predicateCanNhap = s =>
            s.ISDELETE == false && s.ISUSE == true &&
            s.KHOMATHANGs.FirstOrDefault(
                p => p.MAMATHANG == s.MAMATHANG).SOLUONGLE <=
            s.NGUONGNHAP;

        private readonly Expression<Func<MATHANG, bool>> _predicateCanXuat = s =>
            s.ISDELETE == false && s.ISUSE == true &&
            s.KHOMATHANGs.FirstOrDefault(
                p => p.MAMATHANG == s.MAMATHANG).SOLUONGLE >=
            s.NGUONGXUAT;

        private readonly Expression<Func<MATHANG, bool>>
            _predicateLoadAll = s => s.ISDELETE == false && s.ISUSE == true;

        public UsrcDgvMatHang()
        {
            InitializeComponent();
            DgView = dgvDanhMuc;
            GbxList = gbxList;
            dgvDanhMuc.MouseDoubleClick += HandleCellMouseDoubleClick;
        }

        public MATHANG Model { get; set; }
        public List<MATHANG> DataList { get; set; }

        private IMATHANGService Service
        {
            get
            {
                ReloadUnitOfWork();
                return new MATHANGService(UnitOfWorkAsync);
            }
        }

        private IKHOMATHANGService ServiceKhoMH
        {
            get
            {
                ReloadUnitOfWork();
                return new KHOMATHANGService(UnitOfWorkAsync);
            }
        }

        public event EventHandler CellMouseDoubleClick;


        private void Init()
        {
            ShowLoad();
            BringToFront();
            LoadDataAll();
            CloseLoad();
        }

        private void LoadDataCanNhap()
        {
            DataList =
                Service.Search(_predicateCanNhap).ToList();
            LoadData(DataList.ToDatatable());
        }

        private void LoadDataCanXuat()
        {
            DataList =
                Service.Search(_predicateCanXuat).ToList();
            LoadData(DataList.ToDatatable());
        }

        private void LoadDataAll()
        {
            DataList = Service.Search(_predicateLoadAll).ToList();
            LoadData(DataList.ToDatatable());
        }

        private void SearchData()
        {
            var lstSearchs = Service.Search(_predicateLoadAll, txtTimKiem.Text);
            if (!lstSearchs.isNullOrZero())
            {
                txtTimKiem.Text = "";
                UiHelper.LoadFocus(txtTimKiem);
            }

            LoadData(lstSearchs.ToDatatable());
        }

        private bool GetDataFromDgv()
        {
            try
            {
                Model = null;
                if (dgvDanhMuc.SelectedRows.Count > 0)
                {
                    var row = dgvDanhMuc.SelectedRows[0];
                    if (row == null) return false;

                    var sId = row.Cells["IDUnit"].Value.ToString();
                    if (sId == "") return false;

                    Model = Service.Find(s => s.MAMATHANG.ToString().Equals(sId));
                    CurrentRow = row;
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        private void HandleCellMouseDoubleClick(object sender, EventArgs e)
        {
            OnCellMouseDoubleClick();
        }

        private void OnCellMouseDoubleClick()
        {
            CellMouseDoubleClick?.Invoke(this, EventArgs.Empty);
        }

        private void dgvDanhMuc_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvDanhMuc.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1;
        }

        private void dgvDanhMuc_SelectionChanged(object sender, EventArgs e)
        {
            GetDataFromDgv();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            SearchData();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            LoadDataAll();
        }

        private void usrcDgvMatHang_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void btnCanNhap_Click(object sender, EventArgs e)
        {
            LoadDataCanNhap();
        }

        private void btnCanXuat_Click(object sender, EventArgs e)
        {
            LoadDataCanXuat();
        }
    }
}