using System;
using System.Collections.Generic;

namespace DotnetCoreTemplate.Models
{
    public partial class LogEvent
    {
        public int Id { get; set; }
        public DateTime? EventDate { get; set; }
        public string? User { get; set; }
        public string? Task { get; set; }
    }
}
