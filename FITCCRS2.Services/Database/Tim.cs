using System;
using System.Collections.Generic;

namespace FITCCRS2.Services.Database
{
    public partial class Tim
    {
        public Tim()
        {
            Projekats = new HashSet<Projekat>();
        }

        public int TimId { get; set; }
        public string? Naziv { get; set; }
        public int? BrojClanova { get; set; }
        public int? TakmicenjeId { get; set; }
        public int? UserId { get; set; }
        public string? Username { get; set; }

        public virtual Takmicenje? Takmicenje { get; set; }
        public virtual ICollection<Projekat> Projekats { get; set; }
    }
}
