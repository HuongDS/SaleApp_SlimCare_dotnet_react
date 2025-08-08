using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SlimcareWeb.DataAccess.Entities;
using SlimcareWeb.DataAccess.Interface;
using SlimcareWeb.Service.Dtos.User;
using SlimcareWeb.Service.Helpers;
using SlimcareWeb.Service.Interfaces;

namespace SlimcareWeb.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly BCryptHelper _BCryptHelper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this._userRepository = userRepository;
            this._mapper = mapper;
            this._BCryptHelper = new BCryptHelper();
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }
        public async Task<User?> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }
        public async Task<string?> GetEmailAsync(int id)
        {
            return await _userRepository.GetEmailAsync(id);
        }
        public async Task<User> LoginAsync(UserLoginDTO data)
        {
            var user = await _userRepository.GetUserByUsername(data.Username);
            if (user == null)
            {
                throw new Exception("Invalid username.");
            }
            data.Password += user.Salting;
            if (!_BCryptHelper.BCryptVerify(data.Password, user.Password))
            {
                throw new Exception("Password is not correct.");
            }
            return user;
        }
        public async Task<User> AddAsync(CreateUserDto data)
        {
            var checkEmail = await _userRepository.CheckEmailExist(data.Email);
            var checkUsername = await _userRepository.CheckUsernameExist(data.Username);
            if (checkEmail)
            {
                throw new Exception("Email already exists");
            }
            if (checkUsername)
            {
                throw new Exception("Username already exists");
            }
            // Process password
            var salt = _BCryptHelper.GenerateSalting(100);
            data.Password += salt;
            var user = _mapper.Map<User>(data);
            user.Salting = salt;
            user.Password = _BCryptHelper.BCryptHash(user.Password);
            user.Delete_At = DateTime.MinValue;
            await _userRepository.AddAsync(user);
            return user;
        }
        public async Task<User> UpdateAsync(UpdateUserDto data)
        {
            var user = await _userRepository.GetByIdAsync(data.Id);
            if (user == null)
            {
                throw new Exception("Not Found User with Id: " + data.Id);
            }
            user = _mapper.Map<User>(data);
            await _userRepository.UpdateAsync(user);
            return user;
        }
        public async Task<User> SoftDeleteAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                throw new Exception("Not Found User with Id: " + id);
            }
            await _userRepository.SoftDeleteAsync(id);
            return user;
        }
    }
}
