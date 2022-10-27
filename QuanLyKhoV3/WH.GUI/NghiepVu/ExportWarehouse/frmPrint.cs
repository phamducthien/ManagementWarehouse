using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using WH.GUI.Dto;

namespace WH.GUI.ExportWarehouse
{
    public partial class frmPrint : Form
    {
        private readonly Receipt _receipt;
        private List<ReceiptItem> _receiptItem;

        public frmPrint(Receipt receipt, List<ReceiptItem> receiptItems)
        {
            InitializeComponent();
            _receipt = receipt;
            _receiptItem = receiptItems;
        }

        private void frmPrint_Load(object sender, EventArgs e)
        {
            var para = new[]
            {
                new ReportParameter("pCustomerName", _receipt.CustomerName),
                new ReportParameter("pPhone", _receipt.Phone),
                new ReportParameter("pAddress", _receipt.Address),
                new ReportParameter("pDate", DateTime.Now.ToShortDateString()),
            };
            reportViewer1.LocalReport.SetParameters(para);
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
