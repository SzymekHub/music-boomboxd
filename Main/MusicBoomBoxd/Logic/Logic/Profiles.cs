using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Logic
{
    public class Profiles
    {
        public string UserEmail { get;}

        public string Image {  get; private set; }

        public List<Album> FavoriteAlbum{ get; private set; }

        public List<Album> PublishedAlbums { get; private set; }

        public List<Song> FavoriteSong { get; private set; }

        public List<Song> PublishedSongs { get; private set; }

        public List<Profiles> Following {  get; private set; }

        public Profiles(string userEmail, string image, List<Album> favoriteAlbum, List<Album> publishedAlbums, List<Song> favoriteSong, List<Song> publishedSongs, List<Profiles> following)
        {
            UserEmail = userEmail;
            Image = image;
            FavoriteAlbum = favoriteAlbum;
            PublishedAlbums = publishedAlbums;
            FavoriteSong = favoriteSong;
            PublishedSongs = publishedSongs;
            Following = following;
        }


        public void AddFavoriteAlbum(Album album)
        {
        }

        public void RemoveFavoriteAlbum(Album album)
        {
        }

        public void AddFavoriteSong(Song song)
        {
        }

        public void RemoveFavoriteSong(Song song)
        {
        }
    }
}
