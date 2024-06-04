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

        //Adding an artist
        #region Artist
        private void btnAddArtistUser_Click(object sender, EventArgs e)
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
                Result resultAddArtist = userManager.SaveArtistInUsers(selectedUser.UserID, selectedSongIDs);

                if (resultAddArtist.Success)
                {
                    DialogResult = DialogResult.OK;
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
                Result resultAddArtist = userManager.RemoveArtistFromAlbum(selectedUser.UserID, selectedSongIDs);

                if (resultAddArtist.Success)
                {
                    DialogResult = DialogResult.OK;
                    tsslblNewUserForm.Text = resultAddArtist.Message;
                }
                else
                {
                    tsslblNewUserForm.Text = resultAddArtist.Message;
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
            cklbAritstUser.ValueMember = "ArtistID";

            // Reapply the checked state for previously selected songs
            for (int i = 0; i < cklbAritstUser.Items.Count; i++)
            {
                Artist artist = (Artist)cklbAritstUser.Items[i];
                if (selectedSongIDs.Contains(artist.ArtistID))
                {
                    cklbAritstUser.SetItemChecked(i, true);
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

            // Clear all checked items
            for (int i = 0; i < cklbAritstUser.Items.Count; i++)
            {
                cklbAritstUser.SetItemChecked(i, false);
            }

            // Get the songs for the album from the database
            var artists = artistManager.GetArtistForUser(user.UserID);

            // Check the songs in the checked list box and update the global selectedSongIDs list
            foreach (var artist in artists)
            {
                for (int i = 0; i < cklbAritstUser.Items.Count; i++)
                {
                    if (((Artist)cklbAritstUser.Items[i]).ArtistID == artist.ArtistID)
                    {
                        cklbAritstUser.SetItemChecked(i, true);
                        if (!selectedArtistIDs.Contains(artist.ArtistID))
                        {
                            selectedArtistIDs.Add(artist.ArtistID);
                        }
                        break;
                    }
                }
            }
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

            cklbAritstUser.DataSource = artistManager.LoadArtistFromDB();
            cklbAritstUser.DisplayMember = "Name";
            cklbAritstUser.ValueMember = "ArtistID";
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
