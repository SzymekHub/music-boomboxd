namespace Logic
{
    public class Profile
    {
        public int ProfileID { get; set; }

        public string UserID { get; set; }

        public double User_Balance { get; set; }

        public Profile(int profileID, string userID, double user_Balance)
        {
            ProfileID = profileID;
            UserID = userID;
            User_Balance = user_Balance;
        }
    }
}
