using System;
namespace FITCCRS2.Model
{
	public class DogadjajiPerAgenda
	{
        public int AgendaId { get; set; }
        public int? Dan { get; set; }
        public int? TakmicenjeId { get; set; }
        public int DogadjajId { get; set; }
        public string Naziv { get; set; }
        public int? Trajanje { get; set; }
        public DateTime? Pocetak { get; set; }
        public DateTime? Kraj { get; set; }
        public string Napomena { get; set; }
        public string Lokacija { get; set; }
    }
}

