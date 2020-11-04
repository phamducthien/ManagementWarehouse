using System.Linq;
using WH.Entity;

namespace WH.Service.Repository
{
    public partial interface INGUOIDUNGRepository
    {
        NGUOIDUNG FindLogin(string username, string plainpassword);
    }

    public partial class NGUOIDUNGRepository
    {
        public NGUOIDUNG FindLogin(string username, string password)
        {
            return Queryable().FirstOrDefault(p => p.TENDANGNHAP == username && p.MATKHAU == password);
        }
    }
}