namespace WinFormsApp
{
    partial class NewUser_Form
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
            panel1 = new Panel();
            btnCancel = new Button();
            btnRegister = new Button();
            CbUserType = new ComboBox();
            label1 = new Label();
            txtPassword = new TextBox();
            lblPassword = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtName = new TextBox();
            lblName = new Label();
            lblTitle = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkGray;
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(btnRegister);
            panel1.Controls.Add(CbUserType);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(lblPassword);
            panel1.Controls.Add(txtEmail);
            panel1.Controls.Add(lblEmail);
            panel1.Controls.Add(txtName);
            panel1.Controls.Add(lblName);
            panel1.Controls.Add(lblTitle);
            panel1.Location = new Point(26, 22);
            panel1.Name = "panel1";
            panel1.Size = new Size(433, 382);
            panel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.MediumSlateBlue;
            btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(311, 335);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(119, 44);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.MediumSlateBlue;
            btnRegister.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegister.Location = new Point(186, 335);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(119, 44);
            btnRegister.TabIndex = 10;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // CbUserType
            // 
            CbUserType.FormattingEnabled = true;
            CbUserType.Location = new Point(140, 233);
            CbUserType.Name = "CbUserType";
            CbUserType.Size = new Size(178, 28);
            CbUserType.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(62, 232);
            label1.Name = "label1";
            label1.Size = new Size(72, 25);
            label1.TabIndex = 7;
            label1.Text = "Genre :";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(140, 182);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(178, 27);
            txtPassword.TabIndex = 6;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPassword.Location = new Point(35, 181);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(99, 25);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "Password :";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(140, 134);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(178, 27);
            txtEmail.TabIndex = 4;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmail.Location = new Point(69, 133);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(65, 25);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "Email :";
            // 
            // txtName
            // 
            txtName.Location = new Point(140, 86);
            txtName.Name = "txtName";
            txtName.Size = new Size(178, 27);
            txtName.TabIndex = 2;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.Location = new Point(29, 85);
            lblName.Name = "lblName";
            lblName.Size = new Size(105, 25);
            lblName.TabIndex = 1;
            lblName.Text = "Username :";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(116, 17);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(202, 31);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "NEW USER FORM";
            // 
            // NewUser_Form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumSlateBlue;
            ClientSize = new Size(498, 431);
            Controls.Add(panel1);
            Name = "NewUser_Form";
            Text = "NewUser_Form";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblTitle;
        private TextBox txtName;
        private Label lblName;
        private Label label1;
        private TextBox txtPassword;
        private Label lblPassword;
        private TextBox txtEmail;
        private Label lblEmail;
        private ComboBox CbUserType;
        private Button btnCancel;
        private Button btnRegister;
    }
}