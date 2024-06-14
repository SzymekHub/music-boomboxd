using Infrastructure.InterfacesForRepo;
using Infrastructure.Repositories;
using Infrastructure;
using Logic.Interfaces;
using Logic.Algorithms;
using Infrastructure.DTOs;

namespace Logic.Algorithms
{
    public class FavGenreFilter : IRecommendationFilter
	{
		private readonly IAlbumRepository _albumRepository;

        public FavGenreFilter(IAlbumRepository albumRepository)
        {
             _albumRepository = albumRepository;
        }

        public List<Album> GetFilteredAlbum (User user)
        {
			List<Album> FilteredAlbums = new List<Album>();

			List<AlbumDTO> albums = _albumRepository.GetAlbums(1000);

			foreach (var album in albums)
			{
				if (album.Genre == user.FavGenre.ToString())
				{
					FilteredAlbums.Add(AlbumMapper.ToAlbum(album));
				}
			}
			return FilteredAlbums;
		}
    }
}
