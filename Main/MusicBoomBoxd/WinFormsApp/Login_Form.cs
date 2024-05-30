using Infrastructure;
using Logic;
using System.Collections.Generic;

namespace WinFormsApp
{
    public partial class Login_Form : Form
    {
        private const string AdminUsername = "Admin";
        private const string AdminPassword = "p";
        public UserManager userManager { get; }
        public AlbumManager albumManager { get; }
        public SongManager songManager { get; }

        public ArtistManager artistManager { get; } 

        private List<Artist> artistList;


        public Login_Form()
        {
            InitializeComponent();
            //For users
            #region Users
            UserRepository userRep = new UserRepository();
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

            albumManager =  new AlbumManager(albumRep, IalbumRep);
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
            string enteredUsername = txtUsername.Text;
            string enteredPassword = txtPassword.Text;

            if (enteredUsername == AdminUsername && enteredPassword == AdminPassword)
            {
                DashBoard_Form dash_form = new DashBoard_Form(AdminUsername, userManager, artistManager, albumManager, songManager, artistList);
                dash_form.Owner = this;
                dash_form.Text = "Hello" + AdminUsername;
                this.Visible = false;
                dash_form.Show();
                ClearControls();
            }
            else if (string.IsNullOrWhiteSpace(enteredUsername) || string.IsNullOrWhiteSpace(enteredPassword)) 
            {
                tsslblLoginForm.Text = "The Username and Password cannot be empty";
            }
            else
            {
                tsslblLoginForm.Text = "Looks like the Username or Password is incorrect";
            }
        }

        public void ClearControls()
        {
            txtPassword.Clear();
            txtUsername.Clear();
        }
    }
}
