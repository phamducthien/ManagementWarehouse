using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace Util.Pattern
{
    public class OsInfo
    {
        public static readonly bool Is64BitProcess = IntPtr.Size == 8;
        public bool Is64BitOperatingSystem = Is64BitProcess || InternalCheckIsWow64();

        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWow64Process
        (
            [In] IntPtr hProcess,
            [Out] out bool wow64Process
        );

        //Check bit win.
        public static bool InternalCheckIsWow64()
        {
            if ((Environment.OSVersion.Version.Major != 5 || Environment.OSVersion.Version.Minor < 1) &&
                Environment.OSVersion.Version.Major < 6) return false;
            using (var p = Process.GetCurrentProcess())
            {
                bool retVal;
                return IsWow64Process(p.Handle, out retVal) && retVal;
            }
        }

        //Get name win
        public static string GetOsFriendlyName()
        {
            var result = string.Empty;
            var searcher = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem");
            foreach (var os in searcher.Get().Cast<ManagementObject>())
            {
                result = os["Caption"].ToString();
                break;
            }

            return result;
        }

        //Check software installed
        public static bool IsApplictionInstalled(string pName)
        {
            try
            {
                string displayName;

                // search in: CurrentUser
                var key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
                if (key != null)
                {
                    var key1 = key;
                    foreach (var subkey in key.GetSubKeyNames().Select(keyName => key1.OpenSubKey(keyName)))
                    {
                        displayName = subkey.GetValue("DisplayName") as string;
                        if (pName.Equals(displayName, StringComparison.OrdinalIgnoreCase)) return true;
                    }
                }

                // search in: LocalMachine_32
                key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
                if (key != null)
                {
                    var key1 = key;
                    foreach (var subkey in key.GetSubKeyNames().Select(keyName => key1.OpenSubKey(keyName)))
                    {
                        displayName = subkey.GetValue("DisplayName") as string;
                        if (pName.Equals(displayName, StringComparison.OrdinalIgnoreCase)) return true;
                    }
                }

                // search in: LocalMachine_64
                key =
                    Registry.LocalMachine.OpenSubKey(
                        @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall");
                if (key != null)
                    foreach (var subkey in key.GetSubKeyNames().Select(keyName => key.OpenSubKey(keyName)))
                    {
                        displayName = subkey.GetValue("DisplayName") as string;
                        if (pName.Equals(displayName, StringComparison.OrdinalIgnoreCase)) return true;
                    }
            }
            catch (Exception ex)
            {
                //MessageBoxEx.Show(ex.Message, 1000);
                throw ex;
            }

            // NOT FOUND
            return false;
        }

        //Get ten o cai win C:\
        public static string LetterWin()
        {
            return Path.GetPathRoot(Environment.SystemDirectory);
        }
    }
}