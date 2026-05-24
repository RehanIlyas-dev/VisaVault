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
    using Invoice = visavault_g43.Models.Invoice;

    public class InvoiceService
    {
        // Returns invoices from the DAL using the DAL method names and maps them to models.
        public static List<Invoice> GetAllInvoices(int clientId = 0, string status = "All")
        {
            DataTable dt = InvoiceDAL.GetAllInvoices(clientId, status);
            if (dt == null) return new List<Invoice>();
            return dt.AsEnumerable().Select(row => MapDataRowToInvoice(row)).ToList();
        }

        // Returns one invoice and its line items.
        public static Invoice GetInvoiceById(int invoiceId)
        {
            if (invoiceId <= 0) return null;
            DataTable dt = InvoiceDAL.GetInvoiceById(invoiceId);
            if (dt == null || dt.Rows.Count == 0) return null;

            Invoice invoice = MapDataRowToInvoice(dt.Rows[0]);
            invoice.LineItems = GetLineItems(invoiceId);
            return invoice;
        }

        // Returns line items for an invoice.
        public static List<InvoiceLineItem> GetLineItems(int invoiceId)
        {
            DataTable dt = InvoiceDAL.GetLineItems(invoiceId);
            if (dt == null) return new List<InvoiceLineItem>();

            return dt.AsEnumerable().Select(row => new InvoiceLineItem(
                row.Field<int?>("item_id") ?? 0,
                row.Field<int?>("invoice_id") ?? 0,
                row.Field<int?>("fee_id") ?? 0,
                row.Field<int?>("quantity") ?? 0,
                row.Field<decimal?>("unit_price") ?? 0m,
                row.Field<decimal?>("total_price") ?? 0m
            )).ToList();
        }

        // Saves an invoice and its line items.
        public static ValidationResult SaveInvoice(Invoice invoice, List<InvoiceLineItem> lineItems)
        {
            if (invoice == null) return ValidationResult.Failure("Invoice cannot be null.");
            if (invoice.CaseId <= 0 || invoice.ClientId <= 0) return ValidationResult.Failure("Invoice must have a valid CaseId and ClientId.");
            if (invoice.DueDate == DateTime.MinValue) return ValidationResult.Failure("Invoice must have a valid DueDate.");
            if (lineItems == null || lineItems.Count == 0) return ValidationResult.Failure("Invoice must have at least one line item.");

            decimal runningTotal = 0m;
            foreach (InvoiceLineItem item in lineItems)
            {
                decimal totalPrice = item.TotalPrice > 0 ? item.TotalPrice : item.Amount;
                if (totalPrice <= 0) return ValidationResult.Failure("Line item amounts must be greater than zero.");

                item.TotalPrice = totalPrice;
                item.Amount = totalPrice;
                if (item.Quantity <= 0) item.Quantity = 1;
                if (item.UnitPrice <= 0) item.UnitPrice = totalPrice;
                runningTotal += totalPrice;
            }

            invoice.Status = string.IsNullOrWhiteSpace(invoice.Status) ? "Unpaid" : invoice.Status;
            invoice.Amount = runningTotal;

            if (InvoiceDAL.InsertInvoice(invoice) <= 0) return ValidationResult.Failure("Failed to save invoice.");

            Invoice savedInvoice = GetAllInvoices(invoice.ClientId, invoice.Status)
                .OrderByDescending(x => x.CreatedAt)
                .FirstOrDefault(x => x.CaseId == invoice.CaseId && x.ClientId == invoice.ClientId && x.DueDate.Date == invoice.DueDate.Date && x.Amount == invoice.Amount);

            if (savedInvoice == null) return ValidationResult.Failure("Invoice saved, but it could not be reloaded.");

            foreach (InvoiceLineItem item in lineItems)
            {
                item.InvoiceID = savedInvoice.InvoiceID;
                InvoiceDAL.InsertInvoiceLineItem(item);
            }

            return ValidationResult.Success("Invoice saved successfully.");
        }

        // Records a payment for an invoice.
        public static ValidationResult RecordPayment(Payment payment)
        {
            if (payment == null) return ValidationResult.Failure("Payment cannot be null.");
            if (!payment.AmountPaid.HasValue || payment.AmountPaid.Value <= 0) return ValidationResult.Failure("Payment amount must be greater than zero.");

            ValidationResult amountCheck = ValidatePaymentAmount(payment.InvoiceId, payment.AmountPaid.Value);
            if (!amountCheck.IsValid) return amountCheck;

            if (InvoiceDAL.InsertPayment(payment) <= 0) return ValidationResult.Failure("Failed to record payment.");

            UpdateInvoiceStatus(payment.InvoiceId);
            return ValidationResult.Success("Payment recorded successfully.");
        }

        // Recalculates invoice amount from all line items.
        public static decimal ReCalculateTotalFromItems(int invoiceId)
        {
            List<InvoiceLineItem> items = GetLineItems(invoiceId);
            decimal total = items.Sum(item => item.TotalPrice > 0 ? item.TotalPrice : item.Amount);
            InvoiceDAL.UpdateInvoiceTotal(invoiceId, total);
            UpdateInvoiceStatus(invoiceId);
            return total;
        }

        // Returns invoice balance.
        public static decimal GetBalance(int invoiceId)
        {
            Invoice inv = GetInvoiceById(invoiceId);
            if (inv == null) return 0m;
            decimal totalPayments = InvoiceDAL.GetTotalPaidAmount(invoiceId);
            return inv.Amount - totalPayments;
        }

        // Updates invoice status based on amount paid and due date.
        public static void UpdateInvoiceStatus(int invoiceId)
        {
            Invoice inv = GetInvoiceById(invoiceId);
            if (inv == null || inv.Status == "Cancelled") return;

            decimal totalPaid = InvoiceDAL.GetTotalPaidAmount(invoiceId);
            string status = DetermineStatus(inv.Amount, totalPaid, inv.DueDate);
            InvoiceDAL.UpdateInvoiceStatus(invoiceId, status);
        }

        // Returns true if the invoice is overdue.
        public static bool IsOverdue(Invoice invoice)
        {
            if (invoice == null) return false;
            decimal totalPaid = InvoiceDAL.GetTotalPaidAmount(invoice.InvoiceID);
            return DateTime.Today > invoice.DueDate.Date && totalPaid < invoice.Amount;
        }

        // Returns all payments for an invoice.
        public static List<Payment> GetPaymentsForInvoice(int invoiceId)
        {
            DataTable dt = InvoiceDAL.GetPaymentsForInvoice(invoiceId);
            if (dt == null) return new List<Payment>();

            return dt.AsEnumerable().Select(row => new Payment(
                row.Field<int?>("payment_id") ?? 0,
                row.Field<int?>("invoice_id") ?? 0,
                row.Field<decimal?>("amount_paid") ?? 0m,
                string.Empty,
                row.Field<DateTime?>("payment_date") ?? DateTime.MinValue,
                row.Field<string>("payment_method") ?? string.Empty,
                row.Field<int?>("user_id") ?? 0
            )).ToList();
        }

        public static int GetInvoiceCount(int clientId = 0, string status = "All")
        {
            return GetAllInvoices(clientId, status).Count;
        }

        private static string DetermineStatus(decimal totalAmount, decimal totalPaid, DateTime dueDate)
        {
            if (totalPaid >= totalAmount) return "Paid";
            if (totalPaid > 0 && totalPaid < totalAmount) return "Partially Paid";
            if (DateTime.Today > dueDate.Date) return "Overdue";
            return "Unpaid";
        }

        private static ValidationResult ValidatePaymentAmount(int invoiceId, decimal amount)
        {
            decimal outstandingBalance = GetBalance(invoiceId);
            if (amount > outstandingBalance) return ValidationResult.Failure("Payment amount exceeds outstanding balance.");
            return ValidationResult.Success("Payment amount is valid.");
        }

        private static Invoice MapDataRowToInvoice(DataRow row)
        {
            return new Invoice()
            {
                InvoiceID = row.Field<int?>("invoice_id") ?? 0,
                CaseId = row.Field<int?>("case_id") ?? 0,
                ClientId = row.Field<int?>("client_id") ?? 0,
                DueDate = row.Field<DateTime?>("due_date") ?? DateTime.MinValue,
                Status = row.Field<string>("status") ?? string.Empty,
                CreatedAt = row.Field<DateTime?>("created_at") ?? DateTime.MinValue,
                UpdatedAt = row.Field<DateTime?>("updated_at") ?? DateTime.MinValue,
                Amount = row.Field<decimal?>("amount") ?? 0m
            };
        }
    }
}
