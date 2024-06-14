using Infrastructure.DTOs;
using Infrastructure.InterfacesForRepo;
using Infrastructure.Repositories;
using Logic.Algorithms;
using Logic.Interfaces;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using WebApp.Pages.Models;


namespace WebApp.Pages
{
    [Authorize]
    public class AlbumsPageModel : PageModel
    {
        private readonly IUserRepository _userRepository;
        private readonly IProfileRepository _profileRepository;
        private readonly IArtistRepository _artistRepository;
        private readonly IAlbumRepository _albumRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IValidateUser _validateUser;
        private readonly IValidateAlbum _validateAlbum;
        private readonly AlbumManager _albumManager;
		private readonly SongManager _songManager;
		private readonly ArtistManager _artistManager;
		private readonly ReviewManager _reviewManager;
        private readonly UserManager _userManager;

		public List<AlbumViewModel> Albums { get; private set; }
		public List<SongModel> Songs { get; private set; }
		public string Username { get; private set; }

        public AlbumsPageModel(IUserRepository userRepository, IProfileRepository profileRepository, IAlbumRepository albumRepository, IReviewRepository reviewRepository, IValidateUser validateUser, IPasswordHasher passwordHasher, IArtistRepository artistRepository, IValidateAlbum validateAlbum, AlbumManager albumManager, SongManager songManager, ArtistManager artistManager)
        {
            _userRepository = userRepository;
            _profileRepository = profileRepository;
            _validateUser = validateUser;
            _passwordHasher = passwordHasher;
            _userManager = new UserManager(passwordHasher, userRepository, validateUser, profileRepository);
            _albumRepository = albumRepository;
            _artistRepository = artistRepository;
            _validateAlbum = validateAlbum;
			_reviewRepository = reviewRepository;
			_reviewManager = new ReviewManager(reviewRepository, userRepository, albumRepository);
            _passwordHasher = passwordHasher;
			_albumManager = albumManager;
			_songManager = songManager;
			_artistManager = artistManager;
		}


        private void LoadAlbums()
        {
			List<Album> albums = _albumManager.LoadAlbumsFromDatabase();

			Albums = new List<AlbumViewModel>();

			foreach (var album in albums)
			{
				Artist artist = _artistManager.GetArtistByArtistID(album.Artist.ArtistID);

				List<Song> songs = _songManager.GetSongsForAlbum(album.AlbumID);

				Albums.Add(new AlbumViewModel(album.AlbumID, artist, songs, album.Title, album.Date, album.RunTime, album.Genre, Convert.ToBase64String(album.AlbumCoverData), album.AlbumCoverContentType));
			}
		}

        public void OnGet()
        {
            LoadAlbums();
        }

        public string GetPercentageDifferenceClass(double percentageDifference)
        {
            if (percentageDifference == 0)
                return "percent-zero";
            else if (percentageDifference > 0 && percentageDifference <= 10)
                return "percent-light-green";
            else if (percentageDifference > 10)
                return "percent-green";
            else if (percentageDifference < 0 && percentageDifference >= -10)
                return "percent-light-red";
            else
                return "percent-red";
        }

        public IActionResult OnPostRate(int albumID, int rating)
        {
            var userClaims = User.Claims;
            Username = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            User user = _userManager.GetUserByUsernameFromDb(Username);

            Album album = _albumManager.GetAlbumByAlbumID(albumID);

            if (album == null)
            {
                return NotFound();
            }

            Review existingReview = _reviewManager.GetReviewByUsernameAndAlbumID(Username, albumID);

            if (existingReview != null)
            {
                existingReview.Rate = rating;
                _reviewManager.UpdateRating(existingReview);
            }
            else
            {
                // Create a new Review for the user and the album
                Review newRating = new Review(user, album, rating);
                _reviewManager.AddReview(newRating);
            }

            return RedirectToPage("/AlbumsPage");
        }

    }
}