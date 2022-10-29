using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using WH.GUI.Dto;

namespace WH.GUI.ExportWarehouse
{
    public partial class FrmPrint : Form
    {
        private readonly Receipt _receipt;
        private readonly List<ReceiptItem> _receiptItem;

        public FrmPrint(Receipt receipt, List<ReceiptItem> receiptItems)
        {
            InitializeComponent();
            _receipt = receipt;
            _receiptItem = receiptItems;
        }

        private void frmPrint_Load(object sender, EventArgs e)
        {
            var rds = new ReportDataSource("ReceiptItem", _receiptItem);
            var para = new[]
            {
                new ReportParameter("pCustomerName", _receipt.CustomerName),
                new ReportParameter("pPhone", _receipt.Phone),
                new ReportParameter("pAddress", _receipt.Address),
                new ReportParameter("pDate", DateTime.Now.ToLongDateString()),
                new ReportParameter("pTotalAmount", _receipt.TotalAmount.ToString(CultureInfo.InvariantCulture)),
                new ReportParameter("pPayment", _receipt.Payment.ToString(CultureInfo.InvariantCulture)),
            };
            reportViewer1.LocalReport.SetParameters(para);
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }
    }
}
