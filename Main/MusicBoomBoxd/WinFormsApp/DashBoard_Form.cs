using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Infrastructure.DTOs;
using Infrastructure;
using Logic;

namespace WinFormsApp
{
    public partial class DashBoard_Form : Form
    {

        //for the Album tab
        private static AlbumManager albumManager;
        private static AlbumRepository albumRepository;
        private static List<Album> albumsList = new List<Album>();

        //For the Song tab
        private static SongManager songManager;
        private static SongRepository songRepository;
        private static List<Song> songList = new List<Song>();

        public DashBoard_Form(string adminUsername, AlbumManager am, SongManager sm)
        {
            InitializeComponent();
            //This is for the album page
            albumManager = am;
            albumRepository = new AlbumRepository();
            InitializeAlbumManager();
            SetUpDataGridViewAlbums();
            PopulateAlbums();

            //This is for the song page
            songManager = sm;
            songRepository = new SongRepository();
            InitializeSongManager();
            SetUpDataGridViewSongs();
            PopulateSongs();

            lblHello.Text = $"Hello, {adminUsername}";
            tsslblDashBoardForm.Text = $"Hello, {adminUsername}";

            #region Tags
            //Tags
            btnReviews.Tag = "Reviews";
            btnUsers.Tag = "Users";
            btnSongs.Tag = "Songs";
            btnAlbums.Tag = "Albums";
            btnLogOut.Tag = "LogOut";
            #endregion

            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void InitializeAlbumManager()
        {
            // Create an instance of LoadAlbumsFromDataBase with the AlbumRepository instance
            LoadAlbumsFromDataBase loadAlbumsFromDataBase = new LoadAlbumsFromDataBase(albumRepository);

            // If albumManager is null, create a new instance with the LoadAlbumsFromDataBase instance
            albumManager = new AlbumManager(loadAlbumsFromDataBase);

            // Load albums from the database
            albumManager.LoadAlbumsFromDatabase();
        }

        private void InitializeSongManager()
        {
            // Create an instance of LoadSongsFromDataBase with the SongRepository instance
            LoadSongsFromDataBase loadSongsFromDataBase = new LoadSongsFromDataBase(songRepository);

            // If SongManager is null, create a new instance with the LoadSongFromDataBase instance
            songManager = new SongManager(loadSongsFromDataBase);

            // Load songs from the database
            songManager.LoadSongsFromDataBase();
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
        private void DashBoard_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Visible = true;
        }

        #region Users
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            NewUsers_Form users_form = new NewUsers_Form();
            users_form.Owner = this;
            this.Visible = false;
            users_form.Show();
        }

        #endregion

        #region Songs
        private void SetUpDataGridViewSongs()
        {
            // Clear existing columns
            dgvAlbums.Columns.Clear();

            // Set DataGridView properties
            dgvSongs.AutoGenerateColumns = false;
            dgvSongs.AllowUserToAddRows = false;

            // Add the DataGridView Columns if they don't already exist
            if (dgvSongs.Columns["Title"] == null)
            {
                dgvSongs.Columns.Add("Title", "Title");
                dgvSongs.Columns["Title"].DataPropertyName = "Title";
            }

            if (dgvSongs.Columns["Artist"] == null)
            {
                dgvSongs.Columns.Add("Artist", "Artist");
                dgvSongs.Columns["Artist"].DataPropertyName = "Artist";
            }

            if (dgvSongs.Columns["Genre"] == null)
            {
                dgvSongs.Columns.Add("Genre", "Genre");
                dgvSongs.Columns["Genre"].DataPropertyName = "Genre";
            }

            if (dgvSongs.Columns["Date"] == null)
            {
                dgvSongs.Columns.Add("Date", "Date");
                dgvSongs.Columns["Date"].DataPropertyName = "Date";
            }

            if (dgvSongs.Columns["SongCoverName"] == null)
            {
                dgvSongs.Columns.Add("SongCoverName", "SongCoverName");
                dgvSongs.Columns["SongCoverName"].DataPropertyName = "SongCoverName";
            }

            // Bind the list of Songs from SongManager to the DataGridView
            dgvSongs.DataSource = songManager.GetArray();
        }

        private void PopulateSongs()
        {
            //This will populate the form with exisiting Songs
            dgvSongs.DataSource = songManager.GetArray();
        }

