using System;
using System.Globalization;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using Util.Pattern.Encryptor;

namespace Util.Pattern
{
    public static class HardwareInfo
    {
        /// <summary>
        ///     Retrieving Processor Id.
        /// </summary>
        /// <returns></returns>
        public static string GetProcessorId()
        {
            var mc = new ManagementClass("win32_processor");
            var moc = mc.GetInstances();
            var id = string.Empty;
            foreach (var mo in moc.Cast<ManagementObject>())
            {
                id = mo.Properties["processorID"].Value.ToString();
                break;
            }

            return id;
        }

        /// <summary>
        ///     Retrieving HDD Serial No.
        /// </summary>
        /// <returns></returns>
        public static string GetHddSerialNo()
        {
            var mangnmt = new ManagementClass("Win32_LogicalDisk");
            var mcol = mangnmt.GetInstances();
            return mcol.Cast<ManagementObject>()
                .Aggregate("", (current, strt) => current + Convert.ToString(strt["VolumeSerialNumber"]));
        }

        /// <summary>
        ///     Retrieving System MAC Address.
        /// </summary>
        /// <returns></returns>
        public static string GetMacAddress()
        {
            var mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            var moc = mc.GetInstances();
            var macAddress = string.Empty;
            foreach (var mo in moc.Cast<ManagementObject>())
            {
                if (macAddress == string.Empty)
                    if ((bool) mo["IPEnabled"])
                        macAddress = mo["MacAddress"].ToString();
                mo.Dispose();
            }

            macAddress = macAddress.Replace(":", "");
            return macAddress;
        }

        /// <summary>
        ///     Retrieving Motherboard Manufacturer.
        /// </summary>
        /// <returns></returns>
        public static string GetBoardMaker()
        {
            var searcher = new ManagementObjectSearcher("root\\CIMV2",
                "SELECT * FROM Win32_BaseBoard");

            foreach (var wmi in searcher.Get().Cast<ManagementObject>())
                try
                {
                    return wmi.GetPropertyValue("Manufacturer").ToString();
                }

                catch
                {
                    return null;
                }

            return "Board Maker: Unknown";
        }

        /// <summary>
        ///     Retrieving Motherboard Product Id.
        /// </summary>
        /// <returns></returns>
        public static string GetBoardProductId()
        {
            var searcher = new ManagementObjectSearcher("root\\CIMV2",
                "SELECT * FROM Win32_BaseBoard");

            foreach (var wmi in searcher.Get().Cast<ManagementObject>())
                try
                {
                    return wmi.GetPropertyValue("Product").ToString();
                }
                catch
                {
                    return null;
                }

            return "Product: Unknown";
        }

        /// <summary>
        ///     Retrieving CD-DVD Drive Path.
        /// </summary>
        /// <returns></returns>
        public static string GetCdRomDrive()
        {
            var searcher = new ManagementObjectSearcher("root\\CIMV2",
                "SELECT * FROM Win32_CDROMDrive");

            foreach (var wmi in searcher.Get().Cast<ManagementObject>())
                try
                {
                    return wmi.GetPropertyValue("Drive").ToString();
                }
                catch
                {
                    return null;
                }

            return "CD ROM Drive Letter: Unknown";
        }

        /// <summary>
        ///     Retrieving BIOS Maker.
        /// </summary>
        /// <returns></returns>
        public static string GetBioSmaker()
        {
            var searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BIOS");

            foreach (var wmi in searcher.Get().Cast<ManagementObject>())
                try
                {
                    return wmi.GetPropertyValue("Manufacturer").ToString();
                }

                catch
                {
                    return null;
                }

            return "BIOS Maker: Unknown";
        }

        /// <summary>
        ///     Retrieving BIOS Serial No.
        /// </summary>
        /// <returns></returns>
        public static string GetBioSserNo()
        {
            var searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BIOS");

            foreach (var wmi in searcher.Get().Cast<ManagementObject>())
                try
                {
                    return wmi.GetPropertyValue("SerialNumber").ToString();
                }

                catch
                {
                    return null;
                }

            return "BIOS Serial Number: Unknown";
        }

        /// <summary>
        ///     Retrieving BIOS Caption.
        /// </summary>
        /// <returns></returns>
        public static string GetBioScaption()
        {
            var searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BIOS");

            foreach (var wmi in searcher.Get().Cast<ManagementObject>())
                try
                {
                    return wmi.GetPropertyValue("Caption").ToString();
                }
                catch
                {
                    return null;
                }

            return "BIOS Caption: Unknown";
        }

        /// <summary>
        ///     Retrieving System Account Name.
        /// </summary>
        /// <returns></returns>
        public static string GetAccountName()
        {
            var searcher = new ManagementObjectSearcher("root\\CIMV2",
                "SELECT * FROM Win32_UserAccount");

            foreach (var wmi in searcher.Get().Cast<ManagementObject>())
                try
                {
                    return wmi.GetPropertyValue("Name").ToString();
                }
                catch
                {
                    return null;
                }

            return "User Account Name: Unknown";
        }

        /// <summary>
        ///     Retrieving Physical Ram Memory.
        /// </summary>
        /// <returns></returns>
        public static string GetPhysicalMemory()
        {
            var oMs = new ManagementScope();
            var oQuery = new ObjectQuery("SELECT Capacity FROM Win32_PhysicalMemory");
            var oSearcher = new ManagementObjectSearcher(oMs, oQuery);
            var oCollection = oSearcher.Get();

            var memSize = oCollection.Cast<ManagementObject>().Sum(obj => Convert.ToInt64(obj["Capacity"]));

            // In case more than one Memory sticks are installed
            memSize = memSize / 1024 / 1024;
            return memSize + "MB";
        }

