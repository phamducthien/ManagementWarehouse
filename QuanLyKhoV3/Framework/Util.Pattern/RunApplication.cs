using System.Diagnostics;

namespace Util.Pattern
{
    public enum WindowStyle
    {
        Normal,
        Minimized,
        Maximized,
        Hide
    }

    public static class RunApplication
    {
        public static void RunApp(string fileName, string arguments, bool isWaitToExit, WindowStyle style)
        {
            var myProcess = new Process();
            var info = new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = arguments,
                Verb = "runas",
                UseShellExecute = true,
                CreateNoWindow = true
            };

            switch (style)
            {
                case WindowStyle.Hide:
                    info.WindowStyle = ProcessWindowStyle.Hidden;
                    break;
                case WindowStyle.Maximized:
                    info.WindowStyle = ProcessWindowStyle.Maximized;
                    break;
                case WindowStyle.Minimized:
                    info.WindowStyle = ProcessWindowStyle.Minimized;
                    break;
                case WindowStyle.Normal:
                    info.WindowStyle = ProcessWindowStyle.Normal;
                    break;
            }

            myProcess.StartInfo = info;
            myProcess.Start();
            if (isWaitToExit)
                myProcess.WaitForExit();
            myProcess.Dispose();
        }
    }
}