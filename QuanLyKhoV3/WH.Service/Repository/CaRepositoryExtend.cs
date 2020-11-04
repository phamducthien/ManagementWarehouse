using System.Collections.Generic;
using System.Linq;
using WH.Entity;

namespace WH.Service.Repository
{
    public partial interface ICARepository
    {
        List<CA> FindByUserId(string userId);
    }

    public partial class CARepository
    {
        public List<CA> FindByUserId(string userId)
        {
            return Queryable().Where(p => p.MANHANVIEN.ToString().Contains(userId)).ToList();
        }
    }
}