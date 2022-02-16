using System;
using System.Collections.Generic;

namespace DotnetCoreTemplate.Models
{
    public partial class Member
    {
        public int Id { get; set; }
        
        public string? Username { get; set; }
        public string? Password { get; set; }
        public bool? Active { get; set; }
        public bool? IsAdmin { get; set; }
    }
}
