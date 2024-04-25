namespace WinFormsApp
{
    partial class NewUsers_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            NewUserPanel = new Panel();
            btnCancel = new Button();
            chklbFavGenre = new CheckedListBox();
            dtpUser = new DateTimePicker();
            lblBirthday = new Label();
            lblFavGenre = new Label();
            SelectedProfileUser = new PictureBox();
            btnAddPictureAlbum = new Button();
            lblProfilePicUser = new Label();
            cbUserType = new ComboBox();
            btnAddUser = new Button();
            tbEmailUser = new TextBox();
            tbNameUser = new TextBox();
            lblUserType = new Label();
            lblEmailUser = new Label();
            lblNameUser = new Label();
            ssNewUserForm = new StatusStrip();
            tsslblNewUserForm = new ToolStripStatusLabel();
            lblPassword = new Label();
            tbPassword = new TextBox();
            NewUserPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SelectedProfileUser).BeginInit();
            ssNewUserForm.SuspendLayout();
            SuspendLayout();
            // 
            // NewUserPanel
            // 
            NewUserPanel.BackColor = Color.DarkGray;
            NewUserPanel.Controls.Add(tbPassword);
            NewUserPanel.Controls.Add(lblPassword);
            NewUserPanel.Controls.Add(btnCancel);
            NewUserPanel.Controls.Add(chklbFavGenre);
            NewUserPanel.Controls.Add(dtpUser);
            NewUserPanel.Controls.Add(lblBirthday);
            NewUserPanel.Controls.Add(lblFavGenre);
            NewUserPanel.Controls.Add(SelectedProfileUser);
            NewUserPanel.Controls.Add(btnAddPictureAlbum);
            NewUserPanel.Controls.Add(lblProfilePicUser);
            NewUserPanel.Controls.Add(cbUserType);
            NewUserPanel.Controls.Add(btnAddUser);
            NewUserPanel.Controls.Add(tbEmailUser);
            NewUserPanel.Controls.Add(tbNameUser);
            NewUserPanel.Controls.Add(lblUserType);
            NewUserPanel.Controls.Add(lblEmailUser);
            NewUserPanel.Controls.Add(lblNameUser);
            NewUserPanel.Location = new Point(41, 39);
            NewUserPanel.Name = "NewUserPanel";
            NewUserPanel.Size = new Size(718, 373);
            NewUserPanel.TabIndex = 14;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.MediumSlateBlue;
            btnCancel.Location = new Point(564, 203);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(127, 34);
            btnCancel.TabIndex = 41;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // chklbFavGenre
            // 
            chklbFavGenre.FormattingEnabled = true;
            chklbFavGenre.Location = new Point(256, 290);
            chklbFavGenre.Name = "chklbFavGenre";
            chklbFavGenre.Size = new Size(264, 70);
            chklbFavGenre.TabIndex = 40;
            // 
            // dtpUser
            // 
            dtpUser.Location = new Point(256, 248);
            dtpUser.Name = "dtpUser";
            dtpUser.Size = new Size(264, 27);
            dtpUser.TabIndex = 39;
            // 
            // lblBirthday
            // 
            lblBirthday.AutoSize = true;
            lblBirthday.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBirthday.Location = new Point(73, 244);
            lblBirthday.Name = "lblBirthday";
            lblBirthday.Size = new Size(181, 33);
            lblBirthday.TabIndex = 38;
            lblBirthday.Text = "Birthday :";
            // 
            // lblFavGenre
            // 
            lblFavGenre.AutoSize = true;
            lblFavGenre.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFavGenre.Location = new Point(66, 290);
            lblFavGenre.Name = "lblFavGenre";
            lblFavGenre.Size = new Size(187, 33);
            lblFavGenre.TabIndex = 36;
            lblFavGenre.Text = "Fav Genre :";
            // 
            // SelectedProfileUser
            // 
            SelectedProfileUser.Location = new Point(259, 7);
            SelectedProfileUser.Name = "SelectedProfileUser";
            SelectedProfileUser.Size = new Size(82, 78);
            SelectedProfileUser.SizeMode = PictureBoxSizeMode.Zoom;
            SelectedProfileUser.TabIndex = 34;
            SelectedProfileUser.TabStop = false;
            // 
            // btnAddPictureAlbum
            // 
            btnAddPictureAlbum.BackColor = Color.MediumSlateBlue;
            btnAddPictureAlbum.Location = new Point(396, 34);
            btnAddPictureAlbum.Name = "btnAddPictureAlbum";
            btnAddPictureAlbum.Size = new Size(97, 30);
            btnAddPictureAlbum.TabIndex = 32;
            btnAddPictureAlbum.Text = "Add Picture";
            btnAddPictureAlbum.UseVisualStyleBackColor = false;
            btnAddPictureAlbum.Click += btnAddPictureAlbum_Click;
            // 
            // lblProfilePicUser
            // 
            lblProfilePicUser.AutoSize = true;
            lblProfilePicUser.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProfilePicUser.Location = new Point(51, 30);
            lblProfilePicUser.Name = "lblProfilePicUser";
            lblProfilePicUser.Size = new Size(202, 33);
            lblProfilePicUser.TabIndex = 31;
            lblProfilePicUser.Text = "Profile Pic:";
            // 
            // cbUserType
            // 
            cbUserType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbUserType.FormattingEnabled = true;
            cbUserType.Location = new Point(256, 202);
            cbUserType.Name = "cbUserType";
            cbUserType.Size = new Size(264, 28);
            cbUserType.TabIndex = 20;
            // 
            // btnAddUser
            // 
            btnAddUser.BackColor = Color.MediumSlateBlue;
            btnAddUser.Location = new Point(564, 140);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(127, 57);
            btnAddUser.TabIndex = 19;
            btnAddUser.Text = "Add User";
            btnAddUser.UseVisualStyleBackColor = false;
            btnAddUser.Click += BtnAddUser_Click;
            // 
            // tbEmailUser
            // 
            tbEmailUser.Location = new Point(256, 130);
            tbEmailUser.Name = "tbEmailUser";
            tbEmailUser.Size = new Size(264, 27);
            tbEmailUser.TabIndex = 17;
            // 
            // tbNameUser
            // 
            tbNameUser.Location = new Point(256, 91);
            tbNameUser.Name = "tbNameUser";
            tbNameUser.Size = new Size(264, 27);
            tbNameUser.TabIndex = 16;
            // 
            // lblUserType
            // 
            lblUserType.AutoSize = true;
            lblUserType.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserType.Location = new Point(66, 197);
            lblUserType.Name = "lblUserType";
            lblUserType.Size = new Size(188, 33);
            lblUserType.TabIndex = 14;
            lblUserType.Text = "User Type :";
            // 
            // lblEmailUser
            // 
            lblEmailUser.AutoSize = true;
            lblEmailUser.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmailUser.Location = new Point(133, 124);
            lblEmailUser.Name = "lblEmailUser";
            lblEmailUser.Size = new Size(119, 33);
            lblEmailUser.TabIndex = 13;
            lblEmailUser.Text = "Email :";
            // 
            // lblNameUser
            // 
            lblNameUser.AutoSize = true;
            lblNameUser.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNameUser.Location = new Point(66, 91);
            lblNameUser.Name = "lblNameUser";
            lblNameUser.Size = new Size(186, 33);
            lblNameUser.TabIndex = 12;
            lblNameUser.Text = "Username :";
            // 
            // ssNewUserForm
            // 
            ssNewUserForm.BackColor = Color.MediumSlateBlue;
            ssNewUserForm.ImageScalingSize = new Size(20, 20);
            ssNewUserForm.Items.AddRange(new ToolStripItem[] { tsslblNewUserForm });
            ssNewUserForm.Location = new Point(0, 428);
            ssNewUserForm.Name = "ssNewUserForm";
            ssNewUserForm.Size = new Size(800, 22);
            ssNewUserForm.TabIndex = 15;
            ssNewUserForm.Text = "statusStrip1";
            // 
            // tsslblNewUserForm
            // 
            tsslblNewUserForm.ActiveLinkColor = Color.LavenderBlush;
            tsslblNewUserForm.BackColor = Color.MediumSlateBlue;
            tsslblNewUserForm.ForeColor = Color.LavenderBlush;
            tsslblNewUserForm.Name = "tsslblNewUserForm";
            tsslblNewUserForm.Size = new Size(0, 16);
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPassword.Location = new Point(65, 157);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(187, 33);
            lblPassword.TabIndex = 42;
            lblPassword.Text = "Password :";
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(256, 163);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(264, 27);
            tbPassword.TabIndex = 43;
            // 
            // NewUsers_Form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumSlateBlue;
            ClientSize = new Size(800, 450);
            Controls.Add(ssNewUserForm);
            Controls.Add(NewUserPanel);
            Name = "NewUsers_Form";
            Text = "Users_Form";
            FormClosed += Users_Form_FormClosed;
            NewUserPanel.ResumeLayout(false);
            NewUserPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SelectedProfileUser).EndInit();
            ssNewUserForm.ResumeLayout(false);
            ssNewUserForm.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel NewUserPanel;
        private PictureBox SelectedProfileUser;
        private Button btnAddPictureAlbum;
        private Label lblProfilePicUser;
        private ComboBox cbUserType;
        private Button btnAddUser;
        private TextBox tbEmailUser;
        private TextBox tbNameUser;
        private Label lblUserType;
        private Label lblEmailUser;
        private Label lblNameUser;
        private Label lblFavGenre;
        private CheckedListBox chklbFavGenre;
        private DateTimePicker dtpUser;
        private Label lblBirthday;
        private StatusStrip ssNewUserForm;
        private ToolStripStatusLabel tsslblNewUserForm;
        private Button btnCancel;
        private TextBox tbPassword;
        private Label lblPassword;
    }
}