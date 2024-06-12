namespace Logic
{
	public class Review
	{
		public int UserRatingID { get; set; }

		public User User { get; set; }

		public Album Album { get; set; }

		public int Rate { get; set; }

		public Review(int userRatingID, User user, Album album, int rate)
		{
			UserRatingID = userRatingID;
			User = user;
			Album = album;
			Rate = rate;
		}
        public Review(User user, Album album, int rate)
        {
            User = user;
            Album = album;
            Rate = rate;
        }
    }
}
