namespace visavault_g43
{
    partial class Fee_Calculator
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
            System.Windows.Forms.Button btnCalculateFee;
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvFeeBreakdown = new System.Windows.Forms.DataGridView();
            this.cmbCountry = new System.Windows.Forms.ComboBox();
            this.cmbDocumentType = new System.Windows.Forms.ComboBox();
            this.colComponent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            btnCalculateFee = new System.Windows.Forms.Button();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeeBreakdown)).BeginInit();
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
            this.panel5.Size = new System.Drawing.Size(1360, 63);
            this.panel5.TabIndex = 37;
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
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(66, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(196, 32);
            this.label11.TabIndex = 56;
            this.label11.Text = "Fee Calculator";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(14)))), ((int)(((byte)(85)))));
            this.panel1.Controls.Add(this.cmbDocumentType);
            this.panel1.Controls.Add(this.cmbCountry);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(142, 114);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1067, 186);
            this.panel1.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Book Antiqua", 12.2F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(352, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 26);
            this.label3.TabIndex = 16;
            this.label3.Text = "Document Type\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Book Antiqua", 12.2F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(352, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 26);
            this.label2.TabIndex = 15;
            this.label2.Text = "Country ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Book Antiqua", 16.2F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(62, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 32);
            this.label1.TabIndex = 14;
            this.label1.Text = "Fee Lookup ";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(14)))), ((int)(((byte)(85)))));
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.dgvFeeBreakdown);
            this.panel2.Location = new System.Drawing.Point(142, 406);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1067, 401);
            this.panel2.TabIndex = 39;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Book Antiqua", 16.2F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(62, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(220, 32);
            this.label4.TabIndex = 13;
            this.label4.Text = "Fee Breakdown ";
            // 
            // dgvFeeBreakdown
            // 
            this.dgvFeeBreakdown.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFeeBreakdown.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colComponent,
            this.colType,
            this.colAmount});
            this.dgvFeeBreakdown.Location = new System.Drawing.Point(121, 140);
            this.dgvFeeBreakdown.Name = "dgvFeeBreakdown";
            this.dgvFeeBreakdown.RowHeadersWidth = 51;
            this.dgvFeeBreakdown.RowTemplate.Height = 24;
            this.dgvFeeBreakdown.Size = new System.Drawing.Size(815, 182);
            this.dgvFeeBreakdown.TabIndex = 12;
            // 
            // btnCalculateFee
            // 
            btnCalculateFee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(14)))), ((int)(((byte)(85)))));
            btnCalculateFee.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            btnCalculateFee.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            btnCalculateFee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCalculateFee.Font = new System.Drawing.Font("Book Antiqua", 9.2F, System.Drawing.FontStyle.Bold);
            btnCalculateFee.ForeColor = System.Drawing.Color.White;
            btnCalculateFee.Location = new System.Drawing.Point(1017, 320);
            btnCalculateFee.Name = "btnCalculateFee";
            btnCalculateFee.Size = new System.Drawing.Size(192, 40);
            btnCalculateFee.TabIndex = 61;
            btnCalculateFee.Text = "Calculate Fee";
            btnCalculateFee.UseVisualStyleBackColor = false;
            // 
            // cmbCountry
            // 
            this.cmbCountry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(14)))), ((int)(((byte)(85)))));
            this.cmbCountry.Font = new System.Drawing.Font("Book Antiqua", 12.2F, System.Drawing.FontStyle.Bold);
            this.cmbCountry.ForeColor = System.Drawing.Color.White;
            this.cmbCountry.FormattingEnabled = true;
            this.cmbCountry.Location = new System.Drawing.Point(589, 77);
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.Size = new System.Drawing.Size(152, 32);
            this.cmbCountry.TabIndex = 62;
            // 
            // cmbDocumentType
            // 
            this.cmbDocumentType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(14)))), ((int)(((byte)(85)))));
            this.cmbDocumentType.Font = new System.Drawing.Font("Book Antiqua", 12.2F, System.Drawing.FontStyle.Bold);
            this.cmbDocumentType.ForeColor = System.Drawing.Color.White;
            this.cmbDocumentType.FormattingEnabled = true;
            this.cmbDocumentType.Location = new System.Drawing.Point(589, 131);
            this.cmbDocumentType.Name = "cmbDocumentType";
            this.cmbDocumentType.Size = new System.Drawing.Size(152, 32);
            this.cmbDocumentType.TabIndex = 63;
            // 
            // colComponent
            // 
            this.colComponent.HeaderText = "Component";
            this.colComponent.MinimumWidth = 6;
            this.colComponent.Name = "colComponent";
            this.colComponent.Width = 250;
            // 
            // colType
            // 
            this.colType.HeaderText = "Type";
            this.colType.MinimumWidth = 6;
            this.colType.Name = "colType";
            this.colType.Width = 125;
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "Amount";
            this.colAmount.MinimumWidth = 6;
            this.colAmount.Name = "colAmount";
            this.colAmount.Width = 125;
            // 
            // Fee_Calculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(14)))), ((int)(((byte)(75)))));
            this.ClientSize = new System.Drawing.Size(1360, 867);
            this.Controls.Add(btnCalculateFee);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Fee_Calculator";
            this.Text = "Fee_Calculator";
            this.Load += new System.EventHandler(this.Fee_Calculator_Load);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeeBreakdown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvFeeBreakdown;
        private System.Windows.Forms.ComboBox cmbDocumentType;
        private System.Windows.Forms.ComboBox cmbCountry;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComponent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
    }
}