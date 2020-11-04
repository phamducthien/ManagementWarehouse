using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using ExcelLibrary;
using Service.Pattern;
using Util.Pattern;
using WH.Entity;
using WH.Model;
using WH.Service.Service;

namespace WH.Base.UI
{
    public class ExcelService : BaseForm
    {
        public bool ExportExcelMatHang(KryptonDataGridView dgvData, string pathSave)
        {
            if (dgvData == null || dgvData.Rows.Count == 0)
            {
                VietNamMsg = "Không có dữ liệu để xuất!";
                EnglishMsg = "Data may be empty!!";
                ErrMsg = IsVietNamLanguage ? VietNamMsg : EnglishMsg;
                return false;
            }
            var indexRow = 3;
            try
            {
                var pathExcelTemplate = Path.Combine(StaticGlobalVariables.PathExcelTemp, "DSMatHangTemplate.xlsx");
                var pathExcelExportTemp = Path.Combine(StaticGlobalVariables.PathTempFolder, "DSMatHang.xlsx");
                File.Copy(pathExcelTemplate, pathExcelExportTemp, true);

                var sl = new SLDocument(pathExcelExportTemp, "DSMatHang")
                {
                    DocumentProperties =
                    {
                        Title = "DsMatHang",
                        Subject = "Xuất Excel Danh Sách Mặt Hàng",
                        Category = "Danh Mục",
                        Creator = "Cong Ty Phat Trien Thuong Mai Dich Vu.",
                        ContentStatus = "Mặt Hàng",
                        Description = "Danh Sách Các Mặt Hàng."
                    }
                };
                //Rename Sheet
                //sl.RenameWorksheet(SLDocument.DefaultFirstSheetName, "DSMatHang");

                foreach (var row in dgvData.Rows.Cast<DataGridViewRow>().Where(row => row.Index <= dgvData.Rows.Count))
                {
                    sl.SetCellValue("A" + indexRow, indexRow - 2);
                    sl.SetCellValue("B" + indexRow, row.Cells[1].Value?.ToString() ?? "");
                    sl.SetCellValue("C" + indexRow, row.Cells[5].Value?.ToString() ?? "");
                    sl.SetCellValue("D" + indexRow, row.Cells[3].Value?.ToString() ?? "");
                    sl.SetCellValue("E" + indexRow, row.Cells[4].Value?.ToString() ?? "");
                    sl.SetCellValue("F" + indexRow, row.Cells[6].Value?.ToString() ?? "");
                    sl.SetCellValue("G" + indexRow, row.Cells[7].Value?.ToString() ?? "");
                    sl.SetCellValue("H" + indexRow, row.Cells[8].Value?.ToString() ?? "");
                    sl.SetCellValue("I" + indexRow, row.Cells[9].Value?.ToString() ?? "");
                    sl.SetCellValue("J" + indexRow, row.Cells[10].Value?.ToString() ?? "");
                    sl.SetCellValue("K" + indexRow, row.Cells[11].Value?.ToString() ?? "");
                    sl.SetCellValue("L" + indexRow, row.Cells[12].Value?.ToString() ?? "");
                    sl.SetCellValue("M" + indexRow, row.Cells[2].Value?.ToString() ?? "");
                    sl.SetCellValue("N" + indexRow, row.Cells[13].Value?.ToString() ?? "");
                    sl.SetCellValue("O" + indexRow, row.Cells[14].Value?.ToString() ?? "");
                    sl.SetCellValue("P" + indexRow, row.Cells[15].Value?.ToString() ?? "");
                    indexRow++;
                }
                sl.Save();
                File.Copy(pathExcelExportTemp, pathSave, true);
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message + "_" + indexRow;
                return false;
            }
            return true;
        }
        public bool ExportExcelMatHangMau(string pathSave)
        {
            try
            {
                var pathExcelTemplate = Path.Combine(StaticGlobalVariables.PathExcelTemp, "DSMatHangTemplate.xlsx");
                var pathExcelExportTemp = Path.Combine(StaticGlobalVariables.PathTempFolder, "DSMatHang.xlsx");
                File.Copy(pathExcelTemplate, pathExcelExportTemp, true);
                var sl = new SLDocument(pathExcelExportTemp, "DSMatHang")
                {
                    DocumentProperties =
                    {
                        Title = "DsMatHang",
                        Subject = "Xuất Excel Danh Sách Mặt Hàng",
                        Category = "Danh Mục",
                        Creator = "Cong Ty Phat Trien Thuong Mai Dich Vu.",
                        ContentStatus = "Mặt Hàng",
                        Description = "Danh Sách Các Mặt Hàng."
                    }
                };
                sl.Save();
                File.Copy(pathExcelExportTemp, pathSave, true);
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
                return false;
            }
            return true;
        }

