using Infrastructure;
using Infrastructure.DTOs;
using Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class NewAlbum_Form : Form
    {
        public Album NewAlbum { get; private set; }
        private Album exisitingAlbum;
        private AlbumManager albumManager;
        private const string FilePath = "./NewAlbum.CSV";
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
            }

            if (view)
            {
                //to do later
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnAddAlbum_Click(object sender, EventArgs e)
        {
            //this validates the input data
            if (ValidateForm())
            {
                Review albumReview = new Review();

                Comment albumComment = new Comment();

                Album newAlbum = new Album(
                      TxtArtistAlbum.Text,
                      TxtTitleAlbum.Text,
                      DatePickerAlbum.Value,
                      CbGenreAlbum.SelectedItem,
                      albumReview,
                      albumComment
                    );
                //string title = TxtTitleAlbum.Text;
                //string artist = TxtArtistAlbum.Text;
                //DateTime releaseDate = DatePickerAlbum.Value;
                //genreType genre = (genreType)CbGenreAlbum.SelectedItem;

                //// Get the file name from the selected image path
                //string albumCoverName = Path.GetFileName(selectedImagePath);

                //// Get the content type based on the file extension
                //string albumCoverContentType = "";
                //string extension = Path.GetExtension(selectedImagePath);
                //if (extension != null)
                //{
                //    switch (extension.ToLower())
                //    {
                //        case ".jpg":
                //            albumCoverContentType = "image/jpeg";
                //            break;
                //        case ".png":
                //            albumCoverContentType = "image/png";
                //            break;
                //        default:
                //            tsslblNewAlbumForm.Text = $"Wrong format!";
                //            break;
                //    }
                //}

                //// This reads the selected image file into a byte array
                //byte[] albumCoverData = File.ReadAllBytes(selectedImagePath);

                //// This converts the genre enum to a string to pass it to the AlbumDTO constructor
                //string genreString = genre.ToString();

                //// This creates a new instance of the AlbumDTO and initializes the properties with values entered.
                //AlbumDTO albumDTO = new AlbumDTO(title, artist, releaseDate, genreString, albumCoverName, albumCoverData, albumCoverContentType);

                //// This calls the InsertAlbum method with the album DTO
                //if (_albumRepository.InsertAlbum(albumDTO))
                //{
                //    SaveAlbumToCSV(albumDTO);

                //    tsslblNewAlbumForm.Text = $"The album has been added successfully!";
                //    ClearControls();
                //}
                //else
                //{
                //    tsslblNewAlbumForm.Text = $"Sorry, failed to add the album.";
                //}
            }
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

                    // This will load and display the image if needed
                    SelectedCoverAlbum.Image = Image.FromFile(selectedImagePath);
                }
            }
        }

        private void ClearControls()
        {
            TxtTitleAlbum.Clear();
            TxtArtistAlbum.Clear();
            DatePickerAlbum.Value = DateTime.Now;
            CbGenreAlbum.SelectedIndex = 0;
            selectedImagePath = null;
            SelectedCoverAlbum.Image = null;
        }

        public void InitializeComboBox()
        {
            CbGenreAlbum.DataSource = Enum.GetValues(typeof(genreType));
        }

        private bool ValidateForm()
        {
            // Checks if the title is provided
            if (string.IsNullOrEmpty(TxtTitleAlbum.Text))
            {
                tsslblNewAlbumForm.Text = "Every Album needs a title. Please enter one.";
                return false;
            }

            // Checks if the artist is provided
            if (string.IsNullOrEmpty(TxtArtistAlbum.Text))
            {
                tsslblNewAlbumForm.Text = "Every Album needs an artist. Please enter one.";
                return false;
            }

            // Checks if a genre is selected
            if (CbGenreAlbum.SelectedItem == null)
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
       
        private void SaveAlbumToCSV(AlbumDTO album)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(FilePath, true))
                {
                    // Format the album data and write it to the CSV file
                    string albumData = $"{album.AlbumTitle},{album.Artist},{album.ReleaseDate},{album.Genre},{selectedImagePath}";
                    writer.WriteLine(albumData);
                }
            }
            catch (Exception ex)
            {
                tsslblNewAlbumFormCSV.Text = $"Failed to save the song to the CSV file: {ex.Message}";
            }
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
