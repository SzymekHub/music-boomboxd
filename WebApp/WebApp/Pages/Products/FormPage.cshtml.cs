using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Products
{
    public class FormPageModel : PageModel
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
        }
    }

}
