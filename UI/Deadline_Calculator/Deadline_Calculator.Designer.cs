namespace visavault_g43
{
    partial class Deadline_Calculator
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
            this.cmbClient = new System.Windows.Forms.ComboBox();
            this.dgvDeadlines = new System.Windows.Forms.DataGridView();
            this.colClient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDocType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExpiryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProcDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBufferDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDaysToAct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAlert = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeadlines)).BeginInit();
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
            this.panel3.Size = new System.Drawing.Size(1414, 63);
            this.panel3.TabIndex = 27;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::visavault_g43.Properties.Resources.renewable;
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
            this.label11.Size = new System.Drawing.Size(269, 32);
            this.label11.TabIndex = 56;
            this.label11.Text = "Deadline Calculator";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.cmbClient);
            this.panel1.Controls.Add(this.dgvDeadlines);
            this.panel1.Location = new System.Drawing.Point(26, 142);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1273, 453);
            this.panel1.TabIndex = 28;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(68)))), ((int)(((byte)(115)))));
            this.btnClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(800, 56);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(120, 40);
            this.btnClear.TabIndex = 62;
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
            this.btnSearch.Location = new System.Drawing.Point(657, 56);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 40);
            this.btnSearch.TabIndex = 61;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // cmbClient
            // 
            this.cmbClient.BackColor = System.Drawing.Color.White;
            this.cmbClient.Font = new System.Drawing.Font("Book Antiqua", 12.2F, System.Drawing.FontStyle.Bold);
            this.cmbClient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.cmbClient.FormattingEnabled = true;
            this.cmbClient.Location = new System.Drawing.Point(347, 60);
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.Size = new System.Drawing.Size(247, 32);
            this.cmbClient.TabIndex = 60;
            // 
            // dgvDeadlines
            // 
            this.dgvDeadlines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeadlines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colClient,
            this.colDocType,
            this.colExpiryDate,
            this.colProcDays,
            this.colBufferDays,
            this.colActionDate,
            this.colDaysToAct,
            this.colAlert});
            this.dgvDeadlines.Location = new System.Drawing.Point(18, 173);
            this.dgvDeadlines.Name = "dgvDeadlines";
            this.dgvDeadlines.RowHeadersWidth = 51;
            this.dgvDeadlines.RowTemplate.Height = 24;
            this.dgvDeadlines.Size = new System.Drawing.Size(1236, 168);
            this.dgvDeadlines.TabIndex = 27;
            System.Windows.Forms.DataGridViewCellStyle dgvDeadlinesHeaderStyle = new System.Windows.Forms.DataGridViewCellStyle();
            dgvDeadlinesHeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(68)))), ((int)(((byte)(115)))));
            dgvDeadlinesHeaderStyle.ForeColor = System.Drawing.Color.White;
            dgvDeadlinesHeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            
            System.Windows.Forms.DataGridViewCellStyle dgvDeadlinesRowStyle = new System.Windows.Forms.DataGridViewCellStyle();
            dgvDeadlinesRowStyle.BackColor = System.Drawing.Color.White;
            dgvDeadlinesRowStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dgvDeadlinesRowStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dgvDeadlinesRowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            dgvDeadlinesRowStyle.SelectionForeColor = System.Drawing.Color.Black;

            this.dgvDeadlines.BackgroundColor = System.Drawing.Color.White;
            this.dgvDeadlines.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDeadlines.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDeadlines.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvDeadlines.EnableHeadersVisualStyles = false;
            this.dgvDeadlines.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDeadlines.ColumnHeadersDefaultCellStyle = dgvDeadlinesHeaderStyle;
            this.dgvDeadlines.ColumnHeadersHeight = 40;
            this.dgvDeadlines.DefaultCellStyle = dgvDeadlinesRowStyle;
            this.dgvDeadlines.RowHeadersVisible = false;
            this.dgvDeadlines.RowTemplate.Height = 35;
            this.dgvDeadlines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDeadlines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDeadlines.AllowUserToAddRows = false;
            this.dgvDeadlines.AllowUserToDeleteRows = false;
            this.dgvDeadlines.ReadOnly = true;
            // 
            // colClient
            // 
            this.colClient.HeaderText = "Client";
            this.colClient.MinimumWidth = 6;
            this.colClient.Name = "colClient";
            this.colClient.Width = 50;
            // 
            // colDocType
            // 
            this.colDocType.HeaderText = "Doc Type";
            this.colDocType.MinimumWidth = 6;
            this.colDocType.Name = "colDocType";
            this.colDocType.Width = 125;
            // 
            // colExpiryDate
            // 
            this.colExpiryDate.HeaderText = "Expiry Date";
            this.colExpiryDate.MinimumWidth = 6;
            this.colExpiryDate.Name = "colExpiryDate";
            this.colExpiryDate.Width = 125;
            // 
            // colProcDays
            // 
            this.colProcDays.HeaderText = "Proc. Days";
            this.colProcDays.MinimumWidth = 6;
            this.colProcDays.Name = "colProcDays";
            this.colProcDays.Width = 125;
            // 
            // colBufferDays
            // 
            this.colBufferDays.HeaderText = "Buffer Days";
            this.colBufferDays.MinimumWidth = 6;
            this.colBufferDays.Name = "colBufferDays";
            this.colBufferDays.Width = 125;
            // 
            // colActionDate
            // 
            this.colActionDate.HeaderText = "Action Date";
            this.colActionDate.MinimumWidth = 6;
            this.colActionDate.Name = "colActionDate";
            this.colActionDate.Width = 125;
            // 
            // colDaysToAct
            // 
            this.colDaysToAct.HeaderText = "Days to Act";
            this.colDaysToAct.MinimumWidth = 6;
            this.colDaysToAct.Name = "colDaysToAct";
            this.colDaysToAct.Width = 125;
            // 
            // colAlert
            // 
            this.colAlert.HeaderText = "Alert";
            this.colAlert.MinimumWidth = 6;
            this.colAlert.Name = "colAlert";
            this.colAlert.Width = 125;
            // 
            // Deadline_Calculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1414, 1008);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Deadline_Calculator";
            this.Text = "DeadLine_Calculator";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeadlines)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvDeadlines;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbClient;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClient;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExpiryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProcDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBufferDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActionDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDaysToAct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAlert;
    }
}