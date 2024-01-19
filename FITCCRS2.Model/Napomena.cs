using System.ComponentModel.DataAnnotations;

namespace FITCCRS2.Model
{
	public class Napomena
	{
        [Key]
        public int NapomenaId { get; set; }
        public string Poruka { get; set; }
        public string UsernameTakmicar { get; set; }
        public string UserName { get; set; }
    }
}

