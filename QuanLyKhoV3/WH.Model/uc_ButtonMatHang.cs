using System;
using System.Drawing;
using System.Globalization;
using MetroFramework.Controls;

namespace WH.Model
{
    public partial class UcButtonMatHang : MetroUserControl
    {
        public UcButtonMatHang()
        {
            InitializeComponent();
        }

        public event MatHangClickHandler MatHangEvent;

        private void uc_ButtonMatHang_MouseEnter(object sender, EventArgs e)
        {
            picHinhSP.BackColor = Color.Orange;
            lblTenSP.BackColor = Color.Orange;
        }

        private void uc_ButtonMatHang_MouseLeave(object sender, EventArgs e)
        {
            picHinhSP.BackColor = Color.White;
            lblTenSP.BackColor = Color.Green;
        }

        private void usrImage_Click(object sender, EventArgs e)
        {
            InvokeMatHangClick(new MatHangArgs(_prId, IdCode, BarCode, _prName, _prImage, _prPriceGiaLe,
                GiaChiaThang, GiaQuyDinh, GiaNhap, Number, PrVat, GroupMenuId, UnitId1, UnitId2,
                PrMadeIn, Idpos, IsUse, IsDelete, NameUnit1, NameUnit2, _existNumber, Index));
            BackColor = Color.FromArgb(255, 128, 0);
        }

        #region field

        private int _prId;
        private string _prName;
        private Image _prImage;
        private decimal _prPriceGiaLe;
        private string _existNumber;

        #endregion field

        #region Property

        public string IdCode { get; set; }

        public string BarCode { get; set; }

        public int MaSanPham
        {
            get => _prId;
            set
            {
                _prId = value;
                Name = _prId.ToString(CultureInfo.InvariantCulture);
                picHinhSP.Name = _prId.ToString(CultureInfo.InvariantCulture);
            }
        }

        public string TenSanPham
        {
            get => _prName;
            set
            {
                _prName = value;
                lblTenSP.Text = value;
            }
        }

        public Image HinhAnh
        {
            get => _prImage;
            set
            {
                _prImage = value;
                picHinhSP.Image = value;
            }
        }

        public decimal GiaLe
        {
            get => _prPriceGiaLe;
            set
            {
                _prPriceGiaLe = value;
                labDonGia.Text = string.Format("{0:####,0}", value);
            }
        }

        public decimal GiaChiaThang { get; set; }

        public decimal GiaNhap { get; set; }

        public decimal GiaQuyDinh { get; set; }

        public string Number { get; set; }

        public string PrVat { get; set; }

        public int GroupMenuId { get; set; }

        public string UnitId1 { get; set; }

        public string UnitId2 { get; set; }

        public string Idpos { get; set; }

        public string PrMadeIn { get; set; }

        public bool IsUse { get; set; }

        public bool IsDelete { get; set; }

        public string NameUnit1 { get; set; }

        public string NameUnit2 { get; set; }

        public string SoLuongTon
        {
            get => _existNumber;
            set
            {
                _existNumber = value;
                lblSoLuongConLai.Text = value;
            }
        }

        public int Index { get; set; }

        #endregion Property

        #region Delegate UserControl Click

        public delegate void MatHangClickHandler(object sender, MatHangArgs mhArgs);

        private void InvokeMatHangClick(MatHangArgs mhArgs)
        {
            var mhevent = MatHangEvent;
            if (mhevent != null) mhevent(this, mhArgs);
        }

        public class MatHangArgs : EventArgs
        {
            public MatHangArgs()
            {
            }

            public MatHangArgs(int prId, string idCode, string barCode, string prName, Image prImage, decimal giaLe,
                decimal giaQuyDinh, decimal giaChiaThang, decimal giaNhap, string number, string prVat,
                int groupMenuId, string unitId1, string unitId2, string prMadeIn, string idpos, bool isUse,
                bool isDelete, string nameUnit1, string nameUnit2, string existNumber, int index)
            {
                PrID = prId;
                IDCode = idCode;
                BarCode = barCode;
                PrName = prName;
                PrImage = prImage;
                PrPriceGiaLe = giaLe;
                PrPriceGiaChiaThang = giaQuyDinh;
                PrPriceGiaQuyDinh = giaChiaThang;
                PrPriceGiaNhap = giaNhap;
                Number = number;
                PrVAT = prVat;
                GroupMenuID = groupMenuId;
                UnitID1 = unitId1;
                UnitID2 = unitId2;
                PrMadeIn = prMadeIn;
                IDPOS = idpos;
                IsUse = isUse;
                IsDelete = isDelete;
                NameUnit1 = nameUnit1;
                NameUnit2 = nameUnit2;
                ExistNumber = existNumber;
                Index = index;
            }

            public int PrID { get; set; }
            public string IDCode { get; set; }
            public string BarCode { get; set; }
            public string PrName { get; set; }
            public Image PrImage { get; set; }

            public decimal GiaLe
            {
                get => GiaLe;
                set => GiaLe = value;
            }

            public decimal GiaChiaThang
            {
                get => GiaChiaThang;
                set => GiaChiaThang = value;
            }

            public decimal GiaQuyDinh
            {
                get => GiaQuyDinh;
                set => GiaQuyDinh = value;
            }

            public decimal GiaNhap
            {
                get => GiaNhap;
                set => GiaNhap = value;
            }

            public string Number { get; set; }
            public string PrVAT { get; set; }
            public int GroupMenuID { get; set; }
            public string UnitID1 { get; set; }
            public string UnitID2 { get; set; }
            public string PrMadeIn { get; set; }
            public string IDPOS { get; set; }
            public bool IsUse { get; set; }
            public bool IsDelete { get; set; }
            public string NameUnit1 { get; set; }
            public string NameUnit2 { get; set; }
            public string ExistNumber { get; set; }
            public int Index { get; set; }
            public decimal PrPriceGiaLe { get; set; }
            public decimal PrPriceGiaQuyDinh { get; set; }
            public decimal PrPriceGiaChiaThang { get; set; }
            public decimal PrPriceGiaNhap { get; set; }
        }

        #endregion Delegate UserControl Click
    }
}