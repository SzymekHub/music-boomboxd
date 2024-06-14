using Microsoft.AspNetCore.Mvc.RazorPages;
using Infrastructure.DTOs;
using Infrastructure.InterfacesForRepo;
using Infrastructure.Repositories;
using Logic.Algorithms;
using Logic.Interfaces;
using Logic;
using WebApp.Pages.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Infrastructure;


namespace WebApp.Pages
{
	[Authorize]
	public class SongReviewsModel : PageModel
	{
		private readonly SongManager _songManager;
		private readonly ArtistManager _artistManager;
		private readonly ISongRepository _songRepository;
		private readonly IUserRepository _userRepository;

		public List<SongViewPageModel> Songs { get; private set; }
		public string Username { get; private set; }


		public SongReviewsModel(SongManager songManager, ArtistManager artistManager, IUserRepository userRepository, ISongRepository songRepository)
		{
			_songManager = songManager;
			_artistManager = artistManager;
			_userRepository = userRepository;
			_songRepository = songRepository;
		}

		private void LoadSongs()
		{
			var userClaims = User.Claims;
			Username = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

			List<Song> songs = _songManager.LoadSongsFromDataBase();

            Songs = new List<SongViewPageModel>();

            foreach (var song in songs)
			{
				Artist artist = _artistManager.GetArtistByArtistID(song.Artist.ArtistID);

				Songs.Add(new SongViewPageModel(song.SongID, artist, song.Title, song.Date, song.RunTime, song.Genre, Convert.ToBase64String(song.SongCoverData), song.SongCoverContentType));
			}
		}

		public void OnGet()
		{
			LoadSongs();
		}

	}
}

