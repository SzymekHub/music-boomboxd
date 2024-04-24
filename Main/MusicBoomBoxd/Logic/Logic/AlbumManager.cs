using Infrastructure.DTOs;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class AlbumManager
    {
        private List<Album> albums;
        private readonly LoadAlbumsFromDataBase _loadAlbumsFromDataBase;

        public AlbumManager(LoadAlbumsFromDataBase loadAlbumsFromDataBase)
        {
            albums = new List<Album>();
            _loadAlbumsFromDataBase = loadAlbumsFromDataBase;
        }

        public void LoadAlbumsFromDatabase()
        {
            List<AlbumDTO> albumDTOs = _loadAlbumsFromDataBase.LoadAllAlbums();
            foreach (var albumDTO in albumDTOs)
            {
                // This converts AlbumDTO to Album and adds to the albums list
                Album album = ConvertToAlbum(albumDTO);
                albums.Add(album);
            }
        }

        private Album ConvertToAlbum(AlbumDTO albumDTO)
        {
            // This converts AlbumDTO to Album
            return new Album(
                albumDTO.AlbumTitle,
                albumDTO.Artist,
                albumDTO.ReleaseDate,
                (genreType)Enum.Parse(typeof(genreType), albumDTO.Genre),
                albumDTO.AlbumCoverName,
                albumDTO.AlbumCoverData,
                albumDTO.AlbumCoverContentType
            );
        }

        public void Add(Album album)
        {
            albums.Add(album);
        }

        public Album[] GetArray()
        {
            return albums.ToArray();
        }

        public bool Remove(Album album)
        {
            return albums.Remove(album);
        }

        public void UpdateAlbum(Album newAlbum, Album oldAlbum)
        {
            int index = albums.FindIndex(alb => alb == oldAlbum);
            if (index != -1)
            {
                albums[index] = newAlbum;
            }
            else
            {
                Console.WriteLine("Something went wrong when updating the album");
            }
        }
    }
}
