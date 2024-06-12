using Infrastructure;
using Logic;


namespace WinFormsApp
{
    public partial class NewSong_Form : Form
    {
        private bool isNewImageSelected = false;

        public Song NewSong { get; private set; }
        private Song exisitingSong;
        private SongManager songManager;
        private ArtistManager artistManager;
        private string selectedImagePath;

        public NewSong_Form(SongManager sm, ArtistManager arm, Song song = null, bool view = false)
        {
            songManager = sm;
            artistManager = arm;    
            InitializeComponent();
            InitializeComboBox();
            exisitingSong = song;

            ClearControls();
            this.StartPosition = FormStartPosition.CenterScreen;

            if (exisitingSong != null)
            {
                FillFormWithSongDetails(exisitingSong);
                //This will load and display the song cover
                DisplaySongCover(exisitingSong.SongCoverData);
            }

            if (view)
            {
                tbTitleSong.Enabled = false;
                dtpSong.Enabled = false;
                cbArtistSong.Enabled = false;
                cbGenre.Enabled = false;
                nudRunTimeSongs.Enabled = false;
                btnAddPictureSong.Enabled = false;
                BtnAddSong.Enabled = false;
            }

            #region might_use_for_Colors
            //for the status strip font
            //int red = 211;
            //int green = 0;
            //int blue = 0;

            //Color customRed = Color.FromArgb(red, green, blue);
            //ssNewSongForm.ForeColor = customRed;
            #endregion
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAddPictureSong_Click(object sender, EventArgs e)
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
                        tsslblNewSongForm.Text = $"Please select an image file with .jpg or .png extension.";

                        return;
                    }

                    // Stores the selected image path
                    selectedImagePath = selectedFile;
                    isNewImageSelected = true;

