using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using ExcelLibrary;
using Repository.Pattern.UnitOfWork;
using Service.Pattern;
using Util.Pattern;
using WH.Entity;
using WH.Model;
using WH.Service.Service;

namespace WH.Service
{
    public interface IKhachHangModelService : IService
    {
        MethodResult XuatExcel(string pathSave);
        MethodResult NhapExcel(string pathOpen, bool isCommited = true);
        MethodResult XuatExcelMau(string pathSave);
    }

    public class KhachHangModelService : global::Service.Pattern.Service, IKhachHangModelService
    {
        private readonly string _filenameSaveTempExcel = Path.Combine(StaticGlobalVariables.PathTempFolder,
            DateTime.Now.ToString("ddMMyyyyHHmmss") + ".temp");

        private readonly string _filenameTemplateExcel =
            Path.Combine(StaticGlobalVariables.PathExcelTemp, "DSDoiTacTemplate.xlsx");

        private readonly string _iduser = SessionModel.CurrentSession.UserId;
        private IKHACHHANGService _khachhangService;
        private IKHACHHANGKHUVUCService _khuvucService;

        public KhachHangModelService(IUnitOfWorkAsync unitOfWork) : base(unitOfWork)
        {
        }

        public MethodResult XuatExcel(string pathSave)
        {
            MethodResult result;
            try
            {
                var indexRow = 3;
                var index = 0;
                var data = GetListKhachHang();
                File.Copy(_filenameTemplateExcel, _filenameSaveTempExcel, true);

                var sl = new SLDocument(_filenameSaveTempExcel, "DSDoiTac")
                {
                    DocumentProperties =
                    {
                        Title = "DSDoiTac",
                        Subject = "Xuất Excel Danh Sách Đối Tác",
                        Category = "Danh Mục",
                        Creator = "Cong Ty Phat Trien Thuong Mai Dich Vu.",
                        ContentStatus = "Đối Tác",
                        Description = "Danh Sách Các Đối Tác."
                    }
                };

                foreach (DataRow row in data.Rows)
                {
                    //index++;
                    sl.SetCellValue("A" + indexRow, row[index++]?.ToString() ?? "");
                    sl.SetCellValue("B" + indexRow, row[index++]?.ToString() ?? "");
                    sl.SetCellValue("C" + indexRow, row[index++].ToString() ?? "");
                    sl.SetCellValue("D" + indexRow, row[index++]?.ToString() ?? "");
                    sl.SetCellValue("E" + indexRow, row[index++]?.ToString() ?? "");
                    sl.SetCellValue("F" + indexRow, row[index++]?.ToString() ?? "");
                    sl.SetCellValue("G" + indexRow, row[index++]?.ToString() ?? "");
                    sl.SetCellValue("H" + indexRow, row[index++]?.ToString() ?? "");
                    sl.SetCellValue("I" + indexRow, row[index++]?.ToString() ?? "");
                    sl.SetCellValue("J" + indexRow, row[index++]?.ToString() ?? "");
                    sl.SetCellValue("K" + indexRow, row[index++]?.ToString() ?? "");
                    sl.SetCellValue("L" + indexRow, row[index++]?.ToString() ?? "");
                    sl.SetCellValue("M" + indexRow, row[index++]?.ToString() ?? "");
                    sl.SetCellValue("N" + indexRow, row[index++]?.ToString() ?? "");
                    sl.SetCellValue("O" + indexRow, row[index++]?.ToString() ?? "");
                    sl.SetCellValue("P" + indexRow, row[index++]?.ToString() ?? "");
                    sl.SetCellValue("Q" + indexRow, row[index++]?.ToString() ?? "");

                    index = 0;
                    indexRow++;
                }

                sl.Save();
                sl.Dispose();

                File.Copy(_filenameSaveTempExcel, pathSave, true);
                result = MethodResult.Succeed;
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
                result = MethodResult.Failed;
            }

            return result;
        }

