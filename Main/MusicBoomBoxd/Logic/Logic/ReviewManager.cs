using Infrastructure;

namespace Logic
{
    public class ReviewManager
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAlbumRepository _albumRepository;

        public ReviewManager(IReviewRepository irevRep, IUserRepository iuserRep, IAlbumRepository ialbRep)
        {
            _reviewRepository = irevRep;
            _userRepository = iuserRep;
            _albumRepository = ialbRep;
        }

        public Result AddReview(Review review)
        {
            ReviewDTO reviewDTO = ReviewMapper.ConvertToReviewDTO(review);
            return _reviewRepository.InsertReview(reviewDTO);
        }

        public Result UpdateRating(Review review)
        {
            ReviewDTO reviewDTO = ReviewMapper.ConvertToReviewDTO(review);
            return _reviewRepository.UpdateReview(reviewDTO);
        }

        public Review GetReviewByUsernameAndAlbumID(string username, int albumID)
        {
            UserDTO userDTO = _userRepository.GetUserByUsername(username);
            AlbumDTO albumDTO = _albumRepository.GetAlbumByAlbumID(albumID);

            ReviewDTO reviewDTO = _reviewRepository.GetReviewByUserAndAlbumID(userDTO, albumDTO);

            if (reviewDTO == null)
            {
                return null;
            }

            return ReviewMapper.ConvertToReview(reviewDTO);
        }

        public double GetAverageRatingByAlbumID(Album album)
        {
            AlbumDTO albumDTO = AlbumMapper.ToAlbumDTO(album);

            List<ReviewDTO> reviews = _reviewRepository.GetReviewsByAlbumID(albumDTO);

            int totalRatings = reviews.Count;
            if (totalRatings == 0)
            {
                return 0;
            }

            int totalRatingSum = reviews.Sum(r => r.Rate);

            double averageRating = (double)totalRatingSum / totalRatings;

            _albumRepository.AddAverageRating(albumDTO, averageRating);

            return averageRating;
        }
    }
}
