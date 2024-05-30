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
                songDTO.ArtistID,
                songDTO.ReleaseDate,
                (genreType)Enum.Parse(typeof(genreType), songDTO.Genre),
                songDTO.SongCoverName,
                songDTO.SongCoverData,
                songDTO.SongCoverContentType)
            {
                Artist = artist
            };
        }

        public static SongDTO ToSongDTO(Song song)
        {
            return new SongDTO(
                song.SongID,
                song.Title,
                song.ArtistID,
                song.Date,
                song.Genre.ToString(),
                song.SongCoverName,
                song.SongCoverData,
                song.SongCoverContentType
                );
        }

    }
}
