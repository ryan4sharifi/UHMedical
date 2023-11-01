using System;
using System.Collections.Generic;

namespace Medical.Models
{
    public partial class DoctorList
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; } = null!;
        public string? Office { get; set; }
        public string Classification { get; set; } = null!;
    }
}
