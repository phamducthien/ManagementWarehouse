//------------------------------------------------------------------------------
// <auto-generated>
// Service Generated By Nick Nguyen
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Repository.Pattern.UnitOfWork;
using Service.Pattern;
using WH.Entity;
using WH.Model;
using WH.Service.Repository;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using WH.Service.Service;
namespace WH.Service.Service
{
    public partial interface IKHOMATHANGService : IService
    {
    	bool Exist(string id);
    	bool Exist(Expression<Func<KHOMATHANG, bool>> predicate);
    
    	KHOMATHANG CreateNew();
        List<KHOMATHANG> FindAll();
    	List<KHOMATHANG> Search(string textSearch);
    	List<KHOMATHANG> Search(Expression<Func<KHOMATHANG, bool>> predicate,string textSearch);
        List<KHOMATHANG> Search(Expression<Func<KHOMATHANG, bool>> predicate);
    	
    	KHOMATHANG Find(string idUnit);
    	KHOMATHANG Find(Expression<Func<KHOMATHANG, bool>> predicate);
    
    	//KHOMATHANG CloneNew(KHOMATHANG objKHOMATHANG);
    	//KHOMATHANG CloneUpdate(KHOMATHANG objKHOMATHANG);
    	KHOMATHANG Clone(KHOMATHANG objKHOMATHANG);
    	List< KHOMATHANG> Clone(IList<KHOMATHANG> listKHOMATHANGs);
    
        MethodResult Add(KHOMATHANG model, bool isCommited = false,bool isAddChild = false);
        MethodResult Modify(KHOMATHANG model, bool isCommited= false,bool isModifyChild = false);
    	MethodResult Remove(KHOMATHANG model, bool isCommited = false,bool isRemoveChild = false);
        MethodResult Remove(string idUnit, bool isCommited = false,bool isRemoveChild = false);
    }
    
    public partial class KHOMATHANGService : global::Service.Pattern.Service, IKHOMATHANGService
    {
    	protected string userId = SessionModel.CurrentSession?.UserId;
    	protected IKHOMATHANGRepository _KHOMATHANGRepository;
    	
    
    	public KHOMATHANGService(IUnitOfWorkAsync unitOfWork)
                : base(unitOfWork)
        {
        }
    
        protected override void InitRepositories()
        {
            _KHOMATHANGRepository = new KHOMATHANGRepository(this._dataContext, this._unitOfWork);
    		
        }
    	
    	public bool Exist(string id)
        {
    		return _KHOMATHANGRepository.Exist(id);
        }
    
    	public bool Exist(Expression<Func<KHOMATHANG, bool>> predicate)
    	{
    		return _KHOMATHANGRepository.Exist(predicate);
    	}
    
        public KHOMATHANG CreateNew()
        {
            return _KHOMATHANGRepository.CreateNew();
        }
    
    	public List<KHOMATHANG> FindAll()
    	{
    		return _KHOMATHANGRepository.FindAll();
    	}
    
    	public List<KHOMATHANG> Search(string textSearch)
        {
            return _KHOMATHANGRepository.Search(textSearch);
        }
    
    	public List<KHOMATHANG> Search(Expression<Func<KHOMATHANG, bool>> predicate,string textSearch)
    	{
    		  return _KHOMATHANGRepository.Search(predicate, textSearch);
    	}
    
    		public KHOMATHANG Find(Expression<Func<KHOMATHANG, bool>> predicate)
            {
               return _KHOMATHANGRepository.getObject(predicate);
            }
    
            public List<KHOMATHANG> Search(Expression<Func<KHOMATHANG, bool>> predicate)
            {
                return _KHOMATHANGRepository.Search(predicate);
            }
    
            //public KHOMATHANG CloneNew(KHOMATHANG objKHOMATHANG)
           // {
           //     return _KHOMATHANGRepository.CloneNew(objKHOMATHANG);
           // }
    
    	//	public KHOMATHANG CloneUpdate(KHOMATHANG objKHOMATHANG)
    	//	{
    	//		  return _KHOMATHANGRepository.CloneUpdate(objKHOMATHANG);
    	//	}
    
