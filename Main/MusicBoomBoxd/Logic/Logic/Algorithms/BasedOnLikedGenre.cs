using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Algorithms
{

    //extend on other things
    // like: genre and something else fav songs,  etc.
    public class BasedOnLikedGenre : IRecommendations
    {
        public List<Song> GetRecommendedSong(User user)
        {
            throw new NotImplementedException();
        }
    }
}
