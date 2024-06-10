using Logic;

namespace WebApp.Pages
{
	public class SongModel
	{
		public int SongID { get; }
		public string Title { get; }
		public int ArtistID { get; set; } 
		public Artist Artist { get; set; }
		public DateTime Date { get; set; }
		public int RunTime { get; set; }
		public genreType Genre { get; set; }

		public SongModel(int songID, string title, int artistID, DateTime date, int runTime, genreType genre)
		{
			SongID = songID;
			Title = title;
			ArtistID = artistID;
			Date = date;
			RunTime = runTime;
			Genre = genre;
		}
        public SongModel(int songID, string title)
        {
            SongID = songID;
            Title = title;
        }
    }
}
