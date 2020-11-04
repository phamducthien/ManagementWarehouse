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
    public partial interface IDONVIService : IService
    {
    	bool Exist(string id);
    	bool Exist(Expression<Func<DONVI, bool>> predicate);
    
    	DONVI CreateNew();
        List<DONVI> FindAll();
    	List<DONVI> Search(string textSearch);
    	List<DONVI> Search(Expression<Func<DONVI, bool>> predicate,string textSearch);
        List<DONVI> Search(Expression<Func<DONVI, bool>> predicate);
    	
    	DONVI Find(string idUnit);
    	DONVI Find(Expression<Func<DONVI, bool>> predicate);
    
    	//DONVI CloneNew(DONVI objDONVI);
    	//DONVI CloneUpdate(DONVI objDONVI);
    	DONVI Clone(DONVI objDONVI);
    	List< DONVI> Clone(IList<DONVI> listDONVIs);
    
        MethodResult Add(DONVI model, bool isCommited = false,bool isAddChild = false);
        MethodResult Modify(DONVI model, bool isCommited= false,bool isModifyChild = false);
    	MethodResult Remove(DONVI model, bool isCommited = false,bool isRemoveChild = false);
        MethodResult Remove(string idUnit, bool isCommited = false,bool isRemoveChild = false);
    }
    
    public partial class DONVIService : global::Service.Pattern.Service, IDONVIService
    {
    	protected string userId = SessionModel.CurrentSession?.UserId;
    	protected IDONVIRepository _DONVIRepository;
    		protected IMATHANGRepository  _MATHANGRepository;
	
    
    	public DONVIService(IUnitOfWorkAsync unitOfWork)
                : base(unitOfWork)
        {
        }
    
        protected override void InitRepositories()
        {
            _DONVIRepository = new DONVIRepository(this._dataContext, this._unitOfWork);
    			_MATHANGRepository = new MATHANGRepository(this._dataContext, this._unitOfWork);
		
        }
    	
    	public bool Exist(string id)
        {
    		return _DONVIRepository.Exist(id);
        }
    
    	public bool Exist(Expression<Func<DONVI, bool>> predicate)
    	{
    		return _DONVIRepository.Exist(predicate);
    	}
    
        public DONVI CreateNew()
        {
            return _DONVIRepository.CreateNew();
        }
    
    	public List<DONVI> FindAll()
    	{
    		return _DONVIRepository.FindAll();
    	}
    
    	public List<DONVI> Search(string textSearch)
        {
            return _DONVIRepository.Search(textSearch);
        }
    
    	public List<DONVI> Search(Expression<Func<DONVI, bool>> predicate,string textSearch)
    	{
    		  return _DONVIRepository.Search(predicate, textSearch);
    	}
    
    		public DONVI Find(Expression<Func<DONVI, bool>> predicate)
            {
               return _DONVIRepository.getObject(predicate);
            }
    
            public List<DONVI> Search(Expression<Func<DONVI, bool>> predicate)
            {
                return _DONVIRepository.Search(predicate);
            }
    
            //public DONVI CloneNew(DONVI objDONVI)
           // {
           //     return _DONVIRepository.CloneNew(objDONVI);
           // }
    
    	//	public DONVI CloneUpdate(DONVI objDONVI)
    	//	{
    	//		  return _DONVIRepository.CloneUpdate(objDONVI);
    	//	}
    
    		public DONVI Clone(DONVI objDONVI)
    		{
    			return _DONVIRepository.Clone(objDONVI);
    		}
    
            public List<DONVI> Clone(IList<DONVI> listDONVIs)
            {
                return _DONVIRepository.Clone(listDONVIs);
            }
    
        public DONVI Find(string idUnit)
        {
    		return _DONVIRepository.getObject(idUnit);
        }
    
    	public MethodResult Add(DONVI entity, bool isCommited,bool isAddChild)
        {
    		MethodResult result = MethodResult.Succeed;
    		try
    		{
    			if(isCommited)
    				_unitOfWork.BeginTransaction();
    
    			entity.Validate();
    
    			_DONVIRepository.Insert(Clone(entity));
    			if (SaveChanges() <= 0)
    			{
    				ThrowException("Không thể thêm dữ liệu 'DONVI'.");
    			}
    
    			if(isAddChild)
    			{
    			List<MATHANG> lstMATHANGs = _MATHANGRepository.Clone(entity.MATHANGs);
	 foreach( var obj in lstMATHANGs ) 
{
MATHANG objMATHANG = _MATHANGRepository.CloneNew(obj);
 if (objMATHANG != null)
{
 _MATHANGRepository.Insert(objMATHANG);
}
}

List<MATHANG> lstMATHANGs1 = _MATHANGRepository.Clone(entity.MATHANGs1);
	 foreach( var obj in lstMATHANGs1 ) 
{
MATHANG objMATHANG = _MATHANGRepository.CloneNew(obj);
 if (objMATHANG != null)
{
 _MATHANGRepository.Insert(objMATHANG);
}
}


    
    				if (SaveChanges() <= 0)
    				{
    					ThrowException("Không thể thêm dữ liệu con 'DONVI'.");
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
    
    	public MethodResult Modify(DONVI entity, bool isCommited,bool isModifyChild)
    	{
                MethodResult result = MethodResult.Succeed;
                try
                {
    
                 if(isCommited)
    				_unitOfWork.BeginTransaction();
    
                    entity.Validate();
    
                    _DONVIRepository.Update(Clone(entity));
    				if (SaveChanges() <= 0)
                    {
                        ThrowException("Không thể sửa dữ liệu 'DONVI'.");
                    }
    
    				if(isModifyChild)
    				{
    				List<MATHANG> lstMATHANGs = _MATHANGRepository.Clone(entity.MATHANGs);
	 foreach( var obj in lstMATHANGs ) 
{
MATHANG objMATHANG = _MATHANGRepository.CloneUpdate(obj);
 if (objMATHANG != null)
{
 _MATHANGRepository.Update(objMATHANG);
}
}

List<MATHANG> lstMATHANGs1 = _MATHANGRepository.Clone(entity.MATHANGs1);
	 foreach( var obj in lstMATHANGs1 ) 
{
MATHANG objMATHANG = _MATHANGRepository.CloneUpdate(obj);
 if (objMATHANG != null)
{
 _MATHANGRepository.Update(objMATHANG);
}
}


    
    					 if (SaveChanges() <= 0)
    					{
    						ThrowException("Không thể sửa dữ liệu con 'DONVI'.");
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
    
    
                    DONVI entity = Find(idUnit);
    
                    if (entity == null)
                    {
                        ThrowException("Dữ liệu 'DONVI' này không tồn tại trong hệ thống.");
                    }
    				if(isRemoveChild)
    				{
    				List<MATHANG> lstMATHANGs = _MATHANGRepository.Clone(entity.MATHANGs);
	 foreach( var obj in lstMATHANGs ) 
{
MATHANG objMATHANG = _MATHANGRepository.Clone(obj);
 if (objMATHANG != null)
{
 _MATHANGRepository.Delete(objMATHANG);
}
}

List<MATHANG> lstMATHANGs1 = _MATHANGRepository.Clone(entity.MATHANGs1);
	 foreach( var obj in lstMATHANGs1 ) 
{
MATHANG objMATHANG = _MATHANGRepository.Clone(obj);
 if (objMATHANG != null)
{
 _MATHANGRepository.Delete(objMATHANG);
}
}


    
    				    if (SaveChanges() <= 0)
    					{
    						ThrowException("Không thể xóa dữ liệu con 'DONVI'.");
    					}
    				}
    
                    _DONVIRepository.Delete(Clone(entity));
    
                    if (SaveChanges() <= 0)
                    {
                        ThrowException("Không thể xóa dữ liệu 'DONVI'.");
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
    
    		public MethodResult Remove(DONVI model, bool isCommited,bool isRemoveChild)
            {
                MethodResult result = MethodResult.Succeed;
    
                try
                {
                    if(isCommited)
    						_unitOfWork.BeginTransaction();
    
    
                    DONVI entity = Find(model.IDUnit);
    
                    if (entity == null)
                    {
                        ThrowException("Dữ liệu 'DONVI' này không tồn tại trong hệ thống.");
                    }
    
    				if(isRemoveChild)
    				{
    				List<MATHANG> lstMATHANGs = _MATHANGRepository.Clone(entity.MATHANGs);
	 foreach( var obj in lstMATHANGs ) 
{
MATHANG objMATHANG = _MATHANGRepository.Clone(obj);
 if (objMATHANG != null)
{
 _MATHANGRepository.Delete(objMATHANG);
}
}

List<MATHANG> lstMATHANGs1 = _MATHANGRepository.Clone(entity.MATHANGs1);
	 foreach( var obj in lstMATHANGs1 ) 
{
MATHANG objMATHANG = _MATHANGRepository.Clone(obj);
 if (objMATHANG != null)
{
 _MATHANGRepository.Delete(objMATHANG);
}
}


    
    					if (SaveChanges() <= 0)
    					{
    						ThrowException("Không thể xóa dữ liệu con 'DONVI'.");
    					}
    				}
                    _DONVIRepository.Delete(Clone(entity));
    
                    if (SaveChanges() <= 0)
                    {
                        ThrowException("Không thể xóa dữ liệu 'DONVI'.");
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
