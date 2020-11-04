using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;

namespace Util.Pattern.Connection
{
    public interface ISqlServerConnectionUtil : ISqlConnectionUtil<SqlConnection>
    {
    }

    public class SqlServerConnectionUtil : DbConnectionUtil<SqlConnection>, ISqlServerConnectionUtil
    {
        public override SqlConnection GetConnection()
        {
            return new SqlConnection(GetConnectionString());
        }

        public List<string> EnumerateServers()
        {
            var dataSources = SqlDataSourceEnumerator.Instance.GetDataSources();
            List<string> result;
            if (dataSources.Rows.Count <= 0)
            {
                result = null;
            }
            else
            {
                var list = (from DataRow dataRow in dataSources.Rows
                        let text = dataRow["ServerName"].ToString()
                        let text2 = dataRow["InstanceName"].ToString()
                        select string.IsNullOrEmpty(text2)
                            ? text
                            : string.Format("{0}\\{1}", text, text2))
                    .ToList();
                result = list;
            }

            return result;
        }

        public List<string> EnumerateDatabases()
        {
            List<string> result;
            var connectionString = GetConnectionStringWithoutDbName();
            try
            {
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    var schema = sqlConnection.GetSchema("Databases");
                    sqlConnection.Close();
                    if (schema.Rows.Count < 1)
                    {
                        result = null;
                    }
                    else
                    {
                        var list = (from DataRow dataRow in schema.Rows
                            select dataRow["database_name"].ToString()).ToList();
                        result = list;
                    }
                }
            }
            catch
            {
                result = null;
            }

            return result;
        }

        protected override string GetConnectionString()
        {
            var builder = new SqlConnectionStringBuilder();

            builder.UserID = UserId;
            builder.Password = Password;
            builder.DataSource = Server;
            builder.ConnectTimeout = 3;
            builder.PersistSecurityInfo = true;

            if (!string.IsNullOrWhiteSpace(DbName)) builder.InitialCatalog = DbName;
            if (!string.IsNullOrWhiteSpace(Application)) builder.ApplicationName = Application;
            return builder.ToString();
        }

        protected string GetConnectionStringWithoutDbName()
        {
            var builder = new SqlConnectionStringBuilder();

            builder.UserID = UserId;
            builder.Password = Password;
            builder.DataSource = Server;
            builder.ConnectTimeout = 3;
            builder.PersistSecurityInfo = true;

            if (!string.IsNullOrWhiteSpace(Application)) builder.ApplicationName = Application;
            return builder.ToString();
        }
    }
}