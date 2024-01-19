using System;
using System.Collections.Generic;
using System.Text;

namespace FITCCRS2.Model
{
    public class Kategorija
    {
        public int KategorijaId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public int? TakmicenjeId { get; set; }

        public virtual ICollection<Kriteriji> Kriterijs { get; set; }
        public virtual ICollection<Projekat> Projekats { get; set; }
    }
}
