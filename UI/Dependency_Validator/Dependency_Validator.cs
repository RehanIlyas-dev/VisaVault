using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisaVault.BLL;
using visavault_g43.BLL;
using visavault_g43.Models;

namespace visavault_g43
{
    public partial class Dependency_Validator : Form
    {
        private int selectedClientId = 0;
        private int selectedDocumentTypeId = 0;
        private bool allPrerequisitesMet = false;

        // Label placed inside the lblResults Panel to display text results
        private Label lblResultsText;

        public Dependency_Validator()
        {
            InitializeComponent();
            this.Load += Dependency_Validator_Load;
        }

        private void Dependency_Validator_Load(object sender, EventArgs e)
        {
            // Create a multiline Label inside the lblResults Panel
            lblResultsText = new Label();
            lblResultsText.AutoSize = false;
            lblResultsText.Dock = DockStyle.Fill;
            lblResultsText.ForeColor = Color.White;
            lblResultsText.BackColor = Color.Transparent;
            lblResultsText.Font = new Font("Segoe UI", 10f);
            lblResultsText.TextAlign = ContentAlignment.TopLeft;
            lblResultsText.Text = "";
            lblResults.Controls.Add(lblResultsText);

            // Wire button click events
            btnSearchClient.Click += btnSearchClient_Click;
            btnSearchDocument.Click += btnSearchDocument_Click;

            // Fill cmbSelectClient
            cmbSelectClient.Items.Clear();
            List<Client> clients = ClientService.GetClients();
            foreach (var c in clients)
                cmbSelectClient.Items.Add($"{c.ClientName} (C-{c.ClientId:D3})");

            // Fill cmbDocumentToRenew
            cmbDocumentToRenew.Items.Clear();
            foreach (var dt in AuthService.CachedDocumentTypes)
                cmbDocumentToRenew.Items.Add(dt.DocumentTypeName);

            // Pre-select client if context is set
            if (AuthService.CurrentClientId > 0)
            {
                for (int i = 0; i < clients.Count; i++)
                {
                    if (clients[i].ClientId == AuthService.CurrentClientId)
                    {
                        cmbSelectClient.SelectedIndex = i;
                        selectedClientId = AuthService.CurrentClientId;
                        break;
                    }
                }
            }
        }

        // btnSearchClient — confirms client selection
        private void btnSearchClient_Click(object sender, EventArgs e)
        {
            if (cmbSelectClient.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a client.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            selectedClientId = GetClientIdFromCombo();
            AuthService.SetClientContext(selectedClientId);
            lblResultsText.Text = "Client confirmed. Now select a document type and click Search.";
        }

        // btnSearchDocument — runs the dependency check and shows results in lblResultsText
        private void btnSearchDocument_Click(object sender, EventArgs e)
        {
            if (selectedClientId <= 0)
            {
                MessageBox.Show("Please select a client first.", "No Client",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbDocumentToRenew.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a document type.", "No Document",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            selectedDocumentTypeId =
                AuthService.CachedDocumentTypes[cmbDocumentToRenew.SelectedIndex].DocumentTypeId;

            List<DependencyCheckResult> results =
                DependencyService.RunDependencyCheck(selectedClientId, selectedDocumentTypeId);

            if (results.Count == 0)
            {
                lblResultsText.Text = "No prerequisites required for this document type.\r\n\r\nResult: Renewal case can be opened.";
                allPrerequisitesMet = true;
            }
            else
            {
                allPrerequisitesMet = true;
                string output = "";

                foreach (var r in results)
                {
                    string icon = r.IsValid ? "✔" : (r.Exists ? "!" : "✘");
                    output += $"{icon}  {r.RequiredDocumentType}  —  {r.Status}\r\n";
                    if (!r.IsValid) allPrerequisitesMet = false;
                }

                output += allPrerequisitesMet
                    ? "\r\nResult: Prerequisites met. Case can be opened."
                    : "\r\nResult: Prerequisites NOT met. Fix issues first.";

                lblResultsText.Text = output;
            }

            // If all prerequisites met, ask user to open case
            if (allPrerequisitesMet)
            {
                var confirm = MessageBox.Show(
                    "All prerequisites met. Open renewal case now?",
                    "Open Case", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                    OpenRenewalCase();
            }
        }

        private void OpenRenewalCase()
        {
            // Find a document of the selected type for this client
            List<Document> docs = DocumentService.GetDocumentsbyClientId(selectedClientId);
            int documentId = 0;
            foreach (var d in docs)
                if (d.TypeID == selectedDocumentTypeId) { documentId = d.DocumentId; break; }

            if (documentId <= 0)
            {
                MessageBox.Show("No document found of this type for the client.", "Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ValidationResult result = RenewalService.OpenCase(
                selectedClientId, documentId, AuthService.CurrentUserId);

            MessageBox.Show(result.Message,
                result.IsValid ? "Case Opened" : "Error",
                MessageBoxButtons.OK,
                result.IsValid ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            if (result.IsValid)
            {
                Form1 main = this.ParentForm as Form1;
                if (main != null) main.fromload(new Renewal_WorkFlow());
            }
        }

        // Helper: extract client ID from "Name (C-001)" combo text
        private int GetClientIdFromCombo()
        {
            string item = cmbSelectClient.SelectedItem?.ToString() ?? "";
            int start = item.IndexOf("C-") + 2;
            int end = item.IndexOf(")", start);
            if (start > 1 && end > start)
                if (int.TryParse(item.Substring(start, end - start), out int id)) return id;
            return 0;
        }


    }
}
