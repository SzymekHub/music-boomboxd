
namespace Infrastructure
{
    public class AlbumDTO
    {
        public int AlbumID { get; set; }
        public ArtistDTO ArtistDTO { get; set; }
        public string AlbumTitle { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int RunTime { get; set; }
        public string Genre { get; set; }
        public string AlbumCoverName { get; set; }
        public byte[] AlbumCoverData { get; set; }
        public string AlbumCoverContentType { get; set; }
    }
}
