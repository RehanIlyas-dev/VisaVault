using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using visavault_g43.BLL;
using visavault_g43.Models;

namespace visavault_g43
{
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
            this.Load += ReportsForm_Load;
            cmbReportType.SelectedIndexChanged += cmbReportType_SelectedIndexChanged;
            btnGenerate.Click += btnGenerate_Click;
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            cmbReportType.Items.Clear();
            cmbReportType.Items.Add("1. Client Registry Report");
            cmbReportType.Items.Add("2. Active Visa Renewal Cases");
            cmbReportType.Items.Add("3. Expiring Client Documents");
            cmbReportType.Items.Add("4. Accounts Receivable (Invoices)");
            cmbReportType.Items.Add("5. Revenue Collection Summary");
            cmbReportType.Items.Add("6. Appointment Daily Manifest");
            cmbReportType.Items.Add("7. Fee Rule Rates Chart");
            cmbReportType.Items.Add("8. Document Type Dependencies Map");
            cmbReportType.Items.Add("9. System Audit Log History");
            cmbReportType.Items.Add("10. Case Processing Timeline");
            cmbReportType.SelectedIndex = 0;
            cmbCountry.Items.Clear();
            cmbCountry.Items.Add("All Countries");
            foreach (var country in AuthService.CachedCountries)
            {
                cmbCountry.Items.Add(country.CountryName);
            }
            cmbCountry.SelectedIndex = 0;
            cmbStage.Items.Clear();
            cmbStage.Items.Add("All Stages");
            foreach (var stage in AuthService.CachedStages)
            {
                cmbStage.Items.Add(stage.StageName);
            }
            cmbStage.SelectedIndex = 0;
            dtpStart.Value = DateTime.Today.AddMonths(-1);
            dtpEnd.Value = DateTime.Today;
            dtpSingleDate.Value = DateTime.Today;

