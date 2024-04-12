using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace Infrastructure
{
    public class PasswordHasher
    {
        private static readonly string Pepper = "20082004";

        public static string HashPassword(string password)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt();

            string pepperedPassword = password + Pepper;

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(pepperedPassword, salt);

            return hashedPassword;
        }
    }
}
