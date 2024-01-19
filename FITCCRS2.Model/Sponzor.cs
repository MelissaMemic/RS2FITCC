using System;
using System.Collections.Generic;
using System.Text;

namespace FITCCRS2.Model
{
    public class Sponzor
    {

        public int SponzorId { get; set; }
        public string Naziv { get; set; }
        public string TipSponzorstva { get; set; }
        public int? KategorijaId { get; set; }
        public bool? SponzorKategorije { get; set; }
        public double? Iznos { get; set; }
        public int? Godina { get; set; }

        public virtual Kategorija Kategorija { get; set; }
    }
}
