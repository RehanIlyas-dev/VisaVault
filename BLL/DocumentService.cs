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
            try {
                DataTable dt = clientId > 0
                    ? DocumentDAL.GetDocumentsByClient(clientId)
                    : DocumentDAL.GetAllDocuments();
                return MapDataTabletoDocumentList(dt);
            } catch (Exception) {
                return new List<Document>();
            }
        }

        public static List<Document> SearchDocuments(int clientId, string keyword)
        {
            try {
                if(String.IsNullOrWhiteSpace(keyword)) keyword = ""; 
                DataTable dt = DocumentDAL.SearchDocuments(clientId, keyword); 
                return MapDataTabletoDocumentList(dt);
            } catch (Exception) {
                return new List<Document>();
            }
        }

        public static ValidationResult SaveDocument(Document document)
        {
            try {
                if (String.IsNullOrWhiteSpace(document.DocumentNo))
                    return ValidationResult.Failure("Document number cannot be empty.");
                if (document.TypeID <= 0)
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
            } catch (Exception ex) {
                return ValidationResult.Failure("Database error: " + ex.Message);
            }
        }

        public static ValidationResult UpdateDocument(Document document)
        {
            try {
                if (document.DocumentId <= 0)
                    return ValidationResult.Failure("Invalid document ID.");
                if (String.IsNullOrWhiteSpace(document.DocumentNo))
                    return ValidationResult.Failure("Document number cannot be empty.");
                if (document.TypeID <= 0)
                    return ValidationResult.Failure("Invalid document type ID.");
                if (document.ClientId <= 0)
                    return ValidationResult.Failure("Invalid client ID.");
                if (document.IssueDate > document.ExpiryDate)
                    return ValidationResult.Failure("Issue date cannot be later than expiry date.");
                int rows = DocumentDAL.UpdateDocument(document);
                return rows > 0 ? ValidationResult.Success("Document updated successfully.") : ValidationResult.Failure("Failed to update document.");
            } catch (Exception ex) {
                return ValidationResult.Failure("Database error: " + ex.Message);
            }
        }
        
        public static ValidationResult DeleteDocument(int documentId)
        {
            try {
                if(documentId <= 0)
                    return ValidationResult.Failure("Invalid document ID.");
                int rows = DocumentDAL.DeleteDocument(documentId);
                return rows > 0 ? ValidationResult.Success("Document deleted successfully.") : ValidationResult.Failure("Failed to delete document.");
            } catch (Exception ex) {
                return ValidationResult.Failure("Database error: " + ex.Message);
            }
        }

        public static Document GetDocumentbyId(int DocumentId)
        {
            try {
                if (DocumentId <= 0) return null; 
                DataTable dt = DocumentDAL.GetDocumentById(DocumentId);
                if (dt.Rows.Count == 0) return null;
                DataRow row = dt.Rows[0];
                return MapDataRowToDocument(row); 
            } catch (Exception) {
                return null;
            }
        }

        public static List<DocumentType> GetAllDocumentTypes()
        {
            try {
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
            } catch (Exception) {
                return new List<DocumentType>();
            }
        }

        public static DateTime GetActionDate(Document document)
        {
            int processingDays = document.ProcessingDays > 0 ? document.ProcessingDays : 15;
            return document.ExpiryDate.AddDays(-processingDays);
        }

        public static int GetDaystoAction(Document document)
        {
            DateTime actionDate = GetActionDate(document); 
            int daysToAction = (actionDate - DateTime.Now).Days; 
            return daysToAction;
        }

        public static string GetAlertLevel(Document document)
        {
            if (IsExpired(document)) return "Expired";

            int daysToAction = GetDaystoAction(document); 
            if (daysToAction <= 14) return "Critical";
            if (daysToAction <= 30) return "Warning";
            return "Safe";
        }

        public static bool IsExpired(Document document)
        {
            return document.ExpiryDate < DateTime.Now;
        }

        public static List<Document> GetCriticalDocuments()
        {
            try {
                DataTable dt = DocumentDAL.GetCriticalDocuments(); 
                List<Document> alldocs = MapDataTabletoDocumentList(dt);
                List<Document> criticalDocs = new List<Document>();
                foreach(var docs in alldocs)
                {
                    string alertLevel = GetAlertLevel(docs);
                    if(alertLevel == "Critical" || alertLevel == "Expired")
                    {
                        criticalDocs.Add(docs);
                    }
                }
                return criticalDocs;
            } catch (Exception) {
                return new List<Document>();
            }
        }

        private static List<Document> MapDataTabletoDocumentList(DataTable dt)
        {
            List<Document> documents = new List<Document>();
            foreach (DataRow row in dt.Rows)
            {
                documents.Add(MapDataRowToDocument(row));
            }
            return documents;
        }

        private static Document MapDataRowToDocument(DataRow row)
        {
            var doc = new Document(
                Convert.ToInt32(row["document_id"]),
                row["document_no"]?.ToString() ?? string.Empty,
                row["issue_date"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["issue_date"]),
                row["expiry_date"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["expiry_date"]),
                Convert.ToInt32(row["type_id"]),
                Convert.ToInt32(row["client_id"])
            );
            if (row.Table.Columns.Contains("processing_days") && row["processing_days"] != DBNull.Value)
                doc.ProcessingDays = Convert.ToInt32(row["processing_days"]);
            if (row.Table.Columns.Contains("buffer_days") && row["buffer_days"] != DBNull.Value)
                doc.BufferDays = Convert.ToInt32(row["buffer_days"]);
            return doc;
        }

    }
}
