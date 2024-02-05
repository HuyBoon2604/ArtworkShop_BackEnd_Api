using System;
using System.Collections.Generic;

namespace AWS.Models
{
    public partial class TransactionLog
    {
        public string TransactionId { get; set; } = null!;
        public string? UserId { get; set; }
        public string? OrderId { get; set; }
        public string? Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? FeedbackId { get; set; }

        public virtual Ordertb? Order { get; set; }
        public virtual Usertb? User { get; set; }
    }
}
