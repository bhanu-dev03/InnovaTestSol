using System.ComponentModel.DataAnnotations;

namespace InnovaSolTest.Web.Models
{
    public class LoginViewModel
    {
        [Required(AllowEmptyStrings =false,ErrorMessage ="Email is required")]
        [EmailAddress(ErrorMessage ="Enter valid Email address")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage ="Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(AllowEmptyStrings =false,ErrorMessage ="Verification code is required")]
        public string VerificationCode { get; set; }
    }
}
