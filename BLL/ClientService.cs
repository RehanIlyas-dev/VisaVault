using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using visavault_g43.DLL;
using visavault_g43.Models;

namespace visavault_g43.BLL
{
    public static class ClientService
    {
        
        public static List<visavault_g43.Models.Client> GetClients()
        {
            DataTable dt = ClientDAL.GetAllClients(); // DAL returns rows using DB column names
            return MapDataTableToClients(dt);
        }

        public static List<visavault_g43.Models.Client> SearchClient(string Keyword, string StatusFilter)
        {
            if (string.IsNullOrWhiteSpace(Keyword)) Keyword = " ";
            DataTable dt = ClientDAL.SearchClient(Keyword, StatusFilter); // DAL.SearchClient expects (keyword, filterColumn)
            return MapDataTableToClients(dt);
        }

        public static visavault_g43.Models.Client GetClientbyID(int clientID)
        {
            if (clientID <= 0) return null;
            DataTable dt = ClientDAL.GetClientById(clientID); // Assuming ClientDAL has a method to get a client by ID
            if (dt.Rows.Count == 0) return null;

            DataRow row = dt.Rows[0];
            return MapDataRowToClient(row); // Assuming a method to map DataRow to Client object
        }

        public static ValidationResult SaveClient(visavault_g43.Models.Client client)
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

            int newID = ClientDAL.InsertClient(client); // DAL.InsertClient returns inserted id per DAL implementation
            if (newID > 0)
            {
                client.ClientId = newID;
                return ValidationResult.Success();
            }
            return ValidationResult.Failure("Failed to save client.");
        }

        public static ValidationResult UpdateClient(visavault_g43.Models.Client client)
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
            return ClientDAL.GetTotalClientCount(); // Assuming ClientDAL has a method to get the total number of clients
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
            // DAL.CNICExists returns true if CNIC exists; invert to indicate uniqueness
            return !ClientDAL.CNICExists(cnic, clientId ?? 0);
        }

        private static List<visavault_g43.Models.Client> MapDataTableToClients(DataTable dt) // Assuming a method to map a DataTable to a list of Client objects
        {
            List<visavault_g43.Models.Client> clients = new List<visavault_g43.Models.Client>();
            foreach (DataRow row in dt.Rows)
            {
                clients.Add(MapDataRowToClient(row));
            }
            return clients;
        }

        private static visavault_g43.Models.Client MapDataRowToClient(DataRow row) // Map DB columns (snake_case) to Client model
        {
            // Simplified mapping using DataRow.Field<T>() with null/default fallbacks
                return new Client(
                    Convert.ToInt32(row["client_id"]),
                    row["client_name"]?.ToString() ?? string.Empty,
                    row["cnic_no"]?.ToString() ?? string.Empty,
                    row["email"]?.ToString() ?? string.Empty,
                    row["contact_no"]?.ToString() ?? string.Empty,
                    row["address"]?.ToString() ?? string.Empty,
                    row["country_id"] == DBNull.Value ? 0 : Convert.ToInt32(row["country_id"]),
                    row["created_at"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["created_at"]),
                    row["updated_at"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["updated_at"]),
                    row["status"]?.ToString() ?? string.Empty
                );
        }


    }
}