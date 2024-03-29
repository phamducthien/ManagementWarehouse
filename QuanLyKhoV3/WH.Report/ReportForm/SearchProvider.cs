using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using HLVControl.Grid;

namespace WH.Report.ReportForm
{
    public static class SearchProvider
    {
        public static TreeListView SmartSearch(TreeListView grid, string TenCotTimKiem, string compare)
        {
            try
            {
                for (var i = 0; i < grid.Rows.Count; i++)
                {
                    var SCompareLower_UnsignedChar =
                        converToUnsign1(grid.Rows[i].Cells[TenCotTimKiem].Value.ToString().ToLower());
                    var sCompareNormal_UnsignedChar =
                        converToUnsign1(grid.Rows[i].Cells[TenCotTimKiem].Value.ToString());
                    var sCompareUpper_UnsignedChar =
                        converToUnsign1(grid.Rows[i].Cells[TenCotTimKiem].Value.ToString().ToUpper());
                    var sCompareLower_SignedChar = grid.Rows[i].Cells[TenCotTimKiem].Value.ToString().ToLower();
                    var sCompareNormal_SignedChar = grid.Rows[i].Cells[TenCotTimKiem].Value.ToString();
                    var sCompareUpper_SignedChar = grid.Rows[i].Cells[TenCotTimKiem].Value.ToString().ToUpper();

                    var SCompareLower_UnsignedChar_ = XoaKhoangTrang(SCompareLower_UnsignedChar);
                    var sCompareNormal_UnsignedChar_ = XoaKhoangTrang(sCompareNormal_UnsignedChar);
                    var sCompareUpper_UnsignedChar_ = XoaKhoangTrang(sCompareUpper_UnsignedChar);
                    var sCompareLower_SignedChar_ = XoaKhoangTrang(sCompareLower_SignedChar);
                    var sCompareNormal_SignedChar_ = XoaKhoangTrang(sCompareNormal_SignedChar);
                    var sCompareUpper_SignedChar_ = XoaKhoangTrang(sCompareUpper_SignedChar);

                    if (SCompareLower_UnsignedChar.Contains(compare) || sCompareNormal_UnsignedChar.Contains(compare) ||
                        sCompareUpper_UnsignedChar.Contains(compare) || sCompareLower_SignedChar.Contains(compare) ||
                        sCompareNormal_SignedChar.Contains(compare) || sCompareUpper_SignedChar.Contains(compare)
                        || SCompareLower_UnsignedChar_.Contains(compare) ||
                        sCompareNormal_UnsignedChar_.Contains(compare) ||
                        sCompareUpper_UnsignedChar_.Contains(compare) || sCompareLower_SignedChar_.Contains(compare) ||
                        sCompareNormal_SignedChar_.Contains(compare) || sCompareUpper_SignedChar_.Contains(compare))
                        grid.Rows[i].Visible = true;
                    else
                        grid.Rows[i].Visible = false;
                }

                grid.Refresh();
                return grid;
            }
            catch
            {
                return grid;
            }
        }

