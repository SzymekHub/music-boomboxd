using Infrastructure;
using Infrastructure.DTOs;
using Infrastructure.InterfacesForRepo;
using Infrastructure.Repositories;
using Logic.Algorithms;
using Logic.Interfaces;

namespace Logic
{
    public class SongManager
    {
        private readonly ISongRepository _songRepository;
        private readonly IArtistRepository _artistRepository;
        private readonly ArtistManager _artistManager;
        private readonly IValidateSong _validateSong;
		private readonly Artist artist;

        public SongManager(ISongRepository isongRep, IArtistRepository iartRep, IValidateSong ivalidSong)
        {
            _songRepository = isongRep;
            _artistManager = new ArtistManager(iartRep);
            _artistRepository = iartRep;
            _validateSong = ivalidSong;
        }

        public List<Song> LoadSongsFromDataBase()
        {
            List<Song> songs = new();

            List<SongDTO> songDTOs = _songRepository.GetSongs(1000);
            
            foreach (var songDTO in songDTOs)
            {
                Artist artist = _artistManager.GetArtistByArtistID(songDTO.ArtistDTO.ArtistID);

                if (artist != null)
                {
                    Song song = SongMapper.ToSong(songDTO, artist);
                    song.Artist = artist;
                    songs.Add(SongMapper.ToSong(songDTO, artist));
                }
            }
            return songs;
        }

        public List<Song> GetSongsForAlbum(int albumID)
        {
            List<Song> songs = new List<Song>();

            List<SongDTO> songDTOs = _songRepository.GetSongsForAlbum(albumID);

            foreach (var songDTO in songDTOs)
            {
                Artist artist = _artistManager.GetArtistByArtistID(songDTO.ArtistDTO.ArtistID);
                if (artist != null)
                {
                    Song song = SongMapper.ToSong(songDTO, artist);
                    song.Artist = artist;
                    songs.Add(song);
                }
            }

            return songs;
        }

        public List<Song> GetSongsForUsers(int userID)
        {
            List<Song> songs = new List<Song>();

            List<SongDTO> songDTOs = _songRepository.GetSongsForUser(userID);

            foreach (var songDTO in songDTOs)
            {
                Artist artist = _artistManager.GetArtistByArtistID(songDTO.ArtistDTO.ArtistID);
                if (artist != null)
                {
                    Song song = SongMapper.ToSong(songDTO, artist);
                    song.Artist = artist;
                    songs.Add(song);
                }
            }

            return songs;
        }
		public int GetSongIDBySongTitle(string songTitle)
		{
			return _songRepository.GetSongIDBySongTitle(songTitle);
		}

		public Result Add(Song song)
        {
            SongDTO songDTO = SongMapper.ToSongDTO(song);

            Result resultSong = SendSongToTheDb(songDTO);

            return resultSong;

        }
		public Result AddWEB(Song song)
		{
			SongDTO songDTO = SongMapper.ToSongDTO(song);

			Result resultSong = SendSongToTheDbWEB(songDTO);

			return resultSong;

		}

		public Result Remove(Song song)
        {
            Result resultRemoveSong = _songRepository.DeleteSong(SongMapper.ToSongDTO(song));

            return resultRemoveSong;
        }

        public Result Update(Song newSong)
        {
            SongDTO songDTO = SongMapper.ToSongDTO(newSong);

            if (newSong.SongID == 0)
            {
                return Add(newSong);
            }

            Result resultUpdated = _songRepository.UpdateSong(songDTO);

            return resultUpdated;
        }

        public Result SendSongToTheDb(SongDTO newSong)
        {
            return _songRepository.InsertSong(newSong);
        }

		public Result SendSongToTheDbWEB(SongDTO newSong)
		{
			var errors = _validateSong.ValidateSongs(newSong.SongTitle, newSong.ArtistDTO.ArtistID);
			if (errors.Any())
			{
				return new Result
				{
					Success = false,
					Errors = errors
				};
			}
			return _songRepository.InsertSong(newSong);
		}
	}
}
