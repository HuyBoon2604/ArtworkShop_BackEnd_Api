using System;
using System.Collections.Generic;

namespace AWS.Models
{
    public partial class OrderPremiumLog
    {
        public string OrderPremiumLogId { get; set; } = null!;
        public string? OrderPremiumId { get; set; }
        public DateTime? LogDate { get; set; }

        public virtual OrderPremium? OrderPremium { get; set; }
    }
}
