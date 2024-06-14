using Logic;

namespace WebApp.Pages.Models
{
	public class SongViewPageModel
	{
		public int SongID { get; }
		public string Title { get; }
		public Artist Artist { get; set; }
		public DateTime Date { get; set; }
		public int RunTime { get; set; }
		public genreType Genre { get; set; }
		public double AverageRating { get; set; }
		public string SongCoverData { get; set; }
		public string SongCoverContentType { get; set; }

		public SongViewPageModel(int songID, Artist artist, string title, DateTime date, int runTime, genreType genre, string songCoverData, string songCoverContentType)
		{
			SongID = songID;
			Artist = artist;
			Title = title;
			Date = date;
			RunTime = runTime;
			Genre = genre;
			SongCoverData = songCoverData;
			SongCoverContentType = songCoverContentType;
		}

		public SongViewPageModel(int songID, Artist artist, string title, DateTime date, int runTime, genreType genre, double averageRating, string songCoverData, string songCoverContentType)
		{
			SongID = songID;
			Artist = artist;
			Title = title;
			Date = date;
			RunTime = runTime;
			Genre = genre;
			AverageRating = averageRating;
			SongCoverData = songCoverData;
			SongCoverContentType = songCoverContentType;
		}
	}
}
