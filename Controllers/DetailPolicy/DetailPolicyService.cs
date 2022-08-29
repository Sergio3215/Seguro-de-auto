using InsuranceCar_WebApi.Services;
using InsuranceCar_WebAPI.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceCars_WebApi.Controllers.DetailPolicy
{
    public class DetailPolicyService
    {

        private GlobalContext _context;

        public DetailPolicyService()
        {
            _context = new GlobalContext();
        }

        public List<PolicyList> GetDetail()
        {
            return _context.detailPolicyLists().ToList();
        }
    }
}