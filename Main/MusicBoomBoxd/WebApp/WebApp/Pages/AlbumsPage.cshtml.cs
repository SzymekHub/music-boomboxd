using Infrastructure;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;


namespace WebApp.Pages
{
    [Authorize]
    public class AlbumsPageModel : PageModel
    {
        
    }
}