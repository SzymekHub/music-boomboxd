using Infrastructure;
using Infrastructure.DTOs;
using Infrastructure.Interfaces;
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
        private readonly IUserRepository _iuserRepostiory;

        public UserManager(UserRepository userRep, IUserRepository iuserRep)
        {
            _users = new List<User>();
            _userRepository = userRep;
            _iuserRepostiory = iuserRep;

            // inject the repository and use userRepistory as an interface and inject it as well. Get rid of Load stuff.
        }

        public void LoadUsersFromDataBase()
        {
            List<UserDTO> userDTOs = _userRepository.GetRecentUser(1000);
            _users.Clear();
            foreach (var userDTO in userDTOs)
            {
                //This converts UserDTO to Users and adds to the users list
                User user = ConvertToUser(userDTO);
                _users.Add(user);
            }
        }

        public Result Add(User user)
        {
            UserDTO userDTO = ConvertToUserDTO(user);
            
            _users.Add(user);

            Result resultfailed = new Result { Success = false, Message = "" };

            Result resultUser = SendToTheDb(userDTO);
            
            if (resultfailed.Success == false) 
            {
                return resultfailed;
            }
            else
            {
                return resultUser;
            }
        }
        
        public bool Remove(User user)
        {
            _userRepository.DeleteUser(ConvertToUserDTO(user));
            return _users.Remove(user);
        }

        public User[] GetArray()
        {
            return _users.ToArray();
        }

        // Method to update an existing user
        public Result Update(User newUser, User oldUser)
        {
            UserDTO newUserDTO = ConvertToUserDTO(newUser);

            UserDTO oldUserDTO = ConvertToUserDTO(oldUser);

            //This calls the repository method to update the User
            Result resultupdate = _userRepository.UpdateUser(newUserDTO, oldUserDTO);

            if (resultupdate.Success)
            {
                LoadUsersFromDataBase();
                int index = _users.FindIndex(ur => ur == oldUser);

                if (index != -1)
                {
                    _users[index] = newUser;
                }
            }
            else
            {
                Console.WriteLine("Something went wrong when updating the user");
            }

            return resultupdate;
        }

        public Result SendToTheDb(UserDTO newUser)
        {
            string HashedPassword = PasswordHasher.HashPassword(newUser.Password);

            newUser.Password = HashedPassword;  

            return _userRepository.InsertUser(newUser);

        }
        public User ConvertToUser(UserDTO newUserDTO)
        {
            //Converts the user role enum to a string
            userType user = (userType)Enum.Parse(typeof(userType), newUserDTO.UserType);

            //Converts the genre enum to a string 
            genreType genre = (genreType)Enum.Parse(typeof(genreType), newUserDTO.FavGenre);

            //this converts UserDto to users
            return new User(
                newUserDTO.UserID,
                newUserDTO.UserName,
                newUserDTO.Password,
                newUserDTO.Email,
                user,
                newUserDTO.Birthday,
                genre,
                newUserDTO.ProfilePictureName,
                newUserDTO.ProfilePictureData,
                newUserDTO.ProfilePictureContentType
                );

            //try and use a tryparse
        }

        public UserDTO ConvertToUserDTO(User user)
        {
            // this converts User to UserDTO
            return new UserDTO(
                user.UserID,
                user.UserName,
                user.Password,
                user.Email,
                user.UserType.ToString(),
                user.Birthday,
                user.FavGenre.ToString(),
                user.ProfilePictureName,
                user.ProfilePictureData,
                user.ProfilePictureContentType
                );
        }
    }
}