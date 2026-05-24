using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using visavault_g43;
using System.Text;
using System.Threading.Tasks;

namespace visavault_g43.DLL
{
    internal class DependencyDAL
    {
        static Database db = new Database();
        public static DataTable GetDependenciesForType(int documentTypeId)
        {
            string query = "SELECT requireddocumenttype_id FROM documentdependency WHERE documenttype_id = @DocumentTypeId;";

            MySqlParameter[] parameters = new MySqlParameter[]
            {
        new MySqlParameter("@DocumentTypeId", documentTypeId)
            };
            return db.ExecuteQuery(query, parameters);
        }

        public static DataTable GetRequiredDocumentTypes(int documentTypeId)
        {
            string query = @" SELECT dt.documenttype_id, dt.documenttype_name 
                            FROM documenttype dt JOIN documentdependency dd ON dt.documenttype_id = dd.requireddocumenttype_id 
                            WHERE dd.documenttype_id = @DocumentTypeId;";

            MySqlParameter[] parameters = new MySqlParameter[]
            {
        new MySqlParameter("@DocumentTypeId", documentTypeId)
            };
            return db.ExecuteQuery(query, parameters);
        }
        public static bool ClientHasDocument(int clientId, int requiredDocumentTypeId)
        {

            string query = @"
                SELECT COUNT(*) 
                FROM document 
                WHERE client_id = @ClientId 
                  AND type_id = @RequiredDocumentTypeId;";

            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@ClientId", clientId),
                new MySqlParameter("@RequiredDocumentTypeId", requiredDocumentTypeId)
            };

            int result = Convert.ToInt32(db.ExecuteScalar(query, parameters));
            return result > 0;
        }

        public static bool ClientHasValidDocument(int clientId, int requiredDocumentTypeId)
        {

            string query = @"
        SELECT COUNT(*) 
        FROM document 
        WHERE client_id = @ClientId 
          AND type_id = @RequiredTypeId 
          AND expiry_date >= CURDATE();";

            MySqlParameter[] parameters = new MySqlParameter[]
            {
        new MySqlParameter("@ClientId", clientId),
        new MySqlParameter("@RequiredTypeId", requiredDocumentTypeId)
            };

            object result = db.ExecuteScalar(query, parameters);
            int count = Convert.ToInt32(result);

            return count > 0;
        }
        public static DataTable GetAllDependencies()
        {
            string query = @"SELECT 
                            dd.documenttype_id,
                            dt1.documenttype_name AS target_document_type,
                            dd.requireddocumenttype_id,
                            dt2.documenttype_name AS prerequisite_document_type
                            FROM documentdependency dd
                            JOIN documenttype dt1 ON dd.documenttype_id = dt1.documenttype_id
                            JOIN documenttype dt2 ON dd.requireddocumenttype_id = dt2.documenttype_id
                            ORDER BY target_document_type ASC;";

            return db.ExecuteQuery(query);
        }

    }
}