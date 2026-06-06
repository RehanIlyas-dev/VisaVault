using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace visavault_g43.BLL
{
    public static class ReportService
    {
        private static Database db = new Database();
        public static void GenerateClientRegistryReport(string destPath, string statusFilter, int countryId = 0)
        {
            string countryName = "All Countries";
            string query = "SELECT c.client_id, c.client_name, c.cnic_no, c.email, c.contact_no, co.country_name, c.status " +
                           "FROM client c JOIN country co ON c.country_id = co.country_id WHERE 1=1";
            var paramsList = new System.Collections.Generic.List<MySqlParameter>();

            if (statusFilter != "All" && statusFilter != "All Status" && !string.IsNullOrEmpty(statusFilter))
            {
                query += " AND c.status = @status";
                paramsList.Add(new MySqlParameter("@status", statusFilter));
            }
            if (countryId > 0)
            {
                query += " AND c.country_id = @countryId";
                paramsList.Add(new MySqlParameter("@countryId", countryId));
                
                DataTable cDt = db.ExecuteQuery("SELECT country_name FROM country WHERE country_id = @id", new[] { new MySqlParameter("@id", countryId) });
                if (cDt.Rows.Count > 0) countryName = cDt.Rows[0]["country_name"].ToString();
            }
            query += " ORDER BY c.client_name;";

            DataTable dt = db.ExecuteQuery(query, paramsList.ToArray());
            string subtitle = $"Status Filter: {statusFilter} | Country: {countryName}";
            string[] headers = { "ID", "Name", "CNIC", "Email", "Contact No", "Country", "Status" };
            GenerateReportPdf("Client Registry Report", headers, dt, destPath, subtitle);
        }

        public static void GenerateActiveRenewalsReport(string destPath, int stageId = 0)
        {
            string stageName = "All Stages";
            string query = "SELECT v.renewalcase_id, v.client_name, v.documenttype_name, v.current_stage AS stage_name, v.assigned_user AS username, v.created_at " +
                           "FROM vw_active_renewals v JOIN renewalstage rs ON v.current_stage = rs.stage_name WHERE 1=1";
            var paramsList = new System.Collections.Generic.List<MySqlParameter>();

            if (stageId > 0)
            {
                query += " AND rs.stage_id = @stageId";
                paramsList.Add(new MySqlParameter("@stageId", stageId));

                DataTable sDt = db.ExecuteQuery("SELECT stage_name FROM renewalstage WHERE stage_id = @id", new[] { new MySqlParameter("@id", stageId) });
                if (sDt.Rows.Count > 0) stageName = sDt.Rows[0]["stage_name"].ToString();
            }
            query += " ORDER BY v.renewalcase_id DESC;";

            DataTable dt = db.ExecuteQuery(query, paramsList.ToArray());
            string subtitle = $"Stage Filter: {stageName}";
            string[] headers = { "Case ID", "Client Name", "Document Type", "Current Stage", "Assigned User", "Created Date" };
            GenerateReportPdf("Active Visa Renewal Cases Report", headers, dt, destPath, subtitle);
        }

        public static void GenerateExpiringDocumentsReport(string destPath, int nextDays = 90)
        {
            DataTable dt;
            if (nextDays == 90)
            {
                dt = db.ExecuteQuery("SELECT document_id, document_no, documenttype_name, client_name, expiry_date, days_until_expiry AS days_left FROM vw_expiring_documents ORDER BY expiry_date ASC;");
            }
            else
            {
                string query = "SELECT d.document_id, d.document_no, dt.documenttype_name, c.client_name, d.expiry_date, DATEDIFF(d.expiry_date, CURDATE()) AS days_left " +
                               "FROM document d " +
                               "JOIN documenttype dt ON d.type_id = dt.documenttype_id " +
                               "JOIN client c ON d.client_id = c.client_id " +
                               "WHERE d.expiry_date BETWEEN CURDATE() AND DATE_ADD(CURDATE(), INTERVAL @days DAY) " +
                               "ORDER BY d.expiry_date ASC;";
                dt = db.ExecuteQuery(query, new[] { new MySqlParameter("@days", nextDays) });
            }
            string subtitle = $"Documents Expiring in the Next {nextDays} Days";
            string[] headers = { "Doc ID", "Document No", "Type", "Client Name", "Expiry Date", "Days Remaining" };
            GenerateReportPdf("Expiring Client Documents Report", headers, dt, destPath, subtitle);
        }

        public static void GenerateAccountsReceivableReport(string destPath, string statusFilter = "All")
        {
            string query = "SELECT invoice_id, client_name, due_date, total_amount AS amount, status, total_paid, balance_due FROM vw_invoice_summary WHERE 1=1";
            var paramsList = new System.Collections.Generic.List<MySqlParameter>();

            if (statusFilter != "All" && !string.IsNullOrEmpty(statusFilter))
            {
                query += " AND status = @status";
                paramsList.Add(new MySqlParameter("@status", statusFilter));
            }
            query += " ORDER BY due_date ASC;";

            DataTable dt = db.ExecuteQuery(query, paramsList.ToArray());

            string subtitle = $"Status Filter: {statusFilter}";
            string[] headers = { "Inv ID", "Client Name", "Due Date", "Total Amount", "Total Paid", "Balance Due", "Status" };
            GenerateReportPdf("Accounts Receivable Report", headers, dt, destPath, subtitle);
        }

        public static void GenerateRevenueCollectionReport(string destPath, DateTime startDate, DateTime endDate)
        {
            string query = "SELECT p.payment_id, i.invoice_id, c.client_name, p.amount_paid, p.payment_method, p.payment_date, u.username " +
                           "FROM payment p " +
                           "JOIN invoice i ON p.invoice_id = i.invoice_id " +
                           "JOIN client c ON i.client_id = c.client_id " +
                           "JOIN user u ON p.user_id = u.user_id " +
                           "WHERE p.payment_date BETWEEN @start AND @end " +
                           "ORDER BY p.payment_date DESC;";
            MySqlParameter[] parameters = {
                new MySqlParameter("@start", startDate.Date),
                new MySqlParameter("@end", endDate.Date.AddDays(1).AddSeconds(-1))
            };
            DataTable dt = db.ExecuteQuery(query, parameters);
            string subtitle = $"Date Range: {startDate:yyyy-MM-dd} to {endDate:yyyy-MM-dd}";
            string[] headers = { "Payment ID", "Invoice ID", "Client Name", "Amount Paid", "Method", "Date", "Received By" };
            GenerateReportPdf("Revenue Collection Report", headers, dt, destPath, subtitle);
        }

        public static void GenerateDailyAppointmentsReport(string destPath, DateTime date)
        {
            string query = "SELECT a.appointment_id, a.appointment_date, c.client_name, u.username, a.purpose, a.status " +
                           "FROM appointment a " +
                           "JOIN client c ON a.client_id = c.client_id " +
                           "JOIN user u ON a.user_id = u.user_id " +
                           "WHERE DATE(a.appointment_date) = @date " +
                           "ORDER BY a.appointment_date ASC;";
            DataTable dt = db.ExecuteQuery(query, new[] { new MySqlParameter("@date", date.Date) });
            string subtitle = $"Appointment Date: {date:yyyy-MM-dd}";
            string[] headers = { "ID", "Time", "Client Name", "Consultant", "Purpose", "Status" };
            GenerateReportPdf("Daily Appointments Manifest", headers, dt, destPath, subtitle);
        }
        public static void GenerateFeeRatesReport(string destPath, int countryId = 0)
        {
            string countryName = "All Countries";
            string query = "SELECT fee_id, documenttype_name, country_name, fee_name, base_fee, urgent_fee, processing_fee FROM vw_fee_rules_summary WHERE 1=1";
            var paramsList = new System.Collections.Generic.List<MySqlParameter>();

            if (countryId > 0)
            {
                query += " AND country_name = @countryName";

                DataTable cDt = db.ExecuteQuery("SELECT country_name FROM country WHERE country_id = @id", new[] { new MySqlParameter("@id", countryId) });
                if (cDt.Rows.Count > 0) countryName = cDt.Rows[0]["country_name"].ToString();
                paramsList.Add(new MySqlParameter("@countryName", countryName));
            }
            query += " ORDER BY country_name, documenttype_name;";

            DataTable dt = db.ExecuteQuery(query, paramsList.ToArray());
            string subtitle = $"Country Filter: {countryName}";
            string[] headers = { "Rule ID", "Doc Type", "Country", "Rule Name", "Base Fee", "Urgent Fee", "Processing Fee" };
            GenerateReportPdf("Fee Rates Rule Chart", headers, dt, destPath, subtitle);
        }
        public static void GenerateDependenciesReport(string destPath)
        {
            string query = "SELECT dd.dependency_id, dt1.documenttype_name AS target_doc, dt2.documenttype_name AS required_doc " +
                           "FROM documentdependency dd " +
                           "JOIN documenttype dt1 ON dd.documenttype_id = dt1.documenttype_id " +
                           "JOIN documenttype dt2 ON dd.requireddocumenttype_id = dt2.documenttype_id " +
                           "ORDER BY dt1.documenttype_name;";
            DataTable dt = db.ExecuteQuery(query);
            string subtitle = "Mapping of document dependencies required by visa guidelines";
            string[] headers = { "Dependency ID", "Target Document Type", "Required Document Type" };
            GenerateReportPdf("Document Type Dependencies Map", headers, dt, destPath, subtitle);
        }

        public static void GenerateAuditLogsReport(string destPath, string actionFilter = "All")
        {
            string query = "SELECT al.audit_id, u.username, al.table_name, al.record_id, al.field_name, al.action_type, al.changed_at " +
                           "FROM audit_log al JOIN user u ON al.user_id = u.user_id WHERE 1=1";
            var paramsList = new System.Collections.Generic.List<MySqlParameter>();

            if (actionFilter != "All" && !string.IsNullOrEmpty(actionFilter))
            {
                query += " AND al.action_type = @action";
                paramsList.Add(new MySqlParameter("@action", actionFilter));
            }
            query += " ORDER BY al.changed_at DESC LIMIT 500;";

            DataTable dt = db.ExecuteQuery(query, paramsList.ToArray());
            string subtitle = $"Action Type Filter: {actionFilter} | Showing Latest 500 Records";
            string[] headers = { "Log ID", "User", "Table", "Record ID", "Field Changed", "Action", "Timestamp" };
            GenerateReportPdf("System Audit Log Report", headers, dt, destPath, subtitle);
        }
       public static void GenerateCaseTimelineReport(string destPath, int caseId)
        {
            string query = "SELECT l.log_id, rs.stage_name, u.username, l.remarks, l.updated_at " +
                           "FROM renewalstagelog l " +
                           "JOIN renewalstage rs ON l.currentstage_id = rs.stage_id " +
                           "JOIN user u ON l.user_id = u.user_id " +
                           "WHERE l.renewalcase_id = @caseId " +
                           "ORDER BY l.updated_at ASC;";
            DataTable dt = db.ExecuteQuery(query, new[] { new MySqlParameter("@caseId", caseId) });
            string subtitle = $"Workflow History Timeline for Case Reference ID: #{caseId}";
            string[] headers = { "Log ID", "Stage Name", "Updated By", "Remarks / Activity", "Timestamp" };
            GenerateReportPdf("Case Timeline Audit Report", headers, dt, destPath, subtitle);
        }
        private static void GenerateReportPdf(string title, string[] headers, DataTable data, string destPath, string subtitle = "")
        {
            Document doc = new Document(PageSize.A4, 36f, 36f, 54f, 54f);
            try
            {
                using (FileStream fs = new FileStream(destPath, FileMode.Create, FileAccess.Write))
                {
                    PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                    writer.PageEvent = new PDFPageEventHelper(title);

                    doc.Open();

                    Font titleFont = FontFactory.GetFont("Helvetica-Bold", 18f, new BaseColor(18, 52, 86));
                    Font subtitleFont = FontFactory.GetFont("Helvetica-Oblique", 10f, BaseColor.GRAY);
                    Font timestampFont = FontFactory.GetFont("Helvetica", 9f, BaseColor.DARK_GRAY);
                    Font headerFont = FontFactory.GetFont("Helvetica-Bold", 9f, BaseColor.WHITE);
                    Font cellFont = FontFactory.GetFont("Helvetica", 8f, BaseColor.BLACK);

                    Paragraph mainTitle = new Paragraph(title, titleFont);
                    mainTitle.SpacingAfter = 5f;
                    doc.Add(mainTitle);

                    Paragraph sub = new Paragraph(subtitle, subtitleFont);
                    sub.SpacingAfter = 10f;
                    doc.Add(sub);

                    Paragraph timestamp = new Paragraph($"Generated on: {DateTime.Now:yyyy-MM-dd HH:mm:ss} | Total Records: {data.Rows.Count}", timestampFont);
                    timestamp.SpacingAfter = 15f;
                    doc.Add(timestamp);

                    iTextSharp.text.pdf.draw.LineSeparator ls = new iTextSharp.text.pdf.draw.LineSeparator(1f, 100f, new BaseColor(18, 52, 86), Element.ALIGN_CENTER, -5f);
                    doc.Add(new Chunk(ls));
                    doc.Add(new Paragraph("\n"));

                    if (data.Rows.Count == 0)
                    {
                        Paragraph emptyMsg = new Paragraph("No records found matching the specified parameters.", FontFactory.GetFont("Helvetica-Bold", 10f, BaseColor.RED));
                        doc.Add(emptyMsg);
                    }
                    else
                    {
                        PdfPTable table = new PdfPTable(headers.Length);
                        table.WidthPercentage = 100f;
                        table.HeaderRows = 1;

                        float[] widths = new float[headers.Length];
                        for (int i = 0; i < headers.Length; i++) widths[i] = 1f;
                        table.SetWidths(widths);

                        foreach (string header in headers)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(header, headerFont));
                            cell.BackgroundColor = new BaseColor(18, 52, 86);
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            cell.Padding = 6f;
                            cell.BorderColor = BaseColor.LIGHT_GRAY;
                            table.AddCell(cell);
                        }

                        bool alternate = false;
                        foreach (DataRow row in data.Rows)
                        {
                            for (int i = 0; i < data.Columns.Count && i < headers.Length; i++)
                            {
                                string val = row[i]?.ToString() ?? "";
                                if (DateTime.TryParse(val, out DateTime dateVal) && val.Contains("12:00:00 AM"))
                                {
                                    val = dateVal.ToString("yyyy-MM-dd");
                                }

                                PdfPCell cell = new PdfPCell(new Phrase(val, cellFont));
                                cell.Padding = 5f;
                                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                                cell.BorderColor = BaseColor.LIGHT_GRAY;
                                if (alternate)
                                {
                                    cell.BackgroundColor = new BaseColor(240, 244, 248);
                                }
                                table.AddCell(cell);
                            }
                            alternate = !alternate;
                        }

                        doc.Add(table);
                    }

                    doc.Close();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error generating PDF: " + ex.Message, ex);
            }
            finally
            {
                if (doc.IsOpen()) doc.Close();
            }
        }
    }

    public class PDFPageEventHelper : PdfPageEventHelper
    {
        private string docTitle;
        public PDFPageEventHelper(string title)
        {
            this.docTitle = title;
        }

        public override void OnEndPage(PdfWriter writer, Document doc)
        {
            PdfPTable footer = new PdfPTable(2);
            footer.TotalWidth = doc.PageSize.Width - doc.LeftMargin - doc.RightMargin;
            footer.LockedWidth = true;

            Font footerFont = FontFactory.GetFont("Helvetica", 8f, BaseColor.GRAY);

            PdfPCell cellLeft = new PdfPCell(new Phrase($"{docTitle} | VisaVault", footerFont));
            cellLeft.Border = Rectangle.NO_BORDER;
            cellLeft.HorizontalAlignment = Element.ALIGN_LEFT;
            footer.AddCell(cellLeft);

            PdfPCell cellRight = new PdfPCell(new Phrase($"Page {writer.PageNumber}", footerFont));
            cellRight.Border = Rectangle.NO_BORDER;
            cellRight.HorizontalAlignment = Element.ALIGN_RIGHT;
            footer.AddCell(cellRight);

            footer.WriteSelectedRows(0, -1, doc.LeftMargin, doc.BottomMargin - 15f, writer.DirectContent);
        }
    }
}
