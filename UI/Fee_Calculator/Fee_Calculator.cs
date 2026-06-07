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
    public partial class Fee_Calculator : Form
    {
        public Fee_Calculator()
        {
            InitializeComponent();
        }
        private void Fee_Calculator_Load(object sender, EventArgs e)
        {
            cmbCountry.Items.Clear();
            foreach (var c in AuthService.CachedCountries)
                cmbCountry.Items.Add(c.CountryName);
            cmbDocumentType.Items.Clear();
            foreach (var dt in AuthService.CachedDocumentTypes)
                cmbDocumentType.Items.Add(dt.DocumentTypeName);
            dgvFeeBreakdown.Rows.Clear();
        }
        private void btnCalculateFee_Click(object sender, EventArgs e)
        {
            if (cmbCountry.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a country.", "Missing",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbDocumentType.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a document type.", "Missing",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int countryId = AuthService.CachedCountries[cmbCountry.SelectedIndex].CountryId;
            int documentTypeId = AuthService.CachedDocumentTypes[cmbDocumentType.SelectedIndex].DocumentTypeId;
            FeeBreakdown breakdown = FeeService.CalculateFee(countryId, documentTypeId, false);
            dgvFeeBreakdown.Rows.Clear();
            if (!breakdown.IsActive)
            {
                MessageBox.Show(
                    "No fee rule found for this combination. Contact administrator.",
                    "No Rule Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            AddFeeRow("Base Fee", "Service", breakdown.BaseFee);
            AddFeeRow("Processing Fee", "Government", breakdown.ProcessingFee);
            if (breakdown.UrgencyFee > 0)
                AddFeeRow("Urgency Fee", "Surcharge", breakdown.UrgencyFee);
            int totalRow = dgvFeeBreakdown.Rows.Add();
            dgvFeeBreakdown.Rows[totalRow].Cells["colComponent"].Value = "TOTAL";
            dgvFeeBreakdown.Rows[totalRow].Cells["colType"].Value = "";
            dgvFeeBreakdown.Rows[totalRow].Cells["colAmount"].Value = $"Rs {breakdown.TotalFee:N0}";
            dgvFeeBreakdown.Rows[totalRow].DefaultCellStyle.Font =
                new Font(dgvFeeBreakdown.Font, FontStyle.Bold);
        }
        private void AddFeeRow(string component, string type, decimal amount)
        {
            int row = dgvFeeBreakdown.Rows.Add();
            dgvFeeBreakdown.Rows[row].Cells["colComponent"].Value = component;
            dgvFeeBreakdown.Rows[row].Cells["colType"].Value = type;
            dgvFeeBreakdown.Rows[row].Cells["colAmount"].Value = $"Rs {amount:N0}";
        }
    }
}
