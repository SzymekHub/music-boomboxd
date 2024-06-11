using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
	public class Review
	{
		public int UserRatingID { get; set; }

		public User User { get; set; }

		public Album Album { get; set; }

		public int Rate { get; set; }

		public Review(int userRatingID, User user, Album album, int rate)
		{
			UserRatingID = userRatingID;
			User = user;
			Album = album;
			Rate = rate;
		}
	}
}
