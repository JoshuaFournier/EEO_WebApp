using System;
using System.Collections.Generic;

namespace Predix.Models
{
    public partial class Equipement
    {
        public Equipement()
        {
            Oeedowntime = new HashSet<Oeedowntime>();
        }

        public int EquipementId { get; set; }
        public string Libelle { get; set; }
        public int? TypeequipementId { get; set; }

        public virtual ICollection<Oeedowntime> Oeedowntime { get; set; }
        public virtual Typeequipement Typeequipement { get; set; }
    }
}
