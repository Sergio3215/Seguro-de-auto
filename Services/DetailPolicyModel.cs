using InsuranceCar_WebApi.Controllers;
using InsuranceCar_WebAPI.Schema;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace InsuranceCar_WebApi.Services
{
    public class DetailPolicyModel : EntityTypeConfiguration<PolicyList>
    {
        public DetailPolicyModel()
        {
            this.Property(cat => cat.name).IsRequired();
            this.Property(cat => cat.name_catalog).IsRequired();
            this.Property(cat => cat.insured_amount).IsRequired();
            this.Property(cat => cat.id_catalog).IsRequired();
            this.ToTable("DetailPolicy");
        }
    }
}