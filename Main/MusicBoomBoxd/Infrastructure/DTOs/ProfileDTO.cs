using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTOs
{
    public class ProfileDTO
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }

        public ProfileDTO(int userId, string username, string email, string bio)
        {
            UserId = userId;
            Username = username;
            Email = email;
            Bio = bio;
        }
    }
}