        private void btnAddSong_Click(object sender, EventArgs e)
        {
            // Open the NewSong_Form
            using (NewSong_Form addSongForm = new NewSong_Form(songManager))
            {
                // Show the addSongForm
                if (addSongForm.ShowDialog() == DialogResult.OK)
                {
                    // Get the newly created Song from the addSongForm
                    Song newSong = addSongForm.GetNewSong();

                    // Check if a new Song was created
                    if (newSong != null)
                    {
                        // Add the new employee to the SongManager
                        songManager.Add(newSong);

                        // Update the DataGridView
                        dgvSongs.DataSource = songManager.GetArray();
                    }
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
                using (NewSong_Form addSongForm = new NewSong_Form(songManager, selectedSong))
                {
                    if (addSongForm.ShowDialog() == DialogResult.OK)
                    {
                        // Update the Song with the modified information
                        Song updatedSong = addSongForm.GetUpdatedSong();
                        if (updatedSong != null)
                        {
                            songManager.UpdateSong(updatedSong, selectedSong);
                            dgvSongs.DataSource = songManager.GetArray();
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
                using (NewSong_Form addSongForm = new NewSong_Form(songManager, selectedSong, true))
                {
                    if (addSongForm.ShowDialog() == DialogResult.OK)
                    {
                        // Update the Song with the modified information
                        Song updatedSong = addSongForm.GetUpdatedSong();
                        if (updatedSong != null)
                        {
                            songManager.UpdateSong(updatedSong, selectedSong);
                            dgvSongs.DataSource = songManager.GetArray();
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

                // This removes the selected song from the SongManager
                songManager.Remove(selectedSong);

                // This updates the DataGridView
                dgvSongs.DataSource = songManager.GetArray();

                // This remvoes the song from the database
                RemoveSongFromDatabase(selectedSong);
            }
            else
            {
                tsslblDashBoardForm.Text = "Please select an Song to delete.";
            }
        }
        private void RemoveSongFromDatabase(Song song)
        {
            bool success = songRepository.DeleteSong(song.Title, song.Artist, song.Date, song.Genre.ToString());

            if (success)
            {
                tsslblDashBoardForm.Text = " The song has been deleted successfully";
            }
            else
            {
                tsslblDashBoardForm.Text = "Something went wrong when tryig to delete this song";
            }
        }

        #endregion

        #region Albums

        private void SetUpDataGridViewAlbums()
        {
            // Clear existing columns
            dgvAlbums.Columns.Clear();

            // Set DataGridView properties
            dgvAlbums.AutoGenerateColumns = false;
            dgvAlbums.AllowUserToAddRows = false;

            // Add the DataGridView Columns if they don't already exist
            if (dgvAlbums.Columns["Title"] == null)
            {
                dgvAlbums.Columns.Add("Title", "Title");
                dgvAlbums.Columns["Title"].DataPropertyName = "Title";
            }

            if (dgvAlbums.Columns["Artist"] == null)
            {
                dgvAlbums.Columns.Add("Artist", "Artist");
                dgvAlbums.Columns["Artist"].DataPropertyName = "Artist";
            }

            if (dgvAlbums.Columns["Genre"] == null)
            {
                dgvAlbums.Columns.Add("Genre", "Genre");
                dgvAlbums.Columns["Genre"].DataPropertyName = "Genre";
            }

            if (dgvAlbums.Columns["Date"] == null)
            {
                dgvAlbums.Columns.Add("Date", "Date");
                dgvAlbums.Columns["Date"].DataPropertyName = "Date";
            }

            if (dgvAlbums.Columns["AlbumCoverName"] == null)
            {
                dgvAlbums.Columns.Add("AlbumCoverName", "AlbumCoverName");
                dgvAlbums.Columns["AlbumCoverName"].DataPropertyName = "AlbumCoverName";
            }

            // Bind the list of albums from albumManager to the DataGridView
            dgvAlbums.DataSource = albumManager.GetArray();
        }

        private void PopulateAlbums()
        {
            //This will populate the form with exisiting albums
            dgvAlbums.DataSource = albumManager.GetArray();
        }

        private void bntAddAlbum_Click(object sender, EventArgs e)
        {
            // Open the NewAlbum_Form
            using (NewAlbum_Form addAlbumForm = new NewAlbum_Form(albumManager))
            {
                // Show the addAlbumForm
                if (addAlbumForm.ShowDialog() == DialogResult.OK)
                {
                    // Get the newly created album from the addAlbumForm
                    Album newAlbum = addAlbumForm.GetNewAlbum();

                    // Check if a new album was created
                    if (newAlbum != null)
                    {
                        // Add the new employee to the albumManager
                        albumManager.Add(newAlbum);

                        // Update the DataGridView
                        dgvAlbums.DataSource = albumManager.GetArray();
                    }
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
                using (NewAlbum_Form addAlbumForm = new NewAlbum_Form( albumManager, selectedAlbum))
                {
                    if (addAlbumForm.ShowDialog() == DialogResult.OK)
                    {
                        // Update the Album with the modified information
                        Album updatedAlbum = addAlbumForm.GetUpdatedAlbum();
                        if (updatedAlbum != null)
                        {
                            albumManager.UpdateAlbum(updatedAlbum, selectedAlbum);
                            dgvAlbums.DataSource = albumManager.GetArray();
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
                using (NewAlbum_Form addAlbumForm = new NewAlbum_Form(albumManager,selectedAlbum, true))
                {
                    if (addAlbumForm.ShowDialog() == DialogResult.OK)
                    {
                        // Update the album with the modified information
                        Album updatedAlbum = addAlbumForm.GetUpdatedAlbum();
                        if (updatedAlbum != null)
                        {
                            albumManager.UpdateAlbum(updatedAlbum, selectedAlbum);
                            dgvAlbums.DataSource = albumManager.GetArray();
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

                // This removes the selected album from the AlbumManager
                albumManager.Remove(selectedAlbum);

                // This updates the DataGridView
                dgvAlbums.DataSource = albumManager.GetArray();
                
                // This remvoes the album from the database
                RemoveAlbumFromDatabase(selectedAlbum);
            }
            else
            {
                tsslblDashBoardForm.Text = "Please select an Album to delete.";
            }
        }
        private void RemoveAlbumFromDatabase(Album album)
        {
            bool success = albumRepository.DeleteAlbum(album.Title, album.Artist, album.Date, album.Genre.ToString());

            if (success)
            {
                tsslblDashBoardForm.Text = " The album has been deleted successfully";
            }
            else
            {
                tsslblDashBoardForm.Text = "Something went wrong when tryig to delete this album";
            }
        }

        #endregion
    }
}
