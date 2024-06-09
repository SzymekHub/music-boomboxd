using Infrastructure;

namespace Logic
{
	public class ValidateSong : IValidateSong
	{
		private readonly ISongRepository _songRepository;

		public ValidateSong(ISongRepository songRepository)
		{
			_songRepository = songRepository;
		}

		public Dictionary<string, List<string>> ValidateSongs(string title, int artistID)
		{
			var errors = new Dictionary<string, List<string>>();

			if (SongExists(title, artistID))
			{
				errors.TryAdd("song", new List<string>());
				errors["song"].Add("An song with this title already exists for the selected artist.");
			}
			return errors;
		}

		public bool SongExists(string title, int artistID)
		{
			SongDTO songDTO = _songRepository.GetSongByTitleAndArtist(title, artistID);
			return songDTO != null;
		}
	}
}
