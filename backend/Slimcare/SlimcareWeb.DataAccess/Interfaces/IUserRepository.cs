using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlimcareWeb.DataAccess.Entities;

namespace SlimcareWeb.DataAccess.Interface
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<bool> CheckEmailExist(string email);
        Task<bool> CheckPassword(string password);
        Task<bool> CheckUsernameExist(string username);
        Task<string> GetEmailAsync(int id);
        Task<User?> GetUserByUsername(string username);
    }
}
