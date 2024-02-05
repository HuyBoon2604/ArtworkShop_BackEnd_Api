using System;
using System.Collections.Generic;

namespace AWS.Models
{
    public partial class Artwork
    {
        public Artwork()
        {
            Comments = new HashSet<Comment>();
            Ordertbs = new HashSet<Ordertb>();
            Payments = new HashSet<Payment>();
            Reports = new HashSet<Report>();
            Users = new HashSet<Usertb>();
        }

        public string ArtworkId { get; set; } = null!;
        public string? UserId { get; set; }
        public string? ImageUrl { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public string? GenreId { get; set; }
        public string? LinkShare { get; set; }
        public string? Status { get; set; }
        public int? LikeTimes { get; set; }
        public DateTime? Time { get; set; }
        public string? Reason { get; set; }

        public virtual Genre? Genre { get; set; }
        public virtual Usertb? User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Ordertb> Ordertbs { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Report> Reports { get; set; }

        public virtual ICollection<Usertb> Users { get; set; }
    }
}
