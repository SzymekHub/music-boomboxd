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
            cbGenre = new ComboBox();
            BtnAddSong = new Button();
            tbArtistSong = new TextBox();
            tbTitleSong = new TextBox();
            lblDateSong = new Label();
            lblGenreSong = new Label();
            lblArtistSong = new Label();
            lblTtitleSong = new Label();
            ssNewSongForm = new StatusStrip();
            tsslblNewSongForm = new ToolStripStatusLabel();
            tsslblNewSongFormCSV = new ToolStripStatusLabel();
            pbLogo = new PictureBox();
            btnCancel = new Button();
            NewSongPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SelectedCoverSong).BeginInit();
            ssNewSongForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            SuspendLayout();
            // 
            // NewSongPanel
            // 
            NewSongPanel.BackColor = Color.DarkGray;
            NewSongPanel.Controls.Add(btnCancel);
            NewSongPanel.Controls.Add(pbLogo);
            NewSongPanel.Controls.Add(SelectedCoverSong);
            NewSongPanel.Controls.Add(btnAddPictureSong);
            NewSongPanel.Controls.Add(lblCoverSong);
            NewSongPanel.Controls.Add(DatePickerSong);
            NewSongPanel.Controls.Add(cbGenre);
            NewSongPanel.Controls.Add(BtnAddSong);
            NewSongPanel.Controls.Add(tbArtistSong);
            NewSongPanel.Controls.Add(tbTitleSong);
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
            SelectedCoverSong.Location = new Point(172, 9);
            SelectedCoverSong.Name = "SelectedCoverSong";
            SelectedCoverSong.Size = new Size(141, 113);
            SelectedCoverSong.SizeMode = PictureBoxSizeMode.Zoom;
            SelectedCoverSong.TabIndex = 34;
            SelectedCoverSong.TabStop = false;
            // 
            // btnAddPictureSong
            // 
            btnAddPictureSong.BackColor = Color.MediumSlateBlue;
            btnAddPictureSong.Location = new Point(337, 51);
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
            lblCoverSong.Location = new Point(49, 21);
            lblCoverSong.Name = "lblCoverSong";
            lblCoverSong.Size = new Size(117, 33);
            lblCoverSong.TabIndex = 31;
            lblCoverSong.Text = "Cover:";
            // 
            // DatePickerSong
            // 
            DatePickerSong.Checked = false;
            DatePickerSong.ImeMode = ImeMode.NoControl;
            DatePickerSong.Location = new Point(172, 169);
            DatePickerSong.Name = "DatePickerSong";
            DatePickerSong.Size = new Size(262, 27);
            DatePickerSong.TabIndex = 30;
            // 
            // cbGenre
            // 
            cbGenre.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGenre.FormattingEnabled = true;
            cbGenre.Location = new Point(172, 272);
            cbGenre.Name = "cbGenre";
            cbGenre.Size = new Size(262, 28);
            cbGenre.TabIndex = 20;
            // 
            // BtnAddSong
            // 
            BtnAddSong.BackColor = Color.MediumSlateBlue;
            BtnAddSong.Location = new Point(540, 169);
            BtnAddSong.Name = "BtnAddSong";
            BtnAddSong.Size = new Size(127, 57);
            BtnAddSong.TabIndex = 19;
            BtnAddSong.Text = "Add Song";
            BtnAddSong.UseVisualStyleBackColor = false;
            BtnAddSong.Click += BtnAddSong_Click;
            // 
            // tbArtistSong
            // 
            tbArtistSong.Location = new Point(172, 217);
            tbArtistSong.Name = "tbArtistSong";
            tbArtistSong.Size = new Size(262, 27);
            tbArtistSong.TabIndex = 17;
            // 
            // tbTitleSong
            // 
            tbTitleSong.Location = new Point(172, 128);
            tbTitleSong.Name = "tbTitleSong";
            tbTitleSong.Size = new Size(262, 27);
            tbTitleSong.TabIndex = 16;
            // 
            // lblDateSong
            // 
            lblDateSong.AutoSize = true;
            lblDateSong.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDateSong.Location = new Point(61, 165);
            lblDateSong.Name = "lblDateSong";
            lblDateSong.Size = new Size(105, 33);
            lblDateSong.TabIndex = 15;
            lblDateSong.Text = "Date :";
            // 
            // lblGenreSong
            // 
            lblGenreSong.AutoSize = true;
            lblGenreSong.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGenreSong.Location = new Point(40, 267);
            lblGenreSong.Name = "lblGenreSong";
            lblGenreSong.Size = new Size(126, 33);
            lblGenreSong.TabIndex = 14;
            lblGenreSong.Text = "Genre :";
            // 
            // lblArtistSong
            // 
            lblArtistSong.AutoSize = true;
            lblArtistSong.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblArtistSong.Location = new Point(29, 211);
            lblArtistSong.Name = "lblArtistSong";
            lblArtistSong.Size = new Size(137, 33);
            lblArtistSong.TabIndex = 13;
            lblArtistSong.Text = "Artist :";
            // 
            // lblTtitleSong
            // 
            lblTtitleSong.AutoSize = true;
            lblTtitleSong.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTtitleSong.Location = new Point(52, 122);
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
            ssNewSongForm.Location = new Point(0, 432);
            ssNewSongForm.Name = "ssNewSongForm";
            ssNewSongForm.Size = new Size(797, 22);
            ssNewSongForm.TabIndex = 24;
            ssNewSongForm.Text = "statusStrip1";
            // 
            // tsslblNewSongForm
            // 
            tsslblNewSongForm.ActiveLinkColor = Color.LavenderBlush;
            tsslblNewSongForm.Name = "tsslblNewSongForm";
            tsslblNewSongForm.Size = new Size(0, 16);
            // 
            // tsslblNewSongFormCSV
            // 
            tsslblNewSongFormCSV.ActiveLinkColor = Color.LavenderBlush;
            tsslblNewSongFormCSV.Name = "tsslblNewSongFormCSV";
            tsslblNewSongFormCSV.Size = new Size(0, 16);
            // 
            // pbLogo
            // 
            pbLogo.Image = Properties.Resources.LogoBlue1;
            pbLogo.Location = new Point(609, 0);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(109, 90);
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.TabIndex = 36;
            pbLogo.TabStop = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.MediumSlateBlue;
            btnCancel.Location = new Point(540, 232);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(127, 33);
            btnCancel.TabIndex = 37;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
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
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel NewSongPanel;
        private ComboBox cbGenre;
        private Button BtnAddSong;
        private TextBox tbArtistSong;
        private TextBox tbTitleSong;
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
        private PictureBox pbLogo;
        private Button btnCancel;
    }
}
