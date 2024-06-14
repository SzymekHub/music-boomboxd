using Infrastructure;
using Infrastructure.DTOs;
using Infrastructure.InterfacesForRepo;
using Infrastructure.Repositories;
using Logic.Algorithms;
using Logic.Interfaces;

namespace Logic
{
    public class PasswordHasher : IPasswordHasher
    {
        private readonly string Pepper = "20082004";

        public string HashPassword(string password)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt();

            string pepperedPassword = password + Pepper;

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(pepperedPassword, salt);

            return hashedPassword;
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            // Concatenates pepper with the password
            string pepperedPassword = password + Pepper;

            // Uses BCrypt.Net's Verify method to verify the password
            return BCrypt.Net.BCrypt.Verify(pepperedPassword, hashedPassword);
        }
    }
}
