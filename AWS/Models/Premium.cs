using System;
using System.Collections.Generic;

namespace AWS.Models
{
    public partial class Premium
    {
        public Premium()
        {
            Usertbs = new HashSet<Usertb>();
        }

        public string PremiumId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string NumberOfUses { get; set; } = null!;
        public string UsedTime { get; set; } = null!;

        public virtual ICollection<Usertb> Usertbs { get; set; }
    }
}
