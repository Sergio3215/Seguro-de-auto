//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InsuranceCar_WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DetailPolicy
    {
        public int id_catalog { get; set; }
        public string name { get; set; }
        public decimal insured_amount { get; set; }
    
        public virtual CoverageInsurance CoverageInsurance { get; set; }
    }
}
