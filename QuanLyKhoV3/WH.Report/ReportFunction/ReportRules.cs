using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using WH.Model;

namespace WH.Report.ReportFunction
{
    public class ReportRules
    {
        private DataTable LoadDataTable(string command)
        {
            DataTable dt;
            try
            {
                var cmd = new SqlCommand(command, GlobalContext.ServerConnection)
                {
                    CommandTimeout = 60
                };

                var sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count == 0)
                    dt = null;
            }
            catch (Exception ex)
            {
                throw new Exception("LoadDataTable" + ex.Message, ex);
            }

            return dt;
        }

        private DataTable LoadToDataTable(string sql)
        {
            var dt = LoadDataTable(sql);
            return dt;
        }

        #region Get Doanh Thu Khach Hang

        private DataTable GetReceiptBills(string soLuongHdLoad, string maNhanVien, string maCodeKhachHang,
            string batDau, string ketThuc, bool isOrderByNgayThanhToan, bool isBanLe, bool groupbyKhachHang)
        {
            var sqlSelect = "SELECT " + soLuongHdLoad +
                            "kh.CODEKHACHHANG, kh.TENKHACHHANG,kh.DIACHI,kh.DIENTHOAI, hd.MAHOADONXUAT as MAHOADONXUAT, hd.SOTIENTHANHTOAN_HD as TONGTIENHOADON, isnull(TablePhieuThu.TONGTIENTHU, 0) as SOTIENKHACHDUA, (hd.SOTIENTHANHTOAN_HD -hd.SOTIENKHACHDUA_HD) as CONGNO, hd.NGAYTAOHOADON as NgayTaoHoaDon, " +
                            "\"TinhTrang\" = " +
                            "CASE " +
                            " WHEN (hd.SOTIENTHANHTOAN_HD - isnull(TablePhieuThu.TONGTIENTHU, 0)) <= 0 THEN N'Đã Thanh Toán' " +
                            " ELSE  N'Chưa Thanh Toán' " +
                            "END ";

            var sqlFrom = " FROM KHACHHANG kh, NGUOIDUNG nd, HOADONXUATKHO hd ";
            sqlFrom += "left join ";
            sqlFrom += "(select SUM(pt.TIENTHANHTOAN)as TONGTIENTHU, MAHOADONXUATKHO as MAHOADONXUATKHO " +
                       "from PHIEUTHU pt " +
                       "group by MAHOADONXUATKHO) as TablePhieuThu on hd.MAHOADONXUAT = TablePhieuThu.MAHOADONXUATKHO ";

            var sqlWhere =
                " WHERE hd.MAKHACHHANG=kh.MAKHACHHANG and nd.MANGUOIDUNG=hd.NGUOITAO and hd.MAKHACHHANG=kh.MAKHACHHANG ";

            if (maNhanVien != "")
                sqlWhere += " AND ND.MANGUOIDUNG ='" + maNhanVien + "' ";

            if (maCodeKhachHang != "")
                sqlWhere += " AND kh.CODEKHACHHANG ='" + maCodeKhachHang + "' ";

            if (batDau != "")
                sqlWhere += " AND hd.NGAYTAOHOADON >= '" + batDau + "' ";

            if (ketThuc != "")
                sqlWhere += " AND hd.NGAYTAOHOADON <= '" + ketThuc + "' ";

            var sqlOrderBy = " ORDER BY HD.NGAYTAOHOADON DESC";

            var sql = sqlSelect + sqlFrom + sqlWhere + sqlOrderBy;
            var data = LoadToDataTable(sql);

            return data;
        }

        private DataTable GetReceiptBills(string maCodeKhachHang, string batDau, string ketThuc)
        {
            var sqlSelect = @"
SELECT kh.MAKHACHHANG,
    kh.TENKHACHHANG, 
    mh.MAMATHANG, 
    mh.TENMATHANG, 
    ISNULL(SUM(ct.SOLUONGLE), 0) AS SOLUONGBAN, 
    SUM(isnull(ct.THANHTIENSAUCHIETKHAU_CT, 0)) AS TongTienBan,
    kh.CODEKHACHHANG 
FROM HOADONXUATKHOCHITIET AS ct, HOADONXUATKHO AS hd, MATHANG AS mh, KHACHHANG AS kh
WHERE ct.MAHOADON = hd.MAHOADONXUAT AND mh.MAMATHANG = ct.MAMATHANG AND kh.MAKHACHHANG = hd.MAKHACHHANG";

            var groupAndOrder = @"
GROUP BY mh.MAMATHANG,mh.TENMATHANG,mh.SOLUONGQUYDOI, kh.MAKHACHHANG, kh.TENKHACHHANG,kh.CODEKHACHHANG 
ORDER BY kh.MAKHACHHANG,kh.CODEKHACHHANG, kh.TENKHACHHANG, mh.MAMATHANG, mh.TENMATHANG";

            if (!string.IsNullOrWhiteSpace(maCodeKhachHang))
                sqlSelect += $" AND kh.CODEKHACHHANG = N'{maCodeKhachHang}' ";

            if (!string.IsNullOrWhiteSpace(batDau))
                sqlSelect += $" AND hd.NGAYTAOHOADON >= '{batDau}' ";

            if (!string.IsNullOrWhiteSpace(ketThuc))
                sqlSelect += $" AND hd.NGAYTAOHOADON <= '{ketThuc}' ";

            var sql = sqlSelect + groupAndOrder;
            var data = LoadToDataTable(sql);
            return data;
        }

        public DataTable Cmd_GetReceiptBills_ByKhachHang(string maKhachHang, string batDau, string ketThuc)
        {
            var data = GetReceiptBills(maKhachHang, batDau, ketThuc);
            return data;
        }

        public DataTable Cmd_GetReceiptBills_ByKhachHang(string soLuongHdLoad, string maKhachHang, string batDau,
            string ketThuc, bool groupbyKhachHang)
        {
            var data = GetReceiptBills(soLuongHdLoad, "", maKhachHang, batDau, ketThuc, true, false, groupbyKhachHang);
            return data;
        }

        public DataTable Cmd_GetPosReceiptBills_ByKhachHang(string soLuongHdLoad, string maKhachHang, string batDau,
            string ketThuc, bool groupbyKhachHang)
        {
            var data = GetReceiptBills(soLuongHdLoad, "", maKhachHang, batDau, ketThuc, true, false, true);
            return data;
        }

        public DataTable Cmd_GetReceiptBills_ByNhaVien(string soLuongHdLoad, string maNhanVien, string maCa,
            string batDau, string ketThuc, bool groupbyKhachHang)
        {
            var data = GetReceiptBills(soLuongHdLoad, maNhanVien, "", batDau, ketThuc, true, false, groupbyKhachHang);
            return data;
        }

        public DataTable Cmd_GetPosReceiptBills_ByNhaVien(string soLuongHdLoad, string maNhanVien, string maCa,
            string batDau, string ketThuc, bool groupbyKhachHang)
        {
            var data = GetReceiptBills(soLuongHdLoad, maNhanVien, "", batDau, ketThuc, true, true, groupbyKhachHang);
            return data;
        }

