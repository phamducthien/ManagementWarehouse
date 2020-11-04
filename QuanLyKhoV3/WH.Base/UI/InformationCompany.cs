using System;
using System.Drawing;
using System.IO;

namespace WH.Base.UI
{
    public class InformationCompany
    {
        //private readonly AppSetting _appSetting;
        private readonly string _dirFilename;
        public InformationCompany()
        {
            //_appSetting = new AppSetting();
            _dirFilename = Path.GetPathRoot(Environment.SystemDirectory) + @"FConfig";
        }

        //public string NameAppAdmin = "Finger Talk Admin";
        //public string NameAppAgency = "Finger Talk Agency";
        //public string NameAppClient = "Finger Talk Client";

        //public string Name => _appSetting.GetValue("Name");

        //public string HotLine => _appSetting.GetValue("HotLine");

        //public string Address => _appSetting.GetValue("Address");

        //public string Phone => _appSetting.GetValue("Phone");

        //public string Email => _appSetting.GetValue("Email");

        //public string InfoSuplier => _appSetting.GetValue("InfoSuplier");

        //public  string Info => Name + "- Địa Chỉ: " + Address + " - Email: " + Email + " - Điện thoại: " + Phone;


        public Image LogoImage
        {
            get
            {
                Image img;
                try
                {
                    if (!File.Exists(_dirFilename + @"\logo.jpg"))
                        File.Copy("logo.jpg", _dirFilename + @"\logo.jpg", true);

                    img = Image.FromFile(_dirFilename + @"\logo.jpg");
                }
                catch
                {
                    return Properties.Resources.logodemo;
                }
                return img;
            }
            
        }

        public Image FlashImage
        {
            get
            {
                Image img;
                try
                {
                    if(!File.Exists(_dirFilename + @"\bg.jpg"))
                        File.Copy("bg.jpg", _dirFilename + @"\bg.jpg",true);

                    img = Image.FromFile(_dirFilename + @"\bg.jpg");
                }
                catch
                {
                    return Properties.Resources.bg;
                }
                return img;
            }
        }
    }
}
