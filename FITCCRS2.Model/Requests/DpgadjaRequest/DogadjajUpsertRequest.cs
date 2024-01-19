using System;

namespace FITCCRS2.Model.Requests.DpgadjaRequest
{
    public class DogadjajUpsertRequest
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
