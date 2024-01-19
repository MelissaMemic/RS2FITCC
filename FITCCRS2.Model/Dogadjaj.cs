using System;
using System.Collections.Generic;
using System.Text;

namespace FITCCRS2.Model
{
    public class Dogadjaj
    {
        public int DogadjajId { get; set; }
        public string Naziv { get; set; }
        public int? Trajanje { get; set; }
        public DateTime? Pocetak { get; set; }
        public DateTime? Kraj { get; set; }
        public string Napomena { get; set; }
        public int? AgendaId { get; set; }
        public string Lokacija { get; set; }
    }
}
