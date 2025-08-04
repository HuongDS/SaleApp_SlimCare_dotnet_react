using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SlimcareWeb.DataAccess.Entities;
using SlimcareWeb.DataAccess.Interface;

namespace SlimcareWeb.DataAccess.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(SlimCareDbContext dbContext) : base(dbContext)
        {
        }
        public Task<User?> Login(string username, string password)
        {
            return _dbContext.Users.SingleOrDefaultAsync(u => u.Username.Equals(username) && u.Password.Equals(password));
        }
        public async Task<bool> CheckUsernameExist(string username)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(u => u.Username.Equals(username)) != null;
        }
        public async Task<bool> CheckPassword(string password)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(u => u.Password.Equals(password)) != null;
        }
        public async Task<bool> CheckEmailExist(string email)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(u => u.Email.Equals(email)) != null;
        }
        public async Task<string> GetEmail(string id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id.Equals(id));
            if (user == null)
            {
                throw new Exception("Email not found");
            }
            return user.Email;
        }
    }
}
