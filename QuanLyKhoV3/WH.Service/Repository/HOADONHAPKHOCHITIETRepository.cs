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
    public partial interface IHOADONHAPKHOCHITIETRepository : IRepositoryAsync<HOADONHAPKHOCHITIET>
    {
    	bool Exist(string id);
    	bool Exist(Expression<Func<HOADONHAPKHOCHITIET, bool>> predicate);
    	HOADONHAPKHOCHITIET getObject(string id);
    	HOADONHAPKHOCHITIET getObject(Expression<Func<HOADONHAPKHOCHITIET, bool>> predicate);
    	
    
    	HOADONHAPKHOCHITIET CreateNew();
    	HOADONHAPKHOCHITIET CloneNew(HOADONHAPKHOCHITIET objHOADONHAPKHOCHITIET);
    	HOADONHAPKHOCHITIET CloneUpdate(HOADONHAPKHOCHITIET objHOADONHAPKHOCHITIET);
    	HOADONHAPKHOCHITIET Clone(HOADONHAPKHOCHITIET objHOADONHAPKHOCHITIET);
    
    	List< HOADONHAPKHOCHITIET> Clone(IList<HOADONHAPKHOCHITIET> listHOADONHAPKHOCHITIETs);
    	string GetMaxCode();
    	List<HOADONHAPKHOCHITIET> Search(string textSearch);
    	List<HOADONHAPKHOCHITIET> Search(Expression<Func<HOADONHAPKHOCHITIET, bool>> predicate);
    	List<HOADONHAPKHOCHITIET> Search(Expression<Func<HOADONHAPKHOCHITIET, bool>> predicate,string textSearch);
    }
    
    public partial class HOADONHAPKHOCHITIETRepository : Repository<HOADONHAPKHOCHITIET>, IHOADONHAPKHOCHITIETRepository
    {
    	public string DefaultCode
        {
    		get { return null; }
        }
    
        public HOADONHAPKHOCHITIETRepository(IDataContextAsync context, IUnitOfWorkAsync unitOfWork) : base(context, unitOfWork)
        {
        }
    
        public HOADONHAPKHOCHITIETRepository(IUnitOfWorkAsync unitOfWork)
                : base(unitOfWork)
        {
        }
    
    	public bool Exist(string id)
        {
    		return QueryableList().Any(p => p.IDUnit == id);
        }
    
    	public bool Exist(Expression<Func<HOADONHAPKHOCHITIET, bool>> predicate)
    	{
    		return Queryable().Any(predicate);
    	}
    
    	public HOADONHAPKHOCHITIET CreateNew()
        {
    		
    		HOADONHAPKHOCHITIET _obj = Create();
    
    				//_obj.HOADONNHAPKHO = null;//object
    		_obj.MAHOADON = null;//string
    									//_obj.KHO = null;//object
    		_obj.MAKHO =  null;////Nullable<System.Guid>
    									//_obj.MATHANG = null;//object
    		_obj.MAMATHANG =  null;////Nullable<int>
    										//Primary Key
    			_obj.MACHITIETHOADON = DateTime.Now.ToString("ddMMyyyyHHmmssfff"); //string
    						
    									_obj.GHICHU_CT = string.Empty;//string
    					_obj.ISDELETE = null;//Nullable<bool>
    							        return _obj;
        }
    
    	public HOADONHAPKHOCHITIET CloneNew(HOADONHAPKHOCHITIET objHOADONHAPKHOCHITIET)
    	{
    		if(objHOADONHAPKHOCHITIET==null) return null;
    			 HOADONHAPKHOCHITIET objNew = Find(objHOADONHAPKHOCHITIET.MACHITIETHOADON);
    			if(objNew !=null) return null;
    
    		 objNew =  CreateNew();
    		 				objNew.MACHITIETHOADON =  objHOADONHAPKHOCHITIET.MACHITIETHOADON;
    								objNew.MAHOADON =  objHOADONHAPKHOCHITIET.MAHOADON;
    								objNew.MAKHO =  objHOADONHAPKHOCHITIET.MAKHO;
    								objNew.MAMATHANG =  objHOADONHAPKHOCHITIET.MAMATHANG;
    								objNew.SOLUONGSI =  objHOADONHAPKHOCHITIET.SOLUONGSI;
    								objNew.SOLUONGLE =  objHOADONHAPKHOCHITIET.SOLUONGLE;
    								objNew.DONGIA =  objHOADONHAPKHOCHITIET.DONGIA;
    								objNew.TIENVAT =  objHOADONHAPKHOCHITIET.TIENVAT;
    								objNew.THANHTIENTRUOCCHIETKHAU_CT =  objHOADONHAPKHOCHITIET.THANHTIENTRUOCCHIETKHAU_CT;
    								objNew.THANHTIENSAUCHIETKHAU_CT =  objHOADONHAPKHOCHITIET.THANHTIENSAUCHIETKHAU_CT;
    								objNew.GHICHU_CT =  objHOADONHAPKHOCHITIET.GHICHU_CT;
    								objNew.ISDELETE =  objHOADONHAPKHOCHITIET.ISDELETE;
    						  objNew.isAdd = true;
    		 return objNew;
    	}
    
    	public HOADONHAPKHOCHITIET CloneUpdate(HOADONHAPKHOCHITIET objHOADONHAPKHOCHITIET)
    	{
    		if(objHOADONHAPKHOCHITIET==null) return null;
    		 HOADONHAPKHOCHITIET objNew = Find(objHOADONHAPKHOCHITIET.MACHITIETHOADON);
    		 if(objNew==null) return null;
    		 				objNew.MACHITIETHOADON =  objHOADONHAPKHOCHITIET.MACHITIETHOADON;
    								objNew.MAHOADON =  objHOADONHAPKHOCHITIET.MAHOADON;
    								objNew.MAKHO =  objHOADONHAPKHOCHITIET.MAKHO;
    								objNew.MAMATHANG =  objHOADONHAPKHOCHITIET.MAMATHANG;
    								objNew.SOLUONGSI =  objHOADONHAPKHOCHITIET.SOLUONGSI;
    								objNew.SOLUONGLE =  objHOADONHAPKHOCHITIET.SOLUONGLE;
    								objNew.DONGIA =  objHOADONHAPKHOCHITIET.DONGIA;
    								objNew.TIENVAT =  objHOADONHAPKHOCHITIET.TIENVAT;
    								objNew.THANHTIENTRUOCCHIETKHAU_CT =  objHOADONHAPKHOCHITIET.THANHTIENTRUOCCHIETKHAU_CT;
    								objNew.THANHTIENSAUCHIETKHAU_CT =  objHOADONHAPKHOCHITIET.THANHTIENSAUCHIETKHAU_CT;
    								objNew.GHICHU_CT =  objHOADONHAPKHOCHITIET.GHICHU_CT;
    								objNew.ISDELETE =  objHOADONHAPKHOCHITIET.ISDELETE;
    						 objNew.isUpdate = true;
    		 return objNew;
    	}
    	public HOADONHAPKHOCHITIET Clone(HOADONHAPKHOCHITIET objHOADONHAPKHOCHITIET)
    	{
    		if(objHOADONHAPKHOCHITIET==null) return null;
    		 HOADONHAPKHOCHITIET objNew = Find(objHOADONHAPKHOCHITIET.MACHITIETHOADON);
    		 if(objNew==null) 
    		 {
    		 objNew =  CreateNew();
    		 				objNew.MACHITIETHOADON =  objHOADONHAPKHOCHITIET.MACHITIETHOADON;
    								objNew.MAHOADON =  objHOADONHAPKHOCHITIET.MAHOADON;
    								objNew.MAKHO =  objHOADONHAPKHOCHITIET.MAKHO;
    								objNew.MAMATHANG =  objHOADONHAPKHOCHITIET.MAMATHANG;
    								objNew.SOLUONGSI =  objHOADONHAPKHOCHITIET.SOLUONGSI;
    								objNew.SOLUONGLE =  objHOADONHAPKHOCHITIET.SOLUONGLE;
    								objNew.DONGIA =  objHOADONHAPKHOCHITIET.DONGIA;
    								objNew.TIENVAT =  objHOADONHAPKHOCHITIET.TIENVAT;
    								objNew.THANHTIENTRUOCCHIETKHAU_CT =  objHOADONHAPKHOCHITIET.THANHTIENTRUOCCHIETKHAU_CT;
    								objNew.THANHTIENSAUCHIETKHAU_CT =  objHOADONHAPKHOCHITIET.THANHTIENSAUCHIETKHAU_CT;
    								objNew.GHICHU_CT =  objHOADONHAPKHOCHITIET.GHICHU_CT;
    								objNew.ISDELETE =  objHOADONHAPKHOCHITIET.ISDELETE;
    						  objNew.isAdd = true;
    		 }
    		 else
    		 {
    		 				objNew.MAHOADON =  objHOADONHAPKHOCHITIET.MAHOADON;
    								objNew.MAKHO =  objHOADONHAPKHOCHITIET.MAKHO;
    								objNew.MAMATHANG =  objHOADONHAPKHOCHITIET.MAMATHANG;
    								objNew.SOLUONGSI =  objHOADONHAPKHOCHITIET.SOLUONGSI;
    								objNew.SOLUONGLE =  objHOADONHAPKHOCHITIET.SOLUONGLE;
    								objNew.DONGIA =  objHOADONHAPKHOCHITIET.DONGIA;
    								objNew.TIENVAT =  objHOADONHAPKHOCHITIET.TIENVAT;
    								objNew.THANHTIENTRUOCCHIETKHAU_CT =  objHOADONHAPKHOCHITIET.THANHTIENTRUOCCHIETKHAU_CT;
    								objNew.THANHTIENSAUCHIETKHAU_CT =  objHOADONHAPKHOCHITIET.THANHTIENSAUCHIETKHAU_CT;
    								objNew.GHICHU_CT =  objHOADONHAPKHOCHITIET.GHICHU_CT;
    								objNew.ISDELETE =  objHOADONHAPKHOCHITIET.ISDELETE;
    						 objNew.isUpdate = true;
    		  objNew.isLoaded = true;
    		 }
    		 return objNew;
    	}
    
    	public List< HOADONHAPKHOCHITIET> Clone(IList<HOADONHAPKHOCHITIET> listHOADONHAPKHOCHITIETs)
    	{
    		List< HOADONHAPKHOCHITIET> lst = new List< HOADONHAPKHOCHITIET>();
    		if(listHOADONHAPKHOCHITIETs == null) return lst;
    		foreach(var obj in  listHOADONHAPKHOCHITIETs)
    		{
    			 lst.Add(Clone(obj));
    		}
    		return lst;
    	}
    
    	public HOADONHAPKHOCHITIET getObject(string id)
    	{
    		return QueryableList().FirstOrDefault(p => p.IDUnit == id);
    	}
    
    	public HOADONHAPKHOCHITIET getObject(Expression<Func<HOADONHAPKHOCHITIET, bool>> predicate)
    	{
    		return  Queryable().FirstOrDefault(predicate);
    	}
    
    	 public string GetMaxCode()
         {
    		return QueryableList().Max(s=>s.IDUnit).ToString();
         }
    
    	 public List<HOADONHAPKHOCHITIET> Search(string textSearch)
    	 {
    		List<HOADONHAPKHOCHITIET> listIDUnit = QueryableList().Where(p=>p.IDUnit == textSearch).ToList();
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
    
    	public List<HOADONHAPKHOCHITIET> Search(Expression<Func<HOADONHAPKHOCHITIET, bool>> predicate)
    	{
    		return  Queryable().Where(predicate).ToList();
    	}
    
    	public List<HOADONHAPKHOCHITIET> Search(Expression<Func<HOADONHAPKHOCHITIET, bool>> predicate,string textSearch)
    	{
    			List<HOADONHAPKHOCHITIET> listIDUnit = Search(predicate).Where(p => p.IDUnit == textSearch).ToList();
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
