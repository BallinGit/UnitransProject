using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using MVCAPI.Models;

namespace MVCAPI.Controllers
{
    public class SuburbsController : ApiController
    {
        private UnitransTestSystemsDBEntities db = new UnitransTestSystemsDBEntities();

        [HttpGet]
        [ActionName("GetSuburb")]
        // GET api/Suburbs/GettblSuburb/1
        public HttpResponseMessage GettblSuburb(int id)
        {
            List<prc_GetSuburb_Result> suburbList = db.prc_GetSuburb(id).ToList();

            if (suburbList.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No user details found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, suburbList);
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}