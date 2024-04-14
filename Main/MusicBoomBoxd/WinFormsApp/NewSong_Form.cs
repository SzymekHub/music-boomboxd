using Infrastructure;
using Infrastructure.DTOs;
using Logic;


namespace WinFormsApp
{
    public partial class NewSong_Form : Form
    {
        private const string FilePath = "./NewSong.CSV";
        private string selectedImagePath;
        private readonly SongRepository _songRepository = new SongRepository();

        public NewSong_Form()
        {
            InitializeComponent();
            InitializeComboBox();
            ClearControls();
            LoadRecentSongsFromTheDatabse();
            this.StartPosition = FormStartPosition.CenterScreen;
            
            //for the status strip font
            int red = 211;
            int green = 0;
            int blue = 0;

            Color customRed = Color.FromArgb(red, green, blue);
            ssNewSongForm.ForeColor = customRed;
        }
        
        private void ClearControls()
        {
            TxtTitle.Clear();
            TxtArtist.Clear();
            DatePicker.Value = DateTime.Now; 
            CbGenre.SelectedIndex = 0; 
            selectedImagePath = null; 
            SelectedCover.Image = null; 
        }
        public void InitializeComboBox()
        {
            CbGenre.DataSource = Enum.GetValues(typeof(genreType));
        }

        private bool ValidateForm()
        {
            // Checks if the title is provided
            if (string.IsNullOrEmpty(TxtTitle.Text))
            {
                tsslblNewSongForm.Text = "Every song needs a title. Please enter one.";
                return false;
            }

            // Checks if the artist is provided
            if (string.IsNullOrEmpty(TxtArtist.Text))
            {
                tsslblNewSongForm.Text = "Every song needs an artist. Please enter one.";
                return false;
            }

            // Checks if a genre is selected
            if (CbGenre.SelectedItem == null)
            {
                tsslblNewSongForm.Text = "Please select a genre for the song.";
                return false;
            }

            // Checks if an image is selected
            if (string.IsNullOrEmpty(selectedImagePath))
            {
                tsslblNewSongForm.Text = "Please select an album cover image for the song.";
                return false;
            }

            return true;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {

            if (ValidateForm())
            {

                string title = TxtTitle.Text;
                string artist = TxtArtist.Text;
                DateTime releaseDate = DatePicker.Value;
                genreType genre = (genreType)CbGenre.SelectedItem;

                // This converts the genre enum to a string to pass it to the SongDTO constructor
                string genreString = genre.ToString();

                // This creates a new instance of the SongDTO and initializes the proterites with values enterd.
                SongDTO songDTO = new SongDTO(title, artist, releaseDate, genreString);

                // Later it is passes to the insertSong in the SongRepository to add a new song to the database
                if (_songRepository.InsertSong(songDTO, selectedImagePath))
                {
                    SaveSongToCSV(songDTO);

                    tsslblNewSongForm.Text = $"The song has been added successfully!";
                    LoadRecentSongsFromTheDatabse();
                    ClearControls();
                }
                else
                {
                    tsslblNewSongForm.Text = $"Sorry, failed to add the song.";
                }
            }
            else
            {
                ValidateForm();
            }
        }

        private void btnAddPicture_Click(object sender, EventArgs e)
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

                    // This will load and display the image if needed
                    SelectedCover.Image = Image.FromFile(selectedImagePath);
                }
            }
        }

        private void LoadRecentSongsFromTheDatabse()
        {
            try
            {
                List<SongDTO> recentSongs = _songRepository.GetRecentSong(3);

                lbRecent.Items.Clear();

                foreach (SongDTO song in recentSongs)
                {
                    lbRecent.Items.Add($"{song.SongTitle}, {song.Artist}, {song.Genre}, {song.ReleaseDate.ToShortDateString()}");
                }
            }
            catch (Exception ex)
            {
                tsslblNewSongForm.Text = $"Looks like something went wrong: {ex.Message}";
            }
        }

        private void NewMusic_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Owner != null)
            {
                Owner.Visible = true;
            }
        }

        private void SaveSongToCSV(SongDTO song)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(FilePath, true))
                {
                    // Format the song data and write it to the CSV file
                    string songData = $"{song.SongTitle},{song.Artist},{song.ReleaseDate},{song.Genre},{selectedImagePath}";
                    writer.WriteLine(songData);
                }
            }
            catch (Exception ex)
            {
                tsslblNewSongFormCSV.Text = $"Failed to save the song to the CSV file: {ex.Message}";
            }
        }
    }
}