        public MethodResult NhapExcel(string pathOpen, bool isCommited = true)
        {
            var result = MethodResult.Succeed;
            var fs = new FileStream(pathOpen, FileMode.Open, FileAccess.Read);
            var sl = new SLDocument(fs, "DSNhapDoiTac");
            try
            {
                if (isCommited)
                    _unitOfWork.BeginTransaction();
                if (sl.DocumentProperties.Title != "DSDoiTac")
                    if (sl.DocumentProperties.Title != "DSNhapDoiTac")
                        goto loi1;

                var listInsert = new List<KHACHHANG>();
                var listUpdate = new List<KHACHHANG>();
                var starts = sl.GetWorksheetStatistics();

                var countInsert = 0;
                var countUpdate = 0;
                var countInsertFailed = 0;
                var countUpdateFailed = 0;

                string unit1;
                string unit2;
                for (var i = 3; i <= starts.EndRowIndex; i++)
                {
                    var stt = sl.GetCellValueAsString(i, 1);
                    if (stt.IsNull()) continue;

                    #region Duyet Row trong Excel

                    var index = 1;
                    var countchanges = 0;
                    var isAdd = false;
                    var idUnit = sl.GetCellValueAsString(i, 14);


                    var model = _khachhangService.Find(s => s.MAKHACHHANG.ToString().Equals(idUnit));

                    if (model.isNull())
                    {
                        idUnit = sl.GetCellValueAsString(i, 4);
                        model = _khachhangService.Find(s => s.CODEKHACHHANG.Equals(idUnit));
                    }

                    if (model.isNull())
                    {
                        model = _khachhangService.CreateNew();
                        model.NGAYTAO = DateTime.Now;
                        model.NGUOITAO = _iduser;
                        model.ISDELETE = false;
                        model.ISUSE = true;
                        isAdd = true;
                    }

                    index++; //2 TENKHUVUC
                    index++; //2 TENKHUVUC
                    var tenkhuvuc =
                        CheckChange(sl.GetCellValueAsString(i, index), model?.KHACHHANGKHUVUC?.TEN ?? string.Empty,
                            ref countchanges).ToString();

                    model.TENKHACHHANG =
                        CheckChange(sl.GetCellValueAsString(i, index++), model.TENKHACHHANG, ref countchanges)
                            .ToString(); //3
                    model.CODEKHACHHANG =
                        CheckChange(sl.GetCellValueAsString(i, index++), model.CODEKHACHHANG, ref countchanges)
                            .ToString(); //4
                    model.MABARCODE =
                        CheckChange(sl.GetCellValueAsString(i, index++), model.MABARCODE, ref countchanges).ToString();
                    //5

                    model.DIACHI =
                        CheckChange(sl.GetCellValueAsString(i, index++), model.DIACHI, ref countchanges).ToString(); //6
                    model.DIACHICONGTY =
                        CheckChange(sl.GetCellValueAsString(i, index++), model.DIACHICONGTY, ref countchanges)
                            .ToString(); //7
                    model.DIACHIGIAOHANG =
                        CheckChange(sl.GetCellValueAsString(i, index++), model.DIACHIGIAOHANG, ref countchanges)
                            .ToString(); //8
                    model.DIACHIGIAOHOADON =
                        CheckChange(sl.GetCellValueAsString(i, index++), model.DIACHIGIAOHOADON, ref countchanges)
                            .ToString(); //9

                    model.CONGTY =
                        CheckChange(sl.GetCellValueAsString(i, index++), model.CONGTY, ref countchanges)
                            .ToString(); //10

                    model.DIDONG =
                        CheckChange(sl.GetCellValueAsString(i, index++), model.DIDONG, ref countchanges)
                            .ToString(); //11

                    model.DIENTHOAI =
                        CheckChange(sl.GetCellValueAsString(i, index++), model.DIENTHOAI, ref countchanges)
                            .ToString(); //12

                    model.GHICHU =
                        CheckChange(sl.GetCellValueAsString(i, index++), model.GHICHU, ref countchanges)
                            .ToString(); //13


                    //Khoa Ngoai 
                    index++; //14 MAKH
                    var makhoangoai =
                        CheckChange(sl.GetCellValueAsString(i, index++), model.MAKHUVUC, ref countchanges).ToString();
                    model.MAKHUVUC = makhoangoai.IsBlank() ? 1 : makhoangoai.ToInt(); //15

                    makhoangoai =
                        CheckChange(sl.GetCellValueAsString(i, index++), model.MANHOM, ref countchanges).ToString();
                    model.MANHOM = makhoangoai.IsBlank() ? 1 : makhoangoai.ToInt(); //16

                    makhoangoai =
                        CheckChange(sl.GetCellValueAsString(i, index++), model.MALOAIKHACHHANG, ref countchanges)
                            .ToString();
                    model.MALOAIKHACHHANG = makhoangoai.IsBlank() ? 1 : makhoangoai.ToInt(); //16


                    //them chuc nang nhap theo khu vuc
                    model.MAKHUVUC = _khuvucService.Find(s => s.TEN.Contains(tenkhuvuc))?.MAKHUVUC ?? 1;

                    #endregion

                    if (isAdd)
                    {
                        result = _khachhangService.Add(model, false);
                        if (result != MethodResult.Succeed)
                        {
                            countInsertFailed++;
                            ErrMsg += "Add Failed: " + stt + "-" + model.TENKHACHHANG + "\n";
                            goto loi2;
                        }

                        listInsert.Add(model);
                        countInsert++;
                        ErrMsg += "Add: " + stt + "-" + model.TENKHACHHANG + "\n";
                    }
                    else
                    {
                        result = _khachhangService.Modify(model, false);
                        if (result != MethodResult.Succeed)
                        {
                            countUpdateFailed++;
                            ErrMsg += "Update Failed: " + stt + "-" + model.TENKHACHHANG + "\n";
                            goto loi2;
                        }

                        listUpdate.Add(model);
                        countUpdate++;
                        ErrMsg += "Update: " + stt + "-" + model.TENKHACHHANG + "\n";
                    }
                }


                if (countUpdate == 0 && countInsert == 0)
                    ErrMsg = "Không có dữ liệu thay đổi!";
                else
                    ErrMsg = "Có " + countInsert + " đối tác được thêm!\nCó " + countUpdate + " đối tác được cập nhật!";

                if (isCommited)
                {
                    _unitOfWork?.Commit();
                    result = MethodResult.Succeed;
                }

                return result;
            }
            catch (Exception exception)
            {
                _unitOfWork?.Rollback();
                ErrMsg = exception.Message;
                return MethodResult.Failed;
            }
            finally
            {
                sl.CloseWithoutSaving();
                sl.Dispose();
                fs.Dispose();
            }

            loi1:
            {
                _unitOfWork?.Rollback();
                ErrMsg = "Vui lòng chọn đúng file excel đối tác!!!";
                return MethodResult.Failed;
            }

            loi2:
            {
                _unitOfWork?.Rollback();
                return MethodResult.Failed;
            }
        }

