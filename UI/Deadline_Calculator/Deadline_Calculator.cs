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
    public partial class Deadline_Calculator : Form
    {
        public Deadline_Calculator()
        {
            InitializeComponent();
        }
        private void Deadline_Calculator_Load(object sender, EventArgs e)
        {
            // cmbClient — the one dropdown on the form
            cmbClient.Items.Clear();
            cmbClient.Items.Add("All Clients");

            List<Client> clients = ClientService.GetClients();
            foreach (var c in clients)
                cmbClient.Items.Add($"{c.ClientName} (C-{c.ClientId:D3})");

            // Pre-select if a client context is set
            if (AuthService.CurrentClientId > 0)
            {
                for (int i = 1; i < cmbClient.Items.Count; i++)
                {
                    if (cmbClient.Items[i].ToString().Contains($"C-{AuthService.CurrentClientId:D3}"))
                    {
                        cmbClient.SelectedIndex = i;
                        break;
                    }
                }
            }
            else
            {
                cmbClient.SelectedIndex = 0;
            }

            LoadDeadlines();
        }

        private void LoadDeadlines()
        {
            int filterClientId = GetSelectedClientId();
            List<DeadlineRow> rows = DeadlineService.GetDeadLines(filterClientId);
            dgvDeadlines.Rows.Clear();

            foreach (var dr in rows)
            {
                int row = dgvDeadlines.Rows.Add();
                dgvDeadlines.Rows[row].Cells["colClient"].Value = dr.ClientName;
                dgvDeadlines.Rows[row].Cells["colDocType"].Value = dr.DocumentType;
                dgvDeadlines.Rows[row].Cells["colExpiryDate"].Value = dr.ExpiryDate.ToString("dd-MMM-yyyy");
                dgvDeadlines.Rows[row].Cells["colProcDays"].Value = dr.ProcessingDays;
                dgvDeadlines.Rows[row].Cells["colBufferDays"].Value = "—";
                dgvDeadlines.Rows[row].Cells["colActionDate"].Value = dr.ActionDate.ToString("dd-MMM-yyyy");
                dgvDeadlines.Rows[row].Cells["colDaysToAct"].Value = dr.DaysLeft;
                dgvDeadlines.Rows[row].Cells["colAlert"].Value = dr.AlertLevel;

                // Color the alert and days cells
                Color c = Color.White;
                if (dr.AlertLevel == "Expired") c = Color.Black;
                if (dr.AlertLevel == "Critical") c = Color.FromArgb(255, 200, 180);
                if (dr.AlertLevel == "Warning") c = Color.FromArgb(255, 240, 180);
                if (dr.AlertLevel == "Safe") c = Color.FromArgb(200, 240, 200);

                dgvDeadlines.Rows[row].Cells["colDaysToAct"].Style.BackColor = c;
                dgvDeadlines.Rows[row].Cells["colAlert"].Style.BackColor = c;

                if (dr.AlertLevel == "Expired")
                    dgvDeadlines.Rows[row].Cells["colDaysToAct"].Style.ForeColor = Color.White;
            }
        }

        // btnSearch
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadDeadlines();
        }

        // btnClear
        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbClient.SelectedIndex = 0;
            LoadDeadlines();
        }

        // Helper: extract client ID from "Name (C-001)" combo text
        private int GetSelectedClientId()
        {
            if (cmbClient.SelectedIndex <= 0) return 0;
            string item = cmbClient.SelectedItem.ToString();
            int start = item.IndexOf("C-") + 2;
            int end = item.IndexOf(")", start);
            if (start > 1 && end > start)
                if (int.TryParse(item.Substring(start, end - start), out int id)) return id;
            return 0;
        }
    }
}
