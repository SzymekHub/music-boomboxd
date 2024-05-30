using Infrastructure;
using Logic;
using System.Collections.Generic;

namespace WinFormsApp
{
    public partial class Login_Form : Form
    {
        private readonly UserRepository userRep;
        private readonly UserManager userManager;
        private readonly AlbumManager albumManager;
        private readonly SongManager songManager;
        private readonly ArtistManager artistManager;
        private readonly List<Artist> artistList;


        public Login_Form()
        {
            InitializeComponent();
            //For users
            #region Users
            userRep = new UserRepository();
            IUserRepository IuserRep = userRep;

            userManager = new UserManager(userRep, IuserRep);
            userManager.LoadUsersFromDataBase();
            #endregion

            //for artists
            #region Artists
            IArtistRepository iartRep = new ArtistRepository();

            artistManager = new ArtistManager(iartRep);
            artistManager.LoadArtistFromDB();
            #endregion

            //For Albums
            #region Albums
            AlbumRepository albumRep = new AlbumRepository();
            IAlbumRepository IalbumRep = albumRep;

            albumManager = new AlbumManager(albumRep, IalbumRep);
            albumManager.LoadAlbumsFromDatabase();
            #endregion

            //For Songs
            #region Songs
            SongRepository songRep = new SongRepository();
            ISongRepository IsongRep = songRep;

            songManager = new SongManager(songRep, IsongRep);
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
            else
            {
                tsslblLoginForm.Text = "Looks like the Username or Password is incorrect";
            }

            List<UserDTO> users = userRep.GetRecentUser(1000);
            if (users == null)
            {
                tsslblLoginForm.Text = "Unable to connect to the database";
                return;
            }

            UserDTO user = users.Find(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
            if (user == null)
            {
                tsslblLoginForm.Text = "This user was not found";
                ClearControls();
                return;
            }

            if (!PasswordHasher.VerifyPassword(password, user.Password))
            {
                tsslblLoginForm.Text = "The password is incorrect";
                ClearControls();
                return;
            }

            DashBoard_Form dash_form = new DashBoard_Form(user.Username, userManager, artistManager, albumManager, songManager, artistList);
            dash_form.Owner = this;
            dash_form.Text = "Hello" + txtUsername.Text;
            this.Visible = false;
            dash_form.Show();
            ClearControls();

        }

        public void ClearControls()
        {
            txtPassword.Clear();
            txtUsername.Clear();
        }
    }
}
