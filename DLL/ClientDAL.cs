using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using visavault_g43.database;
using System.Threading.Tasks;

namespace visavault_g43.DLL
{
    internal class ClientDAL
    {
        Database db = new Database();
        public static DataTable GetAllClients()
        {
            string query = "select * from client where status = 'Active';";
            return db.ExecuteQuery(query);
        }
        public static Datatable SrarchClient(string keyword,string filter)
        {
            string query = $"select * from client where @f = @k;";
            MySqlParameter[] parameters = { new MySqlParameter("@f", filter),new MySqlParameter("@k",keyword) };
            return db.ExecuteQuery(query, parameters);
            
        }
        public static DataTable GetClientById(int clientId) {
            string query = "select * from client where client_id = @id;";
            MySqlParameter[] parameters = { new MySqlParameter("@id", clientId) };
            return db.ExecuteQuery(query, parameters);
        }
        public static int InsertClient(ClientDAL client)
        {
            string query = "Insert into client(client_name,cnic_no,email,contact_no,address,country_id) values(@n,@cnic,@e,@cont,@a,@coun);";
            MySqlParameter[] parameters = { new MySqlParameter("@n", client.ClientName), new MySqlParameter("@cnic", client.CnicNo), new MySqlParameter("@e", client.Email), new MySqlParameter("@cont", client.ContactNo), new MySqlParameter("@a", client.Address), new MySqlParameter("@coun", client.CountryId) };
            return db.ExecuteNonQuery(query, parameters);
        }
        public static int UpdateClient(Client client)
        {
            string query = "update client set client_name=@n,cnic_no=@cnic,email=@e,contact_no=@cont,address=@a,country_id=@cont,status=@s where clinet_id=@id;";
            MySqlParameter[] parameters = { new MySqlParameter("@n", client.ClientName), new MySqlParameter("@cnic", client.CnicNo), new MySqlParameter("@e", client.Email), new MySqlParameter("@cont", client.ContactNo), new MySqlParameter("@a", client.Address), new MySqlParameter("@coun", client.CountryId), new MySqlParameter("@status", client.Status), new MySqlParameter("@id", client.ClientId) };
            return db.ExecuteNonQuery(query, parameters);
        }
        public static int UpdateClientStatus(int clientId, string newStatus)
        {
            string query = "update client set status=@s where clinet_id=@id;";
            MySqlParameter[] parameters = {   new MySqlParameter( new MySqlParameter("@status", newStatus), new MySqlParameter("@id", clientId) };
            return db.ExecuteNonQuery(query, parameters);
        }
        public static bool CNICExists(string cnic)
        {
            string query = "select cnic from client where cnic=@cnic;";
            string query = "update client set status=@s where clinet_id=@id;";
            MySqlParameter[] parameters = { new MySqlParameter(new MySqlParameter("@status", newStatus), new MySqlParameter("@id", clientId) };
            return db.ExecuteNonQuery(query, parameters);
        }
    }
}
