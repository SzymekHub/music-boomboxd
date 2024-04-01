using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class UserManager
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public bool RegisterUser(string username, string emial, string password, userType userType)
        {
        }

        public bool LoginUser(string username, string password)
        {
        }
    }
}
