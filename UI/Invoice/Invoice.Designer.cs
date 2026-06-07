namespace visavault_g43
{
    partial class Invoice
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
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbStatusFilter = new System.Windows.Forms.ComboBox();
            this.cmbClientFilter = new System.Windows.Forms.ComboBox();
            this.dgvInvoices = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvLineItems = new System.Windows.Forms.DataGridView();
            this.colInvoiceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFeeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItems)).BeginInit();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.pictureBox2);
            this.panel5.Controls.Add(this.label11);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1378, 63);
            this.panel5.TabIndex = 38;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::visavault_g43.Properties.Resources.profit__1_;
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
            this.label11.Size = new System.Drawing.Size(109, 32);
            this.label11.TabIndex = 56;
            this.label11.Text = "Invoice";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.cmbStatusFilter);
            this.panel1.Controls.Add(this.cmbClientFilter);
            this.panel1.Controls.Add(this.dgvInvoices);
            this.panel1.Location = new System.Drawing.Point(93, 133);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1130, 378);
            this.panel1.TabIndex = 39;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(68)))), ((int)(((byte)(115)))));
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(746, 37);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 40);
            this.btnSearch.TabIndex = 59;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // cmbStatusFilter
            // 
            this.cmbStatusFilter.BackColor = System.Drawing.Color.White;
            this.cmbStatusFilter.Font = new System.Drawing.Font("Book Antiqua", 12.2F, System.Drawing.FontStyle.Bold);
            this.cmbStatusFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.cmbStatusFilter.FormattingEnabled = true;
            this.cmbStatusFilter.Location = new System.Drawing.Point(474, 42);
            this.cmbStatusFilter.Name = "cmbStatusFilter";
            this.cmbStatusFilter.Size = new System.Drawing.Size(200, 32);
            this.cmbStatusFilter.TabIndex = 54;
            // 
            // cmbClientFilter
            // 
            this.cmbClientFilter.BackColor = System.Drawing.Color.White;
            this.cmbClientFilter.Font = new System.Drawing.Font("Book Antiqua", 12.2F, System.Drawing.FontStyle.Bold);
            this.cmbClientFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.cmbClientFilter.FormattingEnabled = true;
            this.cmbClientFilter.Location = new System.Drawing.Point(234, 42);
            this.cmbClientFilter.Name = "cmbClientFilter";
            this.cmbClientFilter.Size = new System.Drawing.Size(201, 32);
            this.cmbClientFilter.TabIndex = 53;
            // 
            // dgvInvoices
            // 
            this.dgvInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colInvoiceID,
            this.colClient,
            this.colCase,
            this.colTotal,
            this.colPaid,
            this.colBalance,
            this.colStatus,
            this.colCreated});
            this.dgvInvoices.Location = new System.Drawing.Point(69, 170);
            this.dgvInvoices.Name = "dgvInvoices";
            this.dgvInvoices.RowHeadersWidth = 51;
            this.dgvInvoices.RowTemplate.Height = 24;
            this.dgvInvoices.Size = new System.Drawing.Size(993, 164);
            this.dgvInvoices.TabIndex = 7;
            System.Windows.Forms.DataGridViewCellStyle dgvInvoicesHeaderStyle = new System.Windows.Forms.DataGridViewCellStyle();
            dgvInvoicesHeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(68)))), ((int)(((byte)(115)))));
            dgvInvoicesHeaderStyle.ForeColor = System.Drawing.Color.White;
            dgvInvoicesHeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            
            System.Windows.Forms.DataGridViewCellStyle dgvInvoicesRowStyle = new System.Windows.Forms.DataGridViewCellStyle();
            dgvInvoicesRowStyle.BackColor = System.Drawing.Color.White;
            dgvInvoicesRowStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dgvInvoicesRowStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dgvInvoicesRowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            dgvInvoicesRowStyle.SelectionForeColor = System.Drawing.Color.Black;

            this.dgvInvoices.BackgroundColor = System.Drawing.Color.White;
            this.dgvInvoices.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvInvoices.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvInvoices.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvInvoices.EnableHeadersVisualStyles = false;
            this.dgvInvoices.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvInvoices.ColumnHeadersDefaultCellStyle = dgvInvoicesHeaderStyle;
            this.dgvInvoices.ColumnHeadersHeight = 40;
            this.dgvInvoices.DefaultCellStyle = dgvInvoicesRowStyle;
            this.dgvInvoices.RowHeadersVisible = false;
            this.dgvInvoices.RowTemplate.Height = 35;
            this.dgvInvoices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInvoices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInvoices.AllowUserToAddRows = false;
            this.dgvInvoices.AllowUserToDeleteRows = false;
            this.dgvInvoices.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dgvLineItems);
            this.panel2.Location = new System.Drawing.Point(93, 558);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1130, 286);
            this.panel2.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Book Antiqua", 16.2F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(68)))), ((int)(((byte)(115)))));
            this.label1.Location = new System.Drawing.Point(63, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(356, 32);
            this.label1.TabIndex = 7;
            this.label1.Text = "Invoice Line Item Objects :";
            // 
            // dgvLineItems
            // 
            this.dgvLineItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLineItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLine,
            this.colDescription,
            this.colFeeType,
            this.colAmount});
            this.dgvLineItems.Location = new System.Drawing.Point(63, 87);
            this.dgvLineItems.Name = "dgvLineItems";
            this.dgvLineItems.RowHeadersWidth = 51;
            this.dgvLineItems.RowTemplate.Height = 24;
            this.dgvLineItems.Size = new System.Drawing.Size(993, 164);
            this.dgvLineItems.TabIndex = 6;
            System.Windows.Forms.DataGridViewCellStyle dgvLineItemsHeaderStyle = new System.Windows.Forms.DataGridViewCellStyle();
            dgvLineItemsHeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(68)))), ((int)(((byte)(115)))));
            dgvLineItemsHeaderStyle.ForeColor = System.Drawing.Color.White;
            dgvLineItemsHeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            
            System.Windows.Forms.DataGridViewCellStyle dgvLineItemsRowStyle = new System.Windows.Forms.DataGridViewCellStyle();
            dgvLineItemsRowStyle.BackColor = System.Drawing.Color.White;
            dgvLineItemsRowStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dgvLineItemsRowStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dgvLineItemsRowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            dgvLineItemsRowStyle.SelectionForeColor = System.Drawing.Color.Black;

            this.dgvLineItems.BackgroundColor = System.Drawing.Color.White;
            this.dgvLineItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLineItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvLineItems.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvLineItems.EnableHeadersVisualStyles = false;
            this.dgvLineItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvLineItems.ColumnHeadersDefaultCellStyle = dgvLineItemsHeaderStyle;
            this.dgvLineItems.ColumnHeadersHeight = 40;
            this.dgvLineItems.DefaultCellStyle = dgvLineItemsRowStyle;
            this.dgvLineItems.RowHeadersVisible = false;
            this.dgvLineItems.RowTemplate.Height = 35;
            this.dgvLineItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLineItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLineItems.AllowUserToAddRows = false;
            this.dgvLineItems.AllowUserToDeleteRows = false;
            this.dgvLineItems.ReadOnly = true;
            // 
            // colInvoiceID
            // 
            this.colInvoiceID.HeaderText = "Invoice ID ";
            this.colInvoiceID.MinimumWidth = 6;
            this.colInvoiceID.Name = "colInvoiceID";
            this.colInvoiceID.Width = 125;
            // 
            // colClient
            // 
            this.colClient.HeaderText = "Client";
            this.colClient.MinimumWidth = 6;
            this.colClient.Name = "colClient";
            this.colClient.Width = 125;
            // 
            // colCase
            // 
            this.colCase.HeaderText = "Case";
            this.colCase.MinimumWidth = 6;
            this.colCase.Name = "colCase";
            this.colCase.Width = 125;
            // 
            // colTotal
            // 
            this.colTotal.HeaderText = "Total";
            this.colTotal.MinimumWidth = 6;
            this.colTotal.Name = "colTotal";
            this.colTotal.Width = 125;
            // 
            // colPaid
            // 
            this.colPaid.HeaderText = "Paid";
            this.colPaid.MinimumWidth = 6;
            this.colPaid.Name = "colPaid";
            this.colPaid.Width = 125;
            // 
            // colBalance
            // 
            this.colBalance.HeaderText = "Balance";
            this.colBalance.MinimumWidth = 6;
            this.colBalance.Name = "colBalance";
            this.colBalance.Width = 125;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.MinimumWidth = 6;
            this.colStatus.Name = "colStatus";
            this.colStatus.Width = 125;
            // 
            // colCreated
            // 
            this.colCreated.HeaderText = "Created";
            this.colCreated.MinimumWidth = 6;
            this.colCreated.Name = "colCreated";
            this.colCreated.Width = 125;
            // 
            // colLine
            // 
            this.colLine.HeaderText = "Line";
            this.colLine.MinimumWidth = 6;
            this.colLine.Name = "colLine";
            this.colLine.Width = 125;
            // 
            // colDescription
            // 
            this.colDescription.HeaderText = "Description";
            this.colDescription.MinimumWidth = 6;
            this.colDescription.Name = "colDescription";
            this.colDescription.Width = 125;
            // 
            // colFeeType
            // 
            this.colFeeType.HeaderText = "Fee Type";
            this.colFeeType.MinimumWidth = 6;
            this.colFeeType.Name = "colFeeType";
            this.colFeeType.Width = 125;
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "Amount";
            this.colAmount.MinimumWidth = 6;
            this.colAmount.Name = "colAmount";
            this.colAmount.Width = 125;
            // 
            // Invoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1378, 914);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Invoice";
            this.Text = "F";
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvInvoices;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvLineItems;
        private System.Windows.Forms.ComboBox cmbStatusFilter;
        private System.Windows.Forms.ComboBox cmbClientFilter;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvoiceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClient;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCase;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFeeType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
    }
}