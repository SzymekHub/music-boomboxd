using Infrastructure;
using Logic;

namespace WinFormsApp
{
    public partial class NewAlbum_Form : Form
    {
        public Album NewAlbum { get; private set; }
        private Album existingAlbum;
        private AlbumManager albumManager;
        private SongManager songManager;
        private ArtistManager artistManager;
        private string selectedImagePath;

        public NewAlbum_Form(AlbumManager am, SongManager sm, ArtistManager arm, Album album = null, bool view = false)
        {
            albumManager = am;
            songManager = sm;
            artistManager = arm;
            InitializeComponent();
            InitializeComboBox();
            existingAlbum = album;
            ClearControls();
            this.StartPosition = FormStartPosition.CenterScreen;

            if (existingAlbum != null)
            {
                FillFormWithAlbumDetails(existingAlbum);
                DisplayAlbumCover(existingAlbum.AlbumCoverData);
            }

            if (view)
            {
                tbTitleAlbum.Enabled = false;
                DatePickerAlbum.Enabled = false;
                cbArtistAlbum.Enabled = false;
                cbGenreAlbum.Enabled = false;
                cklbSongs.Enabled = false;
                btnAddSongs.Enabled = false;
                nudRunTimeAlbum.Enabled = false;
                btnAddPictureAlbum.Enabled = false;
                btnAddAlbum.Enabled = false;
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
                        tsslblNewAlbumForm.Text = $"Please select an image file with .jpg or .png extension.";

                        return;
                    }

                    // Stores the selected image path
                    selectedImagePath = selectedFile;

                    // This will load and display the image
                    SelectedCoverAlbum.Image = Image.FromFile(selectedImagePath);
                }
            }
        }
        private void btnAddSongs_Click(object sender, EventArgs e)
        {
            // Get the selected album
            Album selectedAlbum = GetUpdatedAlbum();

            if (ValidateForm())
            {
                // Get the selected songs from the checkedListBox
                List<int> selectedSongIDs = new List<int>();
                foreach (var item in cklbSongs.CheckedItems)
                {
                    selectedSongIDs.Add(((Song)item).SongID);
                }

                // Call the method in AlbumManager to save songs in albums
                Result resultaddSong = albumManager.SaveSongsInAlbums(selectedAlbum.AlbumID, selectedSongIDs);
                
                if (resultaddSong.Success)
                {
                    DialogResult = DialogResult.OK;
                    tsslblNewAlbumForm.Text = resultaddSong.Message;
                }
                else
                {
                    tsslblNewAlbumForm.Text = resultaddSong.Message;
                }

            }
        }

        private void BtnAddAlbum_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                // This gets the file name from the selected image path
                string albumCoverName = Path.GetFileName(selectedImagePath);

                // This gets the content type based on the file extension
                string albumCoverContentType = "";
                string extension = Path.GetExtension(selectedImagePath);
                if (extension != null)
                {
                    switch (extension.ToLower())
                    {
                        case ".jpg":
                            albumCoverContentType = "image/jpeg";
                            break;
                        case ".png":
                            albumCoverContentType = "image/png";
                            break;
                        default:
                            tsslblNewAlbumForm.Text = $"Wrong format!";
                            break;
                    }
                }

                Artist selectedArtist = cbArtistAlbum.SelectedItem as Artist;

                // This reads the selected image file into a byte array
                byte[] albumCoverData = File.ReadAllBytes(selectedImagePath);

                if (existingAlbum == null)
                {
                    NewAlbum = new Album(
                        selectedArtist.ArtistID,
                        tbTitleAlbum.Text,
                        DatePickerAlbum.Value,
                        (int)nudRunTimeAlbum.Value,
                        (genreType)cbGenreAlbum.SelectedItem,
                        albumCoverName,
                        albumCoverData,
                        albumCoverContentType
                    );
                }
                else
                {
                    NewAlbum = new Album(
                        existingAlbum.AlbumID,
                        selectedArtist.ArtistID,
                        tbTitleAlbum.Text,
                        DatePickerAlbum.Value,
                        (int)nudRunTimeAlbum.Value,
                        (genreType)cbGenreAlbum.SelectedItem,
                        albumCoverName,
                        albumCoverData,
                        albumCoverContentType
                    );
                }

                Result result = albumManager.Update(NewAlbum, existingAlbum);

                if (result.Success)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    tsslblNewAlbumForm.Text = result.Message;
                }
            }
        }

        private void FillFormWithAlbumDetails(Album album)
        {
            tbTitleAlbum.Text = album.Title;
            if (cbArtistAlbum.Items.IndexOf(album.Artist) != -1)
            {
                cbArtistAlbum.SelectedIndex = cbArtistAlbum.Items.IndexOf(album.Artist);
            }
            cklbSongs.SelectedItems.Contains(album.Songs);
            DatePickerAlbum.Value = album.Date;
            nudRunTimeAlbum.Value = album.RunTime;
            cbGenreAlbum.SelectedItem = album.Genre;
        }

        private void DisplayAlbumCover(byte[] albumCoverData)
        {
            using (MemoryStream ms = new MemoryStream(albumCoverData))
            {
                SelectedCoverAlbum.Image = Image.FromStream(ms);
            }
        }

        private void ClearControls()
        {
            tbTitleAlbum.Clear();
            cbArtistAlbum.SelectedIndex = 0;
            DatePickerAlbum.Value = DateTime.Now;
            nudRunTimeAlbum.Value = 0;
            cbGenreAlbum.SelectedIndex = 0;
            selectedImagePath = null;
            SelectedCoverAlbum.Image = null;
        }

        public Album GetNewAlbum()
        {
            if (ValidateForm())
            {
                // Get the file name from the selected image path
                string albumCoverName = Path.GetFileName(selectedImagePath);

                // Get the content type based on the file extension
                string albumCoverContentType = "";
                string extension = Path.GetExtension(selectedImagePath);
                if (extension != null)
                {
                    switch (extension.ToLower())
                    {
                        case ".jpg":
                            albumCoverContentType = "image/jpeg";
                            break;
                        case ".png":
                            albumCoverContentType = "image/png";
                            break;
                        default:
                            tsslblNewAlbumForm.Text = $"Wrong format!";
                            break;
                    }
                }

                // This reads the selected image file into a byte array
                byte[] albumCoverData = File.ReadAllBytes(selectedImagePath);

                // This is a new Album object that returns with the provided details
                return new Album(
                      ((Artist)cbArtistAlbum.SelectedItem).ArtistID,
                      tbTitleAlbum.Text,
                      DatePickerAlbum.Value,
                      (int)nudRunTimeAlbum.Value,
                      (genreType)cbGenreAlbum.SelectedItem,
                      albumCoverName,
                      albumCoverData,
                      albumCoverContentType
                    );
            }
            else
            {
                // Return null if validation fails
                return null;
            }
        }

        public Album GetUpdatedAlbum()
        {
            if (ValidateForm())
            {
                // Get the file name from the selected image path
                string albumCoverName = Path.GetFileName(selectedImagePath);

                // Get the content type based on the file extension
                string albumCoverContentType = "";
                string extension = Path.GetExtension(selectedImagePath);
                if (extension != null)
                {
                    switch (extension.ToLower())
                    {
                        case ".jpg":
                            albumCoverContentType = "image/jpeg";
                            break;
                        case ".png":
                            albumCoverContentType = "image/png";
                            break;
                        default:
                            tsslblNewAlbumForm.Text = $"Wrong format!";
                            break;
                    }
                }

                // This reads the selected image file into a byte array
                byte[] albumCoverData = File.ReadAllBytes(selectedImagePath);

                albumManager.Update(
                    new Album(
                        existingAlbum.AlbumID,
                        ((Artist)cbArtistAlbum.SelectedItem).ArtistID,
                        tbTitleAlbum.Text,
                        DatePickerAlbum.Value,
                        (int)nudRunTimeAlbum.Value,
                        (genreType)cbGenreAlbum.SelectedItem,
                        albumCoverName,
                        albumCoverData,
                        albumCoverContentType),
                        existingAlbum
                    );
                return new Album(
                        existingAlbum.AlbumID,
                        ((Artist)cbArtistAlbum.SelectedItem).ArtistID,
                        tbTitleAlbum.Text,
                        DatePickerAlbum.Value,
                        (int)nudRunTimeAlbum.Value,
                        (genreType)cbGenreAlbum.SelectedItem,
                        albumCoverName,
                        albumCoverData,
                        albumCoverContentType);
            }
            else
            {
                // Returns null if validation fails
                return null;
            }
        }

        private bool ValidateForm()
        {
            // Checks if the title is provided
            if (string.IsNullOrEmpty(tbTitleAlbum.Text))
            {
                tsslblNewAlbumForm.Text = "Every Album needs a title. Please enter one.";
                return false;
            }

            // Checks if the artist is provided
            if (cbArtistAlbum.SelectedItem == null)
            {
                tsslblNewAlbumForm.Text = "Every Album needs an artist. Please select one.";
                return false;
            }

            // Checks if a genre is selected
            if (cbGenreAlbum.SelectedItem == null)
            {
                tsslblNewAlbumForm.Text = "Please select a genre for the Album.";
                return false;
            }

            // Checks if an image is selected
            if (string.IsNullOrEmpty(selectedImagePath))
            {
                tsslblNewAlbumForm.Text = "Please select an album cover image for the Album.";
                return false;
            }

            if (nudRunTimeAlbum == null)
            {
                tsslblNewAlbumForm.Text = "Every Album needs a runtime in seconds. Please input one";
                return false;
            }

            return true;
        }

        public void InitializeComboBox()
        {
            cbGenreAlbum.DataSource = Enum.GetValues(typeof(genreType));

            cbArtistAlbum.DataSource = artistManager.LoadArtistFromDB();

            cklbSongs.DataSource = songManager.LoadSongsFromDataBase();
            cklbSongs.DisplayMember = "Title";
            cklbSongs.ValueMember = "SongID";

        }

        private void NewAlbum_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Owner != null)
            {
                Owner.Visible = true;
            }
        }

    }
}
