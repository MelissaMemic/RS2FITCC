using System;
using System.Collections.Generic;
using System.Text;

namespace FITCCRS2.Model
{
    public class Predavac
    {
        public int PredavacId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int? DogadjaId { get; set; }
        public string Ustanova { get; set; }
        public string Zvanje { get; set; }
        public string Email { get; set; }
    }
}
