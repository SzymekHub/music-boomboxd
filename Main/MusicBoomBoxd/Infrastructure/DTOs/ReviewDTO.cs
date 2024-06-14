namespace Infrastructure.DTOs
{
    public class ReviewDTO
    {
        public int UserRatingID { get; set; }

        public UserDTO UserDTO { get; set; }

        public AlbumDTO AlbumDTO { get; set; }

        public int Rate { get; set; }
    }
}
