using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITCCRS2.Services.Database
{
    public partial class AspNetUserRole
    {
        public string RoleId { get; set; } = null!;
        public string UserId { get; set; } = null!;

        public virtual AspNetRole Role { get; set; } = null!;
        public virtual AspNetUser User { get; set; } = null!;
    }
}
