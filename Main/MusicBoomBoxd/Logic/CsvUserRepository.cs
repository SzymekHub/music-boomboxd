using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class CsvUserRepository : IUserRepository
    {
        private readonly string _filePath;

        public CsvUserRepository(string filePath)
        {
            _filePath = filePath;
        }

        //this will retrieve users form a data soruce (CSV file for now)
        public IEnumerable<User> GetUsers() 
        {
            
        }

        //This will add a new user to the data source(CSV file for now)
        public void AddUser(User user)
        {

        }
        //This will add a new user to the data source(CSV file for now)
        public void RemoveUser(User user)
        {

        }
    }
}
