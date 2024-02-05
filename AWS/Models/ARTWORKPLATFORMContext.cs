using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AWS.Models
{
    public partial class ARTWORKPLATFORMContext : DbContext
    {
        public ARTWORKPLATFORMContext()
        {
        }

        public ARTWORKPLATFORMContext(DbContextOptions<ARTWORKPLATFORMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artwork> Artworks { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<Ordertb> Ordertbs { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<PaymentLog> PaymentLogs { get; set; } = null!;
        public virtual DbSet<Premium> Premia { get; set; } = null!;
        public virtual DbSet<Report> Reports { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<TransactionLog> TransactionLogs { get; set; } = null!;
        public virtual DbSet<Usertb> Usertbs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=ARTWORKPLATFORM;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artwork>(entity =>
            {
                entity.ToTable("Artwork");

                entity.Property(e => e.ArtworkId)
                    .HasMaxLength(50)
                    .HasColumnName("ArtworkID");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.GenreId)
                    .HasMaxLength(50)
                    .HasColumnName("GenreID");

                entity.Property(e => e.ImageUrl).HasColumnName("ImageURL");

                entity.Property(e => e.LikeTimes).HasColumnName("Like_times");

                entity.Property(e => e.LinkShare).HasMaxLength(255);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Reason).HasMaxLength(255);

                entity.Property(e => e.Status).HasMaxLength(255);

                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Artworks)
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("FK__Artwork__GenreID__05D8E0BE");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Artworks)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Artwork__UserID__06CD04F7");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.Property(e => e.CommentId)
                    .HasMaxLength(50)
                    .HasColumnName("CommentID");

                entity.Property(e => e.ArtworkId)
                    .HasMaxLength(50)
                    .HasColumnName("ArtworkID");

                entity.Property(e => e.Text).HasMaxLength(255);

                entity.Property(e => e.Timestamp).HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.Artwork)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.ArtworkId)
                    .HasConstraintName("FK__Comment__Artwork__07C12930");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Comment__UserID__08B54D69");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.Property(e => e.FeedbackId)
                    .HasMaxLength(50)
                    .HasColumnName("FeedbackID");

                entity.Property(e => e.Timestamp).HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Feedback__UserID__09A971A2");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("Genre");

                entity.Property(e => e.GenreId)
                    .HasMaxLength(50)
                    .HasColumnName("GenreID");

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Ordertb>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__Ordertb__C3905BAF203F1502");

                entity.ToTable("Ordertb");

                entity.Property(e => e.OrderId)
                    .HasMaxLength(50)
                    .HasColumnName("OrderID");

                entity.Property(e => e.ArtworkId)
                    .HasMaxLength(50)
                    .HasColumnName("ArtworkID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.Artwork)
                    .WithMany(p => p.Ordertbs)
                    .HasForeignKey(d => d.ArtworkId)
                    .HasConstraintName("FK__Ordertb__Artwork__0C85DE4D");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Ordertbs)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Ordertb__UserID__0D7A0286");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.PaymentId)
                    .HasMaxLength(50)
                    .HasColumnName("PaymentID");

                entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ArtworkId)
                    .HasMaxLength(50)
                    .HasColumnName("ArtworkID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.OrderId)
                    .HasMaxLength(50)
                    .HasColumnName("OrderID");

                entity.Property(e => e.Status).HasMaxLength(255);

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.Artwork)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.ArtworkId)
                    .HasConstraintName("FK__Payment__Artwork__0E6E26BF");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__Payment__OrderID__0F624AF8");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Payment__UserID__10566F31");
            });

            modelBuilder.Entity<PaymentLog>(entity =>
            {
                entity.ToTable("Payment_Log");

                entity.Property(e => e.PaymentLogId)
                    .HasMaxLength(50)
                    .HasColumnName("PaymentLogID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.OrderId)
                    .HasMaxLength(50)
                    .HasColumnName("OrderID");

                entity.Property(e => e.PaymentId)
                    .HasMaxLength(50)
                    .HasColumnName("PaymentID");

                entity.Property(e => e.Status).HasMaxLength(255);

                entity.Property(e => e.TransactionCode).HasMaxLength(255);

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.PaymentLogs)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__Payment_L__Order__114A936A");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.PaymentLogs)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK__Payment_L__Payme__123EB7A3");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PaymentLogs)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Payment_L__UserI__1332DBDC");
            });

            modelBuilder.Entity<Premium>(entity =>
            {
                entity.ToTable("Premium");

                entity.Property(e => e.PremiumId)
                    .HasMaxLength(50)
                    .HasColumnName("PremiumID");

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.NumberOfUses)
                    .HasMaxLength(20)
                    .HasColumnName("number_of_uses");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("price");

                entity.Property(e => e.UsedTime)
                    .HasMaxLength(20)
                    .HasColumnName("Used_Time");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.ToTable("Report");

                entity.Property(e => e.ReportId)
                    .HasMaxLength(50)
                    .HasColumnName("ReportID");

                entity.Property(e => e.ArtworkId)
                    .HasMaxLength(50)
                    .HasColumnName("ArtworkID");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.ReportDate).HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.Artwork)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.ArtworkId)
                    .HasConstraintName("FK__Report__ArtworkI__14270015");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Report__UserID__151B244E");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId)
                    .HasMaxLength(50)
                    .HasColumnName("Role_Id");

                entity.Property(e => e.RoleName).HasMaxLength(20);
            });

            modelBuilder.Entity<TransactionLog>(entity =>
            {
                entity.HasKey(e => e.TransactionId)
                    .HasName("PK__Transact__55433A4B284AE0C9");

                entity.ToTable("Transaction_Log");

                entity.Property(e => e.TransactionId)
                    .HasMaxLength(50)
                    .HasColumnName("TransactionID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.FeedbackId)
                    .HasMaxLength(50)
                    .HasColumnName("FeedbackID");

                entity.Property(e => e.OrderId)
                    .HasMaxLength(50)
                    .HasColumnName("OrderID");

                entity.Property(e => e.Status).HasMaxLength(255);

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.TransactionLogs)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__Transacti__Order__160F4887");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TransactionLogs)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Transacti__UserI__17036CC0");
            });

            modelBuilder.Entity<Usertb>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Usertb__1788CCAC59B4F185");

                entity.ToTable("Usertb");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .HasColumnName("UserID");

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.BankNumber).HasMaxLength(20);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Fullname).HasMaxLength(255);

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(255)
                    .HasColumnName("ImageURL");

                entity.Property(e => e.Noti).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.PremiumId)
                    .HasMaxLength(50)
                    .HasColumnName("PremiumID");

                entity.Property(e => e.RoleId)
                    .HasMaxLength(50)
                    .HasColumnName("Role_Id");

                entity.Property(e => e.Sex).HasMaxLength(10);

                entity.Property(e => e.Username).HasMaxLength(255);

                entity.HasOne(d => d.Premium)
                    .WithMany(p => p.Usertbs)
                    .HasForeignKey(d => d.PremiumId)
                    .HasConstraintName("FK__Usertb__PremiumI__19DFD96B");

                entity.HasMany(d => d.ArtworksNavigation)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "LikeCollection",
                        l => l.HasOne<Artwork>().WithMany().HasForeignKey("ArtworkId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Like_Coll__Artwo__0A9D95DB"),
                        r => r.HasOne<Usertb>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Like_Coll__UserI__0B91BA14"),
                        j =>
                        {
                            j.HasKey("UserId", "ArtworkId").HasName("PK__Like_Col__BA8FF6476F2CDC81");

                            j.ToTable("Like_Collection");

                            j.IndexerProperty<string>("UserId").HasMaxLength(50).HasColumnName("UserID");

                            j.IndexerProperty<string>("ArtworkId").HasMaxLength(50).HasColumnName("ArtworkID");
                        });

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserRole",
                        l => l.HasOne<Role>().WithMany().HasForeignKey("RoleId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__User_Role__Role___17F790F9"),
                        r => r.HasOne<Usertb>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__User_Role__UserI__18EBB532"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId").HasName("PK__User_Rol__BA0867E792568799");

                            j.ToTable("User_Role");

                            j.IndexerProperty<string>("UserId").HasMaxLength(50).HasColumnName("UserID");

                            j.IndexerProperty<string>("RoleId").HasMaxLength(50).HasColumnName("Role_Id");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
