using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using visavault_g43;
using visavault_g43.Models;

namespace visavault_g43.DLL
{
    using Invoice = visavault_g43.Models.Invoice;

    internal class InvoiceDAL
    {
        static Database db = new Database();

        public static DataTable GetAllInvoices(int clientId = 0, string statusFilter = "All")
        {
            
            string query = "SELECT invoice_id, case_id, client_id, due_date, status, created_at, updated_at, amount " +
                "FROM invoice WHERE (@ClientId = 0 OR client_id = @ClientId) AND (@StatusFilter = 'All' OR status = @StatusFilter)" +
                " ORDER BY created_at DESC;";

            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@ClientId", clientId),
                new MySqlParameter("@StatusFilter", statusFilter)
            };

            return db.ExecuteQuery(query, parameters);
        }
        public static DataTable GetInvoiceById(int invoiceId)
        {
            string query = "SELECT invoice_id, case_id, client_id, due_date, status, created_at, updated_at, amount FROM invoice WHERE invoice_id = @InvoiceId;";

            MySqlParameter[] parameters = new MySqlParameter[]
            {
        new MySqlParameter("@InvoiceId", invoiceId)
            };
            return db.ExecuteQuery(query, parameters);
        }
        public static DataTable GetLineItems(int invoiceId)
        {
            string query = "SELECT ii.item_id, ii.invoice_id, ii.fee_id, f.fee_name, ii.quantity, ii.unit_price, ii.total_price" +
                " FROM invoice_item ii JOIN feerule f ON ii.fee_id = f.fee_id WHERE ii.invoice_id = @InvoiceId;";

            MySqlParameter[] parameters = new MySqlParameter[]
            {
        new MySqlParameter("@InvoiceId", invoiceId)
            };
            return db.ExecuteQuery(query, parameters);
        }
        public static int InsertInvoice(Invoice invoice)
        {
            string query = "INSERT INTO invoice (case_id, client_id, due_date, status, amount) " +
                "VALUES (@CaseId, @ClientId, @DueDate, @Status, @Amount);";

            MySqlParameter[] parameters = new MySqlParameter[]
            {
        new MySqlParameter("@CaseId", invoice.CaseId),
        new MySqlParameter("@ClientId", invoice.ClientId),
        new MySqlParameter("@DueDate", invoice.DueDate),
        new MySqlParameter("@Status", invoice.Status),
        new MySqlParameter("@Amount", invoice.Amount)
            };
            return db.ExecuteNonQuery(query, parameters);
        }
        public static int InsertInvoiceLineItem(InvoiceLineItem lineItem)
        {
            string query = "INSERT INTO invoicelineitem (invoice_id, fee_id, quantity, unit_price, total_price) " +
                "VALUES (@InvoiceId, @FeeId, @Quantity, @UnitPrice, @TotalPrice);";

            MySqlParameter[] parameters = new MySqlParameter[]
            {
        new MySqlParameter("@InvoiceId", lineItem.InvoiceID),
        new MySqlParameter("@FeeId", lineItem.FeeId),
        new MySqlParameter("@Quantity", lineItem.Quantity),
        new MySqlParameter("@UnitPrice", lineItem.UnitPrice),
        new MySqlParameter("@TotalPrice", lineItem.TotalPrice)
            };
            return db.ExecuteNonQuery(query, parameters);
        }
        public static int DeleteLineItems(int invoiceId)
        {
            string query = "DELETE FROM invoicelineitem WHERE invoice_id = @InvoiceId;";

            MySqlParameter[] parameters = new MySqlParameter[]
            {
        new MySqlParameter("@InvoiceId", invoiceId)
            };
            return db.ExecuteNonQuery(query, parameters);
        }
        public static int InsertPayment(Payment payment)
        {
            
            string query = "INSERT INTO payment (invoice_id, amount_paid, payment_method, payment_date, user_id) " +
                "VALUES (@InvoiceId, @AmountPaid, @PaymentMethod, @PaymentDate, @UserId);";

            MySqlParameter[] parameters = new MySqlParameter[]
            {
        new MySqlParameter("@InvoiceId", payment.InvoiceId),
        new MySqlParameter("@AmountPaid", payment.AmountPaid),
        new MySqlParameter("@PaymentMethod", payment.PaymentMethod),
        new MySqlParameter("@PaymentDate", payment.PaymentDate),
        new MySqlParameter("@UserId", payment.UserId)
            };

            return db.ExecuteNonQuery(query, parameters);
        }
        public static DataTable GetPaymentsForInvoice(int invoiceId)
        {
            string query = "SELECT payment_id, invoice_id, amount_paid, payment_method, payment_date, user_id FROM payment WHERE invoice_id = @InvoiceId ORDER BY payment_date ASC;";

            MySqlParameter[] parameters = new MySqlParameter[]
            {
        new MySqlParameter("@InvoiceId", invoiceId)
            };
            return db.ExecuteQuery(query, parameters);
        }
        public static decimal GetTotalPaidAmount(int invoiceId)
        {
            string query = "SELECT COALESCE(SUM(amount_paid), 0) FROM payment WHERE invoice_id = @InvoiceId;";

            MySqlParameter[] parameters = new MySqlParameter[]
            {
        new MySqlParameter("@InvoiceId", invoiceId)
            };
            return Convert.ToDecimal(db.ExecuteScalar(query, parameters));
        }
        public static int UpdateInvoiceTotal(int invoiceId, decimal totalAmount)
        {
            string query = "UPDATE invoice SET amount = @TotalAmount  WHERE invoice_id = @InvoiceId;";

            MySqlParameter[] parameters = new MySqlParameter[]
            {
        new MySqlParameter("@TotalAmount", totalAmount),
        new MySqlParameter("@InvoiceId", invoiceId)
            };
            return db.ExecuteNonQuery(query, parameters);
        }
        public static int UpdateInvoiceStatus(int invoiceId, string status)
        {
            string query = "UPDATE invoice SET status = @Status WHERE invoice_id = @InvoiceId;";

            MySqlParameter[] parameters = new MySqlParameter[]
            {
        new MySqlParameter("@Status", status),
        new MySqlParameter("@InvoiceId", invoiceId)
            };
            return db.ExecuteNonQuery(query, parameters);
        }
        public static int GetOverdueInvoiceCount()
        {
            string query = "SELECT COUNT(*) FROM invoice WHERE status IN ('Unpaid', 'Partially Paid')" +
                " AND DATEDIFF(CURRENT_DATE(), due_date) > 20;";
            return Convert.ToInt32(db.ExecuteScalar(query));
        }
    }
}
