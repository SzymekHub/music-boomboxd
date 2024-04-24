using Infrastructure;
using Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class LoadSongsFromDataBase
    {
        private readonly SongRepository _songRepository;

        public LoadSongsFromDataBase(SongRepository songRepository)
        {
            _songRepository = songRepository;
        }

        public List<SongDTO> LoadAllSongs()
        {
            //This will laod all the songs
            return _songRepository.GetRecentSong(int.MaxValue);
        }
    }
}
