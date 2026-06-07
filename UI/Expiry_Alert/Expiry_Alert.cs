using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using visavault_g43.BLL;
using visavault_g43.Models;

namespace visavault_g43
{
    public partial class Expiry_Alert : Form
    {
        private Label lblCriticalCount;
        private Label lblExpiredCount;
        private Label lblWarningCount;
        private Label lblSafeCount;

        public Expiry_Alert()
        {
            InitializeComponent();
            this.Load += Expiry_Alert_Load;
        }

        private void Expiry_Alert_Load(object sender, EventArgs e)
        {
            lblCriticalCount = CreateCountLabel(panelCritical);
            lblExpiredCount = CreateCountLabel(panelExpired);
            lblWarningCount = CreateCountLabel(panelWarning);
            lblSafeCount = CreateCountLabel(panelSafe);

            LoadSummaryCards();
            LoadAlertGrid("All");
            panelCritical.Click += (s, ev) => LoadAlertGrid("Critical");
            panelExpired.Click += (s, ev) => LoadAlertGrid("Expired");
            panelWarning.Click += (s, ev) => LoadAlertGrid("Warning");
            panelSafe.Click += (s, ev) => LoadAlertGrid("Safe");
            lblCriticalCount.Click += (s, ev) => LoadAlertGrid("Critical");
            lblExpiredCount.Click += (s, ev) => LoadAlertGrid("Expired");
            lblWarningCount.Click += (s, ev) => LoadAlertGrid("Warning");
            lblSafeCount.Click += (s, ev) => LoadAlertGrid("Safe");
        }
        private Label CreateCountLabel(Panel parent)
        {
            Label lbl = new Label();
            lbl.AutoSize = false;
            lbl.Dock = DockStyle.Fill;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Font = new Font("Book Antiqua", 24f, FontStyle.Bold);
            lbl.ForeColor = Color.FromArgb(16, 68, 115);
            lbl.BackColor = Color.Transparent;
            lbl.Text = "0";
            lbl.Cursor = Cursors.Hand;
            parent.Controls.Add(lbl);
            return lbl;
        }
        private void LoadSummaryCards()
        {
            Dictionary<string, int> summary = AlertService.GetAlertSummary();

            lblCriticalCount.Text = summary.ContainsKey("Critical") ? summary["Critical"].ToString() : "0";
            lblExpiredCount.Text = summary.ContainsKey("Expired") ? summary["Expired"].ToString() : "0";
            lblWarningCount.Text = summary.ContainsKey("Warning") ? summary["Warning"].ToString() : "0";
            lblSafeCount.Text = summary.ContainsKey("Safe") ? summary["Safe"].ToString() : "0";
        }
        private string ResolveCountryName(int docClientId)
        {
            var client = ClientService.GetClientbyID(docClientId);
            if (client == null || client.CountryId <= 0) return "—";
            var country = AuthService.CachedCountries.FirstOrDefault(c => c.CountryId == client.CountryId);
            return country != null ? country.CountryName : "—";
        }
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
                var client = ClientService.GetClientbyID(doc.ClientId);
                dgvAlerts.Rows[row].Cells["colClient"].Value = client != null ? client.ClientName : $"Client {doc.ClientId}";
                var docType = AuthService.CachedDocumentTypes.FirstOrDefault(t => t.DocumentTypeId == doc.TypeID);
                dgvAlerts.Rows[row].Cells["colDocType"].Value = docType != null ? docType.DocumentTypeName : $"Type {doc.TypeID}";
                dgvAlerts.Rows[row].Cells["colExpiryDate"].Value = doc.ExpiryDate.ToString("dd-MMM-yyyy");
                dgvAlerts.Rows[row].Cells["colCountry"].Value = ResolveCountryName(doc.ClientId);
                dgvAlerts.Rows[row].Cells["colActionDays"].Value = actionDate.ToString("dd-MMM-yyyy");
                dgvAlerts.Rows[row].Cells["colDaysToAct"].Value = daysToAct;
                dgvAlerts.Rows[row].Cells["colAlertLevel"].Value = alertLevel;
                Color c = Color.White;
                if (alertLevel == "Expired") c = Color.FromArgb(220, 53, 69);
                if (alertLevel == "Critical") c = Color.FromArgb(255, 200, 180);
                if (alertLevel == "Warning") c = Color.FromArgb(255, 240, 180);
                if (alertLevel == "Safe") c = Color.FromArgb(200, 240, 200);

                dgvAlerts.Rows[row].Cells["colDaysToAct"].Style.BackColor = c;
                dgvAlerts.Rows[row].Cells["colAlertLevel"].Style.BackColor = c;

                if (alertLevel == "Expired")
                {
                    dgvAlerts.Rows[row].Cells["colDaysToAct"].Style.ForeColor = Color.White;
                    dgvAlerts.Rows[row].Cells["colAlertLevel"].Style.ForeColor = Color.White;
                }
            }
        }
    }
}