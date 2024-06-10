using Infrastructure;
using Logic;
using System.Collections.Generic;

namespace WinFormsApp
{
    public partial class Login_Form : Form
    {
        private readonly IUserRepository userRep;
        private readonly UserManager userManager;
        private readonly IValidateUser valUser;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IProfileRepository iprofRep;

        private readonly IAlbumRepository albumRep;
        private readonly IValidateAlbum valAlbum;
        private readonly AlbumManager albumManager;

        private readonly ISongRepository songRep;
		private readonly IValidateSong valSong;
		private readonly SongManager songManager;

        private readonly IArtistRepository artistRep;
        private readonly ArtistManager artistManager;
        private readonly List<Artist> artistList;


        public Login_Form()
        {
            InitializeComponent();
            //For users
            #region Users
            userRep = new UserRepository();
            _passwordHasher = new PasswordHasher();

            userManager = new UserManager(userRep, iprofRep, valUser, _passwordHasher);
            userManager.LoadUsersFromDataBase();
            #endregion

            //for artists
            #region Artists
            artistRep = new ArtistRepository();

            artistManager = new ArtistManager(artistRep);
            artistManager.LoadArtistFromDB();
            #endregion

            //For Albums
            #region Albums
            albumRep = new AlbumRepository();

            albumManager = new AlbumManager(albumRep,valAlbum);
            albumManager.LoadAlbumsFromDatabase();
            #endregion

            //For Songs
            #region Songs
            songRep = new SongRepository();

            songManager = new SongManager(songRep, valSong);
            songManager.LoadSongsFromDataBase();
            #endregion

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username))
            {
                tsslblLoginForm.Text = "The Username cannot be empty";
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                tsslblLoginForm.Text = "The Password cannot be empty";
            }

            User user = userManager.GetUserByUsernameFromDb(username);
            if (user == null)
            {
                tsslblLoginForm.Text = "This user was not found";
                ClearControls();
                return;
            }

            if (!_passwordHasher.VerifyPassword(password, user.Password))
            {
                tsslblLoginForm.Text = "The password is incorrect";
                ClearControls();
                return;
            }

            if (user.UserType == userType.Admin)
            {
                DashBoard_Form dash_form = new DashBoard_Form(user.Username, userManager, artistManager, albumManager, songManager, artistList);
                dash_form.Owner = this;
                dash_form.Text = "Hello" + txtUsername.Text;
                this.Visible = false;
                dash_form.Show();
                ClearControls();
            }
            else
            {
                tsslblLoginForm.Text = "Looks like you do not have access to this form. It is admin only :(";
            }

        }

        public void ClearControls()
        {
            txtPassword.Clear();
            txtUsername.Clear();
        }
    }
}
