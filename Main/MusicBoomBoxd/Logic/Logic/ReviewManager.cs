using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ReviewManager
    {
        private List<Review> reviews;

        public ReviewManager()
        {
            reviews = new List<Review>();
        }

        public void Add(Review review)
        {
            reviews.Add(review);
        }

        public Review[] GetArray()
        {
            return reviews.ToArray();
        }

        public bool Remove(Review review)
        {
            return reviews.Remove(review);
        }
    }
}
