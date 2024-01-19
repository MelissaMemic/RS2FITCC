using System;
using System.Collections.Generic;

namespace FITCCRS2.Services.Database
{
    public partial class Rezultat
    {
        public int RezultatId { get; set; }
        public int? Bod { get; set; }
        public string? Napomena { get; set; }
        public int? ProjekatId { get; set; }

        public virtual Projekat? Projekat { get; set; }
    }
}
