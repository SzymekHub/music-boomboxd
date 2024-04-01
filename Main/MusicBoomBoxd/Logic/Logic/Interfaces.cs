using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        void AddUser(User user);

        void RemoveUser(User user);
    }

    public interface IUserFilter
    {
        IEnumerable<User> FilterUsers(IEnumerable<User> users, userType userTypes, string searchTerm);
    }
}
