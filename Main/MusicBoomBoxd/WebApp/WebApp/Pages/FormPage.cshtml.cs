using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;


namespace WebApp.Pages
{
    public class FormPageModel : PageModel
    {
        private readonly ILogger<FormPageModel> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

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

        public FormPageModel(ILogger<FormPageModel> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }

        public void OnGet()
        {
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
