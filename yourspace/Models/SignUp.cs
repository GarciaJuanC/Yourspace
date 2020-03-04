using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace yourspace.Models
{
    public class SignUp
    {
        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email required")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password required")]
        public string Password { get; set; }

        [Display(Name = "First Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "First name required")]
        public string fName { get; set; }

        [Display(Name = "Middle Name")]
        [Required(AllowEmptyStrings = true)]
        public string mName { get; set; }

        [Display(Name = "Last Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name required")]
        public string lName { get; set; }

        [Display(Name = "Birth date")]
        [Required(AllowEmptyStrings = true)]
        public DateTime? dob { get; set; }

        [Display(Name = "Phone Number")]
        [Required(AllowEmptyStrings = true)]
        public string phoneNum { get; set; }

    }
}