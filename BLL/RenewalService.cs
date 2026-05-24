using Org.BouncyCastle.Crypto.Prng.Drbg;
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
    public class RenewalService
    {
        // Method to map DataRow to RenewalCase object
        public static List<RenewalRule> GetAllCases(string StatusFilter = "All", int clientId = 0)
        {
            DataTable dt = RenewalDAL.GetAllRenewalCases(StatusFilter, clientId); // Assuming RenewalDAL has a method to get all renewal cases based on status filter and client ID
            List<RenewalCase> list = new List<RenewalCase>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapDataRowtoCase(row));
            }
            return list;
        }

        // Returns a single case by ID
        public static RenewalCase GetCaseById(int CaseId)
        {
            DataTable dt = RenewalDAL.GetRenewalCaseById(CaseId);
            if (dt.Rows.Count == 0) return null;
            return MapDataRowtoCase(dt.Rows[0]);
        }

        // This method opens a new renewal case for a given client and document type, returning a ValidationResult indicating success or failure along with an appropriate message.
        public static ValidationResult OpenCase(int ClientId, int DocumentTypeId, int OpenByUserId)
        {
            if (ClientId == 0 || DocumentTypeId == 0 || OpenByUserId == 0)
                return ValidationResult.Failure("Client ID, Document Type ID, and Open By User ID must be provided.");
            if (RenewalDAL.HasOpenCaseForDocument(documentId))
                return ValidationResult.Failure("An open case already exists for this document.");

            DataTable stageDt = RenewalDAL.GetAllStages();
            if (stageDt.Rows.Count == 0)
                return ValidationResult.Failure("No stages defined in the system.");
            int intialStageId = Convert.ToInt32(stageDt.Rows[0]["Renewal_Stage_Id"]);
            int newCaseId = RenewalDAL.InsertCase(ClientId, DocumentTypeId, OpenByUserId, intialStageId);
            if (newCaseId > 0)
            {
                RenewalDAL.InsertStageLog(newCaseId, intialStageId, OpenByUserId);
                AuditService.Log("renewalcase", newCaseId, "currentstage_id", " " initialStageId.ToString(), "INSERT", openedByUserId);
                return ValidationResult.Success("Case opened successfully.");
            }
            return ValidationResult.Failure("Failed to open case.");
        }

        // This method advances the stage of an existing renewal case, ensuring that the user has permission to perform the action, the case is currently open, and the stage transition is valid. It returns a ValidationResult indicating success or failure along with an appropriate message.
        public static ValidationResult AdvanceStage(int CaseId, int NewStageId, int changedByUserId, string remarks)
        {
            RenewalCase currentcase = GetCaseById(CaseId);
            if (currentcase == null)
                return ValidationResult.Failure("Case not found.");
            if (!CanUserAdvance(changedByUserId, CaseId))
                return ValidationResult.Failure("User does not have permission to advance this case.");
            if (!IsOpen(currentcase))
                return ValidationResult.Failure("Case is not open.");
            if (!isValidTransition(CaseId, newStageId))
                return ValidationResult.Failure("Invalid stage transition.");

            string oldStageStr = currentcase.CurrentStageId.ToString();
            int rowsAffected = RenewalDAL.UpdateCaseStage(CaseId, NewStageId, changedByUserId);
            if (rowsAffected > 0)
            {
                RenewalDAL.InsertStageLog(CaseId, NewStageId, changedByUserId, remarks);
                AuditService.Log("renewalcase", CaseId, "currentstage_id", oldStageStr, NewStageId.ToString(), "UPDATE", changedByUserId);
                return ValidationResult.Success("Case advanced successfully.");
            }
            return ValidationResult.Failure("Failed to advance case.");
        }

        // Helper method to map DataRow to RenewalCase object
        public static List<RenewalCase> GetAllCases()
        {
            DataTable dt = RenewalDAL.GetAllRenewalCases();
            List<RenewalCase> list = new List<RenewalCase>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new RenewalStage
                {
                    StageId = Convert.ToInt32(row["StageId"]),
                    StageName = row["StageName"].ToString(),
                    StageNo = Convert.ToInt32(row["StageNo"])
                    IsTerminal = Convert.ToBoolean(row["IsTerminal"])
                });
            }
            return list;
        }

        // Helper method to map DataRow to RenewalCase object
        public static List<RenewalStageLog> GetStageLog(int CaseId)
        {
            DataTable dt = RenewalDAL.GetStageLog(CaseId);
            List<RenewalStageLog> list = new List<RenewalStageLog>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new RenewalStageLog
                {
                    LogId = Convert.ToInt32(row["LogId"]),
                    CaseId = Convert.ToInt32(row["CaseId"]),
                    StageId = Convert.ToInt32(row["StageId"]),
                    ChangedByUserId = Convert.ToInt32(row["ChangedByUserId"]),
                    Remarks = row["Remarks"].ToString(),
                    LogDate = Convert.ToDateTime(row["LogDate"])
                });
            }
            return list;
        }

        // Helper method to map DataRow to RenewalCase object
        public static List<Document> GetCaseDocuments(int caseId)
        {
            DataTable dt = RenewalDAL.GetCaseDocuments(caseId);
            List<Document> list = new List<Document>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Document
                {
                    DocumentId = Convert.ToInt32(row["DocumentId"]),
                    DocumentNo = row["DocumentNo"].ToString(),
                    TypeID = Convert.ToInt32(row["TypeID"]),
                    IssueDate = Convert.ToDateTime(row["IssueDate"]),
                    ExpiryDate = Convert.ToDateTime(row["ExpiryDate"]),
                    ClientId = Convert.ToInt32(row["ClientId"])
                });
            }
            return list;
        }
        // check if the case is overdue
        public static bool IsOverdue(RenewalCase rc)
        {
            return GetDaysInCurrentStage(rc) > 30;
        }
        // check if the case is open (not in a terminal stage)
        public bool isOpen(RenewalCase rc)
        {
            DataTable stagesDt = RenewalDAL.GetAllStages();
            foreach (DataRow row in stagesDt.Rows)
            {
                if (Convert.ToInt32(row["renewal_stage_id"]) == rc.CurrentStageId) {
                    return !Convert.ToBoolean(row["is_terminal"]);
                }
            }
            return true;
        }

        // --> Helper Functions
        public static int GetActiveCaseCount()
        {
            return RenewalDAL.GetActiveCaseCount();
        }

        public static bool CanUserAdvance(int userId, int caseId)
        {
            return userId > 0;
        }

        public static bool isValidTransition(int caseId, int newStageId)
        {
            DataTable dt = RenewalDAL.GetAllStages();
            foreach (DataRow row in dt.Rows)
            {
                if (Convert.ToInt32(row["RenewalStageId"]) == newStageId)
                    return true;
            }
            return false;
        }
        private static RenewalCase MapDataRowtoCase(DataRow row)
        {
            return new RenewalCase
            {
                CaseId = Convert.ToInt32(row["CaseId"]),
                ClientId = Convert.ToInt32(row["ClientId"]),
                DocumentTypeId = Convert.ToInt32(row["DocumentTypeId"]),
                OpenedByUserId = Convert.ToInt32(row["OpenedByUserId"]),
                CurrentStageId = Convert.ToInt32(row["CurrentStageId"]),
                OpenDate = Convert.ToDateTime(row["OpenDate"])
            };
        }
    }
}