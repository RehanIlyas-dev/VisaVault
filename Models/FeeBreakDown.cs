using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace visavault_g43.Models
{
    public class FeeBreakdown
    {
        public decimal BaseFee { get; set; }
        public decimal ProcessingFee { get; set; }
        public decimal UrgencyFee { get; set; }
        public decimal TotalFee { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public bool IsActive { get; set; }

        // Parameterless constructor to allow property-based initialization
        public FeeBreakdown()
        {
            BaseFee = 0m;
            ProcessingFee = 0m;
            UrgencyFee = 0m;
            TotalFee = 0m;
            ValidFrom = DateTime.MinValue;
            ValidTo = DateTime.MinValue;
            IsActive = false;
        }

        public FeeBreakdown(decimal baseFee, decimal processingFee, decimal urgencyFee, decimal totalFee, DateTime validFrom, DateTime validTo, bool isActive)
        {
            BaseFee = baseFee;
            ProcessingFee = processingFee;
            UrgencyFee = urgencyFee;
            TotalFee = totalFee;
            ValidFrom = validFrom;
            ValidTo = validTo;
            IsActive = isActive;
        }
    }
}
