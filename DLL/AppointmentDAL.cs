using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using visavault_g43.database;
using System.Threading.Tasks;
using visavault_g43.Models;

namespace visavault_g43.DLL
{
    internal class AppointmentDAL
    {
        public static DataTable GetAppointments(DateTime? filterDate = null)
        {
            string query = "SELECT a.appointment_id, a.client_id, c.client_name, a.appointment_date, a.purpose, a.status " +
                           "FROM appointment a " +
                           "JOIN client c ON a.client_id = c.client_id";
            if (filterDate.HasValue)
            {
                query += " WHERE DATE(a.appointment_date) = @FilterDate";
                MySqlParameter[] parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@FilterDate", filterDate.Value.Date)
                };
                return new Database().ExecuteQuery(query, parameters);
            }
            return new Database().ExecuteQuery(query);
        }
        public static DataTable GetTodaysAppointments()
        {
            string query = "SELECT a.appointment_id, a.client_id, c.client_name, a.appointment_date, a.purpose, a.status " +
                           "FROM appointment a " +
                           "JOIN client c ON a.client_id = c.client_id " +
                           "WHERE DATE(a.appointment_date) = CURDATE()";
            return new Database().ExecuteQuery(query);
        }
        public static int InsertAppointment(Appointment appointment)
        {
            string query = "INSERT INTO appointment (appointment_date, status, purpose, user_id, client_id) " +
                           "VALUES (@AppointmentDate, @Status, @Purpose, @UserId, @ClientId)";
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@AppointmentDate", appointment.AppointmentDate),
                new MySqlParameter("@Status", appointment.Status),
                new MySqlParameter("@Purpose", appointment.Purpose),
                new MySqlParameter("@UserId", appointment.UserId),
                new MySqlParameter("@ClientId", appointment.ClientId)
            };
            return new Database().ExecuteNonQuery(query, parameters);
        }
        public static int UpdateAppoin]tmentStatus(int appointmentId, string status)
        {
            string query = "UPDATE appointment SET status = @Status WHERE appointment_id = @AppointmentId";
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@Status", status),
                new MySqlParameter("@AppointmentId", appointmentId)
            };
            return new Database().ExecuteNonQuery(query, parameters);
        }
        public static DataTable GetAppointmentById(int appointmentId)
        {
            string query = "SELECT a.appointment_id, a.client_id, c.client_name, a.appointment_date, a.purpose, a.status " +
                           "FROM appointment a " +
                           "JOIN client c ON a.client_id = c.client_id " +
                           "WHERE a.appointment_id = @AppointmentId";
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@AppointmentId", appointmentId)
            };
            return new Database().ExecuteQuery(query, parameters);
        }
        public static int GetTodaysAppointmentCount()
        {
            string query = "SELECT COUNT(*) FROM appointment WHERE DATE(appointment_date) = CURDATE()";
            object result = new Database().ExecuteScalar(query);
            return Convert.ToInt32(result);
        }
    }
}
