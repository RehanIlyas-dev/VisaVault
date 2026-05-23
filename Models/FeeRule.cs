using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace visavault_g43.Models
{
    public class FeeRule
    {
        public int FeeId { get; set; }
        public int TypeId { get; set; }
        public int CountryId { get; set; }
        public int FeeName { get; set; }
        public decimal? ProcessingFee { get; set; }
        public decimal? UrgentFee { get; set; }
        public decimal BaseFee { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public FeeRule(int FeeId, int TypeId, int CountryId, int FeeName, decimal? ProcessingFee, decimal? UrgentFee, decimal BaseFee, DateTime? ValidFrom, DateTime? ValidTo, DateTime CreatedAt, DateTime UpdatedAt)
        {
            this.FeeId = FeeId;
            this.TypeId = TypeId;
            this.CountryId = CountryId;
            this.FeeName = FeeName;
            this.ProcessingFee = ProcessingFee;
            this.UrgentFee = UrgentFee;
            this.BaseFee = BaseFee;
            this.ValidFrom = ValidFrom;
            this.ValidTo = ValidTo;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
        }
    }
  
    }
