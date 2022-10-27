using System.Collections.Generic;

namespace WH.GUI.Dto
{
    public class Receipt
    {
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string TotalAmount { get; set; }
        public string Payment { get; set; }
        public string Description { get; set; }

        public List<ReceiptItem> ReceiptItems { get; set; }
    }

    public class ReceiptItem
    {
        public string Stt { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Units { get; set; }
        public string Discount { get; set; }
        public string Price { get; set; }
        public string Amount { get; set; }
    }
}
