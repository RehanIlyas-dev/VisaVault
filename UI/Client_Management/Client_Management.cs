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
        private int editClientId = 0;
        public Client_Management()
        {
            InitializeComponent();
        }
        public Client_Management(int clientId)
        {
            InitializeComponent();
            editClientId = clientId;
        }

        private void Client_Management_Load(object sender, EventArgs e)
        {
            // Fill Status dropdown
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Active");
            cmbStatus.Items.Add("Inactive");
            cmbStatus.Items.Add("Blacklisted");
            cmbStatus.SelectedIndex = 0;

            // If editing, load existing client data into fields
            if (editClientId > 0)
            {
                Client existing = ClientService.GetClientbyID(editClientId);
                if (existing != null)
                {
                    txtFullName.Text = existing.ClientName;
                    txtCNIC.Text = existing.CnicNo;
                    txtPhone.Text = existing.ContactNo;
                    txtEmail.Text = existing.Email;
                    txtAddress.Text = existing.Address;
                    cmbStatus.Text = existing.Status;
                    // txtDateOfBirth and txtNationality are on the form
                    // but not stored in the Client model so left blank
                }
            }
        }

        // btnSave
        private void btnSave_Click(object sender, EventArgs e)
        {
            Client client = new Client(
                editClientId,
                txtFullName.Text.Trim(),
                txtCNIC.Text.Trim(),
                txtEmail.Text.Trim(),
                txtPhone.Text.Trim(),
                txtAddress.Text.Trim(),
                0,              // CountryId not on this form
                DateTime.Now,
                DateTime.Now,
                cmbStatus.SelectedItem?.ToString() ?? "Active"
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

        // btnCancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
