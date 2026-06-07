using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace visavault_g43.Models
{
    public class DeadlineRow
    {
       public string ClientName { get; set; }
       public string DocumentType { get; set; }
       public DateTime ExpiryDate { get; set; }
       public DateTime ActionDate { get; set; }
       public int DaysLeft { get; set; }
       public string AlertLevel { get; set; }
       public int ProcessingDays { get; set; }
       public int BufferDays { get; set; }

        public DeadlineRow(string clientName, string documentType, DateTime expiryDate, DateTime actionDate, int daysLeft, string alertLevel, int processingDays, int bufferDays = 30)
        {
            ClientName = clientName;
            DocumentType = documentType;
            ExpiryDate = expiryDate;
            ActionDate = actionDate;
            DaysLeft = daysLeft;
            AlertLevel = alertLevel;
            ProcessingDays = processingDays;
            BufferDays = bufferDays;
        }
    }

}