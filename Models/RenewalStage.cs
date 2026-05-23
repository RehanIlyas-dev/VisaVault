using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace visavault_g43.Models
{
    public class RenewalStage
    {
        public int StageId { get; set; }
        public string StageName { get; set; }
        public int StageNo { get; set; }

        public RenewalStage(int StageId, string StageName, int StageNo)
        {
            this.StageId = StageId;
            this.StageName = StageName;
            this.StageNo = StageNo;
        }
    }

    }
