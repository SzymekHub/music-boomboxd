using Infrastructure;
using Infrastructure.InterfacesForRepo;
using Infrastructure.Repositories;
using Logic.Algorithms;
using Logic.Interfaces;
using Logic;
using System.Linq;

namespace WinFormsApp
{
    public partial class NewAlbum_Form : Form
    {
        private List<int> selectedSongIDs = new List<int>();
        private bool isNewImageSelected = false;

        public Album NewAlbum { get; private set; }
        private Album existingAlbum;
        private AlbumManager albumManager;
        private SongManager songManager;
        private ArtistManager artistManager;
        private string selectedImagePath;

        public NewAlbum_Form(AlbumManager am, SongManager sm, ArtistManager arm, Album album = null, bool view = false, bool update = false)
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

            lblSongs.Visible = false;
            txtSongsSearch.Visible = false;
            cklbSongs.Visible = false;
            label1.Visible = false;
            btnAddSongs.Visible = false;
            btnRemoveSong.Visible = false;

            if (update)
            {
				lblSongs.Visible = true;
				txtSongsSearch.Visible = true;
				cklbSongs.Visible = true;
				label1.Visible = true;
				btnAddSongs.Visible = true;
				btnRemoveSong.Visible = true;
			}
            #region Disables_Controls
            if (view)
            {
                tbTitleAlbum.Enabled = false;
                dtpAlbum.Enabled = false;
                cbArtistAlbum.Enabled = false;
                cbGenreAlbum.Enabled = false;
                cklbSongs.Enabled = false;
                btnAddSongs.Enabled = false;
                nudRunTimeAlbum.Enabled = false;
                btnAddPictureAlbum.Enabled = false;
                btnAddAlbum.Enabled = false;
				lblSongs.Enabled = false;
				txtSongsSearch.Enabled = false;
				cklbSongs.Enabled = false;
				label1.Enabled = false;
				btnAddSongs.Enabled = false;
				btnRemoveSong.Enabled = false;
			}
            #endregion
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

                    // Check if the selected file has a valid image extension
                    string extension = Path.GetExtension(selectedFile);
                    if (extension != ".jpg" && extension != ".png")
                    {
                        tsslblNewAlbumForm.Text = $"Please select an image file with .jpg or .png extension.";
                        return;
                    }

                    // Store the selected image path
                    selectedImagePath = selectedFile;
                    isNewImageSelected = true;

