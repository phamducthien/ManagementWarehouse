using System;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using HLVControl.Grid;

namespace WH.Report.ReportForm
{
    public class UIHelper
    {
        public static void LoadFocus(object sender)
        {
            if (sender is Button)
            {
                var btn = sender as Button;
                btn.Select();
                btn.Focus();
            }

            if (sender is TextBox)
            {
                var txt = sender as TextBox;
                txt.Select();
                txt.Focus();
            }

            if (sender is KryptonTextBox)
            {
                var txt = sender as KryptonTextBox;
                txt.Select();
                txt.Focus();
            }

            if (sender is KryptonRichTextBox)
            {
                var txt = sender as KryptonRichTextBox;
                txt.Select();
                txt.Focus();
            }

            if (sender is NumericUpDown)
            {
                var num = sender as NumericUpDown;
                num.Select();
                num.Focus();
            }

            //if (sender is ComboBox)
            //{
            //    ComboBox mulcobo = sender as ComboBox;
            //    mulcobo.Select();
            //    mulcobo.Focus();
            //}
            if (sender is ComboBox)
            {
                var cobo = sender as ComboBox;
                cobo.Select();
                cobo.Focus();
            }

            if (sender is DateTimePicker)
            {
                var date = sender as DateTimePicker;
                date.Select();
                date.Focus();
            }

            if (sender is TreeListView)
            {
                var treeview = sender as TreeListView;
                treeview.Select();
                treeview.Focus();
            }
        }

        public static void txt_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                var txt = sender as TextBox;
                txt.BackColor = Color.FromArgb(255, 255, 128);
            }

            if (sender is KryptonTextBox)
            {
                var txt = sender as KryptonTextBox;
                txt.BackColor = Color.FromArgb(255, 255, 128);
            }

            if (sender is KryptonRichTextBox)
            {
                var txt = sender as KryptonRichTextBox;
                txt.BackColor = Color.FromArgb(255, 255, 128);
            }

            if (sender is NumericUpDown)
            {
                var num = sender as NumericUpDown;
                num.BackColor = Color.FromArgb(255, 255, 128);
            }

            //if (sender is MultiColumnComboBox)
            //{
            //    MultiColumnComboBox mulcobo = sender as MultiColumnComboBox;
            //    mulcobo.BackColor = Color.FromArgb(255, 255, 128);
            //}
            if (sender is ComboBox)
            {
                var cobo = sender as ComboBox;
                cobo.BackColor = Color.FromArgb(255, 255, 128);
            }

            if (sender is DateTimePicker)
            {
                var date = sender as DateTimePicker;
                date.BackColor = Color.FromArgb(255, 255, 128);
            }

            if (sender is TreeListView)
            {
                var treeview = sender as TreeListView;
                //treeview.BackColor = Color.FromArgb(255, 255, 128);
            }
        }

        public static void txt_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                var txt = sender as TextBox;
                txt.BackColor = Color.White;
            }

            if (sender is KryptonTextBox)
            {
                var txt = sender as KryptonTextBox;
                txt.BackColor = Color.White;
            }

            if (sender is KryptonRichTextBox)
            {
                var txt = sender as KryptonRichTextBox;
                txt.BackColor = Color.White;
            }

            if (sender is NumericUpDown)
            {
                var num = sender as NumericUpDown;
                num.BackColor = Color.White;
            }

            //if (sender is MultiColumnComboBox)
            //{
            //    MultiColumnComboBox mulcobo = sender as MultiColumnComboBox;
            //    mulcobo.BackColor = Color.White;
            //}
            if (sender is ComboBox)
            {
                var cobo = sender as ComboBox;
                cobo.BackColor = Color.White;
            }

            if (sender is DateTimePicker)
            {
                var date = sender as DateTimePicker;
                date.BackColor = Color.White;
            }

            if (sender is TreeListView)
            {
                var treeview = sender as TreeListView;
                //treeview.BackColor = Color.FromArgb(255, 255, 128);
            }
        }

        public static void txt_KeyPress(object sender, object senderFocus, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (senderFocus is Button)
                {
                    var btn = senderFocus as Button;
                    btn.PerformClick();
                }

                if (senderFocus is TextBox)
                {
                    var txt1 = senderFocus as TextBox;
                    txt1.Focus();
                }

                if (senderFocus is NumericUpDown)
                {
                    var num = senderFocus as NumericUpDown;
                    num.Focus();
                }

                //if (sender is MultiColumnComboBox)
                //{
                //    MultiColumnComboBox mulcobo = sender as MultiColumnComboBox;
                //    mulcobo.Focus();
                //}
                if (sender is ComboBox)
                {
                    var cobo = sender as ComboBox;
                    cobo.Focus();
                }

                if (sender is DateTimePicker)
                {
                    var date = sender as DateTimePicker;
                    date.Focus();
                }

                if (sender is TreeListView)
                {
                    var treeview = sender as TreeListView;
                    treeview.Focus();
                }
            }
        }
    }
}