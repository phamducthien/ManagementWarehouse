using System;
using System.Data.SqlClient;
using Service.Pattern;
using Util.Pattern.Connection;
using WH.Model;

namespace WH.Service
{
    public interface IContextService : IErrorProvider
    {
        bool LoadContext();
    }

    public class ContextService : ErrorProvider, IContextService
    {
        public bool LoadContext()
        {
            try
            {
                IConfigurationService service = new ConfigurationService();
                var model = service.ReadConfig();

                //GlobalContext.Configuration = model;

                ISqlServerConnectionUtil sqlUtil =
                    new SqlServerConnectionUtil
                    {
                        Server = model.Server,
                        UserId = model.UserName,
                        DbName = model.DbName,
                        Password = model.PlainPassword
                    };

                if (!sqlUtil.TryConnect())
                    ThrowException();

                IEntityConnectionUtil efutil =
                    new EntityConnectionUtil(sqlUtil.ConnectionString, typeof(SqlConnection));
                //if (!efutil.TryConnect())
                //{
                //    ThrowException();
                //}

                GlobalContext.EntityConnectionString = efutil.ConnectionString;
                GlobalContext.IsLoaded = true;

                GlobalContext.A4PrinterName = model.A4PrinterName;
                GlobalContext.BillPrinterName = model.BillPrinterName;
                GlobalContext.IsA4BarcodePrinterFormat = model.IsBarcodePrinterA4;
                GlobalContext.SqlConnectionString = sqlUtil.ConnectionString;
                GlobalContext.ServerConnection = sqlUtil.GetConnection();
            }
            catch (Exception exception)
            {
                ErrMsg = "Không thể tải cấu hình kết nối dữ liệu.\nBạn phải cấu hình kết nối dữ liệu lại!";
                return false;
            }

            return true;
        }
    }
}