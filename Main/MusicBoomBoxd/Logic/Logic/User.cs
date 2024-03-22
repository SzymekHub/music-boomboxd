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

        public string UserName { get; private set; }

        private string Email { get; set; }

        private string Password { get; set; }

        public userType UserType { get;  private set; }

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
