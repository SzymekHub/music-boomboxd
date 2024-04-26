using Infrastructure;
using Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class LoadUsers
    {
        private readonly UserRepository _userRepository;

        public LoadUsers(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<UserDTO> LoadAllUsers()
        {
            //This will laod all the users
            return _userRepository.GetRecentUsers(int.MaxValue);
        }
    }
}
