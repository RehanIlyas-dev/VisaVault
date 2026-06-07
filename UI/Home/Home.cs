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
        // Runtime labels placed inside each stat Panel
        private Label lblTotalClientsCount;
        private Label lblCriticalDocsCount;
        private Label lblOverdueInvoicesCount;
        private Label lblTodayApptsCount;
        private Label lblActiveCasesCount;
         
        public Home()
        {
            InitializeComponent();
            this.Load += Home_Load;
        }

        private void Home_Load(object sender, EventArgs e)
        {
            // Create a count Label inside each stat Panel
            lblTotalClientsCount = CreateCountLabel(lblTotalClients);
            lblCriticalDocsCount = CreateCountLabel(lblCriticalDocs);
            lblOverdueInvoicesCount = CreateCountLabel(lblOverdueInvoices);
            lblTodayApptsCount = CreateCountLabel(lblTodayAppts);
            lblActiveCasesCount = CreateCountLabel(lblActiveCases);

            LoadStats();
            LoadCriticalDocuments();
            LoadTodayAppointments();
            LoadOverdueInvoices();
        }

        // Creates a large centered Label inside a Panel to display a number
        private Label CreateCountLabel(Panel parent)
        {
            Label lbl = new Label();
            lbl.AutoSize = false;
            lbl.Dock = DockStyle.Fill;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Font = new Font("Book Antiqua", 26f, FontStyle.Bold);
            lbl.ForeColor = Color.FromArgb(16, 68, 115);
            lbl.BackColor = Color.Transparent;
            lbl.Text = "0";
            parent.Controls.Add(lbl);
            return lbl;
        }

        // Fills the 5 count labels inside the 5 stat panels at the top
        private void LoadStats()
        {
            lblTotalClientsCount.Text = ClientService.GetTotalClients().ToString();

            var summary = AlertService.GetAlertSummary();
            int critical = summary.ContainsKey("Critical") ? summary["Critical"] : 0;
            int expired = summary.ContainsKey("Expired") ? summary["Expired"] : 0;
            lblCriticalDocsCount.Text = (critical + expired).ToString();

            lblOverdueInvoicesCount.Text = AlertService.GetOverdueInvoiceCount().ToString();
            lblTodayApptsCount.Text = AppointmentService.GetTodayAppointmentCount().ToString();
            lblActiveCasesCount.Text = AlertService.GetActiveCaseCount().ToString();
        }

        // Fills listCriticalDocs Panel by adding Labels dynamically
        private void LoadCriticalDocuments()
        {
            listCriticalDocs.Controls.Clear();
            List<Document> docs = DocumentService.GetCriticalDocuments();

            int yPos = 5;

            if (docs.Count == 0)
            {
                AddRowToPanel(listCriticalDocs, "No critical documents.", Color.Transparent, Color.FromArgb(45, 45, 48), ref yPos);
                return;
            }

            foreach (var doc in docs)
            {
                string level = DocumentService.GetAlertLevel(doc);
                int days = DocumentService.GetDaystoAction(doc);
                var client = ClientService.GetClientbyID(doc.ClientId);
                string clientName = client != null ? client.ClientName : $"Client {doc.ClientId}";
                string text = $"{clientName}  —  {doc.DocumentNo}  —  {level}  ({days} days)";

                Color fontColor = Color.FromArgb(45, 45, 48);
                if (level == "Expired") fontColor = Color.FromArgb(220, 53, 69);
                if (level == "Critical") fontColor = Color.FromArgb(253, 126, 20);
                if (level == "Warning") fontColor = Color.FromArgb(255, 193, 7);

                AddRowToPanel(listCriticalDocs, text, Color.Transparent, fontColor, ref yPos);
            }
        }

        // Fills listTodayAppts Panel by adding Labels dynamically
        private void LoadTodayAppointments()
        {
            listTodayAppts.Controls.Clear();
            List<Appointment> appts = AppointmentService.GetTodayAppointments();

            int yPos = 5;

            if (appts.Count == 0)
            {
                AddRowToPanel(listTodayAppts, "No appointments today.", Color.Transparent, Color.FromArgb(45, 45, 48), ref yPos);
                return;
            }

            foreach (var a in appts)
            {
                var client = ClientService.GetClientbyID(a.ClientId);
                string clientName = client != null ? client.ClientName : $"Client {a.ClientId}";
                string text = $"{a.AppointmentDate:hh:mm tt}  —  {clientName}  —  {a.Purpose}";
                AddRowToPanel(listTodayAppts, text, Color.Transparent, Color.FromArgb(45, 45, 48), ref yPos);
            }
        }

        // Fills listOverdueInvoices Panel by adding Labels dynamically
        private void LoadOverdueInvoices()
        {
            listOverdueInvoices.Controls.Clear();
            List<visavault_g43.Models.Invoice> invoices =
                InvoiceService.GetAllInvoices(0, "Overdue");

            int yPos = 5;

            if (invoices.Count == 0)
            {
                AddRowToPanel(listOverdueInvoices, "No overdue invoices.", Color.Transparent, Color.FromArgb(45, 45, 48), ref yPos);
                return;
            }

            foreach (var inv in invoices)
            {
                int daysOver = (DateTime.Today - inv.DueDate.Date).Days;
                var client = ClientService.GetClientbyID(inv.ClientId);
                string clientName = client != null ? client.ClientName : $"Client {inv.ClientId}";
                string text = $"INV-{inv.InvoiceID:D3}  —  {clientName}  —  Rs {inv.Amount:N0}  —  {daysOver} days overdue";
                AddRowToPanel(listOverdueInvoices, text, Color.Transparent, Color.FromArgb(220, 53, 69), ref yPos);
            }
        }

        // Helper: adds one text row as a Label inside the given Panel
        private void AddRowToPanel(Panel panel, string text, Color backColor, Color foreColor, ref int yPos)
        {
            Label lbl = new Label();
            lbl.Text = text;
            lbl.AutoSize = false;
            lbl.Width = panel.Width - 10;
            lbl.Height = 22;
            lbl.Location = new Point(5, yPos);
            lbl.BackColor = backColor;
            lbl.ForeColor = foreColor;
            lbl.Font = new Font("Segoe UI", 9f);
            panel.Controls.Add(lbl);
            yPos += 25;
        }

        private void lblTotalClients_Paint(object sender, PaintEventArgs e)
        {
            // Reserved for custom painting if needed
        }

        
    }
}
