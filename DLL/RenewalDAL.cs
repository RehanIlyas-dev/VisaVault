using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using visavault_g43; 
using System.Threading.Tasks;

namespace visavault_g43.DLL
{
    internal class RenewalDAL
    {
         static Database db = new Database();

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
        public static DataTable GetCaseById(int caseId)
        {
            string query = "SELECT rc.renewalcase_id, rc.currentstage_id, rs.stage_name, rs.stage_no, rc.user_id, rc.document_id, " +
                "rc.client_id, rc.created_at, rc.updated_at FROM renewalcase rc JOIN renewalstage rs ON rc.currentstage_id = rs.stage_id" +
                " WHERE rc.renewalcase_id = @CaseId;";

            MySqlParameter[] parameters = new MySqlParameter[]
            {
        new MySqlParameter("@CaseId", caseId)
            };
            return db.ExecuteQuery(query, parameters);
        }
        public static int InsertCase(int clientId, int documentId, int currentStageId, int openedByUserId)
        {
            string query = "INSERT INTO renewalcase (client_id, document_id, currentstage_id, user_id) " +
                "VALUES (@ClientId, @DocumentId, @CurrentStageId, @UserId);";

            MySqlParameter[] parameters = new MySqlParameter[]
            {
        new MySqlParameter("@ClientId", clientId),
        new MySqlParameter("@DocumentId", documentId),
        new MySqlParameter("@CurrentStageId", currentStageId),
        new MySqlParameter("@UserId", openedByUserId)
            };
            return db.ExecuteNonQuery(query, parameters);
        }
        public static int UpdateCaseStage(int caseId, int newStageId, int changedByUserId)
        {
            string query = "UPDATE renewalcase SET currentstage_id = @NewStageId, user_id = @UserId WHERE renewalcase_id = @CaseId;";

            MySqlParameter[] parameters = new MySqlParameter[]
            {
        new MySqlParameter("@NewStageId", newStageId),
        new MySqlParameter("@UserId", changedByUserId),
        new MySqlParameter("@CaseId", caseId)
            };
            return db.ExecuteNonQuery(query, parameters);
        }
        public static int AdvanceCaseStage(int caseId, int changedByUserId, string remarks)
        {
            string query = "CALL sp_AdvanceRenewalStage(@CaseId, @UserId, @Remarks);";

            MySqlParameter[] parameters = new MySqlParameter[]
            {
        new MySqlParameter("@CaseId", caseId),
        new MySqlParameter("@UserId", changedByUserId),
        new MySqlParameter("@Remarks", remarks)
            };
            return db.ExecuteNonQuery(query, parameters);
        }
        public static int InsertStageLog(int caseId, int stageId, int changedByUserId, string remarks)
        {
            string query = "INSERT INTO renewalstagelog (renewalcase_id, currentstage_id, user_id, remarks) VALUES (@CaseId, @StageId, @UserId, @Remarks);";

            MySqlParameter[] parameters = new MySqlParameter[]
            {
        new MySqlParameter("@CaseId", caseId),
        new MySqlParameter("@StageId", stageId),
        new MySqlParameter("@UserId", changedByUserId),
        new MySqlParameter("@Remarks", remarks)
            };
            return db.ExecuteNonQuery(query, parameters);
        }
        public static DataTable GetAllStages()
        {
            string query = "SELECT stage_id, stage_name, stage_no, description FROM renewalstage ORDER BY stage_no ASC;";
            return db.ExecuteQuery(query);
        }
        public static DataTable GetStageLog(int caseId)
        {
            string query = "SELECT rsl.log_id, rsl.renewalcase_id, rsl.currentstage_id, rs.stage_name, rs.stage_no, rsl.user_id, " +
                "rsl.remarks, rsl.updated_at FROM renewalstagelog rsl JOIN renewalstage rs ON rsl.currentstage_id = rs.stage_id " +
                "WHERE rsl.renewalcase_id = @CaseId ORDER BY rsl.updated_at DESC;";

            MySqlParameter[] parameters = new MySqlParameter[]
            {
        new MySqlParameter("@CaseId", caseId)
            };
            return db.ExecuteQuery(query, parameters);
        }
        public static DataTable GetCaseDocuments(int caseId)
        {
            string query = "SELECT d.document_id, d.document_no, d.client_id, d.type_id, dt.documenttype_name, d.issue_date, d.expiry_date" +
                " FROM document d JOIN renewalcase rc ON d.document_id = rc.document_id " +
                "JOIN documenttype dt ON d.type_id = dt.documenttype_id WHERE rc.renewalcase_id = @CaseId;";

            MySqlParameter[] parameters = new MySqlParameter[]
            {
        new MySqlParameter("@CaseId", caseId)
            };
            return db.ExecuteQuery(query, parameters);
        }
        public static bool HasOpenCaseForDocument(int documentId)
        {
            string query = "SELECT COUNT(*) FROM renewalcase rc JOIN renewalstage rs ON rc.currentstage_id = rs.stage_id " +
                "WHERE rc.document_id = @DocumentId AND rs.stage_name NOT IN ('Completed', 'Rejected');";

            MySqlParameter[] parameters = new MySqlParameter[]
            {
        new MySqlParameter("@DocumentId", documentId)
            };
            return Convert.ToInt32(db.ExecuteScalar(query, parameters)) > 0;
        }
        public static int GetActiveCaseCount()
        {
            string query = "SELECT COUNT(*) FROM renewalcase rc JOIN renewalstage rs ON rc.currentstage_id = rs.stage_id " +
                "WHERE rs.stage_name NOT IN ('Completed', 'Rejected');";
            return Convert.ToInt32(db.ExecuteScalar(query));
        }

    }
}
