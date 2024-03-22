namespace WinFormsApp
{
    partial class NewMusic_Form
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
            lblTtitle = new Label();
            GBmusic = new GroupBox();
            BtnAdd = new Button();
            DatePicker = new DateTimePicker();
            TxtGenre = new TextBox();
            TxtArtist = new TextBox();
            TxtTitle = new TextBox();
            lblDate = new Label();
            lblGenre = new Label();
            lblArtist = new Label();
            GBmusic.SuspendLayout();
            SuspendLayout();
            // 
            // lblTtitle
            // 
            lblTtitle.AutoSize = true;
            lblTtitle.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTtitle.Location = new Point(43, 43);
            lblTtitle.Name = "lblTtitle";
            lblTtitle.Size = new Size(114, 33);
            lblTtitle.TabIndex = 0;
            lblTtitle.Text = "Title :";
            // 
            // GBmusic
            // 
            GBmusic.BackColor = Color.CornflowerBlue;
            GBmusic.Controls.Add(BtnAdd);
            GBmusic.Controls.Add(DatePicker);
            GBmusic.Controls.Add(TxtGenre);
            GBmusic.Controls.Add(TxtArtist);
            GBmusic.Controls.Add(TxtTitle);
            GBmusic.Controls.Add(lblDate);
            GBmusic.Controls.Add(lblGenre);
            GBmusic.Controls.Add(lblArtist);
            GBmusic.Controls.Add(lblTtitle);
            GBmusic.Location = new Point(40, 23);
            GBmusic.Name = "GBmusic";
            GBmusic.Size = new Size(611, 334);
            GBmusic.TabIndex = 1;
            GBmusic.TabStop = false;
            GBmusic.Text = "Add New Music";
            // 
            // BtnAdd
            // 
            BtnAdd.BackColor = SystemColors.ActiveCaption;
            BtnAdd.Location = new Point(444, 252);
            BtnAdd.Name = "BtnAdd";
            BtnAdd.Size = new Size(127, 57);
            BtnAdd.TabIndex = 8;
            BtnAdd.Text = "Add Music";
            BtnAdd.UseVisualStyleBackColor = false;
            BtnAdd.Click += BtnAdd_Click;
            // 
            // DatePicker
            // 
            DatePicker.Location = new Point(163, 204);
            DatePicker.Name = "DatePicker";
            DatePicker.Size = new Size(262, 27);
            DatePicker.TabIndex = 7;
            // 
            // TxtGenre
            // 
            TxtGenre.Location = new Point(163, 152);
            TxtGenre.Name = "TxtGenre";
            TxtGenre.Size = new Size(262, 27);
            TxtGenre.TabIndex = 6;
            // 
            // TxtArtist
            // 
            TxtArtist.Location = new Point(163, 102);
            TxtArtist.Name = "TxtArtist";
            TxtArtist.Size = new Size(262, 27);
            TxtArtist.TabIndex = 5;
            // 
            // TxtTitle
            // 
            TxtTitle.Location = new Point(163, 49);
            TxtTitle.Name = "TxtTitle";
            TxtTitle.Size = new Size(262, 27);
            TxtTitle.TabIndex = 4;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDate.Location = new Point(52, 198);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(105, 33);
            lblDate.TabIndex = 3;
            lblDate.Text = "Date :";
            // 
            // lblGenre
            // 
            lblGenre.AutoSize = true;
            lblGenre.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGenre.Location = new Point(31, 146);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(126, 33);
            lblGenre.TabIndex = 2;
            lblGenre.Text = "Genre :";
            // 
            // lblArtist
            // 
            lblArtist.AutoSize = true;
            lblArtist.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblArtist.Location = new Point(20, 96);
            lblArtist.Name = "lblArtist";
            lblArtist.Size = new Size(137, 33);
            lblArtist.TabIndex = 1;
            lblArtist.Text = "Artist :";
            // 
            // NewMusicForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SeaGreen;
            ClientSize = new Size(723, 395);
            Controls.Add(GBmusic);
            Name = "NewMusicForm";
            Text = "Form1";
            GBmusic.ResumeLayout(false);
            GBmusic.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTtitle;
        private GroupBox GBmusic;
        private Label lblGenre;
        private Label lblArtist;
        private DateTimePicker DatePicker;
        private TextBox TxtGenre;
        private TextBox TxtArtist;
        private TextBox TxtTitle;
        private Label lblDate;
        private Button BtnAdd;
    }
}
