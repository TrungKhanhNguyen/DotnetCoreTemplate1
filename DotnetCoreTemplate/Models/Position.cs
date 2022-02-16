using System;
using System.Collections.Generic;

namespace DotnetCoreTemplate.Models
{
    public partial class Position
    {

        public int Id { get; set; }
        public string? Imsi { get; set; }
        public string? Msisdn { get; set; }
        public string? Cgi { get; set; }
        public string? Kind { get; set; }
        public string? Lat { get; set; }
        public string? Lon { get; set; }
        public string? Radius { get; set; }
        public string? PlanName { get; set; }
        public DateTime? RequestTime { get; set; }
        public string? AngleStart { get; set; }
        public string? AngleEnd { get; set; }
        public string? Imei { get; set; }
    }
}
