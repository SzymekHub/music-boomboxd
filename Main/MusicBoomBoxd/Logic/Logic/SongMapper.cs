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
            SongDTO songDTO = new();

            songDTO.SongID = song.SongID;
			songDTO.SongTitle = song.Title;
			songDTO.ArtistDTO = ArtistMapper.ConvertToArtistDTO(song.Artist);
			songDTO.ReleaseDate = song.Date;
			songDTO.RunTime = song.RunTime;
			songDTO.Genre = song.Genre.ToString();
			songDTO.SongCoverName = song.SongCoverName;
			songDTO.SongCoverData = song.SongCoverData;
			songDTO.SongCoverContentType = song.SongCoverContentType;
                
            return songDTO;
        }

    }
}
