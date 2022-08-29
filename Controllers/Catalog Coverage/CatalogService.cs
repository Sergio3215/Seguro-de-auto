using InsuranceCar_WebAPI.Schema;
using InsuranceCar_WebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceCar_WebApi.Controllers.Catalog_Coverage
{
    public class CatalogService
    {
        private GlobalContext _context;

        public CatalogService()
        {
            _context = new GlobalContext();
        }
        
        public List<CatalogList> GetCatalog()
        {
           return _context.catalogLists().ToList();
        }
    }
}