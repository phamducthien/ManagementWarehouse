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
    
    public partial class KHO : Repository.Pattern.Ef6.Entity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHO()
        {
            this.HOADONHAPKHOCHITIETs = new List<HOADONHAPKHOCHITIET>();
            this.HOADONNHAPXUATCHITIETs = new List<HOADONNHAPXUATCHITIET>();
            this.HOADONXUATKHOCHITIETs = new List<HOADONXUATKHOCHITIET>();
            this.KHOMATHANGs = new List<KHOMATHANG>();
        }
    	//List Property
    	
    	//foreign key MAKHO
        public System.Guid MAKHO { get; set; }
        public string MACODE { get; set; }
        public string TENKHO { get; set; }
        public string DIACHI { get; set; }
        public Nullable<bool> ISUSE { get; set; }
        public Nullable<bool> KHOMACDINH { get; set; }
        public string GHICHU { get; set; }
    	//Property TIMKIEM
    	public string TIMKIEM
    	{ 
    		get
    		{
    			return ((""+MAKHO+';'+MACODE+';'+TENKHO+';'+DIACHI+';'+ISUSE+';'+KHOMACDINH+';'+GHICHU+';')+(""+MAKHO+';'+MACODE+';'+TENKHO+';'+DIACHI+';'+ISUSE+';'+KHOMACDINH+';'+GHICHU+';').ToUnsign()).Replace(" ", "").ToLower();
    		}
    	}
       
    	public string TextSearchCoDau
    	{ 
    		get
    		{
    			return (""+MAKHO+';'+MACODE+';'+TENKHO+';'+DIACHI+';'+ISUSE+';'+KHOMACDINH+';'+GHICHU+';').Replace(" ", "").ToLower();
    		}
    	}
    	public string IDUnit {get{return (MAKHO).ToString();}}
    	
    	//LIST HOADONHAPKHOCHITIETs
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual IList<HOADONHAPKHOCHITIET> HOADONHAPKHOCHITIETs { get; set; }
    	//LIST HOADONNHAPXUATCHITIETs
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual IList<HOADONNHAPXUATCHITIET> HOADONNHAPXUATCHITIETs { get; set; }
    	//LIST HOADONXUATKHOCHITIETs
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual IList<HOADONXUATKHOCHITIET> HOADONXUATKHOCHITIETs { get; set; }
    	//LIST KHOMATHANGs
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual IList<KHOMATHANG> KHOMATHANGs { get; set; }
    }
}
