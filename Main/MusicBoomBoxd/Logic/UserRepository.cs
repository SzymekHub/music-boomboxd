using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users;

        private readonly string FilePath;


        public UserRepository(string filePath)
        {
            _users = new List<User>();
            LoadUsersFromCsv();
            FilePath = filePath;
        }

        public IEnumerable<User> GetUsers()
        {
            //Here i will retrieve users from a data source like CSV or database later
            return _users;
        }

        public void AddUser(User user)
        {
            _users.Add(user);
            SaveUsersToCsv();
        }

        public void RemoveUser(User user)
        {
            _users.Remove(user);
            SaveUsersToCsv();
        }

        private void LoadUsersFromCsv()
        {
            try
            {
                using (StreamReader reader = new StreamReader(FilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        int id = int.Parse(parts[0]);
                        string username = parts[1];
                        string email = parts[2];
                        string password = parts[3];
                        userType userTypes = (userType)Enum.Parse(typeof(userType), parts[4]);

                        User user = new User(id, username, email, password, userTypes);
                        _users.Add(user);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void SaveUsersToCsv()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(FilePath))
                {
                    foreach(User user in _users)
                    {
                        writer.WriteLine($"User: {user.UserID}, {user.UserName}, Emial: {user.Email}, Password: {user.Password}, User Type: {user.UserType}");
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
