using System;
using System.Collections.Generic;
using System.Text;

namespace FITCCRS2.Model
{
    public class Takmicenje
    {
        public int TakmicenjeId { get; set; }
        public string Naziv { get; set; }
        public string Slogan { get; set; }
        public DateTime? Pocetak { get; set; }
        public DateTime? Kraj { get; set; }
        public int? Godina { get; set; }
        public int? BrojDana { get; set; }
        public string Slika { get; set; }

        public virtual ICollection<Agenda> Agenda { get; set; }
        public virtual ICollection<Tim> Tims { get; set; }
    }
}
