using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimcareWeb.Service.DTO
{
    public class UserLoginDTO
    {
        public string username { get; set; }
        public string password { get; set; }

        public UserLoginDTO(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
