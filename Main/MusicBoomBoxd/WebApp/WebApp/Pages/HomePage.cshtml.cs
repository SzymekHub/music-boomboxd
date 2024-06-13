using Microsoft.AspNetCore.Mvc.RazorPages;
using Logic;
using WebApp.Pages.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;


namespace WebApp.Pages
{
    [Authorize]

    public class HomePageModel : PageModel
    {

        private readonly IAlbumRepository _albumRepository;
        private readonly IUserRepository _userRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IProfileRepository _profileRepository;
        private readonly IValidateUser _validateUser;
        private readonly IValidateAlbum _validateAlbum;
        private readonly IArtistRepository _artistRepository;
        private readonly ISongRepository _songRepository;
        private readonly IValidateSong _validateSong;
        private readonly UserManager _userManager;
        private readonly RecommendationManager _recomemmendationManager;
        private readonly ReviewManager _reviewManager;
        private readonly AlbumManager _albumManager;
        private readonly SongManager _songManager;
        private readonly ArtistManager _artistManager;

        public List<AlbumViewModel> Albums { get; private set; }
        public List<SongModel> Songs { get; private set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public List<Album> RecommendedAlbums { get; set; }

        public HomePageModel(IAlbumRepository albumRepository, IUserRepository userRepository, IReviewRepository reviewRepository, IProfileRepository profileRepository, IValidateUser validateUser, IValidateAlbum validateAlbum, IArtistRepository artistRepository, ISongRepository songRepository, IValidateSong validateSong)
        {
            _albumRepository = albumRepository;
            _userRepository = userRepository;
            _reviewRepository = reviewRepository;
            _profileRepository = profileRepository;
            _artistRepository = artistRepository;
            _songRepository = songRepository;
            _validateAlbum = validateAlbum;
            _validateUser = validateUser;
            _validateSong = validateSong;
            IPasswordHasher _passwordHasher = new PasswordHasher();
            _userManager = new UserManager(_passwordHasher, userRepository, validateUser, profileRepository);
            _artistManager = new ArtistManager(artistRepository);
            _albumManager = new AlbumManager(albumRepository, artistRepository, validateAlbum);
            _songManager = new SongManager(songRepository, artistRepository, validateSong);
            _reviewManager = new ReviewManager(reviewRepository, userRepository, albumRepository);

            var recommendationFilters = new List<IRecommendationFilter>
            {
                new FavArtistFilter(_albumRepository, _artistRepository),
                new ReviewFilter(_reviewRepository, _albumRepository),
                new FavGenreFilter(_albumRepository)
            };

            _recomemmendationManager = new RecommendationManager(albumRepository, profileRepository, userRepository, reviewRepository, artistRepository, recommendationFilters);
            _profileRepository = profileRepository;
            _validateUser = validateUser;

		}
		public void OnGet()
        {
            var userClaims = User.Claims;
            Username = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            Email = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            Role = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

        }

        private void LoadAlbums()
        {
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

        public IActionResult OnPostGetRecommendation(bool userArtistGenre, bool userReviewFilter, bool userAlbumFilter)
        {
			var userClaims = User.Claims;
            Username = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            Email = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            Role = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            User user = _userManager.GetUserByUsernameFromDb(Username);

            RecommendedAlbums = new List<Album>();
            if (user != null)
            {
                List<Album> recommendedAlbums = _recomemmendationManager.GetRecommendedAlbums(user, userArtistGenre, userReviewFilter, userAlbumFilter);
                if (recommendedAlbums != null)
                {
                    RecommendedAlbums.AddRange(recommendedAlbums);
                }

                return Page();
            }
            else
            {
                // Handle error
                return Page();
            }
        }

    }
}
