using Infrastructure;
using Logic;

namespace WinFormsApp
{
    public partial class NewUsers_Form : Form
    {
        private List<int> selectedSongIDs = new List<int>();
        private List<int> selectedAlbumIDs = new List<int>();
        private List<int> selectedArtistIDs = new List<int>();
        private bool isNewImageSelected = false;

        public User NewUser { get; private set; }
        private User exisitingUser;
        private UserManager userManager;
        private AlbumManager albumManager;
        private SongManager songManager;
        private ArtistManager artistManager;
        private string selectedImagePath;

        public NewUsers_Form(UserManager um, AlbumManager am, SongManager sm, ArtistManager arm, User user = null, bool view = false)
        {
            userManager = um;
            albumManager = am;
            songManager = sm;
            artistManager = arm;
            InitializeComponent();
            InitializeComboBox();
            exisitingUser = user;

            ClearControls();
            this.StartPosition = FormStartPosition.CenterScreen;

            if (exisitingUser != null)
            {
                FillFormWithUserDetails(exisitingUser);
                //This will load and display the User profile picture
                DisplayProfilePicture(exisitingUser.ProfilePictureData);
            }

            if (view)
            {
                tbNameUser.Enabled = false;
                tbPassword.Visible = false;
                tbEmailUser.Enabled = false;
                dtpUser.Enabled = false;
                cbUserType.Enabled = false;
                cbFavGenre.Enabled = false;
                btnAddPictureAlbum.Enabled = false;
                btnAddUser.Enabled = false;
                cklbAlbumUser.Enabled = false;
                cklbAritstUser.Enabled = false;
                cklbSongsUser.Enabled = false;
                btnAddAlbumUser.Enabled = false;
                btnAddArtistUser.Enabled = false;
                btnAddSongsUser.Enabled = false;
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void btnAddPictureAlbum_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg, *.png)|*.jpg;*.png|All Files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFile = openFileDialog.FileName;

                    // Checks if the selected file has a valid image extension
                    string extension = Path.GetExtension(selectedFile);
                    if (extension != ".jpg" && extension != ".png")
                    {
                        tsslblNewUserForm.Text = $"Please select an image file with .jpg or .png extension.";

                        return;
                    }

                    // Stores the selected image path
                    selectedImagePath = selectedFile;
                    isNewImageSelected = true;

                    // This will load and display the image if needed
                    SelectedProfileUser.Image = Image.FromFile(selectedImagePath);
                }
            }
        }
        private bool CheckLimitExceeded(List<int> selectedIDs, int limit, string itemType)
        {
            if (selectedIDs.Count > limit)
            {
                tsslblNewUserForm.Text = $"You can only select up to {limit} {itemType}.";
                return true;
            }
            return false;
        }

        //Adding an artist
        #region Artist
        private void btnAddArtistUser_Click(object sender, EventArgs e)
        {
            // Get the selected User
            User selectedUser = GetUpdatedUser();

            if (ValidateInput())
            {
                // Gets the selected artists from the checkedListBox
                List<int> selectedArtistIDs = new List<int>();
                foreach (var item in cklbAritstUser.CheckedItems)
                {
                    selectedArtistIDs.Add(((Artist)item).ArtistID);
                }

                // Check if limit exceeded
                if (CheckLimitExceeded(selectedArtistIDs, 5, "artists"))
                {
                    return;
                }

                // Calls the method in AlbumManager to save songs in albums
                Result resultAddArtist = userManager.SaveArtistInUsers(selectedUser.UserID, selectedArtistIDs);

                if (resultAddArtist.Success)
                {
                    //DialogResult = DialogResult.OK;
                    tsslblNewUserForm.Text = resultAddArtist.Message;
                }
                else
                {
                    tsslblNewUserForm.Text = resultAddArtist.Message;
                }
            }
        }

        private void btnRemoveArtistUser_Click(object sender, EventArgs e)
        {
            //Get the selected User
            User selectedUser = GetUpdatedUser();

            if (ValidateInput())
            {
                // Gets the selected songs from the checkedListBox
                List<int> selectedArtistIDs = new List<int>();
                foreach (var item in cklbAritstUser.CheckedItems)
                {
                    selectedArtistIDs.Add(((Artist)item).ArtistID);
                }

                // Calls the method in AlbumManager to save songs in albums
                Result resultAddArtist = userManager.RemoveArtistFromUser(selectedUser.UserID, selectedArtistIDs);

                if (resultAddArtist.Success)
                {
                    //DialogResult = DialogResult.OK;
                    tsslblNewUserForm.Text = resultAddArtist.Message;
                }
                else
                {
                    tsslblNewUserForm.Text = resultAddArtist.Message;
                }
            }
        }
        private void tbArtistSearchUser_TextChanged(object sender, EventArgs e)
        {
            FilterArtist(tbArtistSearchUser.Text);
        }

        private void FilterArtist(string searchText)
        {
            List<Artist> allArtists = artistManager.LoadArtistFromDB();
            List<Artist> filteredArtists = allArtists.Where(artist => artist.Name.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            cklbAritstUser.DataSource = filteredArtists;
            cklbAritstUser.DisplayMember = "Title";

            // Reapply the checked state for previously selected songs
            for (int i = 0; i < cklbAritstUser.Items.Count; i++)
            {
                Artist artist = (Artist)cklbAritstUser.Items[i];
                if (selectedArtistIDs.Contains(artist.ArtistID))
                {
                    cklbAritstUser.SetItemChecked(i, true);
                }
            }
        }
        #endregion

        //Adding a Song
        #region Song
        private void btnAddSongsUser_Click(object sender, EventArgs e)
        {
            // Get the selected User
            User selectedUser = GetUpdatedUser();

            if (ValidateInput())
            {
                // Gets the selected songs from the checkedListBox
                List<int> selectedSongIDs = new List<int>();
                foreach (var item in cklbSongsUser.CheckedItems)
                {
                    selectedSongIDs.Add(((Song)item).SongID);
                }

                // Check if limit exceeded
                if (CheckLimitExceeded(selectedSongIDs, 5, "songs"))
                {
                    return;
                }

                // Calls the method in AlbumManager to save songs in albums
                Result resultAddSong = userManager.SaveSongsInUsers(selectedUser.UserID, selectedSongIDs);

                if (resultAddSong.Success)
                {
                    //DialogResult = DialogResult.OK;
                    tsslblNewUserForm.Text = resultAddSong.Message;
                }
                else
                {
                    tsslblNewUserForm.Text = resultAddSong.Message;
                }
            }
        }


        private void btnRemoveSongUser_Click(object sender, EventArgs e)
        {
            //Get the selected User
            User selectedUser = GetUpdatedUser();

            if (ValidateInput())
            {
                // Gets the selected songs from the checkedListBox
                List<int> selectedSongIDs = new List<int>();
                foreach (var item in cklbSongsUser.CheckedItems)
                {
                    selectedSongIDs.Add(((Song)item).SongID);
                }

                // Calls the method in AlbumManager to save songs in albums
                Result resultRemoveSong = userManager.RemoveSongFromUser(selectedUser.UserID, selectedSongIDs);

                if (resultRemoveSong.Success)
                {
                    //DialogResult = DialogResult.OK;
                    tsslblNewUserForm.Text = resultRemoveSong.Message;
                }
                else
                {
                    tsslblNewUserForm.Text = resultRemoveSong.Message;
                }
            }
        }
        private void tbSongsSearch_TextChanged(object sender, EventArgs e)
        {
            FilterSongs(tbSongsSearchUsers.Text);
        }

        private void FilterSongs(string searchText)
        {
            List<Song> allSongs = songManager.LoadSongsFromDataBase();
            List<Song> filteredSongs = allSongs.Where(song => song.Title.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            cklbSongsUser.DataSource = filteredSongs;
            cklbSongsUser.DisplayMember = "Title";

            // Reapply the checked state for previously selected songs
            for (int i = 0; i < cklbSongsUser.Items.Count; i++)
            {
                Song song = (Song)cklbSongsUser.Items[i];
                if (selectedSongIDs.Contains(song.SongID))
                {
                    cklbSongsUser.SetItemChecked(i, true);
                }
            }
        }
        #endregion

        //Adding a Album
        #region Albums

        private void btnAddAlbumUser_Click(object sender, EventArgs e)
        {
            // Get the selected User
            User selectedUser = GetUpdatedUser();

            if (ValidateInput())
            {
                // Gets the selected albums from the checkedListBox
                List<int> selectedAlbumIDs = new List<int>();
                foreach (var item in cklbAlbumUser.CheckedItems)
                {
                    selectedAlbumIDs.Add(((Album)item).AlbumID);
                }

                // Check if limit exceeded
                if (CheckLimitExceeded(selectedAlbumIDs, 5, "albums"))
                {
                    return;
                }

                // Calls the method in AlbumManager to save albums in users
                Result resultAddAlbum = userManager.SaveAlbumInUsers(selectedUser.UserID, selectedAlbumIDs);

                if (resultAddAlbum.Success)
                {
                    //DialogResult = DialogResult.OK;
                    tsslblNewUserForm.Text = resultAddAlbum.Message;
                }
                else
                {
                    tsslblNewUserForm.Text = resultAddAlbum.Message;
                }
            }
        }


        private void btnRemoveAlbumUser_Click(object sender, EventArgs e)
        {
            //Get the selected User
            User selectedUser = GetUpdatedUser();

            if (ValidateInput())
            {
                // Gets the selected albums from the checkedListBox
                List<int> selectedAlbumIDs = new List<int>();
                foreach (var item in cklbAlbumUser.CheckedItems)
                {
                    selectedAlbumIDs.Add(((Album)item).AlbumID);
                }

                // Calls the method in AlbumManager to save albums in users
                Result resultRemoveAlbum = userManager.RemoveAlbumFromUser(selectedUser.UserID, selectedAlbumIDs);

                if (resultRemoveAlbum.Success)
                {
                    //DialogResult = DialogResult.OK;
                    tsslblNewUserForm.Text = resultRemoveAlbum.Message;
                }
                else
                {
                    tsslblNewUserForm.Text = resultRemoveAlbum.Message;
                }
            }
        }

        private void tbAlbumsSearchUser_TextChanged(object sender, EventArgs e)
        {
            FilterAlbums(tbAlbumsSearchUser.Text);
        }

        private void FilterAlbums(string searchText)
        {
            List<Album> allAlbums = albumManager.LoadAlbumsFromDatabase();
            List<Album> filteredAlbums = allAlbums.Where(album => album.Title.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            cklbAlbumUser.DataSource = filteredAlbums;
            cklbAlbumUser.DisplayMember = "Title";

            // Reapply the checked state for previously selected albums
            for (int i = 0; i < cklbAlbumUser.Items.Count; i++)
            {
                Album album = (Album)cklbAlbumUser.Items[i];
                if (selectedAlbumIDs.Contains(album.AlbumID))
                {
                    cklbAlbumUser.SetItemChecked(i, true);
                }
            }
        }
        #endregion

        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                //This gets the file name from the selected image path
                string profilePictureName = isNewImageSelected ? Path.GetFileName(selectedImagePath) : exisitingUser.ProfilePictureName;

                //This gets the content type based on the file extension
                string profilePictureContentType = "";
                string extension = Path.GetExtension(profilePictureName);
                if (extension != null)
                {
                    switch (extension.ToLower())
                    {
                        case ".jpg":
                            profilePictureContentType = "image/jpeg";
                            break;
                        case ".png":
                            profilePictureContentType = "image/png";
                            break;
                        default:
                            tsslblNewUserForm.Text = $"Wrong format!";
                            break;
                    }
                }

                //This reads the selected image file into a byte array
                byte[] profilePictureData = isNewImageSelected ? File.ReadAllBytes(selectedImagePath) : exisitingUser.ProfilePictureData;

                if (exisitingUser == null)
                {
                    //This creates a new User Object with the provided details
                    NewUser = new User(
                       tbNameUser.Text,
                       tbPassword.Text,
                       tbEmailUser.Text,
                       (userType)cbUserType.SelectedItem,
                       dtpUser.Value,
                       (genreType)cbFavGenre.SelectedItem,
                       profilePictureName,
                       profilePictureData,
                       profilePictureContentType
                       );
                }
                else
                {
                    //This creates a new User Object with the provided details
                    NewUser = new User(
                        exisitingUser.UserID,
                        tbNameUser.Text,
                        tbPassword.Text,
                        tbEmailUser.Text,
                        (userType)cbUserType.SelectedItem,
                        dtpUser.Value,
                        (genreType)cbFavGenre.SelectedItem,
                        profilePictureName,
                        profilePictureData,
                        profilePictureContentType
                        );
                }


                Result result = userManager.Update(NewUser, exisitingUser);

                if (result.Success)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    tsslblNewUserForm.Text = result.Message;
                }
            }
        }

        private void FillFormWithUserDetails(User user)
        {
            tbNameUser.Text = user.Username;
            tbPassword.Visible = false;
            tbEmailUser.Text = user.Email;
            tbPassword.Text = user.Password;
            cbUserType.SelectedItem = user.UserType;
            dtpUser.Value = user.Birthday;
            cbFavGenre.SelectedItem = user.FavGenre;

            //For artists
            #region Artist

            // Clear all checked items
            for (int i = 0; i < cklbAritstUser.Items.Count; i++)
            {
                cklbAritstUser.SetItemChecked(i, false);
            }

            // Get the songs for the album from the database
            var artists = artistManager.GetArtistForUser(user.UserID);

            // Set the selected items and update selectedArtistIDs
            foreach (var artist in artists)
            {
                var matchingItem = cklbAritstUser.Items.Cast<Artist>()
                                         .FirstOrDefault(item => item.ArtistID == artist.ArtistID);
                if (matchingItem != null)
                {
                    cklbAritstUser.SetItemChecked(cklbAritstUser.Items.IndexOf(matchingItem), true);
                    if (!selectedArtistIDs.Contains(artist.ArtistID))
                    {
                        selectedArtistIDs.Add(artist.ArtistID);
                    }
                }
            }

            #endregion

            //For songs
            #region Songs
            // Clear all checked items
            for (int i = 0; i < cklbSongsUser.Items.Count; i++)
            {
                cklbSongsUser.SetItemChecked(i, false);
            }

            // Get the songs for the album from the database
            var songs = songManager.GetSongsForUsers(user.UserID);

            // Check the songs in the checked list box and update the global selectedSongIDs list
            foreach (var song in songs)
            {
                for (int i = 0; i < cklbSongsUser.Items.Count; i++)
                {
                    if (((Song)cklbSongsUser.Items[i]).SongID == song.SongID)
                    {
                        cklbSongsUser.SetItemChecked(i, true);
                        if (!selectedSongIDs.Contains(song.SongID))
                        {
                            selectedSongIDs.Add(song.SongID);
                        }
                        break;
                    }
                }
            }
            #endregion

            //For albums
            #region Albums

            // Clear all checked items
            for (int i = 0; i < cklbAlbumUser.Items.Count; i++)
            {
                cklbAlbumUser.SetItemChecked(i, false);
            }

            // Get the songs for the album from the database
            var albums = albumManager.GetAlbumForUsers(user.UserID);

            // Check the songs in the checked list box and update the global selectedSongIDs list
            foreach (var album in albums)
            {
                for (int i = 0; i < cklbAlbumUser.Items.Count; i++)
                {
                    if (((Album)cklbAlbumUser.Items[i]).AlbumID == album.AlbumID)
                    {
                        cklbAlbumUser.SetItemChecked(i, true);
                        if (!selectedAlbumIDs.Contains(album.AlbumID))
                        {
                            selectedAlbumIDs.Add(album.AlbumID);
                        }
                        break;
                    }
                }
            }

            #endregion
        }

        private void DisplayProfilePicture(byte[] profilePictureData)
        {
            using (MemoryStream ms = new MemoryStream(profilePictureData))
            {
                SelectedProfileUser.Image = Image.FromStream(ms);
            }
        }

        private void ClearControls()
        {
            tbNameUser.Clear();
            tbEmailUser.Clear();
            tbPassword.Clear();
            cbUserType.SelectedIndex = 0;
            dtpUser.Value = DateTime.Now;
            cbFavGenre.SelectedIndex = 0;
            selectedImagePath = null;
            SelectedProfileUser.Image = null;
            isNewImageSelected = false;
        }

        public User GetNewUser()
        {
            if (ValidateInput())
            {
                //Gets the file name form the selected image path
                string profilePictureName = isNewImageSelected ? Path.GetFileName(selectedImagePath) : exisitingUser?.ProfilePictureName;

                //Gets the content type based on the file extension
                string profilePictureContentType = "";
                string extension = Path.GetExtension(profilePictureName);
                if (extension != null)
                {
                    switch (extension.ToLower())
                    {
                        case ".jpg":
                            profilePictureContentType = "image/jpeg";
                            break;
                        case ".png":
                            profilePictureContentType = "image/png";
                            break;
                        default:
                            tsslblNewUserForm.Text = $"Wrong format!";
                            break;
                    }
                }

                // This reads the selected image file into a byte array
                byte[] profilePictureData = isNewImageSelected ? File.ReadAllBytes(selectedImagePath) : exisitingUser?.ProfilePictureData;

                // This is a new User object that returns with the provided details
                return new User(
                     tbNameUser.Text,
                     tbPassword.Text,
                     tbEmailUser.Text,
                     (userType)cbUserType.SelectedItem,
                     dtpUser.Value,
                     (genreType)cbFavGenre.SelectedItem,
                     profilePictureName,
                     profilePictureData,
                     profilePictureContentType
                    );
            }
            else
            {
                // Return null if validation fails
                return null;
            }
        }

        public User GetUpdatedUser()
        {
            if (ValidateInput())
            {
                // Get the file name from the selected image path
                string profilePictureName = isNewImageSelected ? Path.GetFileName(selectedImagePath) : exisitingUser?.ProfilePictureName;

                // Get the content type based on the file extension
                string profilePictureContentType = "";
                string extension = Path.GetExtension(profilePictureName);
                if (extension != null)
                {
                    switch (extension.ToLower())
                    {
                        case ".jpg":
                            profilePictureContentType = "image/jpeg";
                            break;
                        case ".png":
                            profilePictureContentType = "image/png";
                            break;
                        default:
                            tsslblNewUserForm.Text = $"Wrong format!";
                            break;
                    }
                }

                // This reads the selected image file into a byte array
                byte[] profilePictureData = isNewImageSelected ? File.ReadAllBytes(selectedImagePath) : exisitingUser?.ProfilePictureData;

                userManager.Update(
                    new User(
                        exisitingUser.UserID,
                        tbNameUser.Text,
                        tbPassword.Text,
                        tbEmailUser.Text,
                        (userType)cbUserType.SelectedItem,
                        dtpUser.Value,
                        (genreType)cbFavGenre.SelectedItem,
                        profilePictureName,
                        profilePictureData,
                        profilePictureContentType),
                        exisitingUser
                    );
                return new User(
                        exisitingUser.UserID,
                        tbNameUser.Text,
                        tbPassword.Text,
                        tbEmailUser.Text,
                        (userType)cbUserType.SelectedItem,
                        dtpUser.Value,
                        (genreType)cbFavGenre.SelectedItem,
                        profilePictureName,
                        profilePictureData,
                        profilePictureContentType);

            }
            else
            {
                // Returns null if validation fails
                return null;
            }
        }
        public bool ValidateInput()
        {
            //Try implementing validation in the classes and then call them here. Validator class that helps check the data validation. List of validation.

            //Validate UserName
            if (string.IsNullOrWhiteSpace(tbNameUser.Text))
            {
                tsslblNewUserForm.Text = $"Every User needs a name";
                return false;
            }

            //Validate User Email
            if (string.IsNullOrWhiteSpace(tbEmailUser.Text) || !IsValidEmail(tbEmailUser.Text))
            {
                tsslblNewUserForm.Text = $"Please enter a valid email address";
                return false;
            }

            //Validate User Birthday
            if (dtpUser.Value == DateTime.Now || dtpUser.Value > DateTime.Now)
            {
                tsslblNewUserForm.Text = $"Please select a realisitc birthdate";
                return false;
            }

            //Validate favorite Genre
            if (cbFavGenre.SelectedItem == null)
            {
                tsslblNewUserForm.Text = $"Please select at least one favorite genre";
                return false;
            }

            // Check if an image is selected or exists for the user
            if (!isNewImageSelected && (exisitingUser == null || exisitingUser.ProfilePictureData == null))
            {
                tsslblNewUserForm.Text = "Please select an profile picture image for the User.";
                return false;
            }

            // All validation passes, return true
            return true;
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public void InitializeComboBox()
        {
            //populates the favorite genre combo box
            cbFavGenre.DataSource = (Enum.GetValues(typeof(genreType)));
            //populates the user type combo box
            cbUserType.DataSource = (Enum.GetValues(typeof(userType)));

            //for artists
            cklbAritstUser.DataSource = artistManager.LoadArtistFromDB();

            //for songs
            cklbSongsUser.DataSource = songManager.LoadSongsFromDataBase();
			cklbSongsUser.DisplayMember = "Title";

			//for albums
			cklbAlbumUser.DataSource = albumManager.LoadAlbumsFromDatabase();
			cklbAlbumUser.DisplayMember = "Title";
		}

        private void Users_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Owner != null)
            {
                Owner.Visible = true;
            }
        }
    }
}
