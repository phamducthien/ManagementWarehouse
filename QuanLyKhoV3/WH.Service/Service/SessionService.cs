using System;
using System.Linq;
using Repository.Pattern.UnitOfWork;
using Service.Pattern;
using Util.Pattern.Encryptor;
using WH.Model;
using WH.Service.Service;

namespace WH.Service
{
    public interface ISessionService : IService
    {
        MethodResult Login(string userName, string password);
        MethodResult Logout();
        MethodResult ResetPassword(string userId);
        MethodResult ChangePassword(string userId, string oldPass, string newPassword);
    }

    public class SessionService : global::Service.Pattern.Service, ISessionService
    {
        protected ICHUCNANGService _ChucNangService;
        protected INGUOIDUNG_QUYENHANService _NguoidungQuyenhanService;
        protected INGUOIDUNGService _NguoidungService;

        protected string defaultPassword = "123456";

        protected string keyEncrypt = "G8_4<A~!7X_tL04";

        public SessionService(IUnitOfWorkAsync unitOfWork) : base(unitOfWork)
        {
            //InitRepositories();
            _NguoidungService = new NGUOIDUNGService(unitOfWork);
            _ChucNangService = new CHUCNANGService(unitOfWork);
            _NguoidungQuyenhanService = new NGUOIDUNG_QUYENHANService(unitOfWork);
        }

        public MethodResult Login(string username, string password)
        {
            try
            {
                ///Trình tự thực hiện:
                /// Kiểm tra User đăng nhập
                /// Load Menu Setting
                /// 
                //INguoiDungModelService userService = new NguoiDungModelService(_unitOfWork);
                //IChucNangService chucNangService = new ChucNangService(this._unitOfWork);
                password = Encrypt(password);
                var userModel = _NguoidungService.Find(s => s.TENDANGNHAP == username && s.MATKHAU == password);
             
                if (userModel == null)
                    ThrowException("Tên đăng nhập hoặc mật khẩu không chính xác");

                if (userModel?.ISDELETE==true)
                    ThrowException("Tài khoản không tồn tại!");

                var chucnangList = _NguoidungQuyenhanService.Search(s => s.MANGUOIDUNG == userModel.MANGUOIDUNG);
                var menuSetting = chucnangList.Select(chucNang =>
                        new MenuSettingModel(_ChucNangService.Find(s => s.MACHUCNANG.Equals(chucNang.MACHUCNANG))))
                    .ToList();
                //menuSetting = menuSetting.OrderByDescending(p => p.GroupPriority).ThenBy(p => p.Title).ToList();
                IKHOService serviceKho = new KHOService(_unitOfWork);
                var khoMatHang = serviceKho.FindAll()[0];
                var newSession = new SessionModel
                {
                    User = userModel,
                    MenuSetting = menuSetting,
                    KhoMatHang = khoMatHang
                };

                SessionModel.CurrentSession = newSession;
            }
            catch (Exception exception)
            {
                ErrMsg = exception.Message;
                return MethodResult.Failed;
            }

            return MethodResult.Succeed;
        }

        public MethodResult Logout()
        {
            try
            {
                SessionModel.CurrentSession = null;
            }
            catch (Exception exception)
            {
                ErrMsg = exception.Message;
                return MethodResult.Failed;
            }

            return MethodResult.Succeed;
        }

        public MethodResult ResetPassword(string userId)
        {
            try
            {
                var nguoiDung = _NguoidungService.Find(userId);
                nguoiDung.MATKHAU = Encrypt(defaultPassword);
                return _NguoidungService.Modify(nguoiDung, true);
            }
            catch (Exception exception)
            {
                ErrMsg = exception.Message;
                return MethodResult.Failed;
            }
        }

        public MethodResult ChangePassword(string userId, string oldPass, string newPassword)
        {
            try
            {
                var nguoiDung = _NguoidungService.Find(userId);
                newPassword = Encrypt(newPassword);
                if (nguoiDung.MATKHAU == oldPass && newPassword != oldPass)
                {
                    nguoiDung.MATKHAU = newPassword;

                    var result = _NguoidungService.Modify(nguoiDung, true);
                    if (result != MethodResult.Succeed)
                    {
                        ErrMsg = _NguoidungService.ErrMsg;
                        return MethodResult.Failed;
                    }

                    var chucnangList = _NguoidungQuyenhanService.Search(s => s.MANGUOIDUNG.Equals(userId));
                    var menuSetting =
                        chucnangList.Select(
                                chucNang =>
                                    new MenuSettingModel(_ChucNangService.Find(s =>
                                        s.MACHUCNANG.Equals(chucNang.MACHUCNANG))))
                            .ToList();


                    //menuSetting = menuSetting.OrderByDescending(p => p.GroupPriority).ThenBy(p => p.Title).ToList();

                    var newSession = new SessionModel
                    {
                        User = SessionModel.CurrentSession.User,
                        MenuSetting = menuSetting
                    };

                    SessionModel.CurrentSession = newSession;
                    return MethodResult.Succeed;
                }

                ErrMsg = "Mật khẩu cũ không đúng hoặc mật khẩu mới phải khác mật khẩu cũ";
                return MethodResult.Failed;
            }
            catch (Exception exception)
            {
                ErrMsg = exception.Message;
                return MethodResult.Failed;
            }
        }

        private string Encrypt(string input)
        {
            return StringCryptographyUtil.Encrypt(input, keyEncrypt);
        }

        protected string Decrypt(string input)
        {
            try
            {
                return StringCryptographyUtil.Decrypt(input, keyEncrypt);
            }
            catch
            {
                return "";
            }
        }

        protected override void InitRepositories()
        {
        }
    }
}