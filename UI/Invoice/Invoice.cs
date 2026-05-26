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
    public partial class Invoice : Form
    {
        private int selectedInvoiceId = 0;

        public Invoice()
        {
            InitializeComponent();
            this.Load += Invoice_Load;

            // FIX: Wire events that the Designer never registered
            dgvInvoices.SelectionChanged += dgvInvoices_SelectionChanged;
            btnSearch.Click += btnSearch_Click;
        }

        private void Invoice_Load(object sender, EventArgs e)
        {
            // cmbClientFilter — first dropdown
            cmbClientFilter.Items.Clear();
            cmbClientFilter.Items.Add("All Clients");
            foreach (var c in ClientService.GetClients())
                cmbClientFilter.Items.Add($"{c.ClientName} (C-{c.ClientId:D3})");
            cmbClientFilter.SelectedIndex = 0;

            // cmbStatusFilter — second dropdown
            cmbStatusFilter.Items.Clear();
            cmbStatusFilter.Items.Add("All Status");
            cmbStatusFilter.Items.Add("Unpaid");
            cmbStatusFilter.Items.Add("Partially Paid");
            cmbStatusFilter.Items.Add("Paid");
            cmbStatusFilter.Items.Add("Overdue");
            cmbStatusFilter.SelectedIndex = 0;

            LoadInvoices();
        }

        private void LoadInvoices()
        {
            int clientId = GetSelectedClientId();
            string status = cmbStatusFilter.SelectedItem?.ToString() ?? "All Status";
            if (status == "All Status") status = "All";

            List<visavault_g43.Models.Invoice> invoices =
                InvoiceService.GetAllInvoices(clientId, status);
            dgvInvoices.Rows.Clear();

            foreach (var inv in invoices)
            {
                decimal paid = inv.Amount - InvoiceService.GetBalance(inv.InvoiceID);
                decimal balance = InvoiceService.GetBalance(inv.InvoiceID);

                int row = dgvInvoices.Rows.Add();
                dgvInvoices.Rows[row].Cells["colInvoiceID"].Value = $"INV-{inv.InvoiceID:D3}";
                dgvInvoices.Rows[row].Cells["colClient"].Value = $"Client {inv.ClientId}";
                dgvInvoices.Rows[row].Cells["colCase"].Value = $"R-{inv.CaseId:D3}";
                dgvInvoices.Rows[row].Cells["colTotal"].Value = $"Rs {inv.Amount:N0}";
                dgvInvoices.Rows[row].Cells["colPaid"].Value = $"Rs {paid:N0}";
                dgvInvoices.Rows[row].Cells["colBalance"].Value = $"Rs {balance:N0}";
                dgvInvoices.Rows[row].Cells["colStatus"].Value = inv.Status;
                dgvInvoices.Rows[row].Cells["colCreated"].Value = inv.CreatedAt.ToString("dd-MMM-yy");

                // Color row by status
                Color c = Color.White;
                if (inv.Status == "Paid") c = Color.FromArgb(200, 255, 200);
                if (inv.Status == "Partially Paid") c = Color.FromArgb(255, 255, 200);
                if (inv.Status == "Overdue") c = Color.FromArgb(255, 200, 180);
                dgvInvoices.Rows[row].DefaultCellStyle.BackColor = c;

                dgvInvoices.Rows[row].Tag = inv.InvoiceID;
            }
        }

        // FIX: Capture selected invoice ID and load its line items when row changes
        private void dgvInvoices_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvInvoices.CurrentRow?.Tag == null) return;
            selectedInvoiceId = (int)dgvInvoices.CurrentRow.Tag;
            LoadLineItems(selectedInvoiceId);
        }

        private void LoadLineItems(int invoiceId)
        {
            List<InvoiceLineItem> items = InvoiceService.GetLineItems(invoiceId);
            dgvLineItems.Rows.Clear();
            int lineNo = 1;

            foreach (var item in items)
            {
                int row = dgvLineItems.Rows.Add();
                dgvLineItems.Rows[row].Cells["colLine"].Value = lineNo++;
                dgvLineItems.Rows[row].Cells["colDescription"].Value = $"Fee Rule {item.FeeId}";
                dgvLineItems.Rows[row].Cells["colFeeType"].Value = "Service";
                dgvLineItems.Rows[row].Cells["colAmount"].Value = $"Rs {item.TotalPrice:N0}";
            }
        }

        // btnSearch
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadInvoices();
        }

        // Helper: extract client ID from "Name (C-001)" combo text
        private int GetSelectedClientId()
        {
            if (cmbClientFilter.SelectedIndex <= 0) return 0;
            string item = cmbClientFilter.SelectedItem.ToString();
            int start = item.IndexOf("C-") + 2;
            int end = item.IndexOf(")", start);
            if (start > 1 && end > start)
                if (int.TryParse(item.Substring(start, end - start), out int id)) return id;
            return 0;
        }
    }
}
