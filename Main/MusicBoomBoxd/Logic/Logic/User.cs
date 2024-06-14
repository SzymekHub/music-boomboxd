using Infrastructure;
using Infrastructure.DTOs;
using Infrastructure.InterfacesForRepo;
using Infrastructure.Repositories;
using Logic.Algorithms;
using Logic.Interfaces;

namespace Logic
{
    public class User
    {
        public int UserID { get; private set; }
        public string Username { get; }
        public string Password { get; }
        public string Email { get; }
        public userType UserType { get; set; }
        public DateTime Birthday { get; set; }
        public genreType FavGenre { get; set; }
        public string ProfilePictureName { get; set; }
        public byte[] ProfilePictureData { get; set; }
        public string ProfilePictureContentType { get; set; }
        public Profile Profile { get; set; }

        public User(int userID, string username, string password, string email, userType userType, DateTime birthday, genreType favGenre, string profilePictureName, byte[] profilePictureData, string profilePictureContentType, Profile profile = null)
        {
            UserID = userID;
            Username = username;
            Password = password;
            Email = email;
            UserType = userType;
            Birthday = birthday;
            FavGenre = favGenre;
            ProfilePictureName = profilePictureName;
            ProfilePictureData = profilePictureData;
            ProfilePictureContentType = profilePictureContentType;
			Profile = profile ?? new Profile { User = this, User_Balance = 0 }; 
		}

		public User(string username, string password, string email, userType userType, DateTime birthday, genreType favGenre, string profilePictureName, byte[] profilePictureData, string profilePictureContentType)
        {
            Username = username;
            Password = password;
            Email = email;
            UserType = userType;
            Birthday = birthday;
            FavGenre = favGenre;
            ProfilePictureName = profilePictureName;
            ProfilePictureData = profilePictureData;
            ProfilePictureContentType = profilePictureContentType;
			Profile = new Profile { User = this, User_Balance = 0 };
		}

		public void SetUserID(int userID)
		{
			if (UserID == 0)
			{
				UserID = userID;
				if (Profile != null) 
				{
					Profile.User.UserID = userID;
				}
			}
		}
	}
}