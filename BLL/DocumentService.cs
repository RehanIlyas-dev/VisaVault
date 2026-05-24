using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using visavault_g43.Models;

namespace visavault_g43.BLL
{
    public static class DocumentService
    {
        public static List<Document> GetDocumentsbyClientId(int clientId)
        {
            if(clientId <= 0)
               return new List<Document>(); // Return an empty list if the clientId is invalid
            DataTable dt = DocumentDAL.GetDocumentsbyClientId(clientId); // Assuming DocumentDAL has a method to get documents by client ID
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

            int newID = DocumentDAL.SaveDocument(document); // Assuming DocumentDAL has a method to save a document and returns the new document ID
            if (newID > 0)
            {
                document.DocumentId = newID; // Update the document object with the new ID
                return ValidationResult.Success("Document saved successfully.");

            }
            else
            {
                return ValidationResult.Failure("Failed to save document.");

            }
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
            bool success = DocumentDAL.UpdateDocument(document); // Assuming DocumentDAL has a method to update a document and returns a boolean indicating success
            if (success)
            {
                return ValidationResult.Success("Document updated successfully.");
            }
            else
            {
                return ValidationResult.Failure("Failed to update document.");
            }
        }
        
        public static ValidationResult DeleteDocument(int documentId)
        {
            if(documentId <= 0)
                return ValidationResult.Failure("Invalid document ID.");
            bool success = DocumentDAL.DeleteDocument(documentId); // Assuming DocumentDAL has a method to delete a document and returns a boolean indicating success
            if (success)
            {
                return ValidationResult.Success("Document deleted successfully.");
            }
            else
            {
                return ValidationResult.Failure("Failed to delete document.");
            }
        }

        public static Document GetDocumentbyId(int DocumentId)
        {
            if (DocumentId <= 0) return null; 
            DataTable dt = DocumentDAL.GetDocumentbyId(DocumentId); // Assuming DocumentDAL has a method to get a document by ID
            if (dt.Rows.Count == 0) return null;
            DataRow row = dt.Rows[0];
            return MapDataRowToDocument(row); // Assuming a method to map DataRow to Document object
        }

        public static List<DocumentType> GetDocumentTypes()
        {
            DataTable dt = DocumentDAL.GetDocumentTypes(); // Assuming DocumentDAL has a method to get document types
            List<DocumentType> documentTypes = new List<DocumentType>();
            foreach (DataRow row in dt.Rows)
            {
                documentTypes.Add(new DocumentType
                {
                    DocumentTypeId = Convert.ToInt32(row["DocumentTypeId"]),
                    DocumentTypeName = row["DocumentTypeName"]?.ToString() ?? string.Empty
                });
            }
            return documentTypes;
        }

        public static DateTime GetActionDate(Document document)
        {
            int ProcessingDays = GetProcessingDays(document.TypeID); // Assuming a method to get processing days based on document type ID
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
            if(isExpired(document)) return "Expired";

            int daysToAction = GetDaystoAction(document); // Get the number of days until the action date
            if(daysToAction <= 14) return "Critical";
            if (daysToAction <= 30) return "Warning";
            return "Safe";
        }

        public static bool IsExpired(Document document)
        {
            return document.ExpiryDate < DateTime.Now; // Check if the document's expiry date is in the past
        }

        public static List<Document> GetCriticalDocuments()
        {
            DataTable dt = DocumentDAL.GetCriticalDocuments(); // Assuming DocumentDAL has a method to get critical documents
            List<Document> alldocs = MapDataTabletoList(dt);
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
            DataTable Clientdt = ClientDAL.GetClientById(ClientId); // Assuming ClientDAL has a method to get a client by ID
            if(Clientdt.Rows.Count > 0)
            {
                int CountryId = Convert.ToInt32(Clientdt.Rows[0]["CountryId"]); // Assuming the client data table has a "CountryId" column
                DataTable feeDt = FeeDAL.GetActiveRule(CountryId, documentTypeId);
                if (feeDt.Rows.Count > 0 && feeDt.Columns.Contains("ProcessingDays"))
                {
                    return Convert.ToInt32(feeDt.Rows[0]["ProcessingDays"]); // Assuming the fee data table has a "ProcessingDays" column
                }
            }
            return 0;
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
            return new Document
            (
                DocumentId: Convert.ToInt32(row["DocumentId"]),
                DocumentNo: row["DocumentNo"].ToString(),
                IssueDate: Convert.ToDateTime(row["IssueDate"]),
                ExpiryDate: Convert.ToDateTime(row["ExpiryDate"]),
                TypeID: Convert.ToInt32(row["TypeID"]),
                ClientId: Convert.ToInt32(row["ClientId"])
            );
        }

    }
}