        public static TreeListView SmartSearch(TreeListView grid, string compare, List<string> ColumnNoSearch)
        {
            try
            {
                for (var i = 0; i < grid.Rows.Count; i++)
                    if (compare != "")
                    {
                        var TimKiem = string.Empty;
                        for (var j = 0; j < grid.Rows[i].Cells.Count; j++)
                            if (!ColumnNoSearch.Contains(j.ToString()))
                            {
                                var Data = grid.Rows[i].Cells[j].Value.ToString();
                                TimKiem = string.Concat(TimKiem, " ", Data);
                            }

                        var SCompareLower_UnsignedChar = converToUnsign1(TimKiem.ToLower());
                        var sCompareNormal_UnsignedChar = converToUnsign1(TimKiem);
                        var sCompareUpper_UnsignedChar = converToUnsign1(TimKiem.ToUpper());
                        var sCompareLower_SignedChar = TimKiem.ToLower();
                        var sCompareNormal_SignedChar = TimKiem;
                        var sCompareUpper_SignedChar = TimKiem.ToUpper();

                        var SCompareLower_UnsignedChar_ = XoaKhoangTrang(SCompareLower_UnsignedChar);
                        var sCompareNormal_UnsignedChar_ = XoaKhoangTrang(sCompareNormal_UnsignedChar);
                        var sCompareUpper_UnsignedChar_ = XoaKhoangTrang(sCompareUpper_UnsignedChar);
                        var sCompareLower_SignedChar_ = XoaKhoangTrang(sCompareLower_SignedChar);
                        var sCompareNormal_SignedChar_ = XoaKhoangTrang(sCompareNormal_SignedChar);
                        var sCompareUpper_SignedChar_ = XoaKhoangTrang(sCompareUpper_SignedChar);

                        if (SCompareLower_UnsignedChar.Contains(compare) ||
                            sCompareNormal_UnsignedChar.Contains(compare) ||
                            sCompareUpper_UnsignedChar.Contains(compare) ||
                            sCompareLower_SignedChar.Contains(compare) || sCompareNormal_SignedChar.Contains(compare) ||
                            sCompareUpper_SignedChar.Contains(compare)
                            || SCompareLower_UnsignedChar_.Contains(compare) ||
                            sCompareNormal_UnsignedChar_.Contains(compare) ||
                            sCompareUpper_UnsignedChar_.Contains(compare) ||
                            sCompareLower_SignedChar_.Contains(compare) ||
                            sCompareNormal_SignedChar_.Contains(compare) || sCompareUpper_SignedChar_.Contains(compare))
                            grid.Rows[i].Visible = true;
                        else
                            grid.Rows[i].Visible = false;
                    }
                    else
                    {
                        grid.Rows[i].Visible = true;
                    }

                grid.Refresh();
                return grid;
            }
            catch
            {
                return grid;
            }
        }

        public static TreeListView SmartSearch(TreeListView grid, string compare)
        {
            try
            {
                for (var i = 0; i < grid.Rows.Count; i++)
                    if (compare != "")
                    {
                        var TimKiem = string.Empty;
                        for (var j = 0; j < grid.Rows[i].Cells.Count; j++)
                        {
                            var Data = grid.Rows[i].Cells[j].Value.ToString();
                            TimKiem = string.Concat(TimKiem, " ", Data);
                        }

                        var SCompareLower_UnsignedChar = converToUnsign1(TimKiem.ToLower());
                        var sCompareNormal_UnsignedChar = converToUnsign1(TimKiem);
                        var sCompareUpper_UnsignedChar = converToUnsign1(TimKiem.ToUpper());
                        var sCompareLower_SignedChar = TimKiem.ToLower();
                        var sCompareNormal_SignedChar = TimKiem;
                        var sCompareUpper_SignedChar = TimKiem.ToUpper();

                        var SCompareLower_UnsignedChar_ = XoaKhoangTrang(SCompareLower_UnsignedChar);
                        var sCompareNormal_UnsignedChar_ = XoaKhoangTrang(sCompareNormal_UnsignedChar);
                        var sCompareUpper_UnsignedChar_ = XoaKhoangTrang(sCompareUpper_UnsignedChar);
                        var sCompareLower_SignedChar_ = XoaKhoangTrang(sCompareLower_SignedChar);
                        var sCompareNormal_SignedChar_ = XoaKhoangTrang(sCompareNormal_SignedChar);
                        var sCompareUpper_SignedChar_ = XoaKhoangTrang(sCompareUpper_SignedChar);

                        if (SCompareLower_UnsignedChar.Contains(compare) ||
                            sCompareNormal_UnsignedChar.Contains(compare) ||
                            sCompareUpper_UnsignedChar.Contains(compare) ||
                            sCompareLower_SignedChar.Contains(compare) || sCompareNormal_SignedChar.Contains(compare) ||
                            sCompareUpper_SignedChar.Contains(compare)
                            || SCompareLower_UnsignedChar_.Contains(compare) ||
                            sCompareNormal_UnsignedChar_.Contains(compare) ||
                            sCompareUpper_UnsignedChar_.Contains(compare) ||
                            sCompareLower_SignedChar_.Contains(compare) ||
                            sCompareNormal_SignedChar_.Contains(compare) || sCompareUpper_SignedChar_.Contains(compare))
                            grid.Rows[i].Visible = true;
                        else
                            grid.Rows[i].Visible = false;
                    }
                    else
                    {
                        grid.Rows[i].Visible = true;
                    }

                grid.Refresh();
                return grid;
            }
            catch
            {
                return grid;
            }
        }

