using System;
using System.Collections.Generic;

namespace Predix.Models
{
    public partial class Pays
    {
        public Pays()
        {
            Ville = new HashSet<Ville>();
        }

        public int PaysId { get; set; }
        public string Libelle { get; set; }

        public virtual ICollection<Ville> Ville { get; set; }
    }
}
