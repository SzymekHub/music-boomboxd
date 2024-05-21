using Infrastructure;
using Logic;

namespace WinFormsApp
{
    public partial class NewUsers_Form : Form
    {
        public User NewUser { get; private set; }
        private User exisitingUser;
        private UserManager userManager;
        private string selectedImagePath;

        public NewUsers_Form(UserManager um, User user = null, bool view = false)
        {
            userManager = um;
            InitializeComponent();
            InitializeComboBox();
            exisitingUser = user;
            ClearControls();
            this.StartPosition = FormStartPosition.CenterScreen;

            if (exisitingUser != null)
            {
                FillFormWithUserDetails(exisitingUser);
                //This will load and display the User profile picture
                DisplayProfilePicture(exisitingUser.ProfilePictureData);
            }

            if (view)
            {
                tbNameUser.Enabled = false;
                tbPassword.Visible = false;
                tbEmailUser.Enabled = false;
                dtpUser.Enabled = false;
                cbUserType.Enabled = false;
                cbFavGenre.Enabled = false;
                btnAddPictureAlbum.Enabled = false;
                btnAddUser.Enabled = false;
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
                        tsslblNewUserForm.Text = $"Please select an image file with .jpg or .png extension.";

                        return;
                    }

                    // Stores the selected image path
                    selectedImagePath = selectedFile;

                    // This will load and display the image if needed
                    SelectedProfileUser.Image = Image.FromFile(selectedImagePath);
                }
            }
        }

        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                //This gets the file name from the selected image path
                string profilePictureName = Path.GetFileName(selectedImagePath);
                //This gets the content type based on the file extension
                string profilePictureContentType = "";
                string extension = Path.GetExtension(selectedImagePath);
                if (extension != null)
                {
                    switch (extension.ToLower())
                    {
                        case ".jpg":
                            profilePictureContentType = "image/jpeg";
                            break;
                        case ".png":
                            profilePictureContentType = "image/png";
                            break;
                        default:
                            tsslblNewUserForm.Text = $"Wrong format!";
                            break;
                    }
                }

                //This reads the selected image file into a byte array
                byte[] profilePictureData = File.ReadAllBytes(selectedImagePath);

                //This creates a new User Object with the provided details
                User newUser = new User(
                    exisitingUser.UserID,
                    tbNameUser.Text,
                    tbPassword.Text,
                    tbEmailUser.Text,
                    (userType)cbUserType.SelectedItem,
                    dtpUser.Value,
                    (genreType)cbFavGenre.SelectedItem,
                    profilePictureName,
                    profilePictureData,
                    profilePictureContentType
                    );

                Result result = userManager.Update(newUser, exisitingUser);

                if (result.Success)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    tsslblNewUserForm.Text = result.Message;
                }
            }
        }

        private void FillFormWithUserDetails(User user)
        {
            tbNameUser.Text = user.Username;
            tbPassword.Visible = false;
            tbEmailUser.Text = user.Email;
            tbPassword.Text = user.Password;
            cbUserType.SelectedItem = user.UserType;
            dtpUser.Value = user.Birthday;
            cbFavGenre.SelectedItem = user.FavGenre;
        }

        private void DisplayProfilePicture(byte[] profilePictureData)
        {
            using (MemoryStream ms = new MemoryStream(profilePictureData))
            {
                SelectedProfileUser.Image = Image.FromStream(ms);
            }
        }

        private void ClearControls()
        {
            tbNameUser.Clear();
            tbEmailUser.Clear();
            tbPassword.Clear();
            cbUserType.SelectedIndex = 0;
            dtpUser.Value = DateTime.Now;
            cbFavGenre.SelectedIndex = 0;
            selectedImagePath = null;
            SelectedProfileUser.Image = null;
        }

        public User GetNewUser()
        {
            if (ValidateInput())
            {
                //Gets the file name form the selected image path
                string profilePictureName = Path.GetFileName(selectedImagePath);

                //Gets the content type based on the file extension
                string profilePictureContentType = "";
                string extension = Path.GetExtension(selectedImagePath);
                if (extension != null)
                {
                    switch (extension.ToLower())
                    {
                        case ".jpg":
                            profilePictureContentType = "image/jpeg";
                            break;
                        case ".png":
                            profilePictureContentType = "image/png";
                            break;
                        default:
                            tsslblNewUserForm.Text = $"Wrong format!";
                            break;
                    }
                }

                // This reads the selected image file into a byte array
                byte[] profilePictureData = File.ReadAllBytes(selectedImagePath);

                // This is a new User object that returns with the provided details
                return new User(
                     tbNameUser.Text,
                     tbPassword.Text,
                     tbEmailUser.Text,
                     (userType)cbUserType.SelectedItem,
                     dtpUser.Value,
                     (genreType)cbFavGenre.SelectedItem,
                     profilePictureName,
                     profilePictureData,
                     profilePictureContentType
                    );
            }
            else
            {
                // Return null if validation fails
                return null;
            }
        }

        public User GetUpdatedUser()
        {
            if (ValidateInput())
            {
                // Get the file name from the selected image path
                string profilePictureName = Path.GetFileName(selectedImagePath);

                // Get the content type based on the file extension
                string profilePictureContentType = "";
                string extension = Path.GetExtension(selectedImagePath);
                if (extension != null)
                {
                    switch (extension.ToLower())
                    {
                        case ".jpg":
                            profilePictureContentType = "image/jpeg";
                            break;
                        case ".png":
                            profilePictureContentType = "image/png";
                            break;
                        default:
                            tsslblNewUserForm.Text = $"Wrong format!";
                            break;
                    }
                }

                // This reads the selected image file into a byte array
                byte[] profilePictureData = File.ReadAllBytes(selectedImagePath);

                userManager.Update(
                    new User(
                        tbNameUser.Text,
                        tbPassword.Text,
                        tbEmailUser.Text,
                        (userType)cbUserType.SelectedItem,
                        dtpUser.Value,
                        (genreType)cbFavGenre.SelectedItem,
                        profilePictureName,
                        profilePictureData,
                        profilePictureContentType),
                        exisitingUser
                    );
                return new User(
                        tbNameUser.Text,
                        tbPassword.Text,
                        tbEmailUser.Text,
                        (userType)cbUserType.SelectedItem,
                        dtpUser.Value,
                        (genreType)cbFavGenre.SelectedItem,
                        profilePictureName,
                        profilePictureData,
                        profilePictureContentType);
                
            }
            else
            {
                // Returns null if validation fails
                return null;
            }
        }
        public bool ValidateInput()
        {
            //Try implementing validation in the classes and then call them here. Validator class that helps check the data validation. List of validation.

            //Validate UserName
            if (string.IsNullOrWhiteSpace(tbNameUser.Text))
            {
                tsslblNewUserForm.Text = $"Every User needs a name";
                return false;
            }

            //Validate User Email
            if (string.IsNullOrWhiteSpace(tbEmailUser.Text) || !IsValidEmail(tbEmailUser.Text))
            {
                tsslblNewUserForm.Text = $"Please enter a valid email address";
                return false;
            }

            //Validate User Birthday
            if (dtpUser.Value == DateTime.Now || dtpUser.Value > DateTime.Now)
            {
                tsslblNewUserForm.Text = $"Please select a realisitc birthdate";
                return false;
            }

            //Validate favorite Genre
            if (cbFavGenre.SelectedItem == null)
            {
                tsslblNewUserForm.Text = $"Please select at least one favorite genre";
                return false;
            }

            // All validation passes, return true
            return true;
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public void InitializeComboBox()
        {
            //populates the favorite genre combo box
            cbFavGenre.DataSource = (Enum.GetValues(typeof(genreType)));
            //populates the user type combo box
            cbUserType.DataSource = (Enum.GetValues(typeof(userType)));
        }

        private void Users_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Owner != null)
            {
                Owner.Visible = true;
            }
        }

    }
}
