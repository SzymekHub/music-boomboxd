using Infrastructure.DTOs;

namespace Infrastructure.InterfacesForRepo
{
    public interface ISongRepository
	{
		Result InsertSong(SongDTO songDTO);
		List<SongDTO> GetSongs(int count);
		List<SongDTO> GetSongsForAlbum(int albumID);
		List<SongDTO> GetSongsForUser(int userID);
		SongDTO GetSongByTitleAndArtist(string title, int artistId);
		int GetSongIDBySongTitle(string albumTitle);
		Result UpdateSong(SongDTO songDTO);
		Result DeleteSong(SongDTO songDTO);
	}
}