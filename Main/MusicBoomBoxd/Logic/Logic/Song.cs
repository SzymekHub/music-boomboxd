using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Logic
{
    public class Song
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public DateTime Date { get; set; }
        public genreType Genre { get; set; }
        public string SongCoverName { get; set; }
        public byte[] SongCoverData { get; set; }
        public string SongCoverContentType { get; set; }

        public Song(string title, string artist, DateTime date, genreType genre, string songCoverName, byte[] songCoverData, string songCoverContentType)
        {
            Title = title;
            Artist = artist;
            Date = date;
            Genre = genre;
            SongCoverName = songCoverName;
            SongCoverData = songCoverData;
            SongCoverContentType = songCoverContentType;
        }

    }
}
