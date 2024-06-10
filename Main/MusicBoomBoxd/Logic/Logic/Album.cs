namespace Logic
{
    public class Album
    {
        public int AlbumID { get; }
        //public int ArtistID { get; set; }
        public Artist Artist { get; set; }
        public List<Song> Songs { get; set; } 
        public string Title { get; }
        public DateTime Date { get; set; }
        public int RunTime { get; set; }
        public genreType Genre { get; set; }
        public string AlbumCoverName { get; set; }
        public byte[] AlbumCoverData { get; set; }
        public string AlbumCoverContentType { get; set; }

        public Album(int albumID, /*int artistID*/ Artist artist, string title, DateTime date, int runTime, genreType genre, string albumCoverName, byte[] albumCoverData, string albumCoverContentType)
        {
            AlbumID = albumID;
            //ArtistID = artistID;
            Artist = artist;
            Title = title;
            Date = date;
            RunTime = runTime;
            Genre = genre;
            AlbumCoverName = albumCoverName;
            AlbumCoverData = albumCoverData;
            AlbumCoverContentType = albumCoverContentType;
            Songs = new List<Song>(); 
        }

        public Album(/*int artistID*/Artist artist, string title, DateTime date, int runTime, genreType genre, string albumCoverName, byte[] albumCoverData, string albumCoverContentType)
        {
            Artist = artist;
            //ArtistID = artistID;
            Title = title;
            Date = date;
            RunTime = runTime;
            Genre = genre;
            AlbumCoverName = albumCoverName;
            AlbumCoverData = albumCoverData;
            AlbumCoverContentType = albumCoverContentType;
            Songs = new List<Song>(); 
        }
    }
}
