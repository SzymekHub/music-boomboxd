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
        AlbumRepository _albumRepository = new AlbumRepository();

        public AlbumManager()
        {
            albums = new List<Album>();
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
