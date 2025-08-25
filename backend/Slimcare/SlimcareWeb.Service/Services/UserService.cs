
using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SlimcareWeb.DataAccess.Entities;
using SlimcareWeb.DataAccess.Enums;
using SlimcareWeb.DataAccess.Interface;
using SlimcareWeb.DataAccess.Interfaces;
using SlimcareWeb.Service.AppsettingsConfigurations;
using SlimcareWeb.Service.Dtos.Others;
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
        private readonly IConfiguration _configuration;
        private readonly IGoogleService _googleService;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly JwtSettings _jwtSettings;
        private readonly IRefreshTokenService _refreshTokenService;
        private IUserRepository object1;
        private IMapper object2;

        public UserService(IUserRepository userRepository, IMapper mapper, IConfiguration configuration, IGoogleService googleService,
            IJwtTokenService jwtTokenService, IOptions<JwtSettings> jwtSettings,
            IRefreshTokenService refreshTokenService)
        {
            this._userRepository = userRepository;
            this._mapper = mapper;
            this._BCryptHelper = new BCryptHelper();
            this._configuration = configuration;
            this._googleService = googleService;
            this._jwtTokenService = jwtTokenService;
            this._jwtSettings = jwtSettings.Value;
            this._refreshTokenService = refreshTokenService;
        }

        public UserService(IUserRepository userRepository, IMapper mapper, IJwtTokenService jwtTokenService, JwtSettings jwtSettings, IRefreshTokenService refreshTokenService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _BCryptHelper = new BCryptHelper();
            _jwtTokenService = jwtTokenService;
            _jwtSettings = jwtSettings;
            _refreshTokenService = refreshTokenService;
        }

        public UserService(IUserRepository object1, IMapper object2)
        {
            this.object1 = object1;
            this.object2 = object2;
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
        public async Task<ResponseDto> LoginAsync(UserLoginDTO data)
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
            if (user.Delete_At != DateTime.MinValue)
            {
                throw new Exception("User has been banned.");
            }
            var response = await GenerateResponseFromUser(user);
            return response;
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

        public async Task<ResponseDto> LoginByGoogle([FromBody] GoogleLoginDto data)
        {
            // Verify Token ID from Google
            var clientId = _configuration["GoogleAuth:ClientId"];
            var user = new User();
            try
            {
                var payload = await _googleService.VerifyGoogleToken(clientId, data.IdToken);
                if (payload != null)
                {
                    user = await _userRepository.GetUserByEmail(payload.Email);
                    if (user == null)
                    {
                        await RegisterByGoogle(payload.Email, payload.Name);
                        user = await _userRepository.GetUserByEmail(payload.Email);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Google login failed: " + e.Message);
            }
            var response = await GenerateResponseFromUser(user);
            return response;
        }

        public async Task RegisterByGoogle(string email, string name)
        {
            var createUser = new CreateUserDto
            {
                Username = name,
                Email = email,
                Password = "GoogleLogin",
                Role = Role.USER,
            };
            var user = _mapper.Map<User>(createUser);
            var salting = _BCryptHelper.GenerateSalting(100);
            user.Salting = salting;
            user.Password += salting;
            user.Password = _BCryptHelper.BCryptHash(user.Password);
            user.Delete_At = DateTime.MinValue;
            await _userRepository.AddAsync(user);
        }

        public async Task Logout([FromBody] RefreshTokenDto data)
        {
            if (data.refreshToken != null)
            {
                await _refreshTokenService.RevokeAsync(data.refreshToken);
                Console.WriteLine("User logged out successfully.");
            }
            else
            {
                Console.WriteLine("User logged out fail.");
            }
        }
        public async Task<ResponseDto> GenerateResponseFromUser(User user)
        {
            var accessToken = _jwtTokenService.GenerateAccessToken(user);
            var (rtPlain, rtEntity) = _jwtTokenService.GenerateRefreshToken(user.Id, TimeSpan.FromDays(_jwtSettings.RefreshTokenLifetimeDays));
            await _refreshTokenService.AddAsync(rtEntity);
            var response = new ResponseDto(accessToken, rtPlain, _jwtSettings.ExpirationInMinutes, user, Role.USER.ToString());
            return response;
        }
        public async Task<ResponseDto> RotateRefreshToken(RefreshTokenDto refreshToken)
        {
            var oldRefreshToken = await _refreshTokenService.FindValidAsync(refreshToken.refreshToken);
            if (oldRefreshToken == null)
            {
                throw new UnauthorizedAccessException("Invalid or expired refresh token");
            }
            var user = await _userRepository.GetByIdAsync(oldRefreshToken.UserId);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            oldRefreshToken.RevokeAt = DateTime.UtcNow;
            await _refreshTokenService.SoftDeleteAsync(oldRefreshToken.Id);
            var response = await GenerateResponseFromUser(user);
            return response;
        }
    }
}