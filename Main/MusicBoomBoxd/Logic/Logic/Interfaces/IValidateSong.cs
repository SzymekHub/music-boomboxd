using Infrastructure.InterfacesForRepo;
using Infrastructure.Repositories;
using Infrastructure;
using Logic.Interfaces;
using Logic.Algorithms;
using Infrastructure.DTOs;

namespace Logic.Interfaces
{
	public interface IValidateSong
	{
		bool SongExists(string title, int artistID);
		Dictionary<string, List<string>> ValidateSongs(string title, int artistID);
	}
}