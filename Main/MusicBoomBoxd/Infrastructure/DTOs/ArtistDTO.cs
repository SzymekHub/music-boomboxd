namespace Infrastructure.DTOs
{
    public class ArtistDTO
    {
        public int ArtistID { get; set; }
        public string Name { get; set; }
        public string ArtistPictureName { get; set; }
        public byte[] ArtistPictureData { get; set; }
        public string ArtistPictureContentType { get; set; }

        public ArtistDTO(int artistID, string name, string artistPictureName, byte[] artistPictureData, string artistPictureContentType)
        {
            ArtistID = artistID;
            Name = name;
            ArtistPictureName = artistPictureName;
            ArtistPictureData = artistPictureData;
            ArtistPictureContentType = artistPictureContentType;
        }
    }
}
