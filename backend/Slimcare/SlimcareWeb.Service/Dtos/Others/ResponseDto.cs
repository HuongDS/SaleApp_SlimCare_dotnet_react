using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlimcareWeb.DataAccess.Entities;


namespace SlimcareWeb.Service.Dtos.Others
{
    public class ResponseDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public int ExpiresIn { get; set; }
        public DataAccess.Entities.User User { get; set; }
        public string Role { get; set; }

        public ResponseDto(string accessToken, string refreshToken, int expiresIn, DataAccess.Entities.User user, string role)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            ExpiresIn = expiresIn;
            User = user;
            Role = role;
        }
    }
}
