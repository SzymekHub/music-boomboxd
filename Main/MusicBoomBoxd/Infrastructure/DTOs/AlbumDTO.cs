using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTOs
{
    public class AlbumDTO
    {
        //This class represents the data structure of a Album
        public string AlbumTitle { get; set; }
        public string Artist { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public byte[] AlbumCover { get; set; }

        public AlbumDTO(string albumTitle, string artist, DateTime releaseDate, string genre, byte[] albumCover)
        {
            AlbumTitle = albumTitle;
            Artist = artist;
            ReleaseDate = releaseDate;
            Genre = genre;
            AlbumCover = albumCover;
        }
    }
}
