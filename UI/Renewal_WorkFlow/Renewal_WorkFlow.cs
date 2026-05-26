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
    public partial class Renewal_WorkFlow : Form
    {
        private int selectedCaseId = 0;
        public Renewal_WorkFlow()
        {
            InitializeComponent();
        }
        private void Renewal_WorkFlow_Load(object sender, EventArgs e)
        {
            // cmbStatusFilter — the one dropdown on the form
            cmbStatusFilter.Items.Clear();
            cmbStatusFilter.Items.Add("All Cases");
            cmbStatusFilter.Items.Add("Active");
            cmbStatusFilter.Items.Add("Closed");
            cmbStatusFilter.SelectedIndex = 0;

            LoadCases("All");
        }

        private void LoadCases(string statusFilter)
        {
            List<RenewalCase> cases = RenewalService.GetAllCases(statusFilter);
            dgvCases.Rows.Clear();

            foreach (var rc in cases)
            {
                string stageName = GetStageName(rc.CurrentStageId);
                int daysInStage = (DateTime.Now - rc.UpdatedAt).Days;

                int row = dgvCases.Rows.Add();
                dgvCases.Rows[row].Cells["colCaseID"].Value = $"R-{rc.RenewalCaseID:D3}";
                dgvCases.Rows[row].Cells["colClient"].Value = $"Client {rc.UserId}";
                dgvCases.Rows[row].Cells["colDocument"].Value = $"Doc {rc.DocumentId}";
                dgvCases.Rows[row].Cells["colStage"].Value = stageName;
                dgvCases.Rows[row].Cells["colIssueDate"].Value = rc.CreatedAt.ToString("dd-MMM-yy");
                dgvCases.Rows[row].Cells["colOpened"].Value = rc.CreatedAt.ToString("dd-MMM-yy");
                dgvCases.Rows[row].Cells["colLastUpdate"].Value = rc.UpdatedAt.ToString("dd-MMM-yy");
                dgvCases.Rows[row].Cells["colDaysInStage"].Value = daysInStage;

                dgvCases.Rows[row].Tag = rc.RenewalCaseID;
            }
        }

        private string GetStageName(int stageId)
        {
            foreach (var s in AuthService.CachedStages)
                if (s.StageId == stageId) return s.StageName;
            return "Unknown";
        }

        // When a case row is selected, highlight the correct stage panel
        private void dgvCases_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCases.CurrentRow?.Tag == null) return;
            selectedCaseId = (int)dgvCases.CurrentRow.Tag;

            RenewalCase rc = RenewalService.GetCaseById(selectedCaseId);
            if (rc == null) return;

            string currentStage = GetStageName(rc.CurrentStageId);

            Color defaultColor = Color.FromArgb(100, 0, 60);
            Color activeColor = Color.SteelBlue;

            panelPending.BackColor = defaultColor;
            panelSubmitted.BackColor = defaultColor;
            panelUnderReview.BackColor = defaultColor;
            panelApprovedRejected.BackColor = defaultColor;

            if (currentStage == "Pending") panelPending.BackColor = activeColor;
            else if (currentStage == "Submitted") panelSubmitted.BackColor = activeColor;
            else if (currentStage == "Under Review") panelUnderReview.BackColor = activeColor;
            else if (currentStage == "Approved" || currentStage == "Rejected") panelApprovedRejected.BackColor = activeColor;
        }

        // btnSearch
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string filter = cmbStatusFilter.SelectedItem?.ToString() ?? "All Cases";
            if (filter == "All Cases") filter = "All";
            LoadCases(filter);
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
