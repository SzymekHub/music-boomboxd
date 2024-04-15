namespace WinFormsApp
{
    partial class DashBoard_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashBoard_Form));
            DashBoardPanel = new Panel();
            btnAlbums = new Button();
            btnSongs = new Button();
            btnReviews = new Button();
            btnUsers = new Button();
            logoPB = new PictureBox();
            btnAddSong = new Button();
            lblHello = new Label();
            tcDashBoard = new TabControl();
            tpUsers = new TabPage();
            lblUsers = new Label();
            tpSongs = new TabPage();
            lblSongs = new Label();
            tpAlbums = new TabPage();
            lblAlbum = new Label();
            tpReviews = new TabPage();
            lblReviews = new Label();
            btnLogOut = new Button();
            SongsPanel = new Panel();
            cbFilterSongs = new ComboBox();
            lblFilterSongs = new Label();
            dgvSongs = new DataGridView();
            lblSearchSongs = new Label();
            tbSearchSongs = new TextBox();
            btnUpdateSong = new Button();
            btnView = new Button();
            btnDelete = new Button();
            UsersPanel = new Panel();
            btnDeleteUser = new Button();
            btnViewUser = new Button();
            btnUpdateUser = new Button();
            lblFilterUser = new Label();
            dgvUsers = new DataGridView();
            lblSearchUser = new Label();
            btnAddUser = new Button();
            CbUsers = new ComboBox();
            txtSearch = new TextBox();
            DashBoardPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoPB).BeginInit();
            tcDashBoard.SuspendLayout();
            tpUsers.SuspendLayout();
            tpSongs.SuspendLayout();
            tpAlbums.SuspendLayout();
            tpReviews.SuspendLayout();
            SongsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSongs).BeginInit();
            UsersPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            SuspendLayout();
            // 
            // DashBoardPanel
            // 
            DashBoardPanel.BackColor = Color.DarkGray;
            DashBoardPanel.Controls.Add(btnAlbums);
            DashBoardPanel.Controls.Add(btnSongs);
            DashBoardPanel.Controls.Add(btnReviews);
            DashBoardPanel.Controls.Add(btnUsers);
            DashBoardPanel.Controls.Add(logoPB);
            DashBoardPanel.Location = new Point(12, 48);
            DashBoardPanel.Name = "DashBoardPanel";
            DashBoardPanel.Size = new Size(249, 573);
            DashBoardPanel.TabIndex = 0;
            // 
            // btnAlbums
            // 
            btnAlbums.BackColor = Color.MediumSlateBlue;
            btnAlbums.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAlbums.Location = new Point(13, 282);
            btnAlbums.Name = "btnAlbums";
            btnAlbums.Size = new Size(126, 57);
            btnAlbums.TabIndex = 19;
            btnAlbums.Text = "Albums";
            btnAlbums.UseVisualStyleBackColor = false;
            btnAlbums.Click += Button_Click;
            // 
            // btnSongs
            // 
            btnSongs.BackColor = Color.MediumSlateBlue;
            btnSongs.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSongs.Location = new Point(13, 200);
            btnSongs.Name = "btnSongs";
            btnSongs.Size = new Size(126, 57);
            btnSongs.TabIndex = 18;
            btnSongs.Text = "Songs";
            btnSongs.UseVisualStyleBackColor = false;
            btnSongs.Click += Button_Click;
            // 
            // btnReviews
            // 
            btnReviews.BackColor = Color.MediumSlateBlue;
            btnReviews.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReviews.Location = new Point(13, 365);
            btnReviews.Name = "btnReviews";
            btnReviews.Size = new Size(126, 57);
            btnReviews.TabIndex = 17;
            btnReviews.Text = "Reviews";
            btnReviews.UseVisualStyleBackColor = false;
            btnReviews.Click += Button_Click;
            // 
            // btnUsers
            // 
            btnUsers.BackColor = Color.MediumSlateBlue;
            btnUsers.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUsers.Location = new Point(13, 122);
            btnUsers.Name = "btnUsers";
            btnUsers.Size = new Size(126, 57);
            btnUsers.TabIndex = 15;
            btnUsers.Text = "Users";
            btnUsers.UseVisualStyleBackColor = false;
            btnUsers.Click += Button_Click;
            // 
            // logoPB
            // 
            logoPB.Image = (Image)resources.GetObject("logoPB.Image");
            logoPB.Location = new Point(75, 0);
            logoPB.Name = "logoPB";
            logoPB.Size = new Size(113, 88);
            logoPB.SizeMode = PictureBoxSizeMode.Zoom;
            logoPB.TabIndex = 13;
            logoPB.TabStop = false;
            // 
            // btnAddSong
            // 
            btnAddSong.BackColor = Color.MediumSlateBlue;
            btnAddSong.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddSong.Location = new Point(747, 125);
            btnAddSong.Name = "btnAddSong";
            btnAddSong.Size = new Size(137, 49);
            btnAddSong.TabIndex = 16;
            btnAddSong.Text = "Add Song";
            btnAddSong.UseVisualStyleBackColor = false;
            btnAddSong.Click += btnAddSong_Click;
            // 
            // lblHello
            // 
            lblHello.AutoSize = true;
            lblHello.Font = new Font("Showcard Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHello.Location = new Point(25, 22);
            lblHello.Name = "lblHello";
            lblHello.Size = new Size(0, 23);
            lblHello.TabIndex = 14;
            // 
            // tcDashBoard
            // 
            tcDashBoard.Controls.Add(tpUsers);
            tcDashBoard.Controls.Add(tpSongs);
            tcDashBoard.Controls.Add(tpAlbums);
            tcDashBoard.Controls.Add(tpReviews);
            tcDashBoard.Location = new Point(267, 0);
            tcDashBoard.Name = "tcDashBoard";
            tcDashBoard.SelectedIndex = 0;
            tcDashBoard.Size = new Size(994, 621);
            tcDashBoard.TabIndex = 1;
            // 
            // tpUsers
            // 
            tpUsers.BackColor = Color.MediumSlateBlue;
            tpUsers.Controls.Add(UsersPanel);
            tpUsers.Controls.Add(lblUsers);
            tpUsers.Location = new Point(4, 29);
            tpUsers.Name = "tpUsers";
            tpUsers.Padding = new Padding(3);
            tpUsers.Size = new Size(986, 588);
            tpUsers.TabIndex = 0;
            tpUsers.Text = "Users";
            // 
            // lblUsers
            // 
            lblUsers.AutoSize = true;
            lblUsers.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold);
            lblUsers.Location = new Point(420, 17);
            lblUsers.Name = "lblUsers";
            lblUsers.Size = new Size(159, 60);
            lblUsers.TabIndex = 9;
            lblUsers.Text = "USERS";
            // 
            // tpSongs
            // 
            tpSongs.BackColor = Color.MediumSlateBlue;
            tpSongs.Controls.Add(SongsPanel);
            tpSongs.Controls.Add(lblSongs);
            tpSongs.Location = new Point(4, 29);
            tpSongs.Name = "tpSongs";
            tpSongs.Padding = new Padding(3);
            tpSongs.Size = new Size(986, 588);
            tpSongs.TabIndex = 1;
            tpSongs.Text = "Songs";
            // 
            // lblSongs
            // 
            lblSongs.AutoSize = true;
            lblSongs.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold);
            lblSongs.Location = new Point(420, 17);
            lblSongs.Name = "lblSongs";
            lblSongs.Size = new Size(174, 60);
            lblSongs.TabIndex = 10;
            lblSongs.Text = "SONGS";
            // 
            // tpAlbums
            // 
            tpAlbums.BackColor = Color.MediumSlateBlue;
            tpAlbums.Controls.Add(lblAlbum);
            tpAlbums.Location = new Point(4, 29);
            tpAlbums.Name = "tpAlbums";
            tpAlbums.Padding = new Padding(3);
            tpAlbums.Size = new Size(986, 588);
            tpAlbums.TabIndex = 2;
            tpAlbums.Text = "Albums";
            // 
            // lblAlbum
            // 
            lblAlbum.AutoSize = true;
            lblAlbum.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold);
            lblAlbum.Location = new Point(420, 17);
            lblAlbum.Name = "lblAlbum";
            lblAlbum.Size = new Size(206, 60);
            lblAlbum.TabIndex = 11;
            lblAlbum.Text = "ALBUMS";
            // 
            // tpReviews
            // 
            tpReviews.BackColor = Color.MediumSlateBlue;
            tpReviews.Controls.Add(lblReviews);
            tpReviews.Location = new Point(4, 29);
            tpReviews.Name = "tpReviews";
            tpReviews.Padding = new Padding(3);
            tpReviews.Size = new Size(986, 588);
            tpReviews.TabIndex = 3;
            tpReviews.Text = "Reviews";
            // 
            // lblReviews
            // 
            lblReviews.AutoSize = true;
            lblReviews.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold);
            lblReviews.Location = new Point(420, 17);
            lblReviews.Name = "lblReviews";
            lblReviews.Size = new Size(213, 60);
            lblReviews.TabIndex = 11;
            lblReviews.Text = "REVIEWS";
            // 
            // btnLogOut
            // 
            btnLogOut.BackColor = Color.MediumSlateBlue;
            btnLogOut.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            btnLogOut.Location = new Point(12, 623);
            btnLogOut.Margin = new Padding(3, 4, 3, 4);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(100, 32);
            btnLogOut.TabIndex = 18;
            btnLogOut.Text = "Log Out";
            btnLogOut.UseVisualStyleBackColor = false;
            btnLogOut.Click += ButtonLogOut_Click;
            // 
            // SongsPanel
            // 
            SongsPanel.BackColor = Color.DarkGray;
            SongsPanel.Controls.Add(btnDelete);
            SongsPanel.Controls.Add(btnView);
            SongsPanel.Controls.Add(btnUpdateSong);
            SongsPanel.Controls.Add(cbFilterSongs);
            SongsPanel.Controls.Add(lblFilterSongs);
            SongsPanel.Controls.Add(dgvSongs);
            SongsPanel.Controls.Add(lblSearchSongs);
            SongsPanel.Controls.Add(tbSearchSongs);
            SongsPanel.Controls.Add(btnAddSong);
            SongsPanel.Location = new Point(34, 94);
            SongsPanel.Name = "SongsPanel";
            SongsPanel.Size = new Size(912, 471);
            SongsPanel.TabIndex = 17;
            // 
            // cbFilterSongs
            // 
            cbFilterSongs.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilterSongs.FormattingEnabled = true;
            cbFilterSongs.Location = new Point(484, 35);
            cbFilterSongs.Name = "cbFilterSongs";
            cbFilterSongs.Size = new Size(239, 28);
            cbFilterSongs.TabIndex = 28;
            // 
            // lblFilterSongs
            // 
            lblFilterSongs.AutoSize = true;
            lblFilterSongs.Font = new Font("Segoe UI", 12F);
            lblFilterSongs.Location = new Point(418, 34);
            lblFilterSongs.Name = "lblFilterSongs";
            lblFilterSongs.Size = new Size(60, 28);
            lblFilterSongs.TabIndex = 27;
            lblFilterSongs.Text = "Filter:";
            // 
            // dgvSongs
            // 
            dgvSongs.BackgroundColor = SystemColors.Window;
            dgvSongs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSongs.Location = new Point(24, 86);
            dgvSongs.Margin = new Padding(3, 4, 3, 4);
            dgvSongs.Name = "dgvSongs";
            dgvSongs.RowHeadersWidth = 51;
            dgvSongs.Size = new Size(699, 363);
            dgvSongs.TabIndex = 26;
            // 
            // lblSearchSongs
            // 
            lblSearchSongs.AutoSize = true;
            lblSearchSongs.Font = new Font("Segoe UI", 12F);
            lblSearchSongs.Location = new Point(24, 31);
            lblSearchSongs.Name = "lblSearchSongs";
            lblSearchSongs.Size = new Size(79, 28);
            lblSearchSongs.TabIndex = 24;
            lblSearchSongs.Text = "Search: ";
            // 
            // tbSearchSongs
            // 
            tbSearchSongs.BackColor = Color.WhiteSmoke;
            tbSearchSongs.Location = new Point(111, 35);
            tbSearchSongs.Margin = new Padding(5, 4, 5, 4);
            tbSearchSongs.Name = "tbSearchSongs";
            tbSearchSongs.Size = new Size(299, 27);
            tbSearchSongs.TabIndex = 25;
            // 
            // btnUpdateSong
            // 
            btnUpdateSong.BackColor = Color.MediumSlateBlue;
            btnUpdateSong.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdateSong.Location = new Point(747, 196);
            btnUpdateSong.Name = "btnUpdateSong";
            btnUpdateSong.Size = new Size(137, 49);
            btnUpdateSong.TabIndex = 29;
            btnUpdateSong.Text = "Update";
            btnUpdateSong.UseVisualStyleBackColor = false;
            // 
            // btnView
            // 
            btnView.BackColor = Color.MediumSlateBlue;
            btnView.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnView.Location = new Point(747, 269);
            btnView.Name = "btnView";
            btnView.Size = new Size(137, 49);
            btnView.TabIndex = 30;
            btnView.Text = "View";
            btnView.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.MediumSlateBlue;
            btnDelete.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(747, 339);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(137, 49);
            btnDelete.TabIndex = 31;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // UsersPanel
            // 
            UsersPanel.BackColor = Color.DarkGray;
            UsersPanel.Controls.Add(CbUsers);
            UsersPanel.Controls.Add(txtSearch);
            UsersPanel.Controls.Add(btnDeleteUser);
            UsersPanel.Controls.Add(btnViewUser);
            UsersPanel.Controls.Add(btnUpdateUser);
            UsersPanel.Controls.Add(lblFilterUser);
            UsersPanel.Controls.Add(dgvUsers);
            UsersPanel.Controls.Add(lblSearchUser);
            UsersPanel.Controls.Add(btnAddUser);
            UsersPanel.Location = new Point(34, 94);
            UsersPanel.Name = "UsersPanel";
            UsersPanel.Size = new Size(912, 471);
            UsersPanel.TabIndex = 18;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.BackColor = Color.MediumSlateBlue;
            btnDeleteUser.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeleteUser.Location = new Point(747, 339);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(137, 49);
            btnDeleteUser.TabIndex = 31;
            btnDeleteUser.Text = "Delete";
            btnDeleteUser.UseVisualStyleBackColor = false;
            // 
            // btnViewUser
            // 
            btnViewUser.BackColor = Color.MediumSlateBlue;
            btnViewUser.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnViewUser.Location = new Point(747, 269);
            btnViewUser.Name = "btnViewUser";
            btnViewUser.Size = new Size(137, 49);
            btnViewUser.TabIndex = 30;
            btnViewUser.Text = "View";
            btnViewUser.UseVisualStyleBackColor = false;
            // 
            // btnUpdateUser
            // 
            btnUpdateUser.BackColor = Color.MediumSlateBlue;
            btnUpdateUser.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdateUser.Location = new Point(747, 196);
            btnUpdateUser.Name = "btnUpdateUser";
            btnUpdateUser.Size = new Size(137, 49);
            btnUpdateUser.TabIndex = 29;
            btnUpdateUser.Text = "Update";
            btnUpdateUser.UseVisualStyleBackColor = false;
            // 
            // lblFilterUser
            // 
            lblFilterUser.AutoSize = true;
            lblFilterUser.Font = new Font("Segoe UI", 12F);
            lblFilterUser.Location = new Point(418, 34);
            lblFilterUser.Name = "lblFilterUser";
            lblFilterUser.Size = new Size(60, 28);
            lblFilterUser.TabIndex = 27;
            lblFilterUser.Text = "Filter:";
            // 
            // dgvUsers
            // 
            dgvUsers.BackgroundColor = SystemColors.Window;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Location = new Point(24, 86);
            dgvUsers.Margin = new Padding(3, 4, 3, 4);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.Size = new Size(699, 363);
            dgvUsers.TabIndex = 26;
            // 
            // lblSearchUser
            // 
            lblSearchUser.AutoSize = true;
            lblSearchUser.Font = new Font("Segoe UI", 12F);
            lblSearchUser.Location = new Point(24, 31);
            lblSearchUser.Name = "lblSearchUser";
            lblSearchUser.Size = new Size(79, 28);
            lblSearchUser.TabIndex = 24;
            lblSearchUser.Text = "Search: ";
            // 
            // btnAddUser
            // 
            btnAddUser.BackColor = Color.MediumSlateBlue;
            btnAddUser.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddUser.Location = new Point(747, 125);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(137, 49);
            btnAddUser.TabIndex = 16;
            btnAddUser.Text = "Add User";
            btnAddUser.UseVisualStyleBackColor = false;
            // 
            // CbUsers
            // 
            CbUsers.DropDownStyle = ComboBoxStyle.DropDownList;
            CbUsers.FormattingEnabled = true;
            CbUsers.Location = new Point(484, 35);
            CbUsers.Name = "CbUsers";
            CbUsers.Size = new Size(239, 28);
            CbUsers.TabIndex = 33;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(111, 35);
            txtSearch.Margin = new Padding(5, 4, 5, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(299, 27);
            txtSearch.TabIndex = 32;
            // 
            // DashBoard_Form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumSlateBlue;
            ClientSize = new Size(1261, 671);
            Controls.Add(btnLogOut);
            Controls.Add(tcDashBoard);
            Controls.Add(DashBoardPanel);
            Controls.Add(lblHello);
            MaximumSize = new Size(1279, 718);
            MinimumSize = new Size(1279, 718);
            Name = "DashBoard_Form";
            Text = "DashBoard";
            FormClosed += DashBoard_Form_FormClosed;
            Load += DashBoard_Form_Load;
            DashBoardPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)logoPB).EndInit();
            tcDashBoard.ResumeLayout(false);
            tpUsers.ResumeLayout(false);
            tpUsers.PerformLayout();
            tpSongs.ResumeLayout(false);
            tpSongs.PerformLayout();
            tpAlbums.ResumeLayout(false);
            tpAlbums.PerformLayout();
            tpReviews.ResumeLayout(false);
            tpReviews.PerformLayout();
            SongsPanel.ResumeLayout(false);
            SongsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSongs).EndInit();
            UsersPanel.ResumeLayout(false);
            UsersPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel DashBoardPanel;
        private Label lblHello;
        private PictureBox logoPB;
        private Button btnReviews;
        private Button btnAddSong;
        private Button btnUsers;
        private TabControl tcDashBoard;
        private TabPage tpUsers;
        private TabPage tpSongs;
        private Button btnLogOut;
        private Label lblUsers;
        private Label lblSongs;
        private TabPage tpAlbums;
        private TabPage tpReviews;
        private Button btnAlbums;
        private Button btnSongs;
        private Label lblAlbum;
        private Label lblReviews;
        private Panel SongsPanel;
        private ComboBox cbFilterSongs;
        private Label lblFilterSongs;
        private DataGridView dgvSongs;
        private Label lblSearchSongs;
        private TextBox tbSearchSongs;
        private Button btnUpdateSong;
        private Button btnView;
        private Button btnDelete;
        private Panel UsersPanel;
        private Button btnDeleteUser;
        private Button btnViewUser;
        private Button btnUpdateUser;
        private ComboBox cbFilterUser;
        private Label lblFilterUser;
        private DataGridView dgvUsers;
        private Label lblSearchUser;
        private TextBox textBox1;
        private Button btnAddUser;
        private ComboBox CbUsers;
        private TextBox txtSearch;
    }
}