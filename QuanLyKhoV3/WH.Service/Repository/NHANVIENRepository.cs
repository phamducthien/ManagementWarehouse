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
    public partial interface INHANVIENRepository : IRepositoryAsync<NHANVIEN>
    {
    	bool Exist(string id);
    	bool Exist(Expression<Func<NHANVIEN, bool>> predicate);
    	NHANVIEN getObject(string id);
    	NHANVIEN getObject(Expression<Func<NHANVIEN, bool>> predicate);
    	
    
    	NHANVIEN CreateNew();
    	NHANVIEN CloneNew(NHANVIEN objNHANVIEN);
    	NHANVIEN CloneUpdate(NHANVIEN objNHANVIEN);
    	NHANVIEN Clone(NHANVIEN objNHANVIEN);
    
    	List< NHANVIEN> Clone(IList<NHANVIEN> listNHANVIENs);
    	string GetMaxCode();
    	List<NHANVIEN> Search(string textSearch);
    	List<NHANVIEN> Search(Expression<Func<NHANVIEN, bool>> predicate);
    	List<NHANVIEN> Search(Expression<Func<NHANVIEN, bool>> predicate,string textSearch);
    }
    
    public partial class NHANVIENRepository : Repository<NHANVIEN>, INHANVIENRepository
    {
    	public string DefaultCode
        {
    		get { return null; }
        }
    
        public NHANVIENRepository(IDataContextAsync context, IUnitOfWorkAsync unitOfWork) : base(context, unitOfWork)
        {
        }
    
        public NHANVIENRepository(IUnitOfWorkAsync unitOfWork)
                : base(unitOfWork)
        {
        }
    
    	public bool Exist(string id)
        {
    		return QueryableList().Any(p => p.IDUnit == id);
        }
    
    	public bool Exist(Expression<Func<NHANVIEN, bool>> predicate)
    	{
    		return Queryable().Any(predicate);
    	}
    
    	public NHANVIEN CreateNew()
        {
    		
    		NHANVIEN _obj = Create();
    
    				//_obj.CAs = null;//List
    		//_obj.CAs = new List<CA>();//List
    					//_obj.LOAINHANVIEN = null;//object
    		_obj.MALOAI =  null;////Nullable<int>
    									//_obj.NGUOIDUNGs = null;//List
    		//_obj.NGUOIDUNGs = new List<NGUOIDUNG>();//List
    					_obj.TENNHANVIEN = string.Empty;//string
    					_obj.CHUCVU = string.Empty;//string
    						_obj.NGAYSINH = null;//Nullable<System.DateTime>
    									_obj.GIOITINH = string.Empty;//string
    					_obj.CMND = string.Empty;//string
    					_obj.DIACHI = string.Empty;//string
    					_obj.QUEQUAN = string.Empty;//string
    					_obj.DIDONG = string.Empty;//string
    					_obj.EMAIL = string.Empty;//string
    					_obj.THEODOI = null;//Nullable<bool>
    										_obj.NGAYTAO = null;//Nullable<System.DateTime>
    									_obj.NGUOITAO = string.Empty;//string
    						_obj.NGAYCAPNHAT = null;//Nullable<System.DateTime>
    									_obj.NGUOICAPNHAT = string.Empty;//string
    					_obj.ISDELETE = null;//Nullable<bool>
    							        return _obj;
        }
    
    	public NHANVIEN CloneNew(NHANVIEN objNHANVIEN)
    	{
    		if(objNHANVIEN==null) return null;
    			 NHANVIEN objNew = Find(objNHANVIEN.MANHANVIEN);
    			if(objNew !=null) return null;
    
    		 objNew =  CreateNew();
    		 				objNew.MANHANVIEN =  objNHANVIEN.MANHANVIEN;
    								objNew.MALOAI =  objNHANVIEN.MALOAI;
    								objNew.TENNHANVIEN =  objNHANVIEN.TENNHANVIEN;
    								objNew.CHUCVU =  objNHANVIEN.CHUCVU;
    								objNew.NGAYSINH =  objNHANVIEN.NGAYSINH;
    								objNew.GIOITINH =  objNHANVIEN.GIOITINH;
    								objNew.CMND =  objNHANVIEN.CMND;
    								objNew.DIACHI =  objNHANVIEN.DIACHI;
    								objNew.QUEQUAN =  objNHANVIEN.QUEQUAN;
    								objNew.DIDONG =  objNHANVIEN.DIDONG;
    								objNew.LUONGCOBAN =  objNHANVIEN.LUONGCOBAN;
    								objNew.EMAIL =  objNHANVIEN.EMAIL;
    								objNew.THEODOI =  objNHANVIEN.THEODOI;
    								objNew.NGAYTAO =  objNHANVIEN.NGAYTAO;
    								objNew.NGUOITAO =  objNHANVIEN.NGUOITAO;
    								objNew.NGAYCAPNHAT =  objNHANVIEN.NGAYCAPNHAT;
    								objNew.NGUOICAPNHAT =  objNHANVIEN.NGUOICAPNHAT;
    								objNew.ISDELETE =  objNHANVIEN.ISDELETE;
    						  objNew.isAdd = true;
    		 return objNew;
    	}
    
    	public NHANVIEN CloneUpdate(NHANVIEN objNHANVIEN)
    	{
    		if(objNHANVIEN==null) return null;
    		 NHANVIEN objNew = Find(objNHANVIEN.MANHANVIEN);
    		 if(objNew==null) return null;
    		 				objNew.MANHANVIEN =  objNHANVIEN.MANHANVIEN;
    								objNew.MALOAI =  objNHANVIEN.MALOAI;
    								objNew.TENNHANVIEN =  objNHANVIEN.TENNHANVIEN;
    								objNew.CHUCVU =  objNHANVIEN.CHUCVU;
    								objNew.NGAYSINH =  objNHANVIEN.NGAYSINH;
    								objNew.GIOITINH =  objNHANVIEN.GIOITINH;
    								objNew.CMND =  objNHANVIEN.CMND;
    								objNew.DIACHI =  objNHANVIEN.DIACHI;
    								objNew.QUEQUAN =  objNHANVIEN.QUEQUAN;
    								objNew.DIDONG =  objNHANVIEN.DIDONG;
    								objNew.LUONGCOBAN =  objNHANVIEN.LUONGCOBAN;
    								objNew.EMAIL =  objNHANVIEN.EMAIL;
    								objNew.THEODOI =  objNHANVIEN.THEODOI;
    								objNew.NGAYTAO =  objNHANVIEN.NGAYTAO;
    								objNew.NGUOITAO =  objNHANVIEN.NGUOITAO;
    								objNew.NGAYCAPNHAT =  objNHANVIEN.NGAYCAPNHAT;
    								objNew.NGUOICAPNHAT =  objNHANVIEN.NGUOICAPNHAT;
    								objNew.ISDELETE =  objNHANVIEN.ISDELETE;
    						 objNew.isUpdate = true;
    		 return objNew;
    	}
    	public NHANVIEN Clone(NHANVIEN objNHANVIEN)
    	{
    		if(objNHANVIEN==null) return null;
    		 NHANVIEN objNew = Find(objNHANVIEN.MANHANVIEN);
    		 if(objNew==null) 
    		 {
    		 objNew =  CreateNew();
    		 				objNew.MANHANVIEN =  objNHANVIEN.MANHANVIEN;
    								objNew.MALOAI =  objNHANVIEN.MALOAI;
    								objNew.TENNHANVIEN =  objNHANVIEN.TENNHANVIEN;
    								objNew.CHUCVU =  objNHANVIEN.CHUCVU;
    								objNew.NGAYSINH =  objNHANVIEN.NGAYSINH;
    								objNew.GIOITINH =  objNHANVIEN.GIOITINH;
    								objNew.CMND =  objNHANVIEN.CMND;
    								objNew.DIACHI =  objNHANVIEN.DIACHI;
    								objNew.QUEQUAN =  objNHANVIEN.QUEQUAN;
    								objNew.DIDONG =  objNHANVIEN.DIDONG;
    								objNew.LUONGCOBAN =  objNHANVIEN.LUONGCOBAN;
    								objNew.EMAIL =  objNHANVIEN.EMAIL;
    								objNew.THEODOI =  objNHANVIEN.THEODOI;
    								objNew.NGAYTAO =  objNHANVIEN.NGAYTAO;
    								objNew.NGUOITAO =  objNHANVIEN.NGUOITAO;
    								objNew.NGAYCAPNHAT =  objNHANVIEN.NGAYCAPNHAT;
    								objNew.NGUOICAPNHAT =  objNHANVIEN.NGUOICAPNHAT;
    								objNew.ISDELETE =  objNHANVIEN.ISDELETE;
    						  objNew.isAdd = true;
    		 }
    		 else
    		 {
    		 				objNew.MALOAI =  objNHANVIEN.MALOAI;
    								objNew.TENNHANVIEN =  objNHANVIEN.TENNHANVIEN;
    								objNew.CHUCVU =  objNHANVIEN.CHUCVU;
    								objNew.NGAYSINH =  objNHANVIEN.NGAYSINH;
    								objNew.GIOITINH =  objNHANVIEN.GIOITINH;
    								objNew.CMND =  objNHANVIEN.CMND;
    								objNew.DIACHI =  objNHANVIEN.DIACHI;
    								objNew.QUEQUAN =  objNHANVIEN.QUEQUAN;
    								objNew.DIDONG =  objNHANVIEN.DIDONG;
    								objNew.LUONGCOBAN =  objNHANVIEN.LUONGCOBAN;
    								objNew.EMAIL =  objNHANVIEN.EMAIL;
    								objNew.THEODOI =  objNHANVIEN.THEODOI;
    								objNew.NGAYTAO =  objNHANVIEN.NGAYTAO;
    								objNew.NGUOITAO =  objNHANVIEN.NGUOITAO;
    								objNew.NGAYCAPNHAT =  objNHANVIEN.NGAYCAPNHAT;
    								objNew.NGUOICAPNHAT =  objNHANVIEN.NGUOICAPNHAT;
    								objNew.ISDELETE =  objNHANVIEN.ISDELETE;
    						 objNew.isUpdate = true;
    		  objNew.isLoaded = true;
    		 }
    		 return objNew;
    	}
    
    	public List< NHANVIEN> Clone(IList<NHANVIEN> listNHANVIENs)
    	{
    		List< NHANVIEN> lst = new List< NHANVIEN>();
    		if(listNHANVIENs == null) return lst;
    		foreach(var obj in  listNHANVIENs)
    		{
    			 lst.Add(Clone(obj));
    		}
    		return lst;
    	}
    
    	public NHANVIEN getObject(string id)
    	{
    		return QueryableList().FirstOrDefault(p => p.IDUnit == id);
    	}
    
    	public NHANVIEN getObject(Expression<Func<NHANVIEN, bool>> predicate)
    	{
    		return  Queryable().FirstOrDefault(predicate);
    	}
    
    	 public string GetMaxCode()
         {
    		return QueryableList().Max(s=>s.IDUnit).ToString();
         }
    
    	 public List<NHANVIEN> Search(string textSearch)
    	 {
    		List<NHANVIEN> listIDUnit = QueryableList().Where(p=>p.IDUnit == textSearch).ToList();
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
    
    	public List<NHANVIEN> Search(Expression<Func<NHANVIEN, bool>> predicate)
    	{
    		return  Queryable().Where(predicate).ToList();
    	}
    
    	public List<NHANVIEN> Search(Expression<Func<NHANVIEN, bool>> predicate,string textSearch)
    	{
    			List<NHANVIEN> listIDUnit = Search(predicate).Where(p => p.IDUnit == textSearch).ToList();
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
