using Logic;

namespace WebApp.Pages.Models
{
	public class AlbumViewModel
	{
        public string ArtistName { get; set; }
        public List<Song> Songs { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public genreType Genre { get; set; }
        public string AlbumCoverData { get; set; }
		public string AlbumCoverContentType { get; set; }

        public AlbumViewModel(string artistName, List<Song> songs, string title, DateTime date, genreType genre, string albumCoverData, string albumCoverContentType)
        {
            ArtistName = artistName;
            Songs = songs;
            Title = title;
            Date = date;
            Genre = genre;
            AlbumCoverData = albumCoverData;
            AlbumCoverContentType = albumCoverContentType;
        }

    }

}
