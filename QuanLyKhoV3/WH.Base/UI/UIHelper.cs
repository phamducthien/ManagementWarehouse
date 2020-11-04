using System;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using MetroFramework.Controls;
using System.Collections.Generic;

namespace WH.Base.UI
{
    public static class UiHelper
    {
        public static void LoadFocus(object sender)
        {
            var button = sender as Button;
            if (button != null)
            {
                var btn = button;
                btn.Select();
                btn.Focus();
            }
            var box1 = sender as TextBox;
            if (box1 != null)
            {
                var txt = box1;
                txt.Select();
                txt.Focus();
            }

            var kryptonTextBox = sender as KryptonTextBox;
            if (kryptonTextBox != null)
            {
                var txt = kryptonTextBox;
                txt.Select();
                txt.Focus();
            }

            var textBox = sender as KryptonRichTextBox;
            if (textBox != null)
            {
                var txt = textBox;
                txt.Select();
                txt.Focus();
            }

            var down = sender as NumericUpDown;
            if (down != null)
            {
                var num = down;
                num.Select();
                num.Focus();
            }
            //if (sender is ComboBox)
            //{
            //    ComboBox mulcobo = sender as ComboBox;
            //    mulcobo.Select();
            //    mulcobo.Focus();
            //}
            var comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                var cobo = comboBox;
                cobo.Select();
                cobo.Focus();
            }

            var box = sender as KryptonComboBox;
            if (box != null)
            {
                var cobo = box;
                cobo.Select();
                cobo.Focus();
            }

            var picker = sender as DateTimePicker;
            if (picker != null)
            {
                var date = picker;
                date.Select();
                date.Focus();
            }

            //var listView = sender as TreeListView;
            //if (listView != null)
            //{
            //    var treeview = listView;
            //    treeview.Select();
            //    treeview.Focus();
            //}
            var view = sender as KryptonDataGridView;
            if (view != null)
            {
                var dgv = view;
                dgv.Select();
                dgv.Focus();
            }
        }

        public static void txt_Enter(object sender, EventArgs e)
        {
            var box1 = sender as TextBox;
            if (box1 != null)
            {
                var txt = box1;
                txt.BackColor = Color.FromArgb(255, 255, 128);
            }
            var kryptonTextBox = sender as KryptonTextBox;
            if (kryptonTextBox != null)
            {
                var txt = kryptonTextBox;
                txt.StateCommon.Back.Color1 = Color.FromArgb(255, 255, 128);
            }
            var textBox = sender as KryptonRichTextBox;
            if (textBox != null)
            {
                var txt = textBox;
                txt.StateCommon.Back.Color1 = Color.FromArgb(255, 255, 128);
            }
            var upDown = sender as NumericUpDown;
            if (upDown != null)
            {
                var num = upDown;
                num.BackColor = Color.FromArgb(255, 255, 128);
            }

            var down = sender as KryptonNumericUpDown;
            if (down != null)
            {
                var num = down;
                num.StateCommon.Back.Color1 = Color.FromArgb(255, 255, 128);
            }

            //if (sender is MultiColumnComboBox)
            //{
            //    MultiColumnComboBox mulcobo = sender as MultiColumnComboBox;
            //    mulcobo.BackColor = Color.FromArgb(255, 255, 128);
            //}
            var comboBox = sender as KryptonComboBox;
            if (comboBox != null)
            {
                var cobo = comboBox;
                cobo.StateCommon.ComboBox.Back.Color1 = Color.FromArgb(255, 255, 128);
            }

            var box = sender as ComboBox;
            if (box != null)
            {
                var cobo = box;
                cobo.BackColor = Color.FromArgb(255, 255, 128);
            }

            var picker = sender as DateTimePicker;
            if (picker != null)
            {
                var date = picker;
                date.BackColor = Color.FromArgb(255, 255, 128);
            }
            //var listView = sender as TreeListView;
            //if (listView != null)
            //{
            //    var treeview = listView;
            //    //treeview.BackColor = Color.FromArgb(255, 255, 128);
            //}
            var view = sender as KryptonDataGridView;
            if (view != null)
            {
                var dgv = view;
            }
        }

