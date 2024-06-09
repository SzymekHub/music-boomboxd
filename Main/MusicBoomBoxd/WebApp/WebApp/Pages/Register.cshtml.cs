using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Infrastructure;

namespace WebApp.Pages
{
	public class RegisterModel : PageModel
	{
		public readonly UserManager _userManager;

		private IWebHostEnvironment _environment;

		public List<SelectListItem> GenreOptions { get; set; }

		[BindProperty]
		public RegisterUser RegiUser { get; set; }

		[BindProperty]
		[Display(Name = "Profile Picture"), Required]
		public IFormFile ProfilePicture { get; set; }

		public RegisterModel(IWebHostEnvironment environment)
		{
			IUserRepository iuserRep = new UserRepository();
            IProfileRepository iprofRep = new ProfileRepository();
            IValidateUser ivalUser = new ValidateUser(iuserRep); 
            _userManager = new UserManager(iuserRep, iprofRep, ivalUser);
            _environment = environment;
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
			LoadGenres();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			LoadGenres();

			if (ProfilePicture != null)
			{
				RegiUser.ProfilePictureName = ProfilePicture.FileName;
				RegiUser.ProfilePictureContentType = ProfilePicture.ContentType;

				using (var memoryStream = new MemoryStream())
				{
					await ProfilePicture.CopyToAsync(memoryStream);
					RegiUser.ProfilePictureData = memoryStream.ToArray();
				}
			}

			if (!ModelState.IsValid)
			{
				return Page();
			}

			User newUser = new User(
				RegiUser.Name,
				RegiUser.Password,
				RegiUser.Email,
				userType.Regular,
				RegiUser.Birthday,
				(genreType)Enum.Parse(typeof(genreType), RegiUser.FavGenre.ToString()),
				RegiUser.ProfilePictureName,
				RegiUser.ProfilePictureData,
				RegiUser.ProfilePictureContentType
			);

			var result = _userManager.AddWEB(newUser);

			if (result.Success)
			{
				return RedirectToPage("/Index");
			}
			else
			{
				if (result.Errors != null)
				{
					foreach (var errorKey in result.Errors)
					{
						foreach (var errorValue in errorKey.Value)
						{
							ModelState.AddModelError($"User.{errorKey.Key}", errorValue);
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
	}
}