                    // Load and display the image
                    SelectedCoverAlbum.Image = Image.FromFile(selectedImagePath);
                }
            }
        }

        private void btnAddSongs_Click(object sender, EventArgs e)
        {
            // Gets the selected album
            Album selectedAlbum = GetUpdatedAlbum();

            if (ValidateForm())
            {
                // Gets the selected songs from the checkedListBox
                List<int> selectedSongIDs = new List<int>();
                foreach (var item in cklbSongs.CheckedItems)
                {
                    selectedSongIDs.Add(((Song)item).SongID);
                }

                // Calls the method in AlbumManager to save songs in albums
                Result resultAddSong = albumManager.SaveSongsInAlbums(selectedAlbum.AlbumID, selectedSongIDs);

                if (resultAddSong.Success)
                {
                    DialogResult = DialogResult.OK;
                    tsslblNewAlbumForm.Text = resultAddSong.Message;
                }
                else
                {
                    tsslblNewAlbumForm.Text = resultAddSong.Message;
                }
            }
        }

        private void btnRemoveSong_Click(object sender, EventArgs e)
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

                // Call the method in AlbumManager to remove songs in albums
                Result resultRemoveSong = albumManager.RemoveSongFromAlbum(selectedAlbum.AlbumID, selectedSongIDs);

                if (resultRemoveSong.Success)
                {
                    DialogResult = DialogResult.OK;
                    tsslblNewAlbumForm.Text = resultRemoveSong.Message;
                }
                else
                {
                    tsslblNewAlbumForm.Text = resultRemoveSong.Message;
                }
            }
        }

        private void BtnAddAlbum_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                // Get the file name from the selected image path or existing image data
                string albumCoverName = isNewImageSelected ? Path.GetFileName(selectedImagePath) : existingAlbum.AlbumCoverName;

                // Get the content type based on the file extension
                string albumCoverContentType = "";
                string extension = Path.GetExtension(albumCoverName);
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

                // Read the selected image file into a byte array or use existing image data
                byte[] albumCoverData = isNewImageSelected ? File.ReadAllBytes(selectedImagePath) : existingAlbum.AlbumCoverData;

                if (existingAlbum == null)
                {
                    NewAlbum = new Album(
                        selectedArtist,
                        tbTitleAlbum.Text,
                        dtpAlbum.Value,
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
                        selectedArtist,
                        tbTitleAlbum.Text,
                        dtpAlbum.Value,
                        (int)nudRunTimeAlbum.Value,
                        (genreType)cbGenreAlbum.SelectedItem,
                        albumCoverName,
                        albumCoverData,
                        albumCoverContentType
                    );
                }

                Result result = albumManager.Update(NewAlbum);

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

        private void txtSongsSearch_TextChanged(object sender, EventArgs e)
        {
            FilterSongs(txtSongsSearch.Text);
        }

        private void FilterSongs(string searchText)
        {
            List<Song> allSongs = songManager.LoadSongsFromDataBase();
            List<Song> filteredSongs = allSongs.Where(song => song.Title.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            cklbSongs.DataSource = filteredSongs;
            cklbSongs.DisplayMember = "Title";
            cklbSongs.ValueMember = "SongID";

            // Reapply the checked state for previously selected songs
            for (int i = 0; i < cklbSongs.Items.Count; i++)
            {
                Song song = (Song)cklbSongs.Items[i];
                if (selectedSongIDs.Contains(song.SongID))
                {
                    cklbSongs.SetItemChecked(i, true);
                }
            }
        }

        private void FillFormWithAlbumDetails(Album album)
        {
            tbTitleAlbum.Text = album.Title;

            foreach (var item in cbArtistAlbum.Items)
            {
                Artist artist = item as Artist;
                if (artist.Name == album.Artist.Name)
                {
                    cbArtistAlbum.SelectedItem = item;
                }
            }

            dtpAlbum.Value = album.Date;
            nudRunTimeAlbum.Value = album.RunTime;
            cbGenreAlbum.SelectedItem = album.Genre;

            // Clear all checked items
            for (int i = 0; i < cklbSongs.Items.Count; i++)
            {
                cklbSongs.SetItemChecked(i, false);
            }

            // Get the songs for the album from the database
            var songs = songManager.GetSongsForAlbum(album.AlbumID);

            // Check the songs in the checked list box and update the global selectedSongIDs list
            foreach (var song in songs)
            {
                for (int i = 0; i < cklbSongs.Items.Count; i++)
                {
                    if (((Song)cklbSongs.Items[i]).SongID == song.SongID)
                    {
                        cklbSongs.SetItemChecked(i, true);
                        if (!selectedSongIDs.Contains(song.SongID))
                        {
                            selectedSongIDs.Add(song.SongID);
                        }
                        break;
                    }
                }
            }
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
            dtpAlbum.Value = DateTime.Now;
            nudRunTimeAlbum.Value = 0;
            cbGenreAlbum.SelectedIndex = 0;
            selectedImagePath = null;
            SelectedCoverAlbum.Image = null;
            isNewImageSelected = false;
        }

        public Album GetNewAlbum()
        {
            if (ValidateForm())
            {
                // Get the file name from the selected image path or existing image data
                string albumCoverName = isNewImageSelected ? Path.GetFileName(selectedImagePath) : existingAlbum?.AlbumCoverName;

                // Get the content type based on the file extension
                string albumCoverContentType = "";
                string extension = Path.GetExtension(albumCoverName);
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

                // Read the selected image file into a byte array or use existing image data
                byte[] albumCoverData = isNewImageSelected ? File.ReadAllBytes(selectedImagePath) : existingAlbum?.AlbumCoverData;

                // Return a new Album object with the provided details
                return new Album(
                      ((Artist)cbArtistAlbum.SelectedItem),
                      tbTitleAlbum.Text,
                      dtpAlbum.Value,
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
                // Get the file name from the selected image path or existing image data
                string albumCoverName = isNewImageSelected ? Path.GetFileName(selectedImagePath) : existingAlbum?.AlbumCoverName;

                // Get the content type based on the file extension
                string albumCoverContentType = "";
                string extension = Path.GetExtension(albumCoverName);
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

                // Read the selected image file into a byte array or use existing image data
                byte[] albumCoverData = isNewImageSelected ? File.ReadAllBytes(selectedImagePath) : existingAlbum?.AlbumCoverData;

                albumManager.Update(
                    new Album(
                        existingAlbum.AlbumID,
                        ((Artist)cbArtistAlbum.SelectedItem),
                        tbTitleAlbum.Text,
                        dtpAlbum.Value,
                        (int)nudRunTimeAlbum.Value,
                        (genreType)cbGenreAlbum.SelectedItem,
                        albumCoverName,
                        albumCoverData,
                        albumCoverContentType)
                    );

                return new Album(
                        existingAlbum.AlbumID,
                        ((Artist)cbArtistAlbum.SelectedItem),
                        tbTitleAlbum.Text,
                        dtpAlbum.Value,
                        (int)nudRunTimeAlbum.Value,
                        (genreType)cbGenreAlbum.SelectedItem,
                        albumCoverName,
                        albumCoverData,
                        albumCoverContentType);
            }
            else
            {
                // Return null if validation fails
                return null;
            }
        }

        private bool ValidateForm()
        {
            // Check if the title is provided
            if (string.IsNullOrEmpty(tbTitleAlbum.Text))
            {
                tsslblNewAlbumForm.Text = "Every Album needs a title. Please enter one.";
                return false;
            }

            // Check if the artist is provided
            if (cbArtistAlbum.SelectedItem == null)
            {
                tsslblNewAlbumForm.Text = "Every Album needs an artist. Please select one.";
                return false;
            }

            // Check if a genre is selected
            if (cbGenreAlbum.SelectedItem == null)
            {
                tsslblNewAlbumForm.Text = "Please select a genre for the Album.";
                return false;
            }

            // Check if an image is selected or exists for the album
            if (!isNewImageSelected && (existingAlbum == null || existingAlbum.AlbumCoverData == null))
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
            cbArtistAlbum.DataSource = artistManager.LoadArtistFromDB();/*.Select(x => new AlbumViewModelWin(x)).ToList();*/
            //cbArtistAlbum.ValueMember = "Artist";


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
