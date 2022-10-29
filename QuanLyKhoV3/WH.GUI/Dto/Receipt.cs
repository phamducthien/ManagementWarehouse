using System;
using System.Collections.Generic;

namespace WH.GUI.Dto
{
    public class Receipt
    {
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Payment { get; set; }
        public DateTime CreatedDate { get; set; }

        public List<ReceiptItem> ReceiptItems { get; set; }
    }

    public class ReceiptItem
    {
        public int Number { get; set; }
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal Units { get; set; }
        public double Discount { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
    }
}
