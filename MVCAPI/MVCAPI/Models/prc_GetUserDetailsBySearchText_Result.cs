//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCAPI.Models
{
    using System;
    
    public partial class prc_GetUserDetailsBySearchText_Result
    {
        public int PK_UserID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string StreetAddress { get; set; }
        public int PoCode { get; set; }
        public System.DateTime DOB { get; set; }
        public string IDNumber { get; set; }
        public Nullable<int> PK_SuburbID { get; set; }
        public Nullable<int> PK_CityID { get; set; }
        public string Suburb_City { get; set; }
    }
}
