using System.Collections.Generic;
using System.Linq;
using WH.Entity;

namespace WH.Service.Repository
{
    public partial interface INGUOIDUNG_QUYENHANRepository
    {
        bool Exist(string idUser, string idFunction);
        List<NGUOIDUNG_QUYENHAN> FindByUserId(string userId);
        List<NGUOIDUNG_QUYENHAN> FindByUserId(List<string> userIds);
    }

    public partial class NGUOIDUNG_QUYENHANRepository
    {
        public bool Exist(string idUser, string idFunction)
        {
            return Queryable().Any(p => p.CHUCNANG.ToString() == idFunction && p.MANGUOIDUNG.ToString() == idUser);
        }

        public List<NGUOIDUNG_QUYENHAN> FindByUserId(string userId)
        {
            return Queryable().Where(p => p.MANGUOIDUNG == userId).ToList();
        }

        public List<NGUOIDUNG_QUYENHAN> FindByUserId(List<string> userIds)
        {
            return
                Queryable().Where(p => p.CHUCNANG.NGUOIDUNG_QUYENHAN.Any(q => userIds.Contains(q.MANGUOIDUNG)))
                    .ToList();
        }
    }
}