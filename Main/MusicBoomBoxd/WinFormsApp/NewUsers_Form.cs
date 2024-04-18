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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WinFormsApp
{
    public partial class NewUsers_Form : Form
    {
        private List<User> allUsers;

        public NewUsers_Form()
        {
            InitializeComponent();
            chklbFavGenre.DataSource = (Enum.GetValues(typeof(genreType)));
            CbUserType.DataSource = (Enum.GetValues(typeof(userType)));
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Users_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Visible = true;
        }

        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {

            }
        }

        private void btnAddPictureAlbum_Click(object sender, EventArgs e)
        {

        }
        public bool ValidateInput()
        {
            //Validate UserName
            if (string.IsNullOrWhiteSpace(TxtNameUser.Text))
            {
                tsslblNewUserForm.Text = $"Every User needs a name";
                return false;
            }

            //Validate User Email
            if (string.IsNullOrWhiteSpace(TxtEmailUser.Text) || !IsValidEmail(TxtEmailUser.Text))
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
            if (chklbFavGenre.SelectedItems == null)
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
    }
}
