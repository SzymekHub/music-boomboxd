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
            DashBoardPanel = new Panel();
            pbReviews = new PictureBox();
            pbAlbums = new PictureBox();
            pbSongs = new PictureBox();
            pbUsers = new PictureBox();
            btnAlbums = new Button();
            btnSongs = new Button();
            btnReviews = new Button();
            btnUsers = new Button();
            logoPB = new PictureBox();
            btnAddSong = new Button();
            lblHello = new Label();
            tcDashBoard = new TabControl();
            tpUsers = new TabPage();
            pbUsers2 = new PictureBox();
            UsersPanel = new Panel();
            CbUsers = new ComboBox();
            txtSearch = new TextBox();
            btnDeleteUser = new Button();
            btnViewUser = new Button();
            btnUpdateUser = new Button();
            lblFilterUser = new Label();
            dgvUsers = new DataGridView();
            lblSearchUser = new Label();
            btnAddUser = new Button();
            lblUsers = new Label();
            tpSongs = new TabPage();
            pbSongs2 = new PictureBox();
            SongsPanel = new Panel();
            btnDelete = new Button();
            btnView = new Button();
            btnUpdateSong = new Button();
            cbFilterSongs = new ComboBox();
            lblFilterSongs = new Label();
            dgvSongs = new DataGridView();
            lblSearchSongs = new Label();
            tbSearchSongs = new TextBox();
            lblSongs = new Label();
            tpAlbums = new TabPage();
            plAlbums = new Panel();
            btnDeleteAlbum = new Button();
            btnViewAlbum = new Button();
            btnUpdateAlbum = new Button();
            cbFilterAlbums = new ComboBox();
            lblFilterAlbums = new Label();
            dgvAlbums = new DataGridView();
            lblSearchAlbums = new Label();
            tbSearchAlbums = new TextBox();
            bntAddAlbum = new Button();
            pbAlbums2 = new PictureBox();
            lblAlbum = new Label();
            tpReviews = new TabPage();
            plReviews = new Panel();
            btnDelteReviews = new Button();
            btnViewReviews = new Button();
            cbFilterReviews = new ComboBox();
            lblFilterReviews = new Label();
            dgvReviews = new DataGridView();
            lblSearchReviews = new Label();
            tbSearchReviews = new TextBox();
            btnWarningReviews = new Button();
            pbReviews2 = new PictureBox();
            lblReviews = new Label();
            btnLogOut = new Button();
            ssDashBoardForm = new StatusStrip();
            tsslblDashBoardForm = new ToolStripStatusLabel();
            DashBoardPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbReviews).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbAlbums).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbSongs).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbUsers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logoPB).BeginInit();
            tcDashBoard.SuspendLayout();
            tpUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbUsers2).BeginInit();
            UsersPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            tpSongs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbSongs2).BeginInit();
            SongsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSongs).BeginInit();
            tpAlbums.SuspendLayout();
            plAlbums.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAlbums).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbAlbums2).BeginInit();
            tpReviews.SuspendLayout();
            plReviews.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReviews).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbReviews2).BeginInit();
            ssDashBoardForm.SuspendLayout();
            SuspendLayout();
            // 
            // DashBoardPanel
            // 
            DashBoardPanel.BackColor = Color.DarkGray;
            DashBoardPanel.Controls.Add(pbReviews);
            DashBoardPanel.Controls.Add(pbAlbums);
            DashBoardPanel.Controls.Add(pbSongs);
            DashBoardPanel.Controls.Add(pbUsers);
            DashBoardPanel.Controls.Add(btnAlbums);
            DashBoardPanel.Controls.Add(btnSongs);
            DashBoardPanel.Controls.Add(btnReviews);
            DashBoardPanel.Controls.Add(btnUsers);
            DashBoardPanel.Controls.Add(logoPB);
            DashBoardPanel.Location = new Point(12, 48);
            DashBoardPanel.Name = "DashBoardPanel";
            DashBoardPanel.Size = new Size(249, 568);
            DashBoardPanel.TabIndex = 0;
            // 
            // pbReviews
            // 
            pbReviews.Image = Properties.Resources.Reviews;
            pbReviews.Location = new Point(172, 365);
            pbReviews.Name = "pbReviews";
            pbReviews.Size = new Size(65, 57);
            pbReviews.SizeMode = PictureBoxSizeMode.Zoom;
            pbReviews.TabIndex = 23;
            pbReviews.TabStop = false;
            // 
            // pbAlbums
            // 
            pbAlbums.Image = Properties.Resources.Albums;
            pbAlbums.Location = new Point(172, 282);
            pbAlbums.Name = "pbAlbums";
            pbAlbums.Size = new Size(65, 57);
            pbAlbums.SizeMode = PictureBoxSizeMode.Zoom;
            pbAlbums.TabIndex = 22;
            pbAlbums.TabStop = false;
            // 
            // pbSongs
            // 
            pbSongs.Image = Properties.Resources.Songs;
            pbSongs.Location = new Point(172, 200);
            pbSongs.Name = "pbSongs";
            pbSongs.Size = new Size(65, 57);
            pbSongs.SizeMode = PictureBoxSizeMode.Zoom;
            pbSongs.TabIndex = 21;
            pbSongs.TabStop = false;
            // 
            // pbUsers
            // 
            pbUsers.Image = Properties.Resources.Users;
            pbUsers.Location = new Point(172, 122);
            pbUsers.Name = "pbUsers";
            pbUsers.Size = new Size(65, 57);
            pbUsers.SizeMode = PictureBoxSizeMode.Zoom;
            pbUsers.TabIndex = 20;
            pbUsers.TabStop = false;
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
            logoPB.Image = Properties.Resources.LogoBlue1;
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
            tcDashBoard.Size = new Size(994, 616);
            tcDashBoard.TabIndex = 1;
            // 
            // tpUsers
            // 
            tpUsers.BackColor = Color.MediumSlateBlue;
            tpUsers.Controls.Add(pbUsers2);
            tpUsers.Controls.Add(UsersPanel);
            tpUsers.Controls.Add(lblUsers);
            tpUsers.Location = new Point(4, 29);
            tpUsers.Name = "tpUsers";
            tpUsers.Padding = new Padding(3);
            tpUsers.Size = new Size(986, 583);
            tpUsers.TabIndex = 0;
            tpUsers.Text = "Users";
            // 
            // pbUsers2
            // 
            pbUsers2.Image = Properties.Resources.Users;
            pbUsers2.Location = new Point(585, 17);
            pbUsers2.Name = "pbUsers2";
            pbUsers2.Size = new Size(65, 57);
            pbUsers2.SizeMode = PictureBoxSizeMode.Zoom;
            pbUsers2.TabIndex = 21;
            pbUsers2.TabStop = false;
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
            btnAddUser.Click += btnAddUser_Click;
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
            tpSongs.Controls.Add(pbSongs2);
            tpSongs.Controls.Add(SongsPanel);
            tpSongs.Controls.Add(lblSongs);
            tpSongs.Location = new Point(4, 29);
            tpSongs.Name = "tpSongs";
            tpSongs.Padding = new Padding(3);
            tpSongs.Size = new Size(986, 583);
            tpSongs.TabIndex = 1;
            tpSongs.Text = "Songs";
            // 
            // pbSongs2
            // 
            pbSongs2.Image = Properties.Resources.Songs;
            pbSongs2.Location = new Point(600, 20);
            pbSongs2.Name = "pbSongs2";
            pbSongs2.Size = new Size(65, 57);
            pbSongs2.SizeMode = PictureBoxSizeMode.Zoom;
            pbSongs2.TabIndex = 22;
            pbSongs2.TabStop = false;
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
            tpAlbums.Controls.Add(plAlbums);
            tpAlbums.Controls.Add(pbAlbums2);
            tpAlbums.Controls.Add(lblAlbum);
            tpAlbums.Location = new Point(4, 29);
            tpAlbums.Name = "tpAlbums";
            tpAlbums.Padding = new Padding(3);
            tpAlbums.Size = new Size(986, 583);
            tpAlbums.TabIndex = 2;
            tpAlbums.Text = "Albums";
            // 
            // plAlbums
            // 
            plAlbums.BackColor = Color.DarkGray;
            plAlbums.Controls.Add(btnDeleteAlbum);
            plAlbums.Controls.Add(btnViewAlbum);
            plAlbums.Controls.Add(btnUpdateAlbum);
            plAlbums.Controls.Add(cbFilterAlbums);
            plAlbums.Controls.Add(lblFilterAlbums);
            plAlbums.Controls.Add(dgvAlbums);
            plAlbums.Controls.Add(lblSearchAlbums);
            plAlbums.Controls.Add(tbSearchAlbums);
            plAlbums.Controls.Add(bntAddAlbum);
            plAlbums.Location = new Point(34, 94);
            plAlbums.Name = "plAlbums";
            plAlbums.Size = new Size(912, 471);
            plAlbums.TabIndex = 24;
            // 
            // btnDeleteAlbum
            // 
            btnDeleteAlbum.BackColor = Color.MediumSlateBlue;
            btnDeleteAlbum.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeleteAlbum.Location = new Point(747, 339);
            btnDeleteAlbum.Name = "btnDeleteAlbum";
            btnDeleteAlbum.Size = new Size(137, 49);
            btnDeleteAlbum.TabIndex = 31;
            btnDeleteAlbum.Text = "Delete";
            btnDeleteAlbum.UseVisualStyleBackColor = false;
            // 
            // btnViewAlbum
            // 
            btnViewAlbum.BackColor = Color.MediumSlateBlue;
            btnViewAlbum.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnViewAlbum.Location = new Point(747, 269);
            btnViewAlbum.Name = "btnViewAlbum";
            btnViewAlbum.Size = new Size(137, 49);
            btnViewAlbum.TabIndex = 30;
            btnViewAlbum.Text = "View";
            btnViewAlbum.UseVisualStyleBackColor = false;
            // 
            // btnUpdateAlbum
            // 
            btnUpdateAlbum.BackColor = Color.MediumSlateBlue;
            btnUpdateAlbum.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdateAlbum.Location = new Point(747, 196);
            btnUpdateAlbum.Name = "btnUpdateAlbum";
            btnUpdateAlbum.Size = new Size(137, 49);
            btnUpdateAlbum.TabIndex = 29;
            btnUpdateAlbum.Text = "Update";
            btnUpdateAlbum.UseVisualStyleBackColor = false;
            // 
            // cbFilterAlbums
            // 
            cbFilterAlbums.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilterAlbums.FormattingEnabled = true;
            cbFilterAlbums.Location = new Point(484, 35);
            cbFilterAlbums.Name = "cbFilterAlbums";
            cbFilterAlbums.Size = new Size(239, 28);
            cbFilterAlbums.TabIndex = 28;
            // 
            // lblFilterAlbums
            // 
            lblFilterAlbums.AutoSize = true;
            lblFilterAlbums.Font = new Font("Segoe UI", 12F);
            lblFilterAlbums.Location = new Point(418, 34);
            lblFilterAlbums.Name = "lblFilterAlbums";
            lblFilterAlbums.Size = new Size(60, 28);
            lblFilterAlbums.TabIndex = 27;
            lblFilterAlbums.Text = "Filter:";
            // 
            // dgvAlbums
            // 
            dgvAlbums.BackgroundColor = SystemColors.Window;
            dgvAlbums.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAlbums.Location = new Point(24, 86);
            dgvAlbums.Margin = new Padding(3, 4, 3, 4);
            dgvAlbums.Name = "dgvAlbums";
            dgvAlbums.RowHeadersWidth = 51;
            dgvAlbums.Size = new Size(699, 363);
            dgvAlbums.TabIndex = 26;
            // 
            // lblSearchAlbums
            // 
            lblSearchAlbums.AutoSize = true;
            lblSearchAlbums.Font = new Font("Segoe UI", 12F);
            lblSearchAlbums.Location = new Point(24, 31);
            lblSearchAlbums.Name = "lblSearchAlbums";
            lblSearchAlbums.Size = new Size(79, 28);
            lblSearchAlbums.TabIndex = 24;
            lblSearchAlbums.Text = "Search: ";
            // 
            // tbSearchAlbums
            // 
            tbSearchAlbums.BackColor = Color.WhiteSmoke;
            tbSearchAlbums.Location = new Point(111, 35);
            tbSearchAlbums.Margin = new Padding(5, 4, 5, 4);
            tbSearchAlbums.Name = "tbSearchAlbums";
            tbSearchAlbums.Size = new Size(299, 27);
            tbSearchAlbums.TabIndex = 25;
            // 
            // bntAddAlbum
            // 
            bntAddAlbum.BackColor = Color.MediumSlateBlue;
            bntAddAlbum.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            bntAddAlbum.Location = new Point(747, 125);
            bntAddAlbum.Name = "bntAddAlbum";
            bntAddAlbum.Size = new Size(137, 49);
            bntAddAlbum.TabIndex = 16;
            bntAddAlbum.Text = "Add Album";
            bntAddAlbum.UseVisualStyleBackColor = false;
            bntAddAlbum.Click += bntAddAlbum_Click;
            // 
            // pbAlbums2
            // 
            pbAlbums2.Image = Properties.Resources.Albums;
            pbAlbums2.Location = new Point(632, 20);
            pbAlbums2.Name = "pbAlbums2";
            pbAlbums2.Size = new Size(65, 57);
            pbAlbums2.SizeMode = PictureBoxSizeMode.Zoom;
            pbAlbums2.TabIndex = 23;
            pbAlbums2.TabStop = false;
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
            tpReviews.Controls.Add(plReviews);
            tpReviews.Controls.Add(pbReviews2);
            tpReviews.Controls.Add(lblReviews);
            tpReviews.Location = new Point(4, 29);
            tpReviews.Name = "tpReviews";
            tpReviews.Padding = new Padding(3);
            tpReviews.Size = new Size(986, 583);
            tpReviews.TabIndex = 3;
            tpReviews.Text = "Reviews";
            // 
            // plReviews
            // 
            plReviews.BackColor = Color.DarkGray;
            plReviews.Controls.Add(btnDelteReviews);
            plReviews.Controls.Add(btnViewReviews);
            plReviews.Controls.Add(cbFilterReviews);
            plReviews.Controls.Add(lblFilterReviews);
            plReviews.Controls.Add(dgvReviews);
            plReviews.Controls.Add(lblSearchReviews);
            plReviews.Controls.Add(tbSearchReviews);
            plReviews.Controls.Add(btnWarningReviews);
            plReviews.Location = new Point(34, 94);
            plReviews.Name = "plReviews";
            plReviews.Size = new Size(912, 471);
            plReviews.TabIndex = 25;
            // 
            // btnDelteReviews
            // 
            btnDelteReviews.BackColor = Color.MediumSlateBlue;
            btnDelteReviews.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelteReviews.Location = new Point(747, 298);
            btnDelteReviews.Name = "btnDelteReviews";
            btnDelteReviews.Size = new Size(137, 49);
            btnDelteReviews.TabIndex = 31;
            btnDelteReviews.Text = "Delete";
            btnDelteReviews.UseVisualStyleBackColor = false;
            // 
            // btnViewReviews
            // 
            btnViewReviews.BackColor = Color.MediumSlateBlue;
            btnViewReviews.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnViewReviews.Location = new Point(747, 227);
            btnViewReviews.Name = "btnViewReviews";
            btnViewReviews.Size = new Size(137, 49);
            btnViewReviews.TabIndex = 30;
            btnViewReviews.Text = "View";
            btnViewReviews.UseVisualStyleBackColor = false;
            // 
            // cbFilterReviews
            // 
            cbFilterReviews.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilterReviews.FormattingEnabled = true;
            cbFilterReviews.Location = new Point(484, 35);
            cbFilterReviews.Name = "cbFilterReviews";
            cbFilterReviews.Size = new Size(239, 28);
            cbFilterReviews.TabIndex = 28;
            // 
            // lblFilterReviews
            // 
            lblFilterReviews.AutoSize = true;
            lblFilterReviews.Font = new Font("Segoe UI", 12F);
            lblFilterReviews.Location = new Point(418, 34);
            lblFilterReviews.Name = "lblFilterReviews";
            lblFilterReviews.Size = new Size(60, 28);
            lblFilterReviews.TabIndex = 27;
            lblFilterReviews.Text = "Filter:";
            // 
            // dgvReviews
            // 
            dgvReviews.BackgroundColor = SystemColors.Window;
            dgvReviews.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReviews.Location = new Point(24, 86);
            dgvReviews.Margin = new Padding(3, 4, 3, 4);
            dgvReviews.Name = "dgvReviews";
            dgvReviews.RowHeadersWidth = 51;
            dgvReviews.Size = new Size(699, 363);
            dgvReviews.TabIndex = 26;
            // 
            // lblSearchReviews
            // 
            lblSearchReviews.AutoSize = true;
            lblSearchReviews.Font = new Font("Segoe UI", 12F);
            lblSearchReviews.Location = new Point(24, 31);
            lblSearchReviews.Name = "lblSearchReviews";
            lblSearchReviews.Size = new Size(79, 28);
            lblSearchReviews.TabIndex = 24;
            lblSearchReviews.Text = "Search: ";
            // 
            // tbSearchReviews
            // 
            tbSearchReviews.BackColor = Color.WhiteSmoke;
            tbSearchReviews.Location = new Point(111, 35);
            tbSearchReviews.Margin = new Padding(5, 4, 5, 4);
            tbSearchReviews.Name = "tbSearchReviews";
            tbSearchReviews.Size = new Size(299, 27);
            tbSearchReviews.TabIndex = 25;
            // 
            // btnWarningReviews
            // 
            btnWarningReviews.BackColor = Color.MediumSlateBlue;
            btnWarningReviews.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnWarningReviews.Location = new Point(747, 156);
            btnWarningReviews.Name = "btnWarningReviews";
            btnWarningReviews.Size = new Size(137, 49);
            btnWarningReviews.TabIndex = 16;
            btnWarningReviews.Text = "Warning";
            btnWarningReviews.UseVisualStyleBackColor = false;
            // 
            // pbReviews2
            // 
            pbReviews2.Image = Properties.Resources.Reviews;
            pbReviews2.Location = new Point(639, 20);
            pbReviews2.Name = "pbReviews2";
            pbReviews2.Size = new Size(65, 57);
            pbReviews2.SizeMode = PictureBoxSizeMode.Zoom;
            pbReviews2.TabIndex = 24;
            pbReviews2.TabStop = false;
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
            btnLogOut.Location = new Point(12, 613);
            btnLogOut.Margin = new Padding(3, 4, 3, 4);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(100, 32);
            btnLogOut.TabIndex = 18;
            btnLogOut.Text = "Log Out";
            btnLogOut.UseVisualStyleBackColor = false;
            btnLogOut.Click += ButtonLogOut_Click;
            // 
            // ssDashBoardForm
            // 
            ssDashBoardForm.BackColor = Color.MediumSlateBlue;
            ssDashBoardForm.Dock = DockStyle.None;
            ssDashBoardForm.ImageScalingSize = new Size(20, 20);
            ssDashBoardForm.Items.AddRange(new ToolStripItem[] { tsslblDashBoardForm });
            ssDashBoardForm.Location = new Point(271, 621);
            ssDashBoardForm.Name = "ssDashBoardForm";
            ssDashBoardForm.Size = new Size(17, 22);
            ssDashBoardForm.TabIndex = 19;
            ssDashBoardForm.Text = "statusStrip1";
            // 
            // tsslblDashBoardForm
            // 
            tsslblDashBoardForm.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tsslblDashBoardForm.ForeColor = Color.LavenderBlush;
            tsslblDashBoardForm.Name = "tsslblDashBoardForm";
            tsslblDashBoardForm.Size = new Size(0, 16);
            // 
            // DashBoard_Form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumSlateBlue;
            ClientSize = new Size(1261, 671);
            Controls.Add(ssDashBoardForm);
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
            ((System.ComponentModel.ISupportInitialize)pbReviews).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbAlbums).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbSongs).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbUsers).EndInit();
            ((System.ComponentModel.ISupportInitialize)logoPB).EndInit();
            tcDashBoard.ResumeLayout(false);
            tpUsers.ResumeLayout(false);
            tpUsers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbUsers2).EndInit();
            UsersPanel.ResumeLayout(false);
            UsersPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            tpSongs.ResumeLayout(false);
            tpSongs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbSongs2).EndInit();
            SongsPanel.ResumeLayout(false);
            SongsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSongs).EndInit();
            tpAlbums.ResumeLayout(false);
            tpAlbums.PerformLayout();
            plAlbums.ResumeLayout(false);
            plAlbums.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAlbums).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbAlbums2).EndInit();
            tpReviews.ResumeLayout(false);
            tpReviews.PerformLayout();
            plReviews.ResumeLayout(false);
            plReviews.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReviews).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbReviews2).EndInit();
            ssDashBoardForm.ResumeLayout(false);
            ssDashBoardForm.PerformLayout();
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
        private PictureBox pbUsers;
        private PictureBox pbReviews;
        private PictureBox pbAlbums;
        private PictureBox pbSongs;
        private PictureBox pbUsers2;
        private PictureBox pbSongs2;
        private PictureBox pbAlbums2;
        private PictureBox pbReviews2;
        private Panel plAlbums;
        private Button btnDeleteAlbum;
        private Button btnViewAlbum;
        private Button btnUpdateAlbum;
        private ComboBox cbFilterAlbums;
        private Label lblFilterAlbums;
        private DataGridView dgvAlbums;
        private Label lblSearchAlbums;
        private TextBox tbSearchAlbums;
        private Button bntAddAlbum;
        private Panel plReviews;
        private Button btnDelteReviews;
        private Button btnViewReviews;
        private ComboBox cbFilterReviews;
        private Label lblFilterReviews;
        private DataGridView dgvReviews;
        private Label lblSearchReviews;
        private TextBox tbSearchReviews;
        private Button btnWarningReviews;
        private StatusStrip ssDashBoardForm;
        private ToolStripStatusLabel tsslblDashBoardForm;
    }
}