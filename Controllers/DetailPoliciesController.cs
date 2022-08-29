using InsuranceCar_WebApi.Controllers.Catalog_Coverage;
using InsuranceCar_WebApi.Services;
using InsuranceCar_WebAPI.Schema;
using InsuranceCars_WebApi.Controllers.DetailPolicy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace InsuranceCar_WebAPI.Controllers
{
    public class DetailPoliciesController : ApiController
    {
        private DetailPolicyService db;
        private GlobalContext context;
        private CatalogService catalog;

        public DetailPoliciesController()
        {
            db = new DetailPolicyService();
            context = new GlobalContext();
            catalog = new CatalogService();
        }

        // GET: api/CoverageInsurances
        public List<PolicyList> GetDetailPolicy()
        {
            return db.GetDetail();
        }

        // GET: api/CoverageInsurances?IdValue=5
        public PolicyList GetDetailPolicyByID(int id_catalog)
        {
            return db.GetDetail().Where(dt => dt.id_catalog == id_catalog).FirstOrDefault();
        }

        // PUT: api/DetailPolicies/5
        public IHttpActionResult PutPolicyList(int id, PolicyList policyList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Entry(policyList).State = EntityState.Modified;

            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PolicyListExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/DetailPolicies?id=5
        public List<PolicyList> PostDetailPolicy(int? id_catalog, string name, decimal amount)
        {
            CatalogList coverageInsurance = catalog.GetCatalog().Where(ci => ci.id == id_catalog).FirstOrDefault();

            PolicyList detailPolicy = new PolicyList();
            detailPolicy.id_catalog = (int)id_catalog;
            detailPolicy.name = name;
            detailPolicy.insured_amount = amount;
            detailPolicy.name_catalog = coverageInsurance.name;
            context.PolicyLists.Add(detailPolicy);
            context.SaveChanges();
            return GetDetailPolicy();
        }

        // DELETE: api/DetailPolicies/5
        public IHttpActionResult DeleteDetailPolicy(int id)
        {
            PolicyList detailPolicy = context.PolicyLists.Where(dt=>dt.id_catalog==id).FirstOrDefault();
            if (detailPolicy == null)
            {
                return NotFound();
            }

            context.PolicyLists.Remove(detailPolicy);
            context.SaveChanges();

            return Ok(detailPolicy);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PolicyListExists(int id)
        {
            return context.PolicyLists.Count(e => e.id_catalog == id) > 0;
        }
    }
}