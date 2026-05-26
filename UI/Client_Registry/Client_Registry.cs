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
    public partial class Client_Registry : Form
    {
        private int selectedClientId = 0;

        public Client_Registry()
        {
            InitializeComponent();
            this.Load += Client_Registry_Load;

            // FIX: Wire events that the Designer never registered
            dgvClients.SelectionChanged += dgvClients_SelectionChanged;
            btnSearch.Click += btnSearch_Click;
            btnClear.Click += btnClear_Click;
            btnViewEdit.Click += btnViewEdit_Click;
            btnChangeStatus.Click += btnChangeStatus_Click;
            btnViewDocuments.Click += btnViewDocuments_Click;
            btnOpenRenewalCase.Click += btnOpenRenewalCase_Click;
        }

        private void Client_Registry_Load(object sender, EventArgs e)
        {
            cmbStatusFilter.Items.Clear();
            cmbStatusFilter.Items.Add("All Status");
            cmbStatusFilter.Items.Add("Active");
            cmbStatusFilter.Items.Add("Inactive");
            cmbStatusFilter.Items.Add("Blacklisted");
            cmbStatusFilter.SelectedIndex = 0;

            LoadClients("", "All Status");
        }

        private void LoadClients(string keyword, string statusFilter)
        {
            List<Client> clients = ClientService.SearchClient(keyword, statusFilter);
            dgvClients.Rows.Clear();

            foreach (var c in clients)
            {
                int docCount = DocumentService.GetDocumentsbyClientId(c.ClientId).Count;

                int row = dgvClients.Rows.Add();
                dgvClients.Rows[row].Cells["colID"].Value = $"C-{c.ClientId:D3}";
                dgvClients.Rows[row].Cells["colName"].Value = c.ClientName;
                dgvClients.Rows[row].Cells["colCNIC"].Value = c.CnicNo;
                dgvClients.Rows[row].Cells["colPhone"].Value = c.ContactNo;
                dgvClients.Rows[row].Cells["colStatus"].Value = c.Status;
                dgvClients.Rows[row].Cells["colDocs"].Value = docCount;
                dgvClients.Rows[row].Cells["colCreated"].Value = c.CreatedAt.ToString("dd-MMM-yyyy");

                // Color row by status
                if (c.Status == "Inactive")
                    dgvClients.Rows[row].DefaultCellStyle.BackColor = Color.LightYellow;
                if (c.Status == "Blacklisted")
                    dgvClients.Rows[row].DefaultCellStyle.BackColor = Color.MistyRose;

                // Tag stores the real client ID
                dgvClients.Rows[row].Tag = c.ClientId;
            }
        }

        // FIX: Capture selected client ID whenever the row changes
        private void dgvClients_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClients.CurrentRow?.Tag != null)
                selectedClientId = (int)dgvClients.CurrentRow.Tag;
        }

        // btnSearch
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadClients(txtSearch.Text.Trim(),
                cmbStatusFilter.SelectedItem?.ToString() ?? "All Status");
        }

        // btnClear
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            cmbStatusFilter.SelectedIndex = 0;
            LoadClients("", "All Status");
        }

        // btnViewEdit — opens Client_Management in edit mode
        private void btnViewEdit_Click(object sender, EventArgs e)
        {
            if (selectedClientId <= 0)
            {
                MessageBox.Show("Please select a client first.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Client_Management form = new Client_Management(selectedClientId);
            form.ShowDialog();
            LoadClients("", "All Status");
        }

        // btnViewDocuments — navigates to Document Portfolio
        private void btnViewDocuments_Click(object sender, EventArgs e)
        {
            if (selectedClientId <= 0)
            {
                MessageBox.Show("Please select a client first.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            AuthService.SetClientContext(selectedClientId);
            Form1 main = this.ParentForm as Form1;
            if (main != null) main.fromload(new Document_Portfolio());
        }

        // btnOpenRenewalCase — navigates to Dependency Validator
        private void btnOpenRenewalCase_Click(object sender, EventArgs e)
        {
            if (selectedClientId <= 0)
            {
                MessageBox.Show("Please select a client first.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            AuthService.SetClientContext(selectedClientId);
            Form1 main = this.ParentForm as Form1;
            if (main != null) main.fromload(new Dependency_Validator());
        }

        // btnChangeStatus
        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            if (selectedClientId <= 0)
            {
                MessageBox.Show("Please select a client first.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string newStatus = ShowStatusDialog();
            if (string.IsNullOrWhiteSpace(newStatus)) return;

            ValidationResult result = ClientService.ChangeClientStatus(selectedClientId, newStatus);
            MessageBox.Show(result.Message,
                result.IsValid ? "Success" : "Error",
                MessageBoxButtons.OK,
                result.IsValid ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            LoadClients("", "All Status");
        }

        private string ShowStatusDialog()
        {
            Form dialog = new Form();
            dialog.Text = "Change Status";
            dialog.Size = new System.Drawing.Size(300, 150);
            dialog.StartPosition = FormStartPosition.CenterParent;

            ComboBox cmb = new ComboBox();
            cmb.Items.Add("Active");
            cmb.Items.Add("Inactive");
            cmb.Items.Add("Blacklisted");
            cmb.SelectedIndex = 0;
            cmb.Location = new System.Drawing.Point(20, 20);
            cmb.Width = 240;

            Button btnOk = new Button();
            btnOk.Text = "OK";
            btnOk.Location = new System.Drawing.Point(100, 60);
            btnOk.DialogResult = DialogResult.OK;

            dialog.Controls.Add(cmb);
            dialog.Controls.Add(btnOk);
            dialog.AcceptButton = btnOk;

            if (dialog.ShowDialog() == DialogResult.OK)
                return cmb.SelectedItem?.ToString() ?? "";

            return "";
        }
    }
}
