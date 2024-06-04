using Infrastructure;
using Infrastructure.DTOs;

namespace Logic
{
    public class UserManager
    {
        public List<User> _users;
        private readonly IUserRepository _userRepository;
        private readonly ValidateUser _validateUsers;

        public UserManager(IUserRepository iuserRep)
        {
            _users = new List<User>();
            _userRepository = iuserRep;
            _validateUsers = new(iuserRep);

            // inject the repository and use userRepistory as an interface and inject it as well. Get rid of Load stuff.
        }
        
        public User GetUserByUsernameFromDb(string username)
        {
            UserDTO userDTO = _userRepository.GetUserByUsername(username);
            User user = ConvertToUser(userDTO);

            return user;
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

        //For artists
        #region Artists
        public Result SaveArtistInUsers(int userID, List<int> selectedArtistIDs)
        {
            Result result = new Result();

            foreach (int artistID in selectedArtistIDs)
            {
                Result resultArtistInUsers = _userRepository.AddArtistToUser(userID, artistID);
                if (!resultArtistInUsers.Success)
                {
                    result.Success = false;
                    result.Message = "";
                    return result;
                }
            }

            // If all artists are successfully added, return a success message
            result.Success = true;
            result.Message = "Successfully added the 5 artists to this user.";
            return result;
        }

        public Result RemoveArtistFromUser(int userID, List<int> selectedArtistIDs)
        {
            Result result = new Result();

            foreach (int artistID in selectedArtistIDs)
            {
                Result resultRemoveArtistFromUsers = _userRepository.RemoveArtistFromUser(userID, artistID);
                if (!resultRemoveArtistFromUsers.Success)
                {
                    result.Success = false;
                    result.Message = "This Artist is not on this users account yet";
                    return result;
                }
            }

            // If all songs are successfully deleted, return a success message
            result.Success = true;
            result.Message = "Successfully removed the Artist from this user.";
            return result;
        }
        #endregion

        //For Songs
        #region Songs
        public Result SaveSongsInUsers(int userID, List<int> selectedSongIDs)
        {
            Result result = new Result();

            foreach (int songID in selectedSongIDs)
            {
                Result resultSongInAlbum = _userRepository.AddSongToUser(userID, songID);
                if (!resultSongInAlbum.Success)
                {
                    result.Success = false;
                    result.Message = "This Song is already on this users list";
                    return result;
                }
            }

            // If all songs are successfully added, return a success message
            result.Success = true;
            result.Message = "Successfully added the 5 Songs to this user.";
            return result;
        }

        public Result RemoveSongFromUser(int userID, List<int> selectedSongIDs)
        {
            Result result = new Result();

            foreach (int songID in selectedSongIDs)
            {
                Result resultRemoveSongfromUser = _userRepository.RemoveSongFromUser(userID, songID);
                if (!resultRemoveSongfromUser.Success)
                {
                    result.Success = false;
                    result.Message = "This Song is not on this users account yet";
                    return result;
                }
            }

            // If all songs are successfully deleted, return a success message
            result.Success = true;
            result.Message = "Successfully removed the Song from this user.";
            return result;
        }
        #endregion

        //For Albums
        #region Albums
        public Result SaveAlbumInUsers(int userID, List<int> selectedAlbumIDs)
        {
            Result result = new Result();

            foreach (int albumID in selectedAlbumIDs)
            {
                Result resultAlbumInUser = _userRepository.AddAlbumToUser(userID, albumID);
                if (!resultAlbumInUser.Success)
                {
                    result.Success = false;
                    result.Message = "This Album is already on this users list";
                    return result;
                }
            }

            // If all songs are successfully added, return a success message
            result.Success = true;
            result.Message = "Successfully added the 5 Albums to this user.";
            return result;
        }

        public Result RemoveAlbumFromUser(int userID, List<int> selectedAlbumIDs)
        {
            Result result = new Result();

            foreach (int albumID in selectedAlbumIDs)
            {
                Result resultRemoveAlbumfromUser = _userRepository.RemoveAlbumFromUser(userID, albumID);
                if (!resultRemoveAlbumfromUser.Success)
                {
                    result.Success = false;
                    result.Message = "This Album is not on this users account yet";
                    return result;
                }
            }

            // If all songs are successfully deleted, return a success message
            result.Success = true;
            result.Message = "Successfully removed the Album from this user.";
            return result;
        }

        #endregion 

        public Result Add(User user)
        {
            UserDTO userDTO = ConvertToUserDTO(user);

            _users.Add(user);

            Result resultUser = SendUserToTheDb(userDTO);

            return resultUser;

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
        }

        public Result SendUserToTheDb(UserDTO newUser)
        {
            if (_validateUsers.UsernameExists(newUser.Username) == false)
            {
                string HashedPassword = PasswordHasher.HashPassword(newUser.Password);

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

            string HashedPassword = PasswordHasher.HashPassword(newUser.Password);

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