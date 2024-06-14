using Infrastructure.DTOs;
using Infrastructure;
using Infrastructure.InterfacesForRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestsMusicBoomBoxd.Mock
{
    public class MockReviewRepository : IReviewRepository
    {
        public readonly List<ReviewDTO> _mockReviews;

        public MockReviewRepository(List<ReviewDTO> mockReviews)
        {
            _mockReviews = mockReviews;
        }

        public List<ReviewDTO> GetAllReviews(int count)
        {
            return _mockReviews;
        }
        public ReviewDTO GetReviewByUserAndAlbumID(UserDTO userDTO, AlbumDTO albumDTO)
        {
            return _mockReviews.FirstOrDefault(review => review.UserDTO.UserID == userDTO.UserID && review.AlbumDTO == albumDTO);
        }
        public List<ReviewDTO> GetReviewsByAlbumID(AlbumDTO albumDTO)
        {
            return _mockReviews.Where(r => r.AlbumDTO.AlbumID == albumDTO.AlbumID).ToList();
        }
        public Result InsertReview(ReviewDTO reviewDTO)
        {
            _mockReviews.Add(reviewDTO);
            return new Result { Success = true };
        }
        public Result UpdateReview(ReviewDTO reviewDTO)
        {
            var existingReview = _mockReviews.FirstOrDefault(review => review.UserDTO.UserID == reviewDTO.UserDTO.UserID && review.AlbumDTO.AlbumID == reviewDTO.AlbumDTO.AlbumID);

            if (existingReview != null)
            {
                existingReview.Rate = reviewDTO.Rate;
                return new Result { Success = true };
            }
            else
            {
                return new Result { Success = false, Message = "Review not found." };
            }
        }
    }
}
