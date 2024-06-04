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
            lblTop5Artists = new Label();
            tbArtistSearchUser = new TextBox();
            btnRemoveArtistUser = new Button();
            lblArtistWarning = new Label();
            btnAddArtistUser = new Button();
            cklbAritstUser = new CheckedListBox();
            lblArtist = new Label();
            lblTop5Songs = new Label();
            lblTop5Albums = new Label();
            tbAlbumsSearchUser = new TextBox();
            btnRemoveAlbumUser = new Button();
            lblAlbumWarning = new Label();
            btnAddAlbumUser = new Button();
            cklbAlbumUser = new CheckedListBox();
            lblAlbumsUser = new Label();
            txtSongsSearchUsers = new TextBox();
            btnRemoveSongUser = new Button();
            lblSongWarning = new Label();
            btnAddSongsUser = new Button();
            cklbSongsUser = new CheckedListBox();
            lblSongsUsers = new Label();
            pbLogoUsers = new PictureBox();
            cbFavGenre = new ComboBox();
            tbPassword = new TextBox();
            lblPassword = new Label();
            btnCancel = new Button();
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
            NewUserPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogoUsers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SelectedProfileUser).BeginInit();
            ssNewUserForm.SuspendLayout();
            SuspendLayout();
            // 
            // NewUserPanel
            // 
            NewUserPanel.BackColor = Color.DarkGray;
            NewUserPanel.Controls.Add(lblTop5Artists);
            NewUserPanel.Controls.Add(tbArtistSearchUser);
            NewUserPanel.Controls.Add(btnRemoveArtistUser);
            NewUserPanel.Controls.Add(lblArtistWarning);
            NewUserPanel.Controls.Add(btnAddArtistUser);
            NewUserPanel.Controls.Add(cklbAritstUser);
            NewUserPanel.Controls.Add(lblArtist);
            NewUserPanel.Controls.Add(lblTop5Songs);
            NewUserPanel.Controls.Add(lblTop5Albums);
            NewUserPanel.Controls.Add(tbAlbumsSearchUser);
            NewUserPanel.Controls.Add(btnRemoveAlbumUser);
            NewUserPanel.Controls.Add(lblAlbumWarning);
            NewUserPanel.Controls.Add(btnAddAlbumUser);
            NewUserPanel.Controls.Add(cklbAlbumUser);
            NewUserPanel.Controls.Add(lblAlbumsUser);
            NewUserPanel.Controls.Add(txtSongsSearchUsers);
            NewUserPanel.Controls.Add(btnRemoveSongUser);
            NewUserPanel.Controls.Add(lblSongWarning);
            NewUserPanel.Controls.Add(btnAddSongsUser);
            NewUserPanel.Controls.Add(cklbSongsUser);
            NewUserPanel.Controls.Add(lblSongsUsers);
            NewUserPanel.Controls.Add(pbLogoUsers);
            NewUserPanel.Controls.Add(cbFavGenre);
            NewUserPanel.Controls.Add(tbPassword);
            NewUserPanel.Controls.Add(lblPassword);
            NewUserPanel.Controls.Add(btnCancel);
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
            NewUserPanel.Location = new Point(36, 25);
            NewUserPanel.Name = "NewUserPanel";
            NewUserPanel.Size = new Size(1056, 593);
            NewUserPanel.TabIndex = 14;
            // 
            // lblTop5Artists
            // 
            lblTop5Artists.AutoSize = true;
            lblTop5Artists.Font = new Font("Stencil", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTop5Artists.Location = new Point(57, 383);
            lblTop5Artists.Name = "lblTop5Artists";
            lblTop5Artists.Size = new Size(176, 24);
            lblTop5Artists.TabIndex = 67;
            lblTop5Artists.Text = "Top 5 Artists :";
            // 
            // tbArtistSearchUser
            // 
            tbArtistSearchUser.Location = new Point(213, 413);
            tbArtistSearchUser.Name = "tbArtistSearchUser";
            tbArtistSearchUser.Size = new Size(166, 27);
            tbArtistSearchUser.TabIndex = 66;
            tbArtistSearchUser.TextChanged += tbArtistSearchUser_TextChanged;
            // 
            // btnRemoveArtistUser
            // 
            btnRemoveArtistUser.BackColor = Color.MediumSlateBlue;
            btnRemoveArtistUser.Location = new Point(385, 468);
            btnRemoveArtistUser.Name = "btnRemoveArtistUser";
            btnRemoveArtistUser.Size = new Size(127, 49);
            btnRemoveArtistUser.TabIndex = 65;
            btnRemoveArtistUser.Text = "Remove Artist";
            btnRemoveArtistUser.UseVisualStyleBackColor = false;
            btnRemoveArtistUser.Click += btnRemoveArtistUser_Click;
            // 
            // lblArtistWarning
            // 
            lblArtistWarning.AutoSize = true;
            lblArtistWarning.Font = new Font("Stencil", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblArtistWarning.Location = new Point(102, 519);
            lblArtistWarning.Name = "lblArtistWarning";
            lblArtistWarning.Size = new Size(237, 54);
            lblArtistWarning.TabIndex = 64;
            lblArtistWarning.Text = "* To add a new Artist please \r\n  unselect the artists that \r\n  are already selected*\r\n";
            // 
            // btnAddArtistUser
            // 
            btnAddArtistUser.BackColor = Color.MediumSlateBlue;
            btnAddArtistUser.Location = new Point(385, 413);
            btnAddArtistUser.Name = "btnAddArtistUser";
            btnAddArtistUser.Size = new Size(127, 49);
            btnAddArtistUser.TabIndex = 63;
            btnAddArtistUser.Text = "Add Artist";
            btnAddArtistUser.UseVisualStyleBackColor = false;
            btnAddArtistUser.Click += btnAddArtistUser_Click;
            // 
            // cklbAritstUser
            // 
            cklbAritstUser.FormattingEnabled = true;
            cklbAritstUser.Location = new Point(57, 446);
            cklbAritstUser.Name = "cklbAritstUser";
            cklbAritstUser.Size = new Size(322, 70);
            cklbAritstUser.TabIndex = 62;
            // 
            // lblArtist
            // 
            lblArtist.AutoSize = true;
            lblArtist.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblArtist.Location = new Point(53, 407);
            lblArtist.Name = "lblArtist";
            lblArtist.Size = new Size(154, 33);
            lblArtist.TabIndex = 61;
            lblArtist.Text = "Artists :";
            // 
            // lblTop5Songs
            // 
            lblTop5Songs.AutoSize = true;
            lblTop5Songs.Font = new Font("Stencil", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTop5Songs.Location = new Point(555, 10);
            lblTop5Songs.Name = "lblTop5Songs";
            lblTop5Songs.Size = new Size(154, 24);
            lblTop5Songs.TabIndex = 60;
            lblTop5Songs.Text = "Top 5 Songs :";
            // 
            // lblTop5Albums
            // 
            lblTop5Albums.AutoSize = true;
            lblTop5Albums.Font = new Font("Stencil", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTop5Albums.Location = new Point(562, 286);
            lblTop5Albums.Name = "lblTop5Albums";
            lblTop5Albums.Size = new Size(172, 24);
            lblTop5Albums.TabIndex = 59;
            lblTop5Albums.Text = "Top 5 Albums :";
            // 
            // tbAlbumsSearchUser
            // 
            tbAlbumsSearchUser.Location = new Point(700, 312);
            tbAlbumsSearchUser.Name = "tbAlbumsSearchUser";
            tbAlbumsSearchUser.Size = new Size(184, 27);
            tbAlbumsSearchUser.TabIndex = 58;
            // 
            // btnRemoveAlbumUser
            // 
            btnRemoveAlbumUser.BackColor = Color.MediumSlateBlue;
            btnRemoveAlbumUser.Location = new Point(757, 502);
            btnRemoveAlbumUser.Name = "btnRemoveAlbumUser";
            btnRemoveAlbumUser.Size = new Size(127, 49);
            btnRemoveAlbumUser.TabIndex = 57;
            btnRemoveAlbumUser.Text = "Remove Album";
            btnRemoveAlbumUser.UseVisualStyleBackColor = false;
            // 
            // lblAlbumWarning
            // 
            lblAlbumWarning.AutoSize = true;
            lblAlbumWarning.Font = new Font("Stencil", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAlbumWarning.Location = new Point(574, 426);
            lblAlbumWarning.Name = "lblAlbumWarning";
            lblAlbumWarning.Size = new Size(284, 63);
            lblAlbumWarning.TabIndex = 56;
            lblAlbumWarning.Text = "* To add a new Album please \r\n  unselect the albums that \r\n  are already selected*\r\n";
            // 
            // btnAddAlbumUser
            // 
            btnAddAlbumUser.BackColor = Color.MediumSlateBlue;
            btnAddAlbumUser.Location = new Point(555, 502);
            btnAddAlbumUser.Name = "btnAddAlbumUser";
            btnAddAlbumUser.Size = new Size(127, 49);
            btnAddAlbumUser.TabIndex = 55;
            btnAddAlbumUser.Text = "Add Album";
            btnAddAlbumUser.UseVisualStyleBackColor = false;
            // 
            // cklbAlbumUser
            // 
            cklbAlbumUser.FormattingEnabled = true;
            cklbAlbumUser.Location = new Point(562, 347);
            cklbAlbumUser.Name = "cklbAlbumUser";
            cklbAlbumUser.Size = new Size(322, 70);
            cklbAlbumUser.TabIndex = 54;
            // 
            // lblAlbumsUser
            // 
            lblAlbumsUser.AutoSize = true;
            lblAlbumsUser.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAlbumsUser.Location = new Point(555, 311);
            lblAlbumsUser.Name = "lblAlbumsUser";
            lblAlbumsUser.Size = new Size(147, 33);
            lblAlbumsUser.TabIndex = 53;
            lblAlbumsUser.Text = "Albums :";
            // 
            // txtSongsSearchUsers
            // 
            txtSongsSearchUsers.Location = new Point(667, 37);
            txtSongsSearchUsers.Name = "txtSongsSearchUsers";
            txtSongsSearchUsers.Size = new Size(161, 27);
            txtSongsSearchUsers.TabIndex = 52;
            // 
            // btnRemoveSongUser
            // 
            btnRemoveSongUser.BackColor = Color.MediumSlateBlue;
            btnRemoveSongUser.Location = new Point(757, 208);
            btnRemoveSongUser.Name = "btnRemoveSongUser";
            btnRemoveSongUser.Size = new Size(127, 49);
            btnRemoveSongUser.TabIndex = 51;
            btnRemoveSongUser.Text = "Remove Songs";
            btnRemoveSongUser.UseVisualStyleBackColor = false;
            // 
            // lblSongWarning
            // 
            lblSongWarning.AutoSize = true;
            lblSongWarning.Font = new Font("Stencil", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSongWarning.Location = new Point(589, 142);
            lblSongWarning.Name = "lblSongWarning";
            lblSongWarning.Size = new Size(269, 63);
            lblSongWarning.TabIndex = 50;
            lblSongWarning.Text = "* To add a new song please \r\n  unselect the songs that \r\n  are already selected*\r\n";
            // 
            // btnAddSongsUser
            // 
            btnAddSongsUser.BackColor = Color.MediumSlateBlue;
            btnAddSongsUser.Location = new Point(562, 208);
            btnAddSongsUser.Name = "btnAddSongsUser";
            btnAddSongsUser.Size = new Size(127, 49);
            btnAddSongsUser.TabIndex = 49;
            btnAddSongsUser.Text = "Add Songs";
            btnAddSongsUser.UseVisualStyleBackColor = false;
            // 
            // cklbSongsUser
            // 
            cklbSongsUser.FormattingEnabled = true;
            cklbSongsUser.Location = new Point(562, 70);
            cklbSongsUser.Name = "cklbSongsUser";
            cklbSongsUser.Size = new Size(322, 70);
            cklbSongsUser.TabIndex = 48;
            // 
            // lblSongsUsers
            // 
            lblSongsUsers.AutoSize = true;
            lblSongsUsers.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSongsUsers.Location = new Point(555, 34);
            lblSongsUsers.Name = "lblSongsUsers";
            lblSongsUsers.Size = new Size(116, 33);
            lblSongsUsers.TabIndex = 47;
            lblSongsUsers.Text = "Songs:";
            // 
            // pbLogoUsers
            // 
            pbLogoUsers.Image = Properties.Resources.LogoBlue1;
            pbLogoUsers.Location = new Point(947, 0);
            pbLogoUsers.Name = "pbLogoUsers";
            pbLogoUsers.Size = new Size(109, 90);
            pbLogoUsers.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogoUsers.TabIndex = 45;
            pbLogoUsers.TabStop = false;
            // 
            // cbFavGenre
            // 
            cbFavGenre.FormattingEnabled = true;
            cbFavGenre.Location = new Point(238, 340);
            cbFavGenre.Name = "cbFavGenre";
            cbFavGenre.Size = new Size(262, 28);
            cbFavGenre.TabIndex = 44;
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(238, 198);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(262, 27);
            tbPassword.TabIndex = 43;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPassword.Location = new Point(52, 192);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(187, 33);
            lblPassword.TabIndex = 42;
            lblPassword.Text = "Password :";
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.MediumSlateBlue;
            btnCancel.Location = new Point(926, 311);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(127, 33);
            btnCancel.TabIndex = 41;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // dtpUser
            // 
            dtpUser.Location = new Point(238, 300);
            dtpUser.Name = "dtpUser";
            dtpUser.Size = new Size(262, 27);
            dtpUser.TabIndex = 39;
            // 
            // lblBirthday
            // 
            lblBirthday.AutoSize = true;
            lblBirthday.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBirthday.Location = new Point(57, 294);
            lblBirthday.Name = "lblBirthday";
            lblBirthday.Size = new Size(181, 33);
            lblBirthday.TabIndex = 38;
            lblBirthday.Text = "Birthday :";
            // 
            // lblFavGenre
            // 
            lblFavGenre.AutoSize = true;
            lblFavGenre.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFavGenre.Location = new Point(52, 334);
            lblFavGenre.Name = "lblFavGenre";
            lblFavGenre.Size = new Size(187, 33);
            lblFavGenre.TabIndex = 36;
            lblFavGenre.Text = "Fav Genre :";
            // 
            // SelectedProfileUser
            // 
            SelectedProfileUser.Location = new Point(245, 19);
            SelectedProfileUser.Name = "SelectedProfileUser";
            SelectedProfileUser.Size = new Size(94, 71);
            SelectedProfileUser.SizeMode = PictureBoxSizeMode.Zoom;
            SelectedProfileUser.TabIndex = 34;
            SelectedProfileUser.TabStop = false;
            // 
            // btnAddPictureAlbum
            // 
            btnAddPictureAlbum.BackColor = Color.MediumSlateBlue;
            btnAddPictureAlbum.Location = new Point(345, 38);
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
            lblProfilePicUser.Location = new Point(38, 38);
            lblProfilePicUser.Name = "lblProfilePicUser";
            lblProfilePicUser.Size = new Size(202, 33);
            lblProfilePicUser.TabIndex = 31;
            lblProfilePicUser.Text = "Profile Pic:";
            // 
            // cbUserType
            // 
            cbUserType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbUserType.FormattingEnabled = true;
            cbUserType.Location = new Point(238, 250);
            cbUserType.Name = "cbUserType";
            cbUserType.Size = new Size(262, 28);
            cbUserType.TabIndex = 20;
            // 
            // btnAddUser
            // 
            btnAddUser.BackColor = Color.MediumSlateBlue;
            btnAddUser.Location = new Point(926, 250);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(127, 57);
            btnAddUser.TabIndex = 19;
            btnAddUser.Text = "Add User";
            btnAddUser.UseVisualStyleBackColor = false;
            btnAddUser.Click += BtnAddUser_Click;
            // 
            // tbEmailUser
            // 
            tbEmailUser.Location = new Point(238, 148);
            tbEmailUser.Name = "tbEmailUser";
            tbEmailUser.Size = new Size(262, 27);
            tbEmailUser.TabIndex = 17;
            // 
            // tbNameUser
            // 
            tbNameUser.Location = new Point(238, 106);
            tbNameUser.Name = "tbNameUser";
            tbNameUser.Size = new Size(262, 27);
            tbNameUser.TabIndex = 16;
            // 
            // lblUserType
            // 
            lblUserType.AutoSize = true;
            lblUserType.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserType.Location = new Point(52, 244);
            lblUserType.Name = "lblUserType";
            lblUserType.Size = new Size(188, 33);
            lblUserType.TabIndex = 14;
            lblUserType.Text = "User Type :";
            // 
            // lblEmailUser
            // 
            lblEmailUser.AutoSize = true;
            lblEmailUser.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmailUser.Location = new Point(120, 142);
            lblEmailUser.Name = "lblEmailUser";
            lblEmailUser.Size = new Size(119, 33);
            lblEmailUser.TabIndex = 13;
            lblEmailUser.Text = "Email :";
            // 
            // lblNameUser
            // 
            lblNameUser.AutoSize = true;
            lblNameUser.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNameUser.Location = new Point(53, 100);
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
            ssNewUserForm.Location = new Point(0, 635);
            ssNewUserForm.Name = "ssNewUserForm";
            ssNewUserForm.Size = new Size(1128, 22);
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
            // NewUsers_Form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumSlateBlue;
            ClientSize = new Size(1128, 657);
            Controls.Add(ssNewUserForm);
            Controls.Add(NewUserPanel);
            Name = "NewUsers_Form";
            Text = "Users_Form";
            FormClosed += Users_Form_FormClosed;
            NewUserPanel.ResumeLayout(false);
            NewUserPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogoUsers).EndInit();
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
        private DateTimePicker dtpUser;
        private Label lblBirthday;
        private StatusStrip ssNewUserForm;
        private ToolStripStatusLabel tsslblNewUserForm;
        private Button btnCancel;
        private TextBox tbPassword;
        private Label lblPassword;
        private ComboBox cbFavGenre;
        private PictureBox pbLogoUsers;
        private TextBox txtSongsSearchUsers;
        private Button btnRemoveSongUser;
        private Label lblSongWarning;
        private Button btnAddSongsUser;
        private CheckedListBox cklbSongsUser;
        private Label lblSongsUsers;
        private TextBox tbAlbumsSearchUser;
        private Button btnRemoveAlbumUser;
        private Label lblAlbumWarning;
        private Button btnAddAlbumUser;
        private CheckedListBox cklbAlbumUser;
        private Label lblAlbumsUser;
        private Label lblTop5Songs;
        private Label lblTop5Albums;
        private Label lblTop5Artists;
        private TextBox tbArtistSearchUser;
        private Button btnRemoveArtistUser;
        private Label lblArtistWarning;
        private Button btnAddArtistUser;
        private CheckedListBox cklbAritstUser;
        private Label lblArtist;
    }
}