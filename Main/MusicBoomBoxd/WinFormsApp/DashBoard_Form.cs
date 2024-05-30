using Infrastructure;
using Logic;


namespace WinFormsApp
{
    public partial class DashBoard_Form : Form
    {

        //for the User tab
        private static UserManager userManager;
        private static List<User> userList = new List<User>();
        
        //for the artist tab
        private static ArtistManager artistManager;
        private List<Artist> artists;


        //for the Album tab
        private static AlbumManager albumManager;
        private static List<Album> albumsList = new List<Album>();

        //For the Song tab
        private static SongManager songManager;
        private static List<Song> songList = new List<Song>();

        public DashBoard_Form(string adminUsername, UserManager um, ArtistManager arm, AlbumManager am, SongManager sm, List<Artist> artistList)
        {
            InitializeComponent();

            //This is for the user page
            userManager = um;
            SetUpDataGridViewUsers();
            PopulateUsers();

            //This is for the Artist page
            artistManager = arm;
            SetUpDataGridViewArtist();
            PopulateArtist();


            //This is for the album page
            albumManager = am;
            artists = artistList;
            SetUpDataGridViewAlbums();
            PopulateAlbums();

            //This is for the song page
            songManager = sm;
            SetUpDataGridViewSongs();
            PopulateSongs();

            lblHello.Text = $"Hello, {adminUsername}";
            tsslblDashBoardForm.Text = $"Hello, {adminUsername}";

            #region Tags
            //Tags
            btnReviews.Tag = "Reviews";
            btnUsers.Tag = "Users";
            btnArtists.Tag = "Artists";
            btnSongs.Tag = "Songs";
            btnAlbums.Tag = "Albums";
            btnLogOut.Tag = "LogOut";
            #endregion

            this.StartPosition = FormStartPosition.CenterScreen;
            this.artists = artists;
        }

        private void DashBoard_Form_Load(object sender, EventArgs e)
        {
            tcDashBoard.ItemSize = new Size(0, 1);
            tcDashBoard.SizeMode = TabSizeMode.Fixed;

            // This will wire up the event handler to all buttons
            foreach (Control control in Controls)
            {
                if (control is Button button)
                {
                    if (button.Tag.ToString() != "LogOut")
                    {
                        button.Click += Button_Click;
                    }
                    else
                    {
                        button.Click += ButtonLogOut_Click;
                    }
                }
            }
        }

        private void DashBoard_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Visible = true;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                // This will determine the target tab page index based on the button clicked
                int targetIndex = -1;
                switch (clickedButton.Tag.ToString())
                {
                    case "Users":
                        targetIndex = 0;
                        break;
                    case "Songs":
                        targetIndex = 1;
                        break;
                    case "Albums":
                        targetIndex = 2;
                        break;
                    case "Reviews":
                        targetIndex = 3;
                        break;
                    case "Artists":
                        targetIndex = 4;
                        break;
                }

