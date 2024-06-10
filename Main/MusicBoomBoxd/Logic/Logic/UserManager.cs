using Infrastructure;
using System.Collections.Generic;

namespace Logic
{
    public class UserManager
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidateUser _validateUsers;
        private readonly IProfileRepository _profileRepository;
        private readonly IPasswordHasher _passwordHasher;

        public UserManager(IUserRepository iuserRep, IProfileRepository iprofRep, IValidateUser ivalUser, IPasswordHasher passwordHasher)
        {
            _userRepository = iuserRep;
            _validateUsers = ivalUser;
            _profileRepository = iprofRep;
            _passwordHasher = passwordHasher;

            // inject the repository and use userRepistory as an interface and inject it as well. Get rid of Load stuff.
        }

        public User GetUserByUsernameFromDb(string username)
        {
            UserDTO userDTO = _userRepository.GetUserByUsername(username);

            User user = ConvertToUser(userDTO);

            return user;
        }

        public List<User> LoadUsersFromDataBase()
        {
            List<User> users = new();
            List<UserDTO> userDTOs = _userRepository.GetRecentUser(1000);

            foreach (var userDTO in userDTOs)
            {
                users.Add(ConvertToUser(userDTO));
            }
            return users;
        }
        
        //For artists
        #region Artists
        public Result SaveArtistInUsers(int userID, List<int> selectedArtistIDs)
        {
            foreach (int artistID in selectedArtistIDs)
            {
                Result resultArtistInUsers = _userRepository.AddArtistToUser(userID, artistID);

                if (!resultArtistInUsers.Success)
                {
                    return new Result { Success = false, Message = "This Artist already belongs to this user" };
                }
            }

            // If all artists are successfully added, return a success message
            return new Result { Success = true, Message = "Successfully added the Artist(s) to this user." };
        }

        public Result RemoveArtistFromUser(int userID, List<int> selectedArtistIDs)
        {
            foreach (int artistID in selectedArtistIDs)
            {
                Result resultRemoveArtistFromUsers = _userRepository.RemoveArtistFromUser(userID, artistID);
                if (!resultRemoveArtistFromUsers.Success)
                {
                    return new Result { Success = false, Message = "This Artist is not on this users account yet" };
                }
            }

            // If all songs are successfully deleted, return a success message
            return new Result { Success = true, Message = "Successfully removed the Artist(s) from this user." };
        }
        #endregion

        //For Songs
        #region Songs
        public Result SaveSongsInUsers(int userID, List<int> selectedSongIDs)
        {
            foreach (int songID in selectedSongIDs)
            {
                Result resultSongInAlbum = _userRepository.AddSongToUser(userID, songID);
                if (!resultSongInAlbum.Success)
                {
                    return new Result { Success = false, Message = "This Song is already on this users list" };
                }
            }

            // If all songs are successfully added, return a success message
            return new Result { Success = true, Message = "Successfully added the Song(s) to this user." };
        }

        public Result RemoveSongFromUser(int userID, List<int> selectedSongIDs)
        {
            foreach (int songID in selectedSongIDs)
            {
                Result resultRemoveSongfromUser = _userRepository.RemoveSongFromUser(userID, songID);
                if (!resultRemoveSongfromUser.Success)
                {
                    return new Result { Success = false, Message = "This Song is not on this users account yet" };
                }
            }

            return new Result { Success = true, Message = "Successfully removed the Song(s) from this user." };
        }
        #endregion

        //For Albums
        #region Albums
        public Result SaveAlbumInUsers(int userID, List<int> selectedAlbumIDs)
        {
            foreach (int albumID in selectedAlbumIDs)
            {
                Result resultAlbumInUser = _userRepository.AddAlbumToUser(userID, albumID);
                if (!resultAlbumInUser.Success)
                {
                    return new Result { Success = false, Message = "This Album is already on this users list" };
                }
            }

            // If all songs are successfully added, return a success message
            return new Result { Success = true, Message = "Successfully added the Album(s) to this user." };
        }

        public Result RemoveAlbumFromUser(int userID, List<int> selectedAlbumIDs)
        {
            foreach (int albumID in selectedAlbumIDs)
            {
                Result resultRemoveAlbumfromUser = _userRepository.RemoveAlbumFromUser(userID, albumID);
                if (!resultRemoveAlbumfromUser.Success)
                {
                    return new Result { Success = false, Message = "This Album is not on this users account yet" };
                }
            }

            // If all songs are successfully deleted, return a success message
            return new Result { Success = true, Message = "Successfully removed the Album(s) from this user." };
        }

