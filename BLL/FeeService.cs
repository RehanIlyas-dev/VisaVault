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
    public static class FeeService 
    {
        // This method returns fee breadkown for country + document type combination
        public static FeeBreakdown CalculateFee(int CountryId, int DocumentTypeid, bool isUrgent)
        {
            FeeBreakdown breakdown = new FeeBreakdown();
            FeeRule rule = GetActiveRule(CountryId, DocumentTypeid);
            if (rule != null)
            {
                breakdown.BaseFee = rule.BaseFee;
                breakdown.ProcessingFee = rule.ProcessingFee ?? 0m;
                breakdown.UrgencyFee = ApplyUrgencyFee(rule.BaseFee, isUrgent, rule);

                breakdown.TotalFee = breakdown.BaseFee + breakdown.ProcessingFee + breakdown.UrgencyFee;
                breakdown.ValidFrom = rule.ValidFrom ?? DateTime.MinValue;
                breakdown.ValidTo = rule.ValidTo ?? DateTime.MinValue;
                breakdown.IsActive = true;
            }
            else
            {
                breakdown.IsActive = false;
            }
            return breakdown;
        }

        // This Method returns Total Fee ready for use in an invoice line item
        public static decimal GetTotalFeeForInvoice(int countryId, int documentTypeId, bool isUrgent)
        {
            FeeBreakdown breakdown = CalculateFee(countryId, documentTypeId, isUrgent);
            return breakdown.IsActive ? breakdown.TotalFee : 0m;
        }
        // This method retrieves the active fee rule for a given country and document type, returning a FeeRule object if found, or null if no active rule exists.
        public static List<Country> GetCountries()
        {
            DataTable dt = FeeDAL.GetAllCountries();
            List<Country> countries = new List<Country>();
            foreach (DataRow row in dt.Rows)
            {
                countries.Add(new Country(
                    Convert.ToInt32(row["country_id"]),
                    row["country_name"]?.ToString() ?? string.Empty,
                    row.Table.Columns.Contains("country_code") ? row["country_code"]?.ToString() ?? string.Empty : string.Empty
                ));
            }
            return countries;
        }

        public static List<Country> GetAllCountries()
        {
            return GetCountries();
        }

        // This methods return all Document Types for ComboBox 
        public static List<DocumentType> GetAllDocumentTypes()
        {
            DataTable dt = FeeDAL.GetAllDocumentTypes();
            List<DocumentType> documentTypes = new List<DocumentType>();
            foreach (DataRow row in dt.Rows)
            {
                documentTypes.Add(new DocumentType
                {
                    DocumentTypeId = Convert.ToInt32(row["documenttype_id"]),
                    DocumentTypeName = row["documenttype_name"]?.ToString() ?? string.Empty
                });
            }
            return documentTypes;
        }

        private static FeeRule GetActiveRule(int countryId, int documentTypeId)
        {
            DataTable dt = FeeDAL.GetActiveRule(countryId, documentTypeId);
            if (dt.Rows.Count == 0) return null;

            DataRow row = dt.Rows[0];
            return new FeeRule(
                Convert.ToInt32(row["fee_id"]),
                Convert.ToInt32(row["type_id"]),
                Convert.ToInt32(row["country_id"]),
                Convert.ToInt32(row["fee_name"]),
                row["processing_fee"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(row["processing_fee"]),
                row["urgent_fee"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(row["urgent_fee"]),
                Convert.ToDecimal(row["base_fee"]),
                row["valid_from"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["valid_from"]),
                row["valid_to"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["valid_to"]),
                DateTime.MinValue,
                DateTime.MinValue
            );
        }

        private static decimal ApplyUrgencyFee(decimal baseFee, bool isUrgent, FeeRule rule)
        {
            if (!isUrgent || (rule.UrgentFee ?? 0m) <= 0m) return 0m;
            return (baseFee * (rule.UrgentFee ?? 0m)) / 100m;
        }
    }
}
