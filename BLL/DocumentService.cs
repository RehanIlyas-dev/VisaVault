using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using visavault_g43.Models;
using visavault_g43.DLL;

namespace visavault_g43.BLL
{
    public static class DocumentService
    {
        public static List<Document> GetDocumentsbyClientId(int clientId)
        {
            if(clientId <= 0)
               return new List<Document>(); // Return an empty list if the clientId is invalid
            DataTable dt = DocumentDAL.GetDocumentsByClient(clientId);
            return MapDataTabletoDocumentList(dt);
        }

        public static List<Document> SearchDocuments(int clientId, string keyword)
        {
            if(String.IsNullOrWhiteSpace(keyword)) keyword = ""; // Handle null or whitespace keyword
            DataTable dt = DocumentDAL.SearchDocuments(clientId, keyword); // Assuming DocumentDAL has a method to search documents
            return MapDataTabletoDocumentList(dt);
        }

        public static ValidationResult SaveDocument(Document document)
        {
            if (String.IsNullOrWhiteSpace(document.DocumentNo))
                return ValidationResult.Failure("Document number cannot be empty.");
            if (document.TypeID < 0)
                return ValidationResult.Failure("Invalid document type ID.");
            if (document.ClientId <= 0)
                return ValidationResult.Failure("Invalid client ID.");
            if (document.IssueDate > document.ExpiryDate)
                return ValidationResult.Failure("Issue date cannot be later than expiry date.");

            int rows = DocumentDAL.InsertDocument(document);
            if (rows > 0)
            {
                return ValidationResult.Success("Document saved successfully.");
            }
            return ValidationResult.Failure("Failed to save document.");
        }

        public static ValidationResult UpdateDocument(Document document)
        {
            if (document.DocumentId <= 0)
                return ValidationResult.Failure("Invalid document ID.");
            if (String.IsNullOrWhiteSpace(document.DocumentNo))
                return ValidationResult.Failure("Document number cannot be empty.");
            if (document.TypeID < 0)
                return ValidationResult.Failure("Invalid document type ID.");
            if (document.ClientId <= 0)
                return ValidationResult.Failure("Invalid client ID.");
            if (document.IssueDate > document.ExpiryDate)
                return ValidationResult.Failure("Issue date cannot be later than expiry date.");
            int rows = DocumentDAL.UpdateDocument(document);
            return rows > 0 ? ValidationResult.Success("Document updated successfully.") : ValidationResult.Failure("Failed to update document.");
        }
        
        public static ValidationResult DeleteDocument(int documentId)
        {
            if(documentId <= 0)
                return ValidationResult.Failure("Invalid document ID.");
            int rows = DocumentDAL.DeleteDocument(documentId);
            return rows > 0 ? ValidationResult.Success("Document deleted successfully.") : ValidationResult.Failure("Failed to delete document.");
        }

        public static Document GetDocumentbyId(int DocumentId)
        {
            if (DocumentId <= 0) return null; 
            DataTable dt = DocumentDAL.GetDocumentById(DocumentId);
            if (dt.Rows.Count == 0) return null;
            DataRow row = dt.Rows[0];
            return MapDataRowToDocument(row); // Assuming a method to map DataRow to Document object
        }

        public static List<DocumentType> GetAllDocumentTypes()
        {
            DataTable dt = DocumentDAL.GetAllDocumentTypes();
            var documentTypes = new List<DocumentType>();
            if (dt == null || dt.Rows.Count == 0) return documentTypes;

            foreach (DataRow row in dt.Rows)
            {
                int documentTypeId = row["documenttype_id"] == DBNull.Value ? 0 : Convert.ToInt32(row["documenttype_id"]);
                string documentTypeName = row["documenttype_name"]?.ToString() ?? string.Empty;

                documentTypes.Add(new DocumentType
                {
                    DocumentTypeId = documentTypeId,
                    DocumentTypeName = documentTypeName
                });
            }

            return documentTypes;
        }

        public static DateTime GetActionDate(Document document)
        {
            int ProcessingDays = GetProcessingDays(document.TypeID, document.ClientId); // include client for country-specific rules
            return document.ExpiryDate.AddDays(-ProcessingDays);
        }

        public static int GetDaystoAction(Document document)
        {
            DateTime actionDate = GetActionDate(document); // Get the action date based on the document's expiry date and processing days
            int daysToAction = (actionDate - DateTime.Now).Days; // Calculate the number of days until the action date
            return daysToAction;
        }

        public static string GetAlertLevel(Document document)
        {
            if (IsExpired(document)) return "Expired";

            int daysToAction = GetDaystoAction(document); // Get the number of days until the action date
            if (daysToAction <= 14) return "Critical";
            if (daysToAction <= 30) return "Warning";
            return "Safe";
        }

        public static bool IsExpired(Document document)
        {
            return document.ExpiryDate < DateTime.Now; // Check if the document's expiry date is in the past
        }

        public static List<Document> GetCriticalDocuments()
        {
            DataTable dt = DocumentDAL.GetCriticalDocuments(); // DAL has GetCriticalDocuments
            List<Document> alldocs = MapDataTabletoDocumentList(dt);
            List<Document> criticalDocs = new List<Document>();
            foreach(var docs in alldocs)
            {
                string alertLevel = GetAlertLevel(docs); // Get the alert level for each document
                if(alertLevel == "Critical" || alertLevel == "Expired")
                {
                    criticalDocs.Add(docs);
                }
            }
            return criticalDocs;
        }

        private static int GetProcessingDays(int documentTypeId, int ClientId)
        { 
            return 15; // default 15 days since processing_days is not in the db
        }

        private static List<Document> MapDataTabletoDocumentList(DataTable dt)
        {
            List<Document> documents = new List<Document>();
            foreach (DataRow row in dt.Rows)
            {
                documents.Add(MapDataRowToDocument(row)); // Assuming a method to map DataRow to Document object
            }
            return documents;
        }

        private static Document MapDataRowToDocument(DataRow row)
        {
            // Simple, explicit mapping from DataRow to Document
            return new Document(
                Convert.ToInt32(row["document_id"]),
                row["document_no"]?.ToString() ?? string.Empty,
                row["issue_date"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["issue_date"]),
                row["expiry_date"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["expiry_date"]),
                Convert.ToInt32(row["type_id"]),
                Convert.ToInt32(row["client_id"])
            );
        }

    }
}