        #endregion 

        public Result Add(User user)
        {
            UserDTO userDTO = ConvertToUserDTO(user);

            Result resultUser = SendUserToTheDb(userDTO);

            if (resultUser.Success)
            {
                // Set the UserID in the user object
                user.SetUserID(userDTO.UserID);

                // Create ProfileDTO for the new User
                ProfileDTO profileDTO = new();
                profileDTO.UserID = user.UserID;
                profileDTO.User_Balance = 0;

                // Insert Profile into the database
                Result resultProfile = _profileRepository.InsertProfile(profileDTO);

                if (!resultProfile.Success)
                {
                    return new Result { Success = false, Message = "User created but failed to create Profile." };
                }
            }
            return resultUser;
        }

        public Result AddWEB(User user)
        {
            UserDTO userDTO = ConvertToUserDTO(user);

            Result resultUserWeb = SendUserToTheDbWEB(userDTO);

            if (resultUserWeb.Success)
            {
                // Set the UserID in the user object
                user.SetUserID(userDTO.UserID);

                // Create ProfileDTO for the new User
                ProfileDTO profileDTO = new();
                profileDTO.UserID = user.UserID;
                profileDTO.User_Balance = 0;

                // Insert Profile into the database
                Result resultProfile = _profileRepository.InsertProfile(profileDTO);

                if (!resultProfile.Success)
                {
                    return new Result { Success = false, Message = "User created but failed to create Profile." };
                }
            }

            return resultUserWeb;
        }

        public Result UpgradeToCritic(User user)
        {
            Result resultUpgradeCritic = _userRepository.UpdateUserRoleToCritic(ConvertToUserDTO(user));
            return resultUpgradeCritic;
        }
        
        public Result UpgradeToMusician(User user)
        {
            Result resultUpgradeMusician = _userRepository.UpdateUserRoleToMusician(ConvertToUserDTO(user));
            return resultUpgradeMusician;
        }
       
        public Result Remove(User user)
        {
            Result resultRemoveUser = _userRepository.DeleteUser(ConvertToUserDTO(user));

            return resultRemoveUser;
        }

        // Method to update an existing user
        public Result Update(User newUser, User oldUser)
        {
            UserDTO newUserDTO = ConvertToUserDTO(newUser);
            if (oldUser == null)
            {
                Result resultAdd = Add(newUser);
                return resultAdd;
            }
            else
            {
                UserDTO oldUserDTO = ConvertToUserDTO(oldUser);

                //This calls the repository method to update the User
                Result resultupdate = _userRepository.UpdateUser(newUserDTO, oldUserDTO);

                if (resultupdate.Success)
                {
                    List<User> users = LoadUsersFromDataBase();
                    int index = users.FindIndex(ur => ur == oldUser);

                    if (index != -1)
                    {
                        users[index] = newUser;
                    }
                }
                else if (!resultupdate.Success)
                {
                    return new Result { Success = false, Message = "Something went wrong when updating the user" };
                }

                return resultupdate;
            }
        }

        public Result SendUserToTheDb(UserDTO newUser)
        {
            if (_validateUsers.UsernameExists(newUser.Username) == false)
            {
                string HashedPassword = _passwordHasher.HashPassword(newUser.Password);

                newUser.Password = HashedPassword;

                return _userRepository.InsertUser(newUser);
            }
            else
            {
                return new Result
                {
                    Success = false,
                    Message = "Username is already taken"
                };

            }

        }

        public Result SendUserToTheDbWEB(UserDTO newUser)
        {
            var errors = _validateUsers.ValidateUsers(newUser.Username);
            if (errors.Any())
            {
                return new Result
                {
                    Success = false,
                    Errors = errors
                };
            }

            string HashedPassword = _passwordHasher.HashPassword(newUser.Password);

            newUser.Password = HashedPassword;

            return _userRepository.InsertUser(newUser);
        }

        public User ConvertToUser(UserDTO newUserDTO)
        {
            if (newUserDTO == null)
            {
                return null;
            }

            //Converts the user role enum to a string
            userType type = (userType)Enum.Parse(typeof(userType), newUserDTO.UserType);

            //Converts the genre enum to a string 
            genreType genre = (genreType)Enum.Parse(typeof(genreType), newUserDTO.FavGenre);

            //this converts UserDto to users
            return new User(
                newUserDTO.UserID,
                newUserDTO.Username,
                newUserDTO.Password,
                newUserDTO.Email,
                type,
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
                user.Username,
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
