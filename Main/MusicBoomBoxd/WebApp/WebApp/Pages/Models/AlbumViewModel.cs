using Logic;
using Infrastructure;
using Logic;
using Infrastructure;
using Infrastructure.DTOs;
using Infrastructure.InterfacesForRepo;
using Infrastructure.Repositories;
using Logic.Algorithms;
using Logic.Interfaces;

namespace WebApp.Pages.Models
{
	public class AlbumViewModel
	{
        public int AlbumID { get; }
        public Artist Artist { get; set; }
        public List<Song> Songs { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int RunTime { get; set; }
        public genreType Genre { get; set; }
		public double AverageRating { get; set; }

		public string AlbumCoverData { get; set; }
		public string AlbumCoverContentType { get; set; }

        public AlbumViewModel(int albumID, Artist artist, List<Song> songs, string title, DateTime date, int runTime, genreType genre, string albumCoverData, string albumCoverContentType)
        {
            AlbumID = albumID;
            Artist = artist;
            Songs = songs;
            Title = title;
            Date = date;
            RunTime = runTime;
            Genre = genre;
            AlbumCoverData = albumCoverData;
            AlbumCoverContentType = albumCoverContentType;
        }

		public AlbumViewModel(int albumID, Artist artist, List<Song> songs, string title, DateTime date, int runTime, genreType genre, double averageRating, string albumCoverData, string albumCoverContentType)
		{
			AlbumID = albumID;
			Artist = artist;
			Songs = songs;
			Title = title;
			Date = date;
			RunTime = runTime;
			Genre = genre;
			AverageRating = averageRating;
			AlbumCoverData = albumCoverData;
			AlbumCoverContentType = albumCoverContentType;
		}
	}

}
