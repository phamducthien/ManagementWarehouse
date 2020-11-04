using System.Windows.Forms;
using Repository.Pattern.UnitOfWork;
using WH.Service.Repository.Core;

namespace WH.GUI
{
    public enum ThaoTac
    {
        Xem,
        Them,
        Sua,
        Xoa,
        XuatExcel,
        NhapExcel,
        FileMau,
        Luu,
        Huy,
        TimKiem,
        Thoat,
        Load,
        Chon,
        MacDinh
    }

    public enum StateObject
    {
        NULL = 1,
        NOTNULL = 2,
        NONE = 3
    }

    public interface IBaseForm
    {
        DialogResult ShowMessage(IconMessageBox typeBox);
        DialogResult ShowMessage(IconMessageBox typeBox, string message);
        void ReloadUnitOfWork();
    }

    public class BaseForm : IBaseForm
    {
        public IUnitOfWorkAsync UnitOfWorkAsync;

        public BaseForm()
        {
            ThaoTac = ThaoTac.Xem;
            IsSelect = false;
            IsSuccessfuly = false;
            IsChange = false;
            IsVietNamLanguage = true;
        }

        public BaseForm(bool isVietNamLanguage)
        {
            ThaoTac = ThaoTac.Xem;
            IsSelect = false;
            IsSuccessfuly = false;
            IsChange = false;
            IsVietNamLanguage = isVietNamLanguage;
        }

        public ThaoTac ThaoTac { get; set; }
        public DataGridViewRow CurrentRow { get; set; }

        public bool IsSelect { get; set; }

        // public bool IsShowListSelect { get; set; }
        public bool IsSuccessfuly { get; set; }
        public string ErrMsg { get; set; }
        public bool IsChange { get; set; }
        public string VietNamMsg { get; set; }
        public string EnglishMsg { get; set; }
        public bool IsVietNamLanguage { get; set; }

        public void ReloadUnitOfWork()
        {
            if (UnitOfWorkAsync != null)
                UnitOfWorkAsync.Dispose();
            UnitOfWorkAsync = null;
            UnitOfWorkAsync = UnitOfWorkFactory.MakeUnitOfWork();
        }

        public DialogResult ShowMessage(IconMessageBox typeBox)
        {
            var result = DialogResult.None;
            switch (typeBox)
            {
                case IconMessageBox.Information:
                    result = MsgBox.Show(IsVietNamLanguage ? VietNamMsg : EnglishMsg,
                        IsVietNamLanguage ? "Thông Báo" : "Notice", MsgBox.Buttons.Ok, MsgBox.IconMsgBox.Info);
                    break;

                case IconMessageBox.Warning:
                    result = MsgBox.Show(IsVietNamLanguage ? VietNamMsg : EnglishMsg,
                        IsVietNamLanguage ? "Thông Báo" : "Notice", MsgBox.Buttons.Ok, MsgBox.IconMsgBox.Warning);
                    break;

                case IconMessageBox.Error:
                    result = MsgBox.Show(IsVietNamLanguage ? VietNamMsg : EnglishMsg,
                        IsVietNamLanguage ? "Thông Báo" : "Notice", MsgBox.Buttons.Ok, MsgBox.IconMsgBox.Error);
                    break;

                case IconMessageBox.Question:
                    result = MsgBox.Show(IsVietNamLanguage ? VietNamMsg : EnglishMsg,
                        IsVietNamLanguage ? "Thông Báo" : "Notice", MsgBox.Buttons.YesNo, MsgBox.IconMsgBox.Question);
                    break;
            }

            EnglishMsg = string.Empty;
            VietNamMsg = string.Empty;
            return result;
        }

        public DialogResult ShowMessage(IconMessageBox typeBox, string message)
        {
            var result = DialogResult.None;
            switch (typeBox)
            {
                case IconMessageBox.Information:
                    MsgBox.Show(message, IsVietNamLanguage ? "Thông Báo" : "Notice", MsgBox.Buttons.Ok,
                        MsgBox.IconMsgBox.Info);
                    break;

                case IconMessageBox.Warning:
                    MsgBox.Show(message, IsVietNamLanguage ? "Thông Báo" : "Notice", MsgBox.Buttons.Ok,
                        MsgBox.IconMsgBox.Warning);
                    break;

                case IconMessageBox.Error:
                    MsgBox.Show(message, IsVietNamLanguage ? "Thông Báo" : "Notice", MsgBox.Buttons.Ok,
                        MsgBox.IconMsgBox.Error);
                    break;

                case IconMessageBox.Question:
                    result = MsgBox.Show(message, IsVietNamLanguage ? "Thông Báo" : "Notice", MsgBox.Buttons.YesNo,
                        MsgBox.IconMsgBox.Question);
                    break;
            }

            return result;
        }
    }
}