using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic;

namespace WinFormsApp
{
    public partial class DashBoard_Form : Form
    {
        public DashBoard_Form(string adminUsername)
        {
            InitializeComponent();
            lblHello.Text = $"Hello, {adminUsername}";
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            Users_Form users_form = new Users_Form();
            users_form.Owner = this;
            this.Visible = false;
            users_form.Show();
        }

        private void btnMusic_Click(object sender, EventArgs e)
        {

        }

        private void btnReviews_Click(object sender, EventArgs e)
        {

        }

        private void DashBoard_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Visible = true;
        }
    }
}
