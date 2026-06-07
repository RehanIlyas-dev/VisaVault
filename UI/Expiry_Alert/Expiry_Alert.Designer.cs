namespace visavault_g43
{
    partial class Expiry_Alert
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
            this.panelCritical = new System.Windows.Forms.Panel();
            this.panelWarning = new System.Windows.Forms.Panel();
            this.panelSafe = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dgvAlerts = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelExpired = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.colClient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDocType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExpiryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCountry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActionDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDaysToAct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAlertLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlerts)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCritical
            // 
            this.panelCritical.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.panelCritical.Location = new System.Drawing.Point(17, 12);
            this.panelCritical.Name = "panelCritical";
            this.panelCritical.Size = new System.Drawing.Size(200, 100);
            this.panelCritical.TabIndex = 1;
            // 
            // panelWarning
            // 
            this.panelWarning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.panelWarning.Location = new System.Drawing.Point(18, 17);
            this.panelWarning.Name = "panelWarning";
            this.panelWarning.Size = new System.Drawing.Size(200, 100);
            this.panelWarning.TabIndex = 2;
            // 
            // panelSafe
            // 
            this.panelSafe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.panelSafe.Location = new System.Drawing.Point(16, 17);
            this.panelSafe.Name = "panelSafe";
            this.panelSafe.Size = new System.Drawing.Size(200, 100);
            this.panelSafe.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Book Antiqua", 12.2F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(68)))), ((int)(((byte)(115)))));
            this.label2.Location = new System.Drawing.Point(25, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = "Critical (0-14 days)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Book Antiqua", 12.2F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(68)))), ((int)(((byte)(115)))));
            this.label3.Location = new System.Drawing.Point(10, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(217, 26);
            this.label3.TabIndex = 5;
            this.label3.Text = "Warning (15-45 days)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Book Antiqua", 12.2F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(68)))), ((int)(((byte)(115)))));
            this.label4.Location = new System.Drawing.Point(36, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 26);
            this.label4.TabIndex = 6;
            this.label4.Text = "Safe (45+ days)";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.pictureBox2);
            this.panel5.Controls.Add(this.label11);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1342, 63);
            this.panel5.TabIndex = 36;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::visavault_g43.Properties.Resources.time;
            this.pictureBox2.Location = new System.Drawing.Point(26, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 58;
            this.pictureBox2.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Book Antiqua", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(68)))), ((int)(((byte)(115)))));
            this.label11.Location = new System.Drawing.Point(66, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(170, 32);
            this.label11.TabIndex = 56;
            this.label11.Text = "Expiry Alert";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Controls.Add(this.dgvAlerts);
            this.panel6.Location = new System.Drawing.Point(52, 371);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1237, 279);
            this.panel6.TabIndex = 37;
            // 
            // dgvAlerts
            // 
            this.dgvAlerts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlerts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colClient,
            this.colDocType,
            this.colExpiryDate,
            this.colCountry,
            this.colActionDays,
            this.colDaysToAct,
            this.colAlertLevel});
            this.dgvAlerts.Location = new System.Drawing.Point(55, 56);
            this.dgvAlerts.Name = "dgvAlerts";
            this.dgvAlerts.RowHeadersWidth = 51;
            this.dgvAlerts.RowTemplate.Height = 24;
            this.dgvAlerts.Size = new System.Drawing.Size(1139, 164);
            this.dgvAlerts.TabIndex = 9;
            System.Windows.Forms.DataGridViewCellStyle dgvAlertsHeaderStyle = new System.Windows.Forms.DataGridViewCellStyle();
            dgvAlertsHeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(68)))), ((int)(((byte)(115)))));
            dgvAlertsHeaderStyle.ForeColor = System.Drawing.Color.White;
            dgvAlertsHeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            
            System.Windows.Forms.DataGridViewCellStyle dgvAlertsRowStyle = new System.Windows.Forms.DataGridViewCellStyle();
            dgvAlertsRowStyle.BackColor = System.Drawing.Color.White;
            dgvAlertsRowStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dgvAlertsRowStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dgvAlertsRowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            dgvAlertsRowStyle.SelectionForeColor = System.Drawing.Color.Black;

            this.dgvAlerts.BackgroundColor = System.Drawing.Color.White;
            this.dgvAlerts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAlerts.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAlerts.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvAlerts.EnableHeadersVisualStyles = false;
            this.dgvAlerts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvAlerts.ColumnHeadersDefaultCellStyle = dgvAlertsHeaderStyle;
            this.dgvAlerts.ColumnHeadersHeight = 40;
            this.dgvAlerts.DefaultCellStyle = dgvAlertsRowStyle;
            this.dgvAlerts.RowHeadersVisible = false;
            this.dgvAlerts.RowTemplate.Height = 35;
            this.dgvAlerts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAlerts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAlerts.AllowUserToAddRows = false;
            this.dgvAlerts.AllowUserToDeleteRows = false;
            this.dgvAlerts.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panelCritical);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(126, 106);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(235, 174);
            this.panel1.TabIndex = 38;
            // 
            // panelExpired
            // 
            this.panelExpired.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.panelExpired.Location = new System.Drawing.Point(15, 12);
            this.panelExpired.Name = "panelExpired";
            this.panelExpired.Size = new System.Drawing.Size(200, 100);
            this.panelExpired.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Book Antiqua", 12.2F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(68)))), ((int)(((byte)(115)))));
            this.label1.Location = new System.Drawing.Point(72, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 26);
            this.label1.TabIndex = 5;
            this.label1.Text = "Expired";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.Controls.Add(this.panelSafe);
            this.panel8.Controls.Add(this.label4);
            this.panel8.Location = new System.Drawing.Point(992, 106);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(235, 174);
            this.panel8.TabIndex = 39;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Controls.Add(this.panelWarning);
            this.panel9.Controls.Add(this.label3);
            this.panel9.Location = new System.Drawing.Point(706, 106);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(235, 174);
            this.panel9.TabIndex = 39;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.White;
            this.panel10.Controls.Add(this.panelExpired);
            this.panel10.Controls.Add(this.label1);
            this.panel10.Location = new System.Drawing.Point(420, 106);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(235, 174);
            this.panel10.TabIndex = 39;
            // 
            // colClient
            // 
            this.colClient.HeaderText = "Cient";
            this.colClient.MinimumWidth = 6;
            this.colClient.Name = "colClient";
            this.colClient.Width = 125;
            // 
            // colDocType
            // 
            this.colDocType.HeaderText = "Document Type";
            this.colDocType.MinimumWidth = 6;
            this.colDocType.Name = "colDocType";
            this.colDocType.Width = 135;
            // 
            // colExpiryDate
            // 
            this.colExpiryDate.HeaderText = "Expiry Date";
            this.colExpiryDate.MinimumWidth = 6;
            this.colExpiryDate.Name = "colExpiryDate";
            this.colExpiryDate.Width = 125;
            // 
            // colCountry
            // 
            this.colCountry.HeaderText = "Country";
            this.colCountry.MinimumWidth = 6;
            this.colCountry.Name = "colCountry";
            this.colCountry.Width = 125;
            // 
            // colActionDays
            // 
            this.colActionDays.HeaderText = "Actions Days";
            this.colActionDays.MinimumWidth = 6;
            this.colActionDays.Name = "colActionDays";
            this.colActionDays.Width = 125;
            // 
            // colDaysToAct
            // 
            this.colDaysToAct.HeaderText = "Days to Act";
            this.colDaysToAct.MinimumWidth = 6;
            this.colDaysToAct.Name = "colDaysToAct";
            this.colDaysToAct.Width = 125;
            // 
            // colAlertLevel
            // 
            this.colAlertLevel.HeaderText = "Alert Level";
            this.colAlertLevel.MinimumWidth = 6;
            this.colAlertLevel.Name = "colAlertLevel";
            this.colAlertLevel.Width = 125;
            // 
            // Expiry_Alert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1342, 820);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Expiry_Alert";
            this.Text = "Expiry_Alert";
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlerts)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelCritical;
        private System.Windows.Forms.Panel panelWarning;
        private System.Windows.Forms.Panel panelSafe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.DataGridView dgvAlerts;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelExpired;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClient;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExpiryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCountry;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActionDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDaysToAct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAlertLevel;
    }
}