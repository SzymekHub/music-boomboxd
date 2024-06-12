using Infrastructure;
using Logic;

namespace WinFormsApp
{
	public partial class NewArtist_Form : Form
	{
		private bool isNewImageSelected = false;

		public Artist NewArtist { get; private set; }
		private Artist existingArtist;
		private ArtistManager artistManager;
		private string selectedImagePath;

		public NewArtist_Form(ArtistManager am, Artist artist = null, bool view = false)
		{
			artistManager = am;
			InitializeComponent();
			existingArtist = artist;
			ClearControls();
			this.StartPosition = FormStartPosition.CenterScreen;

			if (existingArtist != null)
			{
				FillFormWithArtistDetails(existingArtist);
				DisplayArtistCover(existingArtist.ArtistPictureData);
			}

			if (view)
			{
				tbNameArtist.Enabled = false;
				btnAddArtist.Enabled = false;
				btnAddProfileArtist.Enabled = false;
			}
		}

		private void btnCancelArtist_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void btnAddProfileArtist_Click(object sender, EventArgs e)
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
						tsslblNewArtistForm.Text = $"Please select an image file with .jpg or .png extension.";

						return;
					}

					// Stores the selected image path
					selectedImagePath = selectedFile;
					isNewImageSelected = true;

					// This will load and display the image
					SelectedProfileArtist.Image = Image.FromFile(selectedImagePath);
				}
			}
		}

		private void btnAddArtist_Click(object sender, EventArgs e)
		{
			if (ValidateForm())
			{
				// This gets the file name from the selected image path
				string artistProfileName = isNewImageSelected ? Path.GetFileName(selectedImagePath) : existingArtist.ArtistPictureName;

				// This gets the content type based on the file extension
				string artistProfileContentType = "";
				string extension = Path.GetExtension(artistProfileName);
				if (extension != null)
				{
					switch (extension.ToLower())
					{
						case ".jpg":
							artistProfileContentType = "image/jpeg";
							break;
						case ".png":
							artistProfileContentType = "image/png";
							break;
						default:
							tsslblNewArtistForm.Text = $"Wrong format!";
							break;
					}
				}
				// This reads the selected image file into a byte array
				byte[] artistProfileData = isNewImageSelected ? File.ReadAllBytes(selectedImagePath) : existingArtist.ArtistPictureData;

				if (existingArtist == null)
				{
					NewArtist = new Artist(
						tbNameArtist.Text,
						artistProfileName,
						artistProfileData,
						artistProfileContentType
					);
				}
				else
				{
					NewArtist = new Artist(
						existingArtist.ArtistID,
						tbNameArtist.Text,
						artistProfileName,
						artistProfileData,
						artistProfileContentType
					);
				}
				
				Result result = artistManager.Update(NewArtist);

				if (result.Success)
				{
					DialogResult = DialogResult.OK;
					Close();
				}
				else
				{
					tsslblNewArtistForm.Text = result.Message;
				}
			}
		}
		private void FillFormWithArtistDetails(Artist artist)
		{
			tbNameArtist.Text = artist.Name;
		}

		private void DisplayArtistCover(byte[] artistProfileData)
		{
			using (MemoryStream ms = new MemoryStream(artistProfileData))
			{
				SelectedProfileArtist.Image = Image.FromStream(ms);
			}
		}

		private void ClearControls()
		{
			tbNameArtist.Clear();
			selectedImagePath = null;
			SelectedProfileArtist.Image = null;
			isNewImageSelected = false;
		}

		public Artist GetUpdatedArtist()
		{
			if (ValidateForm())
			{
				// This gets the file name from the selected image path
				string artistProfileName = isNewImageSelected ? Path.GetFileName(selectedImagePath) : existingArtist?.ArtistPictureName;

				// This gets the content type based on the file extension
				string artistProfileContentType = "";
				string extension = Path.GetExtension(artistProfileName);
				if (extension != null)
				{
					switch (extension.ToLower())
					{
						case ".jpg":
							artistProfileContentType = "image/jpeg";
							break;
						case ".png":
							artistProfileContentType = "image/png";
							break;
						default:
							tsslblNewArtistForm.Text = $"Wrong format!";
							break;
					}
				}
				// This reads the selected image file into a byte array
				byte[] artistProfileData = isNewImageSelected ? File.ReadAllBytes(selectedImagePath) : existingArtist?.ArtistPictureData;
				
				artistManager.Update(
					new Artist(
						existingArtist.ArtistID,
						tbNameArtist.Text,
						artistProfileName,
						artistProfileData,
						artistProfileContentType)
					);
				return new Artist(
						existingArtist.ArtistID,
						tbNameArtist.Text,
						artistProfileName,
						artistProfileData,
						artistProfileContentType);
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
			if (string.IsNullOrEmpty(tbNameArtist.Text))
			{
				tsslblNewArtistForm.Text = "Every Artist needs a title. Please enter one.";
				return false;
			}

			// Checks if an image is selected
			if (!isNewImageSelected && (existingArtist == null || existingArtist.ArtistPictureName == null))
			{
				tsslblNewArtistForm.Text = "Please select an album cover image for the Album.";
				return false;
			}

			return true;
		}

		private void NewArtist_Form_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (Owner != null)
			{
				Owner.Visible = true;
			}
		}
	}
}
