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
    public partial interface ILOAINHANVIENService : IService
    {
    	bool Exist(string id);
    	bool Exist(Expression<Func<LOAINHANVIEN, bool>> predicate);
    
    	LOAINHANVIEN CreateNew();
        List<LOAINHANVIEN> FindAll();
    	List<LOAINHANVIEN> Search(string textSearch);
    	List<LOAINHANVIEN> Search(Expression<Func<LOAINHANVIEN, bool>> predicate,string textSearch);
        List<LOAINHANVIEN> Search(Expression<Func<LOAINHANVIEN, bool>> predicate);
    	
    	LOAINHANVIEN Find(string idUnit);
    	LOAINHANVIEN Find(Expression<Func<LOAINHANVIEN, bool>> predicate);
    
    	//LOAINHANVIEN CloneNew(LOAINHANVIEN objLOAINHANVIEN);
    	//LOAINHANVIEN CloneUpdate(LOAINHANVIEN objLOAINHANVIEN);
    	LOAINHANVIEN Clone(LOAINHANVIEN objLOAINHANVIEN);
    	List< LOAINHANVIEN> Clone(IList<LOAINHANVIEN> listLOAINHANVIENs);
    
        MethodResult Add(LOAINHANVIEN model, bool isCommited = false,bool isAddChild = false);
        MethodResult Modify(LOAINHANVIEN model, bool isCommited= false,bool isModifyChild = false);
    	MethodResult Remove(LOAINHANVIEN model, bool isCommited = false,bool isRemoveChild = false);
        MethodResult Remove(string idUnit, bool isCommited = false,bool isRemoveChild = false);
    }
    
    public partial class LOAINHANVIENService : global::Service.Pattern.Service, ILOAINHANVIENService
    {
    	protected string userId = SessionModel.CurrentSession?.UserId;
    	protected ILOAINHANVIENRepository _LOAINHANVIENRepository;
    		protected INHANVIENRepository  _NHANVIENRepository;
	
    
    	public LOAINHANVIENService(IUnitOfWorkAsync unitOfWork)
                : base(unitOfWork)
        {
        }
    
        protected override void InitRepositories()
        {
            _LOAINHANVIENRepository = new LOAINHANVIENRepository(this._dataContext, this._unitOfWork);
    			_NHANVIENRepository = new NHANVIENRepository(this._dataContext, this._unitOfWork);
		
        }
    	
    	public bool Exist(string id)
        {
    		return _LOAINHANVIENRepository.Exist(id);
        }
    
    	public bool Exist(Expression<Func<LOAINHANVIEN, bool>> predicate)
    	{
    		return _LOAINHANVIENRepository.Exist(predicate);
    	}
    
        public LOAINHANVIEN CreateNew()
        {
            return _LOAINHANVIENRepository.CreateNew();
        }
    
    	public List<LOAINHANVIEN> FindAll()
    	{
    		return _LOAINHANVIENRepository.FindAll();
    	}
    
    	public List<LOAINHANVIEN> Search(string textSearch)
        {
            return _LOAINHANVIENRepository.Search(textSearch);
        }
    
    	public List<LOAINHANVIEN> Search(Expression<Func<LOAINHANVIEN, bool>> predicate,string textSearch)
    	{
    		  return _LOAINHANVIENRepository.Search(predicate, textSearch);
    	}
    
    		public LOAINHANVIEN Find(Expression<Func<LOAINHANVIEN, bool>> predicate)
            {
               return _LOAINHANVIENRepository.getObject(predicate);
            }
    
            public List<LOAINHANVIEN> Search(Expression<Func<LOAINHANVIEN, bool>> predicate)
            {
                return _LOAINHANVIENRepository.Search(predicate);
            }
    
            //public LOAINHANVIEN CloneNew(LOAINHANVIEN objLOAINHANVIEN)
           // {
           //     return _LOAINHANVIENRepository.CloneNew(objLOAINHANVIEN);
           // }
    
    	//	public LOAINHANVIEN CloneUpdate(LOAINHANVIEN objLOAINHANVIEN)
    	//	{
    	//		  return _LOAINHANVIENRepository.CloneUpdate(objLOAINHANVIEN);
    	//	}
    
    		public LOAINHANVIEN Clone(LOAINHANVIEN objLOAINHANVIEN)
    		{
    			return _LOAINHANVIENRepository.Clone(objLOAINHANVIEN);
    		}
    
            public List<LOAINHANVIEN> Clone(IList<LOAINHANVIEN> listLOAINHANVIENs)
            {
                return _LOAINHANVIENRepository.Clone(listLOAINHANVIENs);
            }
    
        public LOAINHANVIEN Find(string idUnit)
        {
    		return _LOAINHANVIENRepository.getObject(idUnit);
        }
    
    	public MethodResult Add(LOAINHANVIEN entity, bool isCommited,bool isAddChild)
        {
    		MethodResult result = MethodResult.Succeed;
    		try
    		{
    			if(isCommited)
    				_unitOfWork.BeginTransaction();
    
    			entity.Validate();
    
    			_LOAINHANVIENRepository.Insert(Clone(entity));
    			if (SaveChanges() <= 0)
    			{
    				ThrowException("Không thể thêm dữ liệu 'LOAINHANVIEN'.");
    			}
    
    			if(isAddChild)
    			{
    			List<NHANVIEN> lstNHANVIENs = _NHANVIENRepository.Clone(entity.NHANVIENs);
	 foreach( var obj in lstNHANVIENs ) 
{
NHANVIEN objNHANVIEN = _NHANVIENRepository.CloneNew(obj);
 if (objNHANVIEN != null)
{
 _NHANVIENRepository.Insert(objNHANVIEN);
}
}


    
    				if (SaveChanges() <= 0)
    				{
    					ThrowException("Không thể thêm dữ liệu con 'LOAINHANVIEN'.");
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
    
    	public MethodResult Modify(LOAINHANVIEN entity, bool isCommited,bool isModifyChild)
    	{
                MethodResult result = MethodResult.Succeed;
                try
                {
    
                 if(isCommited)
    				_unitOfWork.BeginTransaction();
    
                    entity.Validate();
    
                    _LOAINHANVIENRepository.Update(Clone(entity));
    				if (SaveChanges() <= 0)
                    {
                        ThrowException("Không thể sửa dữ liệu 'LOAINHANVIEN'.");
                    }
    
    				if(isModifyChild)
    				{
    				List<NHANVIEN> lstNHANVIENs = _NHANVIENRepository.Clone(entity.NHANVIENs);
	 foreach( var obj in lstNHANVIENs ) 
{
NHANVIEN objNHANVIEN = _NHANVIENRepository.CloneUpdate(obj);
 if (objNHANVIEN != null)
{
 _NHANVIENRepository.Update(objNHANVIEN);
}
}


    
    					 if (SaveChanges() <= 0)
    					{
    						ThrowException("Không thể sửa dữ liệu con 'LOAINHANVIEN'.");
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
    
    
                    LOAINHANVIEN entity = Find(idUnit);
    
                    if (entity == null)
                    {
                        ThrowException("Dữ liệu 'LOAINHANVIEN' này không tồn tại trong hệ thống.");
                    }
    				if(isRemoveChild)
    				{
    				List<NHANVIEN> lstNHANVIENs = _NHANVIENRepository.Clone(entity.NHANVIENs);
	 foreach( var obj in lstNHANVIENs ) 
{
NHANVIEN objNHANVIEN = _NHANVIENRepository.Clone(obj);
 if (objNHANVIEN != null)
{
 _NHANVIENRepository.Delete(objNHANVIEN);
}
}


    
    				    if (SaveChanges() <= 0)
    					{
    						ThrowException("Không thể xóa dữ liệu con 'LOAINHANVIEN'.");
    					}
    				}
    
                    _LOAINHANVIENRepository.Delete(Clone(entity));
    
                    if (SaveChanges() <= 0)
                    {
                        ThrowException("Không thể xóa dữ liệu 'LOAINHANVIEN'.");
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
    
    		public MethodResult Remove(LOAINHANVIEN model, bool isCommited,bool isRemoveChild)
            {
                MethodResult result = MethodResult.Succeed;
    
                try
                {
                    if(isCommited)
    						_unitOfWork.BeginTransaction();
    
    
                    LOAINHANVIEN entity = Find(model.IDUnit);
    
                    if (entity == null)
                    {
                        ThrowException("Dữ liệu 'LOAINHANVIEN' này không tồn tại trong hệ thống.");
                    }
    
    				if(isRemoveChild)
    				{
    				List<NHANVIEN> lstNHANVIENs = _NHANVIENRepository.Clone(entity.NHANVIENs);
	 foreach( var obj in lstNHANVIENs ) 
{
NHANVIEN objNHANVIEN = _NHANVIENRepository.Clone(obj);
 if (objNHANVIEN != null)
{
 _NHANVIENRepository.Delete(objNHANVIEN);
}
}


    
    					if (SaveChanges() <= 0)
    					{
    						ThrowException("Không thể xóa dữ liệu con 'LOAINHANVIEN'.");
    					}
    				}
                    _LOAINHANVIENRepository.Delete(Clone(entity));
    
                    if (SaveChanges() <= 0)
                    {
                        ThrowException("Không thể xóa dữ liệu 'LOAINHANVIEN'.");
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
