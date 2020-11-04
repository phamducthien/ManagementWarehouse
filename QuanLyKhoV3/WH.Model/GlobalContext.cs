using System.Data.SqlClient;

namespace WH.Model
{
    public static class GlobalContext
    {
        //private static DateTime _MinDateTime = new DateTime(2000, 1, 1);
        //private static long _DefaultLong = 0;
        public static string SqlConnectionString { get; set; }
        public static string EntityConnectionString { get; set; }
        public static bool IsLoaded { get; set; }
        public static bool IsA4BarcodePrinterFormat { get; set; }
        public static string A4PrinterName { get; set; }
        public static string BillPrinterName { get; set; }
        public static SqlConnection ServerConnection { get; set; }
    }
}