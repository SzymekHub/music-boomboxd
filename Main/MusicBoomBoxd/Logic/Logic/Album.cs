using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Album
    {
        public string Title { get; }
        public string Artist { get; }
        public DateTime Date { get; set; }
        public genreType Genre { get; set; }
        public string AlbumCoverName { get; set; }
        public byte[] AlbumCoverData { get; set; }
        public string AlbumCoverContentType { get; set; }


        public Album(string title, string artist, DateTime date, genreType genre, string albumCoverName, byte[] albumCoverData, string albumCoverContentType)
        {
            Title = title;
            Artist = artist;
            Date = date;
            Genre = genre;
            AlbumCoverName = albumCoverName;
            AlbumCoverData = albumCoverData;
            AlbumCoverContentType = albumCoverContentType;

        }
    }
}
