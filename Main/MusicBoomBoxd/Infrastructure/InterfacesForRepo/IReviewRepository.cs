
namespace Infrastructure
{
    public interface IReviewRepository
    {
        List<ReviewDTO> GetAllReviews();
        ReviewDTO GetReviewByUserAndAlbumID(UserDTO userDTO, AlbumDTO albumDTO);
        List<ReviewDTO> GetReviewsByAlbumID(AlbumDTO albumDTO);
        Result InsertReview(ReviewDTO reviewDTO);
        Result UpdateReview(ReviewDTO reviewDTO);
    }
}