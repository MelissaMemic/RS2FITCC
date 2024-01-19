using System;
namespace FITCCRS2.Model.Requests.NapomenaRequest
{
	public class NapomenaUpsertRequest
	{
        public int NapomenaId { get; set; }
        public string Poruka { get; set; }
        public string UsernameTakmicar { get; set; }
        public string UserName { get; set; }
    }
}

