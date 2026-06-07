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
        private static int DefaultBufferDays = 30; 
        private static int DefaultProceedingDays = 15; 

        public static List<DeadlineRow> GetDeadLines(int FilterClientId = 0) 
        {
            try {
                List<DeadlineRow> GridData = new List<DeadlineRow>();
                DataTable DocumentTable = FilterClientId > 0
                    ? DocumentDAL.GetDocumentsByClient(FilterClientId)
                    : DocumentDAL.GetAllDocuments();

                foreach(DataRow row in DocumentTable.Rows)
                {
                    Document doc = MapDocument(row, FilterClientId);
                    string clientName = GetString(row, "client_name", "Unknown Client");
                    string typeName = GetString(row, "documenttype_name", "Unknown Type");
                    DateTime actionDate = CalculateActionDate(doc);
                    int daysLeft = DaysToAction(doc);
                    string alertLevel = GetAlertLevel(daysLeft);

                    GridData.Add(new DeadlineRow(clientName, typeName, doc.ExpiryDate, actionDate, daysLeft, alertLevel, doc.ProcessingDays, doc.BufferDays));
                }
                return GridData;
            } catch (Exception) {
                return new List<DeadlineRow>();
            }
        }

        public static DateTime CalculateActionDate(Document document)
        {
            int processingDays = document.ProcessingDays > 0 ? document.ProcessingDays : DefaultProceedingDays;
            return document.ExpiryDate.AddDays(-processingDays);
        }
        public static int DaysToAction(Document document)
        {
            DateTime actionDate = CalculateActionDate(document);
            return (actionDate - DateTime.Now).Days;
        }
        public static string GetAlertLevel(int daystoAction)
        {
            if(daystoAction < 0) return "Expired";
            if(daystoAction <= 14) return "Critical";
            if (daystoAction <= DefaultBufferDays) return "Warning";
            return "Safe";
        }

        public static int MinDaysForClient(int clientId) // Returns the minimum days to action for all documents of a client, or int.MaxValue if no documents, or 0 if invalid clientId
        {
            try {
                if(clientId <= 0) return 0;

                DataTable dt = DocumentDAL.GetDocumentsByClient(clientId);
                if (dt.Rows.Count == 0) return int.MaxValue;
                int minDays = int.MaxValue;

                foreach(DataRow row in dt.Rows)
                {
                    int daysToAction = DaysToAction(MapDocument(row, clientId));
                    if(daysToAction < minDays) minDays = daysToAction;
                }
                return minDays;
            } catch (Exception) {
                return int.MaxValue;
            }
        }

        private static Document MapDocument(DataRow row, int clientIdOverride = 0)
        {
            var doc = new Document(
                GetInt(row, "document_id"),
                GetString(row, "document_no"),
                GetDate(row, "issue_date"),
                GetDate(row, "expiry_date"),
                GetInt(row, "type_id"),
                clientIdOverride > 0 ? clientIdOverride : GetInt(row, "client_id")
            );
            int procDays = GetInt(row, "processing_days", DefaultProceedingDays);
            int bufferDays = GetInt(row, "buffer_days", DefaultBufferDays);
            doc.ProcessingDays = procDays > 0 ? procDays : DefaultProceedingDays;
            doc.BufferDays = bufferDays > 0 ? bufferDays : DefaultBufferDays;
            return doc;
        }

        private static int GetInt(DataRow row, string columnName, int defaultValue = 0)
        {
            return row.Table.Columns.Contains(columnName) && row[columnName] != DBNull.Value ? Convert.ToInt32(row[columnName]) : defaultValue;
        }

        private static string GetString(DataRow row, string columnName, string defaultValue = "")
        {
            return row.Table.Columns.Contains(columnName) && row[columnName] != DBNull.Value ? row[columnName].ToString() : defaultValue;
        }

        private static DateTime GetDate(DataRow row, string columnName)
        {
            return row.Table.Columns.Contains(columnName) && row[columnName] != DBNull.Value ? Convert.ToDateTime(row[columnName]) : DateTime.MinValue;
        }

    }
}
