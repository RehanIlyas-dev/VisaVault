using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using visavault_g43.Models;
using visavault_g43.DLL;

namespace visavault_g43.BLL
{
    public static class AppointmentService
    {
        public static List<Appointment> GetAppointments(DateTime? filterdate = null)
        {
            DataTable dt = AppointmentDAL.GetAppointments(filterdate); // Assuming AppointmentDAL is a data access layer class that retrieves appointments from the database
            return MapDataTableToAppointmentList(dt);
        }

        public static List<Appointment> GetTodayAppointments()
        {
            DataTable dt = AppointmentDAL.GetTodaysAppointments(); // DAL method is GetTodaysAppointments
            return MapDataTableToAppointmentList(dt);
        }

        public static ValidationResult BookAppointment(Appointment appointment)
        {
            if(appointment.AppointmentDate <= DateTime.Now) // Validate that the appointment date is in the future
                return ValidationResult.Failure("Appointment date must be in the future.");
            if(appointment.ClientId <= 0)
                return ValidationResult.Failure("Valid client ID is required.");
            if(appointment.UserId <= 0)
                return ValidationResult.Failure("Valid user ID is required.");

            appointment.Status = "Booked"; // Set the status to "Booked" when creating a new appointment

            // DAL.InsertAppointment returns number of rows affected in current DAL
            int rows = AppointmentDAL.InsertAppointment(appointment);
            if (rows > 0)
            {
                return ValidationResult.Success("Appointment booked successfully.");
            }
            else
            {
                return ValidationResult.Failure("Failed to book appointment. Please try again.");
            }
        }
        
        public static ValidationResult MarkComplete(int appointmentId)
        {
            return ChangeStatus(appointmentId, "Completed");
        }

        public static ValidationResult MarkUnAttended(int appointmentId)
        {
            return ChangeStatus(appointmentId, "Unattended");
        }

        public static ValidationResult CancelAppointment(int appointmentId)
        {
            return ChangeStatus(appointmentId, "Cancelled");
        }

        public static bool isToday(Appointment appointment)
        {
            if(appointment == null) return false;
            return appointment.AppointmentDate.Date == DateTime.Today;
        }

        public static int GetTodayAppointmentCount()
        {
            return AppointmentDAL.GetTodaysAppointmentCount();
        }

        public static ValidationResult ChangeStatus(int appointmentId, string status)
        {
            if(appointmentId <= 0)
                return ValidationResult.Failure("Invalid appointment ID.");
            DataTable dt = AppointmentDAL.GetAppointmentById(appointmentId); 
            if (dt.Rows.Count == 0)
                return ValidationResult.Failure("Appointment not found.");

            int rowsAffected = AppointmentDAL.UpdateAppointmentStatus(appointmentId, status); 
            if (rowsAffected > 0)
                return ValidationResult.Success($"Appointment status updated to {status}.");
            else
                return ValidationResult.Failure("Failed to update appointment status. Please try again.");
        }

        public static List<Appointment> MapDataTableToAppointmentList(DataTable dt) // Helper method to convert DataTable to List<Appointment>
        {
            List<Appointment> appointments = new List<Appointment>();
            foreach (DataRow row in dt.Rows)
            {
                int userId = 0;
                if (dt.Columns.Contains("user_id") && row["user_id"] != DBNull.Value)
                    userId = Convert.ToInt32(row["user_id"]);

                appointments.Add(new Appointment(
                    Convert.ToInt32(row["appointment_id"]),
                    Convert.ToInt32(row["client_id"]),
                    userId,
                    row["purpose"].ToString(),
                    Convert.ToDateTime(row["appointment_date"]),
                    row["status"].ToString(),
                    row.Table.Columns.Contains("client_name") && row["client_name"] != DBNull.Value ? row["client_name"].ToString() : ""
                ));
            }
            return appointments;
        }
    }
}
