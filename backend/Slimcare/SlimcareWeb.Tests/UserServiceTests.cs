using AutoMapper;
using Castle.Core.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Moq;
using SlimcareWeb.DataAccess.Entities;
using SlimcareWeb.DataAccess.Enums;
using SlimcareWeb.DataAccess.Interface;
using SlimcareWeb.DataAccess.Interfaces;
using SlimcareWeb.DataAccess.Repositories;
using SlimcareWeb.Service.AppsettingsConfigurations;
using SlimcareWeb.Service.Dtos.Others;
using SlimcareWeb.Service.Dtos.User;
using SlimcareWeb.Service.Helpers;
using SlimcareWeb.Service.Interfaces;
using SlimcareWeb.Service.Services;

namespace SlimcareWeb.Tests
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly BCryptHelper _BCrypt;
        private readonly Mock<IMapper> _mapperMock;
        private readonly UserService _userService;
        private readonly Mock<IJwtTokenService> _jwtTokenService;
        private readonly Mock<IRefreshTokenService> _refreshTokenService;
        private readonly JwtSettings _jwtSettings;

        public UserServiceTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _BCrypt = new BCryptHelper();
            _mapperMock = new Mock<IMapper>();
            _jwtTokenService = new Mock<IJwtTokenService>();
            _jwtSettings = new JwtSettings();
            _refreshTokenService = new Mock<IRefreshTokenService>();
            _userService = new UserService(_userRepositoryMock.Object, _mapperMock.Object, _jwtTokenService.Object, _jwtSettings, _refreshTokenService.Object);
        }

        [Fact]
        public async Task Post_LoginWithValidAccount_ReturnResponseDtoAsync()
        {
            // Arrange  
            var input = new UserLoginDTO("validUsername", "hashedPassword");
            var salting = _BCrypt.GenerateSalting(100);
            var hashedPassword = _BCrypt.BCryptHash(input.Password + salting);
            var expectedUser = new User
            {
                Id = 1,
                Username = input.Username,
                Password = hashedPassword,
                Email = "validUser@gmail.com",
                Role = DataAccess.Enums.Role.USER,
                Delete_At = DateTime.MinValue,
                Salting = salting
            };
            _userRepositoryMock.Setup(u => u.GetUserByUsername(input.Username)).ReturnsAsync(expectedUser);
            var check = _BCrypt.BCryptVerify(input.Password + expectedUser.Salting, expectedUser.Password);
            var accessToken = "validAccessToken";
            _jwtTokenService.Setup(j => j.GenerateAccessToken(expectedUser)).Returns(accessToken);
            var refreshToken = new RefreshToken
            {
                Id = 9999,
                UserId = expectedUser.Id,
                User = expectedUser,
                TokenHash = "9999",
                TokenSalt = "salt",
                ExpiresAt = DateTime.UtcNow.AddDays(14),
                CreatedAt = DateTime.UtcNow,
                RevokeAt = DateTime.MinValue,
                Delete_At = DateTime.MinValue
            };
            var rtPlain = "validRefreshToken";
            _jwtTokenService.Setup(j => j.GenerateRefreshToken(expectedUser.Id, TimeSpan.FromDays(14))).Returns((rtPlain, refreshToken));
            _refreshTokenService.Setup(r => r.AddAsync(It.IsAny<RefreshToken>())).ReturnsAsync(1);
            var useResponse = new ResponseUserDto(expectedUser.Id, expectedUser.Username, expectedUser.Email, expectedUser.Role.ToString());
            var expectedResponse = new ResponseDto(accessToken, rtPlain, 15, useResponse, Role.USER.ToString());
            // Act  
            var response = await _userService.LoginAsync(input);
            // Assert  
            Assert.Equal(accessToken, response.AccessToken);
            Assert.Equal(rtPlain, response.RefreshToken);
        }

        [Fact]
        public async Task Post_LoginWithInValidUsername_ThrowException()
        {
            // Arrange  
            var input = new UserLoginDTO("inValidUsername", "inValidPassword");
            var expectedUser = new User(1, "validUsername", "vallidPassword", "validUser@gmail.com", DataAccess.Enums.Role.USER, DateTime.MinValue, "abc");
            _userRepositoryMock.Setup(u => u.GetUserByUsername(input.Username)).ReturnsAsync((User?)null);
            // Act  
            var result = async () => await _userService.LoginAsync(input);
            // Assert  
            var exception = await Assert.ThrowsAsync<Exception>(result);
            Assert.Equal("Invalid username.", exception.Message);
        }

        [Fact]
        public async Task Post_LoginWithInValidPassword_ThrowException()
        {
            // Arrange  
            var input = new UserLoginDTO("validUsername", "inValidPassword");
            var salting = _BCrypt.GenerateSalting(100);
            var hashedPassword = _BCrypt.BCryptHash("validPassword" + salting);
            var expectedUser = new User
            {
                Id = 1,
                Username = input.Username,
                Password = hashedPassword,
                Email = "validUser@gmail.com",
                Role = DataAccess.Enums.Role.USER,
                Delete_At = DateTime.MinValue,
                Salting = salting
            };
            _userRepositoryMock.Setup(u => u.GetUserByUsername(input.Username)).ReturnsAsync(expectedUser);
            input.Password += expectedUser.Salting;
            // Act  
            var result = async () => await _userService.LoginAsync(input);
            // Assert  
            var exception = await Assert.ThrowsAsync<Exception>(result);
            Assert.Equal("Password is not correct.", exception.Message);
        }

        [Fact]
        public async Task Post_RegisterWithValidInput_ReturnUserModelAsync()
        {
            // Arrange
            var input = new CreateUserDto
            {
                Username = "newUser",
                Password = "newPassword",
                Email = "newUserEmail@gmail.com",
                Role = Role.USER
            };
            var expectedUser = new User(1, input.Username, input.Password, input.Email, input.Role, DateTime.MinValue, "abc");
            var salting = _BCrypt.GenerateSalting(100);
            expectedUser.Password = _BCrypt.BCryptHash(input.Password + salting);
            _userRepositoryMock.Setup(u => u.CheckEmailExist(input.Email)).ReturnsAsync(false);
            _userRepositoryMock.Setup(u => u.CheckUsernameExist(input.Username)).ReturnsAsync(false);
            _mapperMock.Setup(m => m.Map<User>(input)).Returns(expectedUser);
            // Act
            var result = await _userService.AddAsync(input);
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Post_RegisterWithExistedEmail_ThrowException()
        {
            // Arrange
            var input = new CreateUserDto
            {
                Username = "newUser",
                Password = "newPassword",
                Email = "ExistedEmail@gmail.com",
                Role = Role.USER
            };
            _userRepositoryMock.Setup(u => u.CheckEmailExist(input.Email)).ReturnsAsync(true);
            // Act
            var result = async () => await _userService.AddAsync(input);
            // Assert
            var exception = await Assert.ThrowsAsync<Exception>(result);
            Assert.Equal("Email already exists", exception.Message);
        }

        [Fact]
        public async Task Post_RegisterWithExistedUsername_ThrowException()
        {
            // Arrange
            var input = new CreateUserDto
            {
                Username = "ExistedUsername",
                Password = "newPassword",
                Email = "email@gmail.com",
                Role = Role.USER
            };
            _userRepositoryMock.Setup(u => u.CheckEmailExist(input.Email)).ReturnsAsync(false);
            _userRepositoryMock.Setup(u => u.CheckUsernameExist(input.Username)).ReturnsAsync(true);
            // Act
            var result = async () => await _userService.AddAsync(input);
            // Assert
            var exception = await Assert.ThrowsAsync<Exception>(result);
            Assert.Equal("Username already exists", exception.Message);
        }
    }
}