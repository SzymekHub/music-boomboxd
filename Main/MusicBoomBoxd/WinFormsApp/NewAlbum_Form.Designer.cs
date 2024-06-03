namespace WinFormsApp
{
    partial class NewAlbum_Form
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
            NewAlbumPanel = new Panel();
            btnAddSongs = new Button();
            cklbSongs = new CheckedListBox();
            lblSongs = new Label();
            lblSeconds = new Label();
            nudRunTimeAlbum = new NumericUpDown();
            lblRunTime = new Label();
            cbArtistAlbum = new ComboBox();
            btnCancel = new Button();
            pbLogo = new PictureBox();
            SelectedCoverAlbum = new PictureBox();
            btnAddPictureAlbum = new Button();
            lblCoverAlbum = new Label();
            DatePickerAlbum = new DateTimePicker();
            cbGenreAlbum = new ComboBox();
            btnAddAlbum = new Button();
            tbTitleAlbum = new TextBox();
            lblDateAlbum = new Label();
            lblGenreAlbum = new Label();
            lblArtistAlbum = new Label();
            lblTtitleAlbum = new Label();
            ssNewAlbumForm = new StatusStrip();
            tsslblNewAlbumForm = new ToolStripStatusLabel();
            tsslblNewAlbumFormCSV = new ToolStripStatusLabel();
            NewAlbumPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudRunTimeAlbum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SelectedCoverAlbum).BeginInit();
            ssNewAlbumForm.SuspendLayout();
            SuspendLayout();
            // 
            // NewAlbumPanel
            // 
            NewAlbumPanel.BackColor = Color.DarkGray;
            NewAlbumPanel.Controls.Add(btnAddSongs);
            NewAlbumPanel.Controls.Add(cklbSongs);
            NewAlbumPanel.Controls.Add(lblSongs);
            NewAlbumPanel.Controls.Add(lblSeconds);
            NewAlbumPanel.Controls.Add(nudRunTimeAlbum);
            NewAlbumPanel.Controls.Add(lblRunTime);
            NewAlbumPanel.Controls.Add(cbArtistAlbum);
            NewAlbumPanel.Controls.Add(btnCancel);
            NewAlbumPanel.Controls.Add(pbLogo);
            NewAlbumPanel.Controls.Add(SelectedCoverAlbum);
            NewAlbumPanel.Controls.Add(btnAddPictureAlbum);
            NewAlbumPanel.Controls.Add(lblCoverAlbum);
            NewAlbumPanel.Controls.Add(DatePickerAlbum);
            NewAlbumPanel.Controls.Add(cbGenreAlbum);
            NewAlbumPanel.Controls.Add(btnAddAlbum);
            NewAlbumPanel.Controls.Add(tbTitleAlbum);
            NewAlbumPanel.Controls.Add(lblDateAlbum);
            NewAlbumPanel.Controls.Add(lblGenreAlbum);
            NewAlbumPanel.Controls.Add(lblArtistAlbum);
            NewAlbumPanel.Controls.Add(lblTtitleAlbum);
            NewAlbumPanel.Location = new Point(41, 39);
            NewAlbumPanel.Name = "NewAlbumPanel";
            NewAlbumPanel.Size = new Size(895, 485);
            NewAlbumPanel.TabIndex = 13;
            // 
            // btnAddSongs
            // 
            btnAddSongs.BackColor = Color.MediumSlateBlue;
            btnAddSongs.Location = new Point(611, 329);
            btnAddSongs.Name = "btnAddSongs";
            btnAddSongs.Size = new Size(127, 49);
            btnAddSongs.TabIndex = 43;
            btnAddSongs.Text = "Add Songs";
            btnAddSongs.UseVisualStyleBackColor = false;
            btnAddSongs.Click += btnAddSongs_Click;
            // 
            // cklbSongs
            // 
            cklbSongs.FormattingEnabled = true;
            cklbSongs.Location = new Point(456, 77);
            cklbSongs.Name = "cklbSongs";
            cklbSongs.Size = new Size(282, 246);
            cklbSongs.TabIndex = 42;
            // 
            // lblSongs
            // 
            lblSongs.AutoSize = true;
            lblSongs.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSongs.Location = new Point(456, 41);
            lblSongs.Name = "lblSongs";
            lblSongs.Size = new Size(116, 33);
            lblSongs.TabIndex = 41;
            lblSongs.Text = "Songs:";
            // 
            // lblSeconds
            // 
            lblSeconds.AutoSize = true;
            lblSeconds.Font = new Font("Stencil", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSeconds.Location = new Point(308, 393);
            lblSeconds.Name = "lblSeconds";
            lblSeconds.Size = new Size(138, 27);
            lblSeconds.TabIndex = 40;
            lblSeconds.Text = "(Seconds)";
            // 
            // nudRunTimeAlbum
            // 
            nudRunTimeAlbum.Location = new Point(184, 396);
            nudRunTimeAlbum.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nudRunTimeAlbum.Name = "nudRunTimeAlbum";
            nudRunTimeAlbum.Size = new Size(118, 27);
            nudRunTimeAlbum.TabIndex = 39;
            // 
            // lblRunTime
            // 
            lblRunTime.AutoSize = true;
            lblRunTime.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRunTime.Location = new Point(14, 396);
            lblRunTime.Name = "lblRunTime";
            lblRunTime.Size = new Size(164, 33);
            lblRunTime.TabIndex = 38;
            lblRunTime.Text = "RunTime :";
            // 
            // cbArtistAlbum
            // 
            cbArtistAlbum.FormattingEnabled = true;
            cbArtistAlbum.Location = new Point(184, 293);
            cbArtistAlbum.Name = "cbArtistAlbum";
            cbArtistAlbum.Size = new Size(262, 28);
            cbArtistAlbum.TabIndex = 37;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.MediumSlateBlue;
            btnCancel.Location = new Point(753, 236);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(127, 33);
            btnCancel.TabIndex = 36;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // pbLogo
            // 
            pbLogo.Image = Properties.Resources.LogoBlue1;
            pbLogo.Location = new Point(786, 0);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(109, 90);
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.TabIndex = 35;
            pbLogo.TabStop = false;
            // 
            // SelectedCoverAlbum
            // 
            SelectedCoverAlbum.Location = new Point(184, 41);
            SelectedCoverAlbum.Name = "SelectedCoverAlbum";
            SelectedCoverAlbum.Size = new Size(159, 141);
            SelectedCoverAlbum.SizeMode = PictureBoxSizeMode.Zoom;
            SelectedCoverAlbum.TabIndex = 34;
            SelectedCoverAlbum.TabStop = false;
            // 
            // btnAddPictureAlbum
            // 
            btnAddPictureAlbum.BackColor = Color.MediumSlateBlue;
            btnAddPictureAlbum.Location = new Point(349, 106);
            btnAddPictureAlbum.Name = "btnAddPictureAlbum";
            btnAddPictureAlbum.Size = new Size(97, 30);
            btnAddPictureAlbum.TabIndex = 32;
            btnAddPictureAlbum.Text = "Add Picture";
            btnAddPictureAlbum.UseVisualStyleBackColor = false;
            btnAddPictureAlbum.Click += btnAddPictureAlbum_Click;
            // 
            // lblCoverAlbum
            // 
            lblCoverAlbum.AutoSize = true;
            lblCoverAlbum.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCoverAlbum.Location = new Point(61, 102);
            lblCoverAlbum.Name = "lblCoverAlbum";
            lblCoverAlbum.Size = new Size(117, 33);
            lblCoverAlbum.TabIndex = 31;
            lblCoverAlbum.Text = "Cover:";
            // 
            // DatePickerAlbum
            // 
            DatePickerAlbum.Checked = false;
            DatePickerAlbum.ImeMode = ImeMode.NoControl;
            DatePickerAlbum.Location = new Point(184, 236);
            DatePickerAlbum.Name = "DatePickerAlbum";
            DatePickerAlbum.Size = new Size(262, 27);
            DatePickerAlbum.TabIndex = 30;
            // 
            // cbGenreAlbum
            // 
            cbGenreAlbum.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGenreAlbum.FormattingEnabled = true;
            cbGenreAlbum.Location = new Point(184, 350);
            cbGenreAlbum.Name = "cbGenreAlbum";
            cbGenreAlbum.Size = new Size(262, 28);
            cbGenreAlbum.TabIndex = 20;
            // 
            // btnAddAlbum
            // 
            btnAddAlbum.BackColor = Color.MediumSlateBlue;
            btnAddAlbum.Location = new Point(753, 173);
            btnAddAlbum.Name = "btnAddAlbum";
            btnAddAlbum.Size = new Size(127, 57);
            btnAddAlbum.TabIndex = 19;
            btnAddAlbum.Text = "Add Album";
            btnAddAlbum.UseVisualStyleBackColor = false;
            btnAddAlbum.Click += BtnAddAlbum_Click;
            // 
            // tbTitleAlbum
            // 
            tbTitleAlbum.Location = new Point(184, 188);
            tbTitleAlbum.Name = "tbTitleAlbum";
            tbTitleAlbum.Size = new Size(262, 27);
            tbTitleAlbum.TabIndex = 16;
            // 
            // lblDateAlbum
            // 
            lblDateAlbum.AutoSize = true;
            lblDateAlbum.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDateAlbum.Location = new Point(73, 233);
            lblDateAlbum.Name = "lblDateAlbum";
            lblDateAlbum.Size = new Size(105, 33);
            lblDateAlbum.TabIndex = 15;
            lblDateAlbum.Text = "Date :";
            // 
            // lblGenreAlbum
            // 
            lblGenreAlbum.AutoSize = true;
            lblGenreAlbum.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGenreAlbum.Location = new Point(52, 345);
            lblGenreAlbum.Name = "lblGenreAlbum";
            lblGenreAlbum.Size = new Size(126, 33);
            lblGenreAlbum.TabIndex = 14;
            lblGenreAlbum.Text = "Genre :";
            // 
            // lblArtistAlbum
            // 
            lblArtistAlbum.AutoSize = true;
            lblArtistAlbum.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblArtistAlbum.Location = new Point(41, 293);
            lblArtistAlbum.Name = "lblArtistAlbum";
            lblArtistAlbum.Size = new Size(137, 33);
            lblArtistAlbum.TabIndex = 13;
            lblArtistAlbum.Text = "Artist :";
            // 
            // lblTtitleAlbum
            // 
            lblTtitleAlbum.AutoSize = true;
            lblTtitleAlbum.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTtitleAlbum.Location = new Point(64, 182);
            lblTtitleAlbum.Name = "lblTtitleAlbum";
            lblTtitleAlbum.Size = new Size(114, 33);
            lblTtitleAlbum.TabIndex = 12;
            lblTtitleAlbum.Text = "Title :";
            // 
            // ssNewAlbumForm
            // 
            ssNewAlbumForm.BackColor = Color.MediumSlateBlue;
            ssNewAlbumForm.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ssNewAlbumForm.ImageScalingSize = new Size(24, 24);
            ssNewAlbumForm.Items.AddRange(new ToolStripItem[] { tsslblNewAlbumForm, tsslblNewAlbumFormCSV });
            ssNewAlbumForm.Location = new Point(0, 547);
            ssNewAlbumForm.Name = "ssNewAlbumForm";
            ssNewAlbumForm.Size = new Size(976, 22);
            ssNewAlbumForm.TabIndex = 25;
            ssNewAlbumForm.Text = "statusStrip1";
            // 
            // tsslblNewAlbumForm
            // 
            tsslblNewAlbumForm.ActiveLinkColor = Color.LavenderBlush;
            tsslblNewAlbumForm.Name = "tsslblNewAlbumForm";
            tsslblNewAlbumForm.Size = new Size(0, 16);
            // 
            // tsslblNewAlbumFormCSV
            // 
            tsslblNewAlbumFormCSV.ActiveLinkColor = Color.LavenderBlush;
            tsslblNewAlbumFormCSV.Name = "tsslblNewAlbumFormCSV";
            tsslblNewAlbumFormCSV.Size = new Size(0, 16);
            // 
            // NewAlbum_Form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumSlateBlue;
            ClientSize = new Size(976, 569);
            Controls.Add(ssNewAlbumForm);
            Controls.Add(NewAlbumPanel);
            Name = "NewAlbum_Form";
            Text = "NewAlbum";
            FormClosed += NewAlbum_Form_FormClosed;
            NewAlbumPanel.ResumeLayout(false);
            NewAlbumPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudRunTimeAlbum).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)SelectedCoverAlbum).EndInit();
            ssNewAlbumForm.ResumeLayout(false);
            ssNewAlbumForm.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel NewAlbumPanel;
        private PictureBox SelectedCoverAlbum;
        private Button btnAddPictureAlbum;
        private Label lblCoverAlbum;
        private DateTimePicker DatePickerAlbum;
        private ComboBox cbGenreAlbum;
        private Button btnAddAlbum;
        private TextBox tbTitleAlbum;
        private Label lblDateAlbum;
        private Label lblGenreAlbum;
        private Label lblArtistAlbum;
        private Label lblTtitleAlbum;
        private StatusStrip ssNewAlbumForm;
        private ToolStripStatusLabel tsslblNewAlbumForm;
        private ToolStripStatusLabel tsslblNewAlbumFormCSV;
        private PictureBox pbLogo;
        private Button btnCancel;
        private ComboBox cbArtistAlbum;
        private Label lblRunTime;
        private Label lblSeconds;
        private NumericUpDown nudRunTimeAlbum;
        private Label lblSongs;
        private Button btnAddSongs;
        private CheckedListBox cklbSongs;
    }
}