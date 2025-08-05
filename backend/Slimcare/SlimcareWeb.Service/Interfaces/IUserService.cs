using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlimcareWeb.DataAccess.Entities;
using SlimcareWeb.Service.Dtos.User;

namespace SlimcareWeb.Service.Interfaces
{
    public interface IUserService
    {
        Task<User> AddAsync(CreateUserDto data);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<string?> GetEmailAsync(int id);
        Task<User> LoginAsync(UserLoginDTO data);
        Task<User> SoftDeleteAsync(int id);
        Task<User> UpdateAsync(UpdateUserDto data);
    }
}
