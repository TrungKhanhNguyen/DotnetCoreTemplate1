using System;
using System.Collections.Generic;

namespace DotnetCoreTemplate.Models
{
    public partial class Target
    {
        public int Id { get; set; }
        public string? Msisdn { get; set; }
        public string? Imei { get; set; }
        public string? Imsi { get; set; }
        public bool? IsRequest { get; set; }
        public bool? IsActive { get; set; }
        public string? TargetName { get; set; }
    }
}
