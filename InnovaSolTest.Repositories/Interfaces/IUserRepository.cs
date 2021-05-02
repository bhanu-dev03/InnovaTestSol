using InnovaSolTest.Models.Entities;
using InnovaSolTest.Repositories.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSolTest.Repositories.Interfaces
{
    public interface IUserRepository:IRepository<User>
    {
        Task<int> SaveUserAsync(User user);
        Task<User> GetUserAsync(int id);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<int> UpdateUserAsync(User user);
        Task<int> DeleteUserAsync(int id);

        Task<User> GetUserByEmailAsync(string email);
        Task<int> VerifyUserAsync(string activationcode);

    }
}
