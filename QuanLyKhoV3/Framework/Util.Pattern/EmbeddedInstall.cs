using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace Util.Pattern
{
    public class EmbeddedInstall
    {
        #region Internal variables

        //Variables for setup.exe command line
        private const string AddLocal = "All";
        private string _saPassword = "123456";

        #endregion

        #region Properties

        public string InstanceName { get; set; } = "BRAINMAX";

        public string SetupFileLocation { get; set; } = Environment.GetEnvironmentVariable("TEMP") + "\\sqlexpr.exe";

        public string SqlInstallSharedDirectory { get; set; } = "";

        public string SqlDataDirectory { get; set; } = "";

        public bool AutostartSqlService { get; set; } = true;

        public bool AutostartSqlBrowserService { get; set; }

        public string SqlBrowserAccountName { get; set; } = "";

        public string SqlBrowserPassword { get; set; } = "";

        //Defaults to LocalSystem
        public string SqlServiceAccountName { get; set; } = "sa";

        public string SqlServicePassword { get; set; } = "";

        public bool UseSqlSecurityMode { get; set; }

        public string SysadminPassword
        {
            set => _saPassword = value;
        }

        public string Collation { get; set; } = "";

        public bool DisableNetworkProtocols { get; set; } = true;

        public bool ReportErrors { get; set; } = true;

        public string SqlInstallDirectory { get; set; } = "";

        #endregion

        #region method

        public bool IsExpressInstalled()
        {
            using (
                var key = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Microsoft SQL Server\\", false)
            )
            {
                if (key == null) return false;
                var strNames = key.GetSubKeyNames();

                //If we cannot find a SQL Server registry key, we don't have SQL Server Express installed
                if (strNames.Length == 0) return false;

                foreach (var s in strNames.Where(s => s.StartsWith("MSSQL.")))
                    //Check to see if the edition is "Express Edition"
                    using (var keyEdition = key.OpenSubKey(s + "\\Setup\\", false))
                    {
                        if (keyEdition != null && (string) keyEdition.GetValue("Edition") == "Express Edition")
                            return true;
                    }
            }

            return false;
        }

        public int EnumSqlInstances(ref string[] strInstanceArray, ref string[] strEditionArray,
            ref string[] strVersionArray)
        {
            using (
                var key = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Microsoft SQL Server\\", false)
            )
            {
                if (key == null) return 0;
                var strNames = key.GetSubKeyNames();

                //If we can not find a SQL Server registry key, we return 0 for none
                if (strNames.Length == 0) return 0;

                //How many instances do we have?
                var iNumberOfInstances = strNames.Count(s => s.StartsWith("MSSQL."));

                //Reallocate the string arrays to the new number of instances
                strInstanceArray = new string[iNumberOfInstances];
                strVersionArray = new string[iNumberOfInstances];
                strEditionArray = new string[iNumberOfInstances];
                var iCounter = 0;

                foreach (var s in strNames)
                    if (s.StartsWith("MSSQL."))
                    {
                        //Get Instance name
                        using (var keyInstanceName = key.OpenSubKey(s, false))
                        {
                            if (keyInstanceName != null)
                                strInstanceArray[iCounter] = (string) keyInstanceName.GetValue("");
                        }

                        //Get Edition
                        using (var keySetup = key.OpenSubKey(s + "\\Setup\\", false))
                        {
                            if (keySetup != null)
                            {
                                strEditionArray[iCounter] = (string) keySetup.GetValue("Edition");
                                strVersionArray[iCounter] = (string) keySetup.GetValue("Version");
                            }
                        }

                        iCounter++;
                    }

                return iCounter;
            }
        }

        public string BuildCommandLine()
        {
            var strCommandLine = new StringBuilder();

            if (!string.IsNullOrEmpty(SqlInstallDirectory))
                strCommandLine.Append(" INSTALLSQLDIR=\"").Append(SqlInstallDirectory).Append("\"");

            if (!string.IsNullOrEmpty(SqlInstallSharedDirectory))
                strCommandLine.Append(" INSTALLSQLSHAREDDIR=\"").Append(SqlInstallSharedDirectory).Append("\"");

            if (!string.IsNullOrEmpty(SqlDataDirectory))
                strCommandLine.Append(" INSTALLSQLDATADIR=\"").Append(SqlDataDirectory).Append("\"");

            if (!string.IsNullOrEmpty(AddLocal)) strCommandLine.Append(" ADDLOCAL=\"").Append(AddLocal).Append("\"");

            strCommandLine.Append(AutostartSqlService ? " SQLAUTOSTART=1" : " SQLAUTOSTART=0");

            strCommandLine.Append(AutostartSqlBrowserService ? " SQLBROWSERAUTOSTART=1" : " SQLBROWSERAUTOSTART=0");

            if (!string.IsNullOrEmpty(SqlBrowserAccountName))
                strCommandLine.Append(" SQLBROWSERACCOUNT=\"").Append(SqlBrowserAccountName).Append("\"");

            if (!string.IsNullOrEmpty(SqlBrowserPassword))
                strCommandLine.Append(" SQLBROWSERPASSWORD=\"").Append(SqlBrowserPassword).Append("\"");

            if (!string.IsNullOrEmpty(SqlServiceAccountName))
                strCommandLine.Append(" SQLACCOUNT=\"").Append(SqlServiceAccountName).Append("\"");

            if (!string.IsNullOrEmpty(SqlServicePassword))
                strCommandLine.Append(" SQLPASSWORD=\"").Append(SqlServicePassword).Append("\"");

            if (UseSqlSecurityMode) strCommandLine.Append(" SECURITYMODE=SQL");

            if (!string.IsNullOrEmpty(_saPassword)) strCommandLine.Append(" SAPWD=\"").Append(_saPassword).Append("\"");

            if (!string.IsNullOrEmpty(Collation))
                strCommandLine.Append(" SQLCOLLATION=\"").Append(Collation).Append("\"");

            strCommandLine.Append(DisableNetworkProtocols
                ? " DISABLENETWORKPROTOCOLS=1"
                : " DISABLENETWORKPROTOCOLS=0");

            strCommandLine.Append(ReportErrors ? " ERRORREPORTING=1" : " ERRORREPORTING=0");

            return strCommandLine.ToString();
        }

        public bool InstallExpress()
        {
            //In both cases, we run Setup because we have the file.
            var myProcess = new Process
            {
                StartInfo =
                {
                    FileName = SetupFileLocation,
                    Arguments = "/qb " + BuildCommandLine(),
                    UseShellExecute = false
                }
            };
            /*      /qn -- Specifies that setup run with no user interface.
                    /qb -- Specifies that setup show only the basic 
user interface. Only dialog boxes displaying progress information are 
displayed. Other dialog boxes, such as the dialog box that asks users if 
they want to restart at the end of the setup process, are not displayed.
            */

            return myProcess.Start();
        }

        //public bool CheckConnectSql()
        //{
        //    bool kq;
        //    ISqlConnectionUtil connectionUtil = new Isql();
        //    string connectionString = connectionUtil.GetConnectionString();
        //    IDbConnection con = new SqlConnection(connectionString);
        //    try
        //    {
        //        con.Open();
        //        kq = true;
        //    }
        //    catch
        //    {
        //        kq = false;
        //    }
        //    finally
        //    {
        //        if (con.State != ConnectionState.Closed)
        //        {
        //            con.Close();
        //        }
        //    }
        //    return kq;
        //}

        #endregion
    }
}