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
            try {
                DataTable dt = ClientDAL.GetAllClients(); 
                return MapDataTableToClients(dt);
            } catch (Exception) {
                return new List<visavault_g43.Models.Client>();
            }
        }

        public static List<visavault_g43.Models.Client> SearchClient(string Keyword, string StatusFilter)
        {
            try {
                if (string.IsNullOrWhiteSpace(Keyword)) Keyword = " ";
                DataTable dt = ClientDAL.SearchClient(Keyword, StatusFilter); 
                return MapDataTableToClients(dt);
            } catch (Exception) {
                return new List<visavault_g43.Models.Client>();
            }
        }

        public static visavault_g43.Models.Client GetClientbyID(int clientID)
        {
            try {
                if (clientID <= 0) return null;
                DataTable dt = ClientDAL.GetClientById(clientID); 
                if (dt.Rows.Count == 0) return null;

                DataRow row = dt.Rows[0];
                return MapDataRowToClient(row); 
            } catch (Exception) {
                return null;
            }
        }

        public static ValidationResult SaveClient(visavault_g43.Models.Client client)
        {
            try {
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

                client.Status = "active";

                int newID = ClientDAL.InsertClient(client);
                if (newID > 0)
                {
                    client.ClientId = newID;
                    return ValidationResult.Success();
                }
                return ValidationResult.Failure("Failed to save client.");
            } catch (Exception ex) {
                return ValidationResult.Failure("Database error: " + ex.Message);
            }
        }

        public static ValidationResult UpdateClient(visavault_g43.Models.Client client)
        {
            try {
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
                bool success = ClientDAL.UpdateClient(client); 
                return success ? ValidationResult.Success() : ValidationResult.Failure("Failed to update client.");
            } catch (Exception ex) {
                return ValidationResult.Failure("Database error: " + ex.Message);
            }
        }

        public static ValidationResult ChangeClientStatus(int ClientID, string NewStatus)
        {
            try {
                if (ClientID <= 0)
                    return ValidationResult.Failure("Invalid client ID.");
                if (string.IsNullOrWhiteSpace(NewStatus))
                    return ValidationResult.Failure("Invalid status.");
                bool success = ClientDAL.UpdateClientStatus(ClientID, NewStatus); 
                if (success)
                    return ValidationResult.Success();
                return ValidationResult.Failure("Failed to change client status.");
            } catch (Exception ex) {
                return ValidationResult.Failure("Database error: " + ex.Message);
            }
        }

        public static int GetTotalClients()
        {
            try {
                return ClientDAL.GetTotalClientCount(); 
            } catch (Exception) {
                return 0;
            }
        }

        private static bool ValidateCNIC(string cnic)
        {
            if (string.IsNullOrWhiteSpace(cnic) || cnic.Length != 15)
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
            return !ClientDAL.CNICExists(cnic, clientId ?? 0);
        }

        private static List<visavault_g43.Models.Client> MapDataTableToClients(DataTable dt) 
        {
            List<visavault_g43.Models.Client> clients = new List<visavault_g43.Models.Client>();
            foreach (DataRow row in dt.Rows)
            {
                clients.Add(MapDataRowToClient(row));
            }
            return clients;
        }

        private static visavault_g43.Models.Client MapDataRowToClient(DataRow row) 
        {
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