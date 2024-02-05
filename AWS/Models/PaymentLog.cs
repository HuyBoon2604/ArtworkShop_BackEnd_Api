using System;
using System.Collections.Generic;

namespace AWS.Models
{
    public partial class PaymentLog
    {
        public string PaymentLogId { get; set; } = null!;
        public string? PaymentId { get; set; }
        public string? UserId { get; set; }
        public string? OrderId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? Status { get; set; }
        public string? TransactionCode { get; set; }

        public virtual Ordertb? Order { get; set; }
        public virtual Payment? Payment { get; set; }
        public virtual Usertb? User { get; set; }
    }
}
