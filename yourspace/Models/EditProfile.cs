using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace yourspace.Models
{
    public class EditProfile
    {

        [Display(Name = "First Name")]
        [Required(AllowEmptyStrings = true)]
        public string fName { get; set; }

        [Display(Name = "Last Name")]
        [Required(AllowEmptyStrings = true)]
        public string lName { get; set; }

        [Display(Name = "Biography")]
        [Required(AllowEmptyStrings = true)]
        public string biography { get; set; }

        [Display(Name = "Phone Number")]
        [Required(AllowEmptyStrings = true)]
        public string phoneNum { get; set; }

    }

    



}