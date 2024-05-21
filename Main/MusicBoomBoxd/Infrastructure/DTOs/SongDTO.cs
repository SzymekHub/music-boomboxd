namespace Infrastructure
{
    //This class represents the data structure of a song
    public class SongDTO
    {
        public int SongID { get; set; }
        public string SongTitle { get; set; }
        public string Artist { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string SongCoverName { get; set; }
        public byte[] SongCoverData { get; set; }
        public string SongCoverContentType { get; set; }

        public SongDTO(int songID, string songTitle, string artist, DateTime releaseDate, string genre, string songCoverName, byte[] songCoverData, string songCoverContentType)
        {
            SongID = songID;
            SongTitle = songTitle;
            Artist = artist;
            ReleaseDate = releaseDate;
            Genre = genre;
            SongCoverName = songCoverName;
            SongCoverData = songCoverData;
            SongCoverContentType = songCoverContentType;
        }
    }
}
