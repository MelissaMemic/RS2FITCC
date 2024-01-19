using System;
using System.Collections.Generic;
using System.Text;

namespace FITCCRS2.Model.Requests.ProjekatRequest
{
    public class ProjekatUpsertRequest
    {
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public int? KategorijaId { get; set; }
        public int? TimId { get; set; }
        public int? UserId { get; set; }
        public string Username { get; set; }
    }
}
