using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class User
    {
        public int UserID { get;  set; }

        public string UserName { get;  set; }

        public string Password { get;  set; }

        public string Email { get;  set; }

        public userType UserType { get;  set; }

        public User(int userID, string userName, string email, string password, userType userType)
        {
            UserID = userID;
            UserName = userName;
            Email = email;
            Password = password;
            UserType = userType;
        }
        public static List<User> InitializeUsers()
        {
            //For now I am hardcoding the users in categorize
            return new List<User>
            {
                new User(1, "Paul","paul@example.com", "password", userType.Artist),
                new User(2, "Amy","amy@example.com", "password", userType.Artist),
                new User(3, "Ringo","ring@example.com", "password", userType.Artist),
                new User(4, "George", "george@example.com", "password", userType.Artist),
                new User(5, "Ruby","ruby@example.com", "password", userType.Artist),
                new User(6,"Scrim","scrim@example.com", "password", userType.Artist),
                new User(7, "Mac","mac@example.com", "password", userType.Artist),
                new User(8, "BoopeDooper","booper@example.com", "password", userType.Amateur),
                new User(9, "MusicLover1234","musiclove@example.com", "password", userType.Amateur),
                new User(10, "IhateTechno3","hatetechno@example.com", "password", userType.Amateur),
                new User(11, "IloveMac","lovemac@example.com", "password", userType.Amateur),
                new User(12, "Gustav", "gustav@example.com", "password", userType.Professional),
                new User(13, "Austin", "austin@example.com", "passsword", userType.Professional)
            };

        }
    }
}