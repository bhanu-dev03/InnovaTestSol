using System.Threading.Tasks;
using InnovaSolTest.Common;
using InnovaSolTest.Common.Helper;
using InnovaSolTest.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace InnovaSolTest.Web.Controllers
{
    [Route("user")]
    public class RegistrationController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpHelper _httpHelper;
        
        public RegistrationController(IConfiguration configuration, IHttpHelper httpHelper)
        {
            _configuration = configuration;
            _httpHelper = httpHelper;
        }

        [Route("signup")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> Index(SingupViewModel signupViewModel)
        {
            if(!ModelState.IsValid)
            return View();

            await _httpHelper.GetAsync(ApiEndPointConstants.SignUpApiUrl);
            return View();
        }

        [HttpGet]
        [Route("signin")]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [Route("signin")]
        public async Task<IActionResult> SignIn(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
                return View();

            await _httpHelper.PostAsync<LoginViewModel>(ApiEndPointConstants.SignInApiUrl, loginViewModel);

            return RedirectToAction("Update", new {loginViewModel.Email });
        }

        [HttpGet]
        [Route("verify/{activationcode?}")]
        public async Task<IActionResult> Verify(string activationcode)
        {
            if (string.IsNullOrEmpty(activationcode))
                return RedirectToAction("Error", "Home");

            await _httpHelper.GetAsync(ApiEndPointConstants.VerifyUserApiUrl + "/" + activationcode);
            return RedirectToAction("SignIn");
        }

        [HttpGet]
        [Route("update/{email?}")]
        public async Task<IActionResult> Update(string email)
        {
            await Task.Delay(1);
            var user = await _httpHelper.GetAsync(ApiEndPointConstants.GetUserApiUrl + "/" + email);
            return View(user);
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update(UserViewModel userViewModel)
        {
            if(!ModelState.IsValid)
            return View();

            await _httpHelper.PostAsync<UserViewModel>(ApiEndPointConstants.UpdateApiUrl,userViewModel);

            return View();
        }
    }
}