        public static KryptonDataGridView SmartSearch(KryptonDataGridView grid, string TenCotTimKiem, string compare)
        {
            try
            {
                for (var i = 0; i < grid.Rows.Count; i++)
                {
                    var SCompareLower_UnsignedChar =
                        converToUnsign1(grid.Rows[i].Cells[TenCotTimKiem].Value.ToString().ToLower());
                    var sCompareNormal_UnsignedChar =
                        converToUnsign1(grid.Rows[i].Cells[TenCotTimKiem].Value.ToString());
                    var sCompareUpper_UnsignedChar =
                        converToUnsign1(grid.Rows[i].Cells[TenCotTimKiem].Value.ToString().ToUpper());
                    var sCompareLower_SignedChar = grid.Rows[i].Cells[TenCotTimKiem].Value.ToString().ToLower();
                    var sCompareNormal_SignedChar = grid.Rows[i].Cells[TenCotTimKiem].Value.ToString();
                    var sCompareUpper_SignedChar = grid.Rows[i].Cells[TenCotTimKiem].Value.ToString().ToUpper();

                    var SCompareLower_UnsignedChar_ = XoaKhoangTrang(SCompareLower_UnsignedChar);
                    var sCompareNormal_UnsignedChar_ = XoaKhoangTrang(sCompareNormal_UnsignedChar);
                    var sCompareUpper_UnsignedChar_ = XoaKhoangTrang(sCompareUpper_UnsignedChar);
                    var sCompareLower_SignedChar_ = XoaKhoangTrang(sCompareLower_SignedChar);
                    var sCompareNormal_SignedChar_ = XoaKhoangTrang(sCompareNormal_SignedChar);
                    var sCompareUpper_SignedChar_ = XoaKhoangTrang(sCompareUpper_SignedChar);

                    if (SCompareLower_UnsignedChar.Contains(compare) || sCompareNormal_UnsignedChar.Contains(compare) ||
                        sCompareUpper_UnsignedChar.Contains(compare) || sCompareLower_SignedChar.Contains(compare) ||
                        sCompareNormal_SignedChar.Contains(compare) || sCompareUpper_SignedChar.Contains(compare)
                        || SCompareLower_UnsignedChar_.Contains(compare) ||
                        sCompareNormal_UnsignedChar_.Contains(compare) ||
                        sCompareUpper_UnsignedChar_.Contains(compare) || sCompareLower_SignedChar_.Contains(compare) ||
                        sCompareNormal_SignedChar_.Contains(compare) || sCompareUpper_SignedChar_.Contains(compare))
                        grid.Rows[i].Visible = true;
                    else
                        grid.Rows[i].Visible = false;
                }

                grid.Refresh();
                return grid;
            }
            catch
            {
                return grid;
            }
        }

