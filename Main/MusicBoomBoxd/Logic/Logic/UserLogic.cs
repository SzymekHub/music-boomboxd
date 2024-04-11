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
            // Hash the password
            string hashedPassword = PasswordHasher.HashPassword(password);

            // Insert user into database
            _userRepository.InsertUser(username, hashedPassword, email);

            return true;
        }
    }
}