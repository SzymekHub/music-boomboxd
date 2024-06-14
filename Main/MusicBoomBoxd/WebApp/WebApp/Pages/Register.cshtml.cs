using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Infrastructure.DTOs;
using Infrastructure.InterfacesForRepo;
using Infrastructure.Repositories;
using Logic.Algorithms;
using Logic.Interfaces;
using Logic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Pages.Models;

namespace WebApp.Pages
{
    public class RegisterModel : PageModel
	{
		public readonly UserManager _userManager;
        public readonly IPasswordHasher _passwordHasher;
        public readonly IProfileRepository _profileRepository;
        public readonly IUserRepository _userRepository;
        private readonly IValidateUser _validateUsers;

        private IWebHostEnvironment _environment;

		public List<SelectListItem> GenreOptions { get; set; }

		[BindProperty]
		public RegisterUser RegiUser { get; set; }

		[BindProperty]
		[Display(Name = "Profile Picture"), Required]
		public IFormFile ProfilePicture { get; set; }

		public RegisterModel(IPasswordHasher passwordHasher, IUserRepository userRepository, IValidateUser validateUsers, IProfileRepository profileRepository, IWebHostEnvironment environment)
		{
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
            _validateUsers = validateUsers;
            _profileRepository = profileRepository;
            _userManager = new UserManager(passwordHasher, userRepository, validateUsers, profileRepository);
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
