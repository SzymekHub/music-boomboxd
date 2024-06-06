using Infrastructure;


namespace Logic
{
	public class ValidateAlbum
	{
		private readonly IAlbumRepository _albumRepository;

		public ValidateAlbum(IAlbumRepository albumRepository)
		{
			_albumRepository = albumRepository;
		}

		public Dictionary<string, List<string>> ValidateAlbums(string title, int artistID)
		{
			var errors = new Dictionary<string, List<string>>();

			if (AlbumExists(title, artistID))
			{
				errors.TryAdd("album", new List<string>());
				errors["album"].Add("An album with this title already exists for the selected artist.");
			}
			return errors;
		}

		public bool AlbumExists(string title, int artistID)
		{
			AlbumDTO albumDTO = _albumRepository.GetAlbumByTitleAndArtist(title, artistID);
			return albumDTO != null;
		}
	}
}
