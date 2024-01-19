using System;
using System.Collections.Generic;
using System.Text;

namespace FITCCRS2.Model
{
    public class Projekat
    {
        public int ProjekatId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public int? KategorijaId { get; set; }
        public int? TimId { get; set; }
        public int? UserId { get; set; }
        public string Username { get; set; }

        public virtual Kategorija Kategorija { get; set; }
        //public virtual Tim Tim { get; set; }
         public virtual ICollection<Rezultati> Rezultats { get; set; }
    }
}
