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
using InsuranceCar_WebAPI.Models;

namespace InsuranceCar_WebAPI.Controllers
{
    public class DetailPoliciesController : ApiController
    {
        private InsuranceCarsDBEntities db = new InsuranceCarsDBEntities();

        // GET: api/DetailPolicies
        public IQueryable<DetailPolicy> GetDetailPolicies()
        {
            return db.DetailPolicies;
        }

        // GET: api/DetailPolicies/5
        [ResponseType(typeof(DetailPolicy))]
        public IHttpActionResult GetDetailPolicy(int id)
        {
            DetailPolicy detailPolicy = db.DetailPolicies.Find(id);
            if (detailPolicy == null)
            {
                return NotFound();
            }

            return Ok(detailPolicy);
        }

        // PUT: api/DetailPolicies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDetailPolicy(int id, DetailPolicy detailPolicy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != detailPolicy.id_catalog)
            {
                return BadRequest();
            }

            db.Entry(detailPolicy).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetailPolicyExists(id))
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

        // POST: api/DetailPolicies
        [ResponseType(typeof(DetailPolicy))]
        public IHttpActionResult PostDetailPolicy(DetailPolicy detailPolicy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DetailPolicies.Add(detailPolicy);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DetailPolicyExists(detailPolicy.id_catalog))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = detailPolicy.id_catalog }, detailPolicy);
        }

        // DELETE: api/DetailPolicies/5
        [ResponseType(typeof(DetailPolicy))]
        public IHttpActionResult DeleteDetailPolicy(int id)
        {
            DetailPolicy detailPolicy = db.DetailPolicies.Find(id);
            if (detailPolicy == null)
            {
                return NotFound();
            }

            db.DetailPolicies.Remove(detailPolicy);
            db.SaveChanges();

            return Ok(detailPolicy);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DetailPolicyExists(int id)
        {
            return db.DetailPolicies.Count(e => e.id_catalog == id) > 0;
        }
    }
}