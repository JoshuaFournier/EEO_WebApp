using System;
using System.Collections.Generic;

namespace Predix.Models
{
    public partial class Oeedowntime
    {
        public int OeedowntimeId { get; set; }
        public DateTime? DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public int? Duree { get; set; }
        public string Commentaire { get; set; }
        public int? EquipementId { get; set; }

        public virtual Equipement Equipement { get; set; }
    }
}
