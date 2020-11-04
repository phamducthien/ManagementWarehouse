namespace WH.Model
{
    public class ConfigurationModel
    {
        public string Server { get; set; }
        public string UserName { get; set; }
        public string PlainPassword { get; set; }
        public string EncryptedPassword { get; set; }
        public string DbName { get; set; }
        public string A4PrinterName { get; set; }
        public string BillPrinterName { get; set; }
        public bool IsBarcodePrinterA4 { get; set; }
    }
}