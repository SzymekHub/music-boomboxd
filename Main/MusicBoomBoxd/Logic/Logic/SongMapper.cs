using Infrastructure;

namespace Logic
{
    public static class SongMapper
    {

        public static Song ToSong(SongDTO songDTO, Artist artist)
        {
            return new Song(
                songDTO.SongID,
                songDTO.SongTitle,
                artist,
                songDTO.ReleaseDate,
                songDTO.RunTime,
                (genreType)Enum.Parse(typeof(genreType), songDTO.Genre),
                songDTO.SongCoverName,
                songDTO.SongCoverData,
                songDTO.SongCoverContentType);
        }

        public static SongDTO ToSongDTO(Song song)
        {
            return new SongDTO(
                song.SongID,
                song.Title,
                song.Artist.ArtistID,
                song.Date,
                song.RunTime,
                song.Genre.ToString(),
                song.SongCoverName,
                song.SongCoverData,
                song.SongCoverContentType
                );
        }

    }
}
