namespace LogServer
{
    partial class Logs
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
            this.listLogs = new System.Windows.Forms.ListView();
            this.columnEvent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnEventDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clientsPanel = new System.Windows.Forms.Panel();
            this.btnUpdateClients = new System.Windows.Forms.Button();
            this.clientsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // listLogs
            // 
            this.listLogs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnEvent,
            this.columnEventDate});
            this.listLogs.Location = new System.Drawing.Point(39, 41);
            this.listLogs.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.listLogs.Name = "listLogs";
            this.listLogs.Size = new System.Drawing.Size(724, 440);
            this.listLogs.TabIndex = 2;
            this.listLogs.UseCompatibleStateImageBehavior = false;
            this.listLogs.View = System.Windows.Forms.View.Details;
            // 
            // columnEvent
            // 
            this.columnEvent.Text = "Event";
            this.columnEvent.Width = 400;
            // 
            // columnEventDate
            // 
            this.columnEventDate.Text = "Event Date";
            this.columnEventDate.Width = 250;
            // 
            // clientsPanel
            // 
            this.clientsPanel.BackColor = System.Drawing.Color.CornflowerBlue;
            this.clientsPanel.Controls.Add(this.listLogs);
            this.clientsPanel.Controls.Add(this.btnUpdateClients);
            this.clientsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientsPanel.Location = new System.Drawing.Point(0, 0);
            this.clientsPanel.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.clientsPanel.Name = "clientsPanel";
            this.clientsPanel.Size = new System.Drawing.Size(803, 515);
            this.clientsPanel.TabIndex = 2;
            // 
            // btnUpdateClients
            // 
            this.btnUpdateClients.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnUpdateClients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateClients.Location = new System.Drawing.Point(275, 987);
            this.btnUpdateClients.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnUpdateClients.Name = "btnUpdateClients";
            this.btnUpdateClients.Size = new System.Drawing.Size(165, 59);
            this.btnUpdateClients.TabIndex = 0;
            this.btnUpdateClients.Text = "Update";
            this.btnUpdateClients.UseVisualStyleBackColor = false;
            // 
            // Logs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 515);
            this.Controls.Add(this.clientsPanel);
            this.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "Logs";
            this.Text = "Logs";
            this.clientsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listLogs;
        private System.Windows.Forms.ColumnHeader columnEvent;
        private System.Windows.Forms.ColumnHeader columnEventDate;
        private System.Windows.Forms.Panel clientsPanel;
        private System.Windows.Forms.Button btnUpdateClients;
    }
}

