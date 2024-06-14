using Infrastructure;
using Infrastructure.DTOs;
using Infrastructure.InterfacesForRepo;
using Infrastructure.Repositories;
using Logic.Algorithms;
using Logic.Interfaces;
using System.Collections.Generic;

namespace Logic
{
    public class ValidateUser : IValidateUser
    {
        private readonly IUserRepository _userRepository;

        public ValidateUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Dictionary<string, List<string>> ValidateUsers(string username)
        {
            var errors = new Dictionary<string, List<string>>();

            if (UsernameExists(username))
            {
                errors.TryAdd("username", new List<string>());
                errors["username"].Add("Username is already taken");
            }
            return errors;
        }

        public Dictionary<string, List<string>> ValidateUsersWEB(User user)
        {
            var errors = new Dictionary<string, List<string>>();

            if (IsUsernameOrEmailTaken(user.Username, user.Email, user.UserID))
            {
                if (UsernameExists(user.Username))
                {
                    errors.TryAdd("username", new List<string>());
                    errors["username"].Add("Username is already taken");
                }
                if (EmailExists(user.Email))
                {
                    errors.TryAdd("email", new List<string>());
                    errors["email"].Add("Email is already taken");
                }
            }
            return errors;
        }

        public bool IsUsernameOrEmailTaken(string username, string email, int userId)
        {
            var existingUserByUsername = _userRepository.GetUserByUsername(username);
            var existingUserByEmail = _userRepository.GetUserByEmail(email);

            return (existingUserByUsername != null && existingUserByUsername.UserID != userId) || (existingUserByEmail != null && existingUserByEmail.UserID != userId);
        }

        public bool UsernameExists(string username)
        {
            UserDTO userDTO = _userRepository.GetUserByUsername(username);
            return userDTO != null;
        }
        public bool EmailExists(string email)
        {
            UserDTO userDTO = _userRepository.GetUserByEmail(email);
            return userDTO != null;
        }
    }
}
