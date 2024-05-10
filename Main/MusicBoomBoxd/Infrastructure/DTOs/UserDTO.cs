using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTOs
{
    //This class represents the data structure of a user
    public class UserDTO
    {
        public string UserName {  get; set; } 
        public string Password { get; set; }
        public string Email { get; set; }
        public string UserType { get; set; }
        public DateTime Birthday { get; set; }
        public string FavGenre { get; set; }
        public string ProfilePictureName { get; set; }
        public byte[] ProfilePictureData { get; set; }
        public string ProfilePictureContentType { get; set; }

        public UserDTO(string userName, string password, string email, string userType, DateTime birthday, string favGenre, string profilePictureName, byte[] profilePictureData, string profilePictureContentType)
        {
            UserName = userName;
            Password = password;
            Email = email;
            UserType = userType;
            Birthday = birthday;
            FavGenre = favGenre;
            ProfilePictureName = profilePictureName;
            ProfilePictureData = profilePictureData;
            ProfilePictureContentType = profilePictureContentType;
        }

        public UserDTO(string userName, string password, string email, string userType)
        {
            UserName = userName;
            Password = password;
            Email = email;
            UserType = userType;
        }
    }
}
