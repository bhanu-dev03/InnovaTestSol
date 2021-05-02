using InnovaSolTest.Common;
using InnovaSolTest.Common.Helper;
using InnovaSolTest.Models.ServiceModels;
using InnovaSolTest.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InnovaSolTest.Services.Managers
{
    public class UserRegistrationService : IUserRegistrationService
    {
        private readonly IEmailService _emailService;
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public UserRegistrationService(IConfiguration configuration,IEmailService emailService,IUserService userService)
        {
            _emailService = emailService;
            _userService = userService;
            _configuration = configuration;
        }

        public async Task<UserDto> GetUserAsync(string email)
        {
            return await _userService.GetUserAsync(email);
        }

        public async Task<int> UserSignInAsync(LoginDto loginDto)
        {
            var userDto = await _userService.GetUserAsync(loginDto.Email);
            if (userDto == null)
            {
                return 0;
            }

            if (userDto.Email == loginDto.Email && userDto.Password == loginDto.Password.EncryptPassword()
                && userDto.VerificationCode == loginDto.VerificationCode)
                return 1;

            return 0;
        }

        public async Task<int> UserSignUpAsync(LoginDto loginDto)
        {
            var userDto = _userService.GetUserAsync(loginDto.Email);
            if (userDto != null)
            {
                return 0;
            }

            var webBaseUrl = _configuration.GetSection("Web:BaseUrl").Value;
            var activationcode = Guid.NewGuid();
            var verifyUserEmailUrl = webBaseUrl + WebEndPointConstants.VerifyUserUrl + activationcode;
            var otpCode = CodeGeneratorHelper.GetActivationCode();
            var email = new EmailDto()
            {
                ToAddress = new List<string>() { loginDto.Email },
                Subject = "Your account is successfull created",
                Body = "<br/><br/>Your account is successfully created. Please click on the below link to verify your account" +
                "<br/><br/><a href='" + verifyUserEmailUrl + "'>" + verifyUserEmailUrl + "</a>" +
                "<br/>Use Verification Code to Login " + otpCode
            };

            var user = new UserDto()
            {
                Email = loginDto.Email,
                Password = loginDto.Password.EncryptPassword()
            };

            await _userService.SaveUserAsync(user);
            await _emailService.SendEmailAsync(email);

            return 1;
        }

        public async Task<int> UserUpdateAsync(UserDto userDto)
        {
            return await _userService.UpdateUserAsync(userDto);
        }

        public async Task<int> VerifyUser(string activationCode)
        {
            return await _userService.VerifyUserAsync(activationCode);
        }
    }
}
