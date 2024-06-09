using Logic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Pages
{
    public class InputFormSongModel
    {
		[Required(ErrorMessage = "Title is required.")]
		public string Title { get; set; }

		[Required(ErrorMessage = "Artist is required.")]
		public int ArtistID { get; set; }

		[Required(ErrorMessage = "Date is required.")]
		public DateTime Date { get; set; }

		[Required(ErrorMessage = "RunTime is required.")]
		public int RunTime { get; set; }

		[Required(ErrorMessage = "Genre is required.")]
		public genreType Genre { get; set; }

		public string SongCoverName { get; set; } = string.Empty;

		public byte[] SongCoverData { get; set; } = new byte[0];

		public string SongCoverContentType { get; set; } = string.Empty;

		public InputFormSongModel() 
		{
			
		}
		public InputFormSongModel(string title, int artistID, DateTime date, genreType genre, string songCoverName, byte[] songCoverData, string songCoverContentType)
		{
			Title = title;
			ArtistID = artistID;
			Date = date;
			Genre = genre;
			SongCoverName = songCoverName;
			SongCoverData = songCoverData;
			SongCoverContentType = songCoverContentType;
		}
	}
}
