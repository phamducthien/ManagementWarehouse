//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace WH.Entity
{
    using Util.Pattern;
    using System;
    using System.Collections.Generic;
    
    public partial class HOADONHAPKHOCHITIET : Repository.Pattern.Ef6.Entity
    {
    	//foreign key MACHITIETHOADON
        public string MACHITIETHOADON { get; set; }
        public string MAHOADON { get; set; }
        public Nullable<System.Guid> MAKHO { get; set; }
        public Nullable<int> MAMATHANG { get; set; }
        public Nullable<decimal> SOLUONGSI { get; set; }
        public Nullable<decimal> SOLUONGLE { get; set; }
        public Nullable<decimal> DONGIA { get; set; }
        public Nullable<decimal> TIENVAT { get; set; }
        public Nullable<decimal> THANHTIENTRUOCCHIETKHAU_CT { get; set; }
        public Nullable<decimal> THANHTIENSAUCHIETKHAU_CT { get; set; }
        public string GHICHU_CT { get; set; }
        public Nullable<bool> ISDELETE { get; set; }
    	//Property TIMKIEM
    	public string TIMKIEM
    	{ 
    		get
    		{
    			return ((""+MACHITIETHOADON+';'+MAHOADON+';'+MAKHO+';'+MAMATHANG+';'+SOLUONGSI+';'+SOLUONGLE+';'+DONGIA+';'+TIENVAT+';'+THANHTIENTRUOCCHIETKHAU_CT+';'+THANHTIENSAUCHIETKHAU_CT+';'+GHICHU_CT+';'+ISDELETE+';')+(""+MACHITIETHOADON+';'+MAHOADON+';'+MAKHO+';'+MAMATHANG+';'+SOLUONGSI+';'+SOLUONGLE+';'+DONGIA+';'+TIENVAT+';'+THANHTIENTRUOCCHIETKHAU_CT+';'+THANHTIENSAUCHIETKHAU_CT+';'+GHICHU_CT+';'+ISDELETE+';').ToUnsign()).Replace(" ", "").ToLower();
    		}
    	}
       
    	public string TextSearchCoDau
    	{ 
    		get
    		{
    			return (""+MACHITIETHOADON+';'+MAHOADON+';'+MAKHO+';'+MAMATHANG+';'+SOLUONGSI+';'+SOLUONGLE+';'+DONGIA+';'+TIENVAT+';'+THANHTIENTRUOCCHIETKHAU_CT+';'+THANHTIENSAUCHIETKHAU_CT+';'+GHICHU_CT+';'+ISDELETE+';').Replace(" ", "").ToLower();
    		}
    	}
    	public string IDUnit {get{return (MACHITIETHOADON).ToString();}}
    	
        public virtual HOADONNHAPKHO HOADONNHAPKHO { get; set; }
        public virtual KHO KHO { get; set; }
        public virtual MATHANG MATHANG { get; set; }
    }
}
