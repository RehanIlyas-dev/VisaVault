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