        public static void txt_Leave(object sender, EventArgs e)
        {
            var box1 = sender as TextBox;
            if (box1 != null)
            {
                var txt = box1;
                txt.BackColor = Color.White;
            }
            var kryptonTextBox = sender as KryptonTextBox;
            if (kryptonTextBox != null)
            {
                var txt = kryptonTextBox;
                txt.StateCommon.Back.Color1 = Color.White;
            }
            var textBox = sender as KryptonRichTextBox;
            if (textBox != null)
            {
                var txt = textBox;
                txt.StateCommon.Back.Color1 = Color.White;
            }
            var upDown = sender as NumericUpDown;
            if (upDown != null)
            {
                var num = upDown;
                num.BackColor = Color.White;
            }

            var down = sender as KryptonNumericUpDown;
            if (down != null)
            {
                var num = down;
                num.StateCommon.Back.Color1 = Color.White;
            }

            //if (sender is MultiColumnComboBox)
            //{
            //    MultiColumnComboBox mulcobo = sender as MultiColumnComboBox;
            //    mulcobo.BackColor = Color.White;
            //}
            var comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                var cobo = comboBox;
                cobo.BackColor = Color.White;
            }

            var box = sender as KryptonComboBox;
            if (box != null)
            {
                var cobo = box;
                cobo.StateCommon.ComboBox.Back.Color1 = Color.White;
            }

