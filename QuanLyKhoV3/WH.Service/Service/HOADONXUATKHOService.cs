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
    public partial interface IHOADONXUATKHOService : IService
    {
    	bool Exist(string id);
    	bool Exist(Expression<Func<HOADONXUATKHO, bool>> predicate);
    
    	HOADONXUATKHO CreateNew();
        List<HOADONXUATKHO> FindAll();
    	List<HOADONXUATKHO> Search(string textSearch);
    	List<HOADONXUATKHO> Search(Expression<Func<HOADONXUATKHO, bool>> predicate,string textSearch);
        List<HOADONXUATKHO> Search(Expression<Func<HOADONXUATKHO, bool>> predicate);
    	
    	HOADONXUATKHO Find(string idUnit);
    	HOADONXUATKHO Find(Expression<Func<HOADONXUATKHO, bool>> predicate);
    
    	//HOADONXUATKHO CloneNew(HOADONXUATKHO objHOADONXUATKHO);
    	//HOADONXUATKHO CloneUpdate(HOADONXUATKHO objHOADONXUATKHO);
    	HOADONXUATKHO Clone(HOADONXUATKHO objHOADONXUATKHO);
    	List< HOADONXUATKHO> Clone(IList<HOADONXUATKHO> listHOADONXUATKHOs);
    
        MethodResult Add(HOADONXUATKHO model, bool isCommited = false,bool isAddChild = false);
        MethodResult Modify(HOADONXUATKHO model, bool isCommited= false,bool isModifyChild = false);
    	MethodResult Remove(HOADONXUATKHO model, bool isCommited = false,bool isRemoveChild = false);
        MethodResult Remove(string idUnit, bool isCommited = false,bool isRemoveChild = false);
    }
    
    public partial class HOADONXUATKHOService : global::Service.Pattern.Service, IHOADONXUATKHOService
    {
    	protected string userId = SessionModel.CurrentSession?.UserId;
    	protected IHOADONXUATKHORepository _HOADONXUATKHORepository;
    		protected IHOADONXUATKHOCHITIETRepository  _HOADONXUATKHOCHITIETRepository;
		protected IPHIEUTHURepository  _PHIEUTHURepository;
	
    
    	public HOADONXUATKHOService(IUnitOfWorkAsync unitOfWork)
                : base(unitOfWork)
        {
        }
    
        protected override void InitRepositories()
        {
            _HOADONXUATKHORepository = new HOADONXUATKHORepository(this._dataContext, this._unitOfWork);
    			_HOADONXUATKHOCHITIETRepository = new HOADONXUATKHOCHITIETRepository(this._dataContext, this._unitOfWork);
			_PHIEUTHURepository = new PHIEUTHURepository(this._dataContext, this._unitOfWork);
		
        }
    	
    	public bool Exist(string id)
        {
    		return _HOADONXUATKHORepository.Exist(id);
        }
    
    	public bool Exist(Expression<Func<HOADONXUATKHO, bool>> predicate)
    	{
    		return _HOADONXUATKHORepository.Exist(predicate);
    	}
    
        public HOADONXUATKHO CreateNew()
        {
            return _HOADONXUATKHORepository.CreateNew();
        }
    
    	public List<HOADONXUATKHO> FindAll()
    	{
    		return _HOADONXUATKHORepository.FindAll();
    	}
    
    	public List<HOADONXUATKHO> Search(string textSearch)
        {
            return _HOADONXUATKHORepository.Search(textSearch);
        }
    
    	public List<HOADONXUATKHO> Search(Expression<Func<HOADONXUATKHO, bool>> predicate,string textSearch)
    	{
    		  return _HOADONXUATKHORepository.Search(predicate, textSearch);
    	}
    
    		public HOADONXUATKHO Find(Expression<Func<HOADONXUATKHO, bool>> predicate)
            {
               return _HOADONXUATKHORepository.getObject(predicate);
            }
    
            public List<HOADONXUATKHO> Search(Expression<Func<HOADONXUATKHO, bool>> predicate)
            {
                return _HOADONXUATKHORepository.Search(predicate);
            }
    
            //public HOADONXUATKHO CloneNew(HOADONXUATKHO objHOADONXUATKHO)
           // {
           //     return _HOADONXUATKHORepository.CloneNew(objHOADONXUATKHO);
           // }
    
    	//	public HOADONXUATKHO CloneUpdate(HOADONXUATKHO objHOADONXUATKHO)
    	//	{
    	//		  return _HOADONXUATKHORepository.CloneUpdate(objHOADONXUATKHO);
    	//	}
    
    		public HOADONXUATKHO Clone(HOADONXUATKHO objHOADONXUATKHO)
    		{
    			return _HOADONXUATKHORepository.Clone(objHOADONXUATKHO);
    		}
    
            public List<HOADONXUATKHO> Clone(IList<HOADONXUATKHO> listHOADONXUATKHOs)
            {
                return _HOADONXUATKHORepository.Clone(listHOADONXUATKHOs);
            }
    
        public HOADONXUATKHO Find(string idUnit)
        {
    		return _HOADONXUATKHORepository.getObject(idUnit);
        }
    
    	public MethodResult Add(HOADONXUATKHO entity, bool isCommited,bool isAddChild)
        {
    		MethodResult result = MethodResult.Succeed;
    		try
    		{
    			if(isCommited)
    				_unitOfWork.BeginTransaction();
    
    			entity.Validate();
    
    			_HOADONXUATKHORepository.Insert(Clone(entity));
    			if (SaveChanges() <= 0)
    			{
    				ThrowException("Không thể thêm dữ liệu 'HOADONXUATKHO'.");
    			}
    
    			if(isAddChild)
    			{
    			List<HOADONXUATKHOCHITIET> lstHOADONXUATKHOCHITIETs = _HOADONXUATKHOCHITIETRepository.Clone(entity.HOADONXUATKHOCHITIETs);
	 foreach( var obj in lstHOADONXUATKHOCHITIETs ) 
{
HOADONXUATKHOCHITIET objHOADONXUATKHOCHITIET = _HOADONXUATKHOCHITIETRepository.CloneNew(obj);
 if (objHOADONXUATKHOCHITIET != null)
{
 _HOADONXUATKHOCHITIETRepository.Insert(objHOADONXUATKHOCHITIET);
}
}

List<PHIEUTHU> lstPHIEUTHUs = _PHIEUTHURepository.Clone(entity.PHIEUTHUs);
	 foreach( var obj in lstPHIEUTHUs ) 
{
PHIEUTHU objPHIEUTHU = _PHIEUTHURepository.CloneNew(obj);
 if (objPHIEUTHU != null)
{
 _PHIEUTHURepository.Insert(objPHIEUTHU);
}
}


    
    				if (SaveChanges() <= 0)
    				{
    					ThrowException("Không thể thêm dữ liệu con 'HOADONXUATKHO'.");
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
    
    	public MethodResult Modify(HOADONXUATKHO entity, bool isCommited,bool isModifyChild)
    	{
                MethodResult result = MethodResult.Succeed;
                try
                {
    
                 if(isCommited)
    				_unitOfWork.BeginTransaction();
    
                    entity.Validate();
    
                    _HOADONXUATKHORepository.Update(Clone(entity));
    				if (SaveChanges() <= 0)
                    {
                        ThrowException("Không thể sửa dữ liệu 'HOADONXUATKHO'.");
                    }
    
    				if(isModifyChild)
    				{
    				List<HOADONXUATKHOCHITIET> lstHOADONXUATKHOCHITIETs = _HOADONXUATKHOCHITIETRepository.Clone(entity.HOADONXUATKHOCHITIETs);
	 foreach( var obj in lstHOADONXUATKHOCHITIETs ) 
{
HOADONXUATKHOCHITIET objHOADONXUATKHOCHITIET = _HOADONXUATKHOCHITIETRepository.CloneUpdate(obj);
 if (objHOADONXUATKHOCHITIET != null)
{
 _HOADONXUATKHOCHITIETRepository.Update(objHOADONXUATKHOCHITIET);
}
}

List<PHIEUTHU> lstPHIEUTHUs = _PHIEUTHURepository.Clone(entity.PHIEUTHUs);
	 foreach( var obj in lstPHIEUTHUs ) 
{
PHIEUTHU objPHIEUTHU = _PHIEUTHURepository.CloneUpdate(obj);
 if (objPHIEUTHU != null)
{
 _PHIEUTHURepository.Update(objPHIEUTHU);
}
}


    
    					 if (SaveChanges() <= 0)
    					{
    						ThrowException("Không thể sửa dữ liệu con 'HOADONXUATKHO'.");
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
    
    
                    HOADONXUATKHO entity = Find(idUnit);
    
                    if (entity == null)
                    {
                        ThrowException("Dữ liệu 'HOADONXUATKHO' này không tồn tại trong hệ thống.");
                    }
    				if(isRemoveChild)
    				{
    				List<HOADONXUATKHOCHITIET> lstHOADONXUATKHOCHITIETs = _HOADONXUATKHOCHITIETRepository.Clone(entity.HOADONXUATKHOCHITIETs);
	 foreach( var obj in lstHOADONXUATKHOCHITIETs ) 
{
HOADONXUATKHOCHITIET objHOADONXUATKHOCHITIET = _HOADONXUATKHOCHITIETRepository.Clone(obj);
 if (objHOADONXUATKHOCHITIET != null)
{
 _HOADONXUATKHOCHITIETRepository.Delete(objHOADONXUATKHOCHITIET);
}
}

List<PHIEUTHU> lstPHIEUTHUs = _PHIEUTHURepository.Clone(entity.PHIEUTHUs);
	 foreach( var obj in lstPHIEUTHUs ) 
{
PHIEUTHU objPHIEUTHU = _PHIEUTHURepository.Clone(obj);
 if (objPHIEUTHU != null)
{
 _PHIEUTHURepository.Delete(objPHIEUTHU);
}
}


    
    				    if (SaveChanges() <= 0)
    					{
    						ThrowException("Không thể xóa dữ liệu con 'HOADONXUATKHO'.");
    					}
    				}
    
                    _HOADONXUATKHORepository.Delete(Clone(entity));
    
                    if (SaveChanges() <= 0)
                    {
                        ThrowException("Không thể xóa dữ liệu 'HOADONXUATKHO'.");
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
    
    		public MethodResult Remove(HOADONXUATKHO model, bool isCommited,bool isRemoveChild)
            {
                MethodResult result = MethodResult.Succeed;
    
                try
                {
                    if(isCommited)
    						_unitOfWork.BeginTransaction();
    
    
                    HOADONXUATKHO entity = Find(model.IDUnit);
    
                    if (entity == null)
                    {
                        ThrowException("Dữ liệu 'HOADONXUATKHO' này không tồn tại trong hệ thống.");
                    }
    
    				if(isRemoveChild)
    				{
    				List<HOADONXUATKHOCHITIET> lstHOADONXUATKHOCHITIETs = _HOADONXUATKHOCHITIETRepository.Clone(entity.HOADONXUATKHOCHITIETs);
	 foreach( var obj in lstHOADONXUATKHOCHITIETs ) 
{
HOADONXUATKHOCHITIET objHOADONXUATKHOCHITIET = _HOADONXUATKHOCHITIETRepository.Clone(obj);
 if (objHOADONXUATKHOCHITIET != null)
{
 _HOADONXUATKHOCHITIETRepository.Delete(objHOADONXUATKHOCHITIET);
}
}

List<PHIEUTHU> lstPHIEUTHUs = _PHIEUTHURepository.Clone(entity.PHIEUTHUs);
	 foreach( var obj in lstPHIEUTHUs ) 
{
PHIEUTHU objPHIEUTHU = _PHIEUTHURepository.Clone(obj);
 if (objPHIEUTHU != null)
{
 _PHIEUTHURepository.Delete(objPHIEUTHU);
}
}


    
    					if (SaveChanges() <= 0)
    					{
    						ThrowException("Không thể xóa dữ liệu con 'HOADONXUATKHO'.");
    					}
    				}
                    _HOADONXUATKHORepository.Delete(Clone(entity));
    
                    if (SaveChanges() <= 0)
                    {
                        ThrowException("Không thể xóa dữ liệu 'HOADONXUATKHO'.");
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
