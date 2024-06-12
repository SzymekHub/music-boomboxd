namespace Infrastructure
{
    //This class represents the data structure of a song
    public class SongDTO
    {
        public int SongID { get; set; }
        public string SongTitle { get; set; }
		public ArtistDTO ArtistDTO { get; set; }
		public DateTime ReleaseDate { get; set; }
        public int RunTime { get; set; }
        public string Genre { get; set; }
        public string SongCoverName { get; set; }
        public byte[] SongCoverData { get; set; }
        public string SongCoverContentType { get; set; }

	}
}
