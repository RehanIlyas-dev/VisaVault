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
    public partial class Appoinment : Form
    {

        public Appoinment()
        {
            InitializeComponent();

            // FIX: Wire events that the Designer never registered
            this.Load += Appoinment_Load;
            btnFilter.Click += btnFilter_Click;
        }

        private void Appoinment_Load(object sender, EventArgs e)
        {
            // Load today's appointments on open
            LoadAppointments(DateTime.Today);
        }

        private void LoadAppointments(DateTime date)
        {
            List<Appointment> appts = AppointmentService.GetAppointments(date);
            dgvAppointments.Rows.Clear();

            foreach (var a in appts)
            {
                int row = dgvAppointments.Rows.Add();
                dgvAppointments.Rows[row].Cells["colTime"].Value = a.AppointmentDate.ToString("hh:mm tt");
                dgvAppointments.Rows[row].Cells["colClient"].Value = $"Client {a.ClientId}";
                dgvAppointments.Rows[row].Cells["colPurpose"].Value = a.Purpose;
                dgvAppointments.Rows[row].Cells["colStatus"].Value = a.Status;

                // Color row by status
                Color c = Color.White;
                if (a.Status == "Completed") c = Color.FromArgb(200, 240, 200);
                if (a.Status == "Cancelled") c = Color.FromArgb(255, 200, 200);
                if (a.Status == "Unattended") c = Color.FromArgb(255, 240, 200);
                dgvAppointments.Rows[row].DefaultCellStyle.BackColor = c;

                dgvAppointments.Rows[row].Tag = a.AppointmentId;
            }
        }

        // btnFilter — filter by typed date
        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (DateTime.TryParseExact(txtDate.Text.Trim(), "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out DateTime parsed))
            {
                LoadAppointments(parsed);
            }
            else
            {
                MessageBox.Show("Please enter date as dd-MM-yyyy.", "Format Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
