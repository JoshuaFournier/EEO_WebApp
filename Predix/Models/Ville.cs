using System;
using System.Collections.Generic;

namespace Predix.Models
{
    public partial class Ville
    {
        public Ville()
        {
            Typesite = new HashSet<Typesite>();
        }

        public int VilleId { get; set; }
        public string Libelle { get; set; }
        public int? PaysId { get; set; }

        public virtual ICollection<Typesite> Typesite { get; set; }
        public virtual Pays Pays { get; set; }
    }
}
