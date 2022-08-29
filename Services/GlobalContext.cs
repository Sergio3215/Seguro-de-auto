using InsuranceCar_WebApi.Controllers;
using InsuranceCar_WebAPI.Schema;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InsuranceCar_WebApi.Services
{
    public class GlobalContext : DbContext
    {

        public GlobalContext() : base("InsuranceCarsDB")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CatalogCoverageModel());
            modelBuilder.Configurations.Add(new DetailPolicyModel());
        }

        public IQueryable<CatalogList> catalogLists(bool trackChange = false)
        {
           IQueryable<CatalogList> query =  this.Set<CatalogList>();

            if (!trackChange)
            {
                query = query.AsNoTracking();
            }

            return query;
        }
        public IQueryable<PolicyList> detailPolicyLists(bool trackChange = false)
        {
            IQueryable<PolicyList> query = this.Set<PolicyList>();

            if (!trackChange)
            {
                query = query.AsNoTracking();
            }

            return query;
        }

        public System.Data.Entity.DbSet<InsuranceCar_WebAPI.Schema.PolicyList> PolicyLists { get; set; }

        public System.Data.Entity.DbSet<InsuranceCar_WebAPI.Schema.CatalogList> CatalogLists { get; set; }
    }
}