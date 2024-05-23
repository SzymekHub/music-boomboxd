namespace Infrastructure
{
    public class AlbumDTO
    {
        public int AlbumID { get; set; }
        public int ArtistID { get; set; }
        public string AlbumTitle { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string AlbumCoverName { get; set; }
        public byte[] AlbumCoverData { get; set; }
        public string AlbumCoverContentType { get; set; }

        public AlbumDTO(int albumID, int artistID, string albumTitle, DateTime releaseDate, string genre, string albumCoverName, byte[] albumCoverData, string albumCoverContentType)
        {
            AlbumID = albumID;
            ArtistID = artistID;
            AlbumTitle = albumTitle;
            ReleaseDate = releaseDate;
            Genre = genre;
            AlbumCoverName = albumCoverName;
            AlbumCoverData = albumCoverData;
            AlbumCoverContentType = albumCoverContentType;
        }
    }
}
