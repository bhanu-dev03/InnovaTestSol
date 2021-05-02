using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InnovaSolTest.Web.Models
{
    public class SingupViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter valid Email address")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(6,ErrorMessage ="Password should be minimum 6 chars length")]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        [Compare("Password",ErrorMessage ="Confirm Password must be same as Password")]
        public string ConfirmPassword { get; set; }

    }
}
