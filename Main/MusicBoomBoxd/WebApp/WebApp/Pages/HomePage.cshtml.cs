using Microsoft.AspNetCore.Mvc.RazorPages;
using Logic; 
using WebApp.Pages.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Infrastructure;

namespace WebApp.Pages
{
	[Authorize]

	public class HomePageModel : PageModel
	{
		private readonly AlbumManager _albumManager;
        private readonly SongManager _songManager;
        private readonly ArtistManager _artistManager;
        private readonly IReviewRepository  _reviewRepository;
		private readonly IAlbumRepository _albumRepository;
		private readonly IUserRepository _userRepository;
		private readonly ReviewManager _reviewManager;

		public List<AlbumViewModel> Albums { get; private set; }
        public List<SongModel> Songs { get; private set; }
		public string Username { get; private set; }


		public HomePageModel(AlbumManager albumManager, SongManager songManager, ArtistManager artistManager, IReviewRepository reviewRepository, IUserRepository userRepository, IAlbumRepository albumRepository)
		{
			_albumManager = albumManager;
            _songManager = songManager;
            _artistManager = artistManager;
            _reviewRepository = reviewRepository;
            _userRepository = userRepository;
            _albumRepository = albumRepository;
            _reviewManager = new ReviewManager(reviewRepository, userRepository, albumRepository);
		}

        private void LoadAlbums()
        {
			var userClaims = User.Claims;
			Username = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

			List<Album> albums = _albumManager.LoadAlbumsFromDatabase();

            Albums = new List<AlbumViewModel>();

            foreach (var album in albums)
            {
                Artist artist = _artistManager.GetArtistByArtistID(album.Artist.ArtistID);

                List<Song> songs = _songManager.GetSongsForAlbum(album.AlbumID);

				var averageRating = _reviewManager.GetAverageRatingByAlbumID(album);

				Albums.Add(new AlbumViewModel(album.AlbumID, artist, songs, album.Title, album.Date, album.RunTime, album.Genre, averageRating, Convert.ToBase64String(album.AlbumCoverData), album.AlbumCoverContentType));
            }
        }

        public void OnGet()
		{
			LoadAlbums();
		}

	}
}
