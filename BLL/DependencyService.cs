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
    public static class DependencyService 
    {
        // This method checks the dependencies for a given client and document type, returning a list of results indicating the status of each required document type.
        public static List<DepencdencyCheckResult> RunDependencyCheck(int clientId, int DocumentType)
        {
            List<DependecnyCheckResult> summaryList = new List<DependecnyCheckResult>();
            DataTable dependencyDetails = DepencdencyDAL.GetRequiredDocumentTypes(documentTypeId);

            foreach (DataRow row in dependencyDetails.Rows)
            {
                int reqTypeId = Convert.ToInt32(row["RequiredDocumentTypeId"]);
                string reqTypeName = row["RequiredDocumentTypeName"].ToString();
                bool exists = CheckDocumentExists(clientId, reqTypeId);
                bool isValid = IsDocumentValid(clientId, reqTypeId);

                string statusValue = "Missing";
                if(exists)
                    statusValue = isValid ? "Ok" : "Expired";
                summaryList.Add(new DependecnyCheckResult
                {
                    RequiredDocumentType = reqTypeName,
                    Exists = exists,
                    IsValid = isValid,
                    Status = statusValue
                });
            }
            return summaryList;
        }

        // This method retrieves the list of document dependencies for a specific document type, returning a list of DocumentDependency objects.
        public static List<DocumentDependency> GetDependenciesForType(int documentTypeId)
        {
            DataTable dt = DependencyDAL.GetDependenciesFORtype(documentTypeId);
            List<DocumentDependency> dependencies = new List<DocumentDependency>();

            foreach (DataRow row in dt.Rows)
            {
                dependencies.Add(new DocumentDependency
                {
                    DocumentTypeId = Convert.ToInt32(row["DocumentTypeId"]),
                    RequiredDocumentTypeId = Convert.ToInt32(row["RequiredDocumentTypeId"])
                });
            }

            return dependencies;
        }

        private static bool CheckDocumentExists(int clientId, int documentTypeId)
        {
            // This method checks if a document of a specific type exists for a given client.
            return DocumentDAL.ClientHasDocument(clientId, documentTypeId);
        }

        private static bool isDocumentValid(int clientId, int documentTypeId)
        {
            // This method checks if a document of a specific type is valid (not expired) for a given client.
            return DocumentDAL.ClientHasValidDocument(clientId, documentTypeId);
        }

}
