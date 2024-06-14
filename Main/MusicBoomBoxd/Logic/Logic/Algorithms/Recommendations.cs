using Infrastructure.InterfacesForRepo;
using Infrastructure.Repositories;
using Infrastructure;
using Logic.Interfaces;
using Logic.Algorithms;
using Infrastructure.DTOs;

namespace Logic.Algorithms
{
	public class Recommendations: IRecommendations
	{
		public List<Album> GetRecommendedAlbums(User user, List<IRecommendationFilter> _filters) 
		{
			List<Album> reccoAlbum = new List<Album>();

			foreach (var filter in _filters)
			{
				reccoAlbum.AddRange(filter.GetFilteredAlbum(user));
			}

			reccoAlbum = reccoAlbum.Distinct().ToList();

			return reccoAlbum;
		}
	}
}
