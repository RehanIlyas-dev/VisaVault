using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace visavault_g43.Models
{
    public class RenewalCase
    {
        public int RenewalCaseID { get; set; }
        public int CurrentStageId { get; set; }
        public int UserId { get; set; }
        public int DocumentId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public RenewalCase(int RenewalCaseID, int CurrentStageId, int UserId, int DocumentId, DateTime CreatedAt, DateTime UpdatedAt)
        {
            this.RenewalCaseID = RenewalCaseID;
            this.CurrentStageId = CurrentStageId;
            this.UserId = UserId;
            this.DocumentId = DocumentId;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
        }
    }
 
}