        public decimal Cmd_CalDaThu_DoanhThuKhachHang(DataTable data)
        {
            var sumObj = data.Compute("sum(SOTIENKHACHDUA)", null);
            return (decimal)sumObj;
        }


        public decimal Cmd_CalDaThu_DoanhThu1KhachHang(DataTable data)
        {
            var sumObj = data.Compute("sum(TongTienBan)", null);
            return (decimal)sumObj;
        }

        public decimal Cmd_CalConLai_DoanhThuKhachHang(DataTable data)
        {
            var sumObj = data.Compute("sum(CONLAI)", null);
            return (decimal)sumObj;
        }

        public decimal Cmd_calGiamGia_DoanhThuKhachHang(DataTable data)
        {
            var sumObj = data.Compute("sum(GIAMGIA)", null);
            return (decimal)sumObj;
        }

        public decimal Cmd_calTongTienHoaDon_DoanhThuKhachHang(DataTable data)
        {
            var sumObj = data.Compute("sum(TIENHOADON)", null);
            return (decimal)sumObj;
        }

        //Get Top doannh thu
        private DataTable GetTopProfit(string soLuongHdLoad,
            string batDau, string ketThuc, bool isBanLe)
        {
            var sql = "Select DISTINCT " + soLuongHdLoad +
                      " kh.MAKHACHHANG,kh.MABARCODE,kh.TENKHACHHANG,kh.DIENTHOAI,kh.DIDONG,kh.DIACHI, SUM(pt.TIENTHANHTOAN) as DATHU " +
                      "From PHIEUTHU pt,KHACHHANG kh, HOADONXUATKHO hd " +
                      "WHERE pt.MAHOADONXUATKHO = hd.MAHOADONXUAT and hd.MAKHACHHANG = kh.MAKHACHHANG and pt.MAHOADONTHU like 'POS%' and pt.NGAYTHANHTOAN between '" +
                      batDau + "' and '" + ketThuc + "' " +
                      "GROUP BY kh.MAKHACHHANG,kh.MABARCODE,kh.TENKHACHHANG,kh.DIENTHOAI,kh.DIDONG,kh.DIACHI " +
                      "ORDER BY SUM(pt.TIENTHANHTOAN)DESC";

            if (!isBanLe)
            {
                sql = sql.Replace("POS%", "%PT%");
                sql = sql.Replace("/", "-");
            }


            var data = LoadToDataTable(sql);

            return data;
        }

        public DataTable Cmd_GetTopProfit(string soLuongHdLoad,
            string batDau, string ketThuc, bool isBanLe)
        {
            var data = GetTopProfit(soLuongHdLoad, batDau, ketThuc, isBanLe);
            return data;
        }

        #endregion Get Doanh Thu Khach Hang

        #region Get Cong No Khach Hang

        private DataTable GetExportBills(string soLuongHdLoad, string maNhanVien, string maKhachHang, string batDau,
            string ketThuc)
        {
            var sqlSelect =
                $@"
SELECT {soLuongHdLoad} 
    hd.MAHOADONXUAT AS MAHOADONXUAT, 
    hd.NGAYTAOHOADON AS NgayTaoHoaDon, 
    kh.CODEKHACHHANG AS MACODE,
    kh.MABARCODE,
    kh.TENKHACHHANG,
    hd.SOTIENTHANHTOAN_HD AS TONGTIENHOADON, 
    hd.TIENKHUYENMAI_HD AS TIENKHUYENMAI,
    ISNULL(TablePhieuThu.TONGTIENTHU, 0) AS SOTIENKHACHDUA,
    hd.SOTIENTHANHTOAN_HD AS SOTIENTHANHTOAN_HD, 
    ISNULL(TablePhieuThu.TONGTIENTHU, 0) as TONGTIENTHU
FROM NGUOIDUNG AS nd, KHACHHANG AS kh, HOADONXUATKHO AS hd 
LEFT JOIN (
    SELECT SUM(pt.TIENTHANHTOAN) AS TONGTIENTHU, MAHOADONXUATKHO AS MAHOADONXUATKHO 
    FROM PHIEUTHU AS pt 
    GROUP BY MAHOADONXUATKHO ) AS TablePhieuThu ON hd.MAHOADONXUAT = TablePhieuThu.MAHOADONXUATKHO 
WHERE nd.MANGUOIDUNG= hd.NGUOITAO and kh.MAKHACHHANG = HD.MAKHACHHANG";

            if (!string.IsNullOrWhiteSpace(maNhanVien))
                sqlSelect += $@" AND ND.MANGUOIDUNG ='{maNhanVien}' ";

            if (!string.IsNullOrWhiteSpace(maKhachHang))
                sqlSelect += $@" AND HD.MAKHACHHANG ='{maKhachHang}' ";

            if (!string.IsNullOrWhiteSpace(batDau))
                sqlSelect += $@" AND HD.NGAYTAOHOADON >= '{batDau}' ";

            if (!string.IsNullOrWhiteSpace(ketThuc))
                sqlSelect += $@" AND HD.NGAYTAOHOADON <= '{ketThuc}' ";

            var sqlOrderBy = " ORDER BY HD.NGAYTAOHOADON DESC";

            var sql = sqlSelect + sqlOrderBy;
            var data = LoadToDataTable(sql);

            return data;
        }

        public DataTable Cmd_GetExportBills_ByKhachHang(string soLuongHdLoad, string maKhachHang, string batDau,
            string ketThuc, StateBill stateThanhToan)
        {
            var data = GetExportBills(soLuongHdLoad, "", maKhachHang, batDau, ketThuc);
            return data;
        }

        public DataTable Cmd_GetExportBills_ByNhanVien(string soLuongHdLoad, string maNhanVien, string maCa,
            string batDau, string ketThuc, StateBill stateThanhToan)
        {
            var data = GetExportBills(soLuongHdLoad, maNhanVien, "", batDau, ketThuc);
            return data;
        }

        public decimal Cmd_CalConLai_CongNoKhachHang(DataTable data)
        {
            var sumObj1 = data.Compute("SUM(SOTIENTHANHTOAN_HD)", null);
            var sumObj2 = data.Compute("SUM(TONGTIENTHU)", null);
            var sumObj = (decimal)sumObj1 - (decimal)sumObj2;
            return sumObj;
        }

        public decimal Cmd_CalDaThu_CongNoKhachHang(DataTable data)
        {
            var sumObj = data.Compute("sum(DATHU)", null);
            return (decimal)sumObj;
        }

        public decimal Cmd_calGiamGia_CongNoKhachHang(DataTable data)
        {
            var sumObj = data.Compute("sum(GIAMGIA)", null);
            return (decimal)sumObj;
        }

        public decimal Cmd_calTongTienHoaDon_CongNoKhachHang(DataTable data)
        {
            var sumObj = data.Compute("sum(TONGTIEN)", null);
            return (decimal)sumObj;
        }

        #endregion Get Cong No Khach Hang

        #region Get Cong No Nha Cung Cap

