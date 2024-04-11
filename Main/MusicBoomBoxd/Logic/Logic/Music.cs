using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class Music
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Artist { get; set; }

        public DateTime ReleaseDate { get; set; }

        public genreType GenreType { get; set; }

        public List<Review> Reviews { get; set; }

        public List<Comment> Comments { get; set; }



        public List<Review> GetReviews()
        {
            return Reviews;
        }

        public List<Comment> GetComments()
        {
            return Comments;
        }

        public void AddReview(Review review)
        {
            Reviews.Add(review);
        }

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }
    }
}
