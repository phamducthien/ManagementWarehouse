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
    public partial interface IMATHANGKHUYENMAIService : IService
    {
    	bool Exist(string id);
    	bool Exist(Expression<Func<MATHANGKHUYENMAI, bool>> predicate);
    
    	MATHANGKHUYENMAI CreateNew();
        List<MATHANGKHUYENMAI> FindAll();
    	List<MATHANGKHUYENMAI> Search(string textSearch);
    	List<MATHANGKHUYENMAI> Search(Expression<Func<MATHANGKHUYENMAI, bool>> predicate,string textSearch);
        List<MATHANGKHUYENMAI> Search(Expression<Func<MATHANGKHUYENMAI, bool>> predicate);
    	
    	MATHANGKHUYENMAI Find(string idUnit);
    	MATHANGKHUYENMAI Find(Expression<Func<MATHANGKHUYENMAI, bool>> predicate);
    
    	//MATHANGKHUYENMAI CloneNew(MATHANGKHUYENMAI objMATHANGKHUYENMAI);
    	//MATHANGKHUYENMAI CloneUpdate(MATHANGKHUYENMAI objMATHANGKHUYENMAI);
    	MATHANGKHUYENMAI Clone(MATHANGKHUYENMAI objMATHANGKHUYENMAI);
    	List< MATHANGKHUYENMAI> Clone(IList<MATHANGKHUYENMAI> listMATHANGKHUYENMAIs);
    
        MethodResult Add(MATHANGKHUYENMAI model, bool isCommited = false,bool isAddChild = false);
        MethodResult Modify(MATHANGKHUYENMAI model, bool isCommited= false,bool isModifyChild = false);
    	MethodResult Remove(MATHANGKHUYENMAI model, bool isCommited = false,bool isRemoveChild = false);
        MethodResult Remove(string idUnit, bool isCommited = false,bool isRemoveChild = false);
    }
    
    public partial class MATHANGKHUYENMAIService : global::Service.Pattern.Service, IMATHANGKHUYENMAIService
    {
    	protected string userId = SessionModel.CurrentSession?.UserId;
    	protected IMATHANGKHUYENMAIRepository _MATHANGKHUYENMAIRepository;
    	
    
    	public MATHANGKHUYENMAIService(IUnitOfWorkAsync unitOfWork)
                : base(unitOfWork)
        {
        }
    
        protected override void InitRepositories()
        {
            _MATHANGKHUYENMAIRepository = new MATHANGKHUYENMAIRepository(this._dataContext, this._unitOfWork);
    		
        }
    	
    	public bool Exist(string id)
        {
    		return _MATHANGKHUYENMAIRepository.Exist(id);
        }
    
    	public bool Exist(Expression<Func<MATHANGKHUYENMAI, bool>> predicate)
    	{
    		return _MATHANGKHUYENMAIRepository.Exist(predicate);
    	}
    
        public MATHANGKHUYENMAI CreateNew()
        {
            return _MATHANGKHUYENMAIRepository.CreateNew();
        }
    
    	public List<MATHANGKHUYENMAI> FindAll()
    	{
    		return _MATHANGKHUYENMAIRepository.FindAll();
    	}
    
    	public List<MATHANGKHUYENMAI> Search(string textSearch)
        {
            return _MATHANGKHUYENMAIRepository.Search(textSearch);
        }
    
    	public List<MATHANGKHUYENMAI> Search(Expression<Func<MATHANGKHUYENMAI, bool>> predicate,string textSearch)
    	{
    		  return _MATHANGKHUYENMAIRepository.Search(predicate, textSearch);
    	}
    
    		public MATHANGKHUYENMAI Find(Expression<Func<MATHANGKHUYENMAI, bool>> predicate)
            {
               return _MATHANGKHUYENMAIRepository.getObject(predicate);
            }
    
            public List<MATHANGKHUYENMAI> Search(Expression<Func<MATHANGKHUYENMAI, bool>> predicate)
            {
                return _MATHANGKHUYENMAIRepository.Search(predicate);
            }
    
            //public MATHANGKHUYENMAI CloneNew(MATHANGKHUYENMAI objMATHANGKHUYENMAI)
           // {
           //     return _MATHANGKHUYENMAIRepository.CloneNew(objMATHANGKHUYENMAI);
           // }
    
    	//	public MATHANGKHUYENMAI CloneUpdate(MATHANGKHUYENMAI objMATHANGKHUYENMAI)
    	//	{
    	//		  return _MATHANGKHUYENMAIRepository.CloneUpdate(objMATHANGKHUYENMAI);
    	//	}
    
    		public MATHANGKHUYENMAI Clone(MATHANGKHUYENMAI objMATHANGKHUYENMAI)
    		{
    			return _MATHANGKHUYENMAIRepository.Clone(objMATHANGKHUYENMAI);
    		}
    
            public List<MATHANGKHUYENMAI> Clone(IList<MATHANGKHUYENMAI> listMATHANGKHUYENMAIs)
            {
                return _MATHANGKHUYENMAIRepository.Clone(listMATHANGKHUYENMAIs);
            }
    
        public MATHANGKHUYENMAI Find(string idUnit)
        {
    		return _MATHANGKHUYENMAIRepository.getObject(idUnit);
        }
    
    	public MethodResult Add(MATHANGKHUYENMAI entity, bool isCommited,bool isAddChild)
        {
    		MethodResult result = MethodResult.Succeed;
    		try
    		{
    			if(isCommited)
    				_unitOfWork.BeginTransaction();
    
    			entity.Validate();
    
    			_MATHANGKHUYENMAIRepository.Insert(Clone(entity));
    			if (SaveChanges() <= 0)
    			{
    				ThrowException("Không thể thêm dữ liệu 'MATHANGKHUYENMAI'.");
    			}
    
    			if(isAddChild)
    			{
    			
    
    				if (SaveChanges() <= 0)
    				{
    					ThrowException("Không thể thêm dữ liệu con 'MATHANGKHUYENMAI'.");
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
    
    	public MethodResult Modify(MATHANGKHUYENMAI entity, bool isCommited,bool isModifyChild)
    	{
                MethodResult result = MethodResult.Succeed;
                try
                {
    
                 if(isCommited)
    				_unitOfWork.BeginTransaction();
    
                    entity.Validate();
    
                    _MATHANGKHUYENMAIRepository.Update(Clone(entity));
    				if (SaveChanges() <= 0)
                    {
                        ThrowException("Không thể sửa dữ liệu 'MATHANGKHUYENMAI'.");
                    }
    
    				if(isModifyChild)
    				{
    				
    
    					 if (SaveChanges() <= 0)
    					{
    						ThrowException("Không thể sửa dữ liệu con 'MATHANGKHUYENMAI'.");
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
    
    
                    MATHANGKHUYENMAI entity = Find(idUnit);
    
                    if (entity == null)
                    {
                        ThrowException("Dữ liệu 'MATHANGKHUYENMAI' này không tồn tại trong hệ thống.");
                    }
    				if(isRemoveChild)
    				{
    				
    
    				    if (SaveChanges() <= 0)
    					{
    						ThrowException("Không thể xóa dữ liệu con 'MATHANGKHUYENMAI'.");
    					}
    				}
    
                    _MATHANGKHUYENMAIRepository.Delete(Clone(entity));
    
                    if (SaveChanges() <= 0)
                    {
                        ThrowException("Không thể xóa dữ liệu 'MATHANGKHUYENMAI'.");
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
    
    		public MethodResult Remove(MATHANGKHUYENMAI model, bool isCommited,bool isRemoveChild)
            {
                MethodResult result = MethodResult.Succeed;
    
                try
                {
                    if(isCommited)
    						_unitOfWork.BeginTransaction();
    
    
                    MATHANGKHUYENMAI entity = Find(model.IDUnit);
    
                    if (entity == null)
                    {
                        ThrowException("Dữ liệu 'MATHANGKHUYENMAI' này không tồn tại trong hệ thống.");
                    }
    
    				if(isRemoveChild)
    				{
    				
    
    					if (SaveChanges() <= 0)
    					{
    						ThrowException("Không thể xóa dữ liệu con 'MATHANGKHUYENMAI'.");
    					}
    				}
                    _MATHANGKHUYENMAIRepository.Delete(Clone(entity));
    
                    if (SaveChanges() <= 0)
                    {
                        ThrowException("Không thể xóa dữ liệu 'MATHANGKHUYENMAI'.");
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
