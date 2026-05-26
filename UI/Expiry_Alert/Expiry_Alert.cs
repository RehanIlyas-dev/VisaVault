using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using visavault_g43.BLL;
using visavault_g43.Models;

namespace visavault_g43
{
    public partial class Expiry_Alert : Form
    {
        // Labels created at runtime to show counts inside each stat panel
        private Label lblCriticalCount;
        private Label lblExpiredCount;
        private Label lblWarningCount;
        private Label lblSafeCount;

        public Expiry_Alert()
        {
            InitializeComponent();

            // Wire Load event
            this.Load += Expiry_Alert_Load;
        }

        private void Expiry_Alert_Load(object sender, EventArgs e)
        {
            // Create a centered count Label inside each stat Panel
            lblCriticalCount = CreateCountLabel(panelCritical);
            lblExpiredCount = CreateCountLabel(panelExpired);
            lblWarningCount = CreateCountLabel(panelWarning);
            lblSafeCount = CreateCountLabel(panelSafe);

            LoadSummaryCards();
            LoadAlertGrid("All");

            // Clicking a panel filters the grid
            panelCritical.Click += (s, ev) => LoadAlertGrid("Critical");
            panelExpired.Click += (s, ev) => LoadAlertGrid("Expired");
            panelWarning.Click += (s, ev) => LoadAlertGrid("Warning");
            panelSafe.Click += (s, ev) => LoadAlertGrid("Safe");

            // Also allow clicking the count label itself to filter
            lblCriticalCount.Click += (s, ev) => LoadAlertGrid("Critical");
            lblExpiredCount.Click += (s, ev) => LoadAlertGrid("Expired");
            lblWarningCount.Click += (s, ev) => LoadAlertGrid("Warning");
            lblSafeCount.Click += (s, ev) => LoadAlertGrid("Safe");
        }

        // Creates a large centered Label inside a panel to display a number
        private Label CreateCountLabel(Panel parent)
        {
            Label lbl = new Label();
            lbl.AutoSize = false;
            lbl.Dock = DockStyle.Fill;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Font = new Font("Book Antiqua", 24f, FontStyle.Bold);
            lbl.ForeColor = Color.White;
            lbl.BackColor = Color.Transparent;
            lbl.Text = "0";
            lbl.Cursor = Cursors.Hand;
            parent.Controls.Add(lbl);
            return lbl;
        }

        // Update the count label inside each of the 4 stat panels
        private void LoadSummaryCards()
        {
            Dictionary<string, int> summary = AlertService.GetAlertSummary();

            lblCriticalCount.Text = summary.ContainsKey("Critical") ? summary["Critical"].ToString() : "0";
            lblExpiredCount.Text = summary.ContainsKey("Expired") ? summary["Expired"].ToString() : "0";
            lblWarningCount.Text = summary.ContainsKey("Warning") ? summary["Warning"].ToString() : "0";
            lblSafeCount.Text = summary.ContainsKey("Safe") ? summary["Safe"].ToString() : "0";
        }

        // Load documents filtered by alert level into the grid
        private void LoadAlertGrid(string filter)
        {
            List<Document> docs = AlertService.GetDocumentsbyAlertLevel(filter);
            dgvAlerts.Rows.Clear();

            foreach (var doc in docs)
            {
                string alertLevel = DocumentService.GetAlertLevel(doc);
                int daysToAct = DocumentService.GetDaystoAction(doc);
                DateTime actionDate = DocumentService.GetActionDate(doc);

                int row = dgvAlerts.Rows.Add();
                dgvAlerts.Rows[row].Cells["colClient"].Value = $"Client {doc.ClientId}";
                dgvAlerts.Rows[row].Cells["colDocType"].Value = $"Type {doc.TypeID}";
                dgvAlerts.Rows[row].Cells["colExpiryDate"].Value = doc.ExpiryDate.ToString("dd-MMM-yyyy");
                dgvAlerts.Rows[row].Cells["colCountry"].Value = "—";
                dgvAlerts.Rows[row].Cells["colActionDays"].Value = actionDate.ToString("dd-MMM-yyyy");
                dgvAlerts.Rows[row].Cells["colDaysToAct"].Value = daysToAct;
                dgvAlerts.Rows[row].Cells["colAlertLevel"].Value = alertLevel;

                // Color the Days to Act and Alert Level cells
                Color c = Color.White;
                if (alertLevel == "Expired") c = Color.Black;
                if (alertLevel == "Critical") c = Color.FromArgb(255, 200, 180);
                if (alertLevel == "Warning") c = Color.FromArgb(255, 240, 180);
                if (alertLevel == "Safe") c = Color.FromArgb(200, 240, 200);

                dgvAlerts.Rows[row].Cells["colDaysToAct"].Style.BackColor = c;
                dgvAlerts.Rows[row].Cells["colAlertLevel"].Style.BackColor = c;

                if (alertLevel == "Expired")
                    dgvAlerts.Rows[row].Cells["colDaysToAct"].Style.ForeColor = Color.White;
            }
        }
    }
}