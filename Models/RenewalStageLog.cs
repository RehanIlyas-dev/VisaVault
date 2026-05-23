using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace visavault_g43.Models
{
    public class RenewalStageLog
    {
        public int LogID { get; set; }
        public int UserId { get; set; }
        public int RenewalCaseId { get; set; }
        public int CurrentStageId { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Remarks { get; set; }

        public RenewalStageLog(int LogID, int UserId, int RenewalCaseId, int CurrentStageId, DateTime UpdatedAt, string Remarks)
        {
            this.LogID = LogID;
            this.UserId = UserId;
            this.RenewalCaseId = RenewalCaseId;
            this.CurrentStageId = CurrentStageId;

            this.UpdatedAt = UpdatedAt;
            this.Remarks = Remarks;
        }
    }

    }
