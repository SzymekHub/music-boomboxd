using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class FormPageModel: PageModel
    {
        private readonly ILogger<FormPageModel> _logger;

        public FormPageModel(ILogger<FormPageModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            string title = Request.Form["title"];
            string artist = Request.Form["artist"];
            string date = Request.Form["date"];

            
        }
    }

}
