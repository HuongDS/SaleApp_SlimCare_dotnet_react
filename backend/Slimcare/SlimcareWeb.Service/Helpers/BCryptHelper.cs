using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimcareWeb.Service.Helpers
{
    public class BCryptHelper
    {
        public static string BCryptHash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        public static bool BCryptVerify(string passwordFromDb, string passwordFromUser)
        {
            return BCrypt.Net.BCrypt.Verify(passwordFromUser, passwordFromDb);
        }
        public static string GenerateSalting(int length)
        {
            StringBuilder salt = new StringBuilder();
            var random = new Random();
            for (int i = 0; i < length; i++)
            {
                salt.Append(random.Next('a', 'z'));
            }
            return salt.ToString();
        }
    }
}
