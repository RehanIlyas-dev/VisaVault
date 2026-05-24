using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using visavault_g43.Models;
using visavault_g43.DLL;

namespace visavault_g43.BLL
{
    public static class ClientService
    {

        public static List<Client> GetClients()
        {
            DataTable dt = ClientDAL.GetAllClients(); // Assuming ClientDAL is a data access layer class that retrieves clients from the database
            return new List<Client>();
        }

        public static List<Client> SearchClient(string Keyword, string StatusFilter)
        {
            if (string.IsNullOrWhiteSpace(Keyword)) Keyword = " ";
            DataTable dt = ClientDAL.SearchClient(Keyword, StatusFilter); // Assuming ClientDAL has a method to search clients based on keyword and status filter
            return new List<Client>();
        }

        public static Client GetClientbyID(int clientID)
        {
            if (clientID <= 0) return null;
            DataTable dt = ClientDAL.GetClientById(clientID); // Assuming ClientDAL has a method to get a client by ID
            if (dt.Rows.Count == 0) return null;

            DataRow row = dt.Rows[0];
            return MapDataRowToClient(row); // Assuming a method to map DataRow to Client object
        }

        public static ValidationResult SaveClient(Client client)
        {
            if (string.IsNullOrWhiteSpace(client.ClientName))
                return ValidationResult.Failure("Client name is required.");
            if (!ValidateCNIC(client.CnicNo))
                return ValidationResult.Failure("Invalid CNIC number.");
            if (!ValidatePhone(client.ContactNo))
                return ValidationResult.Failure("Invalid phone number.");
            if (!string.IsNullOrWhiteSpace(client.Email) && !ValidateEmail(client.Email))
                return ValidationResult.Failure("Invalid email address.");
            if (!IsCNICUnique(client.CnicNo))
                return ValidationResult.Failure("CNIC number is already in use.");

            client.Status = "Active"; // Set default status to Active

            int newID = ClientDAL.InsertClient(client); // Assuming ClientDAL has a method to save a client and returns the new client ID
            if (newID > 0)
            {
                client.ClientID = newID;
                return ValidationResult.Success();
            }
            return ValidationResult.Failure("Failed to save client.");
        }

        public static ValidationResult UpdateClient(Client client)
        {
            if (client.ClientId <= 0)
                return ValidationResult.Failure("Invalid client ID.");
            if (string.IsNullOrWhiteSpace(client.ClientName))
                return ValidationResult.Failure("Client name is required.");
            if (!ValidateCNIC(client.CnicNo))
                return ValidationResult.Failure("Invalid CNIC number.");
            if (!ValidatePhone(client.ContactNo))
                return ValidationResult.Failure("Invalid phone number.");
            if (!string.IsNullOrWhiteSpace(client.Email) && !ValidateEmail(client.Email))
                return ValidationResult.Failure("Invalid email address.");
            if (!IsCNICUnique(client.CnicNo, client.ClientId))
                return ValidationResult.Failure("CNIC number is already in use by another client.");
            bool success = ClientDAL.UpdateClient(client); // Assuming ClientDAL has a method to update a client
            return success ? ValidationResult.Success() : ValidationResult.Failure("Failed to update client.");
        }

        public static ValidationResult ChangeClientStatus(int ClientID, string NewStatus)
        {
            if (ClientID <= 0)
                return ValidationResult.Failure("Invalid client ID.");
            if (string.IsNullOrWhiteSpace(NewStatus))
                return ValidationResult.Failure("Invalid status.");
            bool success = ClientDAL.UpdateClientStatus(ClientID, NewStatus); // Assuming ClientDAL has a method to change the status of a client
            if (success)
                return ValidationResult.Success();
            return ValidationResult.Failure("Failed to change client status.");
        }

        public static int GetTotalClients()
        {
            return ClientDAL.GetTotalClients(); // Assuming ClientDAL has a method to get the total number of clients
        }

        private static bool ValidateCNIC(string cnic)
        {
            if (string.IsNullOrWhiteSpace(cnic) || cnic.Length != 13)
                return false;
            return Regex.IsMatch(cnic, @"^\d{5}-\d{7}-\d{1}$"); // Basic CNIC format validation (e.g., 12345-1234567-1)
        }

        private static bool ValidatePhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;
            return Regex.IsMatch(phone, @"^\d{11}$"); // Basic phone number validation (11 digits)
        }

        private static bool ValidateEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"); 
        }

        private static bool IsCNICUnique(string cnic, int? clientId = null)
        {
            return ClientDAL.IsCNICUnique(cnic, clientId); // Assuming ClientDAL has a method to check if CNIC is unique, excluding the current client ID if provided
        }

        private static List<Client> MapDataTableToClients(DataTable dt) // Assuming a method to map a DataTable to a list of Client objects
        {
            List<Client> clients = new List<Client>();
            foreach (DataRow row in dt.Rows)
            {
                clients.Add(MapDataRowToClient(row));
            }
            return clients;
        }

        private static Client MapDataRowToClient(DataRow row) // Assuming a method to map a DataRow to a Client object
        {
            return new Client
            (
                ClientId: Convert.ToInt32(row["ClientID"]),
                ClientName: row["ClientName"].ToString(),
                CnicNo: row["CnicNo"].ToString(),
                Email: row["Email"].ToString(),
                ContactNo: row["ContactNo"].ToString(),
                Address: row["Address"].ToString(),
                CountryId: Convert.ToInt32(row["CountryId"]),
                CreatedAt: Convert.ToDateTime(row["CreatedAt"]),
                UpdatedAt: Convert.ToDateTime(row["UpdatedAt"]),
                Status: row["Status"].ToString()
            );
        }
    }
