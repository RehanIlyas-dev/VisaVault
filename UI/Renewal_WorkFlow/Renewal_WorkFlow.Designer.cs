namespace visavault_g43
{
    partial class Renewal_WorkFlow
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
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbStatusFilter = new System.Windows.Forms.ComboBox();
            this.dgvCases = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelApprovedRejected = new System.Windows.Forms.Panel();
            this.panelUnderReview = new System.Windows.Forms.Panel();
            this.panelSubmitted = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelPending = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.colCaseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDocument = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIssueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOpened = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastUpdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDaysinStage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCases)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(14)))), ((int)(((byte)(85)))));
            this.panel5.Controls.Add(this.pictureBox2);
            this.panel5.Controls.Add(this.label11);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1396, 63);
            this.panel5.TabIndex = 39;
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
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(66, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(263, 32);
            this.label11.TabIndex = 56;
            this.label11.Text = "Renewal Workflow";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(14)))), ((int)(((byte)(85)))));
            this.panel6.Controls.Add(this.btnSearch);
            this.panel6.Controls.Add(this.cmbStatusFilter);
            this.panel6.Controls.Add(this.dgvCases);
            this.panel6.Controls.Add(this.button2);
            this.panel6.Location = new System.Drawing.Point(50, 115);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1237, 329);
            this.panel6.TabIndex = 40;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(14)))), ((int)(((byte)(85)))));
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Book Antiqua", 12.2F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(712, 39);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 40);
            this.btnSearch.TabIndex = 61;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // cmbStatusFilter
            // 
            this.cmbStatusFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(14)))), ((int)(((byte)(85)))));
            this.cmbStatusFilter.Font = new System.Drawing.Font("Book Antiqua", 12.2F, System.Drawing.FontStyle.Bold);
            this.cmbStatusFilter.ForeColor = System.Drawing.Color.White;
            this.cmbStatusFilter.FormattingEnabled = true;
            this.cmbStatusFilter.Location = new System.Drawing.Point(396, 44);
            this.cmbStatusFilter.Name = "cmbStatusFilter";
            this.cmbStatusFilter.Size = new System.Drawing.Size(244, 32);
            this.cmbStatusFilter.TabIndex = 60;
            // 
            // dgvCases
            // 
            this.dgvCases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCases.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCaseID,
            this.colClient,
            this.colDocument,
            this.colStage,
            this.colIssueDate,
            this.colOpened,
            this.colLastUpdate,
            this.colDaysinStage});
            this.dgvCases.Location = new System.Drawing.Point(22, 117);
            this.dgvCases.Name = "dgvCases";
            this.dgvCases.RowHeadersWidth = 51;
            this.dgvCases.RowTemplate.Height = 24;
            this.dgvCases.Size = new System.Drawing.Size(1194, 168);
            this.dgvCases.TabIndex = 27;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(771, 130);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 26;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(14)))), ((int)(((byte)(85)))));
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.panelApprovedRejected);
            this.panel1.Controls.Add(this.panelUnderReview);
            this.panel1.Controls.Add(this.panelSubmitted);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.panelPending);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(50, 496);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1237, 296);
            this.panel1.TabIndex = 41;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::visavault_g43.Properties.Resources.arrows;
            this.pictureBox4.Location = new System.Drawing.Point(838, 143);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(67, 51);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 49;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::visavault_g43.Properties.Resources.arrows;
            this.pictureBox3.Location = new System.Drawing.Point(595, 138);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(67, 51);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 48;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::visavault_g43.Properties.Resources.arrows;
            this.pictureBox1.Location = new System.Drawing.Point(353, 138);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(67, 51);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 47;
            this.pictureBox1.TabStop = false;
            // 
            // panelApprovedRejected
            // 
            this.panelApprovedRejected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(14)))), ((int)(((byte)(85)))));
            this.panelApprovedRejected.Location = new System.Drawing.Point(911, 107);
            this.panelApprovedRejected.Name = "panelApprovedRejected";
            this.panelApprovedRejected.Size = new System.Drawing.Size(163, 107);
            this.panelApprovedRejected.TabIndex = 37;
            // 
            // panelUnderReview
            // 
            this.panelUnderReview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(14)))), ((int)(((byte)(85)))));
            this.panelUnderReview.Location = new System.Drawing.Point(669, 107);
            this.panelUnderReview.Name = "panelUnderReview";
            this.panelUnderReview.Size = new System.Drawing.Size(163, 107);
            this.panelUnderReview.TabIndex = 37;
            // 
            // panelSubmitted
            // 
            this.panelSubmitted.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(14)))), ((int)(((byte)(85)))));
            this.panelSubmitted.Location = new System.Drawing.Point(426, 107);
            this.panelSubmitted.Name = "panelSubmitted";
            this.panelSubmitted.Size = new System.Drawing.Size(163, 107);
            this.panelSubmitted.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Book Antiqua", 12.2F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(216, 240);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 26);
            this.label8.TabIndex = 46;
            this.label8.Text = "Pending";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Book Antiqua", 12.2F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(680, 240);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 26);
            this.label7.TabIndex = 45;
            this.label7.Text = "Under Review";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Book Antiqua", 12.2F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(455, 240);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 26);
            this.label6.TabIndex = 44;
            this.label6.Text = "Submitted";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Book Antiqua", 12.2F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(898, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(210, 26);
            this.label5.TabIndex = 43;
            this.label5.Text = "Approved / Rejected";
            // 
            // panelPending
            // 
            this.panelPending.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(14)))), ((int)(((byte)(85)))));
            this.panelPending.Location = new System.Drawing.Point(183, 107);
            this.panelPending.Name = "panelPending";
            this.panelPending.Size = new System.Drawing.Size(163, 107);
            this.panelPending.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Book Antiqua", 16.2F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(53, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 32);
            this.label1.TabIndex = 35;
            this.label1.Text = "Stage Flow : ";
            // 
            // colCaseID
            // 
            this.colCaseID.HeaderText = "Case ID";
            this.colCaseID.MinimumWidth = 6;
            this.colCaseID.Name = "colCaseID";
            this.colCaseID.Width = 125;
            // 
            // colClient
            // 
            this.colClient.HeaderText = "Client";
            this.colClient.MinimumWidth = 6;
            this.colClient.Name = "colClient";
            this.colClient.Width = 125;
            // 
            // colDocument
            // 
            this.colDocument.HeaderText = "Document";
            this.colDocument.MinimumWidth = 6;
            this.colDocument.Name = "colDocument";
            this.colDocument.Width = 125;
            // 
            // colStage
            // 
            this.colStage.HeaderText = "Stage";
            this.colStage.MinimumWidth = 6;
            this.colStage.Name = "colStage";
            this.colStage.Width = 125;
            // 
            // colIssueDate
            // 
            this.colIssueDate.HeaderText = "Issue Date";
            this.colIssueDate.MinimumWidth = 6;
            this.colIssueDate.Name = "colIssueDate";
            this.colIssueDate.Width = 125;
            // 
            // colOpened
            // 
            this.colOpened.HeaderText = "Openend";
            this.colOpened.MinimumWidth = 6;
            this.colOpened.Name = "colOpened";
            this.colOpened.Width = 125;
            // 
            // colLastUpdate
            // 
            this.colLastUpdate.HeaderText = "Last Update";
            this.colLastUpdate.MinimumWidth = 6;
            this.colLastUpdate.Name = "colLastUpdate";
            this.colLastUpdate.Width = 125;
            // 
            // colDaysinStage
            // 
            this.colDaysinStage.HeaderText = "Dyas in Stage";
            this.colDaysinStage.MinimumWidth = 6;
            this.colDaysinStage.Name = "colDaysinStage";
            this.colDaysinStage.Width = 125;
            // 
            // Renewal_WorkFlow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(14)))), ((int)(((byte)(75)))));
            this.ClientSize = new System.Drawing.Size(1396, 961);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Renewal_WorkFlow";
            this.Text = "Renewal_WorkFlow";
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCases)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView dgvCases;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelPending;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelApprovedRejected;
        private System.Windows.Forms.Panel panelUnderReview;
        private System.Windows.Forms.Panel panelSubmitted;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbStatusFilter;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCaseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClient;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocument;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIssueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOpened;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDaysinStage;
    }
}