        public MethodResult XuatExcelMau(string pathSave)
        {
            var result = MethodResult.Failed;
            try
            {
                File.Copy(_filenameTemplateExcel, _filenameSaveTempExcel, true);
                var sl = new SLDocument(_filenameSaveTempExcel, "DSNhapDoiTac")
                {
                    DocumentProperties =
                    {
                        Title = "DSNhapDoiTac",
                        Subject = "Xuất Excel Mẫu Danh Sách Đối Tác",
                        Category = "Danh Mục",
                        Creator = "Cong Ty Phat Trien Thuong Mai Dich Vu.",
                        ContentStatus = "Đối Tác",
                        Description = "Danh Sách Các Đối Tác."
                    }
                };
                sl.Save();
                sl.Dispose();
                File.Copy(_filenameSaveTempExcel, pathSave, true);
                result = MethodResult.Succeed;
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
            }

            return result;
        }

        protected override void InitRepositories()
        {
            _khachhangService = new KHACHHANGService(_unitOfWork);
            _khuvucService = new KHACHHANGKHUVUCService(_unitOfWork);
        }

        private DataTable GetListKhachHang()
        {
            var record = 1;
            var lsearch = _khachhangService.Search(s =>
                s.ISDELETE == false && s.ISUSE == true &&
                s.MAKHACHHANG.ToString().ToLower() != "56dbc32e-11d7-4175-a7ac-608ccbf962d7" &&
                s.MAKHACHHANG.ToString().ToLower() != "66dbc32e-11d7-4175-a7ac-608ccbf962d7");
            var lst = lsearch.Select(p => new
            {
                STT = record++, //0
                KHUVUC = p.KHACHHANGKHUVUC?.TEN, //1
                p.TENKHACHHANG,
                p.CODEKHACHHANG,
                p.MABARCODE,
                p.DIACHI,
                p.DIACHICONGTY,
                DCKHO = p.DIACHIGIAOHANG,
                DCHANGDONG = p.DIACHIGIAOHOADON,
                TENSHOP = p.CONGTY,
                p.DIDONG,
                p.DIENTHOAI,
                p.GHICHU,
                p.MAKHACHHANG,
                p.MAKHUVUC,
                p.MANHOM,
                p.MALOAIKHACHHANG
            });

            return lst.ToList().ToDatatable();
        }

        private object CheckChange(object value1, object value2, ref int count)
        {
            var kq = !value1.Equals(value2);
            if (kq)
            {
                count++;
                return value1;
            }

            return value2;
        }
    }
}