using System;
using System.Globalization;
using System.Threading;
using System.Xml;
using Microsoft.Win32;

namespace Util.Pattern
{
    public class AppSetting
    {
        private static AppSetting aps;
        private readonly XmlNode appSettingsElement;
        private XmlElement newElement;
        private readonly XmlDocument xml = new XmlDocument();

        private AppSetting(string configFileName)
        {
            CultureInfo = new CultureInfo("vi-VN");
            //System.Windows.Forms.MessageBox.Show(CultureInfo.NumberFormat.CurrencyDecimalDigits.ToString());
            // Đặt lại số lẻ sau dấu chấm thập phân là không có số lẻ
            // Đặt lại ký tự tiền tệ là không có
            CultureInfo.NumberFormat.CurrencyDecimalDigits = 0;
            CultureInfo.NumberFormat.CurrencySymbol = string.Empty;
            CultureInfo.NumberFormat.CurrencyGroupSeparator = ".";
            CultureInfo.NumberFormat.CurrencyDecimalSeparator = ",";
            CultureInfo.DateTimeFormat.ShortTimePattern = "";
            CultureInfo.DateTimeFormat.LongTimePattern = "";

            //if (m_AppName == "")
            //    ConfigFileName = Environment.CurrentDirectory + "\\" + AppDomain.CurrentDomain.FriendlyName + ".config";
            //else
            //    ConfigFileName = Environment.CurrentDirectory + "\\" + m_AppName + ".config";

            ConfigFileName = configFileName;

            try
            {
                // Create a new XmlDocument object
                xml = new XmlDocument();

                // load the configuration file
                xml.Load(ConfigFileName);

                // get the <appSettings> element
                appSettingsElement = xml.SelectSingleNode("//configuration/appSettings");

                // if there's no <appSettings> section, create one.
                if (appSettingsElement == null)
                {
                    appSettingsElement = xml.CreateElement("appSettings");
                    xml.DocumentElement.AppendChild(appSettingsElement);
                }

                //DATETIME_FORMAT = this.getConfigValue("DATETIME_FORMAT");
            }
            catch (Exception ex)
            {
                // handle Load errors
                throw new ApplicationException("Unable to load the configuration " + ConfigFileName +
                                               " file for this application.", ex);
            }
            //}
            //else
            //{
            //    // no configuration file exists
            //    // you might want to alter this method to  create one
            //    throw new ApplicationException("This application (" + Environment.CurrentDirectory + "\\" + AppDomain.CurrentDomain.FriendlyName + ".config" + " has no configuration file.");

            //}
        }

        public string ConfigFileName { get; set; }
        //private string m_AppName = "";

        public CultureInfo CultureInfo { get; set; }

        public void SetValue(string key, string val)
        {
            // create a new <add> element
            newElement = xml.CreateElement("add");
            var s = GetValue(key);
            if (s == null)
            {
                // set its attributes
                newElement.SetAttribute("key", key);
                //val = Security.Encrypt(val, "khaihoanproducts","takeru");
                newElement.SetAttribute("value", val);

                // append it to the <appSettings> section
                appSettingsElement.AppendChild(newElement);
            }
            else
            {
                var appsetting = (XmlElement) appSettingsElement.SelectSingleNode("add[@key='" + key + "']");
                if (appsetting != null) appsetting.SetAttribute("value", val);
            }

            try
            {
                xml.Save(ConfigFileName);
            }
            catch
            {
                Thread.Sleep(3000);
                xml.Save(ConfigFileName);
            }
        }

        public string GetValue(string aKey)
        {
            var appsetting = (XmlElement) appSettingsElement.SelectSingleNode("add[@key='" + aKey + "']");
            if (appsetting != null)
                return appsetting.GetAttribute("value");
            return null; //String.Empty ;
        }

        public void Remove(string aKey)
        {
            var el = _GetSettingsElement(aKey);
            if (el != null) el.ParentNode.RemoveChild(el);
            xml.Save(ConfigFileName);
        }

        private XmlElement _GetSettingsElement(string aKey)
        {
            return (XmlElement) appSettingsElement.SelectSingleNode("add[@key='" + aKey + "']");
        }

        public static AppSetting GetSetting(string configFileName)
        {
            //m_AppName = AppName;

            if (aps == null)
            {
                aps = new AppSetting(configFileName);
                return aps;
            }

            return aps;
        }

        public static AppSetting GetSetting()
        {
            var configFileName = Environment.CurrentDirectory + "\\" + AppDomain.CurrentDomain.FriendlyName + ".config";
            return GetSetting(configFileName);
        }

        public bool ExistKey(string aKey)
        {
            try
            {
                var appsetting = (XmlElement) appSettingsElement.SelectSingleNode("add[@key='" + aKey + "']");
                if (appsetting == null)
                    return false;

                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    public class RegSetting
    {
        public string c_RegistryKey { get; set; } = @"Software\Victory\eTicket";

        // set property cho _RegistryKey truoc khi goi 02 ham duoi day
        public string getValue(string aKey)
        {
            string avalue = null;
            var regKey = Registry.LocalMachine.OpenSubKey(c_RegistryKey);
            if (regKey != null)
            {
                avalue = (string) regKey.GetValue(aKey);
                regKey.Close();
            }

            return avalue;
        }

        public void setValue(string aKey, string val)
        {
            //RegistryKey regKey = Registry.CurrentUser.CreateSubKey(_RegistryKey);
            var regKey = Registry.LocalMachine.CreateSubKey(c_RegistryKey);
            regKey.SetValue(aKey, val);
            regKey.Close();
        }
    }
}