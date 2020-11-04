using System;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;

namespace Util.Pattern.Connection
{
    public interface IEntityConnectionUtil : IDbConnectionUtil<EntityConnection>
    {
        string Provider { get; set; }
        string Metadata { get; set; }
        string ProviderConnectionString { get; set; }
        Type ProviderType { get; set; }
    }

    public class EntityConnectionUtil : DbConnectionUtil<EntityConnection>, IEntityConnectionUtil
    {
        private string _metadata;


        protected EntityConnectionUtil()
        {
            Application = "EntityFramework";
        }

        //public EntityConnectionUtil(IDbConnection connection) : this()
        //{
        //    this.NestedDbConnection = connection;
        //    Provider = GetProviderByNestedConnection();
        //}

        public EntityConnectionUtil(string providerConnectionString, Type providerType)
            : this()
        {
            ProviderConnectionString = providerConnectionString;
            ProviderType = providerType;
        }

        public string Provider { get; set; }
        public string ProviderConnectionString { get; set; }
        public Type ProviderType { get; set; }

        public string Metadata
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_metadata)) _metadata = "res://*";
                return _metadata;
            }
            set => _metadata = value;
        }

        public override EntityConnection GetConnection()
        {
            var con = new EntityConnection(ConnectionString);
            return con;
        }

        protected string GetProviderByNestedConnection()
        {
            if (ProviderType == typeof(SqlConnection)) return "System.Data.SqlClient";

            return "";
        }

        protected override string GetConnectionString()
        {
            var builder = new EntityConnectionStringBuilder();
            builder.Provider =
                string.IsNullOrWhiteSpace(Provider)
                    ? GetProviderByNestedConnection()
                    : Provider;
            //builder.ProviderConnectionString =
            //    string.IsNullOrWhiteSpace(ProviderConnectionString)
            //        ? this.NestedDbConnection.ConnectionString
            //        : this.ProviderConnectionString;
            builder.ProviderConnectionString = ProviderConnectionString;
            builder.Metadata = Metadata;

            return builder.ToString();
        }
    }
}