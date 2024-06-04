
namespace Infrastructure
{
    public interface ISongRepository
    {
        Result InsertSong(SongDTO songDTO);
        List<SongDTO> GetRecentSong(int count);
        List<SongDTO> GetSongsForAlbum(int albumID);
        List<SongDTO> GetSongsForUser(int userID);
        Result UpdateSong(SongDTO newSongDTO, SongDTO oldSongDTO);
        Result DeleteSong(SongDTO songDTO);
    }
}