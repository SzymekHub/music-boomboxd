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
    public partial class Users_Form : Form
    {
        private List<User> allUsers = new List<User>();

        public Users_Form()
        {
            InitializeComponent();
            InitializeComboBox();
            InitializeUsers();
            RefreshListBox();
        }

        public void InitializeComboBox()
        {
            CbUsers.DataSource = Enum.GetValues(typeof(userType));
            CbUsers.SelectedItem = userType.All;
        }

        private void InitializeUsers()
        {
            //For now I am hardcoding the users in categorize
            allUsers.AddRange(new User[] {
                new User(1, "Paul","paul@example.com", "password", userType.Artist),
                new User(2, "Amy","amy@example.com", "password", userType.Artist),
                new User(3, "Ringo","ring@example.com", "password", userType.Artist),
                new User(4, "George", "george@example.com", "password", userType.Artist),
                new User(5, "Ruby","ruby@example.com", "password", userType.Artist),
                new User(6,"Scrim","scrim@example.com", "password", userType.Artist),
                new User(7, "Mac","mac@example.com", "password", userType.Artist),
                new User(8, "BoopeDooper","booper@example.com", "password", userType.Amateur),
                new User(9, "MusicLover1234","musiclove@example.com", "password", userType.Amateur),
                new User(10, "IhateTechno3","hatetechno@example.com", "password", userType.Amateur),
                new User(11, "IloveMac","lovemac@example.com", "password", userType.Amateur),
                new User(12, "Gustav", "gustav@example.com", "password", userType.Professional),
                new User(13, "Austin", "austin@example.com", "passsword", userType.Professional)
            });
        }
        private void RefreshListBox()
        {
            lbUsers.Items.Clear();
            userType selectedType = (userType)CbUsers.SelectedItem;

            IEnumerable<User> filteredUsers = allUsers;

            if (selectedType != userType.All)
            {
                filteredUsers = filteredUsers.Where(user => user.UserType == selectedType);
            }

            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                filteredUsers = filteredUsers.Where(user => user.UserName.ToLower().Contains(txtSearch.Text.ToLower()));
            }

            foreach (User user in filteredUsers)
            {
                lbUsers.Items.Add(user.UserName);
            }
        }

        private void CbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshListBox();
        }
        private void Users_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Visible = true;
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshListBox();
        }

    }
}
