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
        private string connString = "Server=localhost;Port=3306;Database=visa_vault;Uid=root;Pwd=";
        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connString);
        }
        public DataTable ExecuteQuery(string query, MySqlParameter[] parameters = null)
        {
            using (MySqlConnection conn = GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                if (parameters != null) cmd.Parameters.AddRange(parameters);
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
        public int ExecuteNonQuery(string query, MySqlParameter[] parameters = null)
        {
            using (MySqlConnection conn = GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                if (parameters != null) cmd.Parameters.AddRange(parameters);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public object ExecuteScalar(string query, MySqlParameter[] parameters = null)
        {
            using (MySqlConnection conn = GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                if (parameters != null) cmd.Parameters.AddRange(parameters);
                conn.Open();
                return cmd.ExecuteScalar();
            }
        }

        public void ExecuteTransaction(Action<MySqlConnection, MySqlTransaction> action)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                using (MySqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        action(conn, tx);
                        tx.Commit();
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        throw new ApplicationException("Transaction failed: " + ex.Message, ex);
                    }
                }
            }
        }
    }
}
