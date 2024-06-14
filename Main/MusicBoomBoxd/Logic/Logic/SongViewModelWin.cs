using Infrastructure;
using Infrastructure.DTOs;
using Infrastructure.InterfacesForRepo;
using Infrastructure.Repositories;
using Logic.Algorithms;
using Logic.Interfaces;

namespace Logic
{
    public class SongViewModelWin
    {
        public int SongID { get; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public DateTime Date { get; set; }
        public string Genre { get; set; }
        public string SongCoverName { get; set; }
        public byte[] SongCoverData { get; set; }
        public string SongCoverContentType { get; set; }

        public SongViewModelWin(Song song)
        {
            SongID = song.SongID;
            Title = song.Title;
            Artist = song.Artist.Name;
            Genre = song.Genre.ToString();
            Date = song.Date;
            SongCoverName = song.SongCoverName;
            SongCoverData = song.SongCoverData;
            SongCoverContentType = song.SongCoverContentType;
        }
    }
}
