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
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.tabControlChat = new System.Windows.Forms.TabControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabUsers = new System.Windows.Forms.TabPage();
            this.listBoxConnectedUsers = new System.Windows.Forms.ListBox();
            this.btnConnectedUsers = new System.Windows.Forms.Button();
            this.buttonAddFriend = new System.Windows.Forms.Button();
            this.tabFriends = new System.Windows.Forms.TabPage();
            this.btnChat = new System.Windows.Forms.Button();
            this.listBoxMyFriends = new System.Windows.Forms.ListBox();
            this.buttonMyFriends = new System.Windows.Forms.Button();
            this.tabPendingFriendships = new System.Windows.Forms.TabPage();
            this.listBoxFriendshipRequests = new System.Windows.Forms.ListBox();
            this.buttonFriendshipRequests = new System.Windows.Forms.Button();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.labelMessage = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabUsers.SuspendLayout();
            this.tabFriends.SuspendLayout();
            this.tabPendingFriendships.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtMessage);
            this.panel1.Controls.Add(this.tabControlChat);
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.Add(this.labelMessage);
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1011, 606);
            this.panel1.TabIndex = 0;
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(272, 532);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(596, 20);
            this.txtMessage.TabIndex = 12;
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyDown);
            // 
            // tabControlChat
            // 
            this.tabControlChat.Location = new System.Drawing.Point(272, 22);
            this.tabControlChat.Name = "tabControlChat";
            this.tabControlChat.SelectedIndex = 0;
            this.tabControlChat.Size = new System.Drawing.Size(596, 504);
            this.tabControlChat.TabIndex = 11;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabUsers);
            this.tabControl1.Controls.Add(this.tabFriends);
            this.tabControl1.Controls.Add(this.tabPendingFriendships);
            this.tabControl1.Location = new System.Drawing.Point(12, 22);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(243, 534);
            this.tabControl1.TabIndex = 10;
            // 
            // tabUsers
            // 
            this.tabUsers.Controls.Add(this.listBoxConnectedUsers);
            this.tabUsers.Controls.Add(this.btnConnectedUsers);
            this.tabUsers.Controls.Add(this.buttonAddFriend);
            this.tabUsers.Location = new System.Drawing.Point(4, 22);
            this.tabUsers.Name = "tabUsers";
            this.tabUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tabUsers.Size = new System.Drawing.Size(235, 508);
            this.tabUsers.TabIndex = 0;
            this.tabUsers.Text = "Connected Users";
            this.tabUsers.UseVisualStyleBackColor = true;
            // 
            // listBoxConnectedUsers
            // 
            this.listBoxConnectedUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxConnectedUsers.FormattingEnabled = true;
            this.listBoxConnectedUsers.ItemHeight = 16;
            this.listBoxConnectedUsers.Location = new System.Drawing.Point(15, 15);
            this.listBoxConnectedUsers.Name = "listBoxConnectedUsers";
            this.listBoxConnectedUsers.Size = new System.Drawing.Size(204, 372);
            this.listBoxConnectedUsers.TabIndex = 1;
            this.listBoxConnectedUsers.SelectedValueChanged += new System.EventHandler(this.listBoxConnectedUsers_SelectedValueChanged);
            // 
            // btnConnectedUsers
            // 
            this.btnConnectedUsers.Font = new System.Drawing.Font("Arial", 14.25F);
            this.btnConnectedUsers.Location = new System.Drawing.Point(15, 453);
            this.btnConnectedUsers.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnConnectedUsers.Name = "btnConnectedUsers";
            this.btnConnectedUsers.Size = new System.Drawing.Size(204, 39);
            this.btnConnectedUsers.TabIndex = 2;
            this.btnConnectedUsers.Text = "Get Connected Users";
            this.btnConnectedUsers.UseVisualStyleBackColor = true;
            this.btnConnectedUsers.Click += new System.EventHandler(this.btnConnectedUsers_Click);
            // 
            // buttonAddFriend
            // 
            this.buttonAddFriend.Font = new System.Drawing.Font("Arial", 14.25F);
            this.buttonAddFriend.Location = new System.Drawing.Point(15, 404);
            this.buttonAddFriend.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.buttonAddFriend.Name = "buttonAddFriend";
            this.buttonAddFriend.Size = new System.Drawing.Size(204, 39);
            this.buttonAddFriend.TabIndex = 5;
            this.buttonAddFriend.Text = "Add Friend";
            this.buttonAddFriend.UseVisualStyleBackColor = true;
            this.buttonAddFriend.Click += new System.EventHandler(this.buttonAddFriend_Click);
            // 
            // tabFriends
            // 
            this.tabFriends.Controls.Add(this.btnChat);
            this.tabFriends.Controls.Add(this.listBoxMyFriends);
            this.tabFriends.Controls.Add(this.buttonMyFriends);
            this.tabFriends.Location = new System.Drawing.Point(4, 22);
            this.tabFriends.Name = "tabFriends";
            this.tabFriends.Padding = new System.Windows.Forms.Padding(3);
            this.tabFriends.Size = new System.Drawing.Size(235, 508);
            this.tabFriends.TabIndex = 1;
            this.tabFriends.Text = "Friends";
            this.tabFriends.UseVisualStyleBackColor = true;
            // 
            // btnChat
            // 
            this.btnChat.Font = new System.Drawing.Font("Arial", 14.25F);
            this.btnChat.Location = new System.Drawing.Point(16, 453);
            this.btnChat.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnChat.Name = "btnChat";
            this.btnChat.Size = new System.Drawing.Size(204, 39);
            this.btnChat.TabIndex = 5;
            this.btnChat.Text = "Chat";
            this.btnChat.UseVisualStyleBackColor = true;
            this.btnChat.Click += new System.EventHandler(this.btnChat_Click);
            // 
            // listBoxMyFriends
            // 
            this.listBoxMyFriends.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxMyFriends.FormattingEnabled = true;
            this.listBoxMyFriends.ItemHeight = 16;
            this.listBoxMyFriends.Location = new System.Drawing.Point(16, 15);
            this.listBoxMyFriends.Name = "listBoxMyFriends";
            this.listBoxMyFriends.Size = new System.Drawing.Size(204, 372);
            this.listBoxMyFriends.TabIndex = 3;
            // 
            // buttonMyFriends
            // 
            this.buttonMyFriends.Font = new System.Drawing.Font("Arial", 14.25F);
            this.buttonMyFriends.Location = new System.Drawing.Point(16, 404);
            this.buttonMyFriends.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.buttonMyFriends.Name = "buttonMyFriends";
            this.buttonMyFriends.Size = new System.Drawing.Size(204, 39);
            this.buttonMyFriends.TabIndex = 4;
            this.buttonMyFriends.Text = "My Friends";
            this.buttonMyFriends.UseVisualStyleBackColor = true;
            this.buttonMyFriends.Click += new System.EventHandler(this.buttonMyFriends_Click);
            // 
            // tabPendingFriendships
            // 
            this.tabPendingFriendships.Controls.Add(this.listBoxFriendshipRequests);
            this.tabPendingFriendships.Controls.Add(this.buttonFriendshipRequests);
            this.tabPendingFriendships.Controls.Add(this.buttonAccept);
            this.tabPendingFriendships.Location = new System.Drawing.Point(4, 22);
            this.tabPendingFriendships.Name = "tabPendingFriendships";
            this.tabPendingFriendships.Padding = new System.Windows.Forms.Padding(3);
            this.tabPendingFriendships.Size = new System.Drawing.Size(235, 508);
            this.tabPendingFriendships.TabIndex = 2;
            this.tabPendingFriendships.Text = "Pending Request";
            this.tabPendingFriendships.UseVisualStyleBackColor = true;
            // 
            // listBoxFriendshipRequests
            // 
            this.listBoxFriendshipRequests.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxFriendshipRequests.FormattingEnabled = true;
            this.listBoxFriendshipRequests.ItemHeight = 16;
            this.listBoxFriendshipRequests.Location = new System.Drawing.Point(16, 17);
            this.listBoxFriendshipRequests.Name = "listBoxFriendshipRequests";
            this.listBoxFriendshipRequests.Size = new System.Drawing.Size(204, 372);
            this.listBoxFriendshipRequests.TabIndex = 6;
            this.listBoxFriendshipRequests.SelectedValueChanged += new System.EventHandler(this.listBoxFriendshipRequests_SelectedValueChanged);
            // 
            // buttonFriendshipRequests
            // 
            this.buttonFriendshipRequests.Font = new System.Drawing.Font("Arial", 14.25F);
            this.buttonFriendshipRequests.Location = new System.Drawing.Point(16, 406);
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
            this.buttonAccept.Location = new System.Drawing.Point(16, 455);
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
            this.labelMessage.Location = new System.Drawing.Point(29, 579);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(0, 18);
            this.labelMessage.TabIndex = 9;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(915, 22);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 606);
            this.Controls.Add(this.panel1);
            this.Name = "Home";
            this.Text = "Home";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Home_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabUsers.ResumeLayout(false);
            this.tabFriends.ResumeLayout(false);
            this.tabPendingFriendships.ResumeLayout(false);
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabUsers;
        private System.Windows.Forms.TabPage tabFriends;
        private System.Windows.Forms.TabPage tabPendingFriendships;
        private System.Windows.Forms.TabControl tabControlChat;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnChat;
    }
}