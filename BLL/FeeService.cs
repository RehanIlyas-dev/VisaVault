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
            FeeRule rule = GetActiveRule(coutryId, DocumentTypeid);
            if(rule != null)
            {
                breakdown.BaseFee = rule.BaseFee;
                breakdown.ProcessingFee = rule.ProcessingFee;
                breakdown.UrgencyFee = ApplyUrgencyFee(rule.BaseFee, isUrgent, rule);

                breakdown.TotalFee = breakdown.BaseFee + breakdown.ProcessingFee + breakdown.UrgencyFee;
                breakdown.ValidFrom = rule.ValidFrom;
                breakdown.ValidTo = rule.ValidTo;
                breakdown.IsActive = true;
            } else
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
                countries.Add(new Country
                {
                    CountryId = Convert.ToInt32(row["CountryId"]),
                    CountryName = row["CountryName"].ToString()
                });
            } return countries;
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
                    DocumentTypeId = Convert.ToInt32(row["DocumentTypeId"]),
                    DocumentTypeName = row["DocumentTypeName"].ToString()
                });
            }
            return documentTypes;
        }

        private static FeeRule GetActiveRule(int countryId, int documentTypeId)
        {
            DataTable dt = FeeDAL.GetActiveFeeRule(countryId, documentTypeId);
            if (dt.Rows.Count == 0) return null;
            {
                DataRow row = dt.Rows[0];
                return new FeeRule
                {
                    RuleId = Convert.ToInt32(row["RuleId"]),
                    CountryId = Convert.ToInt32(row["CountryId"]),
                    DocumentTypeId = Convert.ToInt32(row["DocumentTypeId"]),
                    BaseFee = Convert.ToDecimal(row["BaseFee"]),
                    ProcessingFee = Convert.ToDecimal(row["ProcessingFee"]),
                    UrgencyFeePercentage = Convert.ToDecimal(row["UrgencyFeePercentage"]),
                    ValidFrom = Convert.ToDateTime(row["ValidFrom"]),
                    ValidTo = Convert.ToDateTime(row["ValidTo"])
                };
            }
        }

        private static decimal ApplyUrgencyFee(decimal baseFee, bool isUrgent, FeeRule rule)
        {
            if (!isUrgent || rule.UrgencyFeePercentage <= 0) return 0m;
            return (baseFee * rule.UrgencyFeePercentage) / 100m;
        }
}
