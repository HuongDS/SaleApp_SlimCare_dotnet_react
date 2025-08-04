using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimcareWeb.Service.Dtos.User
{
    public class UserLoginDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public UserLoginDTO(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
    }
}
