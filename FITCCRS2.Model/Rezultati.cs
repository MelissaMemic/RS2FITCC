using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FITCCRS2.Model
{
    public class Rezultati
    {
        [Key]
        public int RezultatId { get; set; }
        public int? Bod { get; set; }
        public string Napomena { get; set; }
        public int? ProjekatId { get; set; }

        public Projekat Projekat { get; set; }
    }
}
