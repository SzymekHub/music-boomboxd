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

        public string Content { get; set; }

        public int Rating { get; set; }

        public DateTime CreationDate { get; set; }

        public Review(int reviewID, int userID, string content, int rating, DateTime creationDate)
        {
            ReviewID = reviewID;
            UserID = userID;
            Content = content;
            Rating = rating;
            CreationDate = creationDate;
        }
    }
}
