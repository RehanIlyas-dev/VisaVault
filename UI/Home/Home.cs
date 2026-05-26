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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }


        private void Home_Load(object sender, EventArgs e)
        {
            LoadStats();
            LoadCriticalDocuments();
            LoadTodayAppointments();
            LoadOverdueInvoices();
        }

        // Fills the 5 labels inside the 5 stat panels at the top
        private void LoadStats()
        {
            lblTotalClients.Text = ClientService.GetTotalClients().ToString();

            var summary = AlertService.GetAlertSummary();
            int critical = summary.ContainsKey("Critical") ? summary["Critical"] : 0;
            int expired = summary.ContainsKey("Expired") ? summary["Expired"] : 0;
            lblCriticalDocs.Text = (critical + expired).ToString();

            lblOverdueInvoices.Text = AlertService.GetOverdueInvoiceCount().ToString();
            lblTodayAppts.Text = AppointmentService.GetTodayAppointmentCount().ToString();
            lblActiveCases.Text = AlertService.GetActiveCaseCount().ToString();
        }

        // Fills listCriticalDocs Panel by adding labels dynamically
        private void LoadCriticalDocuments()
        {
            listCriticalDocs.Controls.Clear();
            List<Document> docs = DocumentService.GetCriticalDocuments();

            int yPos = 5;

            if (docs.Count == 0)
            {
                AddRowToPanel(listCriticalDocs, "No critical documents.", Color.White, ref yPos);
                return;
            }

            foreach (var doc in docs)
            {
                string level = DocumentService.GetAlertLevel(doc);
                int days = DocumentService.GetDaystoAction(doc);
                string text = $"Client {doc.ClientId}  —  {doc.DocumentNo}  —  {level}  ({days} days)";

                Color rowColor = Color.White;
                if (level == "Expired") rowColor = Color.FromArgb(255, 200, 200);
                if (level == "Critical") rowColor = Color.FromArgb(255, 220, 200);
                if (level == "Warning") rowColor = Color.FromArgb(255, 255, 200);

                AddRowToPanel(listCriticalDocs, text, rowColor, ref yPos);
            }
        }

        // Fills listTodayAppts Panel by adding labels dynamically
        private void LoadTodayAppointments()
        {
            listTodayAppts.Controls.Clear();
            List<Appointment> appts = AppointmentService.GetTodayAppointments();

            int yPos = 5;

            if (appts.Count == 0)
            {
                AddRowToPanel(listTodayAppts, "No appointments today.", Color.White, ref yPos);
                return;
            }

            foreach (var a in appts)
            {
                string text = $"{a.AppointmentDate:hh:mm tt}  —  Client {a.ClientId}  —  {a.Purpose}";
                AddRowToPanel(listTodayAppts, text, Color.White, ref yPos);
            }
        }

        // Fills listOverdueInvoices Panel by adding labels dynamically
        private void LoadOverdueInvoices()
        {
            listOverdueInvoices.Controls.Clear();
            List<visavault_g43.Models.Invoice> invoices =
                InvoiceService.GetAllInvoices(0, "Overdue");

            int yPos = 5;

            if (invoices.Count == 0)
            {
                AddRowToPanel(listOverdueInvoices, "No overdue invoices.", Color.White, ref yPos);
                return;
            }

            foreach (var inv in invoices)
            {
                int daysOver = (DateTime.Today - inv.DueDate.Date).Days;
                string text = $"INV-{inv.InvoiceID:D3}  —  Client {inv.ClientId}  —  Rs {inv.Amount:N0}  —  {daysOver} days overdue";
                AddRowToPanel(listOverdueInvoices, text, Color.FromArgb(255, 240, 200), ref yPos);
            }
        }

        // Helper: adds one text row as a Label inside the given Panel
        private void AddRowToPanel(Panel panel, string text, Color backColor, ref int yPos)
        {
            Label lbl = new Label();
            lbl.Text = text;
            lbl.AutoSize = false;
            lbl.Width = panel.Width - 10;
            lbl.Height = 22;
            lbl.Location = new Point(5, yPos);
            lbl.BackColor = backColor;
            lbl.ForeColor = Color.White;
            lbl.Font = new Font("Segoe UI", 9f);
            panel.Controls.Add(lbl);
            yPos += 25;
        }

        private void lblTotalClients_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
