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
    
    public partial class CONFIG_PRINTER : Repository.Pattern.Ef6.Entity
    {
    	//foreign key ID
        public int ID { get; set; }
        public string Name { get; set; }
        public string IP { get; set; }
        public Nullable<int> NumberPrint { get; set; }
        public Nullable<bool> IsUse { get; set; }
        public string Note { get; set; }
    	//Property TIMKIEM
    	public string TIMKIEM
    	{ 
    		get
    		{
    			return ((""+ID+';'+Name+';'+IP+';'+NumberPrint+';'+IsUse+';'+Note+';')+(""+ID+';'+Name+';'+IP+';'+NumberPrint+';'+IsUse+';'+Note+';').ToUnsign()).Replace(" ", "").ToLower();
    		}
    	}
       
    	public string TextSearchCoDau
    	{ 
    		get
    		{
    			return (""+ID+';'+Name+';'+IP+';'+NumberPrint+';'+IsUse+';'+Note+';').Replace(" ", "").ToLower();
    		}
    	}
    	public string IDUnit {get{return (ID).ToString();}}
    	}
}
