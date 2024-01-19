using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FITCCRS2.Model
{
    public class Agenda
    {
        public int AgendaId { get; set; }
        public int? Dan { get; set; }
        public int? TakmicenjeId { get; set; }

        public virtual Takmicenje Takmicenje { get; set; }
    }
}
