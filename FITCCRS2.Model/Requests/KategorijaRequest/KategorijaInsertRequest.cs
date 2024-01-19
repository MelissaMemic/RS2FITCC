using System;
using System.Collections.Generic;
using System.Text;

namespace FITCCRS2.Model.Requests
{
    public class KategorijaInsertRequest
    {
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public int? TakmicenjeId { get; set; }
    }
}
