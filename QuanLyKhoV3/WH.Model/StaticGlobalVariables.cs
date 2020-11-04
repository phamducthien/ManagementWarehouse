using System;
using System.IO;
using System.Windows.Forms;
using Util.Pattern;

namespace WH.Model
{
    public static class StaticGlobalVariables
    {
        public static string userID = SessionModel.CurrentSession.UserId;
        public static string khoID = SessionModel.CurrentSession.KhoMatHang.IDUnit;
        public static string posID = HardwareInfo.GetMacAddress();

        public static readonly string PathDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public static readonly string PathExcelTemp = Path.Combine(Application.StartupPath, "TemplateExcel");
        public static string PathTempFolder => Path.Combine(Application.StartupPath, "Temps");

        public static bool CheckTemps(bool begin)
        {
            try
            {
                if (Directory.Exists(PathTempFolder)) Directory.Delete(PathTempFolder, true);
            }
            catch
            {
                return false;
            }

            if (begin) Directory.CreateDirectory(PathTempFolder);
            return true;
        }
    }
}