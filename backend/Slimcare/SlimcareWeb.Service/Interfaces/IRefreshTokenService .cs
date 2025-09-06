using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlimcareWeb.DataAccess.Entities;
using SlimcareWeb.Service.Dtos.Others;
using SlimcareWeb.Service.Dtos.User;

namespace SlimcareWeb.Service.Interfaces
{
    public interface IRefreshTokenService
    {
        Task SaveAsync(RefreshToken token);
        Task<RefreshToken?> FindValidAsync(string plainToken);
        Task UpdateAsync(RefreshToken token);
        Task RevokeAsync(string plainToken);
        Task<int> SoftDeleteAsync(int id);
        Task<int> AddAsync(RefreshToken refreshToken);
        Task<RefreshToken?> FindRefreshTokenByUserId(int userId);
        Task RevokeAsync(int userId);
    }
}