        private DataTable GetImportBills(string soLuongHdLoad, string maNhanVien, string maKhachHang, string batDau,
            string ketThuc)
        {
            var sqlSelect = $@"
SELECT {soLuongHdLoad} 
    hd.MAHOADONNHAP AS MAHOADONNHAP, 
    hd.SOTIENTHANHTOAN_HD AS TONGTIENHOADON, 
    hd.CHIETKHAUTHEOTIEN_HD AS TIENCHIETKHAU, 
    isnull(TablePhieuChi.TONGTIENTRA, 0) AS SOTIENTHANHTOAN, 
    (hd.SOTIENTHANHTOAN_HD - isnull(TablePhieuChi.TONGTIENTRA, 0)) AS CONGNO, 
    hd.NGAYTAOHOADON AS NgayTaoHoaDon,
    TinhTrang = CASE when(hd.SOTIENTHANHTOAN_HD - isnull(TablePhieuChi.TONGTIENTRA, 0)) <=0 THEN N'Đã Thanh Toán' ELSE N'Chưa Thanh Toán' END,
    ncc.TENNHACUNGCAP AS TENNHACUNGCAP, 
    ncc.DIENTHOAI AS DIENTHOAI, 
    ncc.DIDONG AS DIDONG
FROM NGUOIDUNG AS nd, NHACUNGCAP AS ncc, HOADONNHAPKHO AS hd 
LEFT JOIN (
    SELECT SUM(pc.TIENTHANHTOAN) as TONGTIENTRA, MAHOADONNHAPKHO as MAHOADONNHAPKHO
    FROM PHIEUCHI pc
    GROUP BY MAHOADONNHAPKHO
    ) as TablePhieuChi on hd.MAHOADONNHAP = TablePhieuChi.MAHOADONNHAPKHO
WHERE nd.MANGUOIDUNG=hd.NGUOITAO and ncc.MANHACUNGCAP = HD.MANHACUNGCAP
            ";

            if (maNhanVien != "")
                sqlSelect += " AND nd.MANGUOIDUNG ='" + maNhanVien + "' ";

            if (maKhachHang != "")
                sqlSelect += " AND HD.MANHACUNGCAP ='" + maKhachHang + "' ";

            if (batDau != "")
                sqlSelect += " AND HD.NGAYTAOHOADON >= '" + batDau + "' ";

            if (ketThuc != "")
                sqlSelect += " AND HD.NGAYTAOHOADON <= '" + ketThuc + "' ";

            const string sqlOrderBy = " ORDER BY HD.NGAYTAOHOADON DESC";

            var sql = sqlSelect + sqlOrderBy;
            var data = LoadToDataTable(sql);

            return data;
        }

        public DataTable Cmd_GetImportBills_ByNCC(string soLuongHdLoad, string maNhaCungCap, string batDau,
            string ketThuc)
        {
            var data = GetImportBills(soLuongHdLoad, "", maNhaCungCap, batDau, ketThuc);
            return data;
        }

        public DataTable Cmd_GetImportBills_ByNhanVien(string soLuongHdLoad, string maNhanVien, string batDau,
            string ketThuc)
        {
            var data = GetImportBills(soLuongHdLoad, maNhanVien, "", batDau, ketThuc);
            return data;
        }

        public decimal Cmd_CalConLai_CongNoNhaCungCap(DataTable data)
        {
            var sumObj = data.Compute("sum(CONGNO)", null);
            return (decimal)sumObj;
        }

        public decimal Cmd_CalDaChi_CongNoNhaCungCap(DataTable data)
        {
            var sumObj = data.Compute("sum(DATRA)", null);
            return (decimal)sumObj;
        }

        public decimal Cmd_calGiamGia_CongNoNhaCungCap(DataTable data)
        {
            var sumObj = data.Compute("sum(GIAMGIA)", null);
            return (decimal)sumObj;
        }

        public decimal Cmd_calTongTienHoaDon_CongNoNhaCungCap(DataTable data)
        {
            var sumObj = data.Compute("sum(TONGTIEN)", null);
            return (decimal)sumObj;
        }

        #endregion Get Cong No Nha Cung Cap

        #region Get Thanh Toán Nha Cung Cap

        private DataTable GetPaymentBills(string soLuongHdLoad, string maNhanVien, string maNhaCungCap, string batDau,
            string ketThuc)
        {
            var sqlSelect = "SELECT " + soLuongHdLoad +
                            " NC.MANHACUNGCAP, NC.TENNHACUNGCAP,NC.DIACHI,NC.DIENTHOAI, hd.MAHOADONNHAP as MAHOADONNHAP, hd.SOTIENTHANHTOAN_HD as TONGTIENHOADON, isnull(TablePhieuChi.TONGTIENTRA, 0) as SOTIENTHANHTOAN, (hd.SOTIENTHANHTOAN_HD - isnull(TablePhieuChi.TONGTIENTRA, 0)) as CONGNO, hd.NGAYTAOHOADON as NgayTaoHoaDon, " +
                            "\"TinhTrang\" =" +
                            "CASE " +
                            "WHEN(hd.SOTIENTHANHTOAN_HD - isnull(TablePhieuChi.TONGTIENTRA, 0)) <= 0 THEN N'Đã Thanh Toán' " +
                            "ELSE N'Chưa Thanh Toán' " +
                            "END ";
            var sqlFrom = "FROM NHACUNGCAP NC, NGUOIDUNG nd, HOADONNHAPKHO hd left join " +
                          "(select SUM(pc.TIENTHANHTOAN) as TONGTIENTRA, MAHOADONNHAPKHO as MAHOADONNHAPKHO " +
                          "from PHIEUCHI pc " +
                          "group by MAHOADONNHAPKHO) as TablePhieuChi on hd.MAHOADONNHAP = TablePhieuChi.MAHOADONNHAPKHO ";
            var sqlWhere = "WHERE hd.MANHACUNGCAP=NC.MANHACUNGCAP and nd.MANGUOIDUNG=hd.NGUOITAO ";


            if (maNhanVien != "")
                sqlWhere += " AND ND.MANGUOIDUNG ='" + maNhanVien + "' ";

            if (maNhaCungCap != "")
                sqlWhere += " AND HD.MANHACUNGCAP ='" + maNhaCungCap + "' ";

            if (batDau != "")
                sqlWhere += " AND HD.NGAYTAOHOADON >= '" + batDau + "' ";

            if (ketThuc != "")
                sqlWhere += " AND HD.NGAYTAOHOADON <= '" + ketThuc + "' ";

            var sqlOrderBy = " ORDER BY HD.NGAYTAOHOADON DESC";

            var sql = sqlSelect + sqlFrom + sqlWhere + sqlOrderBy;
            var data = LoadToDataTable(sql);

            return data;
        }

        public DataTable Cmd_GetPaymentBills_ByNCC(string soLuongHdLoad, string maNcc, string batDau,
            string ketThuc)
        {
            var data = GetPaymentBills(soLuongHdLoad, "", maNcc, batDau, ketThuc);
            return data;
        }

