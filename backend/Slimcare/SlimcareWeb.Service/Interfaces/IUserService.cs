using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SlimcareWeb.DataAccess.Entities;
using SlimcareWeb.Service.Dtos.User;
using SlimcareWeb.Service.Dtos.Others;

namespace SlimcareWeb.Service.Interfaces
{
    public interface IUserService
    {
        Task<User> AddAsync(CreateUserDto data);
        Task<ResponseDto> GenerateResponseFromUser(User user);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<string?> GetEmailAsync(int id);
        Task<ResponseDto> LoginAsync(UserLoginDTO data);
        Task<ResponseDto> LoginByGoogle([FromBody] GoogleLoginDto data);
        Task Logout([FromBody] RefreshTokenDto data);
        Task<ResponseDto> RotateRefreshToken(RefreshTokenDto refreshToken);
        Task<User> SoftDeleteAsync(int id);
        Task<User> UpdateAsync(UpdateUserDto data);
    }
}
