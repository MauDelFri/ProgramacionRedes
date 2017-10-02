namespace Obligarorio1
{
    partial class Home
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.connectedClientsPanel = new System.Windows.Forms.Panel();
            this.listConnectedClients = new System.Windows.Forms.ListView();
            this.columnUsername2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnFriends2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTimesConnected2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSessionElapsed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.btnUpdateConnected = new System.Windows.Forms.Button();
            this.clientsPanel = new System.Windows.Forms.Panel();
            this.listRegisteredClients = new System.Windows.Forms.ListView();
            this.columnUsername = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnFriends = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTimesConnected = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.btnUpdateClients = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.connectedClientsPanel.SuspendLayout();
            this.clientsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.connectedClientsPanel);
            this.panel1.Controls.Add(this.clientsPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 653);
            this.panel1.TabIndex = 0;
            // 
            // connectedClientsPanel
            // 
            this.connectedClientsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connectedClientsPanel.AutoSize = true;
            this.connectedClientsPanel.BackColor = System.Drawing.Color.CornflowerBlue;
            this.connectedClientsPanel.Controls.Add(this.listConnectedClients);
            this.connectedClientsPanel.Controls.Add(this.label2);
            this.connectedClientsPanel.Controls.Add(this.btnUpdateConnected);
            this.connectedClientsPanel.Location = new System.Drawing.Point(424, 12);
            this.connectedClientsPanel.Name = "connectedClientsPanel";
            this.connectedClientsPanel.Size = new System.Drawing.Size(548, 629);
            this.connectedClientsPanel.TabIndex = 2;
            // 
            // listConnectedClients
            // 
            this.listConnectedClients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnUsername2,
            this.columnFriends2,
            this.columnTimesConnected2,
            this.columnSessionElapsed});
            this.listConnectedClients.Location = new System.Drawing.Point(20, 37);
            this.listConnectedClients.Name = "listConnectedClients";
            this.listConnectedClients.Size = new System.Drawing.Size(509, 529);
            this.listConnectedClients.TabIndex = 3;
            this.listConnectedClients.UseCompatibleStateImageBehavior = false;
            this.listConnectedClients.View = System.Windows.Forms.View.Details;
            // 
            // columnUsername2
            // 
            this.columnUsername2.Text = "Username";
            // 
            // columnFriends2
            // 
            this.columnFriends2.Text = "Friends";
            // 
            // columnTimesConnected2
            // 
            this.columnTimesConnected2.Text = "Times Connected";
            // 
            // columnSessionElapsed
            // 
            this.columnSessionElapsed.Text = "Session Elapsed";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Connected Clients";
            // 
            // btnUpdateConnected
            // 
            this.btnUpdateConnected.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnUpdateConnected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateConnected.Location = new System.Drawing.Point(229, 583);
            this.btnUpdateConnected.Name = "btnUpdateConnected";
            this.btnUpdateConnected.Size = new System.Drawing.Size(90, 35);
            this.btnUpdateConnected.TabIndex = 1;
            this.btnUpdateConnected.Text = "Update";
            this.btnUpdateConnected.UseVisualStyleBackColor = false;
            this.btnUpdateConnected.Click += new System.EventHandler(this.btnUpdateConnected_Click);
            // 
            // clientsPanel
            // 
            this.clientsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.clientsPanel.BackColor = System.Drawing.Color.CornflowerBlue;
            this.clientsPanel.Controls.Add(this.listRegisteredClients);
            this.clientsPanel.Controls.Add(this.label1);
            this.clientsPanel.Controls.Add(this.btnUpdateClients);
            this.clientsPanel.Location = new System.Drawing.Point(12, 12);
            this.clientsPanel.Name = "clientsPanel";
            this.clientsPanel.Size = new System.Drawing.Size(392, 629);
            this.clientsPanel.TabIndex = 1;
            // 
            // listRegisteredClients
            // 
            this.listRegisteredClients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnUsername,
            this.columnFriends,
            this.columnTimesConnected});
            this.listRegisteredClients.Location = new System.Drawing.Point(21, 40);
            this.listRegisteredClients.Name = "listRegisteredClients";
            this.listRegisteredClients.Size = new System.Drawing.Size(352, 529);
            this.listRegisteredClients.TabIndex = 2;
            this.listRegisteredClients.UseCompatibleStateImageBehavior = false;
            this.listRegisteredClients.View = System.Windows.Forms.View.Details;
            // 
            // columnUsername
            // 
            this.columnUsername.Text = "Username";
            // 
            // columnFriends
            // 
            this.columnFriends.Text = "Friends";
            // 
            // columnTimesConnected
            // 
            this.columnTimesConnected.Text = "TimesConnected";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Registered Clients";
            // 
            // btnUpdateClients
            // 
            this.btnUpdateClients.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnUpdateClients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateClients.Location = new System.Drawing.Point(150, 583);
            this.btnUpdateClients.Name = "btnUpdateClients";
            this.btnUpdateClients.Size = new System.Drawing.Size(90, 35);
            this.btnUpdateClients.TabIndex = 0;
            this.btnUpdateClients.Text = "Update";
            this.btnUpdateClients.UseVisualStyleBackColor = false;
            this.btnUpdateClients.Click += new System.EventHandler(this.btnUpdateClients_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 653);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MinimumSize = new System.Drawing.Size(1000, 692);
            this.Name = "Home";
            this.Text = "Server";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.connectedClientsPanel.ResumeLayout(false);
            this.connectedClientsPanel.PerformLayout();
            this.clientsPanel.ResumeLayout(false);
            this.clientsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel connectedClientsPanel;
        private System.Windows.Forms.Panel clientsPanel;
        private System.Windows.Forms.Button btnUpdateConnected;
        private System.Windows.Forms.Button btnUpdateClients;
        private System.Windows.Forms.ListView listConnectedClients;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listRegisteredClients;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnUsername2;
        private System.Windows.Forms.ColumnHeader columnFriends2;
        private System.Windows.Forms.ColumnHeader columnTimesConnected2;
        private System.Windows.Forms.ColumnHeader columnSessionElapsed;
        private System.Windows.Forms.ColumnHeader columnUsername;
        private System.Windows.Forms.ColumnHeader columnFriends;
        private System.Windows.Forms.ColumnHeader columnTimesConnected;
    }
}

