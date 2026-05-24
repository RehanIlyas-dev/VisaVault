using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using visavault_g43.DLL;
using visavault_g43.Models;

namespace visavault_g43.BLL
{
    public class InvoiceService
    {
        // This method retrieves all invoices based on the provided client ID and status. It calls the DAL to get the data, then maps each DataRow to an Invoice object and returns a list of invoices.
        public static List<Invoice> GetAllInvoices(int clientId = 0, string status = "All")
        {
            DataTable dt = InvoiceDAL.GetAllInvoices(clientId, status);
            List<Invoice> invoices = new List<Invoice>();
            foreach(DataRow row in dt.Rows)
            {
                invoices.Add(MapDataRowToInvoice(row))
            }
            return invoices;
        }
        // This Method returns the single Invoice with its line items loaded
        public static Invoice GetInvoiceById(int invoiceId)
        {
            DataTable dt = InvoiceDAL.GetInvoiceById(invoiceId);
            if (dt.Rows.Count == 0) return null;
            Invoice Inv = MapDataRowToInvoice(dt.Rows[0]);
            Inv.LineItems = GetLineItems(invoiceId);
            return Inv;
        }

        // This Method returns line items for a invoice
        public static List<InvoiceLineItem> GetLineItems(int invoiceId)
        {
            DataTable dt = InvoiceDAL.GetLineItems(invoiceId);
            List<InvoiceLineItem> lineItems = new List<InvoiceLineItem>();
            foreach(DataRow row in dt.Rows)
            {
                lineItems.Add(new InvoiceLineItem
                {
                    ItemID = Convert.ToInt32(row["ItemID"]),
                    InvoiceID = Convert.ToInt32(row["InvoiceID"]),
                    Amount = Convert.ToDecimal(row["Amount"]),
                    FeeId = Convert.ToInt32(row["FeeId"])
                });
            }
            return lineItems;
        }
        
        // This method saves an invoice and its line items. It performs validation on the invoice and line items, calculates the total amount, and then calls the DAL to insert the invoice and line items into the database.
        public static ValidationResult SaveInvoice(Invoice invoice, List<InvoiceLineItem> lineItems)
        {
            if(invoice == null) return ValidationResult.Failure("Invoice cannot be null.");
            if(invoice.CaseId <= 0 || invoice.ClientId <= 0) return ValidationResult.Failure("Invoice must have a valid CaseId and ClientId.");
            if(invoice.DueDate == DateTime.MinValue) return ValidationResult.Failure("Invoice must have a valid DueDate.");
            if(lineItems == null || lineItems.Count == 0) return ValidationResult.Failure("Invoice must have at least one line item.");

            invoice.Status = "Unpaid";
            decimal runningTotal = 0;
            foreach (var item in lineItems)
            {
                if (item.Amount <= 0) return ValidationResult.Failure("Line item amounts must be greater than zero.");
                runningTotal += item.Amount;
            }
            invoice.Amount = runningTotal;

            int saveId = InvoiceDAL.InsertInvoice(invoice);
            if(saveId > 0)
            {
                foreach(var item in lineItems)
                {
                    item.InvoiceID = saveId;
                    InvoiceDAL.InsertInvoiceLineItem(item);
                }
                return ValidationResult.Success("Invoice saved successfully.");
            }
            return ValidationResult.Failure("Failed to save invoice.");
        }
        // This method records a payment for an invoice. It validates the payment details, checks that the payment amount does not exceed the invoice total, and then calls the DAL to insert the payment into the database.
        public static ValidationResult RecordPayment(Payment payment)
        {
            if(payment == null) return ValidationResult.Failure("Payment cannot be null.");
            if(payment.AmountPaid <= 0) return ValidationResult.Failure("Payment amount must be greater than zero.");

            ValidationResult amountCheck = ValidatePaymentAmount(payment.InvoiceId);
            if(!amountCheck.IsSuccess) return amountCheck;
            
            int newPaymnentId = InvoiceDAL.InsertPayment(payment);
            if(newPaymnentId > 0)
            {
                UpdateInvoiceStatus(payment.InvoiceId);
                AuditService.Log("payment", newPaymentId, "amount_paid", "", payment.AmountPaid.ToString(), "INSERT", payment.UserId);
                return ValidationResult.Success("Payment recorded successfully.");
            }
            return ValidationResult.Failure("Failed to record payment.");
        }
        
