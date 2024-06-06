
namespace Logic
{
	public interface IValidateAlbum
	{
		bool AlbumExists(string title, int artistID);
		Dictionary<string, List<string>> ValidateAlbums(string title, int artistID);
	}
}