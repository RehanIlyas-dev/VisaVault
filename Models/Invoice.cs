using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace visavault_g43.Models
{
   public class Invoice
    {
        public int InvoiceID { get; set; }
        public int CaseId { get; set; }
        public int ClientId { get; set; }
        public List<InvoiceLineItem> LineItems { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public decimal Amount { get; set; }
        public Invoice()
        {
            LineItems = new List<InvoiceLineItem>();
            Status = string.Empty;
            CreatedAt = DateTime.MinValue;
            UpdatedAt = DateTime.MinValue;
            DueDate = DateTime.MinValue;
            Amount = 0m;
        }

        public Invoice(int InvoiceID, int CaseId, int ClientId, DateTime DueDate, string Status, DateTime CreatedAt, DateTime UpdatedAt, decimal Amount)
        {
            this.InvoiceID = InvoiceID;
            this.CaseId = CaseId;
            this.ClientId = ClientId;
            this.DueDate = DueDate;
            this.Status = Status;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
            this.Amount = Amount;
            this.LineItems = new List<InvoiceLineItem>();
        }
    }
}
