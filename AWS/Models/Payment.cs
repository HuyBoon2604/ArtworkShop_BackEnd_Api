using System;
using System.Collections.Generic;

namespace AWS.Models
{
    public partial class Payment
    {
        public Payment()
        {
            PaymentLogs = new HashSet<PaymentLog>();
        }

        public string PaymentId { get; set; } = null!;
        public string? OrderId { get; set; }
        public string? UserId { get; set; }
        public string? Status { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? ArtworkId { get; set; }

        public virtual Artwork? Artwork { get; set; }
        public virtual Ordertb? Order { get; set; }
        public virtual Usertb? User { get; set; }
        public virtual ICollection<PaymentLog> PaymentLogs { get; set; }
    }
}
