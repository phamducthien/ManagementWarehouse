using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.Win32;

namespace Util.Pattern
{
    public static class SqlServerHelper
    {
        public static List<string> EnumerateServers()
        {
            var dataSources = SqlDataSourceEnumerator.Instance.GetDataSources();
            List<string> result;
            if (dataSources.Rows.Count < 1)
            {
                result = null;
            }
            else
            {
                var list = (from DataRow dataRow in dataSources.Rows
                    let text = dataRow["ServerName"].ToString()
                    let text2 = dataRow["InstanceName"].ToString()
                    select string.IsNullOrEmpty(text2) ? text : string.Format("{0}\\{1}", text, text2)).ToList();
                result = list;
            }

            return result;
        }

        public static List<string> EnumerateDatabases(string connectionString)
        {
            List<string> result;
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
                        var list = (from DataRow dataRow in schema.Rows select dataRow["database_name"].ToString())
                            .ToList();
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

        public static bool IsSqlServerInstalled()
        {
            using (
                var registryKey =
                    Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Microsoft SQL Server\\",
                        false))
            {
                if (registryKey == null) return false;
                var subKeyNames = registryKey.GetSubKeyNames();
                if (subKeyNames.Length == 0) return false;
                var array = subKeyNames;
                foreach (var text in array.Where(text => text.StartsWith("MSSQL.")))
                    using (var registryKey2 = registryKey.OpenSubKey(text, false))
                    {
                        if (registryKey2 != null)
                        {
                            var text2 = (string) registryKey2.GetValue("", "");
                            if (text2.ToLower() == "KTT" || text2.ToLower() == "sqlexpress") return true;
                        }
                    }
            }

            return false;
        }
    }
}