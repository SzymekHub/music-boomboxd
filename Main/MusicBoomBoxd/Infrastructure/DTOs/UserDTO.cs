using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTOs
{
    //This class represents the data structure of a user
    public class UserDTO
    {
        public string UserName {  get; set; } 
        public string Password { get; set; }
        public string Email { get; set; } 

        public UserDTO(string userName, string password, string email)
        {
            UserName = userName;
            Password = password;
            Email = email;
        }
    }
}
