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
    public partial interface IPHIEUTHUService : IService
    {
    	bool Exist(string id);
    	bool Exist(Expression<Func<PHIEUTHU, bool>> predicate);
    
    	PHIEUTHU CreateNew();
        List<PHIEUTHU> FindAll();
    	List<PHIEUTHU> Search(string textSearch);
    	List<PHIEUTHU> Search(Expression<Func<PHIEUTHU, bool>> predicate,string textSearch);
        List<PHIEUTHU> Search(Expression<Func<PHIEUTHU, bool>> predicate);
    	
    	PHIEUTHU Find(string idUnit);
    	PHIEUTHU Find(Expression<Func<PHIEUTHU, bool>> predicate);
    
    	//PHIEUTHU CloneNew(PHIEUTHU objPHIEUTHU);
    	//PHIEUTHU CloneUpdate(PHIEUTHU objPHIEUTHU);
    	PHIEUTHU Clone(PHIEUTHU objPHIEUTHU);
    	List< PHIEUTHU> Clone(IList<PHIEUTHU> listPHIEUTHUs);
    
        MethodResult Add(PHIEUTHU model, bool isCommited = false,bool isAddChild = false);
        MethodResult Modify(PHIEUTHU model, bool isCommited= false,bool isModifyChild = false);
    	MethodResult Remove(PHIEUTHU model, bool isCommited = false,bool isRemoveChild = false);
        MethodResult Remove(string idUnit, bool isCommited = false,bool isRemoveChild = false);
    }
    
    public partial class PHIEUTHUService : global::Service.Pattern.Service, IPHIEUTHUService
    {
    	protected string userId = SessionModel.CurrentSession?.UserId;
    	protected IPHIEUTHURepository _PHIEUTHURepository;
    	
    
    	public PHIEUTHUService(IUnitOfWorkAsync unitOfWork)
                : base(unitOfWork)
        {
        }
    
        protected override void InitRepositories()
        {
            _PHIEUTHURepository = new PHIEUTHURepository(this._dataContext, this._unitOfWork);
    		
        }
    	
    	public bool Exist(string id)
        {
    		return _PHIEUTHURepository.Exist(id);
        }
    
    	public bool Exist(Expression<Func<PHIEUTHU, bool>> predicate)
    	{
    		return _PHIEUTHURepository.Exist(predicate);
    	}
    
        public PHIEUTHU CreateNew()
        {
            return _PHIEUTHURepository.CreateNew();
        }
    
    	public List<PHIEUTHU> FindAll()
    	{
    		return _PHIEUTHURepository.FindAll();
    	}
    
    	public List<PHIEUTHU> Search(string textSearch)
        {
            return _PHIEUTHURepository.Search(textSearch);
        }
    
    	public List<PHIEUTHU> Search(Expression<Func<PHIEUTHU, bool>> predicate,string textSearch)
    	{
    		  return _PHIEUTHURepository.Search(predicate, textSearch);
    	}
    
    		public PHIEUTHU Find(Expression<Func<PHIEUTHU, bool>> predicate)
            {
               return _PHIEUTHURepository.getObject(predicate);
            }
    
            public List<PHIEUTHU> Search(Expression<Func<PHIEUTHU, bool>> predicate)
            {
                return _PHIEUTHURepository.Search(predicate);
            }
    
            //public PHIEUTHU CloneNew(PHIEUTHU objPHIEUTHU)
           // {
           //     return _PHIEUTHURepository.CloneNew(objPHIEUTHU);
           // }
    
    	//	public PHIEUTHU CloneUpdate(PHIEUTHU objPHIEUTHU)
    	//	{
    	//		  return _PHIEUTHURepository.CloneUpdate(objPHIEUTHU);
    	//	}
    
    		public PHIEUTHU Clone(PHIEUTHU objPHIEUTHU)
    		{
    			return _PHIEUTHURepository.Clone(objPHIEUTHU);
    		}
    
            public List<PHIEUTHU> Clone(IList<PHIEUTHU> listPHIEUTHUs)
            {
                return _PHIEUTHURepository.Clone(listPHIEUTHUs);
            }
    
        public PHIEUTHU Find(string idUnit)
        {
    		return _PHIEUTHURepository.getObject(idUnit);
        }
    
    	public MethodResult Add(PHIEUTHU entity, bool isCommited,bool isAddChild)
        {
    		MethodResult result = MethodResult.Succeed;
    		try
    		{
    			if(isCommited)
    				_unitOfWork.BeginTransaction();
    
    			entity.Validate();
    
    			_PHIEUTHURepository.Insert(Clone(entity));
    			if (SaveChanges() <= 0)
    			{
    				ThrowException("Không thể thêm dữ liệu 'PHIEUTHU'.");
    			}
    
    			if(isAddChild)
    			{
    			
    
    				if (SaveChanges() <= 0)
    				{
    					ThrowException("Không thể thêm dữ liệu con 'PHIEUTHU'.");
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
    
    	public MethodResult Modify(PHIEUTHU entity, bool isCommited,bool isModifyChild)
    	{
                MethodResult result = MethodResult.Succeed;
                try
                {
    
                 if(isCommited)
    				_unitOfWork.BeginTransaction();
    
                    entity.Validate();
    
                    _PHIEUTHURepository.Update(Clone(entity));
    				if (SaveChanges() <= 0)
                    {
                        ThrowException("Không thể sửa dữ liệu 'PHIEUTHU'.");
                    }
    
    				if(isModifyChild)
    				{
    				
    
    					 if (SaveChanges() <= 0)
    					{
    						ThrowException("Không thể sửa dữ liệu con 'PHIEUTHU'.");
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
    
    
                    PHIEUTHU entity = Find(idUnit);
    
                    if (entity == null)
                    {
                        ThrowException("Dữ liệu 'PHIEUTHU' này không tồn tại trong hệ thống.");
                    }
    				if(isRemoveChild)
    				{
    				
    
    				    if (SaveChanges() <= 0)
    					{
    						ThrowException("Không thể xóa dữ liệu con 'PHIEUTHU'.");
    					}
    				}
    
                    _PHIEUTHURepository.Delete(Clone(entity));
    
                    if (SaveChanges() <= 0)
                    {
                        ThrowException("Không thể xóa dữ liệu 'PHIEUTHU'.");
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
    
    		public MethodResult Remove(PHIEUTHU model, bool isCommited,bool isRemoveChild)
            {
                MethodResult result = MethodResult.Succeed;
    
                try
                {
                    if(isCommited)
    						_unitOfWork.BeginTransaction();
    
    
                    PHIEUTHU entity = Find(model.IDUnit);
    
                    if (entity == null)
                    {
                        ThrowException("Dữ liệu 'PHIEUTHU' này không tồn tại trong hệ thống.");
                    }
    
    				if(isRemoveChild)
    				{
    				
    
    					if (SaveChanges() <= 0)
    					{
    						ThrowException("Không thể xóa dữ liệu con 'PHIEUTHU'.");
    					}
    				}
                    _PHIEUTHURepository.Delete(Clone(entity));
    
                    if (SaveChanges() <= 0)
                    {
                        ThrowException("Không thể xóa dữ liệu 'PHIEUTHU'.");
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
