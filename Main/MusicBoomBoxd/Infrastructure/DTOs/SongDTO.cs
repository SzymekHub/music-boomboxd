namespace Infrastructure
{
    //This class represents the data structure of a song
    public class SongDTO
    {
        public int SongID { get; set; }
        public string SongTitle { get; set; }
        public int ArtistID { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int RunTime { get; set; }
        public string Genre { get; set; }
        public string SongCoverName { get; set; }
        public byte[] SongCoverData { get; set; }
        public string SongCoverContentType { get; set; }

        public SongDTO(int songID, string songTitle, int artistID, DateTime releaseDate, int runTime, string genre, string songCoverName, byte[] songCoverData, string songCoverContentType)
        {
            SongID = songID;
            SongTitle = songTitle;
            ArtistID = artistID;
            ReleaseDate = releaseDate;
            RunTime = runTime;
            Genre = genre;
            SongCoverName = songCoverName;
            SongCoverData = songCoverData;
            SongCoverContentType = songCoverContentType;
        }
		public SongDTO(int songID, string songTitle, int artistID, DateTime releaseDate, string genre)
		{
			SongID = songID;
			SongTitle = songTitle;
			ArtistID = artistID;
			ReleaseDate = releaseDate;
			Genre = genre;
		}
	}
}
