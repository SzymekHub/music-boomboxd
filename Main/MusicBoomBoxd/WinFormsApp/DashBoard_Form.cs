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
        AlbumRepository _albumRepository = new AlbumRepository();

        public DashBoard_Form(string adminUsername)
        {
            InitializeComponent();

            //This is for the album page
            SetUpDataGridViewAlbums();
            PopulateAlbums();

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
            PopulateDataGridViewWithRecentAlbums();
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


        private void btnAddUser_Click(object sender, EventArgs e)
        {
            NewUsers_Form users_form = new NewUsers_Form();
            users_form.Owner = this;
            this.Visible = false;
            users_form.Show();
        }

        private void DashBoard_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Visible = true;
        }

        private void ButtonLogOut_Click(object sender, EventArgs e)
        {
            if (Owner != null)
            {
                Owner.Visible = true;
            }
            this.Close();
        }

        #region Songs
        private void btnAddSong_Click(object sender, EventArgs e)
        {
            NewSong_Form music_form = new NewSong_Form();
            music_form.Owner = this;
            this.Visible = false;
            music_form.Show();
        }
        #endregion

        #region Albums
        private void bntAddAlbum_Click(object sender, EventArgs e)
        {
            NewAlbum_Form album_form = new NewAlbum_Form();
            album_form.Owner = this;
            this.Visible = false;
            album_form.Show();
        }

        private void SetUpDataGridViewAlbums()
        {
            dgvAlbums.AutoGenerateColumns = false;
            dgvAlbums.AllowUserToAddRows = false;

            //Add the DataGridViewCollumns
            dgvAlbums.Columns.Add("Title", "Title");
            dgvAlbums.Columns["Title"].DataPropertyName = "Title";

            dgvAlbums.Columns.Add("Artist", "Artist");
            dgvAlbums.Columns["Artist"].DataPropertyName = "Artist";

            dgvAlbums.Columns.Add("Genre", "Genre");
            dgvAlbums.Columns["Genre"].DataPropertyName = "Genre";

            dgvAlbums.Columns.Add("Date", "Date");
            dgvAlbums.Columns["Date"].DataPropertyName = "Date";

            dgvAlbums.Columns.Add("AlbumCoverName", "AlbumCoverName");
            dgvAlbums.Columns["AlbumCoverName"].DataPropertyName = "AlbumCoverName";
        }

        private void PopulateAlbums()
        {

        }

        private void PopulateDataGridViewWithRecentAlbums()
        {
            try
            {
                List<AlbumDTO> recentAlbums = _albumRepository.GetRecentAlbum(3);

                // Clear existing rows
                dgvAlbums.Rows.Clear();

                // Add rows for each recent album
                foreach (AlbumDTO album in recentAlbums)
                {
                    dgvAlbums.Rows.Add(album.AlbumTitle, album.Artist, album.Genre, album.ReleaseDate.ToShortDateString(), album.AlbumCoverName);
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                tsslblDashBoardForm.Text = $"Looks like something went wrong: {ex.Message}";
            }
        }


        #endregion


    }
}
