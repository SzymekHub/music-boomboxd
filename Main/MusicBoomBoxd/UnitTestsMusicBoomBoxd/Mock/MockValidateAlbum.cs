using Infrastructure;
using Infrastructure.DTOs;
using Infrastructure.InterfacesForRepo;
using Infrastructure.Repositories;
using Logic.Algorithms;
using Logic.Interfaces;


namespace UnitTestsMusicBoomBoxd.Mock
{
	public class MockValidateAlbum : IValidateAlbum
	{
		public bool AlbumExists(string title, int artistID)
		{
			return title == "existingAlbum" && artistID == 0;
		}

		public Dictionary<string, List<string>> ValidateAlbums(string title, int artistID)
		{
			var errors = new Dictionary<string, List<string>>();

			if (title == "duplicateAlbum" && artistID == 1)
			{
				errors.TryAdd("album", new List<string>());
				errors["album"].Add("An album with this title already exists for the selected artist.");
			}

			return errors;
		}
	}
}
