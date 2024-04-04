using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class UserLogic
    {
        private readonly UserRepository _userRepository;

        public UserLogic(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool RegisterUser(string username, string password, string email)
        {
            // Validate user input (e.g., check for duplicate usernames, password strength, etc.)
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(email))
            {
                // Input validation failed
                return false;
            }

            // Hash the password
            string hashedPassword = PasswordHasher.HashPassword(password);

            // Insert user into database
            _userRepository.InsertUser(username, hashedPassword, email);

            return true;
        }
    }
}