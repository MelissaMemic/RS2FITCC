using System;
using System.Collections.Generic;

namespace FITCCRS2.Services.Database
{
    public partial class Kategorija
    {
        public Kategorija()
        {
            Kriterijs = new HashSet<Kriterij>();
            Projekats = new HashSet<Projekat>();
            Sponzors = new HashSet<Sponzor>();
        }

        public int KategorijaId { get; set; }
        public string? Naziv { get; set; }
        public string? Opis { get; set; }
        public int? TakmicenjeId { get; set; }

        public virtual Takmicenje? Takmicenje { get; set; }
        public virtual ICollection<Kriterij> Kriterijs { get; set; }
        public virtual ICollection<Projekat> Projekats { get; set; }
        public virtual ICollection<Sponzor> Sponzors { get; set; }
    }
}
