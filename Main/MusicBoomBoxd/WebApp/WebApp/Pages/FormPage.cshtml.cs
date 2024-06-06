using Infrastructure;
using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;


namespace WebApp.Pages
{
    [Authorize]
    public class FormPageModel : PageModel
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly SongManager _songManager;

        public List<SongModel> Songs { get; private set; }
        public string Username { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Title is required.")]
            public string Title { get; set; }

            [Required(ErrorMessage = "Artist is required.")]
            public string Artist { get; set; }

            [Required(ErrorMessage = "Date is required.")]
            [DataType(DataType.Date)]
            public DateTime Date { get; set; }

            [Required(ErrorMessage = "Genre is required.")]
            public string Genre { get; set; }

            [Required(ErrorMessage = "Album cover is required.")]
            [Display(Name = "Album Cover")]
            public IFormFile AlbumCover { get; set; }
        }

        public FormPageModel(SongManager songManager, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _songManager = songManager;
        }

        private void LoadSongs()
        {
            var userClaim = User.Claims;
            Username = userClaim.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            List<Song> songs = _songManager.LoadSongsFromDataBase();
            Songs = new List<SongModel>();

            foreach (var song in songs)
            {
                Songs.Add(new SongModel(song.SongID, song.Title, song.ArtistID, song.Date, song.RunTime, song.Genre));
            }
        }

        public void OnGet()
        {
            LoadSongs();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Input.AlbumCover != null && Input.AlbumCover.Length > 0)
            {
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(Input.AlbumCover.FileName);
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    Input.AlbumCover.CopyTo(stream);
                }
                //can save the file path to your database or use it as needed.
            }

            // Redirect to the Home page
            return RedirectToPage("/HomePage", new { title = Input.Title, artist = Input.Artist, date = Input.Date.ToString("yyyy-MM-dd"), genre = Input.Genre });

        }
    }

}

