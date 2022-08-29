using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InsuranceCar_WebAPI.Schema
{
    public partial class CatalogList
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
    }
    public partial class PolicyList
    {
        [Key]
        public int id_catalog { get; set; }
        public string name { get; set; }
        public string name_catalog { get; set; }
        public decimal insured_amount { get; set; }
    }
}