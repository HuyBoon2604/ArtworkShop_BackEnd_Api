using System;
using System.Collections.Generic;

namespace AWS.Models
{
    public partial class ArtworkCustome
    {
        public int ArtworkCustomeId { get; set; }
        public string? OrderId { get; set; }
        public string? UserId { get; set; }
        public bool? Status { get; set; }
        public DateTime? DeadlineDate { get; set; }
        public string? GenreId { get; set; }
        public string? Description { get; set; }

        public virtual Genre? Genre { get; set; }
        public virtual Ordertb? Order { get; set; }
        public virtual Usertb? User { get; set; }
    }
}
