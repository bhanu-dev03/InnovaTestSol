using InnovaSolTest.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSolTest.Services.Interfaces
{
    public interface IUserRegistrationService
    {
        Task<int> UserSignUpAsync(LoginDto loginDto);
        Task<int> UserSignInAsync(LoginDto loginDto);
        Task<int> UserUpdateAsync(UserDto userDto);
        Task<UserDto> GetUserAsync(string email);
        Task<int> VerifyUser(string activationCode);
    }
}
