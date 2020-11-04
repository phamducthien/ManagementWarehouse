using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using WH.GUI;
using WH.Service;

namespace QuanLyKho
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (LoadContext())
                SingleApplication.Run(new FrmMain());
            else
                SingleApplication.Run(new FrmCauHinhKetNoi());
        }

        private static bool LoadContext()
        {
            IContextService service = new ContextService();
            var kq = service.LoadContext();
            if (!kq) MessageBox.Show(service.ErrMsg, @"Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return kq;
        }

        public class SingleApplication
        {
            private const int SwRestore = 9;
            private static Mutex _mutex;

            /// <summary>
            ///     Imports
            /// </summary>
            [DllImport("user32.dll")]
            private static extern int ShowWindow(IntPtr hWnd, int nCmdShow);

            [DllImport("user32.dll")]
            private static extern int SetForegroundWindow(IntPtr hWnd);

            [DllImport("user32.dll")]
            private static extern int IsIconic(IntPtr hWnd);

            /// <summary>
            ///     GetCurrentInstanceWindowHandle
            /// </summary>
            /// <returns></returns>
            private static IntPtr GetCurrentInstanceWindowHandle()
            {
                var hWnd = IntPtr.Zero;
                var process = Process.GetCurrentProcess();
                var processes = Process.GetProcessesByName(process.ProcessName);
                foreach (var _process in processes.Where(_process => _process.Id != process.Id &&
                                                                     _process.MainModule.FileName ==
                                                                     process.MainModule.FileName &&
                                                                     _process.MainWindowHandle != IntPtr.Zero))
                {
                    hWnd = _process.MainWindowHandle;
                    break;
                }

                return hWnd;
            }

            /// <summary>
            ///     SwitchToCurrentInstance
            /// </summary>
            private static void SwitchToCurrentInstance()
            {
                var hWnd = GetCurrentInstanceWindowHandle();
                if (hWnd != IntPtr.Zero)
                {
                    // Restore window if minimised. Do not restore if already in
                    // normal or maximised window state, since we don't want to
                    // change the current state of the window.
                    if (IsIconic(hWnd) != 0) ShowWindow(hWnd, SwRestore);

                    // Set foreground window.
                    SetForegroundWindow(hWnd);
                }
            }

            /// <summary>
            ///     Execute a form base application if another instance already running on
            ///     the system activate previous one
            /// </summary>
            /// <param name="frmMain">main form</param>
            /// <returns>true if no previous instance is running</returns>
            public static bool Run(Form frmMain)
            {
                if (IsAlreadyRunning())
                {
                    //set focus on previously running app
                    SwitchToCurrentInstance();
                    return false;
                }

                Application.Run(frmMain);
                return true;
            }

            /// <summary>
            ///     for console base application
            /// </summary>
            /// <returns></returns>
            public static bool Run()
            {
                if (IsAlreadyRunning()) return false;
                return true;
            }

            /// <summary>
            ///     check if given exe alread running or not
            /// </summary>
            /// <returns>returns true if already running</returns>
            public static bool IsAlreadyRunning()
            {
                var strLoc = Assembly.GetExecutingAssembly().Location;
                FileSystemInfo fileInfo = new FileInfo(strLoc);
                var sExeName = fileInfo.Name;
                bool bCreatedNew;

                _mutex = new Mutex(true, "Global\\" + sExeName, out bCreatedNew);
                if (bCreatedNew)
                    _mutex.ReleaseMutex();

                return !bCreatedNew;
            }
        }
    }
}