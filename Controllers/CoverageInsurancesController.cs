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
using InsuranceCar_WebAPI.Schema;
using InsuranceCar_WebApi.Services;

namespace InsuranceCar_WebAPI.Controllers
{
    public class CoverageInsurancesController : ApiController
    {
        private GlobalContext db = new GlobalContext();

        // GET: api/CoverageInsurances
        public IQueryable<CatalogList> GetCatalogLists()
        {
            return db.CatalogLists;
        }

        // GET: api/CoverageInsurances/5
        [ResponseType(typeof(CatalogList))]
        public IHttpActionResult GetCatalogList(int id)
        {
            CatalogList catalogList = db.CatalogLists.Find(id);
            if (catalogList == null)
            {
                return NotFound();
            }

            return Ok(catalogList);
        }

        // PUT: api/CoverageInsurances/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCatalogList(int id, CatalogList catalogList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != catalogList.id)
            {
                return BadRequest();
            }

            db.Entry(catalogList).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatalogListExists(id))
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
        [ResponseType(typeof(CatalogList))]
        public IQueryable<CatalogList> PostCatalogList(int? id, string name)
        {
            CatalogList catalogList = new CatalogList();
            catalogList.name = name;

            db.CatalogLists.Add(catalogList);
            db.SaveChanges();

            return GetCatalogLists();
        }

        // DELETE: api/CoverageInsurances/5
        [ResponseType(typeof(CatalogList))]
        public IHttpActionResult DeleteCatalogList(int id)
        {
            CatalogList catalogList = db.CatalogLists.Find(id);
            if (catalogList == null)
            {
                return NotFound();
            }

            db.CatalogLists.Remove(catalogList);
            db.SaveChanges();

            return Ok(catalogList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CatalogListExists(int id)
        {
            return db.CatalogLists.Count(e => e.id == id) > 0;
        }
    }
}