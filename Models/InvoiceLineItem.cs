using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace visavault_g43.Models
{
    public class InvoiceLineItem
    {
        public int ItemID { get; set; }
        public int InvoiceID { get; set; }
        public decimal Amount { get; set; }
        public int FeeId { get; set; }

        public InvoiceLineItem(int ItemID, int InvoiceID, string Description, int Quantity, decimal UnitPric, decimal totalPrice)
        {
            this.ItemID = ItemID;
            this.InvoiceID = InvoiceID;
            this.Amount = Amount;
            this.FeeId = FeeId;
        }
    }
  
    }