        public bool ExportExcelDoiTac(KryptonDataGridView dgvData, string pathSave)
        {
            if (dgvData == null || dgvData.Rows.Count == 0)
            {
                VietNamMsg = "Không có dữ liệu để xuất!";
                EnglishMsg = "Data may be empty!!";
                ErrMsg = IsVietNamLanguage ? VietNamMsg : EnglishMsg;
                //ShowMessage(IconMessageBox.Information);
                return false;
            }
            var indexRow = 3;
            try
            {
                var pathExcelTemplate = Path.Combine(StaticGlobalVariables.PathExcelTemp, "DSDoiTacTemplate.xlsx");
                var pathExcelExportTemp = Path.Combine(StaticGlobalVariables.PathTempFolder, "DSDoiTac.xlsx");
                File.Copy(pathExcelTemplate, pathExcelExportTemp, true);

                var sl = new SLDocument(pathExcelExportTemp, "DSDoiTac")
                {
                    DocumentProperties =
                    {
                        Title = "DSDoiTac",
                        Subject = "Xuất Excel Danh Sách Đối Tác",
                        Category = "Danh Mục",
                        Creator = "Cong Ty Phat Trien Thuong Mai Dich Vu.",
                        ContentStatus = " Đối Tác",
                        Description = "Danh Sách Các Đối Tác."
                    }
                };
                //Rename Sheet
                // sl.RenameWorksheet(SLDocument.DefaultFirstSheetName, "DSDoiTac");

                foreach (var row in dgvData.Rows.Cast<DataGridViewRow>().Where(row => row.Index <= dgvData.Rows.Count))
                {
                    sl.SetCellValue("A" + indexRow, indexRow - 2);
                    sl.SetCellValue("B" + indexRow, row.Cells[1].Value?.ToString() ?? "");
                    sl.SetCellValue("C" + indexRow, row.Cells[5].Value?.ToString() ?? "");
                    sl.SetCellValue("D" + indexRow, row.Cells[3].Value?.ToString() ?? "");
                    sl.SetCellValue("E" + indexRow, row.Cells[4].Value?.ToString() ?? "");
                    sl.SetCellValue("F" + indexRow, row.Cells[6].Value?.ToString() ?? "");
                    sl.SetCellValue("G" + indexRow, row.Cells[7].Value?.ToString() ?? "");
                    sl.SetCellValue("H" + indexRow, row.Cells[8].Value?.ToString() ?? "");
                    sl.SetCellValue("I" + indexRow, row.Cells[9].Value?.ToString() ?? "");
                    sl.SetCellValue("J" + indexRow, row.Cells[2].Value?.ToString() ?? "");
                    sl.SetCellValue("K" + indexRow, row.Cells[10].Value?.ToString() ?? "");
                    sl.SetCellValue("L" + indexRow, row.Cells[11].Value?.ToString() ?? "");
                    sl.SetCellValue("M" + indexRow, row.Cells[12].Value?.ToString() ?? "");
                    indexRow++;
                }
                sl.Save();
                File.Copy(pathExcelExportTemp, pathSave, true);
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message + "_" + indexRow;
                return false;
            }
            return true;
        }

