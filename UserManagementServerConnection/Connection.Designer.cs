namespace UserManagementServerConnection
{
    partial class Connection
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
            this.nudServerPort = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.txtServerIp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudServerPort)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.nudServerPort);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblError);
            this.panel1.Controls.Add(this.txtServerIp);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnConnect);
            this.panel1.Location = new System.Drawing.Point(176, 66);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(454, 417);
            this.panel1.TabIndex = 0;
            // 
            // nudServerPort
            // 
            this.nudServerPort.Location = new System.Drawing.Point(189, 197);
            this.nudServerPort.Maximum = new decimal(new int[] {
            68000,
            0,
            0,
            0});
            this.nudServerPort.Name = "nudServerPort";
            this.nudServerPort.Size = new System.Drawing.Size(180, 29);
            this.nudServerPort.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(158, 57);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 27);
            this.label4.TabIndex = 8;
            this.label4.Text = "Connection";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(140, 360);
            this.lblError.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 22);
            this.lblError.TabIndex = 5;
            // 
            // txtServerIp
            // 
            this.txtServerIp.Location = new System.Drawing.Point(189, 128);
            this.txtServerIp.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtServerIp.Name = "txtServerIp";
            this.txtServerIp.Size = new System.Drawing.Size(180, 29);
            this.txtServerIp.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 199);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Server Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 131);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server IP";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(163, 287);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(138, 39);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // Connection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 576);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "Connection";
            this.Text = "Connect";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudServerPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtServerIp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudServerPort;
    }
}

