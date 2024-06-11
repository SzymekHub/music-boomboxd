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
    public class FormPageModel : PageModel
    {
        private readonly AlbumManager _albumManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly SongManager _songManager;
        private readonly ArtistManager _artistManager;

        public List<SelectListItem> GenreOptions { get; set; }
        public List<SongModel> Songs { get; private set; }
        public List<Artist> Artists { get; private set; }
        public string Username { get; set; }

        [BindProperty]
        public InputFormAlbumModel InputAlbum { get; set; }

        // Added a property for handling file upload
        [BindProperty]
        [Display(Name = "Album Cover"), Required]
        public IFormFile AlbumCover { get; set; }

        // Property to store selected song IDs
        [BindProperty]
        public string SelectedSongIDs { get; set; }

        public FormPageModel(AlbumManager albumManager, SongManager songManager, ArtistManager artistManager, IWebHostEnvironment webHostEnvironment)
        {
            _albumManager = albumManager;
            _webHostEnvironment = webHostEnvironment;
            _songManager = songManager;
            _artistManager = artistManager;
            Artists = new List<Artist>();
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

        private void LoadSongs()
        {
            var userClaim = User.Claims;
            Username = userClaim.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            List<Song> songs = _songManager.LoadSongsFromDataBase();
            Songs = new List<SongModel>();

            foreach (var song in songs)
            {
                Songs.Add(new SongModel(song.SongID, song.Title, song.Artist.Name, song.Date, song.RunTime, song.Genre));
            }
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
            LoadSongs();
            LoadArtists();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            LoadGenres();
            LoadSongs();
            LoadArtists();

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

            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Save album to the database
            Album newAlbum = new Album(
                InputAlbum.Artist,
                InputAlbum.Title,
                InputAlbum.Date,
                InputAlbum.RunTime,
                (genreType)Enum.Parse(typeof(genreType), InputAlbum.Genre.ToString()),
                InputAlbum.AlbumCoverName,
                InputAlbum.AlbumCoverData,
                InputAlbum.AlbumCoverContentType
            );

            var result = _albumManager.AddWEB(newAlbum);

            if (result.Success)
            {
                // Save selected songs to the album
                var selectedSongIDs = SelectedSongIDs.Split(',').Select(int.Parse).ToList();
                int existingalbumID = _albumManager.GetAlbumIDByAlbumTitle(InputAlbum.Title);

                var resultAddSongs = _albumManager.SaveSongsInAlbums(existingalbumID, selectedSongIDs);

                if (resultAddSongs.Success)
                {
                    return RedirectToPage("/HomePage");
                }
                else
                {
                    ModelState.AddModelError("", resultAddSongs.Message);
                }
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
            }

			//Returns a page if any of the above conditions are not met
			// Display error message if album already Exists for this artist is incorrect
			ViewData["ErrorMessage"] = "This album already exists for this artist";
			return Page();
        }

    }
}



