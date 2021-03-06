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
    public partial interface ICHUCNANGService : IService
    {
    	bool Exist(string id);
    	bool Exist(Expression<Func<CHUCNANG, bool>> predicate);
    
    	CHUCNANG CreateNew();
        List<CHUCNANG> FindAll();
    	List<CHUCNANG> Search(string textSearch);
    	List<CHUCNANG> Search(Expression<Func<CHUCNANG, bool>> predicate,string textSearch);
        List<CHUCNANG> Search(Expression<Func<CHUCNANG, bool>> predicate);
    	
    	CHUCNANG Find(string idUnit);
    	CHUCNANG Find(Expression<Func<CHUCNANG, bool>> predicate);
    
    	//CHUCNANG CloneNew(CHUCNANG objCHUCNANG);
    	//CHUCNANG CloneUpdate(CHUCNANG objCHUCNANG);
    	CHUCNANG Clone(CHUCNANG objCHUCNANG);
    	List< CHUCNANG> Clone(IList<CHUCNANG> listCHUCNANGs);
    
        MethodResult Add(CHUCNANG model, bool isCommited = false,bool isAddChild = false);
        MethodResult Modify(CHUCNANG model, bool isCommited= false,bool isModifyChild = false);
    	MethodResult Remove(CHUCNANG model, bool isCommited = false,bool isRemoveChild = false);
        MethodResult Remove(string idUnit, bool isCommited = false,bool isRemoveChild = false);
    }
    
    public partial class CHUCNANGService : global::Service.Pattern.Service, ICHUCNANGService
    {
    	protected string userId = SessionModel.CurrentSession?.UserId;
    	protected ICHUCNANGRepository _CHUCNANGRepository;
    		protected INGUOIDUNG_QUYENHANRepository  _NGUOIDUNG_QUYENHANRepository;
	
    
    	public CHUCNANGService(IUnitOfWorkAsync unitOfWork)
                : base(unitOfWork)
        {
        }
    
        protected override void InitRepositories()
        {
            _CHUCNANGRepository = new CHUCNANGRepository(this._dataContext, this._unitOfWork);
    			_NGUOIDUNG_QUYENHANRepository = new NGUOIDUNG_QUYENHANRepository(this._dataContext, this._unitOfWork);
		
        }
    	
    	public bool Exist(string id)
        {
    		return _CHUCNANGRepository.Exist(id);
        }
    
    	public bool Exist(Expression<Func<CHUCNANG, bool>> predicate)
    	{
    		return _CHUCNANGRepository.Exist(predicate);
    	}
    
        public CHUCNANG CreateNew()
        {
            return _CHUCNANGRepository.CreateNew();
        }
    
    	public List<CHUCNANG> FindAll()
    	{
    		return _CHUCNANGRepository.FindAll();
    	}
    
    	public List<CHUCNANG> Search(string textSearch)
        {
            return _CHUCNANGRepository.Search(textSearch);
        }
    
    	public List<CHUCNANG> Search(Expression<Func<CHUCNANG, bool>> predicate,string textSearch)
    	{
    		  return _CHUCNANGRepository.Search(predicate, textSearch);
    	}
    
    		public CHUCNANG Find(Expression<Func<CHUCNANG, bool>> predicate)
            {
               return _CHUCNANGRepository.getObject(predicate);
            }
    
            public List<CHUCNANG> Search(Expression<Func<CHUCNANG, bool>> predicate)
            {
                return _CHUCNANGRepository.Search(predicate);
            }
    
            //public CHUCNANG CloneNew(CHUCNANG objCHUCNANG)
           // {
           //     return _CHUCNANGRepository.CloneNew(objCHUCNANG);
           // }
    
    	//	public CHUCNANG CloneUpdate(CHUCNANG objCHUCNANG)
    	//	{
    	//		  return _CHUCNANGRepository.CloneUpdate(objCHUCNANG);
    	//	}
    
    		public CHUCNANG Clone(CHUCNANG objCHUCNANG)
    		{
    			return _CHUCNANGRepository.Clone(objCHUCNANG);
    		}
    
            public List<CHUCNANG> Clone(IList<CHUCNANG> listCHUCNANGs)
            {
                return _CHUCNANGRepository.Clone(listCHUCNANGs);
            }
    
        public CHUCNANG Find(string idUnit)
        {
    		return _CHUCNANGRepository.getObject(idUnit);
        }
    
    	public MethodResult Add(CHUCNANG entity, bool isCommited,bool isAddChild)
        {
    		MethodResult result = MethodResult.Succeed;
    		try
    		{
    			if(isCommited)
    				_unitOfWork.BeginTransaction();
    
    			entity.Validate();
    
    			_CHUCNANGRepository.Insert(Clone(entity));
    			if (SaveChanges() <= 0)
    			{
    				ThrowException("Không thể thêm dữ liệu 'CHUCNANG'.");
    			}
    
    			if(isAddChild)
    			{
    			List<NGUOIDUNG_QUYENHAN> lstNGUOIDUNG_QUYENHAN = _NGUOIDUNG_QUYENHANRepository.Clone(entity.NGUOIDUNG_QUYENHAN);
	 foreach( var obj in lstNGUOIDUNG_QUYENHAN ) 
{
NGUOIDUNG_QUYENHAN objNGUOIDUNG_QUYENHAN = _NGUOIDUNG_QUYENHANRepository.CloneNew(obj);
 if (objNGUOIDUNG_QUYENHAN != null)
{
 _NGUOIDUNG_QUYENHANRepository.Insert(objNGUOIDUNG_QUYENHAN);
}
}


    
    				if (SaveChanges() <= 0)
    				{
    					ThrowException("Không thể thêm dữ liệu con 'CHUCNANG'.");
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
    
    	public MethodResult Modify(CHUCNANG entity, bool isCommited,bool isModifyChild)
    	{
                MethodResult result = MethodResult.Succeed;
                try
                {
    
                 if(isCommited)
    				_unitOfWork.BeginTransaction();
    
                    entity.Validate();
    
                    _CHUCNANGRepository.Update(Clone(entity));
    				if (SaveChanges() <= 0)
                    {
                        ThrowException("Không thể sửa dữ liệu 'CHUCNANG'.");
                    }
    
    				if(isModifyChild)
    				{
    				List<NGUOIDUNG_QUYENHAN> lstNGUOIDUNG_QUYENHAN = _NGUOIDUNG_QUYENHANRepository.Clone(entity.NGUOIDUNG_QUYENHAN);
	 foreach( var obj in lstNGUOIDUNG_QUYENHAN ) 
{
NGUOIDUNG_QUYENHAN objNGUOIDUNG_QUYENHAN = _NGUOIDUNG_QUYENHANRepository.CloneUpdate(obj);
 if (objNGUOIDUNG_QUYENHAN != null)
{
 _NGUOIDUNG_QUYENHANRepository.Update(objNGUOIDUNG_QUYENHAN);
}
}


    
    					 if (SaveChanges() <= 0)
    					{
    						ThrowException("Không thể sửa dữ liệu con 'CHUCNANG'.");
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
    
    
                    CHUCNANG entity = Find(idUnit);
    
                    if (entity == null)
                    {
                        ThrowException("Dữ liệu 'CHUCNANG' này không tồn tại trong hệ thống.");
                    }
    				if(isRemoveChild)
    				{
    				List<NGUOIDUNG_QUYENHAN> lstNGUOIDUNG_QUYENHAN = _NGUOIDUNG_QUYENHANRepository.Clone(entity.NGUOIDUNG_QUYENHAN);
	 foreach( var obj in lstNGUOIDUNG_QUYENHAN ) 
{
NGUOIDUNG_QUYENHAN objNGUOIDUNG_QUYENHAN = _NGUOIDUNG_QUYENHANRepository.Clone(obj);
 if (objNGUOIDUNG_QUYENHAN != null)
{
 _NGUOIDUNG_QUYENHANRepository.Delete(objNGUOIDUNG_QUYENHAN);
}
}


    
    				    if (SaveChanges() <= 0)
    					{
    						ThrowException("Không thể xóa dữ liệu con 'CHUCNANG'.");
    					}
    				}
    
                    _CHUCNANGRepository.Delete(Clone(entity));
    
                    if (SaveChanges() <= 0)
                    {
                        ThrowException("Không thể xóa dữ liệu 'CHUCNANG'.");
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
    
    		public MethodResult Remove(CHUCNANG model, bool isCommited,bool isRemoveChild)
            {
                MethodResult result = MethodResult.Succeed;
    
                try
                {
                    if(isCommited)
    						_unitOfWork.BeginTransaction();
    
    
                    CHUCNANG entity = Find(model.IDUnit);
    
                    if (entity == null)
                    {
                        ThrowException("Dữ liệu 'CHUCNANG' này không tồn tại trong hệ thống.");
                    }
    
    				if(isRemoveChild)
    				{
    				List<NGUOIDUNG_QUYENHAN> lstNGUOIDUNG_QUYENHAN = _NGUOIDUNG_QUYENHANRepository.Clone(entity.NGUOIDUNG_QUYENHAN);
	 foreach( var obj in lstNGUOIDUNG_QUYENHAN ) 
{
NGUOIDUNG_QUYENHAN objNGUOIDUNG_QUYENHAN = _NGUOIDUNG_QUYENHANRepository.Clone(obj);
 if (objNGUOIDUNG_QUYENHAN != null)
{
 _NGUOIDUNG_QUYENHANRepository.Delete(objNGUOIDUNG_QUYENHAN);
}
}


    
    					if (SaveChanges() <= 0)
    					{
    						ThrowException("Không thể xóa dữ liệu con 'CHUCNANG'.");
    					}
    				}
                    _CHUCNANGRepository.Delete(Clone(entity));
    
                    if (SaveChanges() <= 0)
                    {
                        ThrowException("Không thể xóa dữ liệu 'CHUCNANG'.");
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
