using System.Windows.Forms;

namespace WH.GUI
{
    public partial class FrmUserControl : FrmBase
    {
        public FrmUserControl(UserControl userControl)
        {
            InitializeComponent();
            userControl.Dock = DockStyle.Fill;
            Controls.Add(userControl);
            ResumeLayout(true);
        }
    }
}