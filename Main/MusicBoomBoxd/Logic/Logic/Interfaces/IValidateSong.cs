
namespace Logic
{
	public interface IValidateSong
	{
		bool SongExists(string title, int artistID);
		Dictionary<string, List<string>> ValidateSongs(string title, int artistID);
	}
}