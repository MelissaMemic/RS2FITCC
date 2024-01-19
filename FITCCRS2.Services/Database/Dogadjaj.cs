using System;
using System.Collections.Generic;

namespace FITCCRS2.Services.Database
{
    public partial class Dogadjaj
    {
        public Dogadjaj()
        {
            Predavacs = new HashSet<Predavac>();
        }

        public int DogadjajId { get; set; }
        public string? Naziv { get; set; }
        public int? Trajanje { get; set; }
        public DateTime? Pocetak { get; set; }
        public DateTime? Kraj { get; set; }
        public string? Napomena { get; set; }
        public int? AgendaId { get; set; }
        public string? Lokacija { get; set; }

        public virtual Agendum? Agenda { get; set; }

        public virtual ICollection<Predavac> Predavacs { get; set; }
    }
}
