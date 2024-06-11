using Infrastructure;
using Logic;

namespace WinFormsApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
			IUserRepository userRepository = new UserRepository();
            IProfileRepository profileRepository = new ProfileRepository();
            IAlbumRepository albumRepository = new AlbumRepository();
            IArtistRepository artistRepository = new ArtistRepository();
            ISongRepository songRepository = new SongRepository();
            IValidateAlbum validateAlbum = new ValidateAlbum(albumRepository);
            IValidateSong validateSong = new ValidateSong(songRepository);
            IValidateUser validateUser = new ValidateUser(userRepository);
            IPasswordHasher passwordHasher = new PasswordHasher();

			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();
            Application.Run(new Login_Form(passwordHasher, userRepository, validateUser, profileRepository, artistRepository, albumRepository, songRepository, validateAlbum, validateSong));
        }
    }
}