//------------------------------------------------------------------------------
// <auto-generated>
// Repository Generated
// </auto-generated>
//------------------------------------------------------------------------------
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;
using Util.Pattern;
using WH.Entity;
using System;

namespace WH.Service.Repository
{
    public partial interface ILOAIKHACHHANGRepository : IRepositoryAsync<LOAIKHACHHANG>
    {
    	bool Exist(string id);
    	bool Exist(Expression<Func<LOAIKHACHHANG, bool>> predicate);
    	LOAIKHACHHANG getObject(string id);
    	LOAIKHACHHANG getObject(Expression<Func<LOAIKHACHHANG, bool>> predicate);
    	
    
    	LOAIKHACHHANG CreateNew();
    	LOAIKHACHHANG CloneNew(LOAIKHACHHANG objLOAIKHACHHANG);
    	LOAIKHACHHANG CloneUpdate(LOAIKHACHHANG objLOAIKHACHHANG);
    	LOAIKHACHHANG Clone(LOAIKHACHHANG objLOAIKHACHHANG);
    
    	List< LOAIKHACHHANG> Clone(IList<LOAIKHACHHANG> listLOAIKHACHHANGs);
    	string GetMaxCode();
    	List<LOAIKHACHHANG> Search(string textSearch);
    	List<LOAIKHACHHANG> Search(Expression<Func<LOAIKHACHHANG, bool>> predicate);
    	List<LOAIKHACHHANG> Search(Expression<Func<LOAIKHACHHANG, bool>> predicate,string textSearch);
    }
    
    public partial class LOAIKHACHHANGRepository : Repository<LOAIKHACHHANG>, ILOAIKHACHHANGRepository
    {
    	public string DefaultCode
        {
    		get { return null; }
        }
    
        public LOAIKHACHHANGRepository(IDataContextAsync context, IUnitOfWorkAsync unitOfWork) : base(context, unitOfWork)
        {
        }
    
        public LOAIKHACHHANGRepository(IUnitOfWorkAsync unitOfWork)
                : base(unitOfWork)
        {
        }
    
    	public bool Exist(string id)
        {
    		return QueryableList().Any(p => p.IDUnit == id);
        }
    
    	public bool Exist(Expression<Func<LOAIKHACHHANG, bool>> predicate)
    	{
    		return Queryable().Any(predicate);
    	}
    
    	public LOAIKHACHHANG CreateNew()
        {
    		
    		LOAIKHACHHANG _obj = Create();
    
    				//_obj.KHACHHANGs = null;//List
    		//_obj.KHACHHANGs = new List<KHACHHANG>();//List
    					_obj.TENLOAI = string.Empty;//string
    					_obj.ISUSE = null;//Nullable<bool>
    									_obj.ISDELETE = null;//Nullable<bool>
    							        return _obj;
        }
    
    	public LOAIKHACHHANG CloneNew(LOAIKHACHHANG objLOAIKHACHHANG)
    	{
    		if(objLOAIKHACHHANG==null) return null;
    			 LOAIKHACHHANG objNew = Find(objLOAIKHACHHANG.MALOAI);
    			if(objNew !=null) return null;
    
    		 objNew =  CreateNew();
    		 				objNew.MALOAI =  objLOAIKHACHHANG.MALOAI;
    								objNew.TENLOAI =  objLOAIKHACHHANG.TENLOAI;
    								objNew.DIEMDAT =  objLOAIKHACHHANG.DIEMDAT;
    								objNew.ISUSE =  objLOAIKHACHHANG.ISUSE;
    								objNew.ISDELETE =  objLOAIKHACHHANG.ISDELETE;
    						  objNew.isAdd = true;
    		 return objNew;
    	}
    
