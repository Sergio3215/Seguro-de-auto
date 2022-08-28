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
    public class CoverageInsurancesController : ApiController
    {
        private InsuranceCarsDBEntities db = new InsuranceCarsDBEntities();

        // GET: api/CoverageInsurances
        public IQueryable<CoverageInsurance> GetCoverageInsurances()
        {
            return db.CoverageInsurances;
        }

        // GET: api/CoverageInsurances/5
        [ResponseType(typeof(CoverageInsurance))]
        public IHttpActionResult GetCoverageInsurance(int id)
        {
            CoverageInsurance coverageInsurance = db.CoverageInsurances.Find(id);
            if (coverageInsurance == null)
            {
                return NotFound();
            }

            return Ok(coverageInsurance);
        }

        // PUT: api/CoverageInsurances/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCoverageInsurance(int id, CoverageInsurance coverageInsurance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != coverageInsurance.id)
            {
                return BadRequest();
            }

            db.Entry(coverageInsurance).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoverageInsuranceExists(id))
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

        // POST: api/CoverageInsurances
        [ResponseType(typeof(CoverageInsurance))]
        public IHttpActionResult PostCoverageInsurance(CoverageInsurance coverageInsurance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CoverageInsurances.Add(coverageInsurance);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = coverageInsurance.id }, coverageInsurance);
        }

        // DELETE: api/CoverageInsurances/5
        [ResponseType(typeof(CoverageInsurance))]
        public IHttpActionResult DeleteCoverageInsurance(int id)
        {
            CoverageInsurance coverageInsurance = db.CoverageInsurances.Find(id);
            if (coverageInsurance == null)
            {
                return NotFound();
            }

            db.CoverageInsurances.Remove(coverageInsurance);
            db.SaveChanges();

            return Ok(coverageInsurance);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CoverageInsuranceExists(int id)
        {
            return db.CoverageInsurances.Count(e => e.id == id) > 0;
        }
    }
}