                    // This will load and display the image if needed
                    SelectedCoverSong.Image = Image.FromFile(selectedImagePath);
                }
            }
        }

        private void BtnAddSong_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                // This gets the file name from the selected image path
                string songCoverName = isNewImageSelected ? Path.GetFileName(selectedImagePath) : exisitingSong.SongCoverName;

                // This gets the content type based on the file extension
                string songCoverContentType = "";
                string extension = Path.GetExtension(songCoverName);
                if (extension != null)
                {
                    switch (extension.ToLower())
                    {
                        case ".jpg":
                            songCoverContentType = "image/jpeg";
                            break;
                        case ".png":
                            songCoverContentType = "image/png";
                            break;
                        default:
                            tsslblNewSongForm.Text = $"Wrong format!";
                            break;
                    }
                }

                Artist selectedArtist = cbArtistSong.SelectedItem as Artist;

                // This reads the selected image file into a byte array
                byte[] songCoverData = isNewImageSelected ? File.ReadAllBytes(selectedImagePath) : exisitingSong.SongCoverData;

                if (exisitingSong == null)
                {
                    //This creates a new Song Object with the provided details 
                    NewSong = new Song(
                      tbTitleSong.Text,
                      selectedArtist,
                      dtpSong.Value,
                      (int)nudRunTimeSongs.Value,
                      (genreType)cbGenre.SelectedItem,
                      songCoverName,
                      songCoverData,
                      songCoverContentType
                    );
                }
                else
                {
                    //This creates a new Song Object with the provided details 
                    NewSong = new Song(
                      exisitingSong.SongID,
                      tbTitleSong.Text,
                      selectedArtist,
                      dtpSong.Value,
                      (int)nudRunTimeSongs.Value,
                      (genreType)cbGenre.SelectedItem,
                      songCoverName,
                      songCoverData,
                      songCoverContentType
                    );
                }

                Result result = songManager.Update(NewSong);

                if (result.Success)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    tsslblNewSongForm.Text = result.Message;
                }
            }
        }

        private void FillFormWithSongDetails(Song song)
        {
            tbTitleSong.Text = song.Title;

            // Finds the artist by ID and sets the selected item
            foreach (var item in cbArtistSong.Items)
            {
                Artist artist = item as Artist;
                if (artist.Name == song.Artist.Name)
                {
                    cbArtistSong.SelectedItem = item;
                    break;
                }
            }
            dtpSong.Value = song.Date;
            nudRunTimeSongs.Value = song.RunTime;
            cbGenre.SelectedItem = song.Genre;
        }

        private void DisplaySongCover(byte[] songCoverData)
        {
            using (MemoryStream ms = new MemoryStream(songCoverData))
            {
                SelectedCoverSong.Image = Image.FromStream(ms);
            }
        }

        private void ClearControls()
        {
            tbTitleSong.Clear();
            cbArtistSong.SelectedIndex = 0;
            dtpSong.Value = DateTime.Now;
            cbGenre.SelectedIndex = 0;
            nudRunTimeSongs.Value = 0;
            selectedImagePath = null;
            SelectedCoverSong.Image = null;
            isNewImageSelected = false;
        }

        public Song GetNewSong()
        {

            if (ValidateForm())
            {
                // Get the file name from the selected image path
                string songCoverName = isNewImageSelected ? Path.GetFileName(selectedImagePath) : exisitingSong?.SongCoverName;

                // Get the content type based on the file extension
                string songCoverContentType = "";
                string extension = Path.GetExtension(songCoverName);
                if (extension != null)
                {
                    switch (extension.ToLower())
                    {
                        case ".jpg":
                            songCoverContentType = "image/jpeg";
                            break;
                        case ".png":
                            songCoverContentType = "image/png";
                            break;
                        default:
                            tsslblNewSongForm.Text = $"Wrong format!";
                            break;
                    }
                }

                // This reads the selected image file into a byte array
                byte[] songCoverData = isNewImageSelected ? File.ReadAllBytes(selectedImagePath) : exisitingSong?.SongCoverData;

                // This is a new Song object that returns with the provided details
                return new Song(
                      tbTitleSong.Text,
                      ((Artist)cbArtistSong.SelectedItem),
                      dtpSong.Value,
                      (int)nudRunTimeSongs.Value,
                      (genreType)cbGenre.SelectedItem,
                      songCoverName,
                      songCoverData,
                      songCoverContentType
                    );
            }
            else
            {
                // Return null if validation fails
                return null;
            }
        }

        public Song GetUpdatedSong()
        {
            if (ValidateForm())
            {
                // Get the file name from the selected image path
                string songCoverName = isNewImageSelected ? Path.GetFileName(selectedImagePath) : exisitingSong?.SongCoverName;

                // Get the content type based on the file extension
                string songCoverContentType = "";
                string extension = Path.GetExtension(songCoverName);
                if (extension != null)
                {
                    switch (extension.ToLower())
                    {
                        case ".jpg":
                            songCoverContentType = "image/jpeg";
                            break;
                        case ".png":
                            songCoverContentType = "image/png";
                            break;
                        default:
                            tsslblNewSongForm.Text = $"Wrong format!";
                            break;
                    }
                }

                // This reads the selected image file into a byte array
                byte[] songCoverData = isNewImageSelected ? File.ReadAllBytes(selectedImagePath) : exisitingSong?.SongCoverData;

                songManager.Update(
                     new Song(
                        exisitingSong.SongID,
                        tbTitleSong.Text,
                        ((Artist)cbArtistSong.SelectedItem),
                        dtpSong.Value,
                        (int)nudRunTimeSongs.Value,
                        (genreType)cbGenre.SelectedItem,
                        songCoverName,
                        songCoverData,
                        songCoverContentType)
                     );
                return new Song(
                        exisitingSong.SongID,
                        tbTitleSong.Text,
                        ((Artist)cbArtistSong.SelectedItem),
                        dtpSong.Value,
                        (int)nudRunTimeSongs.Value,
                        (genreType)cbGenre.SelectedItem,
                        songCoverName,
                        songCoverData,
                        songCoverContentType);

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
            if (string.IsNullOrEmpty(tbTitleSong.Text))
            {
                tsslblNewSongForm.Text = "Every song needs a title. Please enter one.";
                return false;
            }

            // Checks if the artist is provided
            if (cbArtistSong.SelectedItem == null)
            {
                tsslblNewSongForm.Text = "Every song needs an artist. Please select one.";
                return false;
            }

            // Checks if a genre is selected
            if (cbGenre.SelectedItem == null)
            {
                tsslblNewSongForm.Text = "Please select a genre for the song.";
                return false;
            }

            // Check if an image is selected or exists for the song
            if (!isNewImageSelected && (exisitingSong == null || exisitingSong.SongCoverData == null))
            {
                tsslblNewSongForm.Text = "Please select an song cover image for the Song.";
                return false;
            }
            if (nudRunTimeSongs == null)
            {
                tsslblNewSongForm.Text = "Every Song needs a runtime in seconds. Please input one";
                return false;
            }

            return true;
        }
       

        public void InitializeComboBox()
        {
            cbGenre.DataSource = Enum.GetValues(typeof(genreType));

            cbArtistSong.DataSource = artistManager.LoadArtistFromDB();
        }

        private void NewMusic_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Owner != null)
            {
                Owner.Visible = true;
            }
        }

    }
}
