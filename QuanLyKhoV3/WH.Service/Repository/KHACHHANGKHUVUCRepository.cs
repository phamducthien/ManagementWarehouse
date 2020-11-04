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
    public partial interface IKHACHHANGKHUVUCRepository : IRepositoryAsync<KHACHHANGKHUVUC>
    {
    	bool Exist(string id);
    	bool Exist(Expression<Func<KHACHHANGKHUVUC, bool>> predicate);
    	KHACHHANGKHUVUC getObject(string id);
    	KHACHHANGKHUVUC getObject(Expression<Func<KHACHHANGKHUVUC, bool>> predicate);
    	
    
    	KHACHHANGKHUVUC CreateNew();
    	KHACHHANGKHUVUC CloneNew(KHACHHANGKHUVUC objKHACHHANGKHUVUC);
    	KHACHHANGKHUVUC CloneUpdate(KHACHHANGKHUVUC objKHACHHANGKHUVUC);
    	KHACHHANGKHUVUC Clone(KHACHHANGKHUVUC objKHACHHANGKHUVUC);
    
    	List< KHACHHANGKHUVUC> Clone(IList<KHACHHANGKHUVUC> listKHACHHANGKHUVUCs);
    	string GetMaxCode();
    	List<KHACHHANGKHUVUC> Search(string textSearch);
    	List<KHACHHANGKHUVUC> Search(Expression<Func<KHACHHANGKHUVUC, bool>> predicate);
    	List<KHACHHANGKHUVUC> Search(Expression<Func<KHACHHANGKHUVUC, bool>> predicate,string textSearch);
    }
    
    public partial class KHACHHANGKHUVUCRepository : Repository<KHACHHANGKHUVUC>, IKHACHHANGKHUVUCRepository
    {
    	public string DefaultCode
        {
    		get { return null; }
        }
    
        public KHACHHANGKHUVUCRepository(IDataContextAsync context, IUnitOfWorkAsync unitOfWork) : base(context, unitOfWork)
        {
        }
    
        public KHACHHANGKHUVUCRepository(IUnitOfWorkAsync unitOfWork)
                : base(unitOfWork)
        {
        }
    
    	public bool Exist(string id)
        {
    		return QueryableList().Any(p => p.IDUnit == id);
        }
    
    	public bool Exist(Expression<Func<KHACHHANGKHUVUC, bool>> predicate)
    	{
    		return Queryable().Any(predicate);
    	}
    
    	public KHACHHANGKHUVUC CreateNew()
        {
    		
    		KHACHHANGKHUVUC _obj = Create();
    
    				//_obj.KHACHHANGs = null;//List
    		//_obj.KHACHHANGs = new List<KHACHHANG>();//List
    					_obj.TEN = string.Empty;//string
    					_obj.GHICHU = string.Empty;//string
    					_obj.ISUSE = null;//Nullable<bool>
    							        return _obj;
        }
    
    	public KHACHHANGKHUVUC CloneNew(KHACHHANGKHUVUC objKHACHHANGKHUVUC)
    	{
    		if(objKHACHHANGKHUVUC==null) return null;
    			 KHACHHANGKHUVUC objNew = Find(objKHACHHANGKHUVUC.MAKHUVUC);
    			if(objNew !=null) return null;
    
    		 objNew =  CreateNew();
    		 				objNew.MAKHUVUC =  objKHACHHANGKHUVUC.MAKHUVUC;
    								objNew.TEN =  objKHACHHANGKHUVUC.TEN;
    								objNew.QUANGDUONG =  objKHACHHANGKHUVUC.QUANGDUONG;
    								objNew.GHICHU =  objKHACHHANGKHUVUC.GHICHU;
    								objNew.ISUSE =  objKHACHHANGKHUVUC.ISUSE;
    						  objNew.isAdd = true;
    		 return objNew;
    	}
    
    	public KHACHHANGKHUVUC CloneUpdate(KHACHHANGKHUVUC objKHACHHANGKHUVUC)
    	{
    		if(objKHACHHANGKHUVUC==null) return null;
    		 KHACHHANGKHUVUC objNew = Find(objKHACHHANGKHUVUC.MAKHUVUC);
    		 if(objNew==null) return null;
    		 				objNew.MAKHUVUC =  objKHACHHANGKHUVUC.MAKHUVUC;
    								objNew.TEN =  objKHACHHANGKHUVUC.TEN;
    								objNew.QUANGDUONG =  objKHACHHANGKHUVUC.QUANGDUONG;
    								objNew.GHICHU =  objKHACHHANGKHUVUC.GHICHU;
    								objNew.ISUSE =  objKHACHHANGKHUVUC.ISUSE;
    						 objNew.isUpdate = true;
    		 return objNew;
    	}
    	public KHACHHANGKHUVUC Clone(KHACHHANGKHUVUC objKHACHHANGKHUVUC)
    	{
    		if(objKHACHHANGKHUVUC==null) return null;
    		 KHACHHANGKHUVUC objNew = Find(objKHACHHANGKHUVUC.MAKHUVUC);
    		 if(objNew==null) 
    		 {
    		 objNew =  CreateNew();
    		 				objNew.MAKHUVUC =  objKHACHHANGKHUVUC.MAKHUVUC;
    								objNew.TEN =  objKHACHHANGKHUVUC.TEN;
    								objNew.QUANGDUONG =  objKHACHHANGKHUVUC.QUANGDUONG;
    								objNew.GHICHU =  objKHACHHANGKHUVUC.GHICHU;
    								objNew.ISUSE =  objKHACHHANGKHUVUC.ISUSE;
    						  objNew.isAdd = true;
    		 }
    		 else
    		 {
    		 				objNew.TEN =  objKHACHHANGKHUVUC.TEN;
    								objNew.QUANGDUONG =  objKHACHHANGKHUVUC.QUANGDUONG;
    								objNew.GHICHU =  objKHACHHANGKHUVUC.GHICHU;
    								objNew.ISUSE =  objKHACHHANGKHUVUC.ISUSE;
    						 objNew.isUpdate = true;
    		  objNew.isLoaded = true;
    		 }
    		 return objNew;
    	}
    
    	public List< KHACHHANGKHUVUC> Clone(IList<KHACHHANGKHUVUC> listKHACHHANGKHUVUCs)
    	{
    		List< KHACHHANGKHUVUC> lst = new List< KHACHHANGKHUVUC>();
    		if(listKHACHHANGKHUVUCs == null) return lst;
    		foreach(var obj in  listKHACHHANGKHUVUCs)
    		{
    			 lst.Add(Clone(obj));
    		}
    		return lst;
    	}
    
    	public KHACHHANGKHUVUC getObject(string id)
    	{
    		return QueryableList().FirstOrDefault(p => p.IDUnit == id);
    	}
    
    	public KHACHHANGKHUVUC getObject(Expression<Func<KHACHHANGKHUVUC, bool>> predicate)
    	{
    		return  Queryable().FirstOrDefault(predicate);
    	}
    
    	 public string GetMaxCode()
         {
    		return QueryableList().Max(s=>s.IDUnit).ToString();
         }
    
    	 public List<KHACHHANGKHUVUC> Search(string textSearch)
    	 {
    		List<KHACHHANGKHUVUC> listIDUnit = QueryableList().Where(p=>p.IDUnit == textSearch).ToList();
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
    
    	public List<KHACHHANGKHUVUC> Search(Expression<Func<KHACHHANGKHUVUC, bool>> predicate)
    	{
    		return  Queryable().Where(predicate).ToList();
    	}
    
    	public List<KHACHHANGKHUVUC> Search(Expression<Func<KHACHHANGKHUVUC, bool>> predicate,string textSearch)
    	{
    			List<KHACHHANGKHUVUC> listIDUnit = Search(predicate).Where(p => p.IDUnit == textSearch).ToList();
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
