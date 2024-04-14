using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTOs
{
    //This class represents the data structure of a song
    public class SongDTO
    {
        public string SongTitle { get; set; }
        public string Artist { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre {  get; set; }

        public SongDTO(string songTitle, string artist, DateTime releaseDate, string genre)
        {
            SongTitle = songTitle;
            Artist = artist;
            ReleaseDate = releaseDate;
            Genre = genre;
        }
    }
}
