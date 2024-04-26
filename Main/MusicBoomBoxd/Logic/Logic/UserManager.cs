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
        private List<User> _users;
        private readonly UserRepository _userRepository;
        private readonly LoadUsers _loadUsers;

        public UserManager(LoadUsers loadUsers)
        {
            _users = new List<User>();
            _loadUsers = loadUsers;
            _userRepository = new UserRepository();
        }

        public void LoadUsersFromDataBase()
        {
            List<UserDTO> userDTOs = _loadUsers.LoadAllUsers();
            foreach (var userDTO in userDTOs)
            {
                //This converts UserDTO to Users and adds to the songs list
                User user = ConvertToUser(userDTO);
                _users.Add(user);
            }
        }

        private User ConvertToUser(UserDTO userDTO)
        {
            //this converts UserDto to users
            return new User(
                userDTO.UserName,
                userDTO.Password,
                userDTO.Email,
                (userType)Enum.Parse(typeof(userType), userDTO.UserType),
                userDTO.Birthday,
                (genreType)Enum.Parse(typeof(genreType), userDTO.FavGenre),
                userDTO.ProfilePictureName,
                userDTO.ProfilePictureData,
                userDTO.ProfilePictureContentType
                );
        }

        public void Add(User user)
        {
            //Converts the genre enum to a string 
            string genreString = user.FavGenre.ToString();
            
            //Converts the user enum to a string 
            string userString = user.UserType.ToString();

            if (Enum.TryParse(typeof(genreType), genreString, out object genre) && Enum.TryParse(typeof(userType), userString, out object usertype))
            {
                // this converts User to UserDTO
                UserDTO userDTO = new UserDTO(
                        user.UserName,
                        user.Password,
                        user.Email,
                        userString,
                        user.Birthday,
                        genreString,
                        user.ProfilePictureName,
                        user.ProfilePictureData,
                        user.ProfilePictureContentType
                    );

                SendToTheDb(userDTO);
                // Add the user to the list of users
                _users.Add(user);
            }
        }

        public User[] GetArray()
        {
            return _users.ToArray();
        }

        public bool Remove(User user)
        {
            return _users.Remove(user);
        }

        // Method to update an existing user
        public void UpdateUser(User newUser, User oldUser)
        {
            //These are UserDTO object for the new and old users
            UserDTO newUserDTO = new UserDTO(
                    newUser.UserName,
                    newUser.Password,
                    newUser.Email,
                    newUser.UserType.ToString(),
                    newUser.Birthday,
                    newUser.FavGenre.ToString(),
                    newUser.ProfilePictureName,
                    newUser.ProfilePictureData,
                    newUser.ProfilePictureContentType
                );

            UserDTO oldUserDTO = new UserDTO(
                    oldUser.UserName,
                    oldUser.Password,
                    oldUser.Email,
                    oldUser.UserType.ToString(),
                    oldUser.Birthday,
                    oldUser.FavGenre.ToString(),
                    oldUser.ProfilePictureName,
                    oldUser.ProfilePictureData,
                    oldUser.ProfilePictureContentType
                );

            //This calls the repository method to update the User
            bool success = _userRepository.UpdateUser(newUserDTO, oldUserDTO);
            
            if (success)
            {
                int index = _users.FindIndex(u => u == oldUser);
                if (index != 1)
                {
                    _users[index] = newUser;
                }
            }
            else
            {
                Console.WriteLine("Looks like something went wrong when updating the User in the database :(");
            }
        }

        public bool SendToTheDb(UserDTO newUser)
        {
            string HashedPassword = PasswordHasher.HashPassword(newUser.Password);

            newUser.Password = HashedPassword;  

            return _userRepository.InsertUser(newUser);

        }

    }
}