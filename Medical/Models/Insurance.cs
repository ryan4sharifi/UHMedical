using System;
using System.Collections.Generic;

namespace Medical.Models
{
    public partial class Insurance
    {
        public Insurance()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int InsuranceId { get; set; }
        public int PatientId { get; set; }
        public string InsuranceName { get; set; } = null!;

        public virtual Patient Patient { get; set; } = null!;
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
