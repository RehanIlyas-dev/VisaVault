using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using visavault_g43.DLL;
using visavault_g43.Models;

namespace visavault_g43.BLL
{
    public class DeadlineService
    {
        private static int DefaultBufferDays = 30; // Default buffer period in days before a document is considered critical
        private static int DefaultProceedingDays = 15; // Default proceeding period in days before a document is considered in warning status

        public static List<DeadlineRow> GetDeadLines(int FilterClientId = 0) // FilterClient is 0 to get all clients
        {
            List<DeadlineRow> GridData = new List<DeadlineRow>();
            DataTable DocumentTable;

            if(FilterClientId > 0) // If a specific client ID is provided, fetch documents for that client only
            {
                DocumentTable = DocumentDAL.GetDocumentsbyClient(FilterClientId);
            }
            else
            {
                DocumentTable = DocumentDAL.GetCriticalDocuments();
            }

            foreach(DataRow row in DocumentTable.Rows)
            {
                int clientId = Convert.ToInt32(row["ClientId"]);
                int typeId = Convert.ToInt32(row["TypeId"]);

                Document doc = new Document
                {
                    DocumentId =  Convert.ToInt32(row["DocumentId"]),
                    DocumentNo = row["DocumentNo"].ToString(),
                    IssueDate = Convert.ToDateTime(row["IssueDate"]),
                    ExpiryDate = Convert.ToDateTime(row["ExpiryDate"]),
                    TypeID = typeId,
                    ClientId = clientId
                };

                // Fetch context names safely via DatabaseRecords
                string ClientName = "Unknown Client";
                DataTable clientDt = ClientDAL.GetClientById(clientId);
                if(clientDt.Rows.Count > 0)
                {
                    ClientName = clientDt.Rows[0]["ClientName"].ToString();
                }

                string typeName = "Unknown Type";
                DataTable typeDt = DocumentDAL.GetTypeById(typeId);
                if(typeDt.Rows.Count > 0)
                {
                    typeName = typeDt.Rows[0]["TypeName"].ToString();
                    break;
                }

                // Compute Calculated Metric sets
                DateTime actionDate = CalculateActionDate(doc);
                int daysLeft = DaysToAction(doc);
                string alertLevel = GetAlertLevel(daysLeft);
                int processingDays = GetEffectiveProcDays(doc);

                GridData.Add(new DeadlineRow
                {
                    Document = doc,
                    ClientName = ClientName,
                    ActionDate = actionDate,
                    DaysLeft = daysLeft,
                    AlertLevel = alertLevel,
                    ProcessingDays = processingDays
                });
            }
            return GridData;
        }

        // Calculate Action Date based on ExpiryDate minus processing days
        public static DateTime CalculateActionDate(Document document)
        {
            int ProcessingDays = GetEffectiveProcDays(document);
            return document.ExpiryDate.AddDays(-ProcessingDays);
        }
        // Calculate processing days based on document type or default value
        public static int DaysToAction(Document document)
        {
            DateTime actionDate = CalculateActionDate(document);
            return (actionDate - DateTime.Now).Days;
        }
        // Determine alert level based on days to action
        public static string GetAlertLevel(int daystoAction)
        {
            if(daystoAction < 0) return "Expired";
            if(daystoAction <= 14) return "Critical";
            if (daystoAction <= 30) return "Warning";
            return "Safe";
        }

        public static int MinDaysForClient(int clientId) // Returns the minimum days to action for all documents of a client, or int.MaxValue if no documents, or 0 if invalid clientId
        {
            if(clientId <= 0) return 0;

            DataTable dt = DocumentDAL.GetDocumentsbyClient(clientId);
            if (dt.Rows.Count == 0) return int.MaxValue;
            int minDays = int.MaxValue;

            foreach(DataRow row in dt.Rows)
            {
                Document doc = new Document
                {
                    ExpiryDate = Convert.ToDateTime(row["ExpiryDate"]),
                    TypeID = Convert.ToInt32(row["TypeId"]),
                    ClientId = clientId
                };

                int daysToAction = DaysToAction(doc);
                if(daysToAction < minDays)
                {
                    minDays = daysToAction;
                }
            }
            return minDays;
        }
        // Helper Functions

        private static int GetEffectiveProcDays(Document document)
        {
            DataTable ClientDt = ClientDAL.GetClientById(document.ClientId);
            if(ClientDt.Rows.Count > 0)
            {
                int CountryId = Convert.ToInt32(ClientDt.Rows[0]["CountryId"]);
                DataTable feeRuleDt = FeeDAL.GetActiveRule(CountryId, document.TypeID);
                if(feeRuleDt.Rows.Count > 0 && feeRuleDt.Rows[0]["ProcessingFee"] != DBNull.Value)
                {
                    return Convert.ToInt32(feeRuleDt.Rows[0]["ProcessingFee"]);
                }
            }
            return DefaultProceedingDays;
        }

        private static int DifferenceInDays(DateTime date1, DateTime date2)
        {
            return (date1 - date2).Days;
        }
    }
}
