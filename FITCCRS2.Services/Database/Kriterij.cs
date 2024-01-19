using System;
using System.Collections.Generic;

namespace FITCCRS2.Services.Database
{
    public partial class Kriterij
    {
        public int KriterijId { get; set; }
        public string? Naziv { get; set; }
        public string? Vrijednost { get; set; }
        public int? KategorijaId { get; set; }

        public virtual Kategorija? Kategorija { get; set; }
    }
}
