using Infrastructure;

namespace Logic
{
    public class SongManager
    {
        public List<Song> _songs;
        private readonly SongRepository _songRepository;
        private readonly ISongRepository _isongRepository;

        public SongManager(SongRepository songRep, ISongRepository isongRep)
        {
            _songs = new List<Song>();
            _songRepository = songRep;
            _isongRepository = isongRep;
        }

        public void LoadSongsFromDataBase()
        {
            List<SongDTO> songDTOs = _songRepository.GetRecentSong(1000);
            
            _songs.Clear();

            foreach (var songDTO in songDTOs)
            {
                //This converts SongDTO to Songs and adds to the songs list
                Song song = ConvertToSong(songDTO);
                _songs.Add(song);
            }
        }

        public Result Add(Song song)
        {
            SongDTO songDTO = ConvertToSongDTO(song);

            _songs.Add(song);

            Result resultfailed = new Result { Success = false, Message = "" };
            
            Result resultSong = SendSongToTheDb(songDTO);

            if (resultfailed.Success == false)
            {
                return resultfailed;
            }
            else
            {
                return resultSong;
            }
        }

        public bool Remove(Song song)
        {
            _songRepository.DeleteSong(ConvertToSongDTO(song));

            return _songs.Remove(song);
        }
        public Song[] GetArray()
        {
            return _songs.ToArray();
        }

        public Result Update(Song newSong, Song oldSong)
        {
            SongDTO newSongDTO = ConvertToSongDTO(newSong);

            SongDTO oldSongDTO = ConvertToSongDTO(oldSong);
            
            // This calls the repository method to update the Song
            Result resultUpdate = _songRepository.UpdateSong(newSongDTO, oldSongDTO);

            if (resultUpdate.Success)
            {
                LoadSongsFromDataBase();

                // If the update was successful, this updates the Song in the list
                int index = _songs.FindIndex(a => a == oldSong);

                if (index != -1)
                {
                    _songs[index] = newSong;
                }
            }
            else
            {
                Console.WriteLine("Looks like something went wrong when updating the Song in the database :(");
            }

            return resultUpdate;
        }

        public Result SendSongToTheDb(SongDTO newSong)
        {
            return _songRepository.InsertSong(newSong);
        }


        public Song ConvertToSong(SongDTO newsongDTO)
        {
            //Converts the genre enum to a string 
            genreType genre = (genreType)Enum.Parse(typeof(genreType), newsongDTO.Genre);

            //this converts SongDTO to songs
            return new Song(
                newsongDTO.SongID,
                newsongDTO.SongTitle,
                newsongDTO.Artist,
                newsongDTO.ReleaseDate,
                genre,
                newsongDTO.SongCoverName,
                newsongDTO.SongCoverData,
                newsongDTO.SongCoverContentType
                );
        }

        public SongDTO ConvertToSongDTO(Song song)
        {
            // this converts Song to SongDTO
            return new SongDTO(
                song.SongID,
                song.Title,
                song.Artist,
                song.Date,
                song.Genre.ToString(),
                song.SongCoverName,
                song.SongCoverData,
                song.SongCoverContentType
            );
        }
    }
}
