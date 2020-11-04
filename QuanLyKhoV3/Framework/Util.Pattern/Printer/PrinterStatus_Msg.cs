using System;

namespace Util.Pattern.Printer
{
    public class PrinterStatus_Msg
    {
        public static string GetPrinterStatusMsg(uint status)
        {
            var rslt = string.Empty;
            if (status == 0)
                return "Ready";

            if ((status & (uint) PrinterStatus.PS_PAUSED) != 0) rslt += "Paused; ";
            if ((status & (uint) PrinterStatus.PS_ERROR) != 0) rslt += "Error; ";
            if ((status & (uint) PrinterStatus.PS_PENDING_DELETION) != 0) rslt += "Pending deletion; ";
            if ((status & (uint) PrinterStatus.PS_PAPER_JAM) != 0) rslt += "Paper jam; ";
            if ((status & (uint) PrinterStatus.PS_PAPER_OUT) != 0) rslt += "Paper out; ";
            if ((status & (uint) PrinterStatus.PS_MANUAL_FEED) != 0) rslt += "Manual feed; ";
            if ((status & (uint) PrinterStatus.PS_PAPER_PROBLEM) != 0) rslt += "Paper problem; ";
            if ((status & (uint) PrinterStatus.PS_OFFLINE) != 0) rslt += "Offline; ";
            if ((status & (uint) PrinterStatus.PS_IO_ACTIVE) != 0) rslt += "I/O active; ";
            if ((status & (uint) PrinterStatus.PS_BUSY) != 0) rslt += "Busy; ";
            if ((status & (uint) PrinterStatus.PS_PRINTING) != 0) rslt += "Printing; ";
            if ((status & (uint) PrinterStatus.PS_OUTPUT_BIN_FULL) != 0) rslt += "Output bin full; ";
            if ((status & (uint) PrinterStatus.PS_NOT_AVAILABLE) != 0) rslt += "Not available; ";
            if ((status & (uint) PrinterStatus.PS_WAITING) != 0) rslt += "Waiting; ";
            if ((status & (uint) PrinterStatus.PS_PROCESSING) != 0) rslt += "Processing; ";
            if ((status & (uint) PrinterStatus.PS_INITIALIZING) != 0) rslt += "Initializing; ";
            if ((status & (uint) PrinterStatus.PS_WARMING_UP) != 0) rslt += "Warming up; ";
            if ((status & (uint) PrinterStatus.PS_TONER_LOW) != 0) rslt += "Toner low; ";
            if ((status & (uint) PrinterStatus.PS_NO_TONER) != 0) rslt += "No toner; ";
            if ((status & (uint) PrinterStatus.PS_PAGE_PUNT) != 0) rslt += "Page punt; ";
            if ((status & (uint) PrinterStatus.PS_USER_INTERVENTION) != 0) rslt += "User intervention; ";
            if ((status & (uint) PrinterStatus.PS_OUT_OF_MEMORY) != 0) rslt += "Out of memory; ";
            if ((status & (uint) PrinterStatus.PS_DOOR_OPEN) != 0) rslt += "Door open; ";
            if ((status & (uint) PrinterStatus.PS_SERVER_UNKNOWN) != 0) rslt += "Server unkown; ";
            if ((status & (uint) PrinterStatus.PS_POWER_SAVE) != 0) rslt += "Power save; ";
            return rslt;
        }

        [Flags]
        internal enum PrinterStatus : uint
        {
            PS_PAUSED = 0x00000001,
            PS_ERROR = 0x00000002,
            PS_PENDING_DELETION = 0x00000004,
            PS_PAPER_JAM = 0x00000008,
            PS_PAPER_OUT = 0x00000010,
            PS_MANUAL_FEED = 0x00000020,
            PS_PAPER_PROBLEM = 0x00000040,
            PS_OFFLINE = 0x00000080,
            PS_IO_ACTIVE = 0x00000100,
            PS_BUSY = 0x00000200,
            PS_PRINTING = 0x00000400,
            PS_OUTPUT_BIN_FULL = 0x00000800,
            PS_NOT_AVAILABLE = 0x00001000,
            PS_WAITING = 0x00002000,
            PS_PROCESSING = 0x00004000,
            PS_INITIALIZING = 0x00008000,
            PS_WARMING_UP = 0x00010000,
            PS_TONER_LOW = 0x00020000,
            PS_NO_TONER = 0x00040000,
            PS_PAGE_PUNT = 0x00080000,
            PS_USER_INTERVENTION = 0x00100000,
            PS_OUT_OF_MEMORY = 0x00200000,
            PS_DOOR_OPEN = 0x00400000,
            Printer,
            PS_SERVER_UNKNOWN = 0x00800000,
            PS_POWER_SAVE = 0x01000000
        }
    }
}