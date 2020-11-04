using System;
using System.Collections.Generic;
using System.Management;

/// 2014-10-01 Sử dụng file này cho các hệ thống về sau
namespace Util.Pattern.Printer
{
    public class Printer
    {
        public string Name { get; set; }

        public string DeviceID { get; set; }

        public string PortName { get; set; }

        public uint M_State { get; set; }

        public bool IsPrinterReader => fn_isPrinterReady();

        private bool fn_isPrinterReady()
        {
            var scope = new ManagementScope(@"\root\cimv2");
            var searcher = new ManagementObjectSearcher("select * from Win32_Printer where Name ='" + Name + "'");

            var printer_list = searcher.Get();
            if (printer_list.Count == 0)
                return false;

            foreach (ManagementObject printer in printer_list)
            {
                if (printer["WorkOffline"].ToString().ToLower().Equals("true")) return false;

                M_State = Convert.ToUInt32(printer["PrinterState"]);
                //m_ErrMsg = PrinterStatus_Msg.GetPrinterStatusMsg(m_state);
            }

            return M_State == 0;
        }
    }

    public class Printer_Util
    {
        public string ErrMsg { get; set; }

        #region Get Printers In Computer

        public List<Printer> GetPrinterList()
        {
            var lstPrinter = new List<Printer>();

            ManagementObjectCollection printers_mgmtobjcoll;

            var scope = new ManagementScope(@"\root\cimv2");
            var searcher = new ManagementObjectSearcher("select * from Win32_Printer");
            printers_mgmtobjcoll = searcher.Get();

            //Printer printer;

            foreach (ManagementObject mgmtobj in printers_mgmtobjcoll)
                try
                {
                    lstPrinter.Add(new Printer
                    {
                        Name = mgmtobj["Name"].ToString(),
                        DeviceID = mgmtobj["DeviceID"].ToString(),
                        PortName = mgmtobj["PortName"].ToString()
                    });
                }
                catch
                {
                }

            //printer = new Printer();
            //printer.Name = mgmtobj["Name"].ToString();
            //printer.DeviceID = mgmtobj["DeviceID"].ToString();
            //printer.PortName = mgmtobj["PortName"].ToString();
            //lstPrinter.Add(printer);

            return lstPrinter;
        }

        #endregion
    }
}