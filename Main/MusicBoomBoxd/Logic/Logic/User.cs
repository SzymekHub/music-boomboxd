namespace Logic
{
    public class User
    {
        public int UserID { get; }
        public string Username { get; }
        public string Password { get; }
        public string Email { get; }
        public userType UserType { get;  set; }
        public DateTime Birthday { get; set; }
        public genreType FavGenre { get; set; }
        public string ProfilePictureName { get; set; }
        public byte[] ProfilePictureData { get; set; }
        public string ProfilePictureContentType { get; set; }

        public User(int userID, string username, string password, string email, userType userType, DateTime birthday, genreType favGenre, string profilePictureName, byte[] profilePictureData, string profilePictureContentType)
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
        }
    }
}