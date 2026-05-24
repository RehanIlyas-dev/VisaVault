using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace visavault_g43.DLL
{
    internal class RenewalDAL
    {
        private static Database db = new Database();

        public static DataTable GetAllCases(string statusFilter = "All", int clientId = 0)
        {
            string query = "SELECT rc.renewalcase_id, rc.currentstage_id, rs.stage_name, rs.stage_no, rc.user_id, rc.document_id, rc.client_id," +
                " rc.created_at, rc.updated_at FROM renewalcase rc JOIN renewalstage rs ON rc.currentstage_id = rs.stage_id " +
                "WHERE (@ClientId = 0 OR rc.client_id = @ClientId) AND (@StatusFilter = 'All' OR (@StatusFilter = 'Active'" +
                " AND rs.stage_name NOT IN ('Completed', 'Rejected')) OR (@StatusFilter = 'Closed' AND " +
                "rs.stage_name IN ('Completed', 'Rejected')) OR (rs.stage_name = @StatusFilter));";

            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@ClientId", clientId),
                new MySqlParameter("@StatusFilter", statusFilter)
            };

            return db.ExecuteQuery(query, parameters);
        }

        public static DataTable GetRenewalCaseById(int caseId)
        {
            string query = "SELECT rc.renewalcase_id, rc.currentstage_id, rs.stage_name, rs.stage_no, rc.user_id, rc.document_id, rc.client_id, rc.created_at, rc.updated_at " +
                "FROM renewalcase rc JOIN renewalstage rs ON rc.currentstage_id = rs.stage_id WHERE rc.renewalcase_id = @CaseId";
            MySqlParameter[] parameters = new MySqlParameter[] { new MySqlParameter("@CaseId", caseId) };
            return db.ExecuteQuery(query, parameters);
        }

        public static bool HasOpenCaseForDocument(int documentId)
        {
            string query = "SELECT COUNT(*) FROM renewalcase rc JOIN renewalstage rs ON rc.currentstage_id = rs.stage_id " +
                "WHERE rc.document_id = @DocumentId AND rs.stage_name NOT IN ('Completed','Rejected')";
            MySqlParameter[] parameters = new MySqlParameter[] { new MySqlParameter("@DocumentId", documentId) };
            object result = db.ExecuteScalar(query, parameters);
            if (result == null || result == DBNull.Value) return false;
            return Convert.ToInt32(result) > 0;
        }

        public static DataTable GetAllStages()
        {
            string query = "SELECT stage_id, stage_name, stage_no, is_terminal FROM renewalstage ORDER BY stage_no";
            return db.ExecuteQuery(query, null);
        }

        public static int InsertCase(int clientId, int documentId, int openedByUserId, int initialStageId)
        {
            string insert = "INSERT INTO renewalcase (client_id, document_id, user_id, currentstage_id, created_at, updated_at) " +
                "VALUES (@ClientId, @DocumentId, @UserId, @StageId, NOW(), NOW())";
            MySqlParameter[] parameters = new MySqlParameter[] {
                new MySqlParameter("@ClientId", clientId),
                new MySqlParameter("@DocumentId", documentId),
                new MySqlParameter("@UserId", openedByUserId),
                new MySqlParameter("@StageId", initialStageId)
            };
            int rows = db.ExecuteNonQuery(insert, parameters);
            if (rows <= 0) return 0;
            // best-effort to get inserted id
            string scalarQuery = "SELECT MAX(renewalcase_id) FROM renewalcase WHERE client_id=@ClientId AND document_id=@DocumentId";
            object obj = db.ExecuteScalar(scalarQuery, new MySqlParameter[] { new MySqlParameter("@ClientId", clientId), new MySqlParameter("@DocumentId", documentId) });
            return obj == null || obj == DBNull.Value ? 0 : Convert.ToInt32(obj);
        }

        public static int InsertStageLog(int caseId, int stageId, int changedByUserId, string remarks = "")
        {
            string insert = "INSERT INTO renewalstagelog (renewalcase_id, stage_id, changed_by_user_id, remarks, log_date) " +
                "VALUES (@CaseId, @StageId, @UserId, @Remarks, NOW())";
            MySqlParameter[] parameters = new MySqlParameter[] {
                new MySqlParameter("@CaseId", caseId),
                new MySqlParameter("@StageId", stageId),
                new MySqlParameter("@UserId", changedByUserId),
                new MySqlParameter("@Remarks", remarks ?? string.Empty)
            };
            return db.ExecuteNonQuery(insert, parameters);
        }

        public static int UpdateCaseStage(int caseId, int newStageId, int changedByUserId)
        {
            string update = "UPDATE renewalcase SET currentstage_id = @StageId, updated_at = NOW() WHERE renewalcase_id = @CaseId";
            MySqlParameter[] parameters = new MySqlParameter[] {
                new MySqlParameter("@StageId", newStageId),
                new MySqlParameter("@CaseId", caseId)
            };
            return db.ExecuteNonQuery(update, parameters);
        }

        public static DataTable GetStageLog(int caseId)
        {
            string query = "SELECT log_id, renewalcase_id, stage_id, changed_by_user_id, remarks, log_date FROM renewalstagelog WHERE renewalcase_id = @CaseId ORDER BY log_date DESC";
            return db.ExecuteQuery(query, new MySqlParameter[] { new MySqlParameter("@CaseId", caseId) });
        }

        public static DataTable GetCaseDocuments(int caseId)
        {
            string query = "SELECT d.document_id, d.document_no, d.type_id, d.issue_date, d.expiry_date, d.client_id " +
                "FROM document d JOIN renewalcase rc ON rc.document_id = d.document_id WHERE rc.renewalcase_id = @CaseId";
            return db.ExecuteQuery(query, new MySqlParameter[] { new MySqlParameter("@CaseId", caseId) });
        }

        public static int GetActiveCaseCount()
        {
            string query = "SELECT COUNT(*) FROM renewalcase rc JOIN renewalstage rs ON rc.currentstage_id = rs.stage_id WHERE rs.stage_name NOT IN ('Completed','Rejected')";
            object obj = db.ExecuteScalar(query, null);
            return obj == null || obj == DBNull.Value ? 0 : Convert.ToInt32(obj);
        }
    }
}
