using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using visavault_g43.Models;

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
            DataTable dt = AppointmentDAL.GetTodayAppointments(); // Assuming AppointmentDAL has a method to get today's appointments
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

            int newId = AppointmentDAL.BookAppointment(appointment); // Assuming AppointmentDAL has a method to book an appointment and returns the new appointment ID
            if (newId > 0)
            {
                appointment.AppointmentId = newId; // Set the new appointment ID
                return ValidationResult.Success("Appointment booked successfully.");
            }
            else
            {
                return ValidationResult.Failure("Failed to book appointment. Please try again.");
            }
            
            return ValidationResult.Success("Appointment booked successfully.");
        }

        public static ValidationResult MarkComplete(int AppoinmentID) 
        {
            return ChangeStatus(AppoinmentID, "Completed"); 
        }

        public static ValidationResult MarkUnAttended(int AppoinmentID)
        {
            return ChangeStatus(AppoinmentID, "Unattended");
        }

        public static ValidationResult CancelAppointment(int AppoinmentID)
        {
            return ChangeStatus(AppoinmentID, "Cancelled");
        }

        public static bool isToday(Appointment appointment)
        {
            if(appointment == null) return false;
            return appointment.AppointmentDate.Date == DateTime.Today;
        }

        public static int GetTodayAppointmentCount()
        {
            return AppointmentsDAL.GetTodayAppointmentCount(); // Assuming AppointmentDAL has a method to get the count of today's appointments
        }

        public static ValidationResult ChangeStatus(int appointmentId, string status)
        {
            if(appointmentId <= 0)
                return ValidationResult.Failure("Invalid appointment ID.");
            DataTable dt = AppointmentDAL.GetAppointmentById(appointmentId); // Assuming AppointmentDAL has a method to get an appointment by ID

            if (dt.Rows.Count == 0)
                return ValidationResult.Failure("Appointment not found.");

            int rowsAffected = AppointmentDAL.UpdateAppointmentStatus(appointmentId, status); // Assuming AppointmentDAL has a method to update the appointment status
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
                appointments.Add(new Appointment(
                    Convert.ToInt32(row["AppointmentId"]),
                    Convert.ToInt32(row["ClientId"]),
                    Convert.ToInt32(row["UserId"]),
                    row["Purpose"].ToString(),
                    Convert.ToDateTime(row["AppointmentDate"]),
                    row["Status"].ToString()
                ));
            }
            return appointments;
        }
    }
}