        // This Method Recalculates invoice.amount from all line items
        public static decimal ReCalculateTotalFromItems(int invoiceId)
        {
            List<InoviceLineItem> items = GetLineItems(invoiceId);
            decimal total = 0;
            foreach(var item in items)
            {
                total += item.Amount;
            }
            InvoiceDAL.UpdateInvoiceTotal(invoiceId, newTotal);
            UpdateInvoiceStatus(invoiceId);
            return total;
        }

        // This method updates invoice status based on payments state
        public static decimal GetBalance(int invoiceId)
        {
            Invoice inv = GetInvoiceById(invoiceId);
            if(inv == null) return 0;
            decimal totalPayments = InvoiceDAL.GetTotalPaidAmount(invoiceId);
            return inv.Amount - totalPayments;
        }

        // This Method Updated Invoice Status based on payments and dues
        public static void UpdateInvoiceStatus(int invoiceId)
        {
            Invoice inv = GetInvoiceById(invoiceId);
            if (inv == null || inv.Status == "Cancelled") return;

            decimal totalPaid = InvoiceDAL.GetTotalPaidAmount(invoiceId);
            string calculatedStatus = DeterminesStatus(inv.Amount, totalPaid, inv.Dues);
            InvoiceDAL.UpdateInvoiceStatus(invoiceId, calculatedStatus);
        }

        // This Method returns true if past due date and not fully paid
        public static bool IsOverdue(Invoice inv)
        {
            if (inv == null) return false;
            decimal totalPaid = InvoiceDAL.GetTotalPaidAmount(inv.InvoiceId);

            return DateTime.Today > inv.DueDate && totalPaid < inv.Amount;
        }

        // This methods returns all payments made against an invoice
        public static List<Payment> GetPaymentsForInvoice(int invoiceid)
        {
            DataTable dt = InvoiceDAL.GetPaymentsForInvoice(invoiceId);
            List<Payment> payments = new List<Payment>();
            foreach (DataRow row in dt.Rows)
            {
                payments.Add(new Payment
                {
                    PaymentId = Convert.ToInt32(row["PaymentId"]),
                    AmountPaid = Convert.ToDecimal(row["AmountPaid"]),
                    PaymentDate = Convert.ToDateTime(row["PaymentDate"]),
                    PaymentMethod = row["PaymentMethod"].ToString(),
                    InvoiceId = Convert.ToInt32(row["InvoiceId"]),
                    UserId = Convert.ToInt32(row["UserId"])
                });
            }
            return payments;
        }

        public static int GetInvoiceCount(int clientId = 0, string status = "All")
        {
            return InvoiceDAL.GetInvoiceCount(clientId, status);
        }

        // Helper Methods

        private static string DeterminesStatus(decimal totalAmount, decimal totalPaid, DateTime dueDate)
        {
            if(totalPaid >= totalAmount) return "Paid";
            if(totalPaid > 0 && totalPaid < totalAmount) return "Partially Paid";
            if(DateTime.Today > dueDate.Date) return "Overdue";
            return "Unpaid";
        }

        private static ValidationResult ValidatePaymentAmount(int InvoiceId, decimal Amount)
        {
            decimal outstandingBalance = GetBalance(InvoiceId);
            if(Amount > outstandingBalance)
            {
                return ValidationResult.Failure($"Payment amount exceeds outstanding balance.");
            }
            return ValidationResult.Success("Payment amount is valid.");
        }
        
        private static Invoice MapDataRowToInvoice(DataRow row)
        {
            return new Invoice
            {
                InvoiceID = Convert.ToInt32(row["InvoiceID"]),
                CaseId = Convert.ToInt32(row["CaseId"]),
                ClientId = Convert.ToInt32(row["ClientId"]),
                DueDate = Convert.ToDateTime(row["DueDate"]),
                Status = row["Status"].ToString(),
                CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                UpdatedAt = Convert.ToDateTime(row["UpdatedAt"]),
                Amount = Convert.ToDecimal(row["Amount"])
            };
        }

}
