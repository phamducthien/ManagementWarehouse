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
    
    public partial class LOAIMATHANG : Repository.Pattern.Ef6.Entity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAIMATHANG()
        {
            this.CHIETKHAULOAIMATHANGs = new List<CHIETKHAULOAIMATHANG>();
            this.MATHANGs = new List<MATHANG>();
        }
    	//List Property
    	
    	//foreign key MALOAIMATHANG
        public int MALOAIMATHANG { get; set; }
        public string TENLOAIMATHANG { get; set; }
        public string MOTA { get; set; }
        public Nullable<int> STATUS { get; set; }
        public Nullable<System.DateTime> NGAYTAO { get; set; }
        public string NGUOITAO { get; set; }
        public Nullable<System.DateTime> NGAYCAPNHAT { get; set; }
        public string NGUOICAPNHAT { get; set; }
    	//Property TIMKIEM
    	public string TIMKIEM
    	{ 
    		get
    		{
    			return ((""+MALOAIMATHANG+';'+TENLOAIMATHANG+';'+MOTA+';'+STATUS+';'+NGAYTAO+';'+NGUOITAO+';'+NGAYCAPNHAT+';'+NGUOICAPNHAT+';')+(""+MALOAIMATHANG+';'+TENLOAIMATHANG+';'+MOTA+';'+STATUS+';'+NGAYTAO+';'+NGUOITAO+';'+NGAYCAPNHAT+';'+NGUOICAPNHAT+';').ToUnsign()).Replace(" ", "").ToLower();
    		}
    	}
       
    	public string TextSearchCoDau
    	{ 
    		get
    		{
    			return (""+MALOAIMATHANG+';'+TENLOAIMATHANG+';'+MOTA+';'+STATUS+';'+NGAYTAO+';'+NGUOITAO+';'+NGAYCAPNHAT+';'+NGUOICAPNHAT+';').Replace(" ", "").ToLower();
    		}
    	}
    	public string IDUnit {get{return (MALOAIMATHANG).ToString();}}
    	
    	//LIST CHIETKHAULOAIMATHANGs
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual IList<CHIETKHAULOAIMATHANG> CHIETKHAULOAIMATHANGs { get; set; }
    	//LIST MATHANGs
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual IList<MATHANG> MATHANGs { get; set; }
    }
}
