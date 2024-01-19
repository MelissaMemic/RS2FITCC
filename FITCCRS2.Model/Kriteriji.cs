using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FITCCRS2.Model
{
    public class Kriteriji
    {
        [Key]
        public int KriterijId { get; set; }
        public string Naziv { get; set; }
        public string Vrijednost { get; set; }
        public int? KategorijaId { get; set; }

        public virtual Kategorija Kategorija { get; set; }
    }
}
