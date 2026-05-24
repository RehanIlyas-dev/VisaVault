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
    internal class FeeDAL
    {
        static Database db = new Database();
        public static DataTable GetActiveRule(int countryId, int documentTypeId)
        {
          
            string query = "SELECT fee_id, type_id, country_id, valid_from, valid_to, fee_name, base_fee, urgent_fee, processing_fee, " +
                "created_at, updated_at FROM feerule " +
                "WHERE country_id = @CountryId AND type_id = @DocumentTypeId AND CURDATE() >= valid_from  AND CURDATE() <= valid_to;";

            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@CountryId", countryId),
                new MySqlParameter("@DocumentTypeId", documentTypeId)
            };

            return db.ExecuteQuery(query, parameters);
        }
        public static DataTable GetFeeRuleById(int feeRuleId)
        {
            string query = "SELECT fee_id, type_id, country_id, valid_from, valid_to, fee_name, base_fee, urgent_fee, processing_fee, " +
                "created_at, updated_at FROM feerule WHERE fee_id = @FeeRuleId;";

            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@FeeRuleId", feeRuleId)
            };
            return db.ExecuteQuery(query, parameters);
        }
        public static DataTable GetAllCountries()
        {
            string query = "SELECT country_id, country_name, country_code FROM country ORDER BY country_name ASC;";
            return db.ExecuteQuery(query);
        }
        public static DataTable GetAllDocumentTypes()
        {
            string query = "SELECT documenttype_id, documenttype_name FROM documenttype ORDER BY documenttype_name ASC;";
            return db.ExecuteQuery(query);
        }
        public static int InsertFeeRule(FeeRule feeRule)
        {
            string query = "INSERT INTO feerule (type_id, country_id, valid_from, valid_to, fee_name, base_fee, urgent_fee, processing_fee)" +
                " VALUES (@TypeId, @CountryId, @ValidFrom, @ValidTo, @FeeName, @BaseFee, @UrgentFee, @ProcessingFee);";

            MySqlParameter[] parameters = new MySqlParameter[]
            {
        new MySqlParameter("@TypeId", feeRule.TypeId),
        new MySqlParameter("@CountryId", feeRule.CountryId),
        new MySqlParameter("@ValidFrom", feeRule.ValidFrom),
        new MySqlParameter("@ValidTo", feeRule.ValidTo),
        new MySqlParameter("@FeeName", feeRule.FeeName),
        new MySqlParameter("@BaseFee", feeRule.BaseFee),
        new MySqlParameter("@UrgentFee", feeRule.UrgentFee),
        new MySqlParameter("@ProcessingFee", feeRule.ProcessingFee)
            };
            return db.ExecuteNonQuery(query, parameters);
        }
        public static int UpdateFeeRule(FeeRule feeRule)
        {
            string query = "UPDATE feerule SET type_id = @TypeId, country_id = @CountryId, valid_from = @ValidFrom, valid_to = @ValidTo, fee_name = @FeeName, base_fee = @BaseFee, urgent_fee = @UrgentFee, processing_fee = @ProcessingFee WHERE fee_id = @FeeId;";

            MySqlParameter[] parameters = new MySqlParameter[]
            {
        new MySqlParameter("@TypeId", feeRule.TypeId),
        new MySqlParameter("@CountryId", feeRule.CountryId),
        new MySqlParameter("@ValidFrom", feeRule.ValidFrom),
        new MySqlParameter("@ValidTo", feeRule.ValidTo),
        new MySqlParameter("@FeeName", feeRule.FeeName),
        new MySqlParameter("@BaseFee", feeRule.BaseFee),
        new MySqlParameter("@UrgentFee", feeRule.UrgentFee),
        new MySqlParameter("@ProcessingFee", feeRule.ProcessingFee),
        new MySqlParameter("@FeeId", feeRule.FeeId)
            };
            return db.ExecuteNonQuery(query, parameters);
        }
    }
}