        /// <summary>
        ///     Retrieving No of Ram Slot on Motherboard.
        /// </summary>
        /// <returns></returns>
        public static string GetNoRamSlots()
        {
            var memSlots = 0;
            var oMs = new ManagementScope();
            var oQuery2 = new ObjectQuery("SELECT MemoryDevices FROM Win32_PhysicalMemoryArray");
            var oSearcher2 = new ManagementObjectSearcher(oMs, oQuery2);
            var oCollection2 = oSearcher2.Get();
            foreach (var obj in oCollection2.Cast<ManagementObject>()) memSlots = Convert.ToInt32(obj["MemoryDevices"]);
            return memSlots.ToString(CultureInfo.InvariantCulture);
        }

        //Get CPU Temprature.
        /// <summary>
        ///     method for retrieving the CPU Manufacturer
        ///     using the WMI class
        /// </summary>
        /// <returns>CPU Manufacturer</returns>
        public static string GetCpuManufacturer()
        {
            string[] cpuMan = {string.Empty};
            //create an instance of the Managemnet class with the
            //Win32_Processor class
            var mgmt = new ManagementClass("Win32_Processor");
            //create a ManagementObjectCollection to loop through
            var objCol = mgmt.GetInstances();
            //start our loop for all processors found
            foreach (var obj in objCol.Cast<ManagementObject>().Where(obj => cpuMan[0] == string.Empty))
                // only return manufacturer from first CPU
                cpuMan[0] = obj.Properties["Manufacturer"].Value.ToString();
            return cpuMan[0];
        }

        /// <summary>
        ///     method to retrieve the CPU's current
        ///     clock speed using the WMI class
        /// </summary>
        /// <returns>Clock speed</returns>
        public static int GetCpuCurrentClockSpeed()
        {
            int[] cpuClockSpeed = {0};
            //create an instance of the Managemnet class with the
            //Win32_Processor class
            var mgmt = new ManagementClass("Win32_Processor");
            //create a ManagementObjectCollection to loop through
            var objCol = mgmt.GetInstances();
            //start our loop for all processors found
            foreach (var obj in objCol.Cast<ManagementObject>().Where(obj => cpuClockSpeed[0] == 0))
                // only return cpuStatus from first CPU
                cpuClockSpeed[0] = Convert.ToInt32(obj.Properties["CurrentClockSpeed"].Value.ToString());
            //return the status
            return cpuClockSpeed[0];
        }

        /// <summary>
        ///     method to retrieve the network adapters
        ///     default IP gateway using WMI
        /// </summary>
        /// <returns>adapters default IP gateway</returns>
        public static string GetDefaultIpGateway()
        {
            //create out management class object using the
            //Win32_NetworkAdapterConfiguration class to get the attributes
            //of the network adapter
            var mgmt = new ManagementClass("Win32_NetworkAdapterConfiguration");
            //create our ManagementObjectCollection to get the attributes with
            var objCol = mgmt.GetInstances();
            var gateway = string.Empty;
            //loop through all the objects we find
            foreach (var o in objCol)
            {
                var obj = (ManagementObject) o;
                if (gateway == string.Empty) // only return MAC Address from first card
                    if ((bool) obj["IPEnabled"])
                        gateway = obj["DefaultIPGateway"].ToString();
                //dispose of our object
                obj.Dispose();
            }

            //replace the ":" with an empty space, this could also
            //be removed if you wish
            gateway = gateway.Replace(":", "");
            //return the mac address
            return gateway;
        }

        /// <summary>
        ///     Retrieve CPU Speed.
        /// </summary>
        /// <returns></returns>
        public static double? GetCpuSpeedInGHz()
        {
            double? gHz = null;
            using (var mc = new ManagementClass("Win32_Processor"))
            {
                foreach (var o in mc.GetInstances())
                {
                    var mo = (ManagementObject) o;
                    gHz = 0.001 * (uint) mo.Properties["CurrentClockSpeed"].Value;
                    break;
                }
            }

            return gHz;
        }


        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        /// <summary>
        ///     Retrieve Win's Info.
        /// </summary>
        /// <returns></returns>
        public static string GetActiveWindowTitle()
        {
            const int nChars = 256;
            var buff = new StringBuilder(nChars);
            var handle = GetForegroundWindow();

            return GetWindowText(handle, buff, nChars) > 0 ? buff.ToString() : null;
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

        public static string GetKeySystem()
        {
            var key = Security.Encrypt(GetProcessorId() + GetMacAddress() + GetOsFriendlyName() + "!@kt@", "!@ZCCCz@");
            return key;
        }

        public static byte[] GetSec7Bytes(bool isRegister)
        {
            var charStrings = GetKeySystem().ToCharArray();
            if (charStrings.Count() > 7)
            {
                string key;
                if (isRegister)
                    key = charStrings[0] + charStrings[8] + charStrings[3] + charStrings[6] + charStrings[2] +
                          charStrings[10] + "Y";
                else
                    key = charStrings[0] + charStrings[8] + charStrings[3] + charStrings[6] + charStrings[2] +
                          charStrings[10] + "N";
                return Encoding.UTF8.GetBytes(key);
            }

            return null;
        }
    }
}