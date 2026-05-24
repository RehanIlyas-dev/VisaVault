using MySql.Data.MySqlClient;
using System;
using System.Data;
using visavault_g43;
using visavault_g43.Models;

namespace visavault_g43.DLL
{
    public static class ClientDAL
    {
        static Database db = new Database();

        public static DataTable GetAllClients()
        {
            string query = "SELECT * FROM client WHERE status = 'Active';";
            return db.ExecuteQuery(query);
        }
        public static DataTable SearchClient(string keyword, string filter)
        {
            string query = $"SELECT * FROM client WHERE {filter} LIKE @k;";
            MySqlParameter[] parameters = { new MySqlParameter("@k", "%" + keyword + "%") };
            return db.ExecuteQuery(query, parameters);
        }
        public static DataTable GetClientById(int clientId)
        {
            string query = "SELECT * FROM client WHERE client_id = @id;";
            MySqlParameter[] parameters = { new MySqlParameter("@id", clientId) };
            return db.ExecuteQuery(query, parameters);
        }

        public static int InsertClient(Client client)
        {
            string query = "INSERT INTO client(client_name, cnic_no, email, contact_no, address, country_id) VALUES(@n, @cnic, @e, @cont, @a, @coun);";
            MySqlParameter[] parameters = {
                new MySqlParameter("@n", client.ClientName),
                new MySqlParameter("@cnic", client.CnicNo),
                new MySqlParameter("@e", client.Email),
                new MySqlParameter("@cont", client.ContactNo),
                new MySqlParameter("@a", client.Address),
                new MySqlParameter("@coun", client.CountryId)
            };
            return Convert.ToInt32(db.ExecuteScalar(query, parameters));
        }

        public static bool UpdateClient(Client client)
        {
            string query = "UPDATE client SET client_name=@n, cnic_no=@cnic, email=@e, contact_no=@cont, address=@a, country_id=@coun, status=@s WHERE client_id=@id;";
            MySqlParameter[] parameters = {
                new MySqlParameter("@n", client.ClientName),
                new MySqlParameter("@cnic", client.CnicNo),
                new MySqlParameter("@e", client.Email),
                new MySqlParameter("@cont", client.ContactNo),
                new MySqlParameter("@a", client.Address),
                new MySqlParameter("@coun", client.CountryId),
                new MySqlParameter("@s", client.Status),
                new MySqlParameter("@id", client.ClientId)
            };
            int rowsAffected = db.ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }

        public static bool CNICExists(string cnic, int excludeClientId = 0)
        {
            string query = "SELECT COUNT(*) FROM client WHERE cnic_no=@cnic AND client_id != @excludeId;";
            MySqlParameter[] parameters = {
                new MySqlParameter("@cnic", cnic),
                new MySqlParameter("@excludeId", excludeClientId)
            };

            int count = Convert.ToInt32(db.ExecuteScalar(query, parameters));
            return count > 0;
        }

        public static bool UpdateClientStatus(int clientId, string newStatus)
        {
            string query = "UPDATE client SET status=@s WHERE client_id=@id;";
            MySqlParameter[] parameters = {
                new MySqlParameter("@s", newStatus),
                new MySqlParameter("@id", clientId)
            };
            int rowsAffected = db.ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }
        public static int GetTotalClientCount()
        {
            string query = "SELECT COUNT(*) FROM client;";
            return Convert.ToInt32(db.ExecuteScalar(query));
        }
    }
}