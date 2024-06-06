using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.IO;



namespace WebApp.Pages
{
	[Authorize]
	public class FormPageModel : PageModel
	{
		public AlbumManager _albumManager { get; }
		private readonly IWebHostEnvironment _webHostEnvironment;
		private readonly SongManager _songManager;
		private readonly ArtistManager _artistManager;

		public List<SongModel> Songs { get; private set; }
		public List<Artist> Artists { get; private set; }
        public List<SelectListItem> GenreOptions { get; set; }

		//if i had songs for particular album i would use this:
		//public string Username { get; set; }

		[BindProperty]
		public InputFormAlbumModel InputAlbum { get; set; }
		
		// Added a property for handling file upload
		[BindProperty]
		[Display(Name = "Album Cover"), Required]
		public IFormFile AlbumCover { get; set; }

		public FormPageModel(SongManager songManager, ArtistManager artistManager, IWebHostEnvironment webHostEnvironment)
		{
			_webHostEnvironment = webHostEnvironment;
			_songManager = songManager;
			_artistManager = artistManager;
		}

		private void LoadSongs()
		{
			//if i had songs for particular album i would use this:
			//var userClaim = User.Claims;
			//Username = userClaim.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
			List<Song> songs = _songManager.LoadSongsFromDataBase();
			Songs = new List<SongModel>();

			foreach (var song in songs)
			{
				Songs.Add(new SongModel(song.SongID, song.Title, song.ArtistID, song.Date, song.RunTime, song.Genre));
			}
		}

		private void LoadArtists()
		{
			Artists = _artistManager.LoadArtistFromDB().ToList();
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

        public void OnGet()
		{
			LoadSongs();
			LoadArtists();
			LoadGenres();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			//if (!ModelState.IsValid)
			//{
			//	LoadArtists();
			//	return Page();
			//}
			try 
			{
				if (AlbumCover != null)
				{
					InputAlbum.AlbumCoverName = AlbumCover.FileName;
					InputAlbum.AlbumCoverContentType = AlbumCover.ContentType;
					
					using (var memorystream = new MemoryStream())
					{
						await AlbumCover.CopyToAsync(memorystream);
						InputAlbum.AlbumCoverData = memorystream.ToArray();
					}
				}
				//saves album to the database

				Album newAlbum = new Album(
						InputAlbum.ArtistID,
						InputAlbum.Title,
						InputAlbum.Date,
						InputAlbum.RunTime,
						(genreType)Enum.Parse(typeof(genreType), InputAlbum.Genre.ToString()),
						InputAlbum.AlbumCoverName,
						InputAlbum.AlbumCoverData,
						InputAlbum.AlbumCoverContentType
						);

				var result = _albumManager.Add(newAlbum);

				if (result.Success)
				{
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
								ModelState.AddModelError($"Album.{errorKey.Key}", errorValue);
							}
						}
					}
					else
					{
						ModelState.AddModelError("", result.Message);
					}
					return Page();
				}
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("", $"Something went wrong!" + ex.Message);

				return Page();
			}
		}
	}

}

