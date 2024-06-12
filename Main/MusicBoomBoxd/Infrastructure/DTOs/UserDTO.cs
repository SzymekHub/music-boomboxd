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

        public bool Active { get; set; }

    }
}
