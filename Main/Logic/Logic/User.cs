using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class User
    {
        private int UserID { get; set; }

        private string UserName { get; set; }

        private string Email { get; set; }

        private string Password { get; set; }

        private userType UserType { get; set; }

        public User(int userID, string userName, string email, string password, userType userType)
        {
            UserID = userID;
            UserName = userName;
            Email = email;
            Password = password;
            UserType = userType;
        }

        public void UpdateProfile()
        {

        }

        public void ResetPassword(string email)
        {

        }

    }
}
