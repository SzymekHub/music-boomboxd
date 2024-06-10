using Microsoft.AspNetCore.Mvc.RazorPages;
using Logic; 
using WebApp.Pages.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Pages
{
	[Authorize]

	public class HomePageModel : PageModel
	{
		private readonly AlbumManager _albumManager;
        private readonly SongManager _songManager;
        private readonly ArtistManager _artistManager;

		public List<AlbumViewModel> Albums { get; private set; }
        public List<SongModel> Songs { get; private set; }


        public HomePageModel(AlbumManager albumManager, SongManager songManager, ArtistManager artistManager)
		{
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
                Artist artist = _artistManager.GetArtistByArtistID(album.Artist);

                List<Song> songs = _songManager.GetSongsForAlbum(album.AlbumID);

                Albums.Add(new AlbumViewModel(artist.Name, songs, album.Title, album.Date, album.Genre, Convert.ToBase64String(album.AlbumCoverData), album.AlbumCoverContentType));
            }
        }

        public void OnGet()
		{
			LoadAlbums();
		}

	}
}
