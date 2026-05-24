using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using visavault_g43; 
using visavault_g43.Models;   
using MySql.Data.MySqlClient;

namespace visavault_g43.DLL
{
    internal class DocumentDAL
    {
        private static  Database db = new Database();
        public static DataTable GetDocumentsByClient(int clientId)
        {
            string query = "SELECT d.document_id, d.client_id, c.client_name, d.document_no, d.type_id, dt.documenttype_name, d.issue_date, d.expiry_date " +
                "FROM document d " +
                "JOIN documenttype dt ON d.type_id = dt.documenttype_id " + 
                "JOIN client c ON c.client_id = d.client_id " +
                "WHERE c.client_id = @ClientId;";
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@ClientId", clientId)
            };
            return db.ExecuteQuery(query, parameters);
        }
        public static DataTable SearchDocuments(int clientId, string keyword)
        {
            string query = "SELECT d.document_id, c.client_id, c.client_name, d.document_no, dt.documenttype_name, d.expiry_date " +
                "FROM document d " +
                "JOIN documenttype dt ON d.type_id = dt.documenttype_id " +
                "JOIN client c ON c.client_id = d.client_id " +
                "WHERE c.client_id = @ClientId AND (d.document_no LIKE @Keyword OR dt.documenttype_name LIKE @Keyword);";
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@ClientId", clientId),
                new MySqlParameter("@Keyword", $"%{keyword}%")
            };
            return db.ExecuteQuery(query, parameters);
        }
        public static int DeleteDocument(int documentId)
        {
            string query = "DELETE FROM document WHERE document_id = @DocumentId";
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@DocumentId", documentId)
            };
            return db.ExecuteNonQuery(query, parameters); 
        }
        public static int InsertDocument(Document document)
        {
            string query = "INSERT INTO document (client_id, type_id, document_no, expiry_date,issue_date) " +
                "VALUES (@ClientId, @TypeId, @DocumentNo, @ExpiryDate, @IssueDate)";
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@ClientId", document.ClientId),
                new MySqlParameter("@TypeId", document.TypeId),
                new MySqlParameter("@DocumentNo", document.DocumentNo),
                new MySqlParameter("@ExpiryDate", document.ExpiryDate),
                new MySqlParameter("@IssueDate", document.IssueDate)
            };
            return db.ExecuteNonQuery(query, parameters);
        }
        public static int UpdateDocument(Document document)
        {
            string query = "UPDATE document SET client_id = @ClientId, type_id = @TypeId, document_no = @DocumentNo, expiry_date = @ExpiryDate, issue_date = @IssueDate " +
                "WHERE document_id = @DocumentId";
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@ClientId", document.ClientId),
                new MySqlParameter("@TypeId", document.TypeId),
                new MySqlParameter("@DocumentNo", document.DocumentNo),
                new MySqlParameter("@ExpiryDate", document.ExpiryDate),
                new MySqlParameter("@IssueDate", document.IssueDate),
                new MySqlParameter("@DocumentId", document.DocumentId)
            };
            return db.ExecuteNonQuery(query, parameters);
        }
        public static DataTable GetDocumentById(int documentId)
        {
            string query = "SELECT d.document_id, c.client_id, c.client_name, d.document_no, dt.documenttype_name, d.expiry_date, d.issue_date " +
                "FROM document d " +
                "JOIN documenttype dt ON d.type_id = dt.documenttype_id " +
                "JOIN client c ON c.client_id = d.client_id " +
                "WHERE d.document_id = @DocumentId;";
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@DocumentId", documentId)
            };
            return db.ExecuteQuery(query, parameters);
        }
        public static DataTable GetAllDocumentTypes()
        {
            string query = "SELECT documenttype_id, documenttype_name FROM documenttype";
            return db.ExecuteQuery(query);
        }
        public static bool IsDocumentLinkedToOpenCase(int documentId)
        {

            string query = "SELECT COUNT(*) FROM renewalcase rc JOIN renewalstage rs ON rc.currentstage_id = rs.stage_id " +
               "WHERE rc.document_id = @DocumentId AND rs.stage_name != 'Completed' AND rs.stage_name != 'Rejected';"; // FIXED: Space before second AND
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@DocumentId", documentId)
            };
            int result=Convert.ToInt32(db.ExecuteScalar(query, parameters));
            return result > 0;
        }
        public static DataTable GetCriticalDocuments()
        {
            
            string query = @"
                SELECT 
                    d.document_id, 
                    c.client_id, 
                    c.client_name, 
                    d.document_no, 
                    dt.documenttype_name, 
                    d.expiry_date,
                    DATEDIFF(d.expiry_date, CURDATE()) AS days_left, 
                    DATE_ADD(CURDATE(), INTERVAL (d.processing_days + d.buffer_days) DAY) AS action_date,
                    'Critical' AS alert_status
                FROM document d 
                JOIN documenttype dt ON d.type_id = dt.documenttype_id 
                JOIN client c ON c.client_id = d.client_id
                WHERE d.expiry_date >= CURDATE() 
                  AND DATEDIFF(d.expiry_date, CURDATE()) <= (d.processing_days + d.buffer_days);";

          
            return db.ExecuteQuery(query);
        }
    }

}
