namespace Infrastructure
{
    public class AlbumDTO
    {
        //This class represents the data structure of a Album
        public int AlbumID { get; set; }
        public string AlbumTitle { get; set; }
        public string Artist { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string AlbumCoverName { get; set; }
        public byte[] AlbumCoverData { get; set; }
        public string AlbumCoverContentType { get; set; }

        public AlbumDTO(int albumID, string albumTitle, string artist, DateTime releaseDate, string genre, string albumCoverName, byte[] albumCoverData, string albumCoverContentType)
        {
            AlbumID = albumID;
            AlbumTitle = albumTitle;
            Artist = artist;
            ReleaseDate = releaseDate;
            Genre = genre;
            AlbumCoverName = albumCoverName;
            AlbumCoverData = albumCoverData;
            AlbumCoverContentType = albumCoverContentType;
        }
    }
}
