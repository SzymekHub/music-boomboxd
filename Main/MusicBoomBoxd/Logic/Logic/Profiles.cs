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
        private int ProfileID {  get; set; }

        private int UserID { get; set; }

        private string Image {  get; set; }

        private List<Music> FavoriteMusic { get; set; }

        private List<Music> PublishedMusic { get; set; }

        private List<Profiles> Following {  get; set; }

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
