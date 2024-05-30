
namespace Infrastructure
{
    public interface ISongRepository
    {
        Result InsertSong(SongDTO songDTO);
        List<SongDTO> GetRecentSong(int count);
        Result UpdateSong(SongDTO newSongDTO, SongDTO oldSongDTO);
        Result DeleteSong(SongDTO songDTO);
    }
}