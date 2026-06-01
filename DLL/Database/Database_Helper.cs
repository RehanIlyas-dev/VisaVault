using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace visavault_g43
{
    internal class Database
    {
        private string connString = "Server=localhost;Port=3306;Database=visa_vault;Uid=root;Pwd=@HA55ANMUGHAL";
        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connString);
        }
        public DataTable ExecuteQuery(string query, MySqlParameter[] parameters = null)
        {
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            if (parameters != null) cmd.Parameters.AddRange(parameters);
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }
        public int ExecuteNonQuery(string query, MySqlParameter[] parameters)
        {
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddRange(parameters);
            conn.Open();
            return cmd.ExecuteNonQuery();
        }
        public object ExecuteScalar(string query, MySqlParameter[] parameters = null)
        {
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }
            conn.Open();
            return cmd.ExecuteScalar();
        }
    }
}
