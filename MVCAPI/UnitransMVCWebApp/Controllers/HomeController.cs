using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using UnitransMVCWebApp.Models;

namespace UnitransMVCWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(Enumerable.Empty<prc_GetUserDetailsBySearchText_Result>());

        }

        [HttpPost]
        public ActionResult Index(string searchText)
        {
            TempData["Success"] = null;
            List<prc_GetUserDetailsBySearchText_Result> _UserDetailsList = null;

            if (searchText == null || searchText.Length > 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("UserDetails/GetUserDetailBySearchString/" + searchText).Result;


                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return View(Enumerable.Empty<prc_GetUserDetailsBySearchText_Result>());
                }

                _UserDetailsList = response.Content.ReadAsAsync<IEnumerable<prc_GetUserDetailsBySearchText_Result>>().Result.ToList();
                return View(_UserDetailsList);
            }

            return View(Enumerable.Empty<prc_GetUserDetailsBySearchText_Result>());


        }


        public JsonResult GetByLookup(string term)
        {
            TempData["Success"] = null;
            List<prc_GetUserDetailsByLookupText_Result> _LookupList = new List<prc_GetUserDetailsByLookupText_Result>();

            if (term.Length > 2)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("UserDetails/GetUserDetailByLookup/" + term).Result;


                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return new JsonResult { Data = "", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }

                _LookupList = response.Content.ReadAsAsync<IEnumerable<prc_GetUserDetailsByLookupText_Result>>().Result.ToList();
                return new JsonResult { Data = _LookupList.Select(p => p.SearchText).ToList(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            else
            {
                return new JsonResult { Data = "", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

        }


        public ActionResult AddOrEdit(int id = 0)
        {
            TempData["Success"] = null;
            UserDetail userDetailModel = new UserDetail();


            HttpResponseMessage cityListResponse = GlobalVariables.WebApiClient.GetAsync("City/GettblCities").Result;



            if (id == 0)
            {
                userDetailModel.DOB = DateTime.Now;
                userDetailModel.Cities = new SelectList(cityListResponse.Content.ReadAsAsync<IEnumerable<prc_GetCity_Result>>().Result, "PK_CityID", "Name", 1);

                HttpResponseMessage suburbListResponse = GlobalVariables.WebApiClient.GetAsync("Suburbs/GetSuburb/1").Result;
                userDetailModel.Suburbs = new SelectList(Enumerable.Empty<prc_GetSuburb_Result>(), "PK_SuburbID", "Name", 1);
                return View(userDetailModel);
            }
            else
            {


                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("UserDetails/GettblUserDetails/" + id.ToString()).Result;

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return View(userDetailModel);
                }

                tblUserDetail getUserDetails = new tblUserDetail();
                getUserDetails = response.Content.ReadAsAsync<tblUserDetail>().Result;

                userDetailModel.PK_UserID = getUserDetails.PK_UserID;
                userDetailModel.Name = getUserDetails.Name;
                userDetailModel.Surname = getUserDetails.Surname;
                userDetailModel.StreetAddress = getUserDetails.StreetAddress;
                userDetailModel.PoCode = getUserDetails.PoCode;
                userDetailModel.IDNumber = getUserDetails.IDNumber;
                userDetailModel.ContactNumber = getUserDetails.ContactNumber.ToString();

                userDetailModel.DOB = getUserDetails.DOB;

                userDetailModel.Cities = new SelectList(cityListResponse.Content.ReadAsAsync<IEnumerable<prc_GetCity_Result>>().Result, "PK_CityID", "Name", getUserDetails.FK_CityID);

                HttpResponseMessage suburbListResponse = GlobalVariables.WebApiClient.GetAsync("Suburbs/GetSuburb/" + getUserDetails.FK_CityID.ToString()).Result;
                userDetailModel.Suburbs = new SelectList(suburbListResponse.Content.ReadAsAsync<IEnumerable<prc_GetSuburb_Result>>().Result, "PK_SuburbID", "Name", getUserDetails.FK_SuburbID);




                return View(userDetailModel);
            }
        }


        [HttpPost]
        public ActionResult AddOrEdit(UserDetail userDetail)
        {

            tblUserDetail postUserDetails = new tblUserDetail();
            postUserDetails.PK_UserID = userDetail.PK_UserID;
            postUserDetails.Name = userDetail.Name;
            postUserDetails.Surname = userDetail.Surname;
            postUserDetails.StreetAddress = userDetail.StreetAddress;
            postUserDetails.PoCode = userDetail.PoCode;
            postUserDetails.IDNumber = userDetail.IDNumber;
            postUserDetails.ContactNumber = int.Parse(userDetail.ContactNumber);
            postUserDetails.FK_CityID = userDetail.SelectedCity.PK_CityID;
            postUserDetails.FK_SuburbID = userDetail.SelectedSuburb.PK_SuburbID;
            postUserDetails.DOB = userDetail.DOB.AddHours(1);

            string ID = postUserDetails.IDNumber;
            string dob = postUserDetails.DOB.Year.ToString().Substring(2) + postUserDetails.DOB.Month.ToString("00") + postUserDetails.DOB.Day.ToString("00");
            if (ID.Contains(dob))
            {
                HttpResponseMessage response;
                if (userDetail.PK_UserID > 0)
                {
                    response = GlobalVariables.WebApiClient.PutAsJsonAsync("UserDetails/PuttblUserDetail/" + userDetail.PK_UserID.ToString(), postUserDetails).Result;

                }
                else
                {
                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("UserDetails/PosttblUserDetail", postUserDetails).Result;
                }

                if (response.StatusCode == HttpStatusCode.OK) TempData["Success"] = "Successfully Saved";

                return RedirectToAction("Index");
            }
            else
            {
                TempData["Success"] = "ID failed to match date of birth";

                return RedirectToAction("AddOrEdit/" + userDetail.PK_UserID.ToString());
            }
        }

        public ActionResult Delete(UserDetail _userDetail)
        {
            TempData["Success"] = null;
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("UserDetails/DeletetblUserDetail/" + _userDetail.PK_UserID.ToString()).Result;

            if (response.StatusCode == HttpStatusCode.OK) TempData["Success"] = "Deleted Saved";
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult GetSuburbs(int cityID)
        {
            TempData["Success"] = null;
            HttpResponseMessage suburbListResponse = GlobalVariables.WebApiClient.GetAsync("Suburbs/GetSuburb/" + cityID.ToString()).Result;
            IEnumerable<SelectListItem> suburbs = new SelectList(suburbListResponse.Content.ReadAsAsync<IEnumerable<prc_GetSuburb_Result>>().Result, "PK_SuburbID", "Name");
            return Json(suburbs, JsonRequestBehavior.AllowGet);

        }
    }
}
