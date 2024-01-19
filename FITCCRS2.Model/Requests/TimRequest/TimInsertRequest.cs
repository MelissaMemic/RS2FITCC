using System;
using System.Collections.Generic;
using System.Text;

namespace FITCCRS2.Model.Requests.TimRequest
{
    public class TimInsertRequest
    {
        public string Naziv { get; set; }
        public int? BrojClanova { get; set; }
        public int? TakmicenjeId { get; set; }
        public int? UserId { get; set; }
        public string Username { get; set; }

    }
}
