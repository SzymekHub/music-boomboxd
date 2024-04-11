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
        public int ProfileID {  get; private set; }

        public int UserID { get; private set; }

        public string Image {  get; private set; }

        public List<Music> FavoriteMusic { get; private set; }

        public List<Music> PublishedMusic { get; private set; }

        public List<Profiles> Following {  get; private set; }

        public Profiles(int profileID, int userID, string image, List<Music> favoriteMusic, List<Music> publishedMusic, List<Profiles> following)
        {
            ProfileID = profileID;
            UserID = userID;
            Image = image;
            FavoriteMusic = favoriteMusic;
            PublishedMusic = publishedMusic;
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
