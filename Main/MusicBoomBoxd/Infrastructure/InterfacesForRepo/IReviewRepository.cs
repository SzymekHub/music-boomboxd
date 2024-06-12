
namespace Infrastructure
{
    public interface IReviewRepository
    {
        List<ReviewDTO> GetAllReviews();
        ReviewDTO GetReviewByUserAndAlbumID(ReviewDTO reviewDTO);
        List<ReviewDTO> GetReviewsByAlbumID(AlbumDTO albumDTO);
        Result InsertReview(ReviewDTO reviewDTO);
        Result UpdateReview(ReviewDTO reviewDTO);
    }
}