    	public LOAIKHACHHANG CloneUpdate(LOAIKHACHHANG objLOAIKHACHHANG)
    	{
    		if(objLOAIKHACHHANG==null) return null;
    		 LOAIKHACHHANG objNew = Find(objLOAIKHACHHANG.MALOAI);
    		 if(objNew==null) return null;
    		 				objNew.MALOAI =  objLOAIKHACHHANG.MALOAI;
    								objNew.TENLOAI =  objLOAIKHACHHANG.TENLOAI;
    								objNew.DIEMDAT =  objLOAIKHACHHANG.DIEMDAT;
    								objNew.ISUSE =  objLOAIKHACHHANG.ISUSE;
    								objNew.ISDELETE =  objLOAIKHACHHANG.ISDELETE;
    						 objNew.isUpdate = true;
    		 return objNew;
    	}
    	public LOAIKHACHHANG Clone(LOAIKHACHHANG objLOAIKHACHHANG)
    	{
    		if(objLOAIKHACHHANG==null) return null;
    		 LOAIKHACHHANG objNew = Find(objLOAIKHACHHANG.MALOAI);
    		 if(objNew==null) 
    		 {
    		 objNew =  CreateNew();
    		 				objNew.MALOAI =  objLOAIKHACHHANG.MALOAI;
    								objNew.TENLOAI =  objLOAIKHACHHANG.TENLOAI;
    								objNew.DIEMDAT =  objLOAIKHACHHANG.DIEMDAT;
    								objNew.ISUSE =  objLOAIKHACHHANG.ISUSE;
    								objNew.ISDELETE =  objLOAIKHACHHANG.ISDELETE;
    						  objNew.isAdd = true;
    		 }
    		 else
    		 {
    		 				objNew.TENLOAI =  objLOAIKHACHHANG.TENLOAI;
    								objNew.DIEMDAT =  objLOAIKHACHHANG.DIEMDAT;
    								objNew.ISUSE =  objLOAIKHACHHANG.ISUSE;
    								objNew.ISDELETE =  objLOAIKHACHHANG.ISDELETE;
    						 objNew.isUpdate = true;
    		  objNew.isLoaded = true;
    		 }
    		 return objNew;
    	}
    
    	public List< LOAIKHACHHANG> Clone(IList<LOAIKHACHHANG> listLOAIKHACHHANGs)
    	{
    		List< LOAIKHACHHANG> lst = new List< LOAIKHACHHANG>();
    		if(listLOAIKHACHHANGs == null) return lst;
    		foreach(var obj in  listLOAIKHACHHANGs)
    		{
    			 lst.Add(Clone(obj));
    		}
    		return lst;
    	}
    
    	public LOAIKHACHHANG getObject(string id)
    	{
    		return QueryableList().FirstOrDefault(p => p.IDUnit == id);
    	}
    
    	public LOAIKHACHHANG getObject(Expression<Func<LOAIKHACHHANG, bool>> predicate)
    	{
    		return  Queryable().FirstOrDefault(predicate);
    	}
    
    	 public string GetMaxCode()
         {
    		return QueryableList().Max(s=>s.IDUnit).ToString();
         }
    
    	 public List<LOAIKHACHHANG> Search(string textSearch)
    	 {
    		List<LOAIKHACHHANG> listIDUnit = QueryableList().Where(p=>p.IDUnit == textSearch).ToList();
    		if (listIDUnit.Count != 0)
    		{
        		return listIDUnit;
    		}
    		else
    		{
        		listIDUnit = QueryableList().Where(p => p.TextSearchCoDau.Contains(textSearch.Replace(" ", "").ToLower())).ToList();
        		return listIDUnit.Count == 0
        		? QueryableList().Where(p => p.TIMKIEM.Contains(textSearch.ToUnsign().Replace(" ", "").ToLower())).ToList()
        		: listIDUnit;
    		}
    	 }
    
    	public List<LOAIKHACHHANG> Search(Expression<Func<LOAIKHACHHANG, bool>> predicate)
    	{
    		return  Queryable().Where(predicate).ToList();
    	}
    
    	public List<LOAIKHACHHANG> Search(Expression<Func<LOAIKHACHHANG, bool>> predicate,string textSearch)
    	{
    			List<LOAIKHACHHANG> listIDUnit = Search(predicate).Where(p => p.IDUnit == textSearch).ToList();
                if (listIDUnit.Count != 0)
                {
                    return listIDUnit;
                }
                else
                {
                    listIDUnit = Search(predicate).Where(p => p.TextSearchCoDau.Contains(textSearch.Replace(" ", "").ToLower())).ToList();
                    return listIDUnit.Count == 0
                    ? Search(predicate).Where(p => p.TIMKIEM.Contains(textSearch.ToUnsign().Replace(" ", "").ToLower())).ToList()
                    : listIDUnit;
                }
    	}
    }
}
