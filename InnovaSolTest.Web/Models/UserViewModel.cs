using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InnovaSolTest.Web.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MobileNo { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Address { get; set; }
        public string FullName => FirstName + " " + LastName;
    }
}
