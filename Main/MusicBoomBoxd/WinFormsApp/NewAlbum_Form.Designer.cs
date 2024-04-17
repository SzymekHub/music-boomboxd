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
            NewMusicPanel = new Panel();
            SelectedCover = new PictureBox();
            btnAddPicture = new Button();
            lblCover = new Label();
            DatePicker = new DateTimePicker();
            lblRecent = new Label();
            lbRecent = new ListBox();
            CbGenre = new ComboBox();
            BtnAdd = new Button();
            TxtArtist = new TextBox();
            TxtTitle = new TextBox();
            lblDate = new Label();
            lblGenre = new Label();
            lblArtist = new Label();
            lblTtitle = new Label();
            NewMusicPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SelectedCover).BeginInit();
            SuspendLayout();
            // 
            // NewMusicPanel
            // 
            NewMusicPanel.BackColor = Color.DarkGray;
            NewMusicPanel.Controls.Add(SelectedCover);
            NewMusicPanel.Controls.Add(btnAddPicture);
            NewMusicPanel.Controls.Add(lblCover);
            NewMusicPanel.Controls.Add(DatePicker);
            NewMusicPanel.Controls.Add(lblRecent);
            NewMusicPanel.Controls.Add(lbRecent);
            NewMusicPanel.Controls.Add(CbGenre);
            NewMusicPanel.Controls.Add(BtnAdd);
            NewMusicPanel.Controls.Add(TxtArtist);
            NewMusicPanel.Controls.Add(TxtTitle);
            NewMusicPanel.Controls.Add(lblDate);
            NewMusicPanel.Controls.Add(lblGenre);
            NewMusicPanel.Controls.Add(lblArtist);
            NewMusicPanel.Controls.Add(lblTtitle);
            NewMusicPanel.Location = new Point(41, 39);
            NewMusicPanel.Name = "NewMusicPanel";
            NewMusicPanel.Size = new Size(718, 373);
            NewMusicPanel.TabIndex = 13;
            // 
            // SelectedCover
            // 
            SelectedCover.Location = new Point(209, 224);
            SelectedCover.Name = "SelectedCover";
            SelectedCover.Size = new Size(88, 74);
            SelectedCover.SizeMode = PictureBoxSizeMode.Zoom;
            SelectedCover.TabIndex = 34;
            SelectedCover.TabStop = false;
            // 
            // btnAddPicture
            // 
            btnAddPicture.BackColor = Color.MediumSlateBlue;
            btnAddPicture.Location = new Point(303, 228);
            btnAddPicture.Name = "btnAddPicture";
            btnAddPicture.Size = new Size(97, 30);
            btnAddPicture.TabIndex = 32;
            btnAddPicture.Text = "Add Picture";
            btnAddPicture.UseVisualStyleBackColor = false;
            // 
            // lblCover
            // 
            lblCover.AutoSize = true;
            lblCover.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCover.Location = new Point(86, 224);
            lblCover.Name = "lblCover";
            lblCover.Size = new Size(117, 33);
            lblCover.TabIndex = 31;
            lblCover.Text = "Cover:";
            // 
            // DatePicker
            // 
            DatePicker.Checked = false;
            DatePicker.ImeMode = ImeMode.NoControl;
            DatePicker.Location = new Point(209, 185);
            DatePicker.Name = "DatePicker";
            DatePicker.Size = new Size(262, 27);
            DatePicker.TabIndex = 30;
            // 
            // lblRecent
            // 
            lblRecent.AutoSize = true;
            lblRecent.Font = new Font("Stencil", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRecent.Location = new Point(19, 273);
            lblRecent.Name = "lblRecent";
            lblRecent.Size = new Size(157, 24);
            lblRecent.TabIndex = 22;
            lblRecent.Text = "Recent Adds:";
            // 
            // lbRecent
            // 
            lbRecent.FormattingEnabled = true;
            lbRecent.Location = new Point(16, 300);
            lbRecent.Name = "lbRecent";
            lbRecent.Size = new Size(686, 64);
            lbRecent.TabIndex = 21;
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
            // BtnAdd
            // 
            BtnAdd.BackColor = Color.MediumSlateBlue;
            BtnAdd.Location = new Point(538, 98);
            BtnAdd.Name = "BtnAdd";
            BtnAdd.Size = new Size(127, 57);
            BtnAdd.TabIndex = 19;
            BtnAdd.Text = "Add Music";
            BtnAdd.UseVisualStyleBackColor = false;
            // 
            // TxtArtist
            // 
            TxtArtist.Location = new Point(209, 83);
            TxtArtist.Name = "TxtArtist";
            TxtArtist.Size = new Size(262, 27);
            TxtArtist.TabIndex = 17;
            // 
            // TxtTitle
            // 
            TxtTitle.Location = new Point(209, 30);
            TxtTitle.Name = "TxtTitle";
            TxtTitle.Size = new Size(262, 27);
            TxtTitle.TabIndex = 16;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDate.Location = new Point(98, 179);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(105, 33);
            lblDate.TabIndex = 15;
            lblDate.Text = "Date :";
            // 
            // lblGenre
            // 
            lblGenre.AutoSize = true;
            lblGenre.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGenre.Location = new Point(77, 127);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(126, 33);
            lblGenre.TabIndex = 14;
            lblGenre.Text = "Genre :";
            // 
            // lblArtist
            // 
            lblArtist.AutoSize = true;
            lblArtist.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblArtist.Location = new Point(66, 77);
            lblArtist.Name = "lblArtist";
            lblArtist.Size = new Size(137, 33);
            lblArtist.TabIndex = 13;
            lblArtist.Text = "Artist :";
            // 
            // lblTtitle
            // 
            lblTtitle.AutoSize = true;
            lblTtitle.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTtitle.Location = new Point(89, 24);
            lblTtitle.Name = "lblTtitle";
            lblTtitle.Size = new Size(114, 33);
            lblTtitle.TabIndex = 12;
            lblTtitle.Text = "Title :";
            // 
            // NewAlbum_Form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumSlateBlue;
            ClientSize = new Size(800, 450);
            Controls.Add(NewMusicPanel);
            Name = "NewAlbum_Form";
            Text = "NewAlbum";
            NewMusicPanel.ResumeLayout(false);
            NewMusicPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SelectedCover).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel NewMusicPanel;
        private PictureBox SelectedCover;
        private Button btnAddPicture;
        private Label lblCover;
        private DateTimePicker DatePicker;
        private Label lblRecent;
        private ListBox lbRecent;
        private ComboBox CbGenre;
        private Button BtnAdd;
        private TextBox TxtArtist;
        private TextBox TxtTitle;
        private Label lblDate;
        private Label lblGenre;
        private Label lblArtist;
        private Label lblTtitle;
    }
}