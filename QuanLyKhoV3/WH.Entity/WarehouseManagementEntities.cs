using Repository.Pattern.Ef6;

namespace WH.Entity
{
    public class WarehouseManagementEntities : DataContext
    {
        public WarehouseManagementEntities(string connectionString)
            : base(connectionString)
        {
        }
    }
}