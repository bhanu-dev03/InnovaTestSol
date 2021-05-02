using AutoMapper;
using InnovaSolTest.Models.Entities;
using InnovaSolTest.Models.ServiceModels;
using InnovaSolTest.Repositories.Interfaces;
using InnovaSolTest.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSolTest.Services.Managers
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<int> DeleteUserAsync(int id)
        {
            return await _userRepository.DeleteUserAsync(id);
        }

        public async Task<UserDto> GetUserAsync(string email)
        {
            var user= await _userRepository.GetUserByEmailAsync(email);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetUserAsync(int id)
        {
            var user = await _userRepository.GetUserAsync(id);
            return _mapper.Map<UserDto>(user);
        }

        public Task<UserDto> GetUserByCodeAsync(string activationcode)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> GetUserByEmailAsync(string email)
        {
            var user =  await _userRepository.GetUserByEmailAsync(email);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<int> SaveUserAsync(UserDto user)
        {
            var _user = _mapper.Map<User>(user);
            return await _userRepository.SaveUserAsync(_user);
        }

        public async Task<int> UpdateUserAsync(UserDto user)
        {
            var _user = _mapper.Map<User>(user);
            return await  _userRepository.UpdateUserAsync(_user);
        }

        public async Task<int> VerifyUserAsync(string activationcode)
        {
            return await _userRepository.VerifyUserAsync(activationcode);
        }
    }
}
