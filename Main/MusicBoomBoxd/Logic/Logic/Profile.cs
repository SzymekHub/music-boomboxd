namespace Logic
{
    public class Profile
    {
		public int ProfileID { get; set; }

        public User User { get; set; }

        public double User_Balance { get; set; }
		public Profile(int profileID, User user, double user_Balance)
		{
			ProfileID = profileID;
			User = user;
			User_Balance = user_Balance;
		}

	}
}
