namespace WinFormsApp
{
    partial class NewSong_Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            NewSongPanel = new Panel();
            SelectedCoverSong = new PictureBox();
            btnAddPictureSong = new Button();
            lblCoverSong = new Label();
            DatePickerSong = new DateTimePicker();
            lblRecentSong = new Label();
            lbRecentSong = new ListBox();
            CbGenre = new ComboBox();
            BtnAddSong = new Button();
            TxtArtistSong = new TextBox();
            TxtTitleSong = new TextBox();
            lblDateSong = new Label();
            lblGenreSong = new Label();
            lblArtistSong = new Label();
            lblTtitleSong = new Label();
            ssNewSongForm = new StatusStrip();
            tsslblNewSongForm = new ToolStripStatusLabel();
            tsslblNewSongFormCSV = new ToolStripStatusLabel();
            NewSongPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SelectedCoverSong).BeginInit();
            ssNewSongForm.SuspendLayout();
            SuspendLayout();
            // 
            // NewSongPanel
            // 
            NewSongPanel.BackColor = Color.DarkGray;
            NewSongPanel.Controls.Add(SelectedCoverSong);
            NewSongPanel.Controls.Add(btnAddPictureSong);
            NewSongPanel.Controls.Add(lblCoverSong);
            NewSongPanel.Controls.Add(DatePickerSong);
            NewSongPanel.Controls.Add(lblRecentSong);
            NewSongPanel.Controls.Add(lbRecentSong);
            NewSongPanel.Controls.Add(CbGenre);
            NewSongPanel.Controls.Add(BtnAddSong);
            NewSongPanel.Controls.Add(TxtArtistSong);
            NewSongPanel.Controls.Add(TxtTitleSong);
            NewSongPanel.Controls.Add(lblDateSong);
            NewSongPanel.Controls.Add(lblGenreSong);
            NewSongPanel.Controls.Add(lblArtistSong);
            NewSongPanel.Controls.Add(lblTtitleSong);
            NewSongPanel.Location = new Point(36, 32);
            NewSongPanel.Name = "NewSongPanel";
            NewSongPanel.Size = new Size(718, 373);
            NewSongPanel.TabIndex = 12;
            // 
            // SelectedCoverSong
            // 
            SelectedCoverSong.Location = new Point(209, 224);
            SelectedCoverSong.Name = "SelectedCoverSong";
            SelectedCoverSong.Size = new Size(88, 74);
            SelectedCoverSong.SizeMode = PictureBoxSizeMode.Zoom;
            SelectedCoverSong.TabIndex = 34;
            SelectedCoverSong.TabStop = false;
            // 
            // btnAddPictureSong
            // 
            btnAddPictureSong.BackColor = Color.MediumSlateBlue;
            btnAddPictureSong.Location = new Point(303, 228);
            btnAddPictureSong.Name = "btnAddPictureSong";
            btnAddPictureSong.Size = new Size(97, 30);
            btnAddPictureSong.TabIndex = 32;
            btnAddPictureSong.Text = "Add Picture";
            btnAddPictureSong.UseVisualStyleBackColor = false;
            btnAddPictureSong.Click += btnAddPictureSong_Click;
            // 
            // lblCoverSong
            // 
            lblCoverSong.AutoSize = true;
            lblCoverSong.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCoverSong.Location = new Point(86, 224);
            lblCoverSong.Name = "lblCoverSong";
            lblCoverSong.Size = new Size(117, 33);
            lblCoverSong.TabIndex = 31;
            lblCoverSong.Text = "Cover:";
            // 
            // DatePickerSong
            // 
            DatePickerSong.Checked = false;
            DatePickerSong.ImeMode = ImeMode.NoControl;
            DatePickerSong.Location = new Point(209, 185);
            DatePickerSong.Name = "DatePickerSong";
            DatePickerSong.Size = new Size(262, 27);
            DatePickerSong.TabIndex = 30;
            // 
            // lblRecentSong
            // 
            lblRecentSong.AutoSize = true;
            lblRecentSong.Font = new Font("Stencil", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRecentSong.Location = new Point(19, 273);
            lblRecentSong.Name = "lblRecentSong";
            lblRecentSong.Size = new Size(157, 24);
            lblRecentSong.TabIndex = 22;
            lblRecentSong.Text = "Recent Adds:";
            // 
            // lbRecentSong
            // 
            lbRecentSong.FormattingEnabled = true;
            lbRecentSong.Location = new Point(16, 300);
            lbRecentSong.Name = "lbRecentSong";
            lbRecentSong.Size = new Size(686, 64);
            lbRecentSong.TabIndex = 21;
            // 
            // CbGenre
            // 
            CbGenre.DropDownStyle = ComboBoxStyle.DropDownList;
            CbGenre.FormattingEnabled = true;
            CbGenre.Location = new Point(209, 127);
            CbGenre.Name = "CbGenre";
            CbGenre.Size = new Size(262, 28);
            CbGenre.TabIndex = 20;
            // 
            // BtnAddSong
            // 
            BtnAddSong.BackColor = Color.MediumSlateBlue;
            BtnAddSong.Location = new Point(538, 98);
            BtnAddSong.Name = "BtnAddSong";
            BtnAddSong.Size = new Size(127, 57);
            BtnAddSong.TabIndex = 19;
            BtnAddSong.Text = "Add Song";
            BtnAddSong.UseVisualStyleBackColor = false;
            BtnAddSong.Click += BtnAddSong_Click;
            // 
            // TxtArtistSong
            // 
            TxtArtistSong.Location = new Point(209, 83);
            TxtArtistSong.Name = "TxtArtistSong";
            TxtArtistSong.Size = new Size(262, 27);
            TxtArtistSong.TabIndex = 17;
            // 
            // TxtTitleSong
            // 
            TxtTitleSong.Location = new Point(209, 30);
            TxtTitleSong.Name = "TxtTitleSong";
            TxtTitleSong.Size = new Size(262, 27);
            TxtTitleSong.TabIndex = 16;
            // 
            // lblDateSong
            // 
            lblDateSong.AutoSize = true;
            lblDateSong.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDateSong.Location = new Point(98, 179);
            lblDateSong.Name = "lblDateSong";
            lblDateSong.Size = new Size(105, 33);
            lblDateSong.TabIndex = 15;
            lblDateSong.Text = "Date :";
            // 
            // lblGenreSong
            // 
            lblGenreSong.AutoSize = true;
            lblGenreSong.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGenreSong.Location = new Point(77, 127);
            lblGenreSong.Name = "lblGenreSong";
            lblGenreSong.Size = new Size(126, 33);
            lblGenreSong.TabIndex = 14;
            lblGenreSong.Text = "Genre :";
            // 
            // lblArtistSong
            // 
            lblArtistSong.AutoSize = true;
            lblArtistSong.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblArtistSong.Location = new Point(66, 77);
            lblArtistSong.Name = "lblArtistSong";
            lblArtistSong.Size = new Size(137, 33);
            lblArtistSong.TabIndex = 13;
            lblArtistSong.Text = "Artist :";
            // 
            // lblTtitleSong
            // 
            lblTtitleSong.AutoSize = true;
            lblTtitleSong.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTtitleSong.Location = new Point(89, 24);
            lblTtitleSong.Name = "lblTtitleSong";
            lblTtitleSong.Size = new Size(114, 33);
            lblTtitleSong.TabIndex = 12;
            lblTtitleSong.Text = "Title :";
            // 
            // ssNewSongForm
            // 
            ssNewSongForm.BackColor = Color.MediumSlateBlue;
            ssNewSongForm.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ssNewSongForm.ImageScalingSize = new Size(24, 24);
            ssNewSongForm.Items.AddRange(new ToolStripItem[] { tsslblNewSongForm, tsslblNewSongFormCSV });
            ssNewSongForm.Location = new Point(0, 430);
            ssNewSongForm.Name = "ssNewSongForm";
            ssNewSongForm.Size = new Size(797, 24);
            ssNewSongForm.TabIndex = 24;
            ssNewSongForm.Text = "statusStrip1";
            // 
            // tsslblNewSongForm
            // 
            tsslblNewSongForm.ActiveLinkColor = Color.LavenderBlush;
            tsslblNewSongForm.Name = "tsslblNewSongForm";
            tsslblNewSongForm.Size = new Size(0, 18);
            // 
            // tsslblNewSongFormCSV
            // 
            tsslblNewSongFormCSV.ActiveLinkColor = Color.LavenderBlush;
            tsslblNewSongFormCSV.Name = "tsslblNewSongFormCSV";
            tsslblNewSongFormCSV.Size = new Size(0, 18);
            // 
            // NewSong_Form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumSlateBlue;
            ClientSize = new Size(797, 454);
            Controls.Add(ssNewSongForm);
            Controls.Add(NewSongPanel);
            Name = "NewSong_Form";
            Text = "NewMusicForm";
            FormClosed += NewMusic_Form_FormClosed;
            NewSongPanel.ResumeLayout(false);
            NewSongPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SelectedCoverSong).EndInit();
            ssNewSongForm.ResumeLayout(false);
            ssNewSongForm.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel NewSongPanel;
        private Label lblRecentSong;
        private ListBox lbRecentSong;
        private ComboBox CbGenre;
        private Button BtnAddSong;
        private TextBox TxtArtistSong;
        private TextBox TxtTitleSong;
        private Label lblDateSong;
        private Label lblGenreSong;
        private Label lblArtistSong;
        private Label lblTtitleSong;
        private DateTimePicker DatePickerSong;
        private Label lblCoverSong;
        private Button btnAddPictureSong;
        private PictureBox SelectedCoverSong;
        private StatusStrip ssNewSongForm;
        private ToolStripStatusLabel tsslblNewSongForm;
        private ToolStripStatusLabel tsslblNewSongFormCSV;
    }
}
