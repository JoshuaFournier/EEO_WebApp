using System;
using System.Collections.Generic;

namespace Predix.Models
{
    public partial class Raison
    {
        public int RaisonId { get; set; }
        public string Description { get; set; }
        public int? TypeequipementId { get; set; }

        public virtual Typeequipement Typeequipement { get; set; }
    }
}
