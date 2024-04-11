using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class UserFilter : IUserFilter
    {
        public IEnumerable<User> FilterUsers(IEnumerable<User> users, userType userTypes, string searchTerm)
        {
            IEnumerable<User> filteredUsers = users;

            if (userTypes != userType.All)
            {
                filteredUsers = filteredUsers.Where(user => user.UserType == userTypes);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                filteredUsers = filteredUsers.Where(user => user.MatchesSearch(searchTerm));
            }

            return filteredUsers;
        }
    }
}
