using InnovaSolTest.Models.Entities;
using InnovaSolTest.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSolTest.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetUserAsync(string email);
        Task<UserDto> GetUserByCodeAsync(string activationcode);

        Task<int> SaveUserAsync(UserDto user);
        Task<UserDto> GetUserAsync(int id);
        Task<IEnumerable<UserDto>> GetUsersAsync();
        Task<int> UpdateUserAsync(UserDto user);
        Task<int> DeleteUserAsync(int id);

        Task<UserDto> GetUserByEmailAsync(string email);
        Task<int> VerifyUserAsync(string activationcode);
    }
}
