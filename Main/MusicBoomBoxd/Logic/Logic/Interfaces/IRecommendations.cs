using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IRecommendations
    {
        List<Song> GetRecommendedSong(User user);
    }
}
