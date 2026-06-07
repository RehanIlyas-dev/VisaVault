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
    public partial class Client_Management : Form
    {
        private int existingCountryId = 0;
        private int editClientId = 0;
        public Client_Management()
        {
            InitializeComponent();
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
        }
        public Client_Management(int clientId)
        {
            InitializeComponent();
            editClientId = clientId;
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
        }
        private void Client_Management_Load(object sender, EventArgs e)
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("active");
            cmbStatus.Items.Add("inactive");
            cmbStatus.SelectedIndex = 0;
            if (editClientId > 0)
            {
                Client existing = ClientService.GetClientbyID(editClientId);
                if (existing != null)
                {
                    existingCountryId = existing.CountryId;
                    txtFullName.Text = existing.ClientName;
                    txtCNIC.Text = existing.CnicNo;
                    txtPhone.Text = existing.ContactNo;
                    txtEmail.Text = existing.Email;
                    txtAddress.Text = existing.Address;
                    cmbStatus.Text = string.IsNullOrWhiteSpace(existing.Status) ? "active" : existing.Status.ToLowerInvariant();
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Client client = new Client(
                editClientId,
                txtFullName.Text.Trim(),
                txtCNIC.Text.Trim(),
                txtEmail.Text.Trim(),
                txtPhone.Text.Trim(),
                txtAddress.Text.Trim(),
                existingCountryId,              // Preserve CountryId
                DateTime.Now,
                DateTime.Now,
                (cmbStatus.SelectedItem?.ToString() ?? "active").ToLowerInvariant()
            );
            ValidationResult result = editClientId > 0
                ? ClientService.UpdateClient(client)
                : ClientService.SaveClient(client);
            MessageBox.Show(result.Message,
                result.IsValid ? "Saved" : "Error",
                MessageBoxButtons.OK,
                result.IsValid ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            if (result.IsValid) this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void panel3_Paint(object sender, PaintEventArgs e) { }
        private void textBox4_TextChanged(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}
