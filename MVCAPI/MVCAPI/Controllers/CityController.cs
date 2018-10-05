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
    public class CityController : ApiController
    {
        private UnitransTestSystemsDBEntities db = new UnitransTestSystemsDBEntities();

        // GET api/City/GettblCities
        public List<prc_GetCity_Result> GettblCities()
        {
            return db.prc_GetCity().ToList();
        }

    }
}