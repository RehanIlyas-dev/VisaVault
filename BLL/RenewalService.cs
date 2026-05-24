using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using visavault_g43.DLL;
using visavault_g43.Models;

namespace visavault_g43.BLL
{
    public class RenewalService
    {
        // Returns all renewal cases using the DAL and maps rows to model objects
        public static List<RenewalCase> GetAllCases(string statusFilter = "All", int clientId = 0)
        {
            DataTable dt = RenewalDAL.GetAllCases(statusFilter, clientId);
            if (dt == null) return new List<RenewalCase>();
            return dt.AsEnumerable().Select(r => MapDataRowToCase(r)).ToList();
        }

        // Returns a single case by ID
        public static RenewalCase GetCaseById(int caseId)
        {
            if (caseId <= 0) return null;
            DataTable dt = RenewalDAL.GetRenewalCaseById(caseId);
            if (dt == null || dt.Rows.Count == 0) return null;
            return MapDataRowToCase(dt.Rows[0]);
        }

        // Opens a new renewal case if none already exists for the document
        public static ValidationResult OpenCase(int clientId, int documentId, int openedByUserId)
        {
            if (clientId <= 0 || documentId <= 0 || openedByUserId <= 0)
                return ValidationResult.Failure("Client ID, Document ID and OpenedByUserId are required.");

            if (RenewalDAL.HasOpenCaseForDocument(documentId))
                return ValidationResult.Failure("An open case already exists for this document.");

            DataTable stages = RenewalDAL.GetAllStages();
            if (stages == null || stages.Rows.Count == 0)
                return ValidationResult.Failure("No stages defined in the system.");

            int initialStageId = Convert.ToInt32(stages.Rows[0]["stage_id"]);
            int newCaseId = RenewalDAL.InsertCase(clientId, documentId, openedByUserId, initialStageId);
            if (newCaseId > 0)
            {
                RenewalDAL.InsertStageLog(newCaseId, initialStageId, openedByUserId, "Case opened");
                return ValidationResult.Success("Case opened successfully.");
            }
            return ValidationResult.Failure("Failed to open case.");
        }

        // Advances the stage of a case
        public static ValidationResult AdvanceStage(int caseId, int newStageId, int changedByUserId, string remarks)
        {
            var current = GetCaseById(caseId);
            if (current == null) return ValidationResult.Failure("Case not found.");
            if (!CanUserAdvance(changedByUserId, caseId)) return ValidationResult.Failure("User not permitted to advance case.");
            if (!IsOpen(current)) return ValidationResult.Failure("Case is not open.");
            if (!IsValidStage(newStageId)) return ValidationResult.Failure("Invalid target stage.");

            int rows = RenewalDAL.UpdateCaseStage(caseId, newStageId, changedByUserId);
            if (rows > 0)
            {
                RenewalDAL.InsertStageLog(caseId, newStageId, changedByUserId, remarks ?? string.Empty);
                return ValidationResult.Success("Case advanced successfully.");
            }
            return ValidationResult.Failure("Failed to advance case.");
        }

        // Returns list of stages
        public static List<RenewalStage> GetAllStages()
        {
            var dt = RenewalDAL.GetAllStages();
            var list = new List<RenewalStage>();
            if (dt == null) return list;
            return dt.AsEnumerable().Select(row => new RenewalStage(
                row.Field<int?>("stage_id") ?? 0,
                row.Field<string>("stage_name") ?? string.Empty,
                row.Field<int?>("stage_no") ?? 0
            )).ToList();
            
        }

        // Returns stage logs for a case
        public static List<RenewalStageLog> GetStageLog(int caseId)
        {
            var dt = RenewalDAL.GetStageLog(caseId);
            var list = new List<RenewalStageLog>();
            if (dt == null) return list;
            return dt.AsEnumerable().Select(row => new RenewalStageLog(
                row.Field<int?>("log_id") ?? 0,
                row.Field<int?>("changed_by_user_id") ?? 0,
                row.Field<int?>("renewalcase_id") ?? 0,
                row.Field<int?>("stage_id") ?? 0,
                row.Field<DateTime?>("log_date") ?? DateTime.MinValue,
                row.Field<string>("remarks") ?? string.Empty
            )).ToList();
        }

        // Returns documents for a case
        public static List<Document> GetCaseDocuments(int caseId)
        {
            var dt = RenewalDAL.GetCaseDocuments(caseId);
            var list = new List<Document>();
            if (dt == null) return list;
            return dt.AsEnumerable().Select(row => new Document(
                row.Field<int?>("document_id") ?? 0,
                row.Field<string>("document_no") ?? string.Empty,
                row.Field<DateTime?>("issue_date") ?? DateTime.MinValue,
                row.Field<DateTime?>("expiry_date") ?? DateTime.MinValue,
                row.Field<int?>("type_id") ?? 0,
                row.Field<int?>("client_id") ?? 0
            )).ToList();
        }

        // check if the case is overdue (simple heuristic: days since created greater than 30)
        public static bool IsOverdue(RenewalCase rc)
        {
            if (rc == null) return false;
            return (DateTime.Now - rc.CreatedAt).TotalDays > 30;
        }

        // check if the case is open (not in a terminal stage)
        public static bool IsOpen(RenewalCase rc)
        {
            if (rc == null) return false;
            var stages = RenewalDAL.GetAllStages();
            if (stages == null) return true;
            foreach (DataRow row in stages.Rows)
            {
                if (row.Table.Columns.Contains("stage_id") && row["stage_id"] != DBNull.Value && Convert.ToInt32(row["stage_id"]) == rc.CurrentStageId)
                {
                    if (row.Table.Columns.Contains("is_terminal") && row["is_terminal"] != DBNull.Value)
                        return !Convert.ToBoolean(row["is_terminal"]);
                    return true;
                }
            }
            return true;
        }

        // Returns the number of active cases using DAL
        public static int GetActiveCaseCount()
        {
            return RenewalDAL.GetActiveCaseCount();
        }

        public static bool CanUserAdvance(int userId, int caseId)
        {
            // placeholder for permission check - expand as needed
            return userId > 0;
        }

        public static bool IsValidStage(int stageId)
        {
            var stages = RenewalDAL.GetAllStages();
            if (stages == null) return false;
            foreach (DataRow row in stages.Rows)
            {
                if (row.Table.Columns.Contains("stage_id") && row["stage_id"] != DBNull.Value && Convert.ToInt32(row["stage_id"]) == stageId)
                    return true;
            }
            return false;
        }

        private static RenewalCase MapDataRowToCase(DataRow row)
        {
            return new RenewalCase(
                row.Field<int?>("renewalcase_id") ?? 0,
                row.Field<int?>("currentstage_id") ?? 0,
                row.Field<int?>("user_id") ?? 0,
                row.Field<int?>("document_id") ?? 0,
                row.Field<DateTime?>("created_at") ?? DateTime.MinValue,
                row.Field<DateTime?>("updated_at") ?? DateTime.MinValue
            );
        }
    }
}