        public DataTable Cmd_GetPaymentBills_ByNhaVien(string soLuongHdLoad, string maNhanVien, string maCa,
            string batDau, string ketThuc)
        {
            var data = GetPaymentBills(soLuongHdLoad, maNhanVien, "", batDau, ketThuc);
            return data;
        }

        public decimal Cmd_CalConLai_DoanhThuNhaCungCap(DataTable data)
        {
            var sumObj = data.Compute("sum(CONNO)", null);
            return (decimal)sumObj;
        }

        public decimal Cmd_CalDaChi_DoanhThuNhaCungCap(DataTable data)
        {
            var sumObj = data.Compute("sum(SOTIENTHANHTOAN)", null);
            return (decimal)sumObj;
        }

        public decimal Cmd_calGiamGia_DoanhThuNhaCungCap(DataTable data)
        {
            var sumObj = data.Compute("sum(GIAMGIA)", null);
            return (decimal)sumObj;
        }

        public decimal Cmd_calTongTienHoaDon_DoanhThuNhaCungCap(DataTable data)
        {
            var sumObj = data.Compute("sum(TIENHOADON)", null);
            return (decimal)sumObj;
        }

        #endregion Get Doanh Thu Nha Cung Cap

        #region Get Chi Tiet Hoa Don Khach Hang

        private DataTable GetExportBillDetails(string soLuongHdLoad, string maNhanVien, string maKhachHang,
            string batDau, string ketThuc, StateBill state, bool isOrderByNgayThanhToan)
        {
            var sqlSelect = "SELECT " + soLuongHdLoad +
                            " kv.TEN as KHUVUC, kh.MABARCODE, kh.CODEKHACHHANG as MACODE, kh.TENKHACHHANG , hd.MAHOADONXUAT as MAHOADON, l.TENLOAIMATHANG , mh.MACODE , mh.TENMATHANG , ct.SOLUONGSI, ct.SOLUONGLE,(ct.SOLUONGLE) as SLTONG,ct.DONGIASI as DONGIA,ct.THANHTIENSAUCHIETKHAU_CT as THANHTIEN,hd.NGAYTAOHOADON,pt.NGAYTHANHTOAN,nd.TENNGUOIDUNG"
                            +
                            " FROM KHACHHANG kh, LOAIMATHANG l, MATHANG mh, HOADONXUATKHO hd, HOADONXUATKHOCHITIET ct, PHIEUTHU pt , KHACHHANGKHUVUC kv, NGUOIDUNG nd";

            var sqlWhere =
                " kh.MAKHACHHANG = hd.MAKHACHHANG and hd.MAHOADONXUAT = ct.MAHOADON and ct.MAMATHANG = mh.MAMATHANG and mh.MALOAIMATHANG = l.MALOAIMATHANG  and pt.MAHOADONXUATKHO = hd.MAHOADONXUAT and kh.MAKHUVUC = kv.MAKHUVUC and nd.MANGUOIDUNG = hd.NGUOITAO ";
            // ReSharper disable once InconsistentNaming
            var _state = state;
            switch (_state)
            {
                case StateBill.ChuaThanhToan:
                    sqlWhere += " AND HD.DATHANHTOAN = 0 ";
                    break;

                case StateBill.DaThanhToan:
                    sqlWhere += " AND HD.DATHANHTOAN = 1 ";
                    break;

                case StateBill.None:
                    break;

                default:
                    Debug.Assert(false);
                    break;
            }

            if (maNhanVien != "")
                sqlWhere += " AND HD.NGUOITAO ='" + maNhanVien + "' ";

            if (maKhachHang != "")
                sqlWhere += " AND HD.MAKHACHHANG ='" + maKhachHang + "' ";

            if (batDau != "")
                sqlWhere += " AND HD.NGAYTAOHOADON >= '" + batDau + "' ";

            if (ketThuc != "")
                sqlWhere += " AND HD.NGAYTAOHOADON <= '" + ketThuc + "' ";

            const string sqlGroupBy =
                " GROUP BY hd.MAHOADONXUAT,kv.TEN, kh.MABARCODE,kh.CODEKHACHHANG, kh.TENKHACHHANG, hd.MAHOADONXUAT, l.TENLOAIMATHANG, mh.MACODE, mh.TENMATHANG, ct.SOLUONGSI, ct.SOLUONGLE, pt.NGAYTHANHTOAN ,ct.DONGIASI, hd.NGAYTAOHOADON, ct.THANHTIENSAUCHIETKHAU_CT, mh.SOLUONGQUYDOI,nd.TENNGUOIDUNG";

            var sqlOrderBy = " ORDER BY HD.NGAYTAOHOADON DESC";
            if (isOrderByNgayThanhToan)
                sqlOrderBy = " ORDER BY PT.NGAYTHANHTOAN DESC";

            var sql = sqlSelect + sqlWhere + sqlGroupBy + sqlOrderBy;
            var data = LoadToDataTable(sql);

            return data;
        }

        public DataTable Cmd_GetExportBillDetails_ByKhachHang(string soLuongHdLoad, string maKhachHang, string batDau,
            string ketThuc, StateBill stateThanhToan)
        {
            var data = GetExportBillDetails(soLuongHdLoad, "", maKhachHang, batDau, ketThuc, stateThanhToan, false);
            return data;
        }

        public DataTable Cmd_GetExportBillDetails_ByNhanVien(string soLuongHdLoad, string maNhanVien, string batDau,
            string ketThuc, StateBill stateThanhToan)
        {
            var data = GetExportBillDetails(soLuongHdLoad, maNhanVien, "", batDau, ketThuc, stateThanhToan, false);
            return data;
        }

        #endregion Get Chi Tiet Hoa Don Khach Hang

        #region Get Chi Tiet Hoa Don Nha Cung Cap

