using Logic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Pages
{
	public class InputFormAlbumModel
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

		public string AlbumCoverName { get; set; } = string.Empty;

		public byte[] AlbumCoverData { get; set; } = new byte[0];

		public string AlbumCoverContentType { get; set; } = string.Empty;
		
		public InputFormAlbumModel()
		{

		}

		public InputFormAlbumModel(string title, int artistID, DateTime date, genreType genre, string albumCoverName, byte[] albumCoverData, string albumCoverContentType)
		{
			Title = title;
			ArtistID = artistID;
			Date = date;
			Genre = genre;
			AlbumCoverName = albumCoverName;
			AlbumCoverData = albumCoverData;
			AlbumCoverContentType = albumCoverContentType;
		}
	}
}