        public static KryptonDataGridView SmartSearch(KryptonDataGridView grid, string compare)
        {
            try
            {
                var currencyManager1 = (CurrencyManager) grid.BindingContext[grid.DataSource];
                currencyManager1.SuspendBinding();
                for (var i = 0; i < grid.RowCount; i++)
                    if (compare != "")
                    {
                        var TimKiem = string.Empty;
                        for (var j = 0; j < grid.Rows[i].Cells.Count; j++)
                            if (grid.Rows[i].Cells[j].Visible)
                            {
                                var Data = converToUnsign1(grid.Rows[i].Cells[j].Value.ToString());
                                TimKiem = string.Concat(TimKiem, " ", Data);
                            }

                        var SCompareLower_UnsignedChar = converToUnsign1(TimKiem.ToLower());
                        var sCompareNormal_UnsignedChar = converToUnsign1(TimKiem);
                        var sCompareUpper_UnsignedChar = converToUnsign1(TimKiem.ToUpper());
                        var sCompareLower_SignedChar = TimKiem.ToLower();
                        var sCompareNormal_SignedChar = TimKiem;
                        var sCompareUpper_SignedChar = TimKiem.ToUpper();

                        var SCompareLower_UnsignedChar_ = XoaKhoangTrang(SCompareLower_UnsignedChar);
                        var sCompareNormal_UnsignedChar_ = XoaKhoangTrang(sCompareNormal_UnsignedChar);
                        var sCompareUpper_UnsignedChar_ = XoaKhoangTrang(sCompareUpper_UnsignedChar);
                        var sCompareLower_SignedChar_ = XoaKhoangTrang(sCompareLower_SignedChar);
                        var sCompareNormal_SignedChar_ = XoaKhoangTrang(sCompareNormal_SignedChar);
                        var sCompareUpper_SignedChar_ = XoaKhoangTrang(sCompareUpper_SignedChar);

                        if (SCompareLower_UnsignedChar.Contains(compare) ||
                            sCompareNormal_UnsignedChar.Contains(compare) ||
                            sCompareUpper_UnsignedChar.Contains(compare) ||
                            sCompareLower_SignedChar.Contains(compare) || sCompareNormal_SignedChar.Contains(compare) ||
                            sCompareUpper_SignedChar.Contains(compare)
                            || SCompareLower_UnsignedChar_.Contains(compare) ||
                            sCompareNormal_UnsignedChar_.Contains(compare) ||
                            sCompareUpper_UnsignedChar_.Contains(compare) ||
                            sCompareLower_SignedChar_.Contains(compare) ||
                            sCompareNormal_SignedChar_.Contains(compare) || sCompareUpper_SignedChar_.Contains(compare))
                            grid.Rows[i].Visible = true;
                        else
                            grid.Rows[i].Visible = false;
                    }
                    else
                    {
                        grid.Rows[i].Visible = true;
                    }

                grid.Refresh();
                currencyManager1.ResumeBinding();
                return grid;
            }
            catch (Exception ex)
            {
                return grid;
            }
        }

        public static DataGridView SmartSearch(DataGridView grid, string TenCotTimKiem, string compare)
        {
            try
            {
                for (var i = 0; i < grid.Rows.Count; i++)
                {
                    var SCompareLower_UnsignedChar =
                        converToUnsign1(grid.Rows[i].Cells[TenCotTimKiem].Value.ToString().ToLower());
                    var sCompareNormal_UnsignedChar =
                        converToUnsign1(grid.Rows[i].Cells[TenCotTimKiem].Value.ToString());
                    var sCompareUpper_UnsignedChar =
                        converToUnsign1(grid.Rows[i].Cells[TenCotTimKiem].Value.ToString().ToUpper());
                    var sCompareLower_SignedChar = grid.Rows[i].Cells[TenCotTimKiem].Value.ToString().ToLower();
                    var sCompareNormal_SignedChar = grid.Rows[i].Cells[TenCotTimKiem].Value.ToString();
                    var sCompareUpper_SignedChar = grid.Rows[i].Cells[TenCotTimKiem].Value.ToString().ToUpper();

                    var SCompareLower_UnsignedChar_ = XoaKhoangTrang(SCompareLower_UnsignedChar);
                    var sCompareNormal_UnsignedChar_ = XoaKhoangTrang(sCompareNormal_UnsignedChar);
                    var sCompareUpper_UnsignedChar_ = XoaKhoangTrang(sCompareUpper_UnsignedChar);
                    var sCompareLower_SignedChar_ = XoaKhoangTrang(sCompareLower_SignedChar);
                    var sCompareNormal_SignedChar_ = XoaKhoangTrang(sCompareNormal_SignedChar);
                    var sCompareUpper_SignedChar_ = XoaKhoangTrang(sCompareUpper_SignedChar);

                    if (SCompareLower_UnsignedChar.Contains(compare) || sCompareNormal_UnsignedChar.Contains(compare) ||
                        sCompareUpper_UnsignedChar.Contains(compare) || sCompareLower_SignedChar.Contains(compare) ||
                        sCompareNormal_SignedChar.Contains(compare) || sCompareUpper_SignedChar.Contains(compare)
                        || SCompareLower_UnsignedChar_.Contains(compare) ||
                        sCompareNormal_UnsignedChar_.Contains(compare) ||
                        sCompareUpper_UnsignedChar_.Contains(compare) || sCompareLower_SignedChar_.Contains(compare) ||
                        sCompareNormal_SignedChar_.Contains(compare) || sCompareUpper_SignedChar_.Contains(compare))
                        grid.Rows[i].Visible = true;
                    else
                        grid.Rows[i].Visible = false;
                }

                grid.Refresh();
                return grid;
            }
            catch
            {
                return grid;
            }
        }

