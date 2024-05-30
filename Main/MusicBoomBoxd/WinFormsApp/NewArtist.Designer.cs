namespace WinFormsApp
{
    partial class NewArtist
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
            tsslblNewAlbumFormCSV = new ToolStripStatusLabel();
            this.btnCancelArtist = new Button();
            pbLogo = new PictureBox();
            this.SelectedProfileArtist = new PictureBox();
            this.btnAddProfileArtist = new Button();
            lblProfileArtist = new Label();
            ssNewArtistForm = new StatusStrip();
            tsslblNewAlbumForm = new ToolStripStatusLabel();
            this.tbNameArtist = new TextBox();
            lblNameArtist = new Label();
            btnAddArtist = new Button();
            NewAlbumPanel = new Panel();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.SelectedProfileArtist).BeginInit();
            ssNewArtistForm.SuspendLayout();
            NewAlbumPanel.SuspendLayout();
            SuspendLayout();
            // 
            // tsslblNewAlbumFormCSV
            // 
            tsslblNewAlbumFormCSV.ActiveLinkColor = Color.LavenderBlush;
            tsslblNewAlbumFormCSV.Name = "tsslblNewAlbumFormCSV";
            tsslblNewAlbumFormCSV.Size = new Size(0, 18);
            // 
            // btnCancelArtist
            // 
            this.btnCancelArtist.BackColor = Color.MediumSlateBlue;
            this.btnCancelArtist.Location = new Point(540, 232);
            this.btnCancelArtist.Name = "btnCancelArtist";
            this.btnCancelArtist.Size = new Size(127, 33);
            this.btnCancelArtist.TabIndex = 36;
            this.btnCancelArtist.Text = "Cancel";
            this.btnCancelArtist.UseVisualStyleBackColor = false;
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
            // SelectedProfileArtist
            // 
            this.SelectedProfileArtist.Location = new Point(195, 57);
            this.SelectedProfileArtist.Name = "SelectedProfileArtist";
            this.SelectedProfileArtist.Size = new Size(181, 169);
            this.SelectedProfileArtist.SizeMode = PictureBoxSizeMode.Zoom;
            this.SelectedProfileArtist.TabIndex = 34;
            this.SelectedProfileArtist.TabStop = false;
            // 
            // btnAddProfileArtist
            // 
            this.btnAddProfileArtist.BackColor = Color.MediumSlateBlue;
            this.btnAddProfileArtist.Location = new Point(403, 133);
            this.btnAddProfileArtist.Name = "btnAddProfileArtist";
            this.btnAddProfileArtist.Size = new Size(97, 30);
            this.btnAddProfileArtist.TabIndex = 32;
            this.btnAddProfileArtist.Text = "Add Picture";
            this.btnAddProfileArtist.UseVisualStyleBackColor = false;
            // 
            // lblProfileArtist
            // 
            lblProfileArtist.AutoSize = true;
            lblProfileArtist.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProfileArtist.Location = new Point(40, 129);
            lblProfileArtist.Name = "lblProfileArtist";
            lblProfileArtist.Size = new Size(146, 33);
            lblProfileArtist.TabIndex = 31;
            lblProfileArtist.Text = "Profile:";
            // 
            // ssNewArtistForm
            // 
            ssNewArtistForm.BackColor = Color.MediumSlateBlue;
            ssNewArtistForm.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ssNewArtistForm.ImageScalingSize = new Size(24, 24);
            ssNewArtistForm.Items.AddRange(new ToolStripItem[] { tsslblNewAlbumForm, tsslblNewAlbumFormCSV });
            ssNewArtistForm.Location = new Point(0, 428);
            ssNewArtistForm.Name = "ssNewArtistForm";
            ssNewArtistForm.Size = new Size(800, 22);
            ssNewArtistForm.TabIndex = 27;
            ssNewArtistForm.Text = "statusStrip1";
            // 
            // tsslblNewAlbumForm
            // 
            tsslblNewAlbumForm.ActiveLinkColor = Color.LavenderBlush;
            tsslblNewAlbumForm.Name = "tsslblNewAlbumForm";
            tsslblNewAlbumForm.Size = new Size(0, 18);
            // 
            // tbNameArtist
            // 
            this.tbNameArtist.Location = new Point(195, 264);
            this.tbNameArtist.Name = "tbNameArtist";
            this.tbNameArtist.Size = new Size(262, 27);
            this.tbNameArtist.TabIndex = 16;
            // 
            // lblNameArtist
            // 
            lblNameArtist.AutoSize = true;
            lblNameArtist.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNameArtist.Location = new Point(75, 264);
            lblNameArtist.Name = "lblNameArtist";
            lblNameArtist.Size = new Size(111, 33);
            lblNameArtist.TabIndex = 12;
            lblNameArtist.Text = "Name :";
            // 
            // btnAddArtist
            // 
            btnAddArtist.BackColor = Color.MediumSlateBlue;
            btnAddArtist.Location = new Point(540, 169);
            btnAddArtist.Name = "btnAddArtist";
            btnAddArtist.Size = new Size(127, 57);
            btnAddArtist.TabIndex = 19;
            btnAddArtist.Text = "Add Artist";
            btnAddArtist.UseVisualStyleBackColor = false;
            // 
            // NewAlbumPanel
            // 
            NewAlbumPanel.BackColor = Color.DarkGray;
            NewAlbumPanel.Controls.Add(this.btnCancelArtist);
            NewAlbumPanel.Controls.Add(pbLogo);
            NewAlbumPanel.Controls.Add(this.SelectedProfileArtist);
            NewAlbumPanel.Controls.Add(this.btnAddProfileArtist);
            NewAlbumPanel.Controls.Add(lblProfileArtist);
            NewAlbumPanel.Controls.Add(btnAddArtist);
            NewAlbumPanel.Controls.Add(this.tbNameArtist);
            NewAlbumPanel.Controls.Add(lblNameArtist);
            NewAlbumPanel.Location = new Point(41, 20);
            NewAlbumPanel.Name = "NewAlbumPanel";
            NewAlbumPanel.Size = new Size(718, 373);
            NewAlbumPanel.TabIndex = 26;
            // 
            // NewArtist
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumSlateBlue;
            ClientSize = new Size(800, 450);
            Controls.Add(ssNewArtistForm);
            Controls.Add(NewAlbumPanel);
            Name = "NewArtist";
            Text = "NewArtist";
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.SelectedProfileArtist).EndInit();
            ssNewArtistForm.ResumeLayout(false);
            ssNewArtistForm.PerformLayout();
            NewAlbumPanel.ResumeLayout(false);
            NewAlbumPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStripStatusLabel tsslblNewAlbumFormCSV;
        private ComboBox cbArtistAlbum;
        private Button btnCancel;
        private PictureBox pbLogo;
        private PictureBox SelectedCoverAlbum;
        private Button btnAddPictureAlbum;
        private Label lblProfileArtist;
        private StatusStrip ssNewArtistForm;
        private ToolStripStatusLabel tsslblNewAlbumForm;
        private ComboBox cbGenreAlbum;
        private TextBox tbTitleAlbum;
        private Label lblGenreAlbum;
        private Label lblArtistAlbum;
        private Label lblNameArtist;
        private Button btnAddArtist;
        private Panel NewAlbumPanel;
    }
}