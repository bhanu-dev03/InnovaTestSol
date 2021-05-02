using Dapper;
using InnovaSolTest.Common.Constants;
using InnovaSolTest.Models.Entities;
using InnovaSolTest.Repositories.Interfaces;
using InnovaSolTest.Repositories.Interfaces.Base;
using InnovaSolTest.Repositories.Repositories.Base;
using InnovaSolTestData;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSolTest.Repositories.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {

        public UserRepository(IConfiguration configuration, IDbProvider dbProvider) :base(configuration,dbProvider)
        {

        }

        public async Task<int> SaveUserAsync(User user)
        {
            using (var sqlConnection = _dbProvider.GetDbConnection())
            {
                sqlConnection.Open();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@FirstName", user.FirstName);
                dynamicParameters.Add("@LastName", user.LastName);
                dynamicParameters.Add("@Email", user.Email);
                dynamicParameters.Add("@Password", user.Password);
                dynamicParameters.Add("@MobileNo", user.MobileNo);
                dynamicParameters.Add("@Address", user.Address);
                dynamicParameters.Add("@IsEmailVerified", user.IsEmailVerified);
                dynamicParameters.Add("@VerificationCode", user.VerificationCode);
                dynamicParameters.Add("@ActivationCode", user.ActivationCode);

                return await sqlConnection.ExecuteAsync(
                    RepositoryConstants.sp_SaveUser,
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }


        public async Task<User> GetUserAsync(int id)
        {
            using (var sqlConnection = _dbProvider.GetDbConnection())
            {
                sqlConnection.Open();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@id", id);
                return await sqlConnection.QuerySingleOrDefaultAsync<User>(
                    RepositoryConstants.sp_GetUser,
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            using (var sqlConnection = _dbProvider.GetDbConnection())
            {
                sqlConnection.Open();
                return await sqlConnection.QueryAsync<User>(
                    RepositoryConstants.sp_GetUsers,
                    null,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> UpdateUserAsync(User user)
        {
            using (var sqlConnection = _dbProvider.GetDbConnection())
            {
                sqlConnection.Open();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", user.Id);
                dynamicParameters.Add("@FirstName", user.FirstName);
                dynamicParameters.Add("@LastName", user.LastName);
                dynamicParameters.Add("@Email", user.Email);
                dynamicParameters.Add("@Password", user.Password);
                dynamicParameters.Add("@MobileNo", user.MobileNo);
                dynamicParameters.Add("@Address", user.Address);
                dynamicParameters.Add("@IsEmailVerified", user.IsEmailVerified);
                dynamicParameters.Add("@VerificationCode", user.VerificationCode);
                dynamicParameters.Add("@ActivationCode", user.ActivationCode);

                return await sqlConnection.ExecuteAsync(
                    RepositoryConstants.sp_UpdateUser,
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> DeleteUserAsync(int id)
        {
            using (var sqlConnection = _dbProvider.GetDbConnection())
            {
                sqlConnection.Open();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@id", id);
                return await sqlConnection.ExecuteAsync(
                    RepositoryConstants.sp_DeleteUser,
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            using (var sqlConnection = _dbProvider.GetDbConnection())
            {
                sqlConnection.Open();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@email", email);
                return await sqlConnection.QueryFirstOrDefaultAsync(
                    RepositoryConstants.sp_GetUserByEmailId,
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public Task<int> VerifyUserAsync(string activationcode)
        {
            throw new NotImplementedException();
        }
    }
}
