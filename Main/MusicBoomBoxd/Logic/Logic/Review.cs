using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Review
    {

        public int ReviewID { get; set; }

        public int UserID { get; set; }

        public int Rating { get; set; }

        public Review(int reviewID, int userID, int rating)
        {
            ReviewID = reviewID;
            UserID = userID;
            Rating = rating;
        }
    }
}
