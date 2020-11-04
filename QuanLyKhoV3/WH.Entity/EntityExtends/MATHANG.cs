namespace WH.Entity
{
    public partial class MATHANG : IEntityExtend
    {
        public string TENDONVI
        {
            get
            {
                try
                {
                    return DONVI1?.TENDONVI ?? "";
                }
                catch
                {
                    return "";
                }
            }
        }

        public string TENLOAI
        {
            get
            {
                try
                {
                    return LOAIMATHANG?.TENLOAIMATHANG ?? "";
                }
                catch
                {
                    return "";
                }
            }
        }

        public decimal SLTON
        {
            get
            {
                try
                {
                    var objKho = KHOMATHANGs?[0];
                    if (objKho?.SOLUONGLE != null) return (decimal) objKho?.SOLUONGLE;
                }
                catch
                {
                    return 0;
                }

                return 0;
            }
        }

        public string TextSearchExtend
        {
            get
            {
                var s = string.Empty;
                if (LOAIMATHANG != null)
                    s = LOAIMATHANG.TENLOAIMATHANG;
                if (DONVI != null)
                    s += ';' + DONVI.TENDONVI;
                return s;
            }
        }
    }
}