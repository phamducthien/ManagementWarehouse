namespace WH.Entity
{
    public partial class KHACHHANG : IEntityExtend
    {
        public string TextSearchExtend
        {
            get
            {
                var s = string.Empty;
                if (KHACHHANGKHUVUC != null)
                    s = KHACHHANGKHUVUC.TEN;
                return s;
            }
        }
    }
}