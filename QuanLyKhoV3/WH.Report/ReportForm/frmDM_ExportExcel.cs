using System;
using System.ComponentModel;
using System.Windows.Forms;
using HLVControl.Grid;
using HLVControl.Grid.Export;
using MetroUI.Forms;

namespace WH.Report.ReportForm
{
    public partial class FrmDmExportExcel : MetroForm
    {
        private readonly string _sNameFile;
        private readonly TreeListView _treeview;
        public bool IsChange;

        public FrmDmExportExcel(string nameFile, TreeListView treeview)
        {
            InitializeComponent();
            _treeview = treeview;
            _sNameFile = nameFile;
        }

        private void frmExportExcel_Load(object sender, EventArgs e)
        {
            txtFilename.Text = _sNameFile;
            txtSheetname.Text = @"sheet_" + _sNameFile;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                try
                {
                    var xlExport = new XLExport
                    {
                        CreateGroups = true,
                        ShowColumnHeaders = true,
                        OpenAfterExport = cbOpenAfterExport.Checked
                    };
                    xlExport.ExportFile(_treeview, folderBrowserDialog.SelectedPath +
                                                   "\\" + txtFilename.Text + ".xls", txtSheetname.Text);

                    DialogResult = DialogResult.OK;
                    IsChange = true;
                }
                catch (Win32Exception)
                {
                    MessageBox.Show(
                        @"Please uncheck 'Open file after export' if excel is not installed on your computer",
                        @"Error opening file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}