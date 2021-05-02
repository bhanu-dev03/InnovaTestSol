using System.Threading.Tasks;
using InnovaSolTest.Models.ServiceModels;
using InnovaSolTest.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InnovaSolTest.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IUserRegistrationService _userRegistrationService;

        public RegistrationController(IUserRegistrationService userRegistrationService)
        {
            _userRegistrationService = userRegistrationService;
        }

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> SignUp([FromBody] LoginDto loginDto)
        {
            var status = await _userRegistrationService.UserSignUpAsync(loginDto);
            if (status == 1)
                return Ok(new string("Your account created sucessfully"));
            else
                return Conflict(new string("Same emailId already exists in the system"));
        }

        [HttpPost]
        [Route("signin")]
        public async Task<IActionResult> SignIn([FromBody] LoginDto loginDto)
        {
            var status = await _userRegistrationService.UserSignInAsync(loginDto);
            if (status == 1)
                return Ok();
            else
                return Unauthorized();
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] UserDto userDto)
        {
            var status = await _userRegistrationService.UserUpdateAsync(userDto);
            if (status == 1)
                return Ok();
            else
                return BadRequest();
        }

        [HttpGet]
        [Route("verify/{activationCode?}")]
        public async Task<IActionResult> VerifyUser(string activationCode)
        {

            var status = await _userRegistrationService.VerifyUser(activationCode);
            if (status == 1)
                return Ok();
            else
                return BadRequest();
        }

        [HttpGet]
        [Route("details/{email?}")]
        public async Task<IActionResult> UserDetails(string email)
        {
            var user = await _userRegistrationService.GetUserAsync(email);
            if (user != null)
                return Ok();
            else
                return BadRequest();
        }
    }
}