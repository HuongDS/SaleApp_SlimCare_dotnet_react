using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlimcareWeb.DataAccess.Entities;
using SlimcareWeb.DataAccess.Interface;

namespace SlimcareWeb.DataAccess.Interfaces
{
    public interface IRefreshTokenRepository : IGenericRepository<RefreshToken>
    {
        Task<RefreshToken?> FindByUserIdAsync(int userId);
        Task<List<RefreshToken>> FindValidRefreshToken();
    }
}
