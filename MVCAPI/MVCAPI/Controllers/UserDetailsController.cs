using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using MVCAPI.Models;
using System.Web.Mvc;

namespace MVCAPI.Controllers
{

    public class UserDetailsController : ApiController
    {
        private UnitransTestSystemsDBEntities db = new UnitransTestSystemsDBEntities();

        // GET api/UserDetails
        public IEnumerable<tblUserDetail> GettblUserDetails()
        {
            return db.tblUserDetails.AsEnumerable();
        }

        // GET api/UserDetails
        public tblUserDetail GettblUserDetails(int id)
        {
            return db.tblUserDetails.AsEnumerable().Where(x => x.PK_UserID == id).First();
        }
        // GET api/UserDetails/GetUserDetailBySearchString/john
        public HttpResponseMessage GetUserDetailBySearchString(string id)
        {
            List<prc_GetUserDetailsBySearchText_Result> userDetailSearchList = db.prc_GetUserDetailsBySearchText(id).ToList();

            if (userDetailSearchList.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No user details found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, userDetailSearchList);
        }

        // GET api/UserDetails/GetUserDetailByLookup/john
        public HttpResponseMessage GetUserDetailByLookup(string id)
        {
            List<prc_GetUserDetailsByLookupText_Result> userDetailLookupList = db.prc_GetUserDetailsByLookupText(id).ToList();

            if (userDetailLookupList.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No user details found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, userDetailLookupList);
        }




        // PUT api/UserDetails/5
        public HttpResponseMessage PuttblUserDetail(int id, tblUserDetail tbluserdetail)
        {


            if (id != tbluserdetail.PK_UserID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(tbluserdetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/UserDetails
        public HttpResponseMessage PosttblUserDetail(tblUserDetail tbluserdetail)
        {

            db.tblUserDetails.Add(tbluserdetail);
            db.SaveChanges();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, tbluserdetail);
            response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = tbluserdetail.PK_UserID }));
            return response;

        }

        // DELETE api/UserDetails/5
        public HttpResponseMessage DeletetblUserDetail(int id)
        {
            tblUserDetail tbluserdetail = db.tblUserDetails.Find(id);
            if (tbluserdetail == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.tblUserDetails.Remove(tbluserdetail);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, tbluserdetail);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}