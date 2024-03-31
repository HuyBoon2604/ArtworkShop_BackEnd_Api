using System;
using System.Collections.Generic;

namespace AWS.Models
{
    public partial class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public string? OrderId { get; set; }
        public string? ArtworkId { get; set; }
        public bool? Status { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }

        public virtual Artwork? Artwork { get; set; }
        public virtual Ordertb? Order { get; set; }
    }
}