    		public KHOMATHANG Clone(KHOMATHANG objKHOMATHANG)
    		{
    			return _KHOMATHANGRepository.Clone(objKHOMATHANG);
    		}
    
            public List<KHOMATHANG> Clone(IList<KHOMATHANG> listKHOMATHANGs)
            {
                return _KHOMATHANGRepository.Clone(listKHOMATHANGs);
            }
    
        public KHOMATHANG Find(string idUnit)
        {
    		return _KHOMATHANGRepository.getObject(idUnit);
        }
    
    	public MethodResult Add(KHOMATHANG entity, bool isCommited,bool isAddChild)
        {
    		MethodResult result = MethodResult.Succeed;
    		try
    		{
    			if(isCommited)
    				_unitOfWork.BeginTransaction();
    
    			entity.Validate();
    
    			_KHOMATHANGRepository.Insert(Clone(entity));
    			if (SaveChanges() <= 0)
    			{
    				ThrowException("Không thể thêm dữ liệu 'KHOMATHANG'.");
    			}
    
    			if(isAddChild)
    			{
    			
    
    				if (SaveChanges() <= 0)
    				{
    					ThrowException("Không thể thêm dữ liệu con 'KHOMATHANG'.");
    				}
    			}
    
    			if(isCommited)
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
    
    	public MethodResult Modify(KHOMATHANG entity, bool isCommited,bool isModifyChild)
    	{
                MethodResult result = MethodResult.Succeed;
                try
                {
    
                 if(isCommited)
    				_unitOfWork.BeginTransaction();
    
                    entity.Validate();
    
                    _KHOMATHANGRepository.Update(Clone(entity));
    				if (SaveChanges() <= 0)
                    {
                        ThrowException("Không thể sửa dữ liệu 'KHOMATHANG'.");
                    }
    
    				if(isModifyChild)
    				{
    				
    
    					 if (SaveChanges() <= 0)
    					{
    						ThrowException("Không thể sửa dữ liệu con 'KHOMATHANG'.");
    					}
    				}
    
                   	if(isCommited)
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
    
            public MethodResult Remove(string idUnit, bool isCommited,bool isRemoveChild)
            {
                MethodResult result = MethodResult.Succeed;
    
                try
                {
    				if(isCommited)
    						_unitOfWork.BeginTransaction();
    
    
                    KHOMATHANG entity = Find(idUnit);
    
                    if (entity == null)
                    {
                        ThrowException("Dữ liệu 'KHOMATHANG' này không tồn tại trong hệ thống.");
                    }
    				if(isRemoveChild)
    				{
    				
    
    				    if (SaveChanges() <= 0)
    					{
    						ThrowException("Không thể xóa dữ liệu con 'KHOMATHANG'.");
    					}
    				}
    
                    _KHOMATHANGRepository.Delete(Clone(entity));
    
                    if (SaveChanges() <= 0)
                    {
                        ThrowException("Không thể xóa dữ liệu 'KHOMATHANG'.");
                    }
    
    				if(isCommited)
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
    
    		public MethodResult Remove(KHOMATHANG model, bool isCommited,bool isRemoveChild)
            {
                MethodResult result = MethodResult.Succeed;
    
                try
                {
                    if(isCommited)
    						_unitOfWork.BeginTransaction();
    
    
                    KHOMATHANG entity = Find(model.IDUnit);
    
                    if (entity == null)
                    {
                        ThrowException("Dữ liệu 'KHOMATHANG' này không tồn tại trong hệ thống.");
                    }
    
    				if(isRemoveChild)
    				{
    				
    
    					if (SaveChanges() <= 0)
    					{
    						ThrowException("Không thể xóa dữ liệu con 'KHOMATHANG'.");
    					}
    				}
                    _KHOMATHANGRepository.Delete(Clone(entity));
    
                    if (SaveChanges() <= 0)
                    {
                        ThrowException("Không thể xóa dữ liệu 'KHOMATHANG'.");
                    }
    
                   	if(isCommited)
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
