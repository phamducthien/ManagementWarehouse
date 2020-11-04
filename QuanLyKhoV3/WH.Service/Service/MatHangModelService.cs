using ExcelLibrary;
using Repository.Pattern.UnitOfWork;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Util.Pattern;
using WH.Entity;
using WH.Model;
using WH.Model.Properties;
using WH.Service.Service;

namespace WH.Service
{
    public interface IMatHangModelService : IService
    {
        MethodResult InsertMatHang(MATHANG objMathang, bool isCommited = true);
        MethodResult UpdateMatHang(MATHANG objMathang, bool isCommited = true);
        MethodResult DeleteMatHang(MATHANG objMathang, bool isCommited = true);
        DataTable GetListMatHang();
        DataTable GetListMatHang(string textSearch);

        MATHANG GetMatHang(int maMatHang);
        MATHANG CreateNew();
        KHOMATHANG GetKhomathang(int maMatHang);

        MethodResult XuatExcel(string pathSave);
        MethodResult NhapExcel(string pathOpen, bool isCommited = true);
        MethodResult XuatExcelMau(string pathSave);
    }

    public class MatHangModelService : global::Service.Pattern.Service, IMatHangModelService
    {
        private readonly Guid _maKho = SessionModel.CurrentSession.KhoMatHang.MAKHO;
        private IDONVIService _donviService;

        private readonly string _filenameSaveTempExcel = Path.Combine(StaticGlobalVariables.PathTempFolder,
            DateTime.Now.ToString("ddMMyyyyHHmmss") + ".temp");

        private readonly string _filenameTemplateExcel =
            Path.Combine(StaticGlobalVariables.PathExcelTemp, "DSMatHangTemplate.xlsx");

        private readonly string _iduser = SessionModel.CurrentSession.UserId;
        private IKHOMATHANGService _khomathangService;
        private ILOAIMATHANGService _loaimathang;
        private int _maCa = SessionModel.CurrentSession.CaID;
        private IMATHANGKHUYENMAIService _mathangkhuyenmaiService;

        private IMATHANGService _mathangService;

        public MatHangModelService(IUnitOfWorkAsync unitOfWork) : base(unitOfWork)
        {
        }

        public new string ErrMsg { get; set; }
        public new string InnerErrMsg { get; set; }