        private DataTable GetImportBillDetails(string soLuongHdLoad, string maNhanVien, string maNhaCungCap,
            string batDau, string ketThuc, StateBill state, bool isOrderByNgayThanhToan)
        {
            var sqlSelect = "SELECT " + soLuongHdLoad +
                            " kh.TENNHACUNGCAP , hd.MAHOADONNHAP as MAHOADON, l.TENLOAIMATHANG , mh.MACODE , mh.TENMATHANG , ct.SOLUONGSI, ct.SOLUONGLE,(ct.SOLUONGLE) as SLTONG,ct.DONGIA ,ct.THANHTIENSAUCHIETKHAU_CT as THANHTIEN,hd.NGAYTAOHOADON,pt.NGAYTHANHTOAN,nd.TENNGUOIDUNG"
                            +
                            " FROM NHACUNGCAP kh, LOAIMATHANG l, MATHANG mh, HOADONNHAPKHO hd, HOADONHAPKHOCHITIET ct, PHIEUCHI pt , NGUOIDUNG nd";

            var sqlWhere =
                " kh.MANHACUNGCAP = hd.MANHACUNGCAP and hd.MAHOADONNHAP = ct.MAHOADON and ct.MAMATHANG = mh.MAMATHANG and mh.MALOAIMATHANG = l.MALOAIMATHANG  and pt.MAHOADONNHAPKHO = hd.MAHOADONNHAP and nd.MANGUOIDUNG = hd.NGUOITAO ";
            // ReSharper disable once InconsistentNaming
            var _state = state;
            switch (_state)
            {
                case StateBill.ChuaThanhToan:
                    sqlWhere += " AND HD.DATHANHTOAN = 0 ";
                    break;

                case StateBill.DaThanhToan:
                    sqlWhere += " AND HD.DATHANHTOAN = 1 ";
                    break;

                case StateBill.None:
                    break;

                default:
                    Debug.Assert(false);
                    break;
            }

            if (maNhanVien != "")
                sqlWhere += " AND HD.NGUOITAO ='" + maNhanVien + "' ";

            if (maNhaCungCap != "")
                sqlWhere += " AND HD.MAKHACHHANG ='" + maNhaCungCap + "' ";

            if (batDau != "")
                sqlWhere += " AND HD.NGAYTAOHOADON >= '" + batDau + "' ";

            if (ketThuc != "")
                sqlWhere += " AND HD.NGAYTAOHOADON <= '" + ketThuc + "' ";

            const string sqlGroupBy =
                " GROUP BY hd.MAHOADONNHAP, kh.TENNHACUNGCAP, hd.MAHOADONNHAP, l.TENLOAIMATHANG, mh.MACODE, mh.TENMATHANG, ct.SOLUONGSI, ct.SOLUONGLE, pt.NGAYTHANHTOAN ,ct.DONGIASI, hd.NGAYTAOHOADON, ct.THANHTIENSAUCHIETKHAU_CT, mh.SOLUONGQUYDOI,nd.TENNGUOIDUNG";

            var sqlOrderBy = " ORDER BY HD.NGAYTAOHOADON DESC";
            if (isOrderByNgayThanhToan)
                sqlOrderBy = " ORDER BY PT.NGAYTHANHTOAN DESC";

            var sql = sqlSelect + sqlWhere + sqlGroupBy + sqlOrderBy;
            var data = LoadToDataTable(sql);

            return data;
        }

        public DataTable Cmd_GetImportBillDetails_ByKhachHang(string soLuongHdLoad, string maNhaCungCap, string batDau,
            string ketThuc, StateBill stateThanhToan)
        {
            var data = GetImportBillDetails(soLuongHdLoad, "", maNhaCungCap, batDau, ketThuc, stateThanhToan,
                false);
            return data;
        }

        public DataTable Cmd_GetImportBillDetails_ByNhanVien(string soLuongHdLoad, string maNhanVien, string batDau,
            string ketThuc, StateBill stateThanhToan)
        {
            var data = GetImportBillDetails(soLuongHdLoad, maNhanVien, "", batDau, ketThuc, stateThanhToan, false);
            return data;
        }

        #endregion Get Chi Tiet Hoa Don Nha Cung Cap

        #region Get Mat Hang & Khach Hang

        /*
        private DataTable GetCustomers(string maKhuVuc, string maKhachHang)
        {
            DataTable Data = null;
            string SqlSelect = " Select kv.TEN as KHUVUC, kh.MABARCODE,kh.CODEKHACHHANG,kh.TENKHACHHANG,kh.DIACHI,kh.DIENTHOAI,kh.CONGTY,kh.GHICHU , kh.CHECKKHUYENMAI "
                               + " From KHACHHANG kh, KHACHHANGKHUVUC kv ";
            string SqlWhere = " Where kh.MAKHUVUC = kv.MAKHUVUC";

            if (maKhuVuc != "")
                SqlWhere += " and kv.MAKHUVUC = '" + maKhuVuc + "'";

            if (maKhachHang != "")
                SqlWhere += " and kh.MAKHACHHANG = '" + maKhachHang + "'";

            string SqlOrderBy = " ORDER BY kv.TEN";

            string Sql = SqlSelect + SqlWhere + SqlOrderBy;
            Data = LoadToDataTable(Sql);

            return Data;
        }
*/

        #endregion Get Mat Hang & Khach Hang

        #region Get So Luong Nhap Xuat

        /*
        private DataTable GetNumberExportImport(string maLoai, string maNhanVien, string maKhachHang, string batDau,
            string ketThuc, StateBill state, bool isOrderByNgayThanhToan)
        {
            DataTable Data = null;
            string SqlSelect = "SELECT HD.MAHOADONXUAT,HD.TIENCHIETKHAU_HD AS GIAMGIA,HD.THANHTIENCHUACK_HD AS TONGTIEN, HD.SOTIENKHACHDUA_HD AS DATHU, HD.SOTIENTHANHTOAN_HD AS CONLAI, KV.TEN AS KHUVUC, KH.TENKHACHHANG,KH.CONGTY AS TENSHOP,KH.DIENTHOAI,KH.DIACHI,KH.CODEKHACHHANG,KH.MABARCODE, HD.NGAYTAOHOADON, PT.NGAYTHANHTOAN"
                               +
                               " FROM HOADONXUATKHO HD,HOADONXUATKHOCHITIET CT,KHACHHANG KH, PHIEUTHU PT,KHACHHANGKHUVUC KV ";

            string SqlWhere =
                " WHERE HD.MAHOADONXUAT = CT.MAHOADON AND HD.MAHOADONXUAT = PT.MAHOADONXUATKHO AND HD.MAKHACHHANG = KH.MAKHACHHANG AND KH.MAKHUVUC = KV.MAKHUVUC";
            StateBill _state = state;
            switch (_state)
            {
                case StateBill.ChuaThanhToan:
                    SqlWhere += " AND HD.DATHANHTOAN = 0 ";
                    break;

                case StateBill.DaThanhToan:
                    SqlWhere += " AND HD.DATHANHTOAN = 1 ";
                    break;

                case StateBill.None:
                    break;

                default:
                    break;
            }

            if (maNhanVien != "")
                SqlWhere += " AND HD.NGUOITAO ='" + maNhanVien + "' ";

            if (maKhachHang != "")
                SqlWhere += " AND HD.MAKHACHHANG ='" + maKhachHang + "' ";

            if (batDau != "")
                SqlWhere += " AND HD.NGAYTAOHOADON >= '" + batDau + "' ";

            if (ketThuc != "")
                SqlWhere += " AND HD.NGAYTAOHOADON <= '" + ketThuc + "' ";

            string SqlGroupBy =
                " GROUP BY HD.MAHOADONXUAT,HD.THANHTIENCHUACK_HD,HD.SOTIENTHANHTOAN_HD,HD.TIENCHIETKHAU_HD,HD.NGAYTAOHOADON, HD.SOTIENKHACHDUA_HD, KV.TEN, KH.TENKHACHHANG,KH.DIACHI,KH.CONGTY,KH.DIENTHOAI,KH.CODEKHACHHANG,KH.MABARCODE,HD.NGAYTAOHOADON,PT.NGAYTHANHTOAN";

            string SqlOrderBy = " ORDER BY HD.NGAYTAOHOADON DESC";
            if (isOrderByNgayThanhToan)
                SqlOrderBy = " ORDER BY PT.NGAYTHANHTOAN DESC";

            string Sql = SqlSelect + SqlWhere + SqlGroupBy + SqlOrderBy;
            Data = LoadToDataTable(Sql);

            return Data;
        }
*/

