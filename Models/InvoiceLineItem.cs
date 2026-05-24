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
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public InvoiceLineItem()
        {
        }

        public InvoiceLineItem(int ItemID, int InvoiceID, int FeeId, int Quantity, decimal UnitPrice, decimal TotalPrice)
        {
            this.ItemID = ItemID;
            this.InvoiceID = InvoiceID;
            this.FeeId = FeeId;
            this.Quantity = Quantity;
            this.UnitPrice = UnitPrice;
            this.TotalPrice = TotalPrice;
            this.Amount = TotalPrice;
        }
    }
  
    }
