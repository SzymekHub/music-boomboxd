namespace WinFormsApp
{
    partial class NewArtist_Form
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
            btnCancelArtist = new Button();
            pbLogo = new PictureBox();
            SelectedProfileArtist = new PictureBox();
            btnAddProfileArtist = new Button();
            lblProfileArtist = new Label();
            ssNewArtistForm = new StatusStrip();
            tsslblNewArtistForm = new ToolStripStatusLabel();
            tbNameArtist = new TextBox();
            lblNameArtist = new Label();
            btnAddArtist = new Button();
            NewArtistPanel = new Panel();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SelectedProfileArtist).BeginInit();
            ssNewArtistForm.SuspendLayout();
            NewArtistPanel.SuspendLayout();
            SuspendLayout();
            // 
            // btnCancelArtist
            // 
            btnCancelArtist.BackColor = Color.MediumSlateBlue;
            btnCancelArtist.Location = new Point(540, 232);
            btnCancelArtist.Name = "btnCancelArtist";
            btnCancelArtist.Size = new Size(127, 33);
            btnCancelArtist.TabIndex = 36;
            btnCancelArtist.Text = "Cancel";
            btnCancelArtist.UseVisualStyleBackColor = false;
            btnCancelArtist.Click += btnCancelArtist_Click;
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
            SelectedProfileArtist.Location = new Point(172, 9);
            SelectedProfileArtist.Name = "SelectedProfileArtist";
            SelectedProfileArtist.Size = new Size(199, 178);
            SelectedProfileArtist.SizeMode = PictureBoxSizeMode.Zoom;
            SelectedProfileArtist.TabIndex = 34;
            SelectedProfileArtist.TabStop = false;
            // 
            // btnAddProfileArtist
            // 
            btnAddProfileArtist.BackColor = Color.MediumSlateBlue;
            btnAddProfileArtist.Location = new Point(409, 86);
            btnAddProfileArtist.Name = "btnAddProfileArtist";
            btnAddProfileArtist.Size = new Size(97, 30);
            btnAddProfileArtist.TabIndex = 32;
            btnAddProfileArtist.Text = "Add Picture";
            btnAddProfileArtist.UseVisualStyleBackColor = false;
            btnAddProfileArtist.Click += btnAddProfileArtist_Click;
            // 
            // lblProfileArtist
            // 
            lblProfileArtist.AutoSize = true;
            lblProfileArtist.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProfileArtist.Location = new Point(17, 83);
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
            ssNewArtistForm.Items.AddRange(new ToolStripItem[] { tsslblNewArtistForm });
            ssNewArtistForm.Location = new Point(0, 428);
            ssNewArtistForm.Name = "ssNewArtistForm";
            ssNewArtistForm.Size = new Size(800, 22);
            ssNewArtistForm.TabIndex = 27;
            ssNewArtistForm.Text = "statusStrip1";
            // 
            // tsslblNewArtistForm
            // 
            tsslblNewArtistForm.ActiveLinkColor = Color.LavenderBlush;
            tsslblNewArtistForm.Name = "tsslblNewArtistForm";
            tsslblNewArtistForm.Size = new Size(0, 16);
            // 
            // tbNameArtist
            // 
            tbNameArtist.Location = new Point(169, 214);
            tbNameArtist.Name = "tbNameArtist";
            tbNameArtist.Size = new Size(262, 27);
            tbNameArtist.TabIndex = 16;
            // 
            // lblNameArtist
            // 
            lblNameArtist.AutoSize = true;
            lblNameArtist.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNameArtist.Location = new Point(52, 208);
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
            btnAddArtist.Click += btnAddArtist_Click;
            // 
            // NewArtistPanel
            // 
            NewArtistPanel.BackColor = Color.DarkGray;
            NewArtistPanel.Controls.Add(btnCancelArtist);
            NewArtistPanel.Controls.Add(pbLogo);
            NewArtistPanel.Controls.Add(SelectedProfileArtist);
            NewArtistPanel.Controls.Add(btnAddProfileArtist);
            NewArtistPanel.Controls.Add(lblProfileArtist);
            NewArtistPanel.Controls.Add(btnAddArtist);
            NewArtistPanel.Controls.Add(tbNameArtist);
            NewArtistPanel.Controls.Add(lblNameArtist);
            NewArtistPanel.Location = new Point(41, 20);
            NewArtistPanel.Name = "NewArtistPanel";
            NewArtistPanel.Size = new Size(718, 373);
            NewArtistPanel.TabIndex = 26;
            // 
            // NewArtist_Form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumSlateBlue;
            ClientSize = new Size(800, 450);
            Controls.Add(ssNewArtistForm);
            Controls.Add(NewArtistPanel);
            Name = "NewArtist_Form";
            Text = "NewArtist_Form";
            FormClosed += NewArtist_Form_FormClosed;
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)SelectedProfileArtist).EndInit();
            ssNewArtistForm.ResumeLayout(false);
            ssNewArtistForm.PerformLayout();
            NewArtistPanel.ResumeLayout(false);
            NewArtistPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStripStatusLabel tsslblNewAlbumFormCSV;
        private Button btnCancelArtist;
        private PictureBox pbLogo;
        private PictureBox SelectedProfileArtist;
        private Button btnAddProfileArtist;
        private Label lblProfileArtist;
        private StatusStrip ssNewArtistForm;
        private ToolStripStatusLabel tsslblNewArtistForm;
        private TextBox tbNameArtist;
        private Label lblNameArtist;
        private Button btnAddArtist;
        private Panel NewArtistPanel;
    }
}