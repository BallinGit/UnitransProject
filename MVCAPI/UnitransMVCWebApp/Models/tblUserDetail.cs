using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UnitransMVCWebApp.Models
{
    public class tblUserDetail
    {

        public int PK_UserID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string StreetAddress { get; set; }
        public int FK_CityID { get; set; }
        public int FK_SuburbID { get; set; }
        public int PoCode { get; set; }
        public int ContactNumber { get; set; }
        public string IDNumber { get; set; }
        public System.DateTime DOB { get; set; }

    }
}