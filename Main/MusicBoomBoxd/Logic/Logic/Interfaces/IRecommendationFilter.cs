using Infrastructure.InterfacesForRepo;
using Infrastructure.Repositories;
using Infrastructure;
using Logic.Interfaces;
using Logic.Algorithms;
using Infrastructure.DTOs;

namespace Logic.Interfaces
{
	public interface IRecommendationFilter
	{
		List<Album> GetFilteredAlbum(User user);
	}
}
