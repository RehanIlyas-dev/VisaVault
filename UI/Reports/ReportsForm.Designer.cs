namespace visavault_g43
{
    partial class ReportsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpParams = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblCountry = new System.Windows.Forms.Label();
            this.cmbCountry = new System.Windows.Forms.ComboBox();
            this.lblStage = new System.Windows.Forms.Label();
            this.cmbStage = new System.Windows.Forms.ComboBox();
            this.lblDays = new System.Windows.Forms.Label();
            this.nudDays = new System.Windows.Forms.NumericUpDown();
            this.lblDateRange = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.lblSingleDate = new System.Windows.Forms.Label();
            this.dtpSingleDate = new System.Windows.Forms.DateTimePicker();
            this.lblCaseId = new System.Windows.Forms.Label();
            this.txtCaseId = new System.Windows.Forms.TextBox();
            this.lblReportSelect = new System.Windows.Forms.Label();
            
            this.grpParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDays)).BeginInit();
            this.SuspendLayout();
            
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Book Antiqua", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(86)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(262, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "PDF Reports Generator";
            
            // 
            // lblReportSelect
            // 
            this.lblReportSelect.AutoSize = true;
            this.lblReportSelect.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportSelect.Location = new System.Drawing.Point(20, 70);
            this.lblReportSelect.Name = "lblReportSelect";
            this.lblReportSelect.Size = new System.Drawing.Size(125, 16);
            this.lblReportSelect.TabIndex = 1;
            this.lblReportSelect.Text = "Select Report Type:";
            
            // 
            // cmbReportType
            // 
            this.cmbReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReportType.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Location = new System.Drawing.Point(160, 67);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(350, 24);
            this.cmbReportType.TabIndex = 2;
            
            // 
            // grpParams
            // 
            this.grpParams.Controls.Add(this.lblStatus);
            this.grpParams.Controls.Add(this.cmbStatus);
            this.grpParams.Controls.Add(this.lblCountry);
            this.grpParams.Controls.Add(this.cmbCountry);
            this.grpParams.Controls.Add(this.lblStage);
            this.grpParams.Controls.Add(this.cmbStage);
            this.grpParams.Controls.Add(this.lblDays);
            this.grpParams.Controls.Add(this.nudDays);
            this.grpParams.Controls.Add(this.lblDateRange);
            this.grpParams.Controls.Add(this.dtpStart);
            this.grpParams.Controls.Add(this.lblTo);
            this.grpParams.Controls.Add(this.dtpEnd);
            this.grpParams.Controls.Add(this.lblSingleDate);
            this.grpParams.Controls.Add(this.dtpSingleDate);
            this.grpParams.Controls.Add(this.lblCaseId);
            this.grpParams.Controls.Add(this.txtCaseId);
            this.grpParams.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpParams.Location = new System.Drawing.Point(20, 110);
            this.grpParams.Name = "grpParams";
            this.grpParams.Size = new System.Drawing.Size(490, 200);
            this.grpParams.TabIndex = 3;
            this.grpParams.TabStop = false;
            this.grpParams.Text = "Report Parameters";
            
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(20, 35);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(49, 16);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Status:";
            
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(120, 32);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(200, 24);
            this.cmbStatus.TabIndex = 1;
            
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountry.Location = new System.Drawing.Point(20, 75);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(56, 16);
            this.lblCountry.TabIndex = 2;
            this.lblCountry.Text = "Country:";
            
            // 
            // cmbCountry
            // 
            this.cmbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCountry.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCountry.FormattingEnabled = true;
            this.cmbCountry.Location = new System.Drawing.Point(120, 72);
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.Size = new System.Drawing.Size(200, 24);
            this.cmbCountry.TabIndex = 3;
            
            // 
            // lblStage
            // 
            this.lblStage.AutoSize = true;
            this.lblStage.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStage.Location = new System.Drawing.Point(20, 115);
            this.lblStage.Name = "lblStage";
            this.lblStage.Size = new System.Drawing.Size(45, 16);
            this.lblStage.TabIndex = 4;
            this.lblStage.Text = "Stage:";
            
            // 
            // cmbStage
            // 
            this.cmbStage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStage.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStage.FormattingEnabled = true;
            this.cmbStage.Location = new System.Drawing.Point(120, 112);
            this.cmbStage.Name = "cmbStage";
            this.cmbStage.Size = new System.Drawing.Size(200, 24);
            this.cmbStage.TabIndex = 5;
            
            // 
            // lblDays
            // 
            this.lblDays.AutoSize = true;
            this.lblDays.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDays.Location = new System.Drawing.Point(20, 35);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(92, 16);
            this.lblDays.TabIndex = 6;
            this.lblDays.Text = "Days Remaining:";
            
            // 
            // nudDays
            // 
            this.nudDays.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudDays.Location = new System.Drawing.Point(120, 33);
            this.nudDays.Maximum = new decimal(new int[] { 365, 0, 0, 0 });
            this.nudDays.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudDays.Name = "nudDays";
            this.nudDays.Size = new System.Drawing.Size(100, 22);
            this.nudDays.TabIndex = 7;
            this.nudDays.Value = new decimal(new int[] { 90, 0, 0, 0 });
            
            // 
            // lblDateRange
            // 
            this.lblDateRange.AutoSize = true;
            this.lblDateRange.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateRange.Location = new System.Drawing.Point(20, 35);
            this.lblDateRange.Name = "lblDateRange";
            this.lblDateRange.Size = new System.Drawing.Size(78, 16);
            this.lblDateRange.TabIndex = 8;
            this.lblDateRange.Text = "Date Range:";
            
            // 
            // dtpStart
            // 
            this.dtpStart.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(120, 32);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(120, 22);
            this.dtpStart.TabIndex = 9;
            
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(250, 35);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(20, 16);
            this.lblTo.TabIndex = 10;
            this.lblTo.Text = "to";
            
            // 
            // dtpEnd
            // 
            this.dtpEnd.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(280, 32);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(120, 22);
            this.dtpEnd.TabIndex = 11;
            
            // 
            // lblSingleDate
            // 
            this.lblSingleDate.AutoSize = true;
            this.lblSingleDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSingleDate.Location = new System.Drawing.Point(20, 35);
            this.lblSingleDate.Name = "lblSingleDate";
            this.lblSingleDate.Size = new System.Drawing.Size(38, 16);
            this.lblSingleDate.TabIndex = 12;
            this.lblSingleDate.Text = "Date:";
            
            // 
            // dtpSingleDate
            // 
            this.dtpSingleDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpSingleDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSingleDate.Location = new System.Drawing.Point(120, 32);
            this.dtpSingleDate.Name = "dtpSingleDate";
            this.dtpSingleDate.Size = new System.Drawing.Size(120, 22);
            this.dtpSingleDate.TabIndex = 13;
            
            // 
            // lblCaseId
            // 
            this.lblCaseId.AutoSize = true;
            this.lblCaseId.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaseId.Location = new System.Drawing.Point(20, 35);
            this.lblCaseId.Name = "lblCaseId";
            this.lblCaseId.Size = new System.Drawing.Size(57, 16);
            this.lblCaseId.TabIndex = 14;
            this.lblCaseId.Text = "Case ID:";
            
            // 
            // txtCaseId
            // 
            this.txtCaseId.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCaseId.Location = new System.Drawing.Point(120, 32);
            this.txtCaseId.Name = "txtCaseId";
            this.txtCaseId.Size = new System.Drawing.Size(100, 22);
            this.txtCaseId.TabIndex = 15;
            
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(86)))));
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.ForeColor = System.Drawing.Color.White;
            this.btnGenerate.Location = new System.Drawing.Point(20, 330);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(490, 45);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "Generate and Save PDF Report";
            this.btnGenerate.UseVisualStyleBackColor = false;
            
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(550, 400);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.grpParams);
            this.Controls.Add(this.cmbReportType);
            this.Controls.Add(this.lblReportSelect);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReportsForm";
            this.Text = "PDF Reports Generator";
            this.grpParams.ResumeLayout(false);
            this.grpParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDays)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpParams;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.ComboBox cmbCountry;
        private System.Windows.Forms.Label lblStage;
        private System.Windows.Forms.ComboBox cmbStage;
        private System.Windows.Forms.Label lblDays;
        private System.Windows.Forms.NumericUpDown nudDays;
        private System.Windows.Forms.Label lblDateRange;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label lblSingleDate;
        private System.Windows.Forms.DateTimePicker dtpSingleDate;
        private System.Windows.Forms.Label lblCaseId;
        private System.Windows.Forms.TextBox txtCaseId;
        private System.Windows.Forms.Label lblReportSelect;
    }
}
