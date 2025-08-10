using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlimcareWeb.DataAccess.Entities;

namespace SlimcareWeb.Service.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateAccessToken(User user);
        (string plain, RefreshToken entity) GenerateRefreshToken(int userId, TimeSpan lifetime);
        bool VerifyRefreshToken(string plain, string salt, string hash);
        string ComputeHash(string token, string salt);
    }
}
