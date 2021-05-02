using System;
using System.Collections.Generic;
using System.Text;

namespace InnovaSolTest.Models.ServiceModels
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }

        public string Email { get; set; }
        public string Address { get; set; }
        public string FullName => FirstName + " " + LastName;
        public Guid ActivationCode { get; set; }
        public int VerificationCode { get; set; }
        public bool IsEmailVerified { get; set; }
        public string Password { get; set; }
    }

}
