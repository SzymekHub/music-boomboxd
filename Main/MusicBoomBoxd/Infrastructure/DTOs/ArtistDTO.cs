namespace Infrastructure.DTOs
{
    public class ArtistDTO
    {
        public int ArtistID { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public string ArtistPictureName { get; set; }
        public byte[] ArtistPictureData { get; set; }
        public string ArtistPictureContentType { get; set; }
    }
}
