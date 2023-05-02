using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Service.Pattern;
using Util.Pattern;
using WH.Service;

namespace WH.GUI
{
    public partial class FrmImportExcelHoaDon : FrmBase
    {
        public FrmImportExcelHoaDon()
        {
            InitializeComponent();
            CreateEvent();

            IsSuccessfully = false;
        }

        private List<ExcelHoaDonModelService.HoaDonNhapExcelModel> _lstDonNhapExcelModels { get; set; }

        #region Events

        private void CreateEvent()
        {
            DgView = dgvHoaDon;
            grbThongTinLoi.Visible = false;

            foreach (var txt in gbxInfo.Panel.Controls.OfType<KryptonTextBox>())
            {
                txt.Enter += txt_Enter;
                txt.Leave += txt_Leave;
                txt.KeyPress += txt_KeyPress;
            }

            btnSelectKH.Click += BtnSelectKH_Click;
            btnXacNhan.Click += BtnXacNhan_Click;
        }

        private void BtnXacNhan_Click(object sender, EventArgs e)
        {
            ActionXacNhan();
        }

        private void BtnSelectKH_Click(object sender, EventArgs e)
        {
            ActionSelect();
        }

        #endregion

        #region Actions

        private void ActionSelect()
        {
            try
            {
                grbThongTinLoi.Visible = false;
                txtThongTinLoi.Text = string.Empty;
                var openFileDialog = new OpenFileDialog
                {
                    Multiselect = false,
                    Filter = @"Excel file (*.xlsx)|*.xlsx|(*.xls)|*.xls"
                };
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtSelectFile.Text = Path.GetFileName(openFileDialog.FileName);
                    ReloadUnitOfWork();
                    IExcelHoaDonModelService excelHoaDonModel = new ExcelHoaDonModelService(UnitOfWorkAsync);
                    var lst = excelHoaDonModel.InsertHoaDonModel(openFileDialog.FileName);
                    if (lst != null && lst.Count > 0)
                    {
                        var stt = 1;
                        var data = from p in lst
                            select new
                            {
                                STT = stt++,
                                NGAYTAO = p.hdXuatKho.NGAYTAOHOADON,
                                MAHOADON = p.hdXuatKho.MAHOADONXUAT,
                                MACODE = p.Khachhang?.CODEKHACHHANG ?? "",
                                KHACHHANG = p.Khachhang?.TENKHACHHANG ?? "",
                                SOLUONG = p.lsthdXuatKhoChiTiet.Sum(s => s.SOLUONGLE),
                                THANHTIEN = p.hdXuatKho.SOTIENTHANHTOAN_HD

                            };
                        LoadData(data.ToList().ToDatatable());
                        if (!excelHoaDonModel.ErrMsgExcel.IsBlank())
                        {
                            grbThongTinLoi.Visible = false;
                            txtThongTinLoi.Text = excelHoaDonModel.ErrMsgExcel;
                            grbThongTinLoi.Visible = true;
                        }

                        labTongTien.Values.ExtraText = lst.Sum(s => s.hdXuatKho.SOTIENTHANHTOAN_HD ?? 0).ToString("N2");
                        labSoLuong.Values.ExtraText = lst.Sum(s => s.lsthdXuatKhoChiTiet.Sum(p => p.SOLUONGLE ?? 0))
                            .ToString("N");

                        _lstDonNhapExcelModels = lst;
                    }
                    else
                    {
                        grbThongTinLoi.Visible = false;
                        txtThongTinLoi.Text = excelHoaDonModel.ErrMsgExcel;
                        grbThongTinLoi.Visible = true;
                        //ShowMessage(IconMessageBox.Warning, excelHoaDonModel.ErrMsg);
                    }
                }
            }
            catch (Exception ex)
            {
                DgView.DataSource = null;
                labTongTien.Values.ExtraText = 0.ToString("N2");
                labSoLuong.Values.ExtraText = 0.ToString("N2");
                txtSelectFile.Text = @"Chọn File Excel Hóa Đơn.";
                txtSelectFile.Select();
                ShowMessage(IconMessageBox.Error, ex.Message);
            }
        }

        private void ActionXacNhan()
        {
            try
            {
                if (_lstDonNhapExcelModels.isNull())
                {
                    ShowMessage(IconMessageBox.Warning, "Không tìm thấy DS hóa đơn!!!");
                    return;
                }

                if (!txtThongTinLoi.Text.IsBlank())
                    if (ShowMessage(IconMessageBox.Question,
                            "Có một số dòng hóa đơn đang bị lỗi bạn có muốn tiếp tục nhập file excel này vào không?") ==
                        DialogResult.No)
                        return;

                ReloadUnitOfWork();
                IXuatKhoService service = new XuatKhoService(UnitOfWorkAsync);
                var result = service.ThanhToan(_lstDonNhapExcelModels);
                if (result != MethodResult.Succeed)
                {
                    ShowMessage(IconMessageBox.Warning, service.ErrMsg);
                }
                else
                {
                    ShowMessage(IconMessageBox.Information, "Nhập Excel Thành Công!");
                    txtThongTinLoi.Text = "";
                    grbThongTinLoi.Visible = false;
                    DgView.DataSource = null;
                    labTongTien.Values.ExtraText = 0.ToString("N");
                    labSoLuong.Values.ExtraText = 0.ToString("N");
                    txtSelectFile.Text = @"Chọn File Excel Hóa Đơn.";
                    txtSelectFile.Select();
                }
            }
            catch (Exception ex)
            {
                ShowMessage(IconMessageBox.Warning, ex.InnerException.Message);
            }
        }

        #endregion

        #region Functions

        #endregion
    }
}