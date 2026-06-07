namespace visavault_g43
{
    partial class Form1
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
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHome = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewClients = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewDocuments = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewCases = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewInvoices = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewReports = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewAppointments = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewExpiryAlerts = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.panelSideMenue = new System.Windows.Forms.Panel();
            this.EAbtn = new System.Windows.Forms.Button();
            this.appbtn = new System.Windows.Forms.Button();
            this.panelFinance = new System.Windows.Forms.Panel();
            this.RPbtn = new System.Windows.Forms.Button();
            this.FCbtn = new System.Windows.Forms.Button();
            this.Ibtn = new System.Windows.Forms.Button();
            this.financebtn = new System.Windows.Forms.Button();
            this.panelCases = new System.Windows.Forms.Panel();
            this.DCbtn = new System.Windows.Forms.Button();
            this.DVbtn = new System.Windows.Forms.Button();
            this.RWbtn = new System.Windows.Forms.Button();
            this.btncase = new System.Windows.Forms.Button();
            this.panelDocument = new System.Windows.Forms.Panel();
            this.DMbtn = new System.Windows.Forms.Button();
            this.DPbtn = new System.Windows.Forms.Button();
            this.Documentbtn = new System.Windows.Forms.Button();
            this.panelClient = new System.Windows.Forms.Panel();
            this.CMbtn = new System.Windows.Forms.Button();
            this.CRbtn = new System.Windows.Forms.Button();
            this.Clientbtn = new System.Windows.Forms.Button();
            this.Homebtn = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.Mainpanel = new System.Windows.Forms.Panel();
            this.mainMenuStrip.SuspendLayout();
            this.panelSideMenue.SuspendLayout();
            this.panelFinance.SuspendLayout();
            this.panelCases.SuspendLayout();
            this.panelDocument.SuspendLayout();
            this.panelClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(14)))), ((int)(((byte)(85)))));
            this.mainMenuStrip.ForeColor = System.Drawing.Color.Gainsboro;
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1682, 24);
            this.mainMenuStrip.TabIndex = 2;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHome,
            this.toolStripSeparator1,
            this.menuExit});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // menuHome
            // 
            this.menuHome.Name = "menuHome";
            this.menuHome.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Home)));
            this.menuHome.Size = new System.Drawing.Size(180, 22);
            this.menuHome.Text = "Home";
            this.menuHome.Click += new System.EventHandler(this.menuHome_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.menuExit.Size = new System.Drawing.Size(180, 22);
            this.menuExit.Text = "Exit";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuViewClients,
            this.menuViewDocuments,
            this.menuViewCases,
            this.menuViewInvoices,
            this.menuViewReports,
            this.menuViewAppointments,
            this.menuViewExpiryAlerts});
            this.viewToolStripMenuItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // menuViewClients
            // 
            this.menuViewClients.Name = "menuViewClients";
            this.menuViewClients.Size = new System.Drawing.Size(180, 22);
            this.menuViewClients.Text = "Client Registry";
            this.menuViewClients.Click += new System.EventHandler(this.CRbtn_Click);
            // 
            // menuViewDocuments
            // 
            this.menuViewDocuments.Name = "menuViewDocuments";
            this.menuViewDocuments.Size = new System.Drawing.Size(180, 22);
            this.menuViewDocuments.Text = "Document Portfolio";
            this.menuViewDocuments.Click += new System.EventHandler(this.DPbtn_Click);
            // 
            // menuViewCases
            // 
            this.menuViewCases.Name = "menuViewCases";
            this.menuViewCases.Size = new System.Drawing.Size(180, 22);
            this.menuViewCases.Text = "Renewal Workflow";
            this.menuViewCases.Click += new System.EventHandler(this.RWbtn_Click);
            // 
            // menuViewInvoices
            // 
            this.menuViewInvoices.Name = "menuViewInvoices";
            this.menuViewInvoices.Size = new System.Drawing.Size(180, 22);
            this.menuViewInvoices.Text = "Invoices";
            this.menuViewInvoices.Click += new System.EventHandler(this.Ibtn_Click);
            // 
            // menuViewReports
            // 
            this.menuViewReports.Name = "menuViewReports";
            this.menuViewReports.Size = new System.Drawing.Size(180, 22);
            this.menuViewReports.Text = "Reports Dashboard";
            this.menuViewReports.Click += new System.EventHandler(this.RPbtn_Click);
            // 
            // menuViewAppointments
            // 
            this.menuViewAppointments.Name = "menuViewAppointments";
            this.menuViewAppointments.Size = new System.Drawing.Size(180, 22);
            this.menuViewAppointments.Text = "Appointments";
            this.menuViewAppointments.Click += new System.EventHandler(this.appbtn_Click);
            // 
            // menuViewExpiryAlerts
            // 
            this.menuViewExpiryAlerts.Name = "menuViewExpiryAlerts";
            this.menuViewExpiryAlerts.Size = new System.Drawing.Size(180, 22);
            this.menuViewExpiryAlerts.Text = "Expiry Alerts";
            this.menuViewExpiryAlerts.Click += new System.EventHandler(this.EAbtn_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAbout});
            this.helpToolStripMenuItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // menuAbout
            // 
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(180, 22);
            this.menuAbout.Text = "About VisaVault";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // panelSideMenue
            // 
            this.panelSideMenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(14)))), ((int)(((byte)(85)))));
            this.panelSideMenue.Controls.Add(this.EAbtn);
            this.panelSideMenue.Controls.Add(this.appbtn);
            this.panelSideMenue.Controls.Add(this.panelFinance);
            this.panelSideMenue.Controls.Add(this.financebtn);
            this.panelSideMenue.Controls.Add(this.panelCases);
            this.panelSideMenue.Controls.Add(this.btncase);
            this.panelSideMenue.Controls.Add(this.panelDocument);
            this.panelSideMenue.Controls.Add(this.Documentbtn);
            this.panelSideMenue.Controls.Add(this.panelClient);
            this.panelSideMenue.Controls.Add(this.Clientbtn);
            this.panelSideMenue.Controls.Add(this.Homebtn);
            this.panelSideMenue.Controls.Add(this.panelLogo);
            this.panelSideMenue.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenue.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenue.Name = "panelSideMenue";
            this.panelSideMenue.Size = new System.Drawing.Size(250, 1055);
            this.panelSideMenue.TabIndex = 0;
            // 
            // EAbtn
            // 
            this.EAbtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.EAbtn.FlatAppearance.BorderSize = 0;
            this.EAbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.EAbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.EAbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EAbtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.EAbtn.Image = global::visavault_g43.Properties.Resources.time;
            this.EAbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EAbtn.Location = new System.Drawing.Point(0, 1024);
            this.EAbtn.Name = "EAbtn";
            this.EAbtn.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.EAbtn.Size = new System.Drawing.Size(250, 72);
            this.EAbtn.TabIndex = 13;
            this.EAbtn.Text = "                     Expiry Alerts";
            this.EAbtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EAbtn.UseVisualStyleBackColor = true;
            this.EAbtn.Click += new System.EventHandler(this.EAbtn_Click);
            // 
            // appbtn
            // 
            this.appbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(14)))), ((int)(((byte)(85)))));
            this.appbtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.appbtn.FlatAppearance.BorderSize = 0;
            this.appbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.appbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.appbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.appbtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.appbtn.Image = global::visavault_g43.Properties.Resources.calendar;
            this.appbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.appbtn.Location = new System.Drawing.Point(0, 946);
            this.appbtn.Name = "appbtn";
            this.appbtn.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.appbtn.Size = new System.Drawing.Size(250, 78);
            this.appbtn.TabIndex = 12;
            this.appbtn.Text = "                     Appointment";
            this.appbtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.appbtn.UseVisualStyleBackColor = false;
            this.appbtn.Click += new System.EventHandler(this.appbtn_Click);
            // 
            // panelFinance
            // 
            this.panelFinance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(14)))), ((int)(((byte)(75)))));
            this.panelFinance.Controls.Add(this.RPbtn);
            this.panelFinance.Controls.Add(this.FCbtn);
            this.panelFinance.Controls.Add(this.Ibtn);
            this.panelFinance.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFinance.Location = new System.Drawing.Point(0, 849);
            this.panelFinance.Name = "panelFinance";
            this.panelFinance.Size = new System.Drawing.Size(250, 137);
            this.panelFinance.TabIndex = 11;
            // 
            // RPbtn
            // 
            this.RPbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(14)))), ((int)(((byte)(75)))));
            this.RPbtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.RPbtn.FlatAppearance.BorderSize = 0;
            this.RPbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.RPbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.RPbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RPbtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.RPbtn.Location = new System.Drawing.Point(0, 80);
            this.RPbtn.Name = "RPbtn";
            this.RPbtn.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.RPbtn.Size = new System.Drawing.Size(250, 40);
            this.RPbtn.TabIndex = 2;
            this.RPbtn.Text = "Reports Dashboard";
            this.RPbtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RPbtn.UseVisualStyleBackColor = false;
            this.RPbtn.Click += new System.EventHandler(this.RPbtn_Click);
            // 
            // FCbtn
            // 
            this.FCbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(14)))), ((int)(((byte)(75)))));
            this.FCbtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.FCbtn.FlatAppearance.BorderSize = 0;
            this.FCbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.FCbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.FCbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FCbtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.FCbtn.Location = new System.Drawing.Point(0, 40);
            this.FCbtn.Name = "FCbtn";
            this.FCbtn.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.FCbtn.Size = new System.Drawing.Size(250, 40);
            this.FCbtn.TabIndex = 1;
            this.FCbtn.Text = "Fee Calculator";
            this.FCbtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FCbtn.UseVisualStyleBackColor = false;
            this.FCbtn.Click += new System.EventHandler(this.FCbtn_Click);
            // 
            // Ibtn
            // 
            this.Ibtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(14)))), ((int)(((byte)(75)))));
            this.Ibtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Ibtn.FlatAppearance.BorderSize = 0;
            this.Ibtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.Ibtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.Ibtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Ibtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.Ibtn.Location = new System.Drawing.Point(0, 0);
            this.Ibtn.Name = "Ibtn";
            this.Ibtn.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.Ibtn.Size = new System.Drawing.Size(250, 40);
            this.Ibtn.TabIndex = 0;
            this.Ibtn.Text = "Invoices";
            this.Ibtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Ibtn.UseVisualStyleBackColor = false;
            this.Ibtn.Click += new System.EventHandler(this.Ibtn_Click);
            // 
            // financebtn
            // 
            this.financebtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(14)))), ((int)(((byte)(85)))));
            this.financebtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.financebtn.FlatAppearance.BorderSize = 0;
            this.financebtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.financebtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.financebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.financebtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.financebtn.Image = global::visavault_g43.Properties.Resources.profit__1_;
            this.financebtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.financebtn.Location = new System.Drawing.Point(0, 762);
            this.financebtn.Name = "financebtn";
            this.financebtn.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.financebtn.Size = new System.Drawing.Size(250, 87);
            this.financebtn.TabIndex = 10;
            this.financebtn.Text = "                     Finance";
            this.financebtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.financebtn.UseVisualStyleBackColor = false;
            this.financebtn.Click += new System.EventHandler(this.financebtn_Click);
            // 
            // panelCases
            // 
            this.panelCases.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(14)))), ((int)(((byte)(75)))));
            this.panelCases.Controls.Add(this.DCbtn);
            this.panelCases.Controls.Add(this.DVbtn);
            this.panelCases.Controls.Add(this.RWbtn);
            this.panelCases.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCases.Location = new System.Drawing.Point(0, 619);
            this.panelCases.Name = "panelCases";
            this.panelCases.Size = new System.Drawing.Size(250, 143);
            this.panelCases.TabIndex = 9;
            // 
            // DCbtn
            // 
            this.DCbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(14)))), ((int)(((byte)(75)))));
            this.DCbtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.DCbtn.FlatAppearance.BorderSize = 0;
            this.DCbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.DCbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.DCbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DCbtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.DCbtn.Location = new System.Drawing.Point(0, 80);
            this.DCbtn.Name = "DCbtn";
            this.DCbtn.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.DCbtn.Size = new System.Drawing.Size(250, 40);
            this.DCbtn.TabIndex = 3;
            this.DCbtn.Text = "Deadline Calculator";
            this.DCbtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DCbtn.UseVisualStyleBackColor = false;
            this.DCbtn.Click += new System.EventHandler(this.DCbtn_Click);
            // 
            // DVbtn
            // 
            this.DVbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(14)))), ((int)(((byte)(75)))));
            this.DVbtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.DVbtn.FlatAppearance.BorderSize = 0;
            this.DVbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.DVbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.DVbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DVbtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.DVbtn.Location = new System.Drawing.Point(0, 40);
            this.DVbtn.Name = "DVbtn";
            this.DVbtn.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.DVbtn.Size = new System.Drawing.Size(250, 40);
            this.DVbtn.TabIndex = 2;
            this.DVbtn.Text = "Dependency Validator";
            this.DVbtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DVbtn.UseVisualStyleBackColor = false;
            this.DVbtn.Click += new System.EventHandler(this.DVbtn_Click);
            // 
            // RWbtn
            // 
            this.RWbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(14)))), ((int)(((byte)(75)))));
            this.RWbtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.RWbtn.FlatAppearance.BorderSize = 0;
            this.RWbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.RWbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.RWbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RWbtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.RWbtn.Location = new System.Drawing.Point(0, 0);
            this.RWbtn.Name = "RWbtn";
            this.RWbtn.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.RWbtn.Size = new System.Drawing.Size(250, 40);
            this.RWbtn.TabIndex = 0;
            this.RWbtn.Text = "Renewal Workflow";
            this.RWbtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RWbtn.UseVisualStyleBackColor = false;
            this.RWbtn.Click += new System.EventHandler(this.RWbtn_Click);
            // 
            // btncase
            // 
            this.btncase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(14)))), ((int)(((byte)(85)))));
            this.btncase.Dock = System.Windows.Forms.DockStyle.Top;
            this.btncase.FlatAppearance.BorderSize = 0;
            this.btncase.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btncase.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btncase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncase.ForeColor = System.Drawing.Color.Gainsboro;
            this.btncase.Image = global::visavault_g43.Properties.Resources.renewable;
            this.btncase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncase.Location = new System.Drawing.Point(0, 535);
            this.btncase.Name = "btncase";
            this.btncase.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btncase.Size = new System.Drawing.Size(250, 84);
            this.btncase.TabIndex = 8;
            this.btncase.Text = "                     Cases ";
            this.btncase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncase.UseVisualStyleBackColor = false;
            this.btncase.Click += new System.EventHandler(this.btncase_Click);
            // 
            // panelDocument
            // 
            this.panelDocument.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(14)))), ((int)(((byte)(75)))));
            this.panelDocument.Controls.Add(this.DMbtn);
            this.panelDocument.Controls.Add(this.DPbtn);
            this.panelDocument.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDocument.Location = new System.Drawing.Point(0, 438);
            this.panelDocument.Name = "panelDocument";
            this.panelDocument.Size = new System.Drawing.Size(250, 97);
            this.panelDocument.TabIndex = 7;
            // 
            // DMbtn
            // 
            this.DMbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(14)))), ((int)(((byte)(75)))));
            this.DMbtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.DMbtn.FlatAppearance.BorderSize = 0;
            this.DMbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.DMbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.DMbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DMbtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.DMbtn.Location = new System.Drawing.Point(0, 40);
            this.DMbtn.Name = "DMbtn";
            this.DMbtn.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.DMbtn.Size = new System.Drawing.Size(250, 40);
            this.DMbtn.TabIndex = 1;
            this.DMbtn.Text = "Document Management";
            this.DMbtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DMbtn.UseVisualStyleBackColor = false;
            this.DMbtn.Click += new System.EventHandler(this.DMbtn_Click);
            // 
            // DPbtn
            // 
            this.DPbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(14)))), ((int)(((byte)(75)))));
            this.DPbtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.DPbtn.FlatAppearance.BorderSize = 0;
            this.DPbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.DPbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.DPbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DPbtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.DPbtn.Location = new System.Drawing.Point(0, 0);
            this.DPbtn.Name = "DPbtn";
            this.DPbtn.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.DPbtn.Size = new System.Drawing.Size(250, 40);
            this.DPbtn.TabIndex = 0;
            this.DPbtn.Text = "Document Portfolio";
            this.DPbtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DPbtn.UseVisualStyleBackColor = false;
            this.DPbtn.Click += new System.EventHandler(this.DPbtn_Click);
            // 
            // Documentbtn
            // 
            this.Documentbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(14)))), ((int)(((byte)(85)))));
            this.Documentbtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Documentbtn.FlatAppearance.BorderSize = 0;
            this.Documentbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.Documentbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.Documentbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Documentbtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.Documentbtn.Image = global::visavault_g43.Properties.Resources.contract1;
            this.Documentbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Documentbtn.Location = new System.Drawing.Point(0, 354);
            this.Documentbtn.Name = "Documentbtn";
            this.Documentbtn.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.Documentbtn.Size = new System.Drawing.Size(250, 84);
            this.Documentbtn.TabIndex = 6;
            this.Documentbtn.Text = "                     Documents";
            this.Documentbtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Documentbtn.UseVisualStyleBackColor = false;
            this.Documentbtn.Click += new System.EventHandler(this.Documentbtn_Click);
            // 
            // panelClient
            // 
            this.panelClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(14)))), ((int)(((byte)(75)))));
            this.panelClient.Controls.Add(this.CMbtn);
            this.panelClient.Controls.Add(this.CRbtn);
            this.panelClient.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelClient.Location = new System.Drawing.Point(0, 257);
            this.panelClient.Name = "panelClient";
            this.panelClient.Size = new System.Drawing.Size(250, 97);
            this.panelClient.TabIndex = 4;
            // 
            // CMbtn
            // 
            this.CMbtn.BackColor = System.Drawing.Color.Transparent;
            this.CMbtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.CMbtn.FlatAppearance.BorderSize = 0;
            this.CMbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.CMbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.CMbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CMbtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.CMbtn.Location = new System.Drawing.Point(0, 40);
            this.CMbtn.Name = "CMbtn";
            this.CMbtn.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.CMbtn.Size = new System.Drawing.Size(250, 40);
            this.CMbtn.TabIndex = 1;
            this.CMbtn.Text = "Client Management";
            this.CMbtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CMbtn.UseVisualStyleBackColor = false;
            this.CMbtn.Click += new System.EventHandler(this.CMbtn_Click);
            // 
            // CRbtn
            // 
            this.CRbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(14)))), ((int)(((byte)(75)))));
            this.CRbtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.CRbtn.FlatAppearance.BorderSize = 0;
            this.CRbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.CRbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.CRbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CRbtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.CRbtn.Location = new System.Drawing.Point(0, 0);
            this.CRbtn.Name = "CRbtn";
            this.CRbtn.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.CRbtn.Size = new System.Drawing.Size(250, 40);
            this.CRbtn.TabIndex = 0;
            this.CRbtn.Text = "Client Registry";
            this.CRbtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CRbtn.UseVisualStyleBackColor = false;
            this.CRbtn.Click += new System.EventHandler(this.CRbtn_Click);
            // 
            // Clientbtn
            // 
            this.Clientbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(14)))), ((int)(((byte)(85)))));
            this.Clientbtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Clientbtn.FlatAppearance.BorderSize = 0;
            this.Clientbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.Clientbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.Clientbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Clientbtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.Clientbtn.Image = global::visavault_g43.Properties.Resources.user_avatar;
            this.Clientbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Clientbtn.Location = new System.Drawing.Point(0, 177);
            this.Clientbtn.Name = "Clientbtn";
            this.Clientbtn.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.Clientbtn.Size = new System.Drawing.Size(250, 80);
            this.Clientbtn.TabIndex = 3;
            this.Clientbtn.Text = "                     Clients";
            this.Clientbtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Clientbtn.UseVisualStyleBackColor = false;
            this.Clientbtn.Click += new System.EventHandler(this.Clientbtn_Click);
            // 
            // Homebtn
            // 
            this.Homebtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(14)))), ((int)(((byte)(85)))));
            this.Homebtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Homebtn.FlatAppearance.BorderSize = 0;
            this.Homebtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.Homebtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.Homebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Homebtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.Homebtn.Image = global::visavault_g43.Properties.Resources.home__2_;
            this.Homebtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Homebtn.Location = new System.Drawing.Point(0, 100);
            this.Homebtn.Name = "Homebtn";
            this.Homebtn.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.Homebtn.Size = new System.Drawing.Size(250, 77);
            this.Homebtn.TabIndex = 1;
            this.Homebtn.Text = "                     Home";
            this.Homebtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Homebtn.UseVisualStyleBackColor = false;
            this.Homebtn.Click += new System.EventHandler(this.Homebtn_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(14)))), ((int)(((byte)(85)))));
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(250, 100);
            this.panelLogo.TabIndex = 0;
            // 
            // Mainpanel
            // 
            this.Mainpanel.BackColor = System.Drawing.Color.White;
            this.Mainpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Mainpanel.Location = new System.Drawing.Point(250, 0);
            this.Mainpanel.Name = "Mainpanel";
            this.Mainpanel.Size = new System.Drawing.Size(1432, 1055);
            this.Mainpanel.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1682, 1055);
            this.Controls.Add(this.Mainpanel);
            this.Controls.Add(this.panelSideMenue);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "Form1";
            this.Text = "VisaVault";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelSideMenue.ResumeLayout(false);
            this.panelFinance.ResumeLayout(false);
            this.panelCases.ResumeLayout(false);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.panelDocument.ResumeLayout(false);
            this.panelClient.ResumeLayout(false);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuHome;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuViewClients;
        private System.Windows.Forms.ToolStripMenuItem menuViewDocuments;
        private System.Windows.Forms.ToolStripMenuItem menuViewCases;
        private System.Windows.Forms.ToolStripMenuItem menuViewInvoices;
        private System.Windows.Forms.ToolStripMenuItem menuViewReports;
        private System.Windows.Forms.ToolStripMenuItem menuViewAppointments;
        private System.Windows.Forms.ToolStripMenuItem menuViewExpiryAlerts;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
        private System.Windows.Forms.Panel panelSideMenue;
        private System.Windows.Forms.Button Homebtn;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Panel panelCases;
        private System.Windows.Forms.Button RWbtn;
        private System.Windows.Forms.Button btncase;
        private System.Windows.Forms.Panel panelDocument;
        private System.Windows.Forms.Button DMbtn;
        private System.Windows.Forms.Button DPbtn;
        private System.Windows.Forms.Button Documentbtn;
        private System.Windows.Forms.Panel panelClient;
        private System.Windows.Forms.Button CMbtn;
        private System.Windows.Forms.Button CRbtn;
        private System.Windows.Forms.Button Clientbtn;
        private System.Windows.Forms.Panel panelFinance;
        private System.Windows.Forms.Button RPbtn;
        private System.Windows.Forms.Button FCbtn;
        private System.Windows.Forms.Button Ibtn;
        private System.Windows.Forms.Button financebtn;
        private System.Windows.Forms.Button EAbtn;
        private System.Windows.Forms.Button appbtn;
        private System.Windows.Forms.Button DCbtn;
        private System.Windows.Forms.Button DVbtn;
        private System.Windows.Forms.Panel Mainpanel;
    }
}

