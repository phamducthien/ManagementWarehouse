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
    public partial interface IKHACHHANGService : IService
    {
    	bool Exist(string id);
    	bool Exist(Expression<Func<KHACHHANG, bool>> predicate);
    
    	KHACHHANG CreateNew();
        List<KHACHHANG> FindAll();
    	List<KHACHHANG> Search(string textSearch);
    	List<KHACHHANG> Search(Expression<Func<KHACHHANG, bool>> predicate,string textSearch);
        List<KHACHHANG> Search(Expression<Func<KHACHHANG, bool>> predicate);
    	
    	KHACHHANG Find(string idUnit);
    	KHACHHANG Find(Expression<Func<KHACHHANG, bool>> predicate);
    
    	//KHACHHANG CloneNew(KHACHHANG objKHACHHANG);
    	//KHACHHANG CloneUpdate(KHACHHANG objKHACHHANG);
    	KHACHHANG Clone(KHACHHANG objKHACHHANG);
    	List< KHACHHANG> Clone(IList<KHACHHANG> listKHACHHANGs);
    
        MethodResult Add(KHACHHANG model, bool isCommited = false,bool isAddChild = false);
        MethodResult Modify(KHACHHANG model, bool isCommited= false,bool isModifyChild = false);
    	MethodResult Remove(KHACHHANG model, bool isCommited = false,bool isRemoveChild = false);
        MethodResult Remove(string idUnit, bool isCommited = false,bool isRemoveChild = false);
    }
    
    public partial class KHACHHANGService : global::Service.Pattern.Service, IKHACHHANGService
    {
    	protected string userId = SessionModel.CurrentSession?.UserId;
    	protected IKHACHHANGRepository _KHACHHANGRepository;
    		protected IHOADONNHAPXUATRepository  _HOADONNHAPXUATRepository;
		protected IHOADONXUATKHORepository  _HOADONXUATKHORepository;
		protected IQUANLYTHETHEOKHACHHANGRepository  _QUANLYTHETHEOKHACHHANGRepository;
		protected IKHACHHANGTHEODOIDOANHTHURepository  _KHACHHANGTHEODOIDOANHTHURepository;
	
    
    	public KHACHHANGService(IUnitOfWorkAsync unitOfWork)
                : base(unitOfWork)
        {
        }
    
        protected override void InitRepositories()
        {
            _KHACHHANGRepository = new KHACHHANGRepository(this._dataContext, this._unitOfWork);
    			_HOADONNHAPXUATRepository = new HOADONNHAPXUATRepository(this._dataContext, this._unitOfWork);
			_HOADONXUATKHORepository = new HOADONXUATKHORepository(this._dataContext, this._unitOfWork);
			_QUANLYTHETHEOKHACHHANGRepository = new QUANLYTHETHEOKHACHHANGRepository(this._dataContext, this._unitOfWork);
			_KHACHHANGTHEODOIDOANHTHURepository = new KHACHHANGTHEODOIDOANHTHURepository(this._dataContext, this._unitOfWork);
		
        }
    	
    	public bool Exist(string id)
        {
    		return _KHACHHANGRepository.Exist(id);
        }
    
    	public bool Exist(Expression<Func<KHACHHANG, bool>> predicate)
    	{
    		return _KHACHHANGRepository.Exist(predicate);
    	}
    
        public KHACHHANG CreateNew()
        {
            return _KHACHHANGRepository.CreateNew();
        }
    
    	public List<KHACHHANG> FindAll()
    	{
    		return _KHACHHANGRepository.FindAll();
    	}
    
    	public List<KHACHHANG> Search(string textSearch)
        {
            return _KHACHHANGRepository.Search(textSearch);
        }
    
    	public List<KHACHHANG> Search(Expression<Func<KHACHHANG, bool>> predicate,string textSearch)
    	{
    		  return _KHACHHANGRepository.Search(predicate, textSearch);
    	}
    
    		public KHACHHANG Find(Expression<Func<KHACHHANG, bool>> predicate)
            {
               return _KHACHHANGRepository.getObject(predicate);
            }
    
            public List<KHACHHANG> Search(Expression<Func<KHACHHANG, bool>> predicate)
            {
                return _KHACHHANGRepository.Search(predicate);
            }
    
            //public KHACHHANG CloneNew(KHACHHANG objKHACHHANG)
           // {
           //     return _KHACHHANGRepository.CloneNew(objKHACHHANG);
           // }
    
    	//	public KHACHHANG CloneUpdate(KHACHHANG objKHACHHANG)
    	//	{
    	//		  return _KHACHHANGRepository.CloneUpdate(objKHACHHANG);
    	//	}
    
    		public KHACHHANG Clone(KHACHHANG objKHACHHANG)
    		{
    			return _KHACHHANGRepository.Clone(objKHACHHANG);
    		}
    
            public List<KHACHHANG> Clone(IList<KHACHHANG> listKHACHHANGs)
            {
                return _KHACHHANGRepository.Clone(listKHACHHANGs);
            }
    
        public KHACHHANG Find(string idUnit)
        {
    		return _KHACHHANGRepository.getObject(idUnit);
        }
    
    	public MethodResult Add(KHACHHANG entity, bool isCommited,bool isAddChild)
        {
    		MethodResult result = MethodResult.Succeed;
    		try
    		{
    			if(isCommited)
    				_unitOfWork.BeginTransaction();
    
    			entity.Validate();
    
    			_KHACHHANGRepository.Insert(Clone(entity));
    			if (SaveChanges() <= 0)
    			{
    				ThrowException("Không thể thêm dữ liệu 'KHACHHANG'.");
    			}
    
    			if(isAddChild)
    			{
    			List<HOADONNHAPXUAT> lstHOADONNHAPXUATs = _HOADONNHAPXUATRepository.Clone(entity.HOADONNHAPXUATs);
	 foreach( var obj in lstHOADONNHAPXUATs ) 
{
HOADONNHAPXUAT objHOADONNHAPXUAT = _HOADONNHAPXUATRepository.CloneNew(obj);
 if (objHOADONNHAPXUAT != null)
{
 _HOADONNHAPXUATRepository.Insert(objHOADONNHAPXUAT);
}
}

List<HOADONXUATKHO> lstHOADONXUATKHOes = _HOADONXUATKHORepository.Clone(entity.HOADONXUATKHOes);
	 foreach( var obj in lstHOADONXUATKHOes ) 
{
HOADONXUATKHO objHOADONXUATKHO = _HOADONXUATKHORepository.CloneNew(obj);
 if (objHOADONXUATKHO != null)
{
 _HOADONXUATKHORepository.Insert(objHOADONXUATKHO);
}
}

List<QUANLYTHETHEOKHACHHANG> lstQUANLYTHETHEOKHACHHANGs = _QUANLYTHETHEOKHACHHANGRepository.Clone(entity.QUANLYTHETHEOKHACHHANGs);
	 foreach( var obj in lstQUANLYTHETHEOKHACHHANGs ) 
{
QUANLYTHETHEOKHACHHANG objQUANLYTHETHEOKHACHHANG = _QUANLYTHETHEOKHACHHANGRepository.CloneNew(obj);
 if (objQUANLYTHETHEOKHACHHANG != null)
{
 _QUANLYTHETHEOKHACHHANGRepository.Insert(objQUANLYTHETHEOKHACHHANG);
}
}

List<KHACHHANGTHEODOIDOANHTHU> lstKHACHHANGTHEODOIDOANHTHUs = _KHACHHANGTHEODOIDOANHTHURepository.Clone(entity.KHACHHANGTHEODOIDOANHTHUs);
	 foreach( var obj in lstKHACHHANGTHEODOIDOANHTHUs ) 
{
KHACHHANGTHEODOIDOANHTHU objKHACHHANGTHEODOIDOANHTHU = _KHACHHANGTHEODOIDOANHTHURepository.CloneNew(obj);
 if (objKHACHHANGTHEODOIDOANHTHU != null)
{
 _KHACHHANGTHEODOIDOANHTHURepository.Insert(objKHACHHANGTHEODOIDOANHTHU);
}
}


    
    				if (SaveChanges() <= 0)
    				{
    					ThrowException("Không thể thêm dữ liệu con 'KHACHHANG'.");
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
    
    	public MethodResult Modify(KHACHHANG entity, bool isCommited,bool isModifyChild)
    	{
                MethodResult result = MethodResult.Succeed;
                try
                {
    
                 if(isCommited)
    				_unitOfWork.BeginTransaction();
    
                    entity.Validate();
    
                    _KHACHHANGRepository.Update(Clone(entity));
    				if (SaveChanges() <= 0)
                    {
                        ThrowException("Không thể sửa dữ liệu 'KHACHHANG'.");
                    }
    
    				if(isModifyChild)
    				{
    				List<HOADONNHAPXUAT> lstHOADONNHAPXUATs = _HOADONNHAPXUATRepository.Clone(entity.HOADONNHAPXUATs);
	 foreach( var obj in lstHOADONNHAPXUATs ) 
{
HOADONNHAPXUAT objHOADONNHAPXUAT = _HOADONNHAPXUATRepository.CloneUpdate(obj);
 if (objHOADONNHAPXUAT != null)
{
 _HOADONNHAPXUATRepository.Update(objHOADONNHAPXUAT);
}
}

List<HOADONXUATKHO> lstHOADONXUATKHOes = _HOADONXUATKHORepository.Clone(entity.HOADONXUATKHOes);
	 foreach( var obj in lstHOADONXUATKHOes ) 
{
HOADONXUATKHO objHOADONXUATKHO = _HOADONXUATKHORepository.CloneUpdate(obj);
 if (objHOADONXUATKHO != null)
{
 _HOADONXUATKHORepository.Update(objHOADONXUATKHO);
}
}

List<QUANLYTHETHEOKHACHHANG> lstQUANLYTHETHEOKHACHHANGs = _QUANLYTHETHEOKHACHHANGRepository.Clone(entity.QUANLYTHETHEOKHACHHANGs);
	 foreach( var obj in lstQUANLYTHETHEOKHACHHANGs ) 
{
QUANLYTHETHEOKHACHHANG objQUANLYTHETHEOKHACHHANG = _QUANLYTHETHEOKHACHHANGRepository.CloneUpdate(obj);
 if (objQUANLYTHETHEOKHACHHANG != null)
{
 _QUANLYTHETHEOKHACHHANGRepository.Update(objQUANLYTHETHEOKHACHHANG);
}
}

List<KHACHHANGTHEODOIDOANHTHU> lstKHACHHANGTHEODOIDOANHTHUs = _KHACHHANGTHEODOIDOANHTHURepository.Clone(entity.KHACHHANGTHEODOIDOANHTHUs);
	 foreach( var obj in lstKHACHHANGTHEODOIDOANHTHUs ) 
{
KHACHHANGTHEODOIDOANHTHU objKHACHHANGTHEODOIDOANHTHU = _KHACHHANGTHEODOIDOANHTHURepository.CloneUpdate(obj);
 if (objKHACHHANGTHEODOIDOANHTHU != null)
{
 _KHACHHANGTHEODOIDOANHTHURepository.Update(objKHACHHANGTHEODOIDOANHTHU);
}
}


    
    					 if (SaveChanges() <= 0)
    					{
    						ThrowException("Không thể sửa dữ liệu con 'KHACHHANG'.");
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
    
    
                    KHACHHANG entity = Find(idUnit);
    
                    if (entity == null)
                    {
                        ThrowException("Dữ liệu 'KHACHHANG' này không tồn tại trong hệ thống.");
                    }
    				if(isRemoveChild)
    				{
    				List<HOADONNHAPXUAT> lstHOADONNHAPXUATs = _HOADONNHAPXUATRepository.Clone(entity.HOADONNHAPXUATs);
	 foreach( var obj in lstHOADONNHAPXUATs ) 
{
HOADONNHAPXUAT objHOADONNHAPXUAT = _HOADONNHAPXUATRepository.Clone(obj);
 if (objHOADONNHAPXUAT != null)
{
 _HOADONNHAPXUATRepository.Delete(objHOADONNHAPXUAT);
}
}

List<HOADONXUATKHO> lstHOADONXUATKHOes = _HOADONXUATKHORepository.Clone(entity.HOADONXUATKHOes);
	 foreach( var obj in lstHOADONXUATKHOes ) 
{
HOADONXUATKHO objHOADONXUATKHO = _HOADONXUATKHORepository.Clone(obj);
 if (objHOADONXUATKHO != null)
{
 _HOADONXUATKHORepository.Delete(objHOADONXUATKHO);
}
}

List<QUANLYTHETHEOKHACHHANG> lstQUANLYTHETHEOKHACHHANGs = _QUANLYTHETHEOKHACHHANGRepository.Clone(entity.QUANLYTHETHEOKHACHHANGs);
	 foreach( var obj in lstQUANLYTHETHEOKHACHHANGs ) 
{
QUANLYTHETHEOKHACHHANG objQUANLYTHETHEOKHACHHANG = _QUANLYTHETHEOKHACHHANGRepository.Clone(obj);
 if (objQUANLYTHETHEOKHACHHANG != null)
{
 _QUANLYTHETHEOKHACHHANGRepository.Delete(objQUANLYTHETHEOKHACHHANG);
}
}

List<KHACHHANGTHEODOIDOANHTHU> lstKHACHHANGTHEODOIDOANHTHUs = _KHACHHANGTHEODOIDOANHTHURepository.Clone(entity.KHACHHANGTHEODOIDOANHTHUs);
	 foreach( var obj in lstKHACHHANGTHEODOIDOANHTHUs ) 
{
KHACHHANGTHEODOIDOANHTHU objKHACHHANGTHEODOIDOANHTHU = _KHACHHANGTHEODOIDOANHTHURepository.Clone(obj);
 if (objKHACHHANGTHEODOIDOANHTHU != null)
{
 _KHACHHANGTHEODOIDOANHTHURepository.Delete(objKHACHHANGTHEODOIDOANHTHU);
}
}


    
    				    if (SaveChanges() <= 0)
    					{
    						ThrowException("Không thể xóa dữ liệu con 'KHACHHANG'.");
    					}
    				}
    
                    _KHACHHANGRepository.Delete(Clone(entity));
    
                    if (SaveChanges() <= 0)
                    {
                        ThrowException("Không thể xóa dữ liệu 'KHACHHANG'.");
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
    
    		public MethodResult Remove(KHACHHANG model, bool isCommited,bool isRemoveChild)
            {
                MethodResult result = MethodResult.Succeed;
    
                try
                {
                    if(isCommited)
    						_unitOfWork.BeginTransaction();
    
    
                    KHACHHANG entity = Find(model.IDUnit);
    
                    if (entity == null)
                    {
                        ThrowException("Dữ liệu 'KHACHHANG' này không tồn tại trong hệ thống.");
                    }
    
    				if(isRemoveChild)
    				{
    				List<HOADONNHAPXUAT> lstHOADONNHAPXUATs = _HOADONNHAPXUATRepository.Clone(entity.HOADONNHAPXUATs);
	 foreach( var obj in lstHOADONNHAPXUATs ) 
{
HOADONNHAPXUAT objHOADONNHAPXUAT = _HOADONNHAPXUATRepository.Clone(obj);
 if (objHOADONNHAPXUAT != null)
{
 _HOADONNHAPXUATRepository.Delete(objHOADONNHAPXUAT);
}
}

List<HOADONXUATKHO> lstHOADONXUATKHOes = _HOADONXUATKHORepository.Clone(entity.HOADONXUATKHOes);
	 foreach( var obj in lstHOADONXUATKHOes ) 
{
HOADONXUATKHO objHOADONXUATKHO = _HOADONXUATKHORepository.Clone(obj);
 if (objHOADONXUATKHO != null)
{
 _HOADONXUATKHORepository.Delete(objHOADONXUATKHO);
}
}

List<QUANLYTHETHEOKHACHHANG> lstQUANLYTHETHEOKHACHHANGs = _QUANLYTHETHEOKHACHHANGRepository.Clone(entity.QUANLYTHETHEOKHACHHANGs);
	 foreach( var obj in lstQUANLYTHETHEOKHACHHANGs ) 
{
QUANLYTHETHEOKHACHHANG objQUANLYTHETHEOKHACHHANG = _QUANLYTHETHEOKHACHHANGRepository.Clone(obj);
 if (objQUANLYTHETHEOKHACHHANG != null)
{
 _QUANLYTHETHEOKHACHHANGRepository.Delete(objQUANLYTHETHEOKHACHHANG);
}
}

List<KHACHHANGTHEODOIDOANHTHU> lstKHACHHANGTHEODOIDOANHTHUs = _KHACHHANGTHEODOIDOANHTHURepository.Clone(entity.KHACHHANGTHEODOIDOANHTHUs);
	 foreach( var obj in lstKHACHHANGTHEODOIDOANHTHUs ) 
{
KHACHHANGTHEODOIDOANHTHU objKHACHHANGTHEODOIDOANHTHU = _KHACHHANGTHEODOIDOANHTHURepository.Clone(obj);
 if (objKHACHHANGTHEODOIDOANHTHU != null)
{
 _KHACHHANGTHEODOIDOANHTHURepository.Delete(objKHACHHANGTHEODOIDOANHTHU);
}
}


    
    					if (SaveChanges() <= 0)
    					{
    						ThrowException("Không thể xóa dữ liệu con 'KHACHHANG'.");
    					}
    				}
                    _KHACHHANGRepository.Delete(Clone(entity));
    
                    if (SaveChanges() <= 0)
                    {
                        ThrowException("Không thể xóa dữ liệu 'KHACHHANG'.");
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
