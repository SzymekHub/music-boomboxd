using Infrastructure.DTOs;

namespace Infrastructure.InterfacesForRepo
{
    public interface IReviewRepository
    {
        List<ReviewDTO> GetAllReviews(int count);
        ReviewDTO GetReviewByUserAndAlbumID(UserDTO userDTO, AlbumDTO albumDTO);
        List<ReviewDTO> GetReviewsByAlbumID(AlbumDTO albumDTO);
        Result InsertReview(ReviewDTO reviewDTO);
        Result UpdateReview(ReviewDTO reviewDTO);
    }
}