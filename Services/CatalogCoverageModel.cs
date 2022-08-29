using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using InsuranceCar_WebApi.Controllers;
using InsuranceCar_WebAPI.Schema;

namespace InsuranceCar_WebApi.Services
{
    public class CatalogCoverageModel : EntityTypeConfiguration<CatalogList>
    {
        public CatalogCoverageModel()
        {
            this.Property(cat => cat.id);
            this.Property(cat => cat.name).IsRequired();
            this.ToTable("CoverageInsurance");
        }
    }
}