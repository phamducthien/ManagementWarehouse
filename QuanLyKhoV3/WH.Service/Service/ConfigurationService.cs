using Service.Pattern;
using System;
using System.IO;
using Util.Pattern;
using Util.Pattern.Encryptor;
using WH.Model;

namespace WH.Service
{
    public interface IConfigurationService : IErrorProvider
    {
        ConfigurationModel ReadConfig();
        bool WriteConfig(ConfigurationModel model);
    }

    public class ConfigurationService : ErrorProvider, IConfigurationService
    {
        public static readonly string DefaultConfigFilePath = Environment.CurrentDirectory +
                                                              Path.DirectorySeparatorChar +
                                                              AppDomain.CurrentDomain.FriendlyName + ".config";

        protected string configKeyEncrypt = "<3lQ#H+InqTBg91";

        public ConfigurationService() : this(DefaultConfigFilePath)
        {
            Setting = AppSetting.GetSetting(DefaultConfigFilePath);
        }

        public ConfigurationService(string configFilePath)
        {
            ConfigFilePath = configFilePath;
            Setting = AppSetting.GetSetting(ConfigFilePath);
        }

        public string ConfigFilePath { get; set; }
        public AppSetting Setting { get; set; }

        public ConfigurationModel ReadConfig()
        {
            ConfigurationModel model;

            ErrMsg = "";
            try
            {
                model = new ConfigurationModel();
                string val;

                var server = Setting.GetValue("ip_server");
                if (server == null)
                    ThrowReadException();
                model.Server = server;

                var dbName = Setting.GetValue("database_server");
                if (dbName == null)
                    ThrowReadException();
                model.DbName = dbName;

                var userId = Setting.GetValue("user_server");
                if (userId == null)
                    ThrowReadException();
                model.UserName = userId;

                var encryptedPassword = Setting.GetValue("password_server");
                if (encryptedPassword == null)
                    ThrowReadException();
                model.EncryptedPassword = encryptedPassword;

                model.PlainPassword = Decrypt(model.EncryptedPassword);

                val = Setting.GetValue("printer_name_invoice");
                model.BillPrinterName = val;

                val = Setting.GetValue("printer_name_barcode");
                model.A4PrinterName = val;

                val = Setting.GetValue("barcode_printer_a4");
                model.IsBarcodePrinterA4 = val != "0";
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
                model = GetDefaultModel();
            }

            return model;
        }

        public bool WriteConfig(ConfigurationModel model)
        {
            try
            {
                if (model == null)
                    ThrowException("Null Exception");

                model.EncryptedPassword = Encrypt(model.PlainPassword);

                Setting.SetValue("ip_server", model.Server);
                Setting.SetValue("database_server", model.DbName);
                Setting.SetValue("user_server", model.UserName);
                Setting.SetValue("password_server", model.EncryptedPassword);

                Setting.SetValue("printer_name_invoice", model.BillPrinterName);
                Setting.SetValue("printer_name_barcode", model.A4PrinterName);
                Setting.SetValue("barcode_printer_a4", model.IsBarcodePrinterA4 ? "1" : "0");
            }
            catch (Exception exception)
            {
                ErrMsg = exception.Message;
                return false;
            }

            return true;
        }

        #region Private Methods

        protected void ThrowReadException()
        {
            ThrowException("Không thể đọc cấu hình");
        }

        protected void ThrowWriteException()
        {
            ThrowException("Không thể ghi cấu hình");
        }

        protected string Encrypt(string plainText)
        {
            return StringCryptographyUtil.Encrypt(plainText, configKeyEncrypt);
        }

        protected string Decrypt(string encryptedText)
        {
            return StringCryptographyUtil.Decrypt(encryptedText, configKeyEncrypt);
        }

        protected ConfigurationModel GetDefaultModel()
        {
            var model
                = new ConfigurationModel
                {
                    Server = "localhost",
                    UserName = "sa",
                    PlainPassword = "123456",
                    DbName = "QuanLyKho_V3",
                    IsBarcodePrinterA4 = true,
                    A4PrinterName = "",
                    BillPrinterName = ""
                };
            model.EncryptedPassword = Encrypt(model.PlainPassword);
            return model;
        }

        #endregion
    }
}
