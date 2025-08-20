using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SlimcareWeb.DataAccess.Entities;
using SlimcareWeb.DataAccess.Interfaces;

namespace SlimcareWeb.DataAccess.Repositories
{
    public class RefreshTokenRepository : GenericRepository<RefreshToken>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(SlimCareDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<RefreshToken>> FindValidRefreshToken()
        {
            return await _dbContext.RefreshTokens.Where(rt => rt.RevokeAt == DateTime.MinValue && rt.Delete_At == DateTime.MinValue && rt.ExpiresAt > DateTime.UtcNow).Take(500).ToListAsync();
        }
        public async Task<RefreshToken?> FindByUserIdAsync(int userId)
        {
            return await _dbSet.FirstOrDefaultAsync(rt => rt.UserId == userId && rt.RevokeAt == DateTime.MinValue && rt.Delete_At == DateTime.MinValue);
        }
    }
}
