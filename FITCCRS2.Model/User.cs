using System;
using System.Collections.Generic;
using System.Text;

namespace FITCCRS2.Model
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public bool? IsAllowed { get; set; }
        public string Username { get; set; }
        public string Website { get; set; }
        public string Role { get; set; }
    }
}
