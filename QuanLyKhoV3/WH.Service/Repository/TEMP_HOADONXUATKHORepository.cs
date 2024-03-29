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
    public partial interface ITEMP_HOADONXUATKHORepository : IRepositoryAsync<TEMP_HOADONXUATKHO>
    {
    	bool Exist(string id);
    	bool Exist(Expression<Func<TEMP_HOADONXUATKHO, bool>> predicate);
    	TEMP_HOADONXUATKHO getObject(string id);
    	TEMP_HOADONXUATKHO getObject(Expression<Func<TEMP_HOADONXUATKHO, bool>> predicate);
    	
    
    	TEMP_HOADONXUATKHO CreateNew();
    	TEMP_HOADONXUATKHO CloneNew(TEMP_HOADONXUATKHO objTEMP_HOADONXUATKHO);
    	TEMP_HOADONXUATKHO CloneUpdate(TEMP_HOADONXUATKHO objTEMP_HOADONXUATKHO);
    	TEMP_HOADONXUATKHO Clone(TEMP_HOADONXUATKHO objTEMP_HOADONXUATKHO);
    
    	List< TEMP_HOADONXUATKHO> Clone(IList<TEMP_HOADONXUATKHO> listTEMP_HOADONXUATKHOs);
    	string GetMaxCode();
    	List<TEMP_HOADONXUATKHO> Search(string textSearch);
    	List<TEMP_HOADONXUATKHO> Search(Expression<Func<TEMP_HOADONXUATKHO, bool>> predicate);
    	List<TEMP_HOADONXUATKHO> Search(Expression<Func<TEMP_HOADONXUATKHO, bool>> predicate,string textSearch);
    }
    
    public partial class TEMP_HOADONXUATKHORepository : Repository<TEMP_HOADONXUATKHO>, ITEMP_HOADONXUATKHORepository
    {
    	public string DefaultCode
        {
    		get { return null; }
        }
    
        public TEMP_HOADONXUATKHORepository(IDataContextAsync context, IUnitOfWorkAsync unitOfWork) : base(context, unitOfWork)
        {
        }
    
        public TEMP_HOADONXUATKHORepository(IUnitOfWorkAsync unitOfWork)
                : base(unitOfWork)
        {
        }
    
    	public bool Exist(string id)
        {
    		return QueryableList().Any(p => p.IDUnit == id);
        }
    
    	public bool Exist(Expression<Func<TEMP_HOADONXUATKHO, bool>> predicate)
    	{
    		return Queryable().Any(predicate);
    	}
    
    	public TEMP_HOADONXUATKHO CreateNew()
        {
    		
    		TEMP_HOADONXUATKHO _obj = Create();
    
    					//Primary Key
    			_obj.MAHOADONXUAT = DateTime.Now.ToString("ddMMyyyyHHmmssfff"); //string
    						
    										_obj.HANTHANHTOAN = null;//Nullable<System.DateTime>
    									_obj.GHICHU_HD = string.Empty;//string
    					_obj.DATHANHTOAN = null;//Nullable<bool>
    									_obj.NGUOITAO = string.Empty;//string
    						_obj.NGAYTAOHOADON = null;//Nullable<System.DateTime>
    									_obj.ISDELETE = null;//Nullable<bool>
    									_obj.MAKHACHHANG = null;//Nullable<System.Guid>
    							        return _obj;
        }
    
    	public TEMP_HOADONXUATKHO CloneNew(TEMP_HOADONXUATKHO objTEMP_HOADONXUATKHO)
    	{
    		if(objTEMP_HOADONXUATKHO==null) return null;
    			 TEMP_HOADONXUATKHO objNew = Find(objTEMP_HOADONXUATKHO.MAHOADONXUAT);
    			if(objNew !=null) return null;
    
    		 objNew =  CreateNew();
    		 				objNew.MAHOADONXUAT =  objTEMP_HOADONXUATKHO.MAHOADONXUAT;
    								objNew.THANHTIENCHUACK_HD =  objTEMP_HOADONXUATKHO.THANHTIENCHUACK_HD;
    								objNew.TIENCHIETKHAU_HD =  objTEMP_HOADONXUATKHO.TIENCHIETKHAU_HD;
    								objNew.TIENKHUYENMAI_HD =  objTEMP_HOADONXUATKHO.TIENKHUYENMAI_HD;
    								objNew.SOTIENTHANHTOAN_HD =  objTEMP_HOADONXUATKHO.SOTIENTHANHTOAN_HD;
    								objNew.SOTIENKHACHDUA_HD =  objTEMP_HOADONXUATKHO.SOTIENKHACHDUA_HD;
    								objNew.LOAIHOADON =  objTEMP_HOADONXUATKHO.LOAIHOADON;
    								objNew.HANTHANHTOAN =  objTEMP_HOADONXUATKHO.HANTHANHTOAN;
    								objNew.GHICHU_HD =  objTEMP_HOADONXUATKHO.GHICHU_HD;
    								objNew.DATHANHTOAN =  objTEMP_HOADONXUATKHO.DATHANHTOAN;
    								objNew.NGUOITAO =  objTEMP_HOADONXUATKHO.NGUOITAO;
    								objNew.NGAYTAOHOADON =  objTEMP_HOADONXUATKHO.NGAYTAOHOADON;
    								objNew.ISDELETE =  objTEMP_HOADONXUATKHO.ISDELETE;
    								objNew.MAKHACHHANG =  objTEMP_HOADONXUATKHO.MAKHACHHANG;
    								objNew.MACA =  objTEMP_HOADONXUATKHO.MACA;
    						  objNew.isAdd = true;
    		 return objNew;
    	}
    
    	public TEMP_HOADONXUATKHO CloneUpdate(TEMP_HOADONXUATKHO objTEMP_HOADONXUATKHO)
    	{
    		if(objTEMP_HOADONXUATKHO==null) return null;
    		 TEMP_HOADONXUATKHO objNew = Find(objTEMP_HOADONXUATKHO.MAHOADONXUAT);
    		 if(objNew==null) return null;
    		 				objNew.MAHOADONXUAT =  objTEMP_HOADONXUATKHO.MAHOADONXUAT;
    								objNew.THANHTIENCHUACK_HD =  objTEMP_HOADONXUATKHO.THANHTIENCHUACK_HD;
    								objNew.TIENCHIETKHAU_HD =  objTEMP_HOADONXUATKHO.TIENCHIETKHAU_HD;
    								objNew.TIENKHUYENMAI_HD =  objTEMP_HOADONXUATKHO.TIENKHUYENMAI_HD;
    								objNew.SOTIENTHANHTOAN_HD =  objTEMP_HOADONXUATKHO.SOTIENTHANHTOAN_HD;
    								objNew.SOTIENKHACHDUA_HD =  objTEMP_HOADONXUATKHO.SOTIENKHACHDUA_HD;
    								objNew.LOAIHOADON =  objTEMP_HOADONXUATKHO.LOAIHOADON;
    								objNew.HANTHANHTOAN =  objTEMP_HOADONXUATKHO.HANTHANHTOAN;
    								objNew.GHICHU_HD =  objTEMP_HOADONXUATKHO.GHICHU_HD;
    								objNew.DATHANHTOAN =  objTEMP_HOADONXUATKHO.DATHANHTOAN;
    								objNew.NGUOITAO =  objTEMP_HOADONXUATKHO.NGUOITAO;
    								objNew.NGAYTAOHOADON =  objTEMP_HOADONXUATKHO.NGAYTAOHOADON;
    								objNew.ISDELETE =  objTEMP_HOADONXUATKHO.ISDELETE;
    								objNew.MAKHACHHANG =  objTEMP_HOADONXUATKHO.MAKHACHHANG;
    								objNew.MACA =  objTEMP_HOADONXUATKHO.MACA;
    						 objNew.isUpdate = true;
    		 return objNew;
    	}
    	public TEMP_HOADONXUATKHO Clone(TEMP_HOADONXUATKHO objTEMP_HOADONXUATKHO)
    	{
    		if(objTEMP_HOADONXUATKHO==null) return null;
    		 TEMP_HOADONXUATKHO objNew = Find(objTEMP_HOADONXUATKHO.MAHOADONXUAT);
    		 if(objNew==null) 
    		 {
    		 objNew =  CreateNew();
    		 				objNew.MAHOADONXUAT =  objTEMP_HOADONXUATKHO.MAHOADONXUAT;
    								objNew.THANHTIENCHUACK_HD =  objTEMP_HOADONXUATKHO.THANHTIENCHUACK_HD;
    								objNew.TIENCHIETKHAU_HD =  objTEMP_HOADONXUATKHO.TIENCHIETKHAU_HD;
    								objNew.TIENKHUYENMAI_HD =  objTEMP_HOADONXUATKHO.TIENKHUYENMAI_HD;
    								objNew.SOTIENTHANHTOAN_HD =  objTEMP_HOADONXUATKHO.SOTIENTHANHTOAN_HD;
    								objNew.SOTIENKHACHDUA_HD =  objTEMP_HOADONXUATKHO.SOTIENKHACHDUA_HD;
    								objNew.LOAIHOADON =  objTEMP_HOADONXUATKHO.LOAIHOADON;
    								objNew.HANTHANHTOAN =  objTEMP_HOADONXUATKHO.HANTHANHTOAN;
    								objNew.GHICHU_HD =  objTEMP_HOADONXUATKHO.GHICHU_HD;
    								objNew.DATHANHTOAN =  objTEMP_HOADONXUATKHO.DATHANHTOAN;
    								objNew.NGUOITAO =  objTEMP_HOADONXUATKHO.NGUOITAO;
    								objNew.NGAYTAOHOADON =  objTEMP_HOADONXUATKHO.NGAYTAOHOADON;
    								objNew.ISDELETE =  objTEMP_HOADONXUATKHO.ISDELETE;
    								objNew.MAKHACHHANG =  objTEMP_HOADONXUATKHO.MAKHACHHANG;
    								objNew.MACA =  objTEMP_HOADONXUATKHO.MACA;
    						  objNew.isAdd = true;
    		 }
    		 else
    		 {
    		 				objNew.THANHTIENCHUACK_HD =  objTEMP_HOADONXUATKHO.THANHTIENCHUACK_HD;
    								objNew.TIENCHIETKHAU_HD =  objTEMP_HOADONXUATKHO.TIENCHIETKHAU_HD;
    								objNew.TIENKHUYENMAI_HD =  objTEMP_HOADONXUATKHO.TIENKHUYENMAI_HD;
    								objNew.SOTIENTHANHTOAN_HD =  objTEMP_HOADONXUATKHO.SOTIENTHANHTOAN_HD;
    								objNew.SOTIENKHACHDUA_HD =  objTEMP_HOADONXUATKHO.SOTIENKHACHDUA_HD;
    								objNew.LOAIHOADON =  objTEMP_HOADONXUATKHO.LOAIHOADON;
    								objNew.HANTHANHTOAN =  objTEMP_HOADONXUATKHO.HANTHANHTOAN;
    								objNew.GHICHU_HD =  objTEMP_HOADONXUATKHO.GHICHU_HD;
    								objNew.DATHANHTOAN =  objTEMP_HOADONXUATKHO.DATHANHTOAN;
    								objNew.NGUOITAO =  objTEMP_HOADONXUATKHO.NGUOITAO;
    								objNew.NGAYTAOHOADON =  objTEMP_HOADONXUATKHO.NGAYTAOHOADON;
    								objNew.ISDELETE =  objTEMP_HOADONXUATKHO.ISDELETE;
    								objNew.MAKHACHHANG =  objTEMP_HOADONXUATKHO.MAKHACHHANG;
    								objNew.MACA =  objTEMP_HOADONXUATKHO.MACA;
    						 objNew.isUpdate = true;
    		  objNew.isLoaded = true;
    		 }
    		 return objNew;
    	}
    
    	public List< TEMP_HOADONXUATKHO> Clone(IList<TEMP_HOADONXUATKHO> listTEMP_HOADONXUATKHOs)
    	{
    		List< TEMP_HOADONXUATKHO> lst = new List< TEMP_HOADONXUATKHO>();
    		if(listTEMP_HOADONXUATKHOs == null) return lst;
    		foreach(var obj in  listTEMP_HOADONXUATKHOs)
    		{
    			 lst.Add(Clone(obj));
    		}
    		return lst;
    	}
    
    	public TEMP_HOADONXUATKHO getObject(string id)
    	{
    		return QueryableList().FirstOrDefault(p => p.IDUnit == id);
    	}
    
    	public TEMP_HOADONXUATKHO getObject(Expression<Func<TEMP_HOADONXUATKHO, bool>> predicate)
    	{
    		return  Queryable().FirstOrDefault(predicate);
    	}
    
    	 public string GetMaxCode()
         {
    		return QueryableList().Max(s=>s.IDUnit).ToString();
         }
    
    	 public List<TEMP_HOADONXUATKHO> Search(string textSearch)
    	 {
    		List<TEMP_HOADONXUATKHO> listIDUnit = QueryableList().Where(p=>p.IDUnit == textSearch).ToList();
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
    
    	public List<TEMP_HOADONXUATKHO> Search(Expression<Func<TEMP_HOADONXUATKHO, bool>> predicate)
    	{
    		return  Queryable().Where(predicate).ToList();
    	}
    
    	public List<TEMP_HOADONXUATKHO> Search(Expression<Func<TEMP_HOADONXUATKHO, bool>> predicate,string textSearch)
    	{
    			List<TEMP_HOADONXUATKHO> listIDUnit = Search(predicate).Where(p => p.IDUnit == textSearch).ToList();
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
