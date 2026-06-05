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
        public static List<DependencyCheckResult> RunDependencyCheck(int clientId, int documentTypeId)
        {
            try {
                var summaryList = new List<DependencyCheckResult>();
                DataTable dependencyDetails = DependencyDAL.GetRequiredDocumentTypes(documentTypeId);

                foreach (DataRow row in dependencyDetails.Rows)
                {
                    int reqTypeId = row.Field<int>("documenttype_id");
                    string reqTypeName = row.Field<string>("documenttype_name") ?? string.Empty;

                    bool exists = DependencyDAL.ClientHasDocument(clientId, reqTypeId);
                    bool isValid = DependencyDAL.ClientHasValidDocument(clientId, reqTypeId);

                    string statusValue = "Missing";
                    if (exists) statusValue = isValid ? "Ok" : "Expired";

                    summaryList.Add(new DependencyCheckResult(reqTypeName, exists, isValid, statusValue));
                }

                return summaryList;
            } catch (Exception) {
                return new List<DependencyCheckResult>();
            }
        }

        public static List<DocumentDependency> GetDependenciesForType(int documentTypeId)
        {
            try {
                DataTable dt = DependencyDAL.GetDependenciesForType(documentTypeId);
                var dependencies = new List<DocumentDependency>();

                foreach (DataRow row in dt.Rows)
                {
                    int requiredId = row.Field<int>("requireddocumenttype_id");
                    dependencies.Add(new DocumentDependency(0, documentTypeId, requiredId));
                }

                return dependencies;
            } catch (Exception) {
                return new List<DocumentDependency>();
            }
        }
    }
}
