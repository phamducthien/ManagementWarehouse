using System;
using MetroUI.Forms;

namespace WH.Report.ReportForm
{
    public partial class FrmSelectTop : MetroForm
    {
        public FrmSelectTop()
        {
            InitializeComponent();
        }

        public int top { get; set; }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                top = int.Parse(txtTop.Text);
            }
            catch
            {
                top = 0;
            }

            Close();
        }

        private void btnTop10_Click(object sender, EventArgs e)
        {
            top = 10;
            Close();
        }

        private void btnTop50_Click(object sender, EventArgs e)
        {
            top = 50;
            Close();
        }

        private void btnTop100_Click(object sender, EventArgs e)
        {
            top = 100;
            Close();
        }
    }
}