using Logic;


namespace WinFormsApp
{
    public partial class NewMusic_Form : Form
    {
        private const string FilePath = "./NewMusic.CSV";
        public NewMusic_Form()
        {
            InitializeComponent();
            InitializeComboBox();
            LoadRecentSongs();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public void InitializeComboBox()
        {
            CbGenre.DataSource = Enum.GetValues(typeof(genreType));

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string title = TxtTitle.Text;
            string artist = TxtArtist.Text;
            DateTime releaseDate = DatePicker.Value;
            genreType genre = (genreType)CbGenre.SelectedItem;

            Song song = new Song
            {
                Title = title,
                Artist = artist,
                ReleaseDate = releaseDate,
                GenreType = genre,
            };

            SaveSongToCSV(song);

            LoadRecentSongs();
        }

        private void SaveSongToCSV(Song song)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(FilePath, true))
                {
                    writer.WriteLine($"Title: {song.Title}, Artist: {song.Artist}, Genre: {song.GenreType}, ReleaseDate: {song.ReleaseDate.ToShortDateString()}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Looks like an error occurd. {ex.Message}");
            }
        }

        private void LoadRecentSongs()
        {
            try
            {
                //This will read the last 3 songs in the csv and add them to the list
                List<string> recentSongs = File.ReadAllLines(FilePath).Reverse().Take(3).ToList();

                lbRecent.Items.Clear();

                foreach(string songData in recentSongs)
                {
                    string[] songFields = songData.Split(',');
                    string title = songFields[0];
                    string artist = songFields[1];
                    string genre = songFields[2];
                    string releaseDate = songFields[3];

                    lbRecent.Items.Add($"{title}, {artist}, {genre}, {releaseDate}");
                }

            }
            catch ( Exception ex )
            {
                MessageBox.Show($"Looks like an error occurd. {ex.Message}");
            }
        }

        private void NewMusic_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Visible = true;
        }
    }
}
