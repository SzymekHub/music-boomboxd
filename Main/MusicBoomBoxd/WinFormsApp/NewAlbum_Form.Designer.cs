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
            pbLogo = new PictureBox();
            SelectedCoverAlbum = new PictureBox();
            btnAddPictureAlbum = new Button();
            lblCoverAlbum = new Label();
            DatePickerAlbum = new DateTimePicker();
            CbGenreAlbum = new ComboBox();
            BtnAddAlbum = new Button();
            TxtArtistAlbum = new TextBox();
            TxtTitleAlbum = new TextBox();
            lblDateAlbum = new Label();
            lblGenreAlbum = new Label();
            lblArtistAlbum = new Label();
            lblTtitleAlbum = new Label();
            ssNewAlbumForm = new StatusStrip();
            tsslblNewAlbumForm = new ToolStripStatusLabel();
            tsslblNewAlbumFormCSV = new ToolStripStatusLabel();
            btnCancel = new Button();
            NewAlbumPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SelectedCoverAlbum).BeginInit();
            ssNewAlbumForm.SuspendLayout();
            SuspendLayout();
            // 
            // NewAlbumPanel
            // 
            NewAlbumPanel.BackColor = Color.DarkGray;
            NewAlbumPanel.Controls.Add(btnCancel);
            NewAlbumPanel.Controls.Add(pbLogo);
            NewAlbumPanel.Controls.Add(SelectedCoverAlbum);
            NewAlbumPanel.Controls.Add(btnAddPictureAlbum);
            NewAlbumPanel.Controls.Add(lblCoverAlbum);
            NewAlbumPanel.Controls.Add(DatePickerAlbum);
            NewAlbumPanel.Controls.Add(CbGenreAlbum);
            NewAlbumPanel.Controls.Add(BtnAddAlbum);
            NewAlbumPanel.Controls.Add(TxtArtistAlbum);
            NewAlbumPanel.Controls.Add(TxtTitleAlbum);
            NewAlbumPanel.Controls.Add(lblDateAlbum);
            NewAlbumPanel.Controls.Add(lblGenreAlbum);
            NewAlbumPanel.Controls.Add(lblArtistAlbum);
            NewAlbumPanel.Controls.Add(lblTtitleAlbum);
            NewAlbumPanel.Location = new Point(41, 39);
            NewAlbumPanel.Name = "NewAlbumPanel";
            NewAlbumPanel.Size = new Size(718, 373);
            NewAlbumPanel.TabIndex = 13;
            // 
            // pbLogo
            // 
            pbLogo.Image = Properties.Resources.LogoBlue1;
            pbLogo.Location = new Point(609, 0);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(109, 90);
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.TabIndex = 35;
            pbLogo.TabStop = false;
            // 
            // SelectedCoverAlbum
            // 
            SelectedCoverAlbum.Location = new Point(172, 9);
            SelectedCoverAlbum.Name = "SelectedCoverAlbum";
            SelectedCoverAlbum.Size = new Size(141, 113);
            SelectedCoverAlbum.SizeMode = PictureBoxSizeMode.Zoom;
            SelectedCoverAlbum.TabIndex = 34;
            SelectedCoverAlbum.TabStop = false;
            // 
            // btnAddPictureAlbum
            // 
            btnAddPictureAlbum.BackColor = Color.MediumSlateBlue;
            btnAddPictureAlbum.Location = new Point(337, 51);
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
            lblCoverAlbum.Location = new Point(49, 21);
            lblCoverAlbum.Name = "lblCoverAlbum";
            lblCoverAlbum.Size = new Size(117, 33);
            lblCoverAlbum.TabIndex = 31;
            lblCoverAlbum.Text = "Cover:";
            // 
            // DatePickerAlbum
            // 
            DatePickerAlbum.Checked = false;
            DatePickerAlbum.ImeMode = ImeMode.NoControl;
            DatePickerAlbum.Location = new Point(172, 169);
            DatePickerAlbum.Name = "DatePickerAlbum";
            DatePickerAlbum.Size = new Size(262, 27);
            DatePickerAlbum.TabIndex = 30;
            // 
            // CbGenreAlbum
            // 
            CbGenreAlbum.DropDownStyle = ComboBoxStyle.DropDownList;
            CbGenreAlbum.FormattingEnabled = true;
            CbGenreAlbum.Location = new Point(172, 272);
            CbGenreAlbum.Name = "CbGenreAlbum";
            CbGenreAlbum.Size = new Size(262, 28);
            CbGenreAlbum.TabIndex = 20;
            // 
            // BtnAddAlbum
            // 
            BtnAddAlbum.BackColor = Color.MediumSlateBlue;
            BtnAddAlbum.Location = new Point(540, 169);
            BtnAddAlbum.Name = "BtnAddAlbum";
            BtnAddAlbum.Size = new Size(127, 57);
            BtnAddAlbum.TabIndex = 19;
            BtnAddAlbum.Text = "Add Album";
            BtnAddAlbum.UseVisualStyleBackColor = false;
            BtnAddAlbum.Click += BtnAddAlbum_Click;
            // 
            // TxtArtistAlbum
            // 
            TxtArtistAlbum.Location = new Point(172, 217);
            TxtArtistAlbum.Name = "TxtArtistAlbum";
            TxtArtistAlbum.Size = new Size(262, 27);
            TxtArtistAlbum.TabIndex = 17;
            // 
            // TxtTitleAlbum
            // 
            TxtTitleAlbum.Location = new Point(172, 128);
            TxtTitleAlbum.Name = "TxtTitleAlbum";
            TxtTitleAlbum.Size = new Size(262, 27);
            TxtTitleAlbum.TabIndex = 16;
            // 
            // lblDateAlbum
            // 
            lblDateAlbum.AutoSize = true;
            lblDateAlbum.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDateAlbum.Location = new Point(61, 165);
            lblDateAlbum.Name = "lblDateAlbum";
            lblDateAlbum.Size = new Size(105, 33);
            lblDateAlbum.TabIndex = 15;
            lblDateAlbum.Text = "Date :";
            // 
            // lblGenreAlbum
            // 
            lblGenreAlbum.AutoSize = true;
            lblGenreAlbum.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGenreAlbum.Location = new Point(40, 267);
            lblGenreAlbum.Name = "lblGenreAlbum";
            lblGenreAlbum.Size = new Size(126, 33);
            lblGenreAlbum.TabIndex = 14;
            lblGenreAlbum.Text = "Genre :";
            // 
            // lblArtistAlbum
            // 
            lblArtistAlbum.AutoSize = true;
            lblArtistAlbum.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblArtistAlbum.Location = new Point(29, 211);
            lblArtistAlbum.Name = "lblArtistAlbum";
            lblArtistAlbum.Size = new Size(137, 33);
            lblArtistAlbum.TabIndex = 13;
            lblArtistAlbum.Text = "Artist :";
            // 
            // lblTtitleAlbum
            // 
            lblTtitleAlbum.AutoSize = true;
            lblTtitleAlbum.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTtitleAlbum.Location = new Point(52, 122);
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
            ssNewAlbumForm.Location = new Point(0, 428);
            ssNewAlbumForm.Name = "ssNewAlbumForm";
            ssNewAlbumForm.Size = new Size(800, 22);
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
            // btnCancel
            // 
            btnCancel.BackColor = Color.MediumSlateBlue;
            btnCancel.Location = new Point(540, 232);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(127, 33);
            btnCancel.TabIndex = 36;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // NewAlbum_Form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumSlateBlue;
            ClientSize = new Size(800, 450);
            Controls.Add(ssNewAlbumForm);
            Controls.Add(NewAlbumPanel);
            Name = "NewAlbum_Form";
            Text = "NewAlbum";
            FormClosed += NewAlbum_Form_FormClosed;
            NewAlbumPanel.ResumeLayout(false);
            NewAlbumPanel.PerformLayout();
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
        private ComboBox CbGenreAlbum;
        private Button BtnAddAlbum;
        private TextBox TxtArtistAlbum;
        private TextBox TxtTitleAlbum;
        private Label lblDateAlbum;
        private Label lblGenreAlbum;
        private Label lblArtistAlbum;
        private Label lblTtitleAlbum;
        private StatusStrip ssNewAlbumForm;
        private ToolStripStatusLabel tsslblNewAlbumForm;
        private ToolStripStatusLabel tsslblNewAlbumFormCSV;
        private PictureBox pbLogo;
        private Button btnCancel;
    }
}