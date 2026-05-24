using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using visavault_g43.DLL;
using visavault_g43.Models;

namespace visavault_g43.BLL
{
    public  class AlertService
    {
        public static List<Document> GetDocumentsbyAlertLevel(string filter)
        {
            DataTable dt = DocumentDAL.GetCriticalDocuments();
            List<Document> alldocuments = MapDataTabletoDocumentsList(dt);

            if (String.IsNullOrWhiteSpace(filter) || filter == "All")
                return alldocuments;

            List<Document> filteredDocuments = new List<Document>();
            foreach (Document doc in alldocuments)
            {
                string level = DocumentService.GetAlertLevel(doc);
                if (level == filter)
                {
                    filteredDocuments.Add(doc);
                }
            }
            return filteredDocuments;
        }

        public static Dictionary<string, int> GetAlertSummary() // Returns a summary of document counts by alert level
        {
            var summary = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase) // Initialize summary with all levels to ensure they are present even if count is zero
            {
                { "Critical", 0 },
                { "Warning", 0 },
                { "Safe", 0 },
                { "Expired", 0 }
            };

            DataTable dt = DocumentDAL.GetCriticalDocuments();
            List<Document> alldocuments = MapDataTabletoDocumentsList(dt);
            foreach (Document doc in alldocuments)
            {
                string level = DocumentService.GetAlertLevel(doc);
                if (summary.ContainsKey(level)) // Increment count for the alert level if it exists in the summary
                {
                    summary[level]++;
                }
            }
            return summary;
        }

        public static string GetClientAlertLevel(int ClientId)
        {
            if (ClientId <= 0) return null;

            DataTable dt = DocumentDAL.GetDocumentsByClient(ClientId);
            List<Document> clientdocs = MapDataTabletoDocumentsList(dt);

            if (clientdocs.Count == 0) return "None";
            bool hasCritical = false, hasWarning = false, hasExpired = false, hasSafe = false;

            foreach (var doc in clientdocs)
            {
                string level = DocumentService.GetAlertLevel(doc);
                switch (level)
                {
                    case "Critical":
                        hasCritical = true;
                        break;
                    case "Warning":
                        hasWarning = true;
                        break;
                    case "Expired":
                        hasExpired = true;
                        break;
                    case "Safe":
                        hasSafe = true;
                        break;
                }
            }

            if (hasCritical) return "Critical";
            if (hasWarning) return "Warning";
            if (hasExpired) return "Expired";
            if (hasSafe) return "Safe";

            return "None";
        }

        public int GetCriticalDocumentCount() // Returns the count of documents that are currently in the "Critical" alert level
        {
            DataTable dt = DocumentDAL.GetCriticalDocuments();
            List<Document> alldocuments = MapDataTabletoDocumentsList(dt);
            int count = 0;

            foreach (var doc in alldocuments)
            {
                if (DocumentService.GetAlertLevel(doc) == "Critical")
                {
                    count++;
                }
            }
            return count;
        }

        public static int GetOverdueInvoiceCount()
        {
            return InvoiceService.GetInvoiceCount(0, "Overdue");
        }

        public static int GetActiveCaseCount()
        {
            // Use the RenewalService which encapsulates DAL access and business rules
            return RenewalService.GetActiveCaseCount();
        }

        public static List<Document> MapDataTabletoDocumentsList(DataTable dt)
        {
            var documents = new List<Document>();
            if (dt == null) return documents;
            foreach (DataRow dr in dt.Rows)
            {
                documents.Add(new Document(
                    Convert.ToInt32(dr["document_id"]),
                    dr["document_no"]?.ToString() ?? string.Empty,
                    dr["issue_date"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["issue_date"]),
                    dr["expiry_date"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["expiry_date"]),
                    Convert.ToInt32(dr["type_id"]),
                    Convert.ToInt32(dr["client_id"])
                ));
            }
            return documents;
        }

    }
}
