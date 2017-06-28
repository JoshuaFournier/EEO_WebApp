using System;
using System.Collections.Generic;

namespace Predix.Models
{
    public partial class Typesite
    {
        public Typesite()
        {
            Ligneprod = new HashSet<Ligneprod>();
        }

        public int TypesiteId { get; set; }
        public string Libelle { get; set; }
        public int? VilleId { get; set; }

        public virtual ICollection<Ligneprod> Ligneprod { get; set; }
        public virtual Ville Ville { get; set; }
    }
}
