using System;
using System.Collections.Generic;

namespace Predix.Models
{
    public partial class Ligneprod
    {
        public Ligneprod()
        {
            Typeequipement = new HashSet<Typeequipement>();
        }

        public int LigneprodId { get; set; }
        public string Libelle { get; set; }
        public int? TypesiteId { get; set; }

        public virtual ICollection<Typeequipement> Typeequipement { get; set; }
        public virtual Typesite Typesite { get; set; }
    }
}
