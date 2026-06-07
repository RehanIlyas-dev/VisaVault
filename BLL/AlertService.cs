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
            try {
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
            } catch (Exception) {
                return new List<Document>();
            }
        }

        public static Dictionary<string, int> GetAlertSummary() 
        {
            try {
                var summary = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
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
                    if (summary.ContainsKey(level)) 
                    {
                        summary[level]++;
                    }
                }
                return summary;
            } catch (Exception) {
                return new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
                {
                    { "Critical", 0 },
                    { "Warning", 0 },
                    { "Safe", 0 },
                    { "Expired", 0 }
                };
            }
        }

        public static string GetClientAlertLevel(int ClientId)
        {
            try {
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
            } catch (Exception) {
                return "None";
            }
        }

        public static int GetCriticalDocumentCount() 
        {
            try {
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
            } catch (Exception) {
                return 0;
            }
        }

        public static int GetOverdueInvoiceCount()
        {
            return InvoiceService.GetInvoiceCount(0, "Overdue");
        }

        public static int GetActiveCaseCount()
        {
            return RenewalService.GetActiveCaseCount();
        }

        public static List<Document> MapDataTabletoDocumentsList(DataTable dt)
        {
            var documents = new List<Document>();
            if (dt == null) return documents;
            foreach (DataRow dr in dt.Rows)
            {
                var doc = new Document(
                    Convert.ToInt32(dr["document_id"]),
                    dr["document_no"]?.ToString() ?? string.Empty,
                    dr["issue_date"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["issue_date"]),
                    dr["expiry_date"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["expiry_date"]),
                    Convert.ToInt32(dr["type_id"]),
                    Convert.ToInt32(dr["client_id"])
                );
                if (dr.Table.Columns.Contains("processing_days") && dr["processing_days"] != DBNull.Value)
                    doc.ProcessingDays = Convert.ToInt32(dr["processing_days"]);
                if (dr.Table.Columns.Contains("buffer_days") && dr["buffer_days"] != DBNull.Value)
                    doc.BufferDays = Convert.ToInt32(dr["buffer_days"]);
                documents.Add(doc);
            }
            return documents;
        }

    }
}