            var picker = sender as DateTimePicker;
            if (picker != null)
            {
                var date = picker;
                date.BackColor = Color.White;
            }
            //var listView = sender as TreeListView;
            //if (listView != null)
            //{
            //    var treeview = listView;
            //    //treeview.BackColor = Color.FromArgb(255, 255, 128);
            //}
            var view = sender as KryptonDataGridView;
            if (view != null)
            {
                var dgv = view;
                //if (dgv.SelectedRows.Count > 0)
                //    dgv.SelectedRows[0].Selected = false;
            }
        }

        public static void txt_KeyPress(object sender, object senderFocus, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (senderFocus != null)
                {
                    var button = senderFocus as Button;
                    if (button != null)
                    {
                        var btn = button;
                        btn.PerformClick();
                    }

                    var box = senderFocus as TextBox;
                    if (box != null)
                    {
                        var txt1 = box;
                        txt1.Select();
                        txt1.SelectAll();
                        txt1.Focus();
                    }

                    var textBox = senderFocus as KryptonTextBox;
                    if (textBox != null)
                    {
                        var txt1 = textBox;
                        txt1.Select();
                        txt1.SelectAll();
                        txt1.Focus();
                    }

                    var down = senderFocus as NumericUpDown;
                    if (down != null)
                    {
                        var num = down;
                        num.Select();
                        num.Focus();
                    }

                    var upDown = senderFocus as KryptonNumericUpDown;
                    if (upDown != null)
                    {
                        var num = upDown;
                        num.Select();
                        num.Focus();
                    }
                }

                //if (sender is MultiColumnComboBox)
                //{
                //    MultiColumnComboBox mulcobo = sender as MultiColumnComboBox;
                //    mulcobo.Focus();
                //}
                var comboBox = sender as ComboBox;
                if (comboBox != null)
                {
                    var cobo = comboBox;
                    cobo.Select();
                    cobo.Focus();
                }

                var kryptonComboBox = sender as KryptonComboBox;
                if (kryptonComboBox != null)
                {
                    var cobo = kryptonComboBox;
                    cobo.Select();
                    cobo.Focus();
                }

                var picker = sender as DateTimePicker;
                if (picker != null)
                {
                    var date = picker;
                    date.Select();
                    date.Focus();
                }

                //var view = sender as TreeListView;
                //if (view != null)
                //{
                //    var treeview = view;
                //    treeview.Select();
                //    treeview.Focus();
                //}

                var gridView = sender as KryptonDataGridView;
                if (gridView != null)
                {
                    var dgv = gridView;
                    dgv.Select();
                    dgv.Focus();
                }
            }
        }

        public static void setPropertiesMetroGrid(MetroFramework.Controls.MetroGrid grid)
        {
            grid.AutoGenerateColumns = false;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            grid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
        }

        public static class GridDecorator
        {
            public static MetroGrid gridView { get; set; }
            public static List<string> MergedRowsInFirstColumn = new List<string>();
            private static bool isSelectedCell(int[] Rows, int ColumnIndex)
            {
                if (gridView.SelectedCells.Count > 0)
                {
                    for (int iCell = Rows[0]; iCell <= Rows[1]; iCell++)
                    {
                        for (int iSelCell = 0; iSelCell < gridView.SelectedCells.Count; iSelCell++)
                        {
                            if (gridView.Rows[iCell].Cells[ColumnIndex] == gridView.SelectedCells[iSelCell])
                            {
                                return true;
                            }
                        }
                    }
                    return false;
                }
                else
                {
                    return false;
                }
            }

            public static void Merge()
            {
                int[] RowsToMerge = new int[2];
                RowsToMerge[0] = -1;
                int ColumnsIndex = 0;
                //Merge first column at first
                for (int i = 0; i < gridView.Rows.Count - 1; i++)
                {
                    if(gridView.Rows[i].Cells["colMaHD"].Value.ToString() == gridView.Rows[i+1].Cells["colMaHD"].Value.ToString())
                    {
                        if (RowsToMerge[0] == -1)
                        {
                            RowsToMerge[0] = i;
                            RowsToMerge[1] = i + 1;
                        }
                        else
                        {
                            RowsToMerge[1] = i + 1;
                        }
                    }
                    else
                    {
                        MergeCells(RowsToMerge[0], RowsToMerge[1], gridView.Columns[ColumnsIndex].Index, isSelectedCell(RowsToMerge, gridView.Columns[ColumnsIndex].Index) ? true : false);
                        CollectMergedRowsInFirstColumn(RowsToMerge[0], RowsToMerge[1]);
                        RowsToMerge[0] = -1;
                    }
                    if (i == gridView.Rows.Count - 2)
                    {
                        MergeCells(RowsToMerge[0], RowsToMerge[1], gridView.Columns[ColumnsIndex].Index, isSelectedCell(RowsToMerge, gridView.Columns[ColumnsIndex].Index) ? true : false);
                        CollectMergedRowsInFirstColumn(RowsToMerge[0], RowsToMerge[1]);
                        RowsToMerge[0] = -1;
                    }
                }
                if (RowsToMerge[0] != -1)
                {
                    MergeCells(RowsToMerge[0], RowsToMerge[1], gridView.Columns[ColumnsIndex].Index, isSelectedCell(RowsToMerge, gridView.Columns[ColumnsIndex].Index) ? true : false);
                    RowsToMerge[0] = -1;
                }
                //merge all other columns
                for (int iColumn = 1; iColumn < gridView.Columns.Count - 1; iColumn++)
                {
                    for (int iRow = 0; iRow < gridView.Rows.Count - 1; iRow++)
                    {
                        if ((gridView.Rows[iRow].Cells[iColumn] == gridView.Rows[iRow + 1].Cells[iColumn]) && (isRowsHaveOneCellInFirstColumn(iRow, iRow + 1)))
                        {
                            if (RowsToMerge[0] == -1)
                            {
                                RowsToMerge[0] = iRow;
                                RowsToMerge[1] = iRow + 1;
                            }
                            else
                            {
                                RowsToMerge[1] = iRow + 1;
                            }
                        }
                        else
                        {
                            if (RowsToMerge[0] != -1)
                            {
                                MergeCells(RowsToMerge[0], RowsToMerge[1], iColumn, isSelectedCell(RowsToMerge, iColumn) ? true : false);
                                RowsToMerge[0] = -1;
                            }
                        }
                    }
                    if (RowsToMerge[0] != -1)
                    {
                        MergeCells(RowsToMerge[0], RowsToMerge[1], iColumn, isSelectedCell(RowsToMerge, iColumn) ? true : false);
                        RowsToMerge[0] = -1;
                    }
                }


                #region Unused
                //for (int i = 0; i < gridView.Rows.Count - 1; i++)
                //{
                //if (dataSet.Tables["tbl_main"].Rows[i]["Manufacture"] == dataSet.Tables["tbl_main"].Rows[i + 1]["Manufacture"])
                //{
                //    if (RowsToMerge[0] == -1)
                //    {
                //        RowsToMerge[0] = i;
                //        RowsToMerge[1] = i + 1;
                //    }
                //    else
                //    {
                //        RowsToMerge[1] = i + 1;
                //    }
                //}
                //    else
                //    {
                //        MergeCells(RowsToMerge[0], RowsToMerge[1], dataGrid.Columns["Manufacture"].Index, isSelectedCell(RowsToMerge, dataGrid.Columns["Manufacture"].Index) ? true : false);
                //        CollectMergedRowsInFirstColumn(RowsToMerge[0], RowsToMerge[1]);
                //        RowsToMerge[0] = -1;
                //    }
                //    if (i == dataSet.Tables["tbl_main"].Rows.Count - 2)
                //    {
                //        MergeCells(RowsToMerge[0], RowsToMerge[1], dataGrid.Columns["Manufacture"].Index, isSelectedCell(RowsToMerge, dataGrid.Columns["Manufacture"].Index) ? true : false);
                //        CollectMergedRowsInFirstColumn(RowsToMerge[0], RowsToMerge[1]);
                //        RowsToMerge[0] = -1;
                //    }
                //}
                #endregion
                

            }

            private static bool isRowsHaveOneCellInFirstColumn(int RowId1, int RowId2)
            {

                foreach (string rowsCollection in MergedRowsInFirstColumn)
                {
                    string[] RowsNumber = rowsCollection.Split(';');

                    if ((isStringInArray(RowsNumber, RowId1.ToString())) &&
                        (isStringInArray(RowsNumber, RowId2.ToString())))
                    {
                        return true;
                    }
                }
                return false;
            }

            private static bool isStringInArray(string[] Array, string value)
            {
                foreach (string item in Array)
                {
                    if (item == value)
                    {
                        return true;
                    }

                }
                return false;
            }

            private static void CollectMergedRowsInFirstColumn(int RowId1, int RowId2)
            {
                string MergedRows = String.Empty;

                for (int i = RowId1; i <= RowId2; i++)
                {
                    MergedRows += i.ToString() + ";";
                }
                MergedRowsInFirstColumn.Add(MergedRows.Remove(MergedRows.Length - 1, 1));
            }

            private static void MergeCells(int RowId1, int RowId2, int Column, bool isSelected)
            {
                Graphics g = gridView.CreateGraphics();
                Pen gridPen = new Pen(gridView.GridColor);

                //Cells Rectangles
                Rectangle CellRectangle1 = gridView.GetCellDisplayRectangle(Column, RowId1, true);
                Rectangle CellRectangle2 = gridView.GetCellDisplayRectangle(Column, RowId2, true);

                int rectHeight = 0;
                string MergedRows = String.Empty;

                for (int i = RowId1; i <= RowId2; i++)
                {
                    rectHeight += gridView.GetCellDisplayRectangle(Column, i, false).Height;
                }

                Rectangle newCell = new Rectangle(CellRectangle1.X, CellRectangle1.Y, CellRectangle1.Width, rectHeight);

                g.FillRectangle(new SolidBrush(isSelected ? gridView.DefaultCellStyle.SelectionBackColor : gridView.DefaultCellStyle.BackColor), newCell);

                g.DrawRectangle(gridPen, newCell);

                g.DrawString(gridView.Rows[RowId1].Cells[Column].Value.ToString(), gridView.DefaultCellStyle.Font, new SolidBrush(isSelected ? gridView.DefaultCellStyle.SelectionForeColor : gridView.DefaultCellStyle.ForeColor), newCell.X + newCell.Width / 3, newCell.Y + newCell.Height / 3);
            }
        }
    }
}