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
    
    public partial class THONGTINTHE : Repository.Pattern.Ef6.Entity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THONGTINTHE()
        {
            this.QUANLYTHETHEOKHACHHANGs = new List<QUANLYTHETHEOKHACHHANG>();
        }
    	//List Property
    	
    	//foreign key MATHE
        public string MATHE { get; set; }
        public string TEN { get; set; }
        public Nullable<decimal> TUMUC { get; set; }
        public Nullable<decimal> DENMUC { get; set; }
        public Nullable<decimal> TILEGIAMGIA { get; set; }
        public Nullable<bool> ISUSE { get; set; }
        public Nullable<bool> ISDELETE { get; set; }
    	//Property TIMKIEM
    	public string TIMKIEM
    	{ 
    		get
    		{
    			return ((""+MATHE+';'+TEN+';'+TUMUC+';'+DENMUC+';'+TILEGIAMGIA+';'+ISUSE+';'+ISDELETE+';')+(""+MATHE+';'+TEN+';'+TUMUC+';'+DENMUC+';'+TILEGIAMGIA+';'+ISUSE+';'+ISDELETE+';').ToUnsign()).Replace(" ", "").ToLower();
    		}
    	}
       
    	public string TextSearchCoDau
    	{ 
    		get
    		{
    			return (""+MATHE+';'+TEN+';'+TUMUC+';'+DENMUC+';'+TILEGIAMGIA+';'+ISUSE+';'+ISDELETE+';').Replace(" ", "").ToLower();
    		}
    	}
    	public string IDUnit {get{return (MATHE).ToString();}}
    	
    	//LIST QUANLYTHETHEOKHACHHANGs
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual IList<QUANLYTHETHEOKHACHHANG> QUANLYTHETHEOKHACHHANGs { get; set; }
    }
}
