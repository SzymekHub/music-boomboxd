namespace WinFormsApp
{
    partial class Login_Form
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
            LoginGB = new GroupBox();
            Logo = new PictureBox();
            lblUserName = new Label();
            lblPassword = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnLogIn = new Button();
            LoginGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Logo).BeginInit();
            SuspendLayout();
            // 
            // LoginGB
            // 
            LoginGB.BackColor = Color.CornflowerBlue;
            LoginGB.Controls.Add(btnLogIn);
            LoginGB.Controls.Add(txtPassword);
            LoginGB.Controls.Add(txtUsername);
            LoginGB.Controls.Add(lblPassword);
            LoginGB.Controls.Add(lblUserName);
            LoginGB.Controls.Add(Logo);
            LoginGB.Location = new Point(33, 21);
            LoginGB.Name = "LoginGB";
            LoginGB.Size = new Size(721, 396);
            LoginGB.TabIndex = 0;
            LoginGB.TabStop = false;
            LoginGB.Text = "Login";
            // 
            // Logo
            // 
            Logo.Image = Properties.Resources.LogoBlue_1;
            Logo.Location = new Point(266, 26);
            Logo.Name = "Logo";
            Logo.Size = new Size(211, 140);
            Logo.SizeMode = PictureBoxSizeMode.Zoom;
            Logo.TabIndex = 0;
            Logo.TabStop = false;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserName.Location = new Point(166, 191);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(105, 25);
            lblUserName.TabIndex = 1;
            lblUserName.Text = "Username :";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPassword.Location = new Point(172, 231);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(99, 25);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Password :";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(277, 192);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(200, 27);
            txtUsername.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(277, 232);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(200, 27);
            txtPassword.TabIndex = 4;
            // 
            // btnLogIn
            // 
            btnLogIn.BackColor = Color.SeaGreen;
            btnLogIn.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogIn.ForeColor = SystemColors.ActiveCaptionText;
            btnLogIn.Location = new Point(504, 286);
            btnLogIn.Name = "btnLogIn";
            btnLogIn.Size = new Size(119, 40);
            btnLogIn.TabIndex = 5;
            btnLogIn.Text = "Login";
            btnLogIn.UseVisualStyleBackColor = false;
            btnLogIn.Click += btnLogIn_Click;
            // 
            // Login_Form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SeaGreen;
            ClientSize = new Size(800, 450);
            Controls.Add(LoginGB);
            Name = "Login_Form";
            Text = "Login_Form";
            LoginGB.ResumeLayout(false);
            LoginGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Logo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox LoginGB;
        private PictureBox Logo;
        private Label lblUserName;
        private Button btnLogIn;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private Label lblPassword;
    }
}