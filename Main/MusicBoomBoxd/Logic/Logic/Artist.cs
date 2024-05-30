namespace Logic
{
    public class Artist
    {
        public int ArtistID { get; }
        public string Name { get; set; }
        public string ArtistPictureName { get; set; }
        public byte[] ArtistPictureData { get; set; }
        public string ArtistPictureContentType { get; set; }

        public Artist(int artistID, string name, string artistPictureName, byte[] artistPictureData, string artistPictureContentType)
        {
            ArtistID = artistID;
            Name = name;
            ArtistPictureName = artistPictureName;
            ArtistPictureData = artistPictureData;
            ArtistPictureContentType = artistPictureContentType;
        }

        public Artist(string name, string artistPictureName, byte[] artistPictureData, string artistPictureContentType)
        {
            Name = name;
            ArtistPictureName = artistPictureName;
            ArtistPictureData = artistPictureData;
            ArtistPictureContentType = artistPictureContentType;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
