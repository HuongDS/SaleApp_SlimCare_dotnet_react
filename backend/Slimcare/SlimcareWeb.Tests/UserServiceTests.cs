using AutoMapper;
using Moq;
using SlimcareWeb.DataAccess.Entities;
using SlimcareWeb.DataAccess.Enums;
using SlimcareWeb.DataAccess.Interface;
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

        public UserServiceTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _BCrypt = new BCryptHelper();
            _mapperMock = new Mock<IMapper>();
            _userService = new UserService(_userRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task Post_LoginWithValidAccount_ReturnUserModelAsync()
        {
            // Arrange  
            var input = new UserLoginDTO("validUsername", "hashedPassword");
            var salting = _BCrypt.GenerateSalting(100);
            var realPass = input.Password + salting;
            var hashedPassword = _BCrypt.BCryptHash(realPass);
            var expectedUser = new User(1, input.Username, hashedPassword, "validUser@gmail.com", DataAccess.Enums.Role.USER, DateTime.MinValue, salting);
            _userRepositoryMock.Setup(u => u.GetUserByUsername(input.Username)).ReturnsAsync(expectedUser);
            input.Password += expectedUser.Salting;
            var check = _BCrypt.BCryptVerify(input.Password, expectedUser.Password);
            // Act  
            var user = await _userService.LoginAsync(input);
            // Assert  
            Assert.NotNull(user);
            Assert.True(check);
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
            var expectedUser = new User(1, input.Username, "vallidPassword", "validUser@gmail.com", DataAccess.Enums.Role.USER, DateTime.MinValue, "abc");
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