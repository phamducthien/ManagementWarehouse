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
    
    public partial class KHACHHANGTHEODOIDOANHTHU : Repository.Pattern.Ef6.Entity
    {
    	//foreign key MAKHACHHANG
        public System.Guid MAKHACHHANG { get; set; }
    	//foreign key NAM
        public int NAM { get; set; }
        public Nullable<decimal> THANG1 { get; set; }
        public Nullable<decimal> THANG2 { get; set; }
        public Nullable<decimal> THANG3 { get; set; }
        public Nullable<decimal> THANG4 { get; set; }
        public Nullable<decimal> THANG5 { get; set; }
        public Nullable<decimal> THANG6 { get; set; }
        public Nullable<decimal> THANG7 { get; set; }
        public Nullable<decimal> THANG8 { get; set; }
        public Nullable<decimal> THANG9 { get; set; }
        public Nullable<decimal> THANG10 { get; set; }
        public Nullable<decimal> THANG11 { get; set; }
        public Nullable<decimal> THANG12 { get; set; }
        public Nullable<bool> THEODOI { get; set; }
        public string NGUOICAPNHAT { get; set; }
    	//Property TIMKIEM
    	public string TIMKIEM
    	{ 
    		get
    		{
    			return ((""+MAKHACHHANG+';'+NAM+';'+THANG1+';'+THANG2+';'+THANG3+';'+THANG4+';'+THANG5+';'+THANG6+';'+THANG7+';'+THANG8+';'+THANG9+';'+THANG10+';'+THANG11+';'+THANG12+';'+THEODOI+';'+NGUOICAPNHAT+';')+(""+MAKHACHHANG+';'+NAM+';'+THANG1+';'+THANG2+';'+THANG3+';'+THANG4+';'+THANG5+';'+THANG6+';'+THANG7+';'+THANG8+';'+THANG9+';'+THANG10+';'+THANG11+';'+THANG12+';'+THEODOI+';'+NGUOICAPNHAT+';').ToUnsign()).Replace(" ", "").ToLower();
    		}
    	}
       
    	public string TextSearchCoDau
    	{ 
    		get
    		{
    			return (""+MAKHACHHANG+';'+NAM+';'+THANG1+';'+THANG2+';'+THANG3+';'+THANG4+';'+THANG5+';'+THANG6+';'+THANG7+';'+THANG8+';'+THANG9+';'+THANG10+';'+THANG11+';'+THANG12+';'+THEODOI+';'+NGUOICAPNHAT+';').Replace(" ", "").ToLower();
    		}
    	}
    	public string IDUnit {get{return (MAKHACHHANG+"_"+NAM).ToString();}}
    	
        public virtual KHACHHANG KHACHHANG { get; set; }
    }
}