        #endregion Get So Luong Nhap Xuat

        #region Get Chi Tiet Ban Si

        private DataTable GetExportDetails(string soLuongHdLoad, string maNhanVien, string maKhachHang,
            string batDau, string ketThuc, string ngayHienTai, string banLe)
        {
            const string selectTablet =
                " declare @starttime datetime " +
                " declare @endtime datetime " +
                " declare @daytime datetime " +
                " declare @startdaytime datetime " +
                " declare @enddaytime datetime" +
                " declare @khachhang nvarchar(100)" +
                " declare @nhanvien varchar(20)";

            var selectdeclare = " select @starttime = '" + batDau + "' " +
                                " select @endtime = '" + ketThuc + "' " +
                                " select @daytime = '" + ngayHienTai + "'" +
                                " select @starttime = CAST(CONVERT(VARCHAR(10), @starttime, 110) + ' 00:00:00' AS DATETIME) " +
                                " select @endtime = CAST(CONVERT(VARCHAR(10), @endtime, 110) + ' 23:59:59' AS DATETIME) " +
                                " select @khachhang = '" + maKhachHang + "'" +
                                " select @nhanvien = '" + maNhanVien + "'";

            var sql = "select ROW_NUMBER() OVER (ORDER BY mh.MAMATHANG) AS Stt, ";

            //string sqlinserttableByKhachHang = sql + " mh.MAMATHANG,mh.TENMATHANG,mh.SOLUONGQUYDOI as QUYCACH, isnull(SUM(isnull(ct.SOLUONGSI, 0) * mh.SOLUONGQUYDOI + ct.SOLUONGLE), 0) as SOLUONGBAN, SUM(isnull(ct.THANHTIENSAUCHIETKHAU_CT, 0)) as TongTienBan " +
            //                                    "from HOADONXUATKHOCHITIET ct, HOADONXUATKHO hd, MATHANG mh " +
            //                                    "where ct.MAHOADON = hd.MAHOADONXUAT and mh.MAMATHANG = ct.MAMATHANG and hd.NGAYTAOHOADON between @starttime and @endtime and ct.MAHOADON like '" + banLe + "%' and hd.MAKHACHHANG = @khachhang" +
            //                                    "GROUP BY mh.MAMATHANG,mh.TENMATHANG,mh.SOLUONGQUYDOI " +
            //                                    "order by mh.MAMATHANG,mh.TENMATHANG ";

            var sqlinserttableByKhachHang =
                sql +
                " mh.MAMATHANG,mh.TENMATHANG,mh.SOLUONGQUYDOI as QUYCACH, isnull(ct.SOLUONGLE), 0) as SOLUONGBAN, SUM(isnull(ct.THANHTIENSAUCHIETKHAU_CT, 0)) as TongTienBan " +
                "from HOADONXUATKHOCHITIET ct, HOADONXUATKHO hd, MATHANG mh " +
                "where ct.MAHOADON = hd.MAHOADONXUAT and mh.MAMATHANG = ct.MAMATHANG and hd.NGAYTAOHOADON between @starttime and @endtime and ct.MAHOADON like '" +
                banLe + "%' and hd.MAKHACHHANG = @khachhang" +
                "GROUP BY mh.MAMATHANG,mh.TENMATHANG,mh.SOLUONGQUYDOI " +
                "order by mh.MAMATHANG,mh.TENMATHANG ";

            var sqlinserttableByNhanVien =
                sql +
                " mh.MAMATHANG,mh.TENMATHANG,mh.SOLUONGQUYDOI as QUYCACH, isnull(SUM(isnull(ct.SOLUONGLE), 0) as SOLUONGBAN, SUM(isnull(ct.THANHTIENSAUCHIETKHAU_CT, 0)) as TongTienBan " +
                "from HOADONXUATKHOCHITIET ct, HOADONXUATKHO hd, MATHANG mh " +
                "where ct.MAHOADON = hd.MAHOADONXUAT and mh.MAMATHANG = ct.MAMATHANG and hd.NGAYTAOHOADON between @starttime and @endtime and ct.MAHOADON like '" +
                banLe + "%' " + //"and hd.MAKHACHHANG = @khachhang" +
                " and hd.NGUOITAO=@nhanvien " +
                "GROUP BY mh.MAMATHANG,mh.TENMATHANG,mh.SOLUONGQUYDOI " +
                "order by mh.MAMATHANG,mh.TENMATHANG ";

            var sqlinserttableByNhanVienAndByKhachHang =
                sql +
                " mh.MAMATHANG,mh.TENMATHANG,mh.SOLUONGQUYDOI as QUYCACH, isnull(SUM(ct.SOLUONGLE), 0) as SOLUONGBAN, SUM(isnull(ct.THANHTIENSAUCHIETKHAU_CT, 0)) as TongTienBan " +
                "from HOADONXUATKHOCHITIET ct, HOADONXUATKHO hd, MATHANG mh " +
                "where ct.MAHOADON = hd.MAHOADONXUAT and mh.MAMATHANG = ct.MAMATHANG and hd.NGAYTAOHOADON between @starttime and @endtime and ct.MAHOADON like '" +
                banLe + "%' " + "and hd.MAKHACHHANG = @khachhang" +
                " and hd.NGUOITAO=@nhanvien " +
                "GROUP BY mh.MAMATHANG,mh.TENMATHANG,mh.SOLUONGQUYDOI " +
                "order by mh.MAMATHANG,mh.TENMATHANG ";

            //string sqlinserttableTatCa = sql + " mh.MAMATHANG,mh.TENMATHANG,mh.SOLUONGQUYDOI as QUYCACH, isnull(SUM(isnull(ct.SOLUONGSI, 0) * mh.SOLUONGQUYDOI + ct.SOLUONGLE), 0) as SOLUONGBAN, SUM(isnull(ct.THANHTIENSAUCHIETKHAU_CT, 0)) as TongTienBan " +
            //                             "from HOADONXUATKHOCHITIET ct, HOADONXUATKHO hd, MATHANG mh " +
            //                             "where ct.MAHOADON = hd.MAHOADONXUAT and mh.MAMATHANG = ct.MAMATHANG and hd.NGAYTAOHOADON between @starttime and @endtime and ct.MAHOADON like '" + banLe + "%'" +
            //                             "GROUP BY mh.MAMATHANG,mh.TENMATHANG,mh.SOLUONGQUYDOI " +
            //                             "order by mh.MAMATHANG,mh.TENMATHANG ";

            var sqlinserttableTatCa =
                sql +
                " mh.MAMATHANG,mh.TENMATHANG,mh.SOLUONGQUYDOI as QUYCACH, isnull(SUM(ct.SOLUONGLE), 0) as SOLUONGBAN, SUM(isnull(ct.THANHTIENSAUCHIETKHAU_CT, 0)) as TongTienBan " +
                "from HOADONXUATKHOCHITIET ct, HOADONXUATKHO hd, MATHANG mh " +
                "where ct.MAHOADON = hd.MAHOADONXUAT and mh.MAMATHANG = ct.MAMATHANG and hd.NGAYTAOHOADON between @starttime and @endtime and ct.MAHOADON like '" +
                banLe + "%'" +
                "GROUP BY mh.MAMATHANG,mh.TENMATHANG,mh.SOLUONGQUYDOI " +
                "order by mh.MAMATHANG,mh.TENMATHANG ";


            var sqlSelect = sql + soLuongHdLoad +
                            " mh.MAMATHANG,mh.TENMATHANG,mh.SOLUONGQUYDOI as QUYCACH, isnull(SUM(ct.SOLUONGLE), 0) as SOLUONGBAN, SUM(isnull(ct.THANHTIENSAUCHIETKHAU_CT, 0)) as TongTienBan " +
                            "from HOADONXUATKHOCHITIET ct, HOADONXUATKHO hd, MATHANG mh " +
                            "where ct.MAHOADON = hd.MAHOADONXUAT and mh.MAMATHANG = ct.MAMATHANG and hd.NGAYTAOHOADON between @starttime and @endtime and ct.MAHOADON like '" +
                            banLe + "%'" +
                            "GROUP BY mh.MAMATHANG,mh.TENMATHANG,mh.SOLUONGQUYDOI " +
                            "order by mh.MAMATHANG,mh.TENMATHANG ";

            var sqlFinal = selectTablet + selectdeclare;
            if (maKhachHang == "" && maNhanVien == "")
                sqlFinal += sqlinserttableTatCa;
            else if (maKhachHang == "" && maNhanVien != "")
                sqlFinal += sqlinserttableByNhanVien;
            else if (maKhachHang != "" && maNhanVien == "")
                sqlFinal += sqlinserttableByKhachHang;
            else if (maKhachHang != "" && maNhanVien != "")
                sqlFinal += sqlinserttableByNhanVienAndByKhachHang;
            // sqlFinal += sqlSelect;

            var data = LoadToDataTable(sqlFinal);

            return data;
        }

