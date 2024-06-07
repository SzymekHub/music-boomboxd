using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class HomePageModel : PageModel
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Date {  get; set; }
        public string Genre { get; set; }


        public HomePageModel()
        {
        }

        public void OnGet(string title, string artist, string date, string genre)
        {
            Title = title;
            Artist = artist;
            Date = date;
            Genre = genre;
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("FormPage");
        }
    }
}
