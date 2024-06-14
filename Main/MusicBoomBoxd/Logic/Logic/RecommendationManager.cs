using Infrastructure;
using Infrastructure.DTOs;
using Infrastructure.InterfacesForRepo;
using Infrastructure.Repositories;
using Logic.Algorithms;
using Logic.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Drawing;

namespace Logic
{
	public class RecommendationManager
	{
		private readonly IAlbumRepository _albumRepository;
		private readonly IProfileRepository _profileRepository;
		public  readonly IUserRepository _userRepository;
		private readonly IReviewRepository _reviewRepository;
		private readonly IArtistRepository _artistRepository;
		private readonly Recommendations _recommendations;

        public RecommendationManager(IAlbumRepository albumRepository, IProfileRepository profileRepository, IUserRepository userRepository, IReviewRepository reviewRepository, IArtistRepository artistRepository, List<IRecommendationFilter> filters)
        {
            _albumRepository = albumRepository;
			_profileRepository = profileRepository;
			_userRepository = userRepository;
			_reviewRepository = reviewRepository;
			_artistRepository = artistRepository;
			_recommendations = new Recommendations();
        }

		//if one of the bools returns true it adds to the filer and it passes the filters to teh get recommended albums
		public List<Album> GetRecommendedAlbums(User user, bool userArtistGenre, bool userReviewFilter, bool userAlbumFilter)
		{
			var filters = new List<IRecommendationFilter>();

			if (userArtistGenre)
			{
				filters.Add(new FavArtistFilter(_albumRepository, _artistRepository));
			}
			if (userReviewFilter)
			{
				filters.Add(new ReviewFilter(_reviewRepository, _albumRepository));
			}
			if (userAlbumFilter)
			{
				filters.Add(new FavGenreFilter(_albumRepository));
			}

			return _recommendations.GetRecommendedAlbums(user, filters);
		}
    }
}
