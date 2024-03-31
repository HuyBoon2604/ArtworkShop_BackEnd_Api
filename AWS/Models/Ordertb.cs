using System;
using System.Collections.Generic;

namespace AWS.Models
{
    public partial class Ordertb
    {
        public Ordertb()
        {
            ArtworkCustomes = new HashSet<ArtworkCustome>();
            OrderDetails = new HashSet<OrderDetail>();
            Payments = new HashSet<Payment>();
        }

        public string OrderId { get; set; } = null!;
        public string? UserId { get; set; }
        public string? ArtworkId { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? Status { get; set; }
        public decimal? Total { get; set; }
        public bool? StatusCancel { get; set; }

        public virtual Usertb? User { get; set; }
        public virtual ICollection<ArtworkCustome> ArtworkCustomes { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
