using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using visavault_g43.BLL;
using visavault_g43.Models;
namespace visavault_g43
{
    public partial class Renewal_WorkFlow : Form
    {
        private int selectedCaseId = 0;
        public Renewal_WorkFlow()
        {
            InitializeComponent();
            this.Load += Renewal_WorkFlow_Load;
            dgvCases.SelectionChanged += dgvCases_SelectionChanged;
            dgvCases.CellContentClick += dgvCases_CellContentClick;
            btnSearch.Click += btnSearch_Click;
            button2.Click += button2_Click;
        }
        private void Renewal_WorkFlow_Load(object sender, EventArgs e)
        {
            cmbStatusFilter.Items.Clear();
            cmbStatusFilter.Items.Add("All Cases");
            cmbStatusFilter.Items.Add("Active");
            cmbStatusFilter.Items.Add("Closed");
            cmbStatusFilter.SelectedIndex = 0;
            LoadCases("All");
        }
      
       private void LoadCases(string statusFilter)   {
            List<RenewalCase> cases = RenewalService.GetAllCases(statusFilter);
            dgvCases.Rows.Clear();
            foreach (var rc in cases)
            {
                string stageName = GetStageName(rc.CurrentStageId);
                int daysInStage = (DateTime.Now - rc.UpdatedAt).Days;
                int row = dgvCases.Rows.Add();
                dgvCases.Rows[row].Cells["colCaseID"].Value = $"R-{rc.RenewalCaseID:D3}";
                var client = ClientService.GetClientbyID(rc.ClientId);
                dgvCases.Rows[row].Cells["colClient"].Value = client != null ? client.ClientName : $"Client {rc.ClientId}";
                var doc = DocumentService.GetDocumentbyId(rc.DocumentId);
                dgvCases.Rows[row].Cells["colDocument"].Value = doc != null ? doc.DocumentNo : $"Doc {rc.DocumentId}";
                dgvCases.Rows[row].Cells["colStage"].Value = stageName;
                dgvCases.Rows[row].Cells["colIssueDate"].Value = rc.CreatedAt.ToString("dd-MMM-yy");
                dgvCases.Rows[row].Cells["colOpened"].Value = rc.CreatedAt.ToString("dd-MMM-yy");
                dgvCases.Rows[row].Cells["colLastUpdate"].Value = rc.UpdatedAt.ToString("dd-MMM-yy");
                dgvCases.Rows[row].Cells["colDaysinStage"].Value = daysInStage;
                dgvCases.Rows[row].Tag = rc.RenewalCaseID;
            }

            if (dgvCases.Rows.Count > 0)
            {
                dgvCases.ClearSelection();
                dgvCases.Rows[0].Selected = true;
                selectedCaseId = (int)dgvCases.Rows[0].Tag;
                dgvCases_SelectionChanged(dgvCases, EventArgs.Empty);
            }
            else
            {
                panelPending.BackColor = Color.FromArgb(230, 230, 230);
                panelSubmitted.BackColor = Color.FromArgb(230, 230, 230);
                panelUnderReview.BackColor = Color.FromArgb(230, 230, 230);
                panelApprovedRejected.BackColor = Color.FromArgb(230, 230, 230);
            }
        }
        private string GetStageName(int stageId)
        {
            foreach (var s in AuthService.CachedStages)
                if (s.StageId == stageId) return s.StageName;
            return "Unknown";
        }
        private void dgvCases_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCases.CurrentRow?.Tag == null) return;
            selectedCaseId = (int)dgvCases.CurrentRow.Tag;
            RenewalCase rc = RenewalService.GetCaseById(selectedCaseId);
            if (rc == null) return;
            string currentStage = GetStageName(rc.CurrentStageId);
            Color defaultColor = Color.FromArgb(230, 230, 230); // Light Gray
            Color activeColor = Color.FromArgb(16, 68, 115); // Navy Blue
            panelPending.BackColor = defaultColor;
            panelSubmitted.BackColor = defaultColor;
            panelUnderReview.BackColor = defaultColor;
            panelApprovedRejected.BackColor = defaultColor;
            if (currentStage.Equals("Pending", StringComparison.OrdinalIgnoreCase))
                panelPending.BackColor = activeColor;
            else if (currentStage.Equals("Submitted", StringComparison.OrdinalIgnoreCase))
                panelSubmitted.BackColor = activeColor;
            else if (currentStage.Equals("Under_Review", StringComparison.OrdinalIgnoreCase) ||
                     currentStage.Equals("Under Review", StringComparison.OrdinalIgnoreCase))
                panelUnderReview.BackColor = activeColor;
            else if (currentStage.Equals("Accepted", StringComparison.OrdinalIgnoreCase) ||
                     currentStage.Equals("Rejected", StringComparison.OrdinalIgnoreCase) ||
                     currentStage.Equals("Approved / Rejected", StringComparison.OrdinalIgnoreCase) ||
                     currentStage.Equals("Approved/Rejected", StringComparison.OrdinalIgnoreCase))
                panelApprovedRejected.BackColor = activeColor;
        }
        private void dgvCases_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex == dgvCases.Columns["colViewDetails"].Index)
            {
                if (dgvCases.Rows[e.RowIndex].Tag == null) return;
                int caseId = (int)dgvCases.Rows[e.RowIndex].Tag;
                RenewalCase rc = RenewalService.GetCaseById(caseId);
                if (rc == null) return;
                var client = ClientService.GetClientbyID(rc.ClientId);
                var docs = RenewalService.GetCaseDocuments(caseId);
                var doc = docs.FirstOrDefault();
                string clientName = client != null ? client.ClientName : "N/A";
                string cnic = client != null ? client.CnicNo : "N/A";
                string docNo = doc != null ? doc.DocumentNo : "N/A";
                string expiry = doc != null ? doc.ExpiryDate.ToString("dd-MMM-yyyy") : "N/A";
                var logs = RenewalService.GetStageLog(caseId);
                StringBuilder logBuilder = new StringBuilder();
                if (logs != null && logs.Count > 0)
                {
                    foreach (var log in logs)
                    {
                        string stageName = GetStageName(log.CurrentStageId);
                        logBuilder.AppendLine($"- {log.UpdatedAt:dd-MMM-yyyy HH:mm} | Stage: {stageName} | Remarks: {log.Remarks}");
                    }
                }
                else
                {
                    logBuilder.AppendLine("No stage log history found.");
                }
                MessageBox.Show(
                    $"=== Renewal Case Details ===\n" +
                    $"Case ID: R-{rc.RenewalCaseID:D3}\n" +
                    $"Client: {clientName} (CNIC: {cnic})\n" +
                    $"Document: {docNo} (Expires: {expiry})\n" +
                    $"Current Stage: {GetStageName(rc.CurrentStageId)}\n" +
                    $"Opened On: {rc.CreatedAt:dd-MMM-yyyy}\n" +
                    $"Last Updated: {rc.UpdatedAt:dd-MMM-yyyy}\n\n" +
                    $"=== Stage History Log ===\n" +
                    $"{logBuilder.ToString()}",
                    "Renewal Case Details",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            if (e.ColumnIndex == dgvCases.Columns["colAdvanceStage"].Index)
            {
                if (dgvCases.Rows[e.RowIndex].Tag == null) return;
                int caseId = (int)dgvCases.Rows[e.RowIndex].Tag;
                RenewalCase rc = RenewalService.GetCaseById(caseId);
                if (rc == null) return;
                var stages = RenewalService.GetAllStages();
                if (stages == null || stages.Count == 0)
                {
                    MessageBox.Show("No stages configured in the system.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var currentStage = stages.FirstOrDefault(s => s.StageId == rc.CurrentStageId);
                if (currentStage == null)
                {
                    MessageBox.Show("Current stage not recognized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int currentStageNo = currentStage.StageNo;
                var nextStage = stages.OrderBy(s => s.StageNo).FirstOrDefault(s => s.StageNo > currentStageNo);
                if (nextStage == null)
                {
                    MessageBox.Show("Case is already at the final stage.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DialogResult dialogResult = MessageBox.Show(
                    $"Are you sure you want to advance this case from '{currentStage.StageName}' to '{nextStage.StageName}'?",
                    "Advance Stage",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (dialogResult == DialogResult.Yes)
                {
                    int userId = AuthService.CurrentUserId > 0 ? AuthService.CurrentUserId : 1;
                    string remarks = $"Advanced from dashboard by user ID {userId}";
                    var result = RenewalService.AdvanceStage(caseId, nextStage.StageId, userId, remarks);
                    if (result.IsValid)
                    {
                        MessageBox.Show($"Case advanced to '{nextStage.StageName}' successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        string filter = cmbStatusFilter.SelectedItem?.ToString() ?? "All Cases";
                        if (filter == "All Cases") filter = "All";
                        LoadCases(filter);
                    }
                    else
                    {
                        MessageBox.Show($"Failed to advance case: {result.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string filter = cmbStatusFilter.SelectedItem?.ToString() ?? "All Cases";
            if (filter == "All Cases") filter = "All";
            LoadCases(filter);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            cmbStatusFilter.SelectedIndex = 0;
            LoadCases("All");
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
