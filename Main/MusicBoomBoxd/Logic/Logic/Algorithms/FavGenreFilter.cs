using Infrastructure;

namespace Logic
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
