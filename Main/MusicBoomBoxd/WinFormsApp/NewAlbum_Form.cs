using Infrastructure;
using Infrastructure.DTOs;
using Logic;
using System.IO;
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
        //private const string FilePath = "./NewAlbum.CSV";
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
                tbTitleAlbum.Enabled = false;
                DatePickerAlbum.Enabled = false;
                tbArtistAlbum.Enabled = false;
                cbGenreAlbum.Enabled = false;
                btnAddPictureAlbum.Enabled = false;
                btnAddAlbum.Enabled = false;
                SelectedCoverAlbum.Image = Image.FromFile(selectedImagePath);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
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
                      tbTitleAlbum.Text,
                      tbArtistAlbum.Text,
                      DatePickerAlbum.Value,
                      (genreType)cbGenreAlbum.SelectedItem,
                      albumCoverName,
                      albumCoverData,
                      albumCoverContentType
                );

                if (exisitingAlbum != null)
                {
                    albumManager.UpdateAlbum(newAlbum, exisitingAlbum);

                }
                else
                {
                    MessageBox.Show($"Looks like something went worng :( ", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }

                DialogResult = DialogResult.OK;
                Close();
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

                    // This will load and display the image
                    SelectedCoverAlbum.Image = Image.FromFile(selectedImagePath);
                }
            }
        }

        private void FillFormWithAlbumDetails(Album album)
        {
            tbTitleAlbum.Text = album.Title;
            tbArtistAlbum.Text = album.Artist;
            DatePickerAlbum.Value = album.Date;
            cbGenreAlbum.SelectedItem = album.Genre;
            //Don't know how to do it for the picture. So please do it 
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

                // Create and return a new Album object with the provided details
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

                albumManager.UpdateAlbum(
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
                // Return null if validation fails
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

        //private void SaveAlbumToCSV(AlbumDTO album)
        //{
        //    try
        //    {
        //        using (StreamWriter writer = new StreamWriter(FilePath, true))
        //        {
        //            // Format the album data and write it to the CSV file
        //            string albumData = $"{album.AlbumTitle},{album.Artist},{album.ReleaseDate},{album.Genre},{selectedImagePath}";
        //            writer.WriteLine(albumData);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        tsslblNewAlbumFormCSV.Text = $"Failed to save the song to the CSV file: {ex.Message}";
        //    }
        //}

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
