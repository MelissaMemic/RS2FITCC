using System;
using System.Collections.Generic;
using System.Text;

namespace FITCCRS2.Model.Requests.UserRequest
{
    public class UserUpsertRequest
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public bool? IsAllowed { get; set; }
        public string Username { get; set; }
        public string Website { get; set; }
        public string Role { get; set; }
    }
}
