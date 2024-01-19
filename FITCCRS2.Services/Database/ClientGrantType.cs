using System;
using System.Collections.Generic;

namespace FITCCRS2.Services.Database
{
    public partial class ClientGrantType
    {
        public int Id { get; set; }
        public string GrantType { get; set; } = null!;
        public int ClientId { get; set; }

        public virtual Client Client { get; set; } = null!;
    }
}