        public bool ExportExcelDoiTacMau(string pathSave)
        {
            try
            {
                var pathExcelTemplate = Path.Combine(StaticGlobalVariables.PathExcelTemp, "DSDoiTacTemplate.xlsx");
                var pathExcelExportTemp = Path.Combine(StaticGlobalVariables.PathTempFolder, "DSDoiTac.xlsx");
                File.Copy(pathExcelTemplate, pathExcelExportTemp, true);

                var sl = new SLDocument(pathExcelExportTemp, "DSDoiTac")
                {
                    DocumentProperties =
                    {
                        Title = "DSDoiTac",
                        Subject = "Xuất Excel Danh Sách Đối Tác",
                        Category = "Danh Mục",
                        Creator = "Cong Ty Phat Trien Thuong Mai Dich Vu.",
                        ContentStatus = " Đối Tác",
                        Description = "Danh Sách Các Đối Tác."
                    }
                };
                sl.Save();
                File.Copy(pathExcelExportTemp, pathSave, true);
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
                return false;
            }
            return true;
        }

        public bool ImportExcelMatHang(string pathOpen)
        {
            SLDocument sl;
            try
            {
                var fs = new FileStream(pathOpen, FileMode.Open, FileAccess.Read);
                sl = new SLDocument(fs, "DSMatHang");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            if (sl.DocumentProperties.Title != "DSMatHang")
            {
                ErrMsg = "Vui lòng chọn đúng file excel mặt hàng !!!";
                return false;
            }

            ReloadUnitOfWork();
            IMATHANGService service = new MATHANGService(UnitOfWorkAsync);
            var listAll = service.FindAll();
            var listInsert = new List<MATHANG>();
            var listUpdate = new List<MATHANG>();
            var stats = sl.GetWorksheetStatistics();
            var countInsert = 0;
            var countUpdate = 0;
            var countInsertFailed = 0;
            var countUpdateFailed = 0;
            string idUnit;

            for (var i = 3; i <= stats.EndRowIndex; i++)
            {
                var countchanges = 0;
                var isAdd = false;
                var stt = sl.GetCellValueAsString(i, 1);
                idUnit = sl.GetCellValueAsString(i, 13);

                var objMathang = listAll.FirstOrDefault(s => s.IDUnit == idUnit);
                if (objMathang == null)
                {
                    objMathang = service.CreateNew();
                    isAdd = true;
                }
                objMathang.MAMATHANG = idUnit.ToIntOrDefault();

                var value = sl.GetCellValueAsString(i, 14);
                var change = CheckChange(value, objMathang.MALOAIMATHANG);
                if (change)
                {
                    objMathang.MALOAIMATHANG = value.ToIntOrDefault() == 0 ? 1 : value.ToInt();
                    countchanges++;
                }

                value = sl.GetCellValueAsString(i, 15);
                change = CheckChange(value, objMathang.MADONVISI);
                if (change)
                {
                    objMathang.MADONVISI = value.ToIntOrDefault() == 0 ? 1 : value.ToInt();
                    countchanges++;
                }

                value = sl.GetCellValueAsString(i, 16);
                change = CheckChange(value, objMathang.MADONVILE);
                if (change)
                {
                    objMathang.MADONVILE = value.ToIntOrDefault() == 0 ? 1 : value.ToInt();
                    countchanges++;
                }

                value = sl.GetCellValueAsString(i, 3);
                change = CheckChange(value, objMathang.TENMATHANG);
                if (change)
                {
                    objMathang.TENMATHANG = value;
                    countchanges++;
                }

                value = sl.GetCellValueAsString(i, 4);
                change = CheckChange(value, objMathang.MACODE);
                if (change)
                {
                    objMathang.MACODE = value;
                    countchanges++;
                }

                value = sl.GetCellValueAsString(i, 5);
                change = CheckChange(value, objMathang.MABARCODE);
                if (change)
                {
                    objMathang.MABARCODE = value;
                    countchanges++;
                }

                value = sl.GetCellValueAsString(i, 6);
                change = CheckChange(value, objMathang.GIALE);
                if (change)
                {
                    objMathang.GIALE = value.ToDecimalOrDefault() == 0 ? 1 : value.ToDecimal();
                    countchanges++;
                }

                value = sl.GetCellValueAsString(i, 7);
                change = CheckChange(value, objMathang.GIANHAP);
                if (change)
                {
                    objMathang.GIANHAP = value.ToDecimalOrDefault() == 0 ? 1 : value.ToDecimal();
                    countchanges++;
                }

                value = sl.GetCellValueAsString(i, 8);
                change = CheckChange(value, objMathang.SOLUONGQUYDOI);
                if (change)
                {
                    objMathang.SOLUONGQUYDOI = value.ToDecimalOrDefault() == 0 ? 1 : value.ToInt();
                    countchanges++;
                }

                value = sl.GetCellValueAsString(i, 10);
                change = CheckChange(value, objMathang.NGUONGNHAP);
                if (change)
                {
                    objMathang.NGUONGNHAP = value.ToDecimalOrDefault() == 0 ? 1 : value.ToInt();
                    countchanges++;
                }

                value = sl.GetCellValueAsString(i, 11);
                change = CheckChange(value, objMathang.NGUONGXUAT);
                if (change)
                {
                    objMathang.NGUONGXUAT = value.ToDecimalOrDefault() == 0 ? 1 : value.ToInt();
                    countchanges++;
                }

                if (countchanges == 0) continue;

                ErrMsg = "Các dữ liệu không thể nhập";
                MethodResult result;
                if (isAdd)
                {
                    listInsert.Add(objMathang);
                    result = service.Add(objMathang);
                    if (result != MethodResult.Succeed)
                    {
                        ErrMsg += "Add: " + stt + "-" + objMathang.TENMATHANG + "\n";
                        countInsertFailed++;
                        continue;
                    }
                    countInsert++;
                }
                else
                {
                    listUpdate.Add(objMathang);
                    result = service.Modify(objMathang);
                    if (result != MethodResult.Succeed)
                    {
                        ErrMsg += "Update: " + stt + "-" + objMathang.TENMATHANG + "\n";
                        countUpdateFailed++;
                        continue;
                    }
                    countUpdate++;
                }
            }
            sl.Dispose();
            if (countInsertFailed > 0 || countUpdateFailed > 0)
                return false;

            if (countUpdate == 0 && countInsert == 0)
            {
                ErrMsg = "Không có dữ liệu thay đổi!";
                return false;
            }

            ErrMsg = "Có " + countInsert + " mặt hàng được thêm!\nCó " + countUpdate + " mặt hàng được cập nhật!";
            return true;
        }

         public bool ImportExcelDoiTac(string pathOpen)
        {
            SLDocument sl;
            try
            {
                var fs = new FileStream(pathOpen, FileMode.Open, FileAccess.Read);
                sl = new SLDocument(fs, "DSDoiTac");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            if (sl.DocumentProperties.Title != "DSDoiTac")
            {
                ErrMsg = "Vui lòng chọn đúng file excel đối tác !!!";
                return false;
            }

            ReloadUnitOfWork();
            IKHACHHANGService service = new KHACHHANGService(UnitOfWorkAsync);
            var listAll = service.FindAll();
            var listInsert = new List<KHACHHANG>();
            var listUpdate = new List<KHACHHANG>();
            var stats = sl.GetWorksheetStatistics();
            var countInsert = 0;
            var countUpdate = 0;
            var countInsertFailed = 0;
            var countUpdateFailed = 0;
            string idUnit;

            for (var i = 3; i <= stats.EndRowIndex; i++)
            {
                var countchanges = 0;
                var isAdd = false;
                var stt = sl.GetCellValueAsString(i, 1);
                idUnit = sl.GetCellValueAsString(i, 10);

                var obj= listAll.FirstOrDefault(s => s.IDUnit == idUnit);
                if (obj == null)
                {
                    obj = service.CreateNew();
                    obj.MAKHACHHANG = Guid.NewGuid();
                    isAdd = true;
                }
                obj.MAKHACHHANG = idUnit.ToGuid();

                var value = sl.GetCellValueAsString(i, 11);
                var change = CheckChange(value, obj.MAKHUVUC);
                if (change)
                {
                    obj.MAKHUVUC = value.ToIntOrDefault() == 0 ? 1 : value.ToInt();
                    countchanges++;
                }

                value = sl.GetCellValueAsString(i, 12);
                change = CheckChange(value, obj.MANHOM);
                if (change)
                {
                    obj.MANHOM = value.ToIntOrDefault() == 0 ? 1 : value.ToInt();
                    countchanges++;
                }

                value = sl.GetCellValueAsString(i, 13);
                change = CheckChange(value, obj.MALOAIKHACHHANG);
                if (change)
                {
                    obj.MALOAIKHACHHANG = value.ToIntOrDefault() == 0 ? 1 : value.ToInt();
                    countchanges++;
                }

                value = sl.GetCellValueAsString(i, 3);
                change = CheckChange(value, obj.TENKHACHHANG);
                if (change)
                {
                    obj.TENKHACHHANG = value;
                    countchanges++;
                }

                value = sl.GetCellValueAsString(i, 4);
                change = CheckChange(value, obj.CODEKHACHHANG);
                if (change)
                {
                    obj.CODEKHACHHANG = value;
                    countchanges++;
                }

                value = sl.GetCellValueAsString(i, 5);
                change = CheckChange(value, obj.MABARCODE);
                if (change)
                {
                    obj.MABARCODE = value;
                    countchanges++;
                }

                value = sl.GetCellValueAsString(i, 6);
                change = CheckChange(value, obj.DIACHI);
                if (change)
                {
                    obj.DIACHI = value;
                    countchanges++;
                }

                value = sl.GetCellValueAsString(i, 7);
                change = CheckChange(value, obj.DIENTHOAI);
                if (change)
                {
                    obj.DIENTHOAI = value;
                    countchanges++;
                }

                value = sl.GetCellValueAsString(i, 8);
                change = CheckChange(value, obj.CONGTY);
                if (change)
                {
                    obj.CONGTY = value;
                    countchanges++;
                }

                value = sl.GetCellValueAsString(i, 9);
                change = CheckChange(value, obj.GHICHU);
                if (change)
                {
                    obj.GHICHU = value;
                    countchanges++;
                }
                
                if (countchanges == 0) continue;

                ErrMsg = "Các dữ liệu không thể nhập";
                MethodResult result;
                if (isAdd)
                {
                    listInsert.Add(obj);
                    result = service.Add(obj);
                    if (result != MethodResult.Succeed)
                    {
                        ErrMsg += "Add: " + stt + "-" + obj.TENKHACHHANG + "\n";
                        countInsertFailed++;
                        continue;
                    }
                    countInsert++;
                }
                else
                {
                    listUpdate.Add(obj);
                    result = service.Modify(obj);
                    if (result != MethodResult.Succeed)
                    {
                        ErrMsg += "Update: " + stt + "-" + obj.TENKHACHHANG + "\n";
                        countUpdateFailed++;
                        continue;
                    }
                    countUpdate++;
                }
            }
            sl.Dispose();
            if (countInsertFailed > 0 || countUpdateFailed > 0)
                return false;

            if (countUpdate == 0 && countInsert == 0)
            {
                ErrMsg = "Không có dữ liệu thay đổi!";
                return false;
            }

            ErrMsg = "Có " + countInsert + " đối tác được thêm!\nCó " + countUpdate + "  đối tác được cập nhật!";
            return true;
        }

        private bool CheckChange(object value1, object value2)
        {
            return !value1.ToString().Equals(value2.ToString());
        }
    }
}