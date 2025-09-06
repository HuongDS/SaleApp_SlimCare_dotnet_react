using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimcareWeb.Service.Dtos.User
{
    public class ResponseUserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public ResponseUserDto(int id, string username, string email, string role)
        {
            Id = id;
            Username = username;
            Email = email;
            Role = role;
        }
    }
}
