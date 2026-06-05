using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace visavault_g43.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public decimal? AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public int InvoiceId { get; set; }
        public int UserId { get; set; }
        public Payment()
        {
        }

        public Payment(int PaymentId, int InvoiceId, decimal? AmountPaid, DateTime PaymentDate, string PaymentMethod, int ReceivedBy)
        {
            this.PaymentId = PaymentId;
            this.InvoiceId = InvoiceId;
            this.AmountPaid = AmountPaid;
            this.PaymentDate = PaymentDate;
            this.PaymentMethod = PaymentMethod;
            this.UserId = ReceivedBy;
        }
    }

}