        public static DataGridView SmartSearch(DataGridView grid, string compare)
        {
            try
            {
                for (var i = 0; i < grid.Rows.Count; i++)
                    if (compare != "")
                    {
                        var TimKiem = string.Empty;
                        for (var j = 0; j < grid.Rows[i].Cells.Count; j++)
                        {
                            var Data = grid.Rows[i].Cells[j].Value.ToString();
                            TimKiem = string.Concat(TimKiem, " ", Data);
                        }

                        var SCompareLower_UnsignedChar = converToUnsign1(TimKiem.ToLower());
                        var sCompareNormal_UnsignedChar = converToUnsign1(TimKiem);
                        var sCompareUpper_UnsignedChar = converToUnsign1(TimKiem.ToUpper());
                        var sCompareLower_SignedChar = TimKiem.ToLower();
                        var sCompareNormal_SignedChar = TimKiem;
                        var sCompareUpper_SignedChar = TimKiem.ToUpper();

                        var SCompareLower_UnsignedChar_ = XoaKhoangTrang(SCompareLower_UnsignedChar);
                        var sCompareNormal_UnsignedChar_ = XoaKhoangTrang(sCompareNormal_UnsignedChar);
                        var sCompareUpper_UnsignedChar_ = XoaKhoangTrang(sCompareUpper_UnsignedChar);
                        var sCompareLower_SignedChar_ = XoaKhoangTrang(sCompareLower_SignedChar);
                        var sCompareNormal_SignedChar_ = XoaKhoangTrang(sCompareNormal_SignedChar);
                        var sCompareUpper_SignedChar_ = XoaKhoangTrang(sCompareUpper_SignedChar);

                        if (SCompareLower_UnsignedChar.Contains(compare) ||
                            sCompareNormal_UnsignedChar.Contains(compare) ||
                            sCompareUpper_UnsignedChar.Contains(compare) ||
                            sCompareLower_SignedChar.Contains(compare) || sCompareNormal_SignedChar.Contains(compare) ||
                            sCompareUpper_SignedChar.Contains(compare)
                            || SCompareLower_UnsignedChar_.Contains(compare) ||
                            sCompareNormal_UnsignedChar_.Contains(compare) ||
                            sCompareUpper_UnsignedChar_.Contains(compare) ||
                            sCompareLower_SignedChar_.Contains(compare) ||
                            sCompareNormal_SignedChar_.Contains(compare) || sCompareUpper_SignedChar_.Contains(compare))
                            grid.Rows[i].Visible = true;
                        else
                            grid.Rows[i].Visible = false;
                    }
                    else
                    {
                        grid.Rows[i].Visible = true;
                    }

                grid.Refresh();
                return grid;
            }
            catch
            {
                return grid;
            }
        }

        public static string converToUnsign1(string s)
        {
            var regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            var temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, string.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        public static string XoaKhoangTrang(string s)
        {
            var result = "";
            for (var i = 0; i < s.Length; i++)
                if (s[i] != 32)
                    result += s[i].ToString().Trim();
            return result;
        }
    }
}