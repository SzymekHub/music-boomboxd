using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;


namespace WebApp.Pages
{
	[Authorize]
	public class FormPageSongModel : PageModel
	{
		private readonly IWebHostEnvironment _webHostEnvironment;
		private readonly SongManager _songManager;
		private readonly ArtistManager _artistManager;

		public List<SelectListItem> GenreOptions { get; set; }
		public List<Artist> Artists { get; private set; }
		public string Username { get; set; }

		[BindProperty]
		public InputFormSongModel InputSong { get; set; }

		// Added a property for handling file upload
		[BindProperty]
		[Display(Name = "Song Cover"), Required]
		public IFormFile SongCover { get; set; }

		public FormPageSongModel(SongManager songManager, ArtistManager artistManager, IWebHostEnvironment webHostEnvironment)
		{
			_songManager = songManager;
			_artistManager = artistManager;
			Artists = new List<Artist>();
			_webHostEnvironment = webHostEnvironment;
		}

		private void LoadGenres()
		{
			GenreOptions = Enum.GetValues(typeof(genreType))
								.Cast<genreType>()
								.Select(g => new SelectListItem
								{
									Value = g.ToString(),
									Text = g.ToString()
								}).ToList();
		}

		private void LoadArtists()
		{
			var artistsFromDb = _artistManager.LoadArtistFromDB();
			if (artistsFromDb != null)
			{
				Artists = artistsFromDb.ToList();
			}
			else
			{
				Artists = new List<Artist>();
			}
		}

		public void OnGet()
		{
			LoadGenres();
			LoadArtists();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			LoadGenres();
			LoadArtists();

			if (SongCover != null)
			{
				InputSong.SongCoverName = SongCover.FileName;
				InputSong.SongCoverContentType = SongCover.ContentType;

				using (var memorystream = new MemoryStream())
				{
					await SongCover.CopyToAsync(memorystream);
					InputSong.SongCoverData = memorystream.ToArray();
				}
			}

			if (!ModelState.IsValid)
			{
				return Page();
			}

			// Save Song to the database
			Song newSong = new Song(
				InputSong.Title,
				InputSong.ArtistID,
				InputSong.Date,
				InputSong.RunTime,
				(genreType)Enum.Parse(typeof(genreType), InputSong.Genre.ToString()),
				InputSong.SongCoverName,
				InputSong.SongCoverData,
				InputSong.SongCoverContentType
			);

			var result = _songManager.AddWEB(newSong);

			if (result.Success)
			{
				int existingSongID = _songManager.GetSongIDBySongTitle(InputSong.Title);
				return RedirectToPage("/HomePage");
			}
			else
			{
				if (result.Errors != null)
				{
					foreach (var errorKey in result.Errors)
					{
						foreach (var errorValue in errorKey.Value)
						{
							ModelState.AddModelError($"Song.{errorKey.Key}", errorValue);
						}
					}
				}
				else
				{
					ModelState.AddModelError("", result.Message);
				}
			}

			//Returns a page if any of the above conditions are not met
			// Display error message if song already Exists for this artist is incorrect
			ViewData["ErrorMessage"] = "This song already exists for this artist";
			return Page();
		}
	}
}

