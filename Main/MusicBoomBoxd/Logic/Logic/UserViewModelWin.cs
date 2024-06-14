using Infrastructure;
using Infrastructure.DTOs;
using Infrastructure.InterfacesForRepo;
using Infrastructure.Repositories;
using Logic.Algorithms;
using Logic.Interfaces;

namespace Logic
{
	public class UserViewModelWin
	{
		public int UserID { get; }
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

        public UserViewModelWin(User user)
        {
			UserID = user.UserID;
			Username = user.Username;
			Password = user.Password;
			Email = user.Email;
			UserType = user.UserType;
			Birthday = user.Birthday;
			FavGenre = user.FavGenre;
			ProfilePictureName = user.ProfilePictureName;
			ProfilePictureData = user.ProfilePictureData;
			ProfilePictureContentType = user.ProfilePictureContentType;
            
        }

    }
}
