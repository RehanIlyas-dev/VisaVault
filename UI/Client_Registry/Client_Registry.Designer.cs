namespace visavault_g43
{
    partial class Client_Registry
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvClients = new System.Windows.Forms.DataGridView();
            this.cmbStatusFilter = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnViewEdit = new System.Windows.Forms.Button();
            this.btnChangeStatus = new System.Windows.Forms.Button();
            this.btnViewDocuments = new System.Windows.Forms.Button();
            this.btnOpenRenewalCase = new System.Windows.Forms.Button();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCNIC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDocs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1432, 63);
            this.panel3.TabIndex = 26;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::visavault_g43.Properties.Resources.user_avatar;
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
            this.label11.Size = new System.Drawing.Size(206, 32);
            this.label11.TabIndex = 56;
            this.label11.Text = "Client Registry";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.dgvClients);
            this.panel1.Controls.Add(this.cmbStatusFilter);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Location = new System.Drawing.Point(57, 145);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1194, 408);
            this.panel1.TabIndex = 27;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(68)))), ((int)(((byte)(115)))));
            this.btnClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(911, 48);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(120, 40);
            this.btnClear.TabIndex = 59;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(68)))), ((int)(((byte)(115)))));
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(768, 48);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 40);
            this.btnSearch.TabIndex = 58;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // dgvClients
            // 
            this.dgvClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colName,
            this.colCNIC,
            this.colPhone,
            this.colStatus,
            this.colDocs,
            this.colCreated});
            this.dgvClients.Location = new System.Drawing.Point(54, 128);
            this.dgvClients.Name = "dgvClients";
            this.dgvClients.RowHeadersWidth = 51;
            this.dgvClients.RowTemplate.Height = 24;
            this.dgvClients.Size = new System.Drawing.Size(1093, 168);
            this.dgvClients.TabIndex = 13;
            System.Windows.Forms.DataGridViewCellStyle dgvClientsHeaderStyle = new System.Windows.Forms.DataGridViewCellStyle();
            dgvClientsHeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(68)))), ((int)(((byte)(115)))));
            dgvClientsHeaderStyle.ForeColor = System.Drawing.Color.White;
            dgvClientsHeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            
            System.Windows.Forms.DataGridViewCellStyle dgvClientsRowStyle = new System.Windows.Forms.DataGridViewCellStyle();
            dgvClientsRowStyle.BackColor = System.Drawing.Color.White;
            dgvClientsRowStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dgvClientsRowStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dgvClientsRowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            dgvClientsRowStyle.SelectionForeColor = System.Drawing.Color.Black;

            this.dgvClients.BackgroundColor = System.Drawing.Color.White;
            this.dgvClients.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvClients.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvClients.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvClients.EnableHeadersVisualStyles = false;
            this.dgvClients.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvClients.ColumnHeadersDefaultCellStyle = dgvClientsHeaderStyle;
            this.dgvClients.ColumnHeadersHeight = 40;
            this.dgvClients.DefaultCellStyle = dgvClientsRowStyle;
            this.dgvClients.RowHeadersVisible = false;
            this.dgvClients.RowTemplate.Height = 35;
            this.dgvClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClients.AllowUserToAddRows = false;
            this.dgvClients.AllowUserToDeleteRows = false;
            this.dgvClients.ReadOnly = true;
            // 
            // cmbStatusFilter
            // 
            this.cmbStatusFilter.BackColor = System.Drawing.Color.White;
            this.cmbStatusFilter.Font = new System.Drawing.Font("Book Antiqua", 12.2F, System.Drawing.FontStyle.Bold);
            this.cmbStatusFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.cmbStatusFilter.FormattingEnabled = true;
            this.cmbStatusFilter.Location = new System.Drawing.Point(555, 52);
            this.cmbStatusFilter.Name = "cmbStatusFilter";
            this.cmbStatusFilter.Size = new System.Drawing.Size(135, 32);
            this.cmbStatusFilter.TabIndex = 57;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.Font = new System.Drawing.Font("Book Antiqua", 10.2F, System.Drawing.FontStyle.Bold);
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.txtSearch.Location = new System.Drawing.Point(223, 54);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(275, 28);
            this.txtSearch.TabIndex = 56;
            // 
            // btnViewEdit
            // 
            this.btnViewEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(68)))), ((int)(((byte)(115)))));
            this.btnViewEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnViewEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnViewEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewEdit.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnViewEdit.ForeColor = System.Drawing.Color.White;
            this.btnViewEdit.Location = new System.Drawing.Point(238, 606);
            this.btnViewEdit.Name = "btnViewEdit";
            this.btnViewEdit.Size = new System.Drawing.Size(192, 40);
            this.btnViewEdit.TabIndex = 60;
            this.btnViewEdit.Text = "View / Edit";
            this.btnViewEdit.UseVisualStyleBackColor = false;
            // 
            // btnChangeStatus
            // 
            this.btnChangeStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(68)))), ((int)(((byte)(115)))));
            this.btnChangeStatus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnChangeStatus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnChangeStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeStatus.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnChangeStatus.ForeColor = System.Drawing.Color.White;
            this.btnChangeStatus.Location = new System.Drawing.Point(968, 606);
            this.btnChangeStatus.Name = "btnChangeStatus";
            this.btnChangeStatus.Size = new System.Drawing.Size(184, 40);
            this.btnChangeStatus.TabIndex = 61;
            this.btnChangeStatus.Text = "Change Status ";
            this.btnChangeStatus.UseVisualStyleBackColor = false;
            // 
            // btnViewDocuments
            // 
            this.btnViewDocuments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(68)))), ((int)(((byte)(115)))));
            this.btnViewDocuments.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnViewDocuments.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnViewDocuments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewDocuments.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnViewDocuments.ForeColor = System.Drawing.Color.White;
            this.btnViewDocuments.Location = new System.Drawing.Point(479, 606);
            this.btnViewDocuments.Name = "btnViewDocuments";
            this.btnViewDocuments.Size = new System.Drawing.Size(186, 40);
            this.btnViewDocuments.TabIndex = 63;
            this.btnViewDocuments.Text = "View Documents";
            this.btnViewDocuments.UseVisualStyleBackColor = false;
            // 
            // btnOpenRenewalCase
            // 
            this.btnOpenRenewalCase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(68)))), ((int)(((byte)(115)))));
            this.btnOpenRenewalCase.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnOpenRenewalCase.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnOpenRenewalCase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenRenewalCase.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnOpenRenewalCase.ForeColor = System.Drawing.Color.White;
            this.btnOpenRenewalCase.Location = new System.Drawing.Point(711, 606);
            this.btnOpenRenewalCase.Name = "btnOpenRenewalCase";
            this.btnOpenRenewalCase.Size = new System.Drawing.Size(215, 40);
            this.btnOpenRenewalCase.TabIndex = 64;
            this.btnOpenRenewalCase.Text = "Open Reneweal Case";
            this.btnOpenRenewalCase.UseVisualStyleBackColor = false;
            // 
            // colID
            // 
            this.colID.HeaderText = "ID";
            this.colID.MinimumWidth = 6;
            this.colID.Name = "colID";
            this.colID.Width = 50;
            // 
            // colName
            // 
            this.colName.HeaderText = "Name";
            this.colName.MinimumWidth = 6;
            this.colName.Name = "colName";
            this.colName.Width = 125;
            // 
            // colCNIC
            // 
            this.colCNIC.HeaderText = "CNIC";
            this.colCNIC.MinimumWidth = 6;
            this.colCNIC.Name = "colCNIC";
            this.colCNIC.Width = 125;
            // 
            // colPhone
            // 
            this.colPhone.HeaderText = "Phone";
            this.colPhone.MinimumWidth = 6;
            this.colPhone.Name = "colPhone";
            this.colPhone.Width = 125;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.MinimumWidth = 6;
            this.colStatus.Name = "colStatus";
            this.colStatus.Width = 125;
            // 
            // colDocs
            // 
            this.colDocs.HeaderText = "Documents";
            this.colDocs.MinimumWidth = 6;
            this.colDocs.Name = "colDocs";
            this.colDocs.Width = 125;
            // 
            // colCreated
            // 
            this.colCreated.HeaderText = "Created";
            this.colCreated.MinimumWidth = 6;
            this.colCreated.Name = "colCreated";
            this.colCreated.Width = 125;
            // 
            // Client_Registry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1432, 1055);
            this.Controls.Add(this.btnOpenRenewalCase);
            this.Controls.Add(this.btnViewDocuments);
            this.Controls.Add(this.btnChangeStatus);
            this.Controls.Add(this.btnViewEdit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Client_Registry";
            this.Text = "Clinet";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvClients;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbStatusFilter;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnViewEdit;
        private System.Windows.Forms.Button btnChangeStatus;
        private System.Windows.Forms.Button btnViewDocuments;
        private System.Windows.Forms.Button btnOpenRenewalCase;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCNIC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocs;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreated;
    }
}