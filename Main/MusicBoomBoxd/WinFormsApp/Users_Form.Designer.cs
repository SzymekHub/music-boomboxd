namespace WinFormsApp
{
    partial class Users_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Users_Form));
            panel1 = new Panel();
            CbUsers = new ComboBox();
            txtSearch = new TextBox();
            lblSearch = new Label();
            bntDelete = new Button();
            btnAdd = new Button();
            lblUsersList = new Label();
            lbUsers = new ListBox();
            lblUserTitle = new Label();
            logoPB = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoPB).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkGray;
            panel1.Controls.Add(CbUsers);
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(lblSearch);
            panel1.Controls.Add(bntDelete);
            panel1.Controls.Add(btnAdd);
            panel1.Controls.Add(lblUsersList);
            panel1.Controls.Add(lbUsers);
            panel1.Controls.Add(lblUserTitle);
            panel1.Controls.Add(logoPB);
            panel1.Location = new Point(36, 31);
            panel1.Name = "panel1";
            panel1.Size = new Size(711, 371);
            panel1.TabIndex = 0;
            // 
            // CbUsers
            // 
            CbUsers.FormattingEnabled = true;
            CbUsers.Location = new Point(154, 78);
            CbUsers.Name = "CbUsers";
            CbUsers.Size = new Size(107, 28);
            CbUsers.TabIndex = 22;
            CbUsers.SelectedIndexChanged += CbUsers_SelectedIndexChanged;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(82, 296);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(179, 27);
            txtSearch.TabIndex = 21;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSearch.Location = new Point(21, 296);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(60, 20);
            lblSearch.TabIndex = 20;
            lblSearch.Text = "Search :";
            // 
            // bntDelete
            // 
            bntDelete.Location = new Point(82, 339);
            bntDelete.Name = "bntDelete";
            bntDelete.Size = new Size(62, 29);
            bntDelete.TabIndex = 19;
            bntDelete.Text = "Delete";
            bntDelete.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(21, 339);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(55, 29);
            btnAdd.TabIndex = 18;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // lblUsersList
            // 
            lblUsersList.AutoSize = true;
            lblUsersList.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsersList.Location = new Point(21, 83);
            lblUsersList.Name = "lblUsersList";
            lblUsersList.Size = new Size(60, 23);
            lblUsersList.TabIndex = 17;
            lblUsersList.Text = "Users :";
            // 
            // lbUsers
            // 
            lbUsers.FormattingEnabled = true;
            lbUsers.Items.AddRange(new object[] { "Paul", "Amy", "BooperDooper", "Ringo", "George", "Musiclover1234", "IhateTechno3", "Ruby", "Scrim", "BornIntheUSA", "Gustav", "Austin", "Mac", "IloveMac" });
            lbUsers.Location = new Point(21, 109);
            lbUsers.Name = "lbUsers";
            lbUsers.Size = new Size(240, 184);
            lbUsers.TabIndex = 16;
            // 
            // lblUserTitle
            // 
            lblUserTitle.AutoSize = true;
            lblUserTitle.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserTitle.Location = new Point(269, 34);
            lblUserTitle.Name = "lblUserTitle";
            lblUserTitle.Size = new Size(198, 38);
            lblUserTitle.TabIndex = 15;
            lblUserTitle.Text = "Manage Users";
            // 
            // logoPB
            // 
            logoPB.Image = (Image)resources.GetObject("logoPB.Image");
            logoPB.Location = new Point(0, 0);
            logoPB.Name = "logoPB";
            logoPB.Size = new Size(105, 80);
            logoPB.SizeMode = PictureBoxSizeMode.Zoom;
            logoPB.TabIndex = 14;
            logoPB.TabStop = false;
            // 
            // Users_Form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumSlateBlue;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "Users_Form";
            Text = "Users_Form";
            FormClosed += Users_Form_FormClosed;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)logoPB).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox logoPB;
        private Label lblUserTitle;
        private Label lblUsersList;
        private ListBox lbUsers;
        private Label lblSearch;
        private Button bntDelete;
        private Button btnAdd;
        private TextBox txtSearch;
        private ComboBox CbUsers;
    }
}