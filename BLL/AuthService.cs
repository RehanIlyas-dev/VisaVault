using System;
using System.Collections.Generic;
using System.Data;
using visavault_g43.BLL;
using visavault_g43.DLL;
using visavault_g43.Models;

namespace VisaVault.BLL
{
    public static class AuthService
    {
        // Static Cache Lists for Application Performance Optimization
        public static List<Country> CachedCountries { get; private set; } = new List<Country>();
        public static List<DocumentType> CachedDocumentTypes { get; private set; } = new List<DocumentType>();
        public static List<RenewalStage> CachedStages { get; private set; } = new List<RenewalStage>();

        public static int CurrentUserId { get; private set; }
        public static int CurrentClientId { get; private set; }
        public static string CurrentAlertFilter { get; private set; }
        
        // Validates user credentials and establishes session context
        public static ValidationResult Login(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                return ValidationResult.Failure("Email and Password parameters cannot be empty values.");
            }

            // Fetches data via primary backend channel
            DataTable dt = AuthDAL.GetUserByEmail(email);
            if (dt.Rows.Count == 0)
            {
                return ValidationResult.Failure("Invalid email address or credential parameters.");
            }
            DataRow userRow = dt.Rows[0];
            string statusValue = userRow["status"].ToString();

            if (statusValue.Equals("inactive", StringComparison.OrdinalIgnoreCase) ||
                statusValue.Equals("suspended", StringComparison.OrdinalIgnoreCase))
            {
                return ValidationResult.Failure($"Authentication rejected. Your system access status profile is currently: {statusValue}.");
            }

            string dbPasswordHash = userRow["password_hash"].ToString();
            if (password != dbPasswordHash)
            {
                return ValidationResult.Failure("Invalid authentication security clearance passwords.");
            }
            CurrentUserId = Convert.ToInt32(userRow["user_id"]);
            CurrentAlertFilter = "All"; 
            AuthDAL.UpdateLastLogin(CurrentUserId);
            return ValidationResult.Success();
        }

        public static void Logout()
        {
            CurrentUserId = 0;
            CurrentClientId = 0;
            CurrentAlertFilter = null;
        }

        public static User GetCurrentUser()
        {
            if (CurrentUserId <= 0) return null;

            DataTable dt = AuthDAL.GetUserById(CurrentUserId);
            if (dt.Rows.Count == 0) return null;

            DataRow row = dt.Rows[0];
            return new User
            {
                UserId = Convert.ToInt32(row["user_id"]),
                Email = row["email"].ToString(),
                Status = row["status"].ToString(),
                FullName = row["full_name"].ToString(),
                LastLogin = row["last_login"] != DBNull.Value ? Convert.ToDateTime(row["last_login"]) : (DateTime?)null
            };
        }

        public static void SetClientContext(int clientId)
        {
            CurrentClientId = clientId;
        }

        public static void ClearClientContext()
        {
            CurrentClientId = 0;
        }

        public static void PopulateStaticData()
        {
            CachedCountries.Clear();
            CachedCountries.AddRange(FeeService.GetAllCountries());
            CachedDocumentTypes.Clear();
            CachedDocumentTypes.AddRange(DocumentService.GetAllDocumentTypes());
            CachedStages.Clear();
            CachedStages.AddRange(RenewalService.GetAllStages());
        }
    }
}