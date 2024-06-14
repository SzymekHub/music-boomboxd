using Infrastructure;
using Infrastructure.DTOs;
using Infrastructure.InterfacesForRepo;
using Infrastructure.Repositories;
using Logic.Algorithms;
using Logic.Interfaces;

namespace Logic
{
    public class Profile
    {
		public int ProfileID { get; set; }

        public User User { get; set; }

        public double User_Balance { get; set; }

	}
}
