namespace WinFormsApp
{
    partial class Login_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login_Form));
            LoginPanel = new Panel();
            lblWrong = new Label();
            lblPassword = new Label();
            lblUsername = new Label();
            logoPB = new PictureBox();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            btnLogin = new Button();
            label1 = new Label();
            LoginPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoPB).BeginInit();
            SuspendLayout();
            // 
            // LoginPanel
            // 
            LoginPanel.BackColor = Color.DarkGray;
            LoginPanel.Controls.Add(label1);
            LoginPanel.Controls.Add(lblWrong);
            LoginPanel.Controls.Add(lblPassword);
            LoginPanel.Controls.Add(lblUsername);
            LoginPanel.Controls.Add(logoPB);
            LoginPanel.Controls.Add(txtPassword);
            LoginPanel.Controls.Add(txtUsername);
            LoginPanel.Controls.Add(btnLogin);
            LoginPanel.Location = new Point(28, 32);
            LoginPanel.Name = "LoginPanel";
            LoginPanel.Size = new Size(735, 383);
            LoginPanel.TabIndex = 1;
            // 
            // lblWrong
            // 
            lblWrong.AutoSize = true;
            lblWrong.Font = new Font("Tw Cen MT", 10.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblWrong.Location = new Point(158, 281);
            lblWrong.Name = "lblWrong";
            lblWrong.Size = new Size(0, 20);
            lblWrong.TabIndex = 15;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPassword.Location = new Point(165, 247);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(108, 28);
            lblPassword.TabIndex = 14;
            lblPassword.Text = "Password :";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsername.Location = new Point(158, 219);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(115, 28);
            lblUsername.TabIndex = 13;
            lblUsername.Text = "Username :";
            // 
            // logoPB
            // 
            logoPB.Image = (Image)resources.GetObject("logoPB.Image");
            logoPB.Location = new Point(248, 26);
            logoPB.Name = "logoPB";
            logoPB.Size = new Size(233, 172);
            logoPB.SizeMode = PictureBoxSizeMode.Zoom;
            logoPB.TabIndex = 12;
            logoPB.TabStop = false;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(279, 253);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(189, 27);
            txtPassword.TabIndex = 11;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(279, 220);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(189, 27);
            txtUsername.TabIndex = 10;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.MediumSlateBlue;
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.Location = new Point(566, 309);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(113, 52);
            btnLogin.TabIndex = 9;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Location = new Point(22, 42);
            label1.Name = "label1";
            label1.Size = new Size(122, 40);
            label1.TabIndex = 16;
            label1.Text = "The login: Admin\r\nPassword: p\r\n";
            // 
            // Login_Form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumSlateBlue;
            ClientSize = new Size(800, 450);
            Controls.Add(LoginPanel);
            Name = "Login_Form";
            Text = "Login Form";
            LoginPanel.ResumeLayout(false);
            LoginPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)logoPB).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel LoginPanel;
        private Label lblPassword;
        private Label lblUsername;
        private PictureBox logoPB;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private Button btnLogin;
        private Label lblWrong;
        private Label label1;
    }
}