            HideAllParams();
            ShowParamsForIndex(0);
        }

        private void cmbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            HideAllParams();
            ShowParamsForIndex(cmbReportType.SelectedIndex);
        }

        private void HideAllParams()
        {
            lblStatus.Visible = false;
            cmbStatus.Visible = false;
            
            lblCountry.Visible = false;
            cmbCountry.Visible = false;

            lblStage.Visible = false;
            cmbStage.Visible = false;

            lblDays.Visible = false;
            nudDays.Visible = false;

            lblDateRange.Visible = false;
            dtpStart.Visible = false;
            lblTo.Visible = false;
            dtpEnd.Visible = false;

            lblSingleDate.Visible = false;
            dtpSingleDate.Visible = false;

            lblCaseId.Visible = false;
            txtCaseId.Visible = false;
        }

        private void ShowParamsForIndex(int index)
        {
            switch (index)
            {
                case 0: // Client Registry
                    lblStatus.Visible = true;
                    cmbStatus.Visible = true;
                    cmbStatus.Items.Clear();
                    cmbStatus.Items.Add("All");
                    cmbStatus.Items.Add("active");
                    cmbStatus.Items.Add("inactive");
                    cmbStatus.SelectedIndex = 0;

                    lblCountry.Visible = true;
                    cmbCountry.Visible = true;
                    break;

                case 1: // Active Renewal Cases
                    lblStage.Visible = true;
                    cmbStage.Visible = true;
                    break;

                case 2: // Expiring Documents
                    lblDays.Visible = true;
                    nudDays.Visible = true;
                    nudDays.Value = 90;
                    break;

                case 3: // Accounts Receivable
                    lblStatus.Visible = true;
                    cmbStatus.Visible = true;
                    cmbStatus.Items.Clear();
                    cmbStatus.Items.Add("All");
                    cmbStatus.Items.Add("Unpaid");
                    cmbStatus.Items.Add("Paid");
                    cmbStatus.Items.Add("Partially Paid");
                    cmbStatus.Items.Add("Cancelled");
                    cmbStatus.Items.Add("Overdue");
                    cmbStatus.SelectedIndex = 0;
                    break;

                case 4: // Revenue Summary
                    lblDateRange.Visible = true;
                    dtpStart.Visible = true;
                    lblTo.Visible = true;
                    dtpEnd.Visible = true;
                    break;

                case 5: // Daily Appointments Manifest
                    lblSingleDate.Visible = true;
                    dtpSingleDate.Visible = true;
                    break;

                case 6: // Fee Rates Chart
                    lblCountry.Visible = true;
                    cmbCountry.Visible = true;
                    break;

                case 7: // Document dependencies
                    break;

                case 8: // System Audit Log History
                    lblStatus.Visible = true;
                    cmbStatus.Visible = true;
                    cmbStatus.Items.Clear();
                    cmbStatus.Items.Add("All");
                    cmbStatus.Items.Add("INSERT");
                    cmbStatus.Items.Add("UPDATE");
                    cmbStatus.Items.Add("DELETE");
                    cmbStatus.SelectedIndex = 0;
                    break;

                case 9: // Case Timeline
                    lblCaseId.Visible = true;
                    txtCaseId.Visible = true;
                    txtCaseId.Text = "1";
                    break;
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int index = cmbReportType.SelectedIndex;
            if (index < 0) return;

            string defaultFileName = cmbReportType.Text.Substring(3).Replace(" ", "_") + "_" + DateTime.Today.ToString("yyyyMMdd") + ".pdf";

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF Files (*.pdf)|*.pdf";
            sfd.FileName = defaultFileName;
            sfd.Title = "Save Generated PDF Report";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string destPath = sfd.FileName;
                try
                {
                    GeneratePdf(index, destPath);
                    MessageBox.Show("Report successfully generated and saved to:\n" + destPath, "Report Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while generating the report:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void GeneratePdf(int index, string destPath)
        {
            switch (index)
            {
                case 0: // Client Registry
                    string cStatus = cmbStatus.Text;
                    int countryId = 0;
                    if (cmbCountry.SelectedIndex > 0)
                    {
                        countryId = AuthService.CachedCountries[cmbCountry.SelectedIndex - 1].CountryId;
                    }
                    ReportService.GenerateClientRegistryReport(destPath, cStatus, countryId);
                    break;

                case 1: // Active Renewal Cases
                    int stageId = 0;
                    if (cmbStage.SelectedIndex > 0)
                    {
                        stageId = AuthService.CachedStages[cmbStage.SelectedIndex - 1].StageId;
                    }
                    ReportService.GenerateActiveRenewalsReport(destPath, stageId);
                    break;

                case 2: // Expiring Documents
                    int days = (int)nudDays.Value;
                    ReportService.GenerateExpiringDocumentsReport(destPath, days);
                    break;

                case 3: // Accounts Receivable
                    string invStatus = cmbStatus.Text;
                    ReportService.GenerateAccountsReceivableReport(destPath, invStatus);
                    break;

                case 4: // Revenue Summary
                    ReportService.GenerateRevenueCollectionReport(destPath, dtpStart.Value, dtpEnd.Value);
                    break;

                case 5: // Daily Appointments Manifest
                    ReportService.GenerateDailyAppointmentsReport(destPath, dtpSingleDate.Value);
                    break;

                case 6: // Fee Rates Chart
                    int fCountryId = 0;
                    if (cmbCountry.SelectedIndex > 0)
                    {
                        fCountryId = AuthService.CachedCountries[cmbCountry.SelectedIndex - 1].CountryId;
                    }
                    ReportService.GenerateFeeRatesReport(destPath, fCountryId);
                    break;

                case 7: // Document dependencies
                    ReportService.GenerateDependenciesReport(destPath);
                    break;

                case 8: // System Audit Log History
                    string actionFilter = cmbStatus.Text;
                    ReportService.GenerateAuditLogsReport(destPath, actionFilter);
                    break;

                case 9: // Case Timeline
                    if (!int.TryParse(txtCaseId.Text, out int caseId) || caseId <= 0)
                    {
                        throw new ArgumentException("Please enter a valid numeric Case reference ID.");
                    }
                    ReportService.GenerateCaseTimelineReport(destPath, caseId);
                    break;
            }
        }
    }
}