        public DataTable Cmd_GetExportDetails(string soLuongHdLoad, string maNhanVien, string maKhachHang,
            string batDau, string ketThuc, string ngayHienTai)
        {
            return GetExportDetails(soLuongHdLoad, maNhanVien, maKhachHang, batDau, ketThuc, ngayHienTai, "BH");
        }

        public DataTable Cmd_GetPosExportDetails(string soLuongHdLoad, string maNhanVien, string maKhachHang,
            string batDau, string ketThuc, string ngayHienTai)
        {
            return GetExportDetails(soLuongHdLoad, maNhanVien, maKhachHang, batDau, ketThuc, ngayHienTai, "CT");
        }

        #endregion Get Chi Tiet Ban Si

        #region GetAll ChiTietHoaDon

        public DataTable Cmd_GetBillDetail(string MaHoaDon, string IDPOS)
        {
            return GetBillDetail(MaHoaDon, IDPOS);
        }

        private DataTable GetBillDetail(string MaHoaDon, string IDPOS)
        {
            var DS_ChiTiet = new DataTable();
            var SQL =
                " select distinct ROW_NUMBER() OVER (ORDER BY sp.TENMATHANG) as STT, cthd.MAMATHANG , sp.TENMATHANG, SUM(cthd.SOLUONGLE) as SOLUONG, cthd.DONGIASI AS DONGIA, SUM(cthd.THANHTIENTRUOCCHIETKHAU_CT) as THANHTIEN"
                + " from HOADONXUATKHOCHITIET cthd ,MATHANG sp"
                + " where cthd.MAHOADON='" + MaHoaDon + "' and sp.MAMATHANG = cthd.MAMATHANG"
                + " and cthd.GHICHU='" + IDPOS + "'"
                + " group by cthd.MAMATHANG, sp.TENMATHANG, cthd.DONGIASI ORDER BY STT";
            DS_ChiTiet = LoadDataTable(SQL);
            return DS_ChiTiet;
        }

        #endregion

        #region Get Chi Tiet Mua

