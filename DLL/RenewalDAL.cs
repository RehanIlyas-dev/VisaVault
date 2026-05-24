using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace visavault_g43.DLL
{
    internal class RenewalDAL
    {
        rivate static Database db = new Database();

        public static DataTable GetAllCases(string statusFilter = "All", int clientId = 0)
        {
            string query = "SELECT rc.renewalcase_id, rc.currentstage_id, rs.stage_name, rs.stage_no, rc.user_id, rc.document_id, rc.client_id," +
                " rc.created_at, rc.updated_at FROM renewalcase rc JOIN renewalstage rs ON rc.currentstage_id = rs.stage_id " +
                "WHERE (@ClientId = 0 OR rc.client_id = @ClientId) AND (@StatusFilter = 'All' OR (@StatusFilter = 'Active'" +
                " AND rs.stage_name NOT IN ('Completed', 'Rejected')) OR (@StatusFilter = 'Closed' AND " +
                "rs.stage_name IN ('Completed', 'Rejected')) OR (rs.stage_name = @StatusFilter));";

            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@ClientId", clientId),
                new MySqlParameter("@StatusFilter", statusFilter)
            };

            return db.ExecuteQuery(query, parameters);
        }
    }
}
