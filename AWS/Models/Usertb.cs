using System;
using System.Collections.Generic;

namespace AWS.Models
{
    public partial class Usertb
    {
        public Usertb()
        {
            Artworks = new HashSet<Artwork>();
            Comments = new HashSet<Comment>();
            Feedbacks = new HashSet<Feedback>();
            Ordertbs = new HashSet<Ordertb>();
            PaymentLogs = new HashSet<PaymentLog>();
            Payments = new HashSet<Payment>();
            Reports = new HashSet<Report>();
            TransactionLogs = new HashSet<TransactionLog>();
            ArtworksNavigation = new HashSet<Artwork>();
            Roles = new HashSet<Role>();
        }

        public string UserId { get; set; } = null!;
        public string? RoleId { get; set; }
        public string? ImageUrl { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Fullname { get; set; }
        public string? Sex { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? BankNumber { get; set; }
        public string? Noti { get; set; }
        public string? PremiumId { get; set; }

        public virtual Premium? Premium { get; set; }
        public virtual ICollection<Artwork> Artworks { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Ordertb> Ordertbs { get; set; }
        public virtual ICollection<PaymentLog> PaymentLogs { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<TransactionLog> TransactionLogs { get; set; }

        public virtual ICollection<Artwork> ArtworksNavigation { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
