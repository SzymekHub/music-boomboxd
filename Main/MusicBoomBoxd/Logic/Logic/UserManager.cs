using Infrastructure;
using Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class UserManager
    {
        UserRepository userRepository = new UserRepository();
        private List<User> _users;

        public UserManager()
        {
            // Initialize an empty list of users
            _users = new List<User>();
        }

        public User[] GetArray()
        {
            return _users.ToArray();
        }

        // Method to add a new user
        public void AddUser(User user)
        {
            // Assign a unique ID to the user
            user.UserID = GenerateUniqueId();

            // Add the user to the list of users
            _users.Add(user);
        }

        // Method to update an existing user
        public void UpdateUser(User user)
        {
            // Find the user in the list by ID
            User existingUser = _users.FirstOrDefault(u => u.UserID == user.UserID);

            if (existingUser != null)
            {
                // Update user details
                existingUser.UserName = user.UserName;
                existingUser.Email = user.Email;
            }
            else
            {
                throw new ArgumentException("User not found");
            }
        }

        // Method to delete a user
        public void DeleteUser(int userId)
        {
            // Find and remove the user from the list by ID
            User userToRemove = _users.FirstOrDefault(u => u.UserID == userId);

            if (userToRemove != null)
            {
                _users.Remove(userToRemove);
            }
            else
            {
                throw new ArgumentException("User not found");
            }
        }

        public List<User> GetAllUsers()
        {
            return _users;
        }

        // Method to search for users by username or email
        public List<User> SearchUsers(string searchText)
        {
            return _users.Where(u => u.UserName.Contains(searchText) || u.Email.Contains(searchText)).ToList();
        }

        // Method to generate a unique ID for new users
        private int GenerateUniqueId()
        {
            // If there are no users, return 1 as the first ID
            if (_users.Count == 0)
            {
                return 1;
            }

            // Otherwise, find the maximum ID and add 1 to it
            return _users.Max(u => u.UserID) + 1;
        }

        public bool SendToTheDb(UserDTO newUser)
        {
            string HashedPassword = PasswordHasher.HashPassword(newUser.Password);

            newUser.Password = HashedPassword;  

            return userRepository.InsertUser(newUser);

        }

    }
}