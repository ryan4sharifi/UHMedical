using System;
using System.Collections.Generic;

namespace Medical.Models
{
    public partial class AppointmentSv
    {
        public int AppointmentId { get; set; }
        public string DoctorName { get; set; } = null!;
        public string PatientName { get; set; } = null!;
        public DateTime DateAppointment { get; set; }
    }
}
