using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InsuranceCar_WebAPI.Schema
{
    public partial class CatalogList
    {
        public int id { get; set; }
        public string name { get; set; }

        public virtual DetailPolicy DetailPolicy { get; set; }
    }
    public partial class PolicyList
    {
        public int id_catalog { get; set; }
        public string name { get; set; }
        public decimal insured_amount { get; set; }

        public virtual CoverageInsurance CoverageInsurance { get; set; }
    }
}