using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UnitransMVCWebApp.Models
{
    public class prc_GetUserDetailsBySearchText_Result
    {
        public int PK_UserID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        [Display(Name = "Postal Code")]
        public int PoCode { get; set; }
        public System.DateTime DOB { get; set; }
        public string IDNumber { get; set; }
        public int PK_SuburbID { get; set; }
        public int PK_CityID { get; set; }
        [Display(Name = "Suburb City")]
        public string Suburb_City { get; set; }

    }
}