namespace Logic
{
    public class Song
    {
        public int SongID { get;}
        public string Title { get; }
        public int ArtistID { get; set; }
        public Artist Artist { get; set; }
        public DateTime Date { get; set; }
        public int RunTime { get; set; }
        public genreType Genre { get; set; }
        public string SongCoverName { get; set; }
        public byte[] SongCoverData { get; set; }
        public string SongCoverContentType { get; set; }

        public Song(int songID, string title, int artistID, DateTime date, int runTime, genreType genre, string songCoverName, byte[] songCoverData, string songCoverContentType)
        {
            SongID = songID;
            Title = title;
            ArtistID = artistID;
            Date = date;
            RunTime = runTime;
            Genre = genre;
            SongCoverName = songCoverName;
            SongCoverData = songCoverData;
            SongCoverContentType = songCoverContentType;
        }

        public Song(string title, int artistID, DateTime date, int runTime, genreType genre, string songCoverName, byte[] songCoverData, string songCoverContentType)
        {
            Title = title;
            ArtistID = artistID;
            Date = date;
            RunTime = runTime;
            Genre = genre;
            SongCoverName = songCoverName;
            SongCoverData = songCoverData;
            SongCoverContentType = songCoverContentType;
        }
    }
}