        private DataTable GetImportDetails(string soLuongHdLoad, string maNhanVien, string maKhachHang, string batDau,
            string ketThuc, string ngayHienTai, string banLe)
        {
            const string selectTablet =
                " declare @starttime datetime " +
                " declare @endtime datetime " +
                " declare @daytime datetime " +
                " declare @startdaytime datetime " +
                " declare @enddaytime datetime" +
                " declare @nhacungcap nvarchar(100)" +
                " declare @nhanvien varchar(20)";

            var selectdeclare = " select @starttime = '" + batDau + "' " +
                                " select @endtime = '" + ketThuc + "' " +
                                " select @daytime = '" + ngayHienTai + "'" +
                                " select @starttime = CAST(CONVERT(VARCHAR(10), @starttime, 110) + ' 00:00:00' AS DATETIME) " +
                                " select @endtime = CAST(CONVERT(VARCHAR(10), @endtime, 110) + ' 23:59:59' AS DATETIME) " +
                                " select @nhacungcap = '" + maKhachHang + "'" +
                                " select @nhanvien = '" + maNhanVien + "'";

            //string sqlinserttableByKhachHang = " select mh.MAMATHANG,mh.TENMATHANG,mh.SOLUONGQUYDOI as QUYCACH,isnull(SUM(isnull(ct.SOLUONGSI,0)*mh.SOLUONGQUYDOI+ct.SOLUONGLE), 0)  as SOLUONGMUA, SUM(isnull(ct.THANHTIENSAUCHIETKHAU_CT, 0)) as TongTienMua " +
            //                                   " from HOADONHAPKHOCHITIET ct, HOADONNHAPKHO hd, MATHANG mh " +
            //                                   " where ct.MAHOADON = hd.MAHOADONNHAP and mh.MAMATHANG = ct.MAMATHANG and hd.NGAYTAOHOADON between @starttime and @endtime and ct.MAHOADON like '" + banLe + "%' " +
            //                                   " and hd.MANHACUNGCAP=@nhacungcap " +
            //                                   " GROUP BY mh.MAMATHANG,mh.TENMATHANG,mh.SOLUONGQUYDOI " +
            //                                   "order by mh.MAMATHANG,mh.TENMATHANG";

            var sqlinserttableByKhachHang =
                " select ROW_NUMBER() OVER (ORDER BY mh.MAMATHANG) AS Stt, mh.MAMATHANG,mh.TENMATHANG,mh.SOLUONGQUYDOI as QUYCACH,isnull(SUM(ct.SOLUONGLE), 0)  as SOLUONGMUA, SUM(isnull(ct.THANHTIENSAUCHIETKHAU_CT, 0)) as TongTienMua " +
                " from HOADONHAPKHOCHITIET ct, HOADONNHAPKHO hd, MATHANG mh " +
                " where ct.MAHOADON = hd.MAHOADONNHAP and mh.MAMATHANG = ct.MAMATHANG and hd.NGAYTAOHOADON between @starttime and @endtime and ct.MAHOADON like '" +
                banLe + "%' " +
                " and hd.MANHACUNGCAP=@nhacungcap " +
                " GROUP BY mh.MAMATHANG,mh.TENMATHANG,mh.SOLUONGQUYDOI " +
                "order by mh.MAMATHANG,mh.TENMATHANG";

            var sqlinserttableByNhanVien =
                " select ROW_NUMBER() OVER (ORDER BY mh.MAMATHANG) AS Stt, mh.MAMATHANG,mh.TENMATHANG,mh.SOLUONGQUYDOI as QUYCACH,isnull(SUM(ct.SOLUONGLE), 0)  as SOLUONGMUA, SUM(isnull(ct.THANHTIENSAUCHIETKHAU_CT, 0)) as TongTienMua " +
                " from HOADONHAPKHOCHITIET ct, HOADONNHAPKHO hd, MATHANG mh " +
                " where ct.MAHOADON = hd.MAHOADONNHAP and mh.MAMATHANG = ct.MAMATHANG and hd.NGAYTAOHOADON between @starttime and @endtime and ct.MAHOADON like '" +
                banLe + "%' " +
                " and hd.NGUOITAO=@nhanvien " +
                " GROUP BY mh.MAMATHANG,mh.TENMATHANG,mh.SOLUONGQUYDOI " +
                "order by mh.MAMATHANG,mh.TENMATHANG";

            var sqlinserttableByNhanVienAndByKhachHang =
                " select ROW_NUMBER() OVER (ORDER BY mh.MAMATHANG) AS Stt, mh.MAMATHANG,mh.TENMATHANG,mh.SOLUONGQUYDOI as QUYCACH,isnull(SUM(ct.SOLUONGLE), 0)  as SOLUONGMUA, SUM(isnull(ct.THANHTIENSAUCHIETKHAU_CT, 0)) as TongTienMua " +
                " from HOADONHAPKHOCHITIET ct, HOADONNHAPKHO hd, MATHANG mh " +
                " where ct.MAHOADON = hd.MAHOADONNHAP and mh.MAMATHANG = ct.MAMATHANG and hd.NGAYTAOHOADON between @starttime and @endtime and ct.MAHOADON like '" +
                banLe + "%' " +
                " and hd.NGUOITAO=@nhanvien " +
                " and hd.MANHACUNGCAP=@nhacungcap " +
                " GROUP BY mh.MAMATHANG,mh.TENMATHANG,mh.SOLUONGQUYDOI " +
                "order by mh.MAMATHANG,mh.TENMATHANG";

            //string sqlinserttableTatCa = " select mh.MAMATHANG,mh.TENMATHANG,mh.SOLUONGQUYDOI as QUYCACH,isnull(SUM(isnull(ct.SOLUONGSI,0)*mh.SOLUONGQUYDOI+ct.SOLUONGLE), 0)  as SOLUONGMUA, SUM(isnull(ct.THANHTIENSAUCHIETKHAU_CT, 0)) as TongTienMua " +
            //                                   " from HOADONHAPKHOCHITIET ct, HOADONNHAPKHO hd, MATHANG mh " +
            //                                   " where ct.MAHOADON = hd.MAHOADONNHAP and mh.MAMATHANG = ct.MAMATHANG and hd.NGAYTAOHOADON between @starttime and @endtime and ct.MAHOADON like '" + banLe + "%' " +
            //                                   //" and hd.MANHACUNGCAP=@nhacungcap " +
            //                                   " GROUP BY mh.MAMATHANG,mh.TENMATHANG,mh.SOLUONGQUYDOI " +
            //                                   "order by mh.MAMATHANG,mh.TENMATHANG";

            var sqlinserttableTatCa =
                " select ROW_NUMBER() OVER (ORDER BY mh.MAMATHANG) AS Stt, mh.MAMATHANG,mh.TENMATHANG,mh.SOLUONGQUYDOI as QUYCACH, isnull(SUM(ct.SOLUONGLE),0)  as SOLUONGMUA, SUM(isnull(ct.THANHTIENSAUCHIETKHAU_CT, 0)) as TongTienMua " +
                " from HOADONHAPKHOCHITIET ct, HOADONNHAPKHO hd, MATHANG mh " +
                " where ct.MAHOADON = hd.MAHOADONNHAP and mh.MAMATHANG = ct.MAMATHANG and hd.NGAYTAOHOADON between @starttime and @endtime and ct.MAHOADON like '" +
                banLe + "%' " +
                //" and hd.MANHACUNGCAP=@nhacungcap " +
                " GROUP BY mh.MAMATHANG,mh.TENMATHANG,mh.SOLUONGQUYDOI " +
                "order by mh.MAMATHANG,mh.TENMATHANG";

            var sqlSelect = " select " + soLuongHdLoad +
                            " ROW_NUMBER() OVER (ORDER BY mh.MAMATHANG) AS Stt, mh.MAMATHANG,mh.TENMATHANG,mh.SOLUONGQUYDOI as QUYCACH,isnull(SUM(ct.SOLUONGLE), 0)  as SOLUONGMUA, SUM(isnull(ct.THANHTIENSAUCHIETKHAU_CT, 0)) as TongTienMua " +
                            " from HOADONHAPKHOCHITIET ct, HOADONNHAPKHO hd, MATHANG mh " +
                            " where ct.MAHOADON = hd.MAHOADONNHAP and mh.MAMATHANG = ct.MAMATHANG and hd.NGAYTAOHOADON between @starttime and @endtime and ct.MAHOADON like '" +
                            banLe + "%' " +
                            " GROUP BY mh.MAMATHANG,mh.TENMATHANG,mh.SOLUONGQUYDOI " +
                            "order by mh.MAMATHANG,mh.TENMATHANG";

            var sqlFinal = selectTablet + selectdeclare;
            if (maKhachHang == "" && maNhanVien == "")
                sqlFinal += sqlinserttableTatCa;
            else if (maKhachHang == "" && maNhanVien != "")
                sqlFinal += sqlinserttableByNhanVien;
            else if (maKhachHang != "" && maNhanVien == "")
                sqlFinal += sqlinserttableByKhachHang;
            else if (maKhachHang != "" && maNhanVien != "")
                sqlFinal += sqlinserttableByNhanVienAndByKhachHang;

            var data = LoadToDataTable(sqlFinal);

            return data;
        }

        public DataTable Cmd_GetImportDetails(string soLuongHdLoad, string maNhanVien, string maKhachHang,
            string batDau, string ketThuc, string ngayHienTai)
        {
            return GetImportDetails(soLuongHdLoad, maNhanVien, maKhachHang, batDau, ketThuc, ngayHienTai, "NK");
        }

        public DataTable Cmd_GetPosImportDetails(string soLuongHdLoad, string maNhanVien, string maKhachHang,
            string batDau, string ketThuc, string ngayHienTai)
        {
            return GetImportDetails(soLuongHdLoad, maNhanVien, maKhachHang, batDau, ketThuc, ngayHienTai, "CT");
        }

        #endregion Get Chi Tiet Ban Si
    }

    #region Enum Bill

    public enum StateBill
    {
        DaThanhToan,
        ChuaThanhToan,
        None
    }

    #endregion
}