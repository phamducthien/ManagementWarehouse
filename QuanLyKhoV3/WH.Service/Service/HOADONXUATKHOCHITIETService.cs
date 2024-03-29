//------------------------------------------------------------------------------
// <auto-generated>
// Service Generated By Nick Nguyen
// </auto-generated>
//------------------------------------------------------------------------------
using Repository.Pattern.UnitOfWork;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq.Expressions;
using WH.Entity;
using WH.Model;
using WH.Service.Repository;
namespace WH.Service.Service
{
    public partial interface IHOADONXUATKHOCHITIETService : IService
    {
        bool Exist(string id);
        bool Exist(Expression<Func<HOADONXUATKHOCHITIET, bool>> predicate);

        HOADONXUATKHOCHITIET CreateNew();
        List<HOADONXUATKHOCHITIET> FindAll();
        List<HOADONXUATKHOCHITIET> Search(string textSearch);
        List<HOADONXUATKHOCHITIET> Search(Expression<Func<HOADONXUATKHOCHITIET, bool>> predicate, string textSearch);
        List<HOADONXUATKHOCHITIET> Search(Expression<Func<HOADONXUATKHOCHITIET, bool>> predicate);

        HOADONXUATKHOCHITIET Find(string idUnit);
        HOADONXUATKHOCHITIET Find(Expression<Func<HOADONXUATKHOCHITIET, bool>> predicate);

        HOADONXUATKHOCHITIET Clone(HOADONXUATKHOCHITIET objHOADONXUATKHOCHITIET);
        List<HOADONXUATKHOCHITIET> Clone(IList<HOADONXUATKHOCHITIET> listHOADONXUATKHOCHITIETs);

        MethodResult Add(HOADONXUATKHOCHITIET model, bool isCommited = false, bool isAddChild = false);
        MethodResult Modify(HOADONXUATKHOCHITIET model, bool isCommited = false, bool isModifyChild = false);
        MethodResult Remove(HOADONXUATKHOCHITIET model, bool isCommited = false, bool isRemoveChild = false);
        MethodResult Remove(string idUnit, bool isCommited = false, bool isRemoveChild = false);
    }

    public partial class HOADONXUATKHOCHITIETService : global::Service.Pattern.Service, IHOADONXUATKHOCHITIETService
    {
        protected string userId = SessionModel.CurrentSession?.UserId;
        protected IHOADONXUATKHOCHITIETRepository _HOADONXUATKHOCHITIETRepository;


        public HOADONXUATKHOCHITIETService(IUnitOfWorkAsync unitOfWork)
                : base(unitOfWork)
        {
        }

        protected override void InitRepositories()
        {
            _HOADONXUATKHOCHITIETRepository = new HOADONXUATKHOCHITIETRepository(this._dataContext, this._unitOfWork);

        }

        public bool Exist(string id)
        {
            return _HOADONXUATKHOCHITIETRepository.Exist(id);
        }

        public bool Exist(Expression<Func<HOADONXUATKHOCHITIET, bool>> predicate)
        {
            return _HOADONXUATKHOCHITIETRepository.Exist(predicate);
        }

        public HOADONXUATKHOCHITIET CreateNew()
        {
            return _HOADONXUATKHOCHITIETRepository.CreateNew();
        }

        public List<HOADONXUATKHOCHITIET> FindAll()
        {
            return _HOADONXUATKHOCHITIETRepository.FindAll();
        }

        public List<HOADONXUATKHOCHITIET> Search(string textSearch)
        {
            return _HOADONXUATKHOCHITIETRepository.Search(textSearch);
        }

        public List<HOADONXUATKHOCHITIET> Search(Expression<Func<HOADONXUATKHOCHITIET, bool>> predicate, string textSearch)
        {
            return _HOADONXUATKHOCHITIETRepository.Search(predicate, textSearch);
        }

        public HOADONXUATKHOCHITIET Find(Expression<Func<HOADONXUATKHOCHITIET, bool>> predicate)
        {
            return _HOADONXUATKHOCHITIETRepository.getObject(predicate);
        }

        public List<HOADONXUATKHOCHITIET> Search(Expression<Func<HOADONXUATKHOCHITIET, bool>> predicate)
        {
            return _HOADONXUATKHOCHITIETRepository.Search(predicate);
        }

        public HOADONXUATKHOCHITIET Clone(HOADONXUATKHOCHITIET objHOADONXUATKHOCHITIET)
        {
            return _HOADONXUATKHOCHITIETRepository.Clone(objHOADONXUATKHOCHITIET);
        }

        public List<HOADONXUATKHOCHITIET> Clone(IList<HOADONXUATKHOCHITIET> listHOADONXUATKHOCHITIETs)
        {
            return _HOADONXUATKHOCHITIETRepository.Clone(listHOADONXUATKHOCHITIETs);
        }

        public HOADONXUATKHOCHITIET Find(string idUnit)
        {
            return _HOADONXUATKHOCHITIETRepository.getObject(idUnit);
        }

