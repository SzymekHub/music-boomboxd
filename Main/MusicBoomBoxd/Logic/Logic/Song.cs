namespace Logic
{
    public class Song
    {
        public int SongID { get;}
        public string Title { get; }
        public string Artist { get; }
        public DateTime Date { get; set; }
        public genreType Genre { get; set; }
        public string SongCoverName { get; set; }
        public byte[] SongCoverData { get; set; }
        public string SongCoverContentType { get; set; }

        public Song(int songID, string title, string artist, DateTime date, genreType genre, string songCoverName, byte[] songCoverData, string songCoverContentType)
        {
            SongID = songID;
            Title = title;
            Artist = artist;
            Date = date;
            Genre = genre;
            SongCoverName = songCoverName;
            SongCoverData = songCoverData;
            SongCoverContentType = songCoverContentType;
        }

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
