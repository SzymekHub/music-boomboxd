using Infrastructure;

namespace Logic
{
    public class ReviewMapper
    {
        public static Review ConvertToReview(ReviewDTO reviewDTO)
        {
            Review review = new(
                reviewDTO.UserRatingID,
                UserMapper.ConvertToUser(reviewDTO.UserDTO),
                AlbumMapper.ToAlbum(reviewDTO.AlbumDTO),
                reviewDTO.Rate
                );

            return review;
        }

        public static ReviewDTO ConvertToReviewDTO(Review review)
        {
            ReviewDTO reviewDTO = new();
            reviewDTO.UserRatingID = review.UserRatingID;
            reviewDTO.UserDTO = UserMapper.ConvertToUserDTO(review.User);
            reviewDTO.AlbumDTO = AlbumMapper.ToAlbumDTO(review.Album);
            reviewDTO.Rate = review.Rate;

            return reviewDTO;
        }
    }
}
