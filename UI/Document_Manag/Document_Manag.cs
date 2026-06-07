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
    public partial class Document_Manag : Form
    {
        private int clientId = 0;
        private int documentId = 0;
        public Document_Manag(int clientId, int documentId)
        {
            InitializeComponent();
            this.clientId = clientId;
            this.documentId = documentId;
            this.Load += Document_Manag_Load;
            btnSave.Click += btnSave_Click;
            btnClear.Click += btnClear_Click;
        }
        private void Document_Manag_Load(object sender, EventArgs e)
        {
            cmbDocumentType.Items.Clear();
            foreach (var dt in AuthService.CachedDocumentTypes)
                cmbDocumentType.Items.Add(dt.DocumentTypeName);
            cmbCountry.Items.Clear();
            foreach (var c in AuthService.CachedCountries)
                cmbCountry.Items.Add(c.CountryName);
            if (documentId > 0)
            {
                Document doc = DocumentService.GetDocumentbyId(documentId);
                if (doc != null)
                {
                    clientId = doc.ClientId;
                    txtDocumentNumber.Text = doc.DocumentNo;
                    txtIssueDate.Text = doc.IssueDate == DateTime.MinValue ? "" : doc.IssueDate.ToString("dd-MM-yyyy");
                    txtExpiryDate.Text = doc.ExpiryDate == DateTime.MinValue ? "" : doc.ExpiryDate.ToString("dd-MM-yyyy");
                    for (int i = 0; i < AuthService.CachedDocumentTypes.Count; i++)
                    {
                        if (AuthService.CachedDocumentTypes[i].DocumentTypeId == doc.TypeID)
                        {
                            cmbDocumentType.SelectedIndex = i;
                            break;
                        }
                    }
                    var client = ClientService.GetClientbyID(doc.ClientId);
                    if (client != null)
                    {
                        var country = AuthService.CachedCountries.FirstOrDefault(c => c.CountryId == client.CountryId);
                        if (country != null)
                        {
                            for (int i = 0; i < cmbCountry.Items.Count; i++)
                            {
                                if (cmbCountry.Items[i].ToString().Equals(country.CountryName, StringComparison.OrdinalIgnoreCase))
                                {
                                    cmbCountry.SelectedIndex = i;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (documentId <= 0 && clientId <= 0)
            {
                MessageBox.Show("Please open this form from a selected client before saving a new document.", "Client Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!DateTime.TryParseExact(txtIssueDate.Text.Trim(), "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out DateTime issueDate))
            {
                MessageBox.Show("Issue Date must be dd-MM-yyyy format.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!DateTime.TryParseExact(txtExpiryDate.Text.Trim(), "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out DateTime expiryDate))
            {
                MessageBox.Show("Expiry Date must be dd-MM-yyyy format.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int typeId = 0;
            if (cmbDocumentType.SelectedIndex >= 0)
                typeId = AuthService.CachedDocumentTypes[cmbDocumentType.SelectedIndex].DocumentTypeId;
            Document doc = new Document(
                documentId,
                txtDocumentNumber.Text.Trim(),
                issueDate,
                expiryDate,
                typeId,
                clientId
            );
            ValidationResult result = documentId > 0
                ? DocumentService.UpdateDocument(doc)
                : DocumentService.SaveDocument(doc);
            MessageBox.Show(result.Message,
                result.IsValid ? "Saved" : "Error",
                MessageBoxButtons.OK,
                result.IsValid ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            if (result.IsValid) this.Close();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbDocumentType.SelectedIndex = -1;
            txtDocumentNumber.Text = "";
            cmbCountry.SelectedIndex = -1;
            txtIssueDate.Text = "";
            txtExpiryDate.Text = "";
            txtNotes.Text = "";
        }
    }
}
