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
            chklbFavGenre = new CheckedListBox();
            dtpUser = new DateTimePicker();
            label1 = new Label();
            lblFavGenre = new Label();
            SelectedProfileUser = new PictureBox();
            btnAddPictureAlbum = new Button();
            lblProfilePicUser = new Label();
            CbUserType = new ComboBox();
            BtnAddUser = new Button();
            TxtEmailUser = new TextBox();
            TxtNameUser = new TextBox();
            lblUserType = new Label();
            lblEmailUser = new Label();
            lblNameUser = new Label();
            ssNewUserForm = new StatusStrip();
            tsslblNewUserForm = new ToolStripStatusLabel();
            NewUserPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SelectedProfileUser).BeginInit();
            ssNewUserForm.SuspendLayout();
            SuspendLayout();
            // 
            // NewUserPanel
            // 
            NewUserPanel.BackColor = Color.DarkGray;
            NewUserPanel.Controls.Add(chklbFavGenre);
            NewUserPanel.Controls.Add(dtpUser);
            NewUserPanel.Controls.Add(label1);
            NewUserPanel.Controls.Add(lblFavGenre);
            NewUserPanel.Controls.Add(SelectedProfileUser);
            NewUserPanel.Controls.Add(btnAddPictureAlbum);
            NewUserPanel.Controls.Add(lblProfilePicUser);
            NewUserPanel.Controls.Add(CbUserType);
            NewUserPanel.Controls.Add(BtnAddUser);
            NewUserPanel.Controls.Add(TxtEmailUser);
            NewUserPanel.Controls.Add(TxtNameUser);
            NewUserPanel.Controls.Add(lblUserType);
            NewUserPanel.Controls.Add(lblEmailUser);
            NewUserPanel.Controls.Add(lblNameUser);
            NewUserPanel.Location = new Point(41, 39);
            NewUserPanel.Name = "NewUserPanel";
            NewUserPanel.Size = new Size(718, 373);
            NewUserPanel.TabIndex = 14;
            // 
            // chklbFavGenre
            // 
            chklbFavGenre.FormattingEnabled = true;
            chklbFavGenre.Location = new Point(253, 265);
            chklbFavGenre.Name = "chklbFavGenre";
            chklbFavGenre.Size = new Size(264, 92);
            chklbFavGenre.TabIndex = 40;
            // 
            // dtpUser
            // 
            dtpUser.Location = new Point(254, 223);
            dtpUser.Name = "dtpUser";
            dtpUser.Size = new Size(263, 27);
            dtpUser.TabIndex = 39;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(70, 219);
            label1.Name = "label1";
            label1.Size = new Size(181, 33);
            label1.TabIndex = 38;
            label1.Text = "Birthday :";
            // 
            // lblFavGenre
            // 
            lblFavGenre.AutoSize = true;
            lblFavGenre.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFavGenre.Location = new Point(63, 265);
            lblFavGenre.Name = "lblFavGenre";
            lblFavGenre.Size = new Size(187, 33);
            lblFavGenre.TabIndex = 36;
            lblFavGenre.Text = "Fav Genre :";
            // 
            // SelectedProfileUser
            // 
            SelectedProfileUser.Location = new Point(257, 32);
            SelectedProfileUser.Name = "SelectedProfileUser";
            SelectedProfileUser.Size = new Size(64, 53);
            SelectedProfileUser.SizeMode = PictureBoxSizeMode.Zoom;
            SelectedProfileUser.TabIndex = 34;
            SelectedProfileUser.TabStop = false;
            // 
            // btnAddPictureAlbum
            // 
            btnAddPictureAlbum.BackColor = Color.MediumSlateBlue;
            btnAddPictureAlbum.Location = new Point(348, 36);
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
            lblProfilePicUser.Location = new Point(49, 32);
            lblProfilePicUser.Name = "lblProfilePicUser";
            lblProfilePicUser.Size = new Size(202, 33);
            lblProfilePicUser.TabIndex = 31;
            lblProfilePicUser.Text = "Profile Pic:";
            // 
            // CbUserType
            // 
            CbUserType.DropDownStyle = ComboBoxStyle.DropDownList;
            CbUserType.FormattingEnabled = true;
            CbUserType.Location = new Point(254, 172);
            CbUserType.Name = "CbUserType";
            CbUserType.Size = new Size(262, 28);
            CbUserType.TabIndex = 20;
            // 
            // BtnAddUser
            // 
            BtnAddUser.BackColor = Color.MediumSlateBlue;
            BtnAddUser.Location = new Point(575, 30);
            BtnAddUser.Name = "BtnAddUser";
            BtnAddUser.Size = new Size(127, 57);
            BtnAddUser.TabIndex = 19;
            BtnAddUser.Text = "Add User";
            BtnAddUser.UseVisualStyleBackColor = false;
            BtnAddUser.Click += BtnAddUser_Click;
            // 
            // TxtEmailUser
            // 
            TxtEmailUser.Location = new Point(254, 130);
            TxtEmailUser.Name = "TxtEmailUser";
            TxtEmailUser.Size = new Size(262, 27);
            TxtEmailUser.TabIndex = 17;
            // 
            // TxtNameUser
            // 
            TxtNameUser.Location = new Point(254, 91);
            TxtNameUser.Name = "TxtNameUser";
            TxtNameUser.Size = new Size(262, 27);
            TxtNameUser.TabIndex = 16;
            // 
            // lblUserType
            // 
            lblUserType.AutoSize = true;
            lblUserType.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserType.Location = new Point(65, 166);
            lblUserType.Name = "lblUserType";
            lblUserType.Size = new Size(188, 33);
            lblUserType.TabIndex = 14;
            lblUserType.Text = "User Type :";
            // 
            // lblEmailUser
            // 
            lblEmailUser.AutoSize = true;
            lblEmailUser.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmailUser.Location = new Point(132, 124);
            lblEmailUser.Name = "lblEmailUser";
            lblEmailUser.Size = new Size(119, 33);
            lblEmailUser.TabIndex = 13;
            lblEmailUser.Text = "Email :";
            // 
            // lblNameUser
            // 
            lblNameUser.AutoSize = true;
            lblNameUser.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNameUser.Location = new Point(65, 91);
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
        private ComboBox CbUserType;
        private Button BtnAddUser;
        private TextBox TxtEmailUser;
        private TextBox TxtNameUser;
        private Label lblUserType;
        private Label lblEmailUser;
        private Label lblNameUser;
        private Label lblFavGenre;
        private CheckedListBox chklbFavGenre;
        private DateTimePicker dtpUser;
        private Label label1;
        private StatusStrip ssNewUserForm;
        private ToolStripStatusLabel tsslblNewUserForm;
    }
}