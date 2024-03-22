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
            btnReviews = new Button();
            btnMusic = new Button();
            btnUsers = new Button();
            lblHello = new Label();
            logoPB = new PictureBox();
            DashBoardPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoPB).BeginInit();
            SuspendLayout();
            // 
            // DashBoardPanel
            // 
            DashBoardPanel.BackColor = Color.DarkGray;
            DashBoardPanel.Controls.Add(btnReviews);
            DashBoardPanel.Controls.Add(btnMusic);
            DashBoardPanel.Controls.Add(btnUsers);
            DashBoardPanel.Controls.Add(lblHello);
            DashBoardPanel.Controls.Add(logoPB);
            DashBoardPanel.Location = new Point(25, 24);
            DashBoardPanel.Name = "DashBoardPanel";
            DashBoardPanel.Size = new Size(739, 396);
            DashBoardPanel.TabIndex = 0;
            // 
            // btnReviews
            // 
            btnReviews.BackColor = Color.MediumSlateBlue;
            btnReviews.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReviews.Location = new Point(468, 271);
            btnReviews.Name = "btnReviews";
            btnReviews.Size = new Size(199, 58);
            btnReviews.TabIndex = 17;
            btnReviews.Text = "Reviews";
            btnReviews.UseVisualStyleBackColor = false;
            btnReviews.Click += btnReviews_Click;
            // 
            // btnMusic
            // 
            btnMusic.BackColor = Color.MediumSlateBlue;
            btnMusic.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMusic.Location = new Point(263, 193);
            btnMusic.Name = "btnMusic";
            btnMusic.Size = new Size(199, 58);
            btnMusic.TabIndex = 16;
            btnMusic.Text = "Music";
            btnMusic.UseVisualStyleBackColor = false;
            btnMusic.Click += btnMusic_Click;
            // 
            // btnUsers
            // 
            btnUsers.BackColor = Color.MediumSlateBlue;
            btnUsers.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUsers.Location = new Point(57, 122);
            btnUsers.Name = "btnUsers";
            btnUsers.Size = new Size(199, 58);
            btnUsers.TabIndex = 15;
            btnUsers.Text = "Users";
            btnUsers.UseVisualStyleBackColor = false;
            btnUsers.Click += btnUsers_Click;
            // 
            // lblHello
            // 
            lblHello.AutoSize = true;
            lblHello.Font = new Font("Showcard Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHello.Location = new Point(188, 35);
            lblHello.Name = "lblHello";
            lblHello.Size = new Size(0, 23);
            lblHello.TabIndex = 14;
            // 
            // logoPB
            // 
            logoPB.Image = (Image)resources.GetObject("logoPB.Image");
            logoPB.Location = new Point(0, 0);
            logoPB.Name = "logoPB";
            logoPB.Size = new Size(113, 88);
            logoPB.SizeMode = PictureBoxSizeMode.Zoom;
            logoPB.TabIndex = 13;
            logoPB.TabStop = false;
            // 
            // DashBoard_Form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumSlateBlue;
            ClientSize = new Size(800, 450);
            Controls.Add(DashBoardPanel);
            Name = "DashBoard_Form";
            Text = "DashBoard";
            FormClosed += DashBoard_Form_FormClosed;
            DashBoardPanel.ResumeLayout(false);
            DashBoardPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)logoPB).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel DashBoardPanel;
        private Label lblHello;
        private PictureBox logoPB;
        private Button btnReviews;
        private Button btnMusic;
        private Button btnUsers;
    }
}