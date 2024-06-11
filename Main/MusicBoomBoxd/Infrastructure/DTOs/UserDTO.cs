namespace Infrastructure
{
    //This class represents the data structure of a user
    public class UserDTO
    {
        public int UserID { get; set; }
        public string Username {  get; set; } 
        public string Password { get; set; }
        public string Email { get; set; }
        public string UserType { get; set; }
        public DateTime Birthday { get; set; }
        public string FavGenre { get; set; }
        public string ProfilePictureName { get; set; }
        public byte[] ProfilePictureData { get; set; }
        public string ProfilePictureContentType { get; set; }
		public ProfileDTO ProfileDTO { get; set; }

		public UserDTO(int userID, string username, string password, string email, string userType, DateTime birthday, string favGenre, string profilePictureName, byte[] profilePictureData, string profilePictureContentType)
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
        }

        //For the webapp
        public UserDTO(string username, string password, string email, string userType, DateTime birthday, string favGenre, string profilePictureName, byte[] profilePictureData, string profilePictureContentType)
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
        }
    }
}
