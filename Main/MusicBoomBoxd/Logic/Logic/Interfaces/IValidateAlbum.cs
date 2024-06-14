using Infrastructure.InterfacesForRepo;
using Infrastructure.Repositories;
using Infrastructure;
using Logic.Interfaces;
using Logic.Algorithms;
using Infrastructure.DTOs;

namespace Logic.Interfaces
{
	public interface IValidateAlbum
	{
		bool AlbumExists(string title, int artistID);
		Dictionary<string, List<string>> ValidateAlbums(string title, int artistID);
	}
}