using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WH.Service.Service;

namespace WH.Report
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (LoadContext())
            {
                Application.Run(new frmReportMain());
            }
            else
            {
                Application.Exit();
            }
        }

        static bool LoadContext()
        {
            IContextService service = new ContextService();
            bool kq = service.LoadContext();
            if (!kq)
            {
                MessageBox.Show(service.ErrMsg, @"Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return kq;
        }
    }
}