        public MethodResult Add(HOADONXUATKHOCHITIET entity, bool isCommited, bool isAddChild)
        {
            MethodResult result = MethodResult.Succeed;
            try
            {
                if (isCommited)
                    _unitOfWork.BeginTransaction();

                entity.Validate();

                _HOADONXUATKHOCHITIETRepository.Insert(Clone(entity));
                if (SaveChanges() <= 0)
                {
                    ThrowException("Không thể thêm dữ liệu 'HOADONXUATKHOCHITIET'.");
                }

                if (isAddChild)
                {


                    if (SaveChanges() <= 0)
                    {
                        ThrowException("Không thể thêm dữ liệu con 'HOADONXUATKHOCHITIET'.");
                    }
                }

                if (isCommited)
                    _unitOfWork.Commit();
            }
            catch (DbEntityValidationException exception)
            {
                var ex = HandleDbEntityValidationException(exception);

                if (_unitOfWork != null) _unitOfWork.Rollback();
                ErrMsg = ex.Message;
                result = MethodResult.Failed;
            }
            catch (DbUpdateException exception)
            {
                var ex = HandleDbUpdateException(exception);

                if (_unitOfWork != null) _unitOfWork.Rollback();
                ErrMsg = ex.Message;
                result = MethodResult.Failed;
            }
            return result;
        }

        public MethodResult Modify(HOADONXUATKHOCHITIET entity, bool isCommited, bool isModifyChild)
        {
            MethodResult result = MethodResult.Succeed;
            try
            {

                if (isCommited)
                    _unitOfWork.BeginTransaction();

                entity.Validate();

                _HOADONXUATKHOCHITIETRepository.Update(Clone(entity));
                if (SaveChanges() <= 0)
                {
                    ThrowException("Không thể sửa dữ liệu 'HOADONXUATKHOCHITIET'.");
                }

                if (isModifyChild)
                {


                    if (SaveChanges() <= 0)
                    {
                        ThrowException("Không thể sửa dữ liệu con 'HOADONXUATKHOCHITIET'.");
                    }
                }

                if (isCommited)
                    _unitOfWork.Commit();
            }
            catch (DbEntityValidationException exception)
            {
                var ex = HandleDbEntityValidationException(exception);

                if (_unitOfWork != null) _unitOfWork.Rollback();
                ErrMsg = ex.Message;
                result = MethodResult.Failed;
            }
            catch (DbUpdateException exception)
            {
                var ex = HandleDbUpdateException(exception);

                if (_unitOfWork != null) _unitOfWork.Rollback();
                ErrMsg = ex.Message;
                result = MethodResult.Failed;
            }
            return result;
        }

        public MethodResult Remove(string idUnit, bool isCommited, bool isRemoveChild)
        {
            MethodResult result = MethodResult.Succeed;

            try
            {
                if (isCommited)
                    _unitOfWork.BeginTransaction();


                HOADONXUATKHOCHITIET entity = Find(idUnit);

                if (entity == null)
                {
                    ThrowException("Dữ liệu 'HOADONXUATKHOCHITIET' này không tồn tại trong hệ thống.");
                }
                if (isRemoveChild)
                {


                    if (SaveChanges() <= 0)
                    {
                        ThrowException("Không thể xóa dữ liệu con 'HOADONXUATKHOCHITIET'.");
                    }
                }

                _HOADONXUATKHOCHITIETRepository.Delete(Clone(entity));

                if (SaveChanges() <= 0)
                {
                    ThrowException("Không thể xóa dữ liệu 'HOADONXUATKHOCHITIET'.");
                }

                if (isCommited)
                    _unitOfWork.Commit();
            }
            catch (DbEntityValidationException exception)
            {
                var ex = HandleDbEntityValidationException(exception);

                if (_unitOfWork != null) _unitOfWork.Rollback();
                ErrMsg = ex.Message;
                result = MethodResult.Failed;
            }
            catch (DbUpdateException exception)
            {
                var ex = HandleDbUpdateException(exception);

                if (_unitOfWork != null) _unitOfWork.Rollback();
                ErrMsg = ex.Message;
                result = MethodResult.Failed;
            }
            return result;
        }

        public MethodResult Remove(HOADONXUATKHOCHITIET model, bool isCommited, bool isRemoveChild)
        {
            MethodResult result = MethodResult.Succeed;

            try
            {
                if (isCommited)
                    _unitOfWork.BeginTransaction();


                HOADONXUATKHOCHITIET entity = Find(model.IDUnit);

                if (entity == null)
                {
                    ThrowException("Dữ liệu 'HOADONXUATKHOCHITIET' này không tồn tại trong hệ thống.");
                }

                if (isRemoveChild)
                {


                    if (SaveChanges() <= 0)
                    {
                        ThrowException("Không thể xóa dữ liệu con 'HOADONXUATKHOCHITIET'.");
                    }
                }
                _HOADONXUATKHOCHITIETRepository.Delete(Clone(entity));

                if (SaveChanges() <= 0)
                {
                    ThrowException("Không thể xóa dữ liệu 'HOADONXUATKHOCHITIET'.");
                }

                if (isCommited)
                    _unitOfWork.Commit();
            }
            catch (DbEntityValidationException exception)
            {
                var ex = HandleDbEntityValidationException(exception);

                if (_unitOfWork != null) _unitOfWork.Rollback();
                ErrMsg = ex.Message;
                result = MethodResult.Failed;
            }
            catch (DbUpdateException exception)
            {
                var ex = HandleDbUpdateException(exception);

                if (_unitOfWork != null) _unitOfWork.Rollback();
                ErrMsg = ex.Message;
                result = MethodResult.Failed;
            }
            return result;
        }
    }
}
