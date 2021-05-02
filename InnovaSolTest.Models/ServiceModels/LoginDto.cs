namespace InnovaSolTest.Models.ServiceModels
{
    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int VerificationCode { get; set; }
    }
}
