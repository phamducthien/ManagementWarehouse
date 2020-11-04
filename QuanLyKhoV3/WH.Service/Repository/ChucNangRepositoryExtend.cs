using System.Collections.Generic;
using System.Linq;
using WH.Entity;

namespace WH.Service.Repository
{
    public partial interface ICHUCNANGRepository
    {
        List<CHUCNANG> FindByUserId(string userId);
        List<CHUCNANG> FindByUserId(List<string> userIds);
    }

    public partial class CHUCNANGRepository : ICHUCNANGRepository
    {
        public List<CHUCNANG> FindByUserId(string userId)
        {
            return Queryable().Where(p => p.NGUOIDUNG_QUYENHAN.Any(q => q.MANGUOIDUNG == userId)).ToList();
        }

        public List<CHUCNANG> FindByUserId(List<string> userIds)
        {
            return Queryable().Where(p => p.NGUOIDUNG_QUYENHAN.Any(q => userIds.Contains(q.MANGUOIDUNG))).ToList();
        }
    }
}