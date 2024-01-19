using System;
using System.Collections.Generic;

namespace FITCCRS2.Services.Database
{
    public partial class Predavac
    {
        public Predavac()
        {
            Dogadjas = new HashSet<Dogadjaj>();
        }

        public int PredavacId { get; set; }
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public int? DogadjaId { get; set; }
        public string? Ustanova { get; set; }
        public string? Zvanje { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<Dogadjaj> Dogadjas { get; set; }
    }
}
