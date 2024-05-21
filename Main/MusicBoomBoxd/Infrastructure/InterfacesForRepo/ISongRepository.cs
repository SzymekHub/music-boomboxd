
namespace Infrastructure
{
    public interface ISongRepository
    {
        Result DeleteSong(SongDTO songDTO);
        List<SongDTO> GetRecentSong(int count);
        Result InsertSong(SongDTO songDTO);
        Result UpdateSong(SongDTO newSongDTO, SongDTO oldSongDTO);
    }
}