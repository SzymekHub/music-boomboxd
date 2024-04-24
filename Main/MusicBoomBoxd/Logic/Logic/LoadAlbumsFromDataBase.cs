using Infrastructure;
using Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class LoadAlbumsFromDataBase
    {
        private readonly AlbumRepository _albumRepository;

        public LoadAlbumsFromDataBase(AlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public List<AlbumDTO> LoadAllAlbums()
        {
            //This will laod all the albums
            return _albumRepository.GetRecentAlbum(int.MaxValue);
        }
    }
}
