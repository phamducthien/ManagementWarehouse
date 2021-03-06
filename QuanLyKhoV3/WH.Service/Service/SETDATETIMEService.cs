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
    public partial interface ISETDATETIMEService : IService
    {
    	bool Exist(string id);
    	bool Exist(Expression<Func<SETDATETIME, bool>> predicate);
    
    	SETDATETIME CreateNew();
        List<SETDATETIME> FindAll();
    	List<SETDATETIME> Search(string textSearch);
    	List<SETDATETIME> Search(Expression<Func<SETDATETIME, bool>> predicate,string textSearch);
        List<SETDATETIME> Search(Expression<Func<SETDATETIME, bool>> predicate);
    	
    	SETDATETIME Find(string idUnit);
    	SETDATETIME Find(Expression<Func<SETDATETIME, bool>> predicate);
    
    	//SETDATETIME CloneNew(SETDATETIME objSETDATETIME);
    	//SETDATETIME CloneUpdate(SETDATETIME objSETDATETIME);
    	SETDATETIME Clone(SETDATETIME objSETDATETIME);
    	List< SETDATETIME> Clone(IList<SETDATETIME> listSETDATETIMEs);
    
        MethodResult Add(SETDATETIME model, bool isCommited = false,bool isAddChild = false);
        MethodResult Modify(SETDATETIME model, bool isCommited= false,bool isModifyChild = false);
    	MethodResult Remove(SETDATETIME model, bool isCommited = false,bool isRemoveChild = false);
        MethodResult Remove(string idUnit, bool isCommited = false,bool isRemoveChild = false);
    }
    
    public partial class SETDATETIMEService : global::Service.Pattern.Service, ISETDATETIMEService
    {
    	protected string userId = SessionModel.CurrentSession?.UserId;
    	protected ISETDATETIMERepository _SETDATETIMERepository;
    	
    
    	public SETDATETIMEService(IUnitOfWorkAsync unitOfWork)
                : base(unitOfWork)
        {
        }
    
        protected override void InitRepositories()
        {
            _SETDATETIMERepository = new SETDATETIMERepository(this._dataContext, this._unitOfWork);
    		
        }
    	
    	public bool Exist(string id)
        {
    		return _SETDATETIMERepository.Exist(id);
        }
    
    	public bool Exist(Expression<Func<SETDATETIME, bool>> predicate)
    	{
    		return _SETDATETIMERepository.Exist(predicate);
    	}
    
        public SETDATETIME CreateNew()
        {
            return _SETDATETIMERepository.CreateNew();
        }
    
    	public List<SETDATETIME> FindAll()
    	{
    		return _SETDATETIMERepository.FindAll();
    	}
    
    	public List<SETDATETIME> Search(string textSearch)
        {
            return _SETDATETIMERepository.Search(textSearch);
        }
    
    	public List<SETDATETIME> Search(Expression<Func<SETDATETIME, bool>> predicate,string textSearch)
    	{
    		  return _SETDATETIMERepository.Search(predicate, textSearch);
    	}
    
    		public SETDATETIME Find(Expression<Func<SETDATETIME, bool>> predicate)
            {
               return _SETDATETIMERepository.getObject(predicate);
            }
    
            public List<SETDATETIME> Search(Expression<Func<SETDATETIME, bool>> predicate)
            {
                return _SETDATETIMERepository.Search(predicate);
            }
    
            //public SETDATETIME CloneNew(SETDATETIME objSETDATETIME)
           // {
           //     return _SETDATETIMERepository.CloneNew(objSETDATETIME);
           // }
    
    	//	public SETDATETIME CloneUpdate(SETDATETIME objSETDATETIME)
    	//	{
    	//		  return _SETDATETIMERepository.CloneUpdate(objSETDATETIME);
    	//	}
    
    		public SETDATETIME Clone(SETDATETIME objSETDATETIME)
    		{
    			return _SETDATETIMERepository.Clone(objSETDATETIME);
    		}
    
            public List<SETDATETIME> Clone(IList<SETDATETIME> listSETDATETIMEs)
            {
                return _SETDATETIMERepository.Clone(listSETDATETIMEs);
            }
    
        public SETDATETIME Find(string idUnit)
        {
    		return _SETDATETIMERepository.getObject(idUnit);
        }
    
    	public MethodResult Add(SETDATETIME entity, bool isCommited,bool isAddChild)
        {
    		MethodResult result = MethodResult.Succeed;
    		try
    		{
    			if(isCommited)
    				_unitOfWork.BeginTransaction();
    
    			entity.Validate();
    
    			_SETDATETIMERepository.Insert(Clone(entity));
    			if (SaveChanges() <= 0)
    			{
    				ThrowException("Không thể thêm dữ liệu 'SETDATETIME'.");
    			}
    
    			if(isAddChild)
    			{
    			
    
    				if (SaveChanges() <= 0)
    				{
    					ThrowException("Không thể thêm dữ liệu con 'SETDATETIME'.");
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
    
    	public MethodResult Modify(SETDATETIME entity, bool isCommited,bool isModifyChild)
    	{
                MethodResult result = MethodResult.Succeed;
                try
                {
    
                 if(isCommited)
    				_unitOfWork.BeginTransaction();
    
                    entity.Validate();
    
                    _SETDATETIMERepository.Update(Clone(entity));
    				if (SaveChanges() <= 0)
                    {
                        ThrowException("Không thể sửa dữ liệu 'SETDATETIME'.");
                    }
    
    				if(isModifyChild)
    				{
    				
    
    					 if (SaveChanges() <= 0)
    					{
    						ThrowException("Không thể sửa dữ liệu con 'SETDATETIME'.");
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
    
    
                    SETDATETIME entity = Find(idUnit);
    
                    if (entity == null)
                    {
                        ThrowException("Dữ liệu 'SETDATETIME' này không tồn tại trong hệ thống.");
                    }
    				if(isRemoveChild)
    				{
    				
    
    				    if (SaveChanges() <= 0)
    					{
    						ThrowException("Không thể xóa dữ liệu con 'SETDATETIME'.");
    					}
    				}
    
                    _SETDATETIMERepository.Delete(Clone(entity));
    
                    if (SaveChanges() <= 0)
                    {
                        ThrowException("Không thể xóa dữ liệu 'SETDATETIME'.");
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
    
    		public MethodResult Remove(SETDATETIME model, bool isCommited,bool isRemoveChild)
            {
                MethodResult result = MethodResult.Succeed;
    
                try
                {
                    if(isCommited)
    						_unitOfWork.BeginTransaction();
    
    
                    SETDATETIME entity = Find(model.IDUnit);
    
                    if (entity == null)
                    {
                        ThrowException("Dữ liệu 'SETDATETIME' này không tồn tại trong hệ thống.");
                    }
    
    				if(isRemoveChild)
    				{
    				
    
    					if (SaveChanges() <= 0)
    					{
    						ThrowException("Không thể xóa dữ liệu con 'SETDATETIME'.");
    					}
    				}
                    _SETDATETIMERepository.Delete(Clone(entity));
    
                    if (SaveChanges() <= 0)
                    {
                        ThrowException("Không thể xóa dữ liệu 'SETDATETIME'.");
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
