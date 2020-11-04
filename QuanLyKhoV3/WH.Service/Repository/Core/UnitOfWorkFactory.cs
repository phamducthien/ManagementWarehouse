using Repository.Pattern.Ef6;
using Repository.Pattern.UnitOfWork;
using WH.Entity;
using WH.Model;

namespace WH.Service.Repository.Core
{
    public class UnitOfWorkFactory
    {
        public static IUnitOfWorkAsync MakeUnitOfWork()
        {
            var connectionString = GlobalContext.EntityConnectionString;
            DataContext context = new WarehouseManagementEntities(connectionString);
            IUnitOfWorkAsync unitOfWork = new UnitOfWork(context);
            return unitOfWork;
        }
    }
}