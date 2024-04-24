using Infrastructure;
using Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class SongManager
    {
        private List<Song> _songs;
        private readonly SongRepository _songRepository;
        private readonly LoadSongsFromDataBase _loadSongsFromDataBase;

        public SongManager(LoadSongsFromDataBase loadSongsFromDataBase)
        {
            _songs = new List<Song>();
            _loadSongsFromDataBase = loadSongsFromDataBase;
            _songRepository = new SongRepository();
        }

        public void LoadSongsFromDataBase()
        {
            List<SongDTO> songDTOs = _loadSongsFromDataBase.LoadAllSongs();
            foreach (var songDTO in songDTOs)
            {
                //This converts SongDTO to Songs and adds to the songs list
                Song song = ConvertToSong(songDTO);
                _songs.Add(song);
            }
        }
        
        private Song ConvertToSong(SongDTO songDTO)
        {
            //this converts SongDTO to songs
            return new Song(
                songDTO.SongTitle,
                songDTO.Artist,
                songDTO.ReleaseDate,
                (genreType)Enum.Parse(typeof(genreType), songDTO.Genre),
                songDTO.SongCoverName,
                songDTO.SongCoverData,
                songDTO.SongCoverContentType
                );
        }

        public void Add(Song song)
        {
            // Convert the genre enum to a string
            string genreString = song.Genre.ToString();

            // Parse the genre string back to the enum type
            if (Enum.TryParse(typeof(genreType), genreString, out object genre))
            {
                // this converts Song to SongDTO
                SongDTO songDTO = new SongDTO(
                    song.Title,
                    song.Artist,
                    song.Date,
                    genreString,
                    song.SongCoverName,
                    song.SongCoverData,
                    song.SongCoverContentType
                );

                // This calls the InsertSong method with the songDTO
                _songRepository.InsertSong(songDTO);
                // This adds the song to the List<Song>
                _songs.Add(song);
            }
        }

        public Song[] GetArray()
        {
            return _songs.ToArray();
        }

        public bool Remove(Song song)
        {
            return _songs.Remove(song);
        }

        public void UpdateSong(Song newSong, Song oldSong)
        {
            // These are SongDTO objects for the new and old songs
            SongDTO newSongDTO = new SongDTO(
                newSong.Title,
                newSong.Artist,
                newSong.Date,
                newSong.Genre.ToString(),
                newSong.SongCoverName,
                newSong.SongCoverData,
                newSong.SongCoverContentType
            );

            SongDTO oldSongDTO = new SongDTO(
                oldSong.Title,
                oldSong.Artist,
                oldSong.Date,
                oldSong.Genre.ToString(),
                oldSong.SongCoverName,
                oldSong.SongCoverData,
                oldSong.SongCoverContentType
            );

            // This calls the repository method to update the Song
            bool success = _songRepository.UpdateSong(newSongDTO, oldSongDTO);

            if (success)
            {
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
        }
    }
}
