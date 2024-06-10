using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class AlbumViewModelWin
    {
        public int AlbumID { get; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public DateTime Date { get; set; }
        public string Genre { get; set; }
        public string AlbumCoverName { get; set; }
        public byte[] AlbumCoverData { get; set; }
        public string AlbumCoverContentType { get; set; }

        public AlbumViewModelWin(Album album)
        {
            AlbumID = album.AlbumID;
            Title = album.Title;
            Artist = album.Artist.Name;
            Genre = album.Genre.ToString();
            Date = album.Date;
            AlbumCoverName = album.AlbumCoverName;
            AlbumCoverData = album.AlbumCoverData;
            AlbumCoverContentType = album.AlbumCoverContentType;
        }

    }
}
