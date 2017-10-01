namespace Client
{
    partial class Home
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.listBoxConnectedUsers = new System.Windows.Forms.ListBox();
            this.btnConnectedUsers = new System.Windows.Forms.Button();
            this.buttonMyFriends = new System.Windows.Forms.Button();
            this.listBoxMyFriends = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonMyFriends);
            this.panel1.Controls.Add(this.listBoxMyFriends);
            this.panel1.Controls.Add(this.btnConnectedUsers);
            this.panel1.Controls.Add(this.listBoxConnectedUsers);
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1087, 606);
            this.panel1.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(986, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // listBoxConnectedUsers
            // 
            this.listBoxConnectedUsers.FormattingEnabled = true;
            this.listBoxConnectedUsers.Location = new System.Drawing.Point(37, 22);
            this.listBoxConnectedUsers.Name = "listBoxConnectedUsers";
            this.listBoxConnectedUsers.Size = new System.Drawing.Size(204, 381);
            this.listBoxConnectedUsers.TabIndex = 1;
            // 
            // btnConnectedUsers
            // 
            this.btnConnectedUsers.Font = new System.Drawing.Font("Arial", 14.25F);
            this.btnConnectedUsers.Location = new System.Drawing.Point(37, 411);
            this.btnConnectedUsers.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnConnectedUsers.Name = "btnConnectedUsers";
            this.btnConnectedUsers.Size = new System.Drawing.Size(204, 39);
            this.btnConnectedUsers.TabIndex = 2;
            this.btnConnectedUsers.Text = "Get Connected Users";
            this.btnConnectedUsers.UseVisualStyleBackColor = true;
            this.btnConnectedUsers.Click += new System.EventHandler(this.btnConnectedUsers_Click);
            // 
            // buttonMyFriends
            // 
            this.buttonMyFriends.Font = new System.Drawing.Font("Arial", 14.25F);
            this.buttonMyFriends.Location = new System.Drawing.Point(338, 411);
            this.buttonMyFriends.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.buttonMyFriends.Name = "buttonMyFriends";
            this.buttonMyFriends.Size = new System.Drawing.Size(204, 39);
            this.buttonMyFriends.TabIndex = 4;
            this.buttonMyFriends.Text = "My Friends";
            this.buttonMyFriends.UseVisualStyleBackColor = true;
            this.buttonMyFriends.Click += new System.EventHandler(this.buttonMyFriends_Click);
            // 
            // listBoxMyFriends
            // 
            this.listBoxMyFriends.FormattingEnabled = true;
            this.listBoxMyFriends.Location = new System.Drawing.Point(338, 22);
            this.listBoxMyFriends.Name = "listBoxMyFriends";
            this.listBoxMyFriends.Size = new System.Drawing.Size(204, 381);
            this.listBoxMyFriends.TabIndex = 3;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 606);
            this.Controls.Add(this.panel1);
            this.Name = "Home";
            this.Text = "Home";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.ListBox listBoxConnectedUsers;
        private System.Windows.Forms.Button btnConnectedUsers;
        private System.Windows.Forms.Button buttonMyFriends;
        private System.Windows.Forms.ListBox listBoxMyFriends;
    }
}