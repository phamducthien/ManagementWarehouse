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
    
    public partial class DONVI : Repository.Pattern.Ef6.Entity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DONVI()
        {
            this.MATHANGs = new List<MATHANG>();
            this.MATHANGs1 = new List<MATHANG>();
        }
    	//List Property
    	
    	//foreign key MADONVI
        public int MADONVI { get; set; }
        public string TENDONVI { get; set; }
        public Nullable<bool> ISUSE { get; set; }
    	//Property TIMKIEM
    	public string TIMKIEM
    	{ 
    		get
    		{
    			return ((""+MADONVI+';'+TENDONVI+';'+ISUSE+';')+(""+MADONVI+';'+TENDONVI+';'+ISUSE+';').ToUnsign()).Replace(" ", "").ToLower();
    		}
    	}
       
    	public string TextSearchCoDau
    	{ 
    		get
    		{
    			return (""+MADONVI+';'+TENDONVI+';'+ISUSE+';').Replace(" ", "").ToLower();
    		}
    	}
    	public string IDUnit {get{return (MADONVI).ToString();}}
    	
    	//LIST MATHANGs
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual IList<MATHANG> MATHANGs { get; set; }
    	//LIST MATHANGs1
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual IList<MATHANG> MATHANGs1 { get; set; }
    }
}
