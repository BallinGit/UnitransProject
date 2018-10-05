using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UnitransMVCWebApp.Models
{
    public class UserDetail
    {

        public int PK_UserID { get; set; }
        [Required(ErrorMessage = "This is a required field")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This is a required field")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "This is a required field")]
        public string StreetAddress { get; set; }
        [Required(ErrorMessage = "This is a required field")]


        public prc_GetCity_Result SelectedCity { get; set; }
        public IEnumerable<SelectListItem> Cities { get; set; }

        public prc_GetSuburb_Result SelectedSuburb { get; set; }
        public IEnumerable<SelectListItem> Suburbs { get; set; }

       
        [Required(ErrorMessage = "This is a required field")]
        public int PoCode { get; set; }
        [Required(ErrorMessage = "This is a required field")]
        [Display(Name = "Contact Number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-.]?([0-9]{3})[-.]?([0-9]{4})$", ErrorMessage = "Invalid hone number")]
        [MaxLength(10, ErrorMessage = "Contact cannot be longer than 10 characters.")]
        public string ContactNumber { get; set; }
        [Required(ErrorMessage = "This is a required field")]
        [MaxLength(13, ErrorMessage = "ID cannot be longer than 13 characters.")]
        public string IDNumber { get; set; }
        [Required(ErrorMessage = "This is a required field")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime DOB { get; set; }
    }
}