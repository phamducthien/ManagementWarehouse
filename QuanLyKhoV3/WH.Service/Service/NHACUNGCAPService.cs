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
    public partial interface INHACUNGCAPService : IService
    {
    	bool Exist(string id);
    	bool Exist(Expression<Func<NHACUNGCAP, bool>> predicate);
    
    	NHACUNGCAP CreateNew();
        List<NHACUNGCAP> FindAll();
    	List<NHACUNGCAP> Search(string textSearch);
    	List<NHACUNGCAP> Search(Expression<Func<NHACUNGCAP, bool>> predicate,string textSearch);
        List<NHACUNGCAP> Search(Expression<Func<NHACUNGCAP, bool>> predicate);
    	
    	NHACUNGCAP Find(string idUnit);
    	NHACUNGCAP Find(Expression<Func<NHACUNGCAP, bool>> predicate);
    
    	//NHACUNGCAP CloneNew(NHACUNGCAP objNHACUNGCAP);
    	//NHACUNGCAP CloneUpdate(NHACUNGCAP objNHACUNGCAP);
    	NHACUNGCAP Clone(NHACUNGCAP objNHACUNGCAP);
    	List< NHACUNGCAP> Clone(IList<NHACUNGCAP> listNHACUNGCAPs);
    
        MethodResult Add(NHACUNGCAP model, bool isCommited = false,bool isAddChild = false);
        MethodResult Modify(NHACUNGCAP model, bool isCommited= false,bool isModifyChild = false);
    	MethodResult Remove(NHACUNGCAP model, bool isCommited = false,bool isRemoveChild = false);
        MethodResult Remove(string idUnit, bool isCommited = false,bool isRemoveChild = false);
    }
    
    public partial class NHACUNGCAPService : global::Service.Pattern.Service, INHACUNGCAPService
    {
    	protected string userId = SessionModel.CurrentSession?.UserId;
    	protected INHACUNGCAPRepository _NHACUNGCAPRepository;
    		protected IHOADONNHAPKHORepository  _HOADONNHAPKHORepository;
	
    
    	public NHACUNGCAPService(IUnitOfWorkAsync unitOfWork)
                : base(unitOfWork)
        {
        }
    
        protected override void InitRepositories()
        {
            _NHACUNGCAPRepository = new NHACUNGCAPRepository(this._dataContext, this._unitOfWork);
    			_HOADONNHAPKHORepository = new HOADONNHAPKHORepository(this._dataContext, this._unitOfWork);
		
        }
    	
    	public bool Exist(string id)
        {
    		return _NHACUNGCAPRepository.Exist(id);
        }
    
    	public bool Exist(Expression<Func<NHACUNGCAP, bool>> predicate)
    	{
    		return _NHACUNGCAPRepository.Exist(predicate);
    	}
    
        public NHACUNGCAP CreateNew()
        {
            return _NHACUNGCAPRepository.CreateNew();
        }
    
    	public List<NHACUNGCAP> FindAll()
    	{
    		return _NHACUNGCAPRepository.FindAll();
    	}
    
    	public List<NHACUNGCAP> Search(string textSearch)
        {
            return _NHACUNGCAPRepository.Search(textSearch);
        }
    
    	public List<NHACUNGCAP> Search(Expression<Func<NHACUNGCAP, bool>> predicate,string textSearch)
    	{
    		  return _NHACUNGCAPRepository.Search(predicate, textSearch);
    	}
    
    		public NHACUNGCAP Find(Expression<Func<NHACUNGCAP, bool>> predicate)
            {
               return _NHACUNGCAPRepository.getObject(predicate);
            }
    
            public List<NHACUNGCAP> Search(Expression<Func<NHACUNGCAP, bool>> predicate)
            {
                return _NHACUNGCAPRepository.Search(predicate);
            }
    
            //public NHACUNGCAP CloneNew(NHACUNGCAP objNHACUNGCAP)
           // {
           //     return _NHACUNGCAPRepository.CloneNew(objNHACUNGCAP);
           // }
    
    	//	public NHACUNGCAP CloneUpdate(NHACUNGCAP objNHACUNGCAP)
    	//	{
    	//		  return _NHACUNGCAPRepository.CloneUpdate(objNHACUNGCAP);
    	//	}
    
    		public NHACUNGCAP Clone(NHACUNGCAP objNHACUNGCAP)
    		{
    			return _NHACUNGCAPRepository.Clone(objNHACUNGCAP);
    		}
    
            public List<NHACUNGCAP> Clone(IList<NHACUNGCAP> listNHACUNGCAPs)
            {
                return _NHACUNGCAPRepository.Clone(listNHACUNGCAPs);
            }
    
        public NHACUNGCAP Find(string idUnit)
        {
    		return _NHACUNGCAPRepository.getObject(idUnit);
        }
    
    	public MethodResult Add(NHACUNGCAP entity, bool isCommited,bool isAddChild)
        {
    		MethodResult result = MethodResult.Succeed;
    		try
    		{
    			if(isCommited)
    				_unitOfWork.BeginTransaction();
    
    			entity.Validate();
    
    			_NHACUNGCAPRepository.Insert(Clone(entity));
    			if (SaveChanges() <= 0)
    			{
    				ThrowException("Không thể thêm dữ liệu 'NHACUNGCAP'.");
    			}
    
    			if(isAddChild)
    			{
    			List<HOADONNHAPKHO> lstHOADONNHAPKHOes = _HOADONNHAPKHORepository.Clone(entity.HOADONNHAPKHOes);
	 foreach( var obj in lstHOADONNHAPKHOes ) 
{
HOADONNHAPKHO objHOADONNHAPKHO = _HOADONNHAPKHORepository.CloneNew(obj);
 if (objHOADONNHAPKHO != null)
{
 _HOADONNHAPKHORepository.Insert(objHOADONNHAPKHO);
}
}


    
    				if (SaveChanges() <= 0)
    				{
    					ThrowException("Không thể thêm dữ liệu con 'NHACUNGCAP'.");
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
    
    	public MethodResult Modify(NHACUNGCAP entity, bool isCommited,bool isModifyChild)
    	{
                MethodResult result = MethodResult.Succeed;
                try
                {
    
                 if(isCommited)
    				_unitOfWork.BeginTransaction();
    
                    entity.Validate();
    
                    _NHACUNGCAPRepository.Update(Clone(entity));
    				if (SaveChanges() <= 0)
                    {
                        ThrowException("Không thể sửa dữ liệu 'NHACUNGCAP'.");
                    }
    
    				if(isModifyChild)
    				{
    				List<HOADONNHAPKHO> lstHOADONNHAPKHOes = _HOADONNHAPKHORepository.Clone(entity.HOADONNHAPKHOes);
	 foreach( var obj in lstHOADONNHAPKHOes ) 
{
HOADONNHAPKHO objHOADONNHAPKHO = _HOADONNHAPKHORepository.CloneUpdate(obj);
 if (objHOADONNHAPKHO != null)
{
 _HOADONNHAPKHORepository.Update(objHOADONNHAPKHO);
}
}


    
    					 if (SaveChanges() <= 0)
    					{
    						ThrowException("Không thể sửa dữ liệu con 'NHACUNGCAP'.");
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
    
    
                    NHACUNGCAP entity = Find(idUnit);
    
                    if (entity == null)
                    {
                        ThrowException("Dữ liệu 'NHACUNGCAP' này không tồn tại trong hệ thống.");
                    }
    				if(isRemoveChild)
    				{
    				List<HOADONNHAPKHO> lstHOADONNHAPKHOes = _HOADONNHAPKHORepository.Clone(entity.HOADONNHAPKHOes);
	 foreach( var obj in lstHOADONNHAPKHOes ) 
{
HOADONNHAPKHO objHOADONNHAPKHO = _HOADONNHAPKHORepository.Clone(obj);
 if (objHOADONNHAPKHO != null)
{
 _HOADONNHAPKHORepository.Delete(objHOADONNHAPKHO);
}
}


    
    				    if (SaveChanges() <= 0)
    					{
    						ThrowException("Không thể xóa dữ liệu con 'NHACUNGCAP'.");
    					}
    				}
    
                    _NHACUNGCAPRepository.Delete(Clone(entity));
    
                    if (SaveChanges() <= 0)
                    {
                        ThrowException("Không thể xóa dữ liệu 'NHACUNGCAP'.");
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
    
    		public MethodResult Remove(NHACUNGCAP model, bool isCommited,bool isRemoveChild)
            {
                MethodResult result = MethodResult.Succeed;
    
                try
                {
                    if(isCommited)
    						_unitOfWork.BeginTransaction();
    
    
                    NHACUNGCAP entity = Find(model.IDUnit);
    
                    if (entity == null)
                    {
                        ThrowException("Dữ liệu 'NHACUNGCAP' này không tồn tại trong hệ thống.");
                    }
    
    				if(isRemoveChild)
    				{
    				List<HOADONNHAPKHO> lstHOADONNHAPKHOes = _HOADONNHAPKHORepository.Clone(entity.HOADONNHAPKHOes);
	 foreach( var obj in lstHOADONNHAPKHOes ) 
{
HOADONNHAPKHO objHOADONNHAPKHO = _HOADONNHAPKHORepository.Clone(obj);
 if (objHOADONNHAPKHO != null)
{
 _HOADONNHAPKHORepository.Delete(objHOADONNHAPKHO);
}
}


    
    					if (SaveChanges() <= 0)
    					{
    						ThrowException("Không thể xóa dữ liệu con 'NHACUNGCAP'.");
    					}
    				}
                    _NHACUNGCAPRepository.Delete(Clone(entity));
    
                    if (SaveChanges() <= 0)
                    {
                        ThrowException("Không thể xóa dữ liệu 'NHACUNGCAP'.");
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
