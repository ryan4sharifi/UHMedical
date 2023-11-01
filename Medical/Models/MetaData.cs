using System;
using System.Collections.Generic;

namespace Medical.Models
{
    public partial class MetaData
    {
        public int MetaDataId { get; set; }
        public string LoginInfo { get; set; } = null!;
        public string Changelog { get; set; } = null!;
        public string IdentifierNumber { get; set; } = null!;
    }
}