                // Switch to the target tab page
                if (targetIndex != -1)
                {
                    tcDashBoard.SelectedIndex = targetIndex;
                }
            }
        }

        private void ButtonLogOut_Click(object sender, EventArgs e)
        {
            if (Owner != null)
            {
                Owner.Visible = true;
            }
            this.Close();
        }

        #region Users
        private void SetUpDataGridViewUsers()
        {
            // Set DataGridView properties
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.AllowUserToAddRows = false;

            dgvUsers.Columns.Add("Username", "Username");
            dgvUsers.Columns["Username"].DataPropertyName = "Username";

            dgvUsers.Columns.Add("Email", "Email");
            dgvUsers.Columns["Email"].DataPropertyName = "Email";

            dgvUsers.Columns.Add("UserType", "UserType");
            dgvUsers.Columns["UserType"].DataPropertyName = "UserType";

            dgvUsers.Columns.Add("Birthday", "Birthday");
            dgvUsers.Columns["Birthday"].DataPropertyName = "Birthday";

            dgvUsers.Columns.Add("ProfilePictureName", "ProfilePictureName");
            dgvUsers.Columns["ProfilePictureName"].DataPropertyName = "ProfilePictureName";

            // Bind the list of Users from UserManager to the DataGridView
            dgvUsers.DataSource = userManager.GetArray();
        }

        private void PopulateUsers()
        {
            //This will populate the form with exisiting users
            dgvUsers.DataSource = userManager.GetArray();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            // Open the NewUsers_Form
            using (NewUsers_Form addUsersForm = new NewUsers_Form(userManager))
            {
                // Show the addUsersForm
                if (addUsersForm.ShowDialog() == DialogResult.OK)
                {   // Add the new user to the UserManager
                    userManager.LoadUsersFromDataBase();

                    // Update the DataGridView
                    dgvUsers.DataSource = userManager.GetArray();

                }
            }
        }
        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                // Get the selected User
                User selectedUser = dgvUsers.SelectedRows[0].DataBoundItem as User;

                // Open the NewUser_Form with the selected Users's information
                using (NewUsers_Form addUserForm = new NewUsers_Form(userManager, selectedUser))
                {
                    if (addUserForm.ShowDialog() == DialogResult.OK)
                    {
                        // Update the User with the modified information
                        User updatedUser = addUserForm.GetUpdatedUser();
                        if (updatedUser != null)
                        {
                            userManager.Update(updatedUser, selectedUser);
                            dgvUsers.DataSource = userManager.GetArray();
                        }
                    }
                }
            }
            else
            {
                tsslblDashBoardForm.Text = "Please select an User to update.";
            }
        }

        private void btnViewUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                // This gets the selected User
                User selectedUser = dgvUsers.SelectedRows[0].DataBoundItem as User;

                // Opens the NewUser_Form with the selected Users's information
                using (NewUsers_Form addUserForm = new NewUsers_Form(userManager, selectedUser, true))
                {
                    if (addUserForm.ShowDialog() == DialogResult.OK)
                    {
                        // Update the User with the modified information
                        User updatedUser = addUserForm.GetUpdatedUser();
                        if (updatedUser != null)
                        {
                            userManager.Update(updatedUser, selectedUser);
                            dgvUsers.DataSource = userManager.GetArray();
                        }
                    }
                }
            }
            else
            {
                tsslblDashBoardForm.Text = "Please select an user to view.";
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            // This chekcs if a row is selected
            if (dgvUsers.SelectedRows.Count > 0)
            {
                // Get the selected User
                User selectedUser = dgvUsers.SelectedRows[0].DataBoundItem as User;

                DialogResult result = MessageBox.Show("Are you sure you want to delte this user?", "Delete User", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    // This removes the selected user from the userManager
                    userManager.Remove(selectedUser);

                    // This updates the DataGridView
                    dgvUsers.DataSource = userManager.GetArray();
                }

            }
            else
            {
                tsslblDashBoardForm.Text = "Please select an User to delete.";
            }
        }

        #endregion

        #region Artists
        private void SetUpDataGridViewArtist()
        {
            // Set DataGridView properties
            dgvArtists.AutoGenerateColumns = false;
            dgvArtists.AllowUserToAddRows = false;

            dgvArtists.Columns.Add("Name", "Name");
            dgvArtists.Columns["Name"].DataPropertyName = "Name";

            dgvArtists.Columns.Add("ArtistPictureName", "ArtistPictureName");
            dgvArtists.Columns["ArtistPictureName"].DataPropertyName = "ArtistPictureName";

            // Bind the list of Users from UserManager to the DataGridView
            dgvArtists.DataSource = artistManager.LoadArtistFromDB();
        }

        private void PopulateArtist()
        {
            //This will populate the form with exisiting users
            dgvArtists.DataSource = artistManager.LoadArtistFromDB();
        }

        private void btnAddArtist_Click(object sender, EventArgs e)
        {
            // Open the NewUsers_Form
            using (NewArtist_Form addArtistForm = new NewArtist_Form(artistManager))
            {
                // Show the addUsersForm
                if (addArtistForm.ShowDialog() == DialogResult.OK)
                {   // Add the new user to the UserManager
                    artistManager.LoadArtistFromDB();

                    // Update the DataGridView
                    dgvArtists.DataSource = artistManager.LoadArtistFromDB();

                }
            }
        }
        private void btnUpdateArtist_Click(object sender, EventArgs e)
        {
            if (dgvArtists.SelectedRows.Count > 0)
            {
                // Get the selected User
                Artist selectedArtist = dgvArtists.SelectedRows[0].DataBoundItem as Artist;

                // Open the NewUser_Form with the selected Users's information
                using (NewArtist_Form addArtistForm = new NewArtist_Form(artistManager, selectedArtist))
                {
                    if (addArtistForm.ShowDialog() == DialogResult.OK)
                    {
                        // Update the User with the modified information
                        Artist updatedArtist = addArtistForm.GetUpdatedArtist();
                        if (updatedArtist != null)
                        {
                            artistManager.Update(updatedArtist);
                            dgvArtists.DataSource = artistManager.LoadArtistFromDB();
                        }
                    }
                }
            }
            else
            {
                tsslblDashBoardForm.Text = "Please select an Artist to update.";
            }
        }

        private void btnViewArtist_Click(object sender, EventArgs e)
        {
            if (dgvArtists.SelectedRows.Count > 0)
            {
                // This gets the selected User
                Artist selectedArtist = dgvArtists.SelectedRows[0].DataBoundItem as Artist;

                // Opens the NewUser_Form with the selected Users's information
                using (NewArtist_Form addArtistForm = new NewArtist_Form(artistManager, selectedArtist, true))
                {
                    if (addArtistForm.ShowDialog() == DialogResult.OK)
                    {
                        // Update the User with the modified information
                        Artist updatedArtist = addArtistForm.GetUpdatedArtist();
                        if (updatedArtist != null)
                        {
                            artistManager.Update(updatedArtist);
                            dgvArtists.DataSource = artistManager.LoadArtistFromDB();
                        }
                    }
                }
            }
            else
            {
                tsslblDashBoardForm.Text = "Please select an Artist to view.";
            }
        }

        private void btnDeleteArtist_Click(object sender, EventArgs e)
        {
            // This chekcs if a row is selected
            if (dgvArtists.SelectedRows.Count > 0)
            {
                // Get the selected User
                Artist selectedArtist = dgvArtists.SelectedRows[0].DataBoundItem as Artist;

                DialogResult result = MessageBox.Show("Are you sure you want to delte this artist?", "Delete Artist", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    // This removes the selected user from the userManager
                    artistManager.Delete(selectedArtist);

                    // This updates the DataGridView
                    dgvArtists.DataSource = artistManager.LoadArtistFromDB();
                }

            }
            else
            {
                tsslblDashBoardForm.Text = "Please select an Artist to delete.";
            }
        }
        #endregion

        #region Songs
        private void SetUpDataGridViewSongs()
        {
            // Set DataGridView properties
            dgvSongs.AutoGenerateColumns = false;
            dgvSongs.AllowUserToAddRows = false;

            dgvSongs.Columns.Add("Title", "Title");
            dgvSongs.Columns["Title"].DataPropertyName = "Title";

            dgvSongs.Columns.Add("ArtistID", "ArtistID");
            dgvSongs.Columns["ArtistID"].DataPropertyName = "ArtistID";
            dgvSongs.Columns["ArtistID"].Visible = false;
            dgvSongs.Columns.Add("Artist", "Artist");
            dgvSongs.Columns["Artist"].DataPropertyName = "Artist";

            dgvSongs.Columns.Add("Genre", "Genre");
            dgvSongs.Columns["Genre"].DataPropertyName = "Genre";

            dgvSongs.Columns.Add("Date", "Date");
            dgvSongs.Columns["Date"].DataPropertyName = "Date";

            dgvSongs.Columns.Add("SongCoverName", "SongCoverName");
            dgvSongs.Columns["SongCoverName"].DataPropertyName = "SongCoverName";

            PopulateSongs();
        }

        private void PopulateSongs()
        {
            //This will populate the form with exisiting Songs
            dgvSongs.DataSource = songManager.GetArray();

            foreach (DataGridViewRow rows in dgvSongs.Rows)
            {
                int artistID = (int)rows.Cells["ArtistID"].Value;

                var artists = artistManager.LoadArtistFromDB().Where(a => a.ArtistID == artistID);

                rows.Cells["Artist"].Value = artists.First();
            }
        }

        private void btnAddSong_Click(object sender, EventArgs e)
        {
            // Open the NewSong_Form
            using (NewSong_Form addSongForm = new NewSong_Form(songManager, artistManager))
            {
                // Show the addSongForm
                if (addSongForm.ShowDialog() == DialogResult.OK)
                {
                    // Add the new employee to the SongManager
                    songManager.LoadSongsFromDataBase();

                    // Update the DataGridView
                    PopulateSongs();

                }
            }
        }
        private void btnUpdateSong_Click(object sender, EventArgs e)
        {
            if (dgvSongs.SelectedRows.Count > 0)
            {
                // Get the selected Song
                Song selectedSong = dgvSongs.SelectedRows[0].DataBoundItem as Song;

                // Open the NewSong_Form with the selected Songs's information
                using (NewSong_Form addSongForm = new NewSong_Form(songManager, artistManager, selectedSong))
                {
                    if (addSongForm.ShowDialog() == DialogResult.OK)
                    {
                        // Update the Song with the modified information
                        Song updatedSong = addSongForm.GetUpdatedSong();
                        if (updatedSong != null)
                        {
                            songManager.Update(updatedSong, selectedSong);
                            PopulateSongs();
                        }
                    }
                }
            }
            else
            {
                tsslblDashBoardForm.Text = "Please select an Song to update.";
            }
        }

        private void btnViewSong_Click(object sender, EventArgs e)
        {
            if (dgvSongs.SelectedRows.Count > 0)
            {
                // This gets the selected Song
                Song selectedSong = dgvSongs.SelectedRows[0].DataBoundItem as Song;

                // Opens the NewSong_Form with the selected Songs's information
                using (NewSong_Form addSongForm = new NewSong_Form(songManager, artistManager, selectedSong, true))
                {
                    if (addSongForm.ShowDialog() == DialogResult.OK)
                    {
                        // Update the Song with the modified information
                        Song updatedSong = addSongForm.GetUpdatedSong();
                        if (updatedSong != null)
                        {
                            songManager.Update(updatedSong, selectedSong);
                            PopulateSongs();
                        }
                    }
                }
            }
            else
            {
                tsslblDashBoardForm.Text = "Please select an Song to view.";
            }
        }

        private void btnDeleteSong_Click(object sender, EventArgs e)
        {
            // This chekcs if a row is selected
            if (dgvSongs.SelectedRows.Count > 0)
            {
                // Get the selected Song
                Song selectedSong = dgvSongs.SelectedRows[0].DataBoundItem as Song;

                DialogResult result = MessageBox.Show("Are you sure you want to delte this Song?", "Delete Song", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    // This removes the selected song from the userManager
                    songManager.Remove(selectedSong);

                    PopulateSongs();
                }
            }
            else
            {
                tsslblDashBoardForm.Text = "Please select an Song to delete.";
            }
        }
        #endregion

        #region Albums

        private void SetUpDataGridViewAlbums()
        {
            // Set DataGridView properties
            dgvAlbums.AutoGenerateColumns = false;
            dgvAlbums.AllowUserToAddRows = false;

            dgvAlbums.Columns.Add("Title", "Title");
            dgvAlbums.Columns["Title"].DataPropertyName = "Title";

            dgvAlbums.Columns.Add("ArtistID", "ArtistID");
            dgvAlbums.Columns["ArtistID"].DataPropertyName = "ArtistID";
            dgvAlbums.Columns["ArtistID"].Visible = false;
            dgvAlbums.Columns.Add("Artist", "Artist");
            dgvAlbums.Columns["Artist"].DataPropertyName = "Artist";

            dgvAlbums.Columns.Add("Genre", "Genre");
            dgvAlbums.Columns["Genre"].DataPropertyName = "Genre";

            dgvAlbums.Columns.Add("Date", "Date");
            dgvAlbums.Columns["Date"].DataPropertyName = "Date";

            dgvAlbums.Columns.Add("AlbumCoverName", "AlbumCoverName");
            dgvAlbums.Columns["AlbumCoverName"].DataPropertyName = "AlbumCoverName";
            
            PopulateAlbums();
        }

        private void PopulateAlbums()
        {
            //This will populate the form with exisiting albums
            dgvAlbums.DataSource = albumManager.GetArray();

            foreach (DataGridViewRow row in dgvAlbums.Rows)
            {
                int artistID = (int)row.Cells["ArtistID"].Value;

                var artists = artistManager.LoadArtistFromDB().Where(a => a.ArtistID == artistID);

                row.Cells["Artist"].Value = artists.First();
            }
        }

        private void bntAddAlbum_Click(object sender, EventArgs e)
        {
            // Open the NewAlbum_Form
            using (NewAlbum_Form addAlbumForm = new NewAlbum_Form(albumManager, artistManager))
            {
                // Show the addAlbumForm
                if (addAlbumForm.ShowDialog() == DialogResult.OK)
                {
                    // Add the new employee to the albumManager
                    albumManager.LoadAlbumsFromDatabase();

                    // Update the DataGridView
                    PopulateAlbums();

                }
            }
        }

        private void btnUpdateAlbum_Click(object sender, EventArgs e)
        {
            if (dgvAlbums.SelectedRows.Count > 0)
            {
                // Get the selected album
                Album selectedAlbum = dgvAlbums.SelectedRows[0].DataBoundItem as Album;
                // Open the NewAlbum_Form with the selected albums's information
                using (NewAlbum_Form addAlbumForm = new NewAlbum_Form(albumManager, artistManager,selectedAlbum))
                {
                    if (addAlbumForm.ShowDialog() == DialogResult.OK)
                    {
                        // Update the Album with the modified information
                        Album updatedAlbum = addAlbumForm.GetUpdatedAlbum();
                        if (updatedAlbum != null)
                        {
                            albumManager.Update(updatedAlbum, selectedAlbum);
                            PopulateAlbums();
                        }
                    }
                }
            }
            else
            {
                tsslblDashBoardForm.Text = "Please select an album to update.";
            }
        }

        private void btnViewAlbum_Click(object sender, EventArgs e)
        {
            if (dgvAlbums.SelectedRows.Count > 0)
            {
                // This gets the selected album
                Album selectedAlbum = dgvAlbums.SelectedRows[0].DataBoundItem as Album;

                // Opens the NewAlbum_Form with the selected albums's information
                using (NewAlbum_Form addAlbumForm = new NewAlbum_Form(albumManager, artistManager, selectedAlbum, true))
                {
                    if (addAlbumForm.ShowDialog() == DialogResult.OK)
                {
                        // Update the album with the modified information
                        Album updatedAlbum = addAlbumForm.GetUpdatedAlbum();
                        if (updatedAlbum != null)
                    {
                            albumManager.Update(updatedAlbum, selectedAlbum);
                            PopulateAlbums();
                    }
                    }
                }
            }
            else
            {
                tsslblDashBoardForm.Text = "Please select an album to view.";
            }
        }

        private void btnDeleteAlbum_Click(object sender, EventArgs e)
        {
            // This chekcs if a row is selected
            if (dgvAlbums.SelectedRows.Count > 0)
            {
                // Get the selected album
                Album selectedAlbum = dgvAlbums.SelectedRows[0].DataBoundItem as Album;

                DialogResult result = MessageBox.Show("Are you sure you want to delte this Album?", "Delete Album", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    // This removes the selected Album from the AlbumManager
                    albumManager.Remove(selectedAlbum);

                    // This updates the DataGridView
                    PopulateAlbums();
                }
            }
            else
            {
                tsslblDashBoardForm.Text = "Please select an Album to delete.";
            }
        }
        #endregion
    }
}
