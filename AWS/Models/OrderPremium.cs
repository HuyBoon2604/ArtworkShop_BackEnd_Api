using System;
using System.Collections.Generic;

namespace AWS.Models
{
    public partial class OrderPremium
    {
        public OrderPremium()
        {
            OrderPremiumLogs = new HashSet<OrderPremiumLog>();
        }

        public string OrderPremiumId { get; set; } = null!;
        public string? PremiumId { get; set; }
        public DateTime? OrderDate { get; set; }

        public virtual Premium? Premium { get; set; }
        public virtual ICollection<OrderPremiumLog> OrderPremiumLogs { get; set; }
    }
}
