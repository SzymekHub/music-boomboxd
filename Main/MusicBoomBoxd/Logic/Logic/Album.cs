using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Album
    {
        public string ID { get; set; }
        public string AlbumTitle { get; }
        public string Artist { get; }
        public DateTime ReleaseDate { get; set; }
        public genreType GenreType { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Comment> Comments { get; set; }

        public Album(string albumTitle, string artist, DateTime releaseDate, genreType genreType, List<Review> reviews, List<Comment> comments)
        {
            this.ID = GenerateID();
            this.AlbumTitle = albumTitle;
            this.Artist = artist;
            this.ReleaseDate = releaseDate;
            this.GenreType = genreType;
            this.Reviews = reviews;
            this.Comments = comments;
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
