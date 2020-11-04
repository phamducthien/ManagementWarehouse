using System.Collections.Generic;
using WH.Entity;

namespace WH.Model
{
    public class SessionModel
    {
        public static SessionModel CurrentSession { get; set; }

        #region Properties

        public NGUOIDUNG User { get; set; }
        public List<MenuSettingModel> MenuSetting { get; set; }
        public CA CaLamViec { get; set; }
        public KHO KhoMatHang { get; set; }

        public bool IsLogged => User != null;

        public int CaID
        {
            get
            {
                if (CaLamViec != null) return CaLamViec.MACA;
                return 0;
            }
        }

        public string UserId
        {
            get
            {
                if (!IsLogged) return "";
                return User.MANGUOIDUNG;
            }
        }

        #endregion
    }
}