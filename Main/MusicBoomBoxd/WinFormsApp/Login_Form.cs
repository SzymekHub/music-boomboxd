using Infrastructure;
using Logic;

namespace WinFormsApp
{
    public partial class Login_Form : Form
    {
        private const string AdminUsername = "Admin";
        private const string AdminPassword = "p";
        public UserManager userManager { get; }
        private static AlbumManager albumManager;
        private static SongManager songManager;
        

        public Login_Form()
        {
            InitializeComponent();

            UserRepository userRep = new UserRepository();
            IUserRepository IuserRep = userRep;

            userManager = new UserManager(userRep, IuserRep);
            userManager.LoadUsersFromDataBase();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string enteredUsername = txtUsername.Text;
            string enteredPassword = txtPassword.Text;

            if (enteredUsername == AdminUsername && enteredPassword == AdminPassword)
            {
                DashBoard_Form dash_form = new DashBoard_Form(AdminUsername, userManager, albumManager, songManager);
                dash_form.Owner = this;
                dash_form.Text = "Hello" + AdminUsername;
                this.Visible = false;
                dash_form.Show();
                ClearControls();
            }
            else if (string.IsNullOrWhiteSpace(enteredUsername) || string.IsNullOrWhiteSpace(enteredPassword)) 
            {
                tsslblLoginForm.Text = "The Username and Password cannot be empty";
            }
            else
            {
                tsslblLoginForm.Text = "Looks like the Username or Password is incorrect";
            }
        }

        public void ClearControls()
        {
            txtPassword.Clear();
            txtUsername.Clear();
        }
    }
}
