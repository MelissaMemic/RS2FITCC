using System;
using System.Collections.Generic;

namespace FITCCRS2.Services.Database
{
    public partial class Agendum
    {
        public Agendum()
        {
            Dogadjajs = new HashSet<Dogadjaj>();
        }

        public int AgendaId { get; set; }
        public int? Dan { get; set; }
        public int? TakmicenjeId { get; set; }

        public virtual Takmicenje? Takmicenje { get; set; }
        public virtual ICollection<Dogadjaj> Dogadjajs { get; set; }
    }
}
