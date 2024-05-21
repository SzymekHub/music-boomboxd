using Infrastructure;
using Logic;

namespace WinFormsApp
{
    public partial class NewAlbum_Form : Form
    {
        public Album NewAlbum { get; private set; }
        private Album exisitingAlbum;
        private AlbumManager albumManager;
        private string selectedImagePath;

        public NewAlbum_Form(AlbumManager am, Album album = null, bool view = false)
        {
            albumManager = am;
            InitializeComponent();
            InitializeComboBox();
            exisitingAlbum = album;
            ClearControls();
            this.StartPosition = FormStartPosition.CenterScreen;

            if (exisitingAlbum != null)
            {
                FillFormWithAlbumDetails(exisitingAlbum);
                //This will load and display the album cover
                DisplayAlbumCover(exisitingAlbum.AlbumCoverData);
            }

            if (view)
            {
                tbTitleAlbum.Enabled = false;
                DatePickerAlbum.Enabled = false;
                tbArtistAlbum.Enabled = false;
                cbGenreAlbum.Enabled = false;
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

                // This reads the selected image file into a byte array
                byte[] albumCoverData = File.ReadAllBytes(selectedImagePath);

                //This creates a new Album Object with the provided details 
                Album newAlbum = new Album(
                      exisitingAlbum.AlbumID,
                      tbTitleAlbum.Text,
                      tbArtistAlbum.Text,
                      DatePickerAlbum.Value,
                      (genreType)cbGenreAlbum.SelectedItem,
                      albumCoverName,
                      albumCoverData,
                      albumCoverContentType
                );

                Result result = albumManager.Update(newAlbum, exisitingAlbum);

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
            tbArtistAlbum.Text = album.Artist;
            DatePickerAlbum.Value = album.Date;
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
            tbArtistAlbum.Clear();
            DatePickerAlbum.Value = DateTime.Now;
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
                      tbTitleAlbum.Text,
                      tbArtistAlbum.Text,
                      DatePickerAlbum.Value,
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
                        tbTitleAlbum.Text,
                        tbArtistAlbum.Text,
                        DatePickerAlbum.Value,
                        (genreType)cbGenreAlbum.SelectedItem,
                        albumCoverName,
                        albumCoverData,
                        albumCoverContentType),
                        exisitingAlbum
                    );
                return new Album(
                        tbTitleAlbum.Text,
                        tbArtistAlbum.Text,
                        DatePickerAlbum.Value,
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
            if (string.IsNullOrEmpty(tbArtistAlbum.Text))
            {
                tsslblNewAlbumForm.Text = "Every Album needs an artist. Please enter one.";
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

            return true;
        }

        public void InitializeComboBox()
        {
            cbGenreAlbum.DataSource = Enum.GetValues(typeof(genreType));
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
