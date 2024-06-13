using Infrastructure;

namespace Logic
{
	public class ReviewFilter : IRecommendationFilter
	{
		public readonly IReviewRepository _reviewRepository;
		public readonly IAlbumRepository _albumRepository;

        public ReviewFilter(IReviewRepository revRep, IAlbumRepository albRep)
        {
            _reviewRepository = revRep;
            _albumRepository = albRep;
        }

        public List<Album> GetFilteredAlbum(User user)
		{
            List<Album> albumsBasedonRating = new List<Album>();

            List<ReviewDTO> reviews = _reviewRepository.GetAllReviews(1000);

            // This will look and find users with similar ratings where:
            // there's at least one rating by the current user for the same album with the same rating

            var similarUsers = reviews.Where(rev => rev.UserDTO.UserID != user.UserID
                                                                        &&
                                             reviews.Any(rev2 => rev2.UserDTO.UserID == user.UserID
                                                                        &&
                                                        rev2.AlbumDTO.AlbumID == rev.AlbumDTO.AlbumID
                                                                        &&
                                                        rev2.Rate == rev.Rate)).Select(rev => rev.UserDTO.UserID).Distinct(); //Distinct removes all the duplicates and unecessary code

            foreach (var similarUserID in similarUsers) 
            {
				//This gets reviews made by the current similar user that are rated 4 or higher.
				var similiaryUserReviews = reviews.Where(rev => rev.UserDTO.UserID == similarUserID 
                                                                         &&
                                                        rev.Rate >=3).Select(rev => rev.AlbumDTO.AlbumID).Distinct();
                
                foreach(var albumID in similiaryUserReviews)
                {
                    AlbumDTO albumDTO = _albumRepository.GetAlbumByAlbumID(albumID);
                    if (albumDTO != null)
                    {
                        Album album = AlbumMapper.ToAlbum(albumDTO);
						albumsBasedonRating.Add(album);

					}
                }
            }

            return albumsBasedonRating;
		}

    }
}
