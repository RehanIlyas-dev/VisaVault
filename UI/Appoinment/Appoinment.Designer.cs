namespace visavault_g43
{
    partial class Appoinment
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
            this.btnFilter = new System.Windows.Forms.Button();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPurpose = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
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
            this.panel3.Size = new System.Drawing.Size(1324, 63);
            this.panel3.TabIndex = 25;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::visavault_g43.Properties.Resources.calendar;
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
            this.label11.Size = new System.Drawing.Size(193, 32);
            this.label11.TabIndex = 56;
            this.label11.Text = "Appointment ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnFilter);
            this.panel1.Controls.Add(this.txtDate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dgvAppointments);
            this.panel1.Location = new System.Drawing.Point(92, 139);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1128, 519);
            this.panel1.TabIndex = 26;
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(68)))), ((int)(((byte)(115)))));
            this.btnFilter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnFilter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Location = new System.Drawing.Point(775, 86);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(120, 40);
            this.btnFilter.TabIndex = 55;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = false;
            // 
            // txtDate
            // 
            this.txtDate.BackColor = System.Drawing.Color.White;
            this.txtDate.Font = new System.Drawing.Font("Book Antiqua", 12.2F, System.Drawing.FontStyle.Bold);
            this.txtDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.txtDate.Location = new System.Drawing.Point(495, 91);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(181, 32);
            this.txtDate.TabIndex = 54;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Book Antiqua", 12.2F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(68)))), ((int)(((byte)(115)))));
            this.label2.Location = new System.Drawing.Point(234, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 26);
            this.label2.TabIndex = 21;
            this.label2.Text = "Date (dd-mm-yyyy) :";
            // 
            // dgvAppointments
            // 
            this.dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTime,
            this.colClient,
            this.colPurpose,
            this.colStatus});
            this.dgvAppointments.Location = new System.Drawing.Point(172, 196);
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.RowHeadersWidth = 51;
            this.dgvAppointments.RowTemplate.Height = 24;
            this.dgvAppointments.Size = new System.Drawing.Size(793, 164);
            this.dgvAppointments.TabIndex = 20;
            System.Windows.Forms.DataGridViewCellStyle dgvAppointmentsHeaderStyle = new System.Windows.Forms.DataGridViewCellStyle();
            dgvAppointmentsHeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(68)))), ((int)(((byte)(115)))));
            dgvAppointmentsHeaderStyle.ForeColor = System.Drawing.Color.White;
            dgvAppointmentsHeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            
            System.Windows.Forms.DataGridViewCellStyle dgvAppointmentsRowStyle = new System.Windows.Forms.DataGridViewCellStyle();
            dgvAppointmentsRowStyle.BackColor = System.Drawing.Color.White;
            dgvAppointmentsRowStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dgvAppointmentsRowStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dgvAppointmentsRowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            dgvAppointmentsRowStyle.SelectionForeColor = System.Drawing.Color.Black;

            this.dgvAppointments.BackgroundColor = System.Drawing.Color.White;
            this.dgvAppointments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAppointments.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAppointments.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvAppointments.EnableHeadersVisualStyles = false;
            this.dgvAppointments.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvAppointments.ColumnHeadersDefaultCellStyle = dgvAppointmentsHeaderStyle;
            this.dgvAppointments.ColumnHeadersHeight = 40;
            this.dgvAppointments.DefaultCellStyle = dgvAppointmentsRowStyle;
            this.dgvAppointments.RowHeadersVisible = false;
            this.dgvAppointments.RowTemplate.Height = 35;
            this.dgvAppointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAppointments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAppointments.AllowUserToAddRows = false;
            this.dgvAppointments.AllowUserToDeleteRows = false;
            this.dgvAppointments.ReadOnly = true;
            // 
            // colTime
            // 
            this.colTime.HeaderText = "Time";
            this.colTime.MinimumWidth = 6;
            this.colTime.Name = "colTime";
            this.colTime.Width = 250;
            // 
            // colClient
            // 
            this.colClient.HeaderText = "Client";
            this.colClient.MinimumWidth = 6;
            this.colClient.Name = "colClient";
            this.colClient.Width = 125;
            // 
            // colPurpose
            // 
            this.colPurpose.HeaderText = "Purpose";
            this.colPurpose.MinimumWidth = 6;
            this.colPurpose.Name = "colPurpose";
            this.colPurpose.Width = 125;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.MinimumWidth = 6;
            this.colStatus.Name = "colStatus";
            this.colStatus.Width = 125;
            // 
            // Appoinment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1324, 773);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Appoinment";
            this.Text = "Appoinment";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvAppointments;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClient;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPurpose;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
    }
}