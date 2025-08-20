using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlimcareWeb.DataAccess.Entities;
using SlimcareWeb.DataAccess.Interfaces;
using SlimcareWeb.Service.Dtos.Others;
using SlimcareWeb.Service.Dtos.User;
using SlimcareWeb.Service.Interfaces;

namespace SlimcareWeb.Service.Services
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IJwtTokenService _jwtTokenService;

        public RefreshTokenService(IRefreshTokenRepository refreshTokenRepository, IJwtTokenService jwtTokenService)
        {
            this._refreshTokenRepository = refreshTokenRepository;
            this._jwtTokenService = jwtTokenService;
        }

        public async Task<RefreshToken?> FindValidAsync(string plainToken)
        {
            var candidates = await _refreshTokenRepository.FindValidRefreshToken();
            foreach (var item in candidates)
            {
                if (_jwtTokenService.VerifyRefreshToken(plainToken, item.TokenSalt, item.TokenHash))
                {
                    return item;
                }
            }
            return null;
        }

        public async Task RevokeAsync(string plainToken)
        {
            var refreshToken = await FindValidAsync(plainToken);
            if (refreshToken != null)
            {
                refreshToken.RevokeAt = DateTime.UtcNow;
                await _refreshTokenRepository.UpdateAsync(refreshToken);
                await _refreshTokenRepository.SoftDeleteAsync(refreshToken.Id);
            }
        }

        public async Task SaveAsync(RefreshToken token)
        {
            await _refreshTokenRepository.AddAsync(token);
        }

        public async Task UpdateAsync(RefreshToken token)
        {
            await _refreshTokenRepository.UpdateAsync(token);
        }
        public async Task<int> SoftDeleteAsync(int id)
        {
            return await _refreshTokenRepository.SoftDeleteAsync(id);
        }
        public async Task<int> AddAsync(RefreshToken refreshToken)
        {
            return await _refreshTokenRepository.AddAsync(refreshToken);
        }
        public async Task<RefreshToken?> FindRefreshTokenByUserId(int id)
        {
            return await _refreshTokenRepository.FindByUserIdAsync(id);
        }
    }
}