        public MethodResult InsertMatHang(MATHANG objMathang, bool isCommited)
        {
            try
            {
                if (isCommited)
                    _unitOfWork.BeginTransaction();

                var result = _mathangService.Add(objMathang);
                if (result != MethodResult.Succeed)
                    if (result != MethodResult.Succeed)
                        goto loi1;

                var objnew =
                    _mathangService.Search(s => s.ISDELETE == false && s.MACODE == objMathang.MACODE)
                        .OrderByDescending(s => s.MAMATHANG).FirstOrDefault();
                if (objnew.isNull()) goto loi2;

                var lstKhomathangs = _khomathangService.Clone(objMathang.KHOMATHANGs);
                foreach (var o in lstKhomathangs)
                {
                    if (objnew != null) o.MAMATHANG = objnew.MAMATHANG;
                    o.MAKHO = _maKho;
                    o.SOLUONGSI = 0;
                    result = _khomathangService.Add(o);
                    if (result != MethodResult.Succeed)
                        if (result != MethodResult.Succeed)
                            goto loi3;
                }

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

        loi1:
            {
                _unitOfWork?.Rollback();
                ErrMsg = _mathangService.ErrMsg;
                return MethodResult.Failed;
            }
        loi2:
            {
                _unitOfWork?.Rollback();
                ErrMsg = "Không tìm thấy mặt hàng!";
                return MethodResult.Failed;
            }
        loi3:
            {
                _unitOfWork?.Rollback();
                ErrMsg = _khomathangService.ErrMsg;
                return MethodResult.Failed;
            }
        }

        public MethodResult UpdateMatHang(MATHANG objMathang, bool isCommited)
        {
            try
            {
                if (isCommited)
                    _unitOfWork.BeginTransaction();

                var result = _mathangService.Modify(objMathang);
                if (result != MethodResult.Succeed)
                    if (result != MethodResult.Succeed)
                        goto loi1;

                var lstKhomathangs = _khomathangService.Clone(objMathang.KHOMATHANGs);
                foreach (var o in lstKhomathangs)
                {
                    o.MAMATHANG = objMathang.MAMATHANG;
                    o.MAKHO = _maKho;
                    o.SOLUONGSI = 0;

                    result = _khomathangService.Modify(o);
                    if (result != MethodResult.Succeed)
                        if (result != MethodResult.Succeed)
                            goto loi3;
                }

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

        loi1:
            {
                _unitOfWork?.Rollback();
                ErrMsg = _mathangService.ErrMsg;
                return MethodResult.Failed;
            }

        loi3:
            {
                _unitOfWork?.Rollback();
                ErrMsg = _khomathangService.ErrMsg;
                return MethodResult.Failed;
            }
        }

        public MethodResult DeleteMatHang(MATHANG objMathang, bool isCommited)
        {
            try
            {
                if (isCommited)
                    _unitOfWork.BeginTransaction();

                objMathang.ISDELETE = true;
                objMathang.ISUSE = false;
                var result = _mathangService.Modify(objMathang);
                if (result != MethodResult.Succeed)
                    if (result != MethodResult.Succeed)
                        goto loi1;

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

        loi1:
            {
                _unitOfWork?.Rollback();
                ErrMsg = _mathangService.ErrMsg;
                return MethodResult.Failed;
            }
        }

        public DataTable GetListMatHang()
        {
            try
            {
                var record = 1;
                var lst = _mathangService.Search(s => s.ISDELETE == false && s.ISUSE == true).Select(p => new
                {
                    STT = record++, //0
                    TENLOAI = p.LOAIMATHANG?.TENLOAIMATHANG, //1
                    p.TENMATHANG,
                    p.MACODE,
                    p.MABARCODE,
                    LE = p.GIALE ?? 0,
                    NHAP = p.GIANHAP ?? 0,
                    QUYCACH = p.SOLUONGQUYDOI ?? 0,
                    p.DONVI1?.TENDONVI,
                    SLTON = p.KHOMATHANGs[0]?.SOLUONGLE ?? 0,
                    TONTOITHIEU = p.NGUONGNHAP ?? 0,
                    TONTOIDA = p.NGUONGXUAT ?? 0,
                    GIAM = p.CHIETKHAU ?? 0,
                    p.GHICHU,
                    p.MAMATHANG,
                    p.MALOAIMATHANG,
                    p.MADONVISI,
                    p.MADONVILE,
                    //TONGTONKHO = p.HOADONHAPKHOCHITIETs.Sum(d => d.THANHTIENSAUCHIETKHAU_CT) ?? 0,
                    //TONGBAN = p.HOADONXUATKHOCHITIETs.Sum(d => d.THANHTIENSAUCHIETKHAU_CT) ?? 0,
                    //TONHNHAP = p.HOADONXUATKHOCHITIETs.Sum(d => d.SOLUONGLE * d.SOLUONGSI) ?? 0,
                    //TONGTRA = p.HOADONNHAPXUATCHITIETs.Sum(d => d.THANHTIENSAUCHIETKHAU_CT) ?? 0,
                    //TONGLAI = p.HOADONXUATKHOCHITIETs.Sum(d => d.THANHTIENSAUCHIETKHAU_CT) ??
                    //          0 - p.HOADONXUATKHOCHITIETs.Sum(d => d.SOLUONGLE * d.SOLUONGSI) ?? 0 -
                    //          p.HOADONNHAPXUATCHITIETs.Sum(d => d.THANHTIENSAUCHIETKHAU_CT) ?? 0,
                    TONGLAI = p.GIALE * (decimal)(1 - p.CHIETKHAU) - p.GIANHAP,
                    //TrangThai =
                    //(p.HOADONXUATKHOCHITIETs.Sum(d => d.THANHTIENSAUCHIETKHAU_CT) ??
                    // 0 - p.HOADONXUATKHOCHITIETs.Sum(d => d.SOLUONGLE * d.SOLUONGSI) ??
                    // 0 - p.HOADONNHAPXUATCHITIETs.Sum(d => d.THANHTIENSAUCHIETKHAU_CT) ?? 0) == 0
                    //    ? Resources.status3
                    //    : (p.HOADONXUATKHOCHITIETs.Sum(d => d.THANHTIENSAUCHIETKHAU_CT) ??
                    //       0 - p.HOADONXUATKHOCHITIETs.Sum(d => d.SOLUONGLE * d.SOLUONGSI) ??
                    //       0 - p.HOADONNHAPXUATCHITIETs.Sum(d => d.THANHTIENSAUCHIETKHAU_CT) ?? 0) < 0
                    //        ? Resources.status1
                    //        : Resources.status2
                    TrangThai = p.GIALE * (decimal)(1 - p.CHIETKHAU) - p.GIANHAP == 0 ? Resources.status3 :
                    p.GIALE * (decimal)(1 - p.CHIETKHAU) - p.GIANHAP < 0 ? Resources.status1 : Resources.status2
                });


                return lst.ToDatatable();
            }
            catch (Exception exception)
            {
                ErrMsg = exception.Message;
            }

            return null;
        }

        public DataTable GetListMatHang(string textSearch)
        {
            try
            {
                var record = 1;
                var lst = _mathangService.Search(s => s.ISDELETE == false && s.ISUSE == true, textSearch).Select(
                    p => new
                    {
                        STT = record++, //0
                        TENLOAI = p.LOAIMATHANG?.TENLOAIMATHANG, //1
                        p.TENMATHANG,
                        p.MACODE,
                        p.MABARCODE,
                        LE = p.GIALE ?? 0,
                        NHAP = p.GIANHAP ?? 0,
                        QUYCACH = p.SOLUONGQUYDOI ?? 0,
                        p.DONVI1?.TENDONVI,
                        SLTON = p.KHOMATHANGs[0]?.SOLUONGLE ?? 0,
                        TONTOITHIEU = p.NGUONGNHAP ?? 0,
                        TONTOIDA = p.NGUONGXUAT ?? 0,
                        GIAM = p.CHIETKHAU ?? 0,
                        p.GHICHU,
                        p.MAMATHANG,
                        p.MALOAIMATHANG,
                        p.MADONVISI,
                        p.MADONVILE,
                        //TONGTONKHO = p.HOADONHAPKHOCHITIETs.Sum(d => d.THANHTIENSAUCHIETKHAU_CT) ?? 0,
                        //TONGBAN = p.HOADONXUATKHOCHITIETs.Sum(d => d.THANHTIENSAUCHIETKHAU_CT) ?? 0,
                        //TONHNHAP = p.HOADONXUATKHOCHITIETs.Sum(d => d.SOLUONGLE * d.SOLUONGSI) ?? 0,
                        //TONGTRA = p.HOADONNHAPXUATCHITIETs.Sum(d => d.THANHTIENSAUCHIETKHAU_CT) ?? 0,
                        //TONGLAI = p.HOADONXUATKHOCHITIETs.Sum(d => d.THANHTIENSAUCHIETKHAU_CT) ??
                        //          0 - p.HOADONXUATKHOCHITIETs.Sum(d => d.SOLUONGLE * d.SOLUONGSI) ?? 0 -
                        //          p.HOADONNHAPXUATCHITIETs.Sum(d => d.THANHTIENSAUCHIETKHAU_CT) ?? 0,
                        TONGLAI = p.GIALE * (decimal)(1 - p.CHIETKHAU) - p.GIANHAP,
                        //TrangThai =
                        //(p.HOADONXUATKHOCHITIETs.Sum(d => d.THANHTIENSAUCHIETKHAU_CT) ??
                        // 0 - p.HOADONXUATKHOCHITIETs.Sum(d => d.SOLUONGLE * d.SOLUONGSI) ??
                        // 0 - p.HOADONNHAPXUATCHITIETs.Sum(d => d.THANHTIENSAUCHIETKHAU_CT) ?? 0) == 0
                        //    ? Resources.status3
                        //    : (p.HOADONXUATKHOCHITIETs.Sum(d => d.THANHTIENSAUCHIETKHAU_CT) ??
                        //       0 - p.HOADONXUATKHOCHITIETs.Sum(d => d.SOLUONGLE * d.SOLUONGSI) ??
                        //       0 - p.HOADONNHAPXUATCHITIETs.Sum(d => d.THANHTIENSAUCHIETKHAU_CT) ?? 0) < 0
                        //        ? Resources.status1
                        //        : Resources.status2
                        TrangThai = p.GIALE * (decimal)(1 - p.CHIETKHAU) - p.GIANHAP == 0 ? Resources.status3 :
                        p.GIALE * (decimal)(1 - p.CHIETKHAU) - p.GIANHAP < 0 ? Resources.status1 : Resources.status2
                    });
                return lst.ToDatatable();
            }
            catch (Exception exception)
            {
                ErrMsg = exception.Message;
            }

            return null;
        }

        public MATHANG GetMatHang(int maMatHang)
        {
            return _mathangService.Find(s => s.MAMATHANG == maMatHang);
        }

        public MATHANG CreateNew()
        {
            return _mathangService.CreateNew();
        }

        public KHOMATHANG GetKhomathang(int maMatHang)
        {
            return _khomathangService.Find(s => s.MAKHO == _maKho && s.MAMATHANG == maMatHang);
        }

        public MethodResult XuatExcelMau(string pathSave)
        {
            var result = MethodResult.Failed;
            try
            {
                File.Copy(_filenameTemplateExcel, _filenameSaveTempExcel, true);
                var sl = new SLDocument(_filenameSaveTempExcel, "DSNhapMatHang")
                {
                    DocumentProperties =
                    {
                        Title = "DSNhapMatHang",
                        Subject = "Xuất Excel Mẫu Danh Sách Mặt Hàng",
                        Category = "Danh Mục",
                        Creator = "Cong Ty Phat Trien Thuong Mai Dich Vu.",
                        ContentStatus = " Mặt Hàng",
                        Description = "Danh Sách Các Mặt Hàng."
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

        public MethodResult NhapExcel(string pathOpen, bool isCommited)
        {
            var result = MethodResult.Succeed;
            try
            {
                if (isCommited)
                    _unitOfWork.BeginTransaction();

                var fs = new FileStream(pathOpen, FileMode.Open, FileAccess.Read);
                var sl = new SLDocument(fs, "DSNhapMatHang");

                if (sl.DocumentProperties.Title != "DSMatHang")
                    if (sl.DocumentProperties.Title != "DSNhapMatHang")
                        goto loi1;

                var listInsert = new List<MATHANG>();
                var listUpdate = new List<MATHANG>();
                var starts = sl.GetWorksheetStatistics();

                var countInsert = 0;
                var countUpdate = 0;
                var countInsertFailed = 0;
                var countUpdateFailed = 0;

                for (var i = 3; i <= starts.EndRowIndex; i++)
                {
                    var stt = sl.GetCellValueAsString(i, 1);
                    if (stt.IsNull()) continue;

                    #region Duyet Row trong Excel

                    var index = 1;
                    var countchanges = 0;
                    var isAdd = false;
                    var idUnit = sl.GetCellValueAsString(i, 15);

                    var objKhomathang =
                        _khomathangService.Find(s => s.MAMATHANG.ToString().Equals(idUnit) && s.MAKHO == _maKho);

                    var model = _mathangService.Find(s => s.MAMATHANG.ToString().Equals(idUnit));

                    if (model.isNull())
                    {
                        idUnit = sl.GetCellValueAsString(i, 4);
                        model = _mathangService.Find(s => s.MACODE.Equals(idUnit));
                    }

                    if (model.isNull())
                    {
                        model = _mathangService.CreateNew();
                        model.NGAYTAO = DateTime.Now;
                        model.NGUOITAO = _iduser;
                        model.ISDELETE = false;
                        model.ISTHEODOI = true;
                        model.ISUSE = true;

                        objKhomathang = _khomathangService.CreateNew();
                        objKhomathang.MAKHO = _maKho;
                        objKhomathang.SOLUONGSI = 0;
                        objKhomathang.SOLUONGLE = 0;
                        isAdd = true;
                    }

                    index++; //2 TENLOAI
                    var tenloai = CheckChange(sl.GetCellValueAsString(i, index), model.TENLOAI, ref countchanges)
                        .ToString();

                    index++;
                    model.TENMATHANG =
                        CheckChange(sl.GetCellValueAsString(i, index++), model.TENMATHANG, ref countchanges).ToString();
                    model.MACODE = CheckChange(sl.GetCellValueAsString(i, index++), model.MACODE, ref countchanges)
                        .ToString();
                    model.MABARCODE =
                        CheckChange(sl.GetCellValueAsString(i, index++), model.MABARCODE, ref countchanges).ToString();
                    model.GIALE = CheckChange(sl.GetCellValueAsString(i, index++), model.GIALE, ref countchanges)
                        .ToString().ToDecimal();
                    model.GIANHAP = CheckChange(sl.GetCellValueAsString(i, index++), model.GIANHAP, ref countchanges)
                        .ToString().ToDecimal();
                    index++;
                    model.SOLUONGQUYDOI =
                        1; //CheckChange(sl.GetCellValueAsString(i, 8), model.SOLUONGQUYDOI, ref countchanges).ToString().ToInt();
                    var tendonvi = CheckChange(sl.GetCellValueAsString(i, index++), model.TENDONVI, ref countchanges)
                        .ToString(); //TENDONVI index = 9;
                    //Ton Kho.
                    var slTonKho = CheckChange(sl.GetCellValueAsString(i, index++), objKhomathang?.SOLUONGLE ?? 0,
                        ref countchanges).ToString();
                    objKhomathang.SOLUONGLE = slTonKho.isNull() ? 0 : slTonKho.ToDecimal();

                    model.NGUONGNHAP =
                        CheckChange(sl.GetCellValueAsString(i, index++), model.NGUONGNHAP, ref countchanges).ToString()
                            .ToDecimal();
                    model.NGUONGXUAT =
                        CheckChange(sl.GetCellValueAsString(i, index++), model.NGUONGXUAT, ref countchanges).ToString()
                            .ToDecimal();
                    var ck =
                        CheckChange(sl.GetCellValueAsString(i, index++), model.CHIETKHAU, ref countchanges).ToString();
                    if (ck == "") ck = "0";
                    model.CHIETKHAU = ck.ToDouble();

                    model.GHICHU =
                        CheckChange(sl.GetCellValueAsString(i, index++), model.GHICHU, ref countchanges)
                            .ToString(); //12

                    //Khoa Ngoai 
                    index++; //15MAMATHANG
                    var makhoangoai =
                        CheckChange(sl.GetCellValueAsString(i, index++), model.MALOAIMATHANG, ref countchanges)
                            .ToString();
                    model.MALOAIMATHANG = makhoangoai.IsBlank() ? 1 : makhoangoai.ToInt(); //14

                    makhoangoai =
                        CheckChange(sl.GetCellValueAsString(i, index++), model.MADONVISI, ref countchanges).ToString();
                    model.MADONVISI = makhoangoai.IsBlank() ? 1 : makhoangoai.ToInt(); //15

                    model.MADONVILE = model.MADONVISI;

                    model.KHOMATHANGs.Add(objKhomathang);
                    //them chuc nang nhap theo loai mat hang
                    model.MALOAIMATHANG =
                        _loaimathang.Find(s => s.TENLOAIMATHANG.Contains(tenloai))?.MALOAIMATHANG ?? 1;
                    //them chuc nang nhap theo loai mat hang
                    model.MADONVILE =
                        model.MADONVISI = _donviService.Find(s => s.TENDONVI.Contains(tendonvi))?.MADONVI ?? 1;

                    #endregion

                    if (isAdd)
                    {
                        result = InsertMatHang(model, false);
                        if (result != MethodResult.Succeed)
                        {
                            countInsertFailed++;
                            ErrMsg += "Add Failed: " + stt + "-" + model.TENMATHANG + "\n";
                            goto loi2;
                        }

                        listInsert.Add(model);
                        countInsert++;
                        ErrMsg += "Add: " + stt + "-" + model.TENMATHANG + "\n";
                    }
                    else
                    {
                        result = UpdateMatHang(model, false);
                        if (result != MethodResult.Succeed)
                        {
                            countUpdateFailed++;
                            ErrMsg += "Update Failed: " + stt + "-" + model.TENMATHANG + "\n";
                            goto loi2;
                        }

                        listUpdate.Add(model);
                        countUpdate++;
                        ErrMsg += "Update: " + stt + "-" + model.TENMATHANG + "\n";
                    }
                }

                sl.CloseWithoutSaving();
                sl.Dispose();
                fs.Dispose();

                if (countUpdate == 0 && countInsert == 0)
                    ErrMsg = "Không có dữ liệu thay đổi!";
                else
                    ErrMsg = "Có " + countInsert + " mặt hàng được thêm!\nCó " + countUpdate +
                             " mặt hàng được cập nhật!";

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

        loi1:
            {
                _unitOfWork?.Rollback();
                ErrMsg = "Vui lòng chọn đúng file excel mặt hàng!!!";
                return MethodResult.Failed;
            }

        loi2:
            {
                _unitOfWork?.Rollback();
                return MethodResult.Failed;
            }
        }

        public MethodResult XuatExcel(string pathSave)
        {
            MethodResult result;
            try
            {
                var indexRow = 3;
                var index = 0;
                var data = GetListMatHang();
                File.Copy(_filenameTemplateExcel, _filenameSaveTempExcel, true);

                var sl = new SLDocument(_filenameSaveTempExcel, "DSMatHang")
                {
                    DocumentProperties =
                    {
                        Title = "DSMatHang",
                        Subject = "Xuất Excel Danh Sách Mặt Hàng",
                        Category = "Danh Mục",
                        Creator = "Cong Ty Phat Trien Thuong Mai Dich Vu.",
                        ContentStatus = "Mặt Hàng",
                        Description = "Danh Sách Các Mặt Hàng."
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
                    sl.SetCellValue("F" + indexRow, (row[index++]?.ToString() ?? "0").ToDecimal());
                    sl.SetCellValue("G" + indexRow, (row[index++]?.ToString() ?? "0").ToDecimal());
                    sl.SetCellValue("H" + indexRow, (row[index++]?.ToString() ?? "0").ToDecimal());
                    sl.SetCellValue("I" + indexRow, row[index++]?.ToString() ?? "");
                    sl.SetCellValue("J" + indexRow, (row[index++]?.ToString() ?? "0").ToDecimal());
                    sl.SetCellValue("K" + indexRow, (row[index++]?.ToString() ?? "0").ToDecimal());
                    sl.SetCellValue("L" + indexRow, (row[index++]?.ToString() ?? "0").ToDecimal());
                    sl.SetCellValue("M" + indexRow, (row[index++]?.ToString() ?? "0").ToDecimal());
                    sl.SetCellValue("N" + indexRow, row[index++]?.ToString() ?? "");
                    sl.SetCellValue("O" + indexRow, row[index++]?.ToString() ?? "");
                    sl.SetCellValue("P" + indexRow, row[index++]?.ToString() ?? "");
                    sl.SetCellValue("Q" + indexRow, row[index++]?.ToString() ?? "");
                    sl.SetCellValue("R" + indexRow, row[index++]?.ToString() ?? "");
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

        protected override void InitRepositories()
        {
            _mathangService = new MATHANGService(_unitOfWork);
            _khomathangService = new KHOMATHANGService(_unitOfWork);
            _donviService = new DONVIService(_unitOfWork);
            _loaimathang = new LOAIMATHANGService(_unitOfWork);
            _mathangkhuyenmaiService = new MATHANGKHUYENMAIService(_unitOfWork);
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
