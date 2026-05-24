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
    internal class AuthDAL
    {
        static Database db = new Database();
        public static DataTable GetUserByEmail(string email)
        {
            string query = "SELECT user_id, username, email, password, last_login, created_at, status FROM user WHERE email = @Email;";

            MySqlParameter[] parameters = new MySqlParameter[]
            {
        new MySqlParameter("@Email", email)
            };
            return db.ExecuteQuery(query, parameters);
        }
        public static DataTable GetUserById(int userId)
        {
            string query = "SELECT user_id, username, email, password, last_login, created_at, status FROM user WHERE user_id = @UserId;";

            MySqlParameter[] parameters = new MySqlParameter[]
            {
        new MySqlParameter("@UserId", userId)
            };
            return db.ExecuteQuery(query, parameters);
        }
        public static int UpdateLastLogin(int userId)
        {
            string query = "UPDATE user SET last_login = CURRENT_TIMESTAMP WHERE user_id = @UserId;";

            MySqlParameter[] parameters = new MySqlParameter[]
            {
        new MySqlParameter("@UserId", userId)
            };
            return db.ExecuteNonQuery(query, parameters);
        }
        public static DataTable GetAllUsers()
        {
            string query = "SELECT user_id, username, email, password, last_login, created_at, status FROM user ORDER BY username ASC;";
            return db.ExecuteQuery(query);
        }
        public static int UpdateUserStatus(int userId, string status)
        {
            string query = "UPDATE user SET status = @Status WHERE user_id = @UserId;";

            MySqlParameter[] parameters = new MySqlParameter[]
            {
        new MySqlParameter("@Status", status),
        new MySqlParameter("@UserId", userId)
            };
            return db.ExecuteNonQuery(query, parameters);
        }
    }
}
