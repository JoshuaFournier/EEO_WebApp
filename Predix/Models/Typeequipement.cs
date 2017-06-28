using System;
using System.Collections.Generic;

namespace Predix.Models
{
    public partial class Typeequipement
    {
        public Typeequipement()
        {
            Equipement = new HashSet<Equipement>();
            Raison = new HashSet<Raison>();
        }

        public int TypeequipementId { get; set; }
        public string Libelle { get; set; }
        public int? LigneprodId { get; set; }

        public virtual ICollection<Equipement> Equipement { get; set; }
        public virtual ICollection<Raison> Raison { get; set; }
        public virtual Ligneprod Ligneprod { get; set; }
    }
}
