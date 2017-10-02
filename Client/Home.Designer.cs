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
            this.buttonMyFriends = new System.Windows.Forms.Button();
            this.listBoxMyFriends = new System.Windows.Forms.ListBox();
            this.btnConnectedUsers = new System.Windows.Forms.Button();
            this.listBoxConnectedUsers = new System.Windows.Forms.ListBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.buttonAddFriend = new System.Windows.Forms.Button();
            this.listBoxFriendshipRequests = new System.Windows.Forms.ListBox();
            this.buttonFriendshipRequests = new System.Windows.Forms.Button();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.labelMessage = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelMessage);
            this.panel1.Controls.Add(this.buttonAccept);
            this.panel1.Controls.Add(this.buttonFriendshipRequests);
            this.panel1.Controls.Add(this.listBoxFriendshipRequests);
            this.panel1.Controls.Add(this.buttonAddFriend);
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
            this.listBoxMyFriends.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxMyFriends.FormattingEnabled = true;
            this.listBoxMyFriends.ItemHeight = 16;
            this.listBoxMyFriends.Location = new System.Drawing.Point(338, 22);
            this.listBoxMyFriends.Name = "listBoxMyFriends";
            this.listBoxMyFriends.Size = new System.Drawing.Size(204, 372);
            this.listBoxMyFriends.TabIndex = 3;
            // 
            // btnConnectedUsers
            // 
            this.btnConnectedUsers.Font = new System.Drawing.Font("Arial", 14.25F);
            this.btnConnectedUsers.Location = new System.Drawing.Point(37, 460);
            this.btnConnectedUsers.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnConnectedUsers.Name = "btnConnectedUsers";
            this.btnConnectedUsers.Size = new System.Drawing.Size(204, 39);
            this.btnConnectedUsers.TabIndex = 2;
            this.btnConnectedUsers.Text = "Get Connected Users";
            this.btnConnectedUsers.UseVisualStyleBackColor = true;
            this.btnConnectedUsers.Click += new System.EventHandler(this.btnConnectedUsers_Click);
            // 
            // listBoxConnectedUsers
            // 
            this.listBoxConnectedUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxConnectedUsers.FormattingEnabled = true;
            this.listBoxConnectedUsers.ItemHeight = 16;
            this.listBoxConnectedUsers.Location = new System.Drawing.Point(37, 22);
            this.listBoxConnectedUsers.Name = "listBoxConnectedUsers";
            this.listBoxConnectedUsers.Size = new System.Drawing.Size(204, 372);
            this.listBoxConnectedUsers.TabIndex = 1;
            this.listBoxConnectedUsers.SelectedValueChanged += new System.EventHandler(this.listBoxConnectedUsers_SelectedValueChanged);
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
            // buttonAddFriend
            // 
            this.buttonAddFriend.Font = new System.Drawing.Font("Arial", 14.25F);
            this.buttonAddFriend.Location = new System.Drawing.Point(37, 411);
            this.buttonAddFriend.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.buttonAddFriend.Name = "buttonAddFriend";
            this.buttonAddFriend.Size = new System.Drawing.Size(204, 39);
            this.buttonAddFriend.TabIndex = 5;
            this.buttonAddFriend.Text = "Add Friend";
            this.buttonAddFriend.UseVisualStyleBackColor = true;
            this.buttonAddFriend.Click += new System.EventHandler(this.buttonAddFriend_Click);
            // 
            // listBoxFriendshipRequests
            // 
            this.listBoxFriendshipRequests.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxFriendshipRequests.FormattingEnabled = true;
            this.listBoxFriendshipRequests.ItemHeight = 16;
            this.listBoxFriendshipRequests.Location = new System.Drawing.Point(629, 22);
            this.listBoxFriendshipRequests.Name = "listBoxFriendshipRequests";
            this.listBoxFriendshipRequests.Size = new System.Drawing.Size(204, 372);
            this.listBoxFriendshipRequests.TabIndex = 6;
            this.listBoxFriendshipRequests.SelectedValueChanged += new System.EventHandler(this.listBoxFriendshipRequests_SelectedValueChanged);
            // 
            // buttonFriendshipRequests
            // 
            this.buttonFriendshipRequests.Font = new System.Drawing.Font("Arial", 14.25F);
            this.buttonFriendshipRequests.Location = new System.Drawing.Point(629, 411);
            this.buttonFriendshipRequests.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.buttonFriendshipRequests.Name = "buttonFriendshipRequests";
            this.buttonFriendshipRequests.Size = new System.Drawing.Size(204, 39);
            this.buttonFriendshipRequests.TabIndex = 7;
            this.buttonFriendshipRequests.Text = "Friendship Requests";
            this.buttonFriendshipRequests.UseVisualStyleBackColor = true;
            this.buttonFriendshipRequests.Click += new System.EventHandler(this.buttonFriendshipRequests_Click);
            // 
            // buttonAccept
            // 
            this.buttonAccept.Font = new System.Drawing.Font("Arial", 14.25F);
            this.buttonAccept.Location = new System.Drawing.Point(629, 460);
            this.buttonAccept.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(204, 39);
            this.buttonAccept.TabIndex = 8;
            this.buttonAccept.Text = "Accept";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMessage.ForeColor = System.Drawing.Color.Red;
            this.labelMessage.Location = new System.Drawing.Point(423, 561);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(0, 18);
            this.labelMessage.TabIndex = 9;
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
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.ListBox listBoxConnectedUsers;
        private System.Windows.Forms.Button btnConnectedUsers;
        private System.Windows.Forms.Button buttonMyFriends;
        private System.Windows.Forms.ListBox listBoxMyFriends;
        private System.Windows.Forms.Button buttonAddFriend;
        private System.Windows.Forms.Button buttonFriendshipRequests;
        private System.Windows.Forms.ListBox listBoxFriendshipRequests;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Label labelMessage;
    }
}