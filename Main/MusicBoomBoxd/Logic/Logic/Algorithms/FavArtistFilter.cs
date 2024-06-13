using Infrastructure;
using Logic;

public class FavArtistFilter : IRecommendationFilter
{
	private readonly IAlbumRepository _albumRepository;
	private readonly IArtistRepository _artistRepository;

	public FavArtistFilter(IAlbumRepository albumRepository, IArtistRepository artistRepository)
	{
		_albumRepository = albumRepository;
		_artistRepository = artistRepository;
	}

	public List<Album> GetFilteredAlbum(User user)
	{
		List<Album> filteredAlbums = new List<Album>();

		// Fetch albums from the repository
		List<AlbumDTO> albums = _albumRepository.GetAlbums(1000);

		// Fetch favorite artists for the user
		List<ArtistDTO> favoriteArtists = _artistRepository.GetArtistForUser(user.UserID);

		// Get the list of favorite artist names
		var favoriteArtistNames = favoriteArtists.Select(a => a.Name).ToHashSet();

		// Filter albums based on favorite artist names
		foreach (var album in albums)
		{
			if (favoriteArtistNames.Contains(album.ArtistDTO.Name))
			{
				filteredAlbums.Add(AlbumMapper.ToAlbum(album));
			}
		}

		return filteredAlbums;
	}
}
