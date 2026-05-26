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
    public partial class Document_Portfolio : Form
    {
        private int clientId = 0;
        private int selectedDocumentId = 0;

        public Document_Portfolio()
        {
            InitializeComponent();
            this.Load += Document_Portfolio_Load;

            // FIX: Wire events that the Designer never registered
            dgvDocuments.SelectionChanged += dgvDocuments_SelectionChanged;
            btnSearch.Click += btnSearch_Click;
            btnClear.Click += btnClear_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
        }

        private void Document_Portfolio_Load(object sender, EventArgs e)
        {
            clientId = AuthService.CurrentClientId;
            LoadDocuments("");
        }

        private void LoadDocuments(string keyword)
        {
            List<Document> docs = string.IsNullOrWhiteSpace(keyword)
                ? DocumentService.GetDocumentsbyClientId(clientId)
                : DocumentService.SearchDocuments(clientId, keyword);

            dgvDocuments.Rows.Clear();

            foreach (var doc in docs)
            {
                string alertLevel = DocumentService.GetAlertLevel(doc);
                int daysLeft = DocumentService.GetDaystoAction(doc);
                string status = alertLevel == "Expired" ? "Expired" : "Active";

                int row = dgvDocuments.Rows.Add();
                dgvDocuments.Rows[row].Cells["colID"].Value = $"D-{doc.DocumentId:D3}";
                dgvDocuments.Rows[row].Cells["colType"].Value = doc.TypeID.ToString();
                dgvDocuments.Rows[row].Cells["colDocName"].Value = doc.DocumentNo;
                dgvDocuments.Rows[row].Cells["colCountry"].Value = "—";
                dgvDocuments.Rows[row].Cells["colIssueDate"].Value = doc.IssueDate.ToString("dd-MMM-yyyy");
                dgvDocuments.Rows[row].Cells["colExpiryDate"].Value = doc.ExpiryDate.ToString("dd-MMM-yyyy");
                dgvDocuments.Rows[row].Cells["colDaysLeft"].Value = daysLeft;
                dgvDocuments.Rows[row].Cells["colAlert"].Value = alertLevel;
                dgvDocuments.Rows[row].Cells["colStatus"].Value = status;

                // Color row by alert level
                Color c = Color.White;
                if (alertLevel == "Expired") c = Color.FromArgb(255, 200, 200);
                if (alertLevel == "Critical") c = Color.FromArgb(255, 220, 200);
                if (alertLevel == "Warning") c = Color.FromArgb(255, 255, 200);
                if (alertLevel == "Safe") c = Color.FromArgb(200, 255, 200);
                dgvDocuments.Rows[row].DefaultCellStyle.BackColor = c;

                dgvDocuments.Rows[row].Tag = doc.DocumentId;
            }
        }

        // FIX: Capture selected document ID whenever the row changes
        private void dgvDocuments_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDocuments.CurrentRow?.Tag != null)
                selectedDocumentId = (int)dgvDocuments.CurrentRow.Tag;
        }

        // btnSearch
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadDocuments(txtSearch.Text.Trim());
        }

        // btnClear
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            LoadDocuments("");
        }

        // btnEdit — opens Document_Manag in edit mode
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedDocumentId <= 0)
            {
                MessageBox.Show("Please select a document.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Document_Manag form = new Document_Manag(clientId, selectedDocumentId);
            form.ShowDialog();
            LoadDocuments("");
        }

        // btnDelete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedDocumentId <= 0)
            {
                MessageBox.Show("Please select a document.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                "Are you sure you want to delete this document?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            ValidationResult result = DocumentService.DeleteDocument(selectedDocumentId);
            MessageBox.Show(result.Message,
                result.IsValid ? "Deleted" : "Error",
                MessageBoxButtons.OK,
                result.IsValid ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            selectedDocumentId = 0;
            LoadDocuments("");
        }


    }
}
