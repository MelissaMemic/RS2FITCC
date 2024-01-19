using System;
using System.Collections.Generic;
using System.Text;

namespace FITCCRS2.Model.Requests.AktivnostRequest
{
    public class AktivnostUpdateRequest
    {
        public string Naziv { get; set; }
        public DateTime Pocetak { get; set; }
        public DateTime Kraj { get; set; }
        public string Lokacija { get; set; }
        public float Trajanje { get; set; }
    }
}
