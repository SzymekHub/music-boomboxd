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
        private List<User> allUsers;

        public Users_Form()
        {
            InitializeComponent();
            InitializeComboBox();
            RefreshListBox();
        }

        public void InitializeComboBox()
        {
            CbUsers.DataSource = Enum.GetValues(typeof(userType));
            CbUsers.SelectedItem = userType.All;
        }
        private void RefreshListBox()
        {
            lbUsers.Items.Clear();
            allUsers = User.InitializeUsers();
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
