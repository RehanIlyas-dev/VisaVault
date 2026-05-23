using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace visavault_g43.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
        public string Purpose { get; set; }
        public int UserId { get; set; }
        public int ClientId { get; set; }

        public Appointment(int AppointmentId, int ClientId, int UserId, string Purpose, DateTime AppointmentDate, string Status)
        {
            this.AppointmentId = AppointmentId;
            this.ClientId = ClientId;
            this.UserId = UserId;
            this.Purpose = Purpose;
            this.AppointmentDate = AppointmentDate;
            this.Status = Status;
        }
    }
}

    
