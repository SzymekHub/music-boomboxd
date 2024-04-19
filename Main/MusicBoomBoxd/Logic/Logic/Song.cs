using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Song
    {
        public string ID { get; set; }
        public string SongTitle { get; set; }
        public string Artist { get; set; }
        public DateTime ReleaseDate { get; set; }
        public genreType GenreType { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Comment> Comments { get; set; }

        public Song(string songTitle, string artist, DateTime releaseDate, genreType genreType, List<Review> reviews, List<Comment> comments)
        {
            ID = GenerateID();
            SongTitle = songTitle;
            Artist = artist;
            ReleaseDate = releaseDate;
            GenreType = genreType;
            Reviews = reviews;
            Comments = comments;
        }
        private string GenerateID()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }

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
