using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace yourspace.Models
{
    public partial class ashenContext : DbContext
    {
        public ashenContext()
        {
        }

        public ashenContext(DbContextOptions<ashenContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<AdminAccount> AdminAccount { get; set; }
        public virtual DbSet<FriendRequest> FriendRequest { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }
        public virtual DbSet<UserAccount> UserAccount { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:estus.database.windows.net,1433;Initial Catalog=ashen;Persist Security Info=False;User ID=ctrlaltelite;Password=theyseeU2;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasIndex(e => e.AccountId)
                    .HasName("UQ__Account__349DA587ACE39D28")
                    .IsUnique();

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Account__A9D10534B3840B73")
                    .IsUnique();

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.HashedPass)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.SaltValue)
                    .IsRequired()
                    .HasMaxLength(16);
            });

            modelBuilder.Entity<AdminAccount>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("AdminAcount_pk");

                entity.HasIndex(e => e.AccountId)
                    .HasName("UQ__AdminAcc__349DA58778BA8517")
                    .IsUnique();

                entity.Property(e => e.AccountId)
                    .HasColumnName("AccountID")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.Account)
                    .WithOne(p => p.AdminAccount)
                    .HasForeignKey<AdminAccount>(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("AdminAccount_fk");
            });

            modelBuilder.Entity<FriendRequest>(entity =>
            {
                entity.HasKey(e => new { e.SenderId, e.ReceiverId })
                    .HasName("FriendRequest_pk");

                entity.Property(e => e.SenderId).HasColumnName("SenderID");

                entity.Property(e => e.ReceiverId).HasColumnName("ReceiverID");

                entity.Property(e => e.DateSent).HasColumnType("date");

                entity.HasOne(d => d.Receiver)
                    .WithMany(p => p.FriendRequestReceiver)
                    .HasForeignKey(d => d.ReceiverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FriendReq__Recei__0A9D95DB");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.FriendRequestSender)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FriendReq__Sende__09A971A2");
            });

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.HasKey(e => new { e.AccountId, e.PostTime })
                    .HasName("Post_pk");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.PostTime)
                    .HasColumnName("postTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.PhotoPath)
                    .HasColumnName("photoPath")
                    .HasMaxLength(25);

                entity.Property(e => e.TextPost)
                    .HasColumnName("textPost")
                    .HasMaxLength(150);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Posts_fk");
            });

            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("UserAccount_pk");

                entity.HasIndex(e => e.AccountId)
                    .HasName("UQ__UserAcco__349DA5874C18D4EF")
                    .IsUnique();

                entity.Property(e => e.AccountId)
                    .HasColumnName("AccountID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Biography).HasMaxLength(255);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.MiddleName).HasMaxLength(128);

                entity.Property(e => e.Occupation).HasMaxLength(70);

                entity.Property(e => e.PhoneNumber).HasMaxLength(15);

                entity.Property(e => e.PhotoPath).HasMaxLength(100);

                entity.Property(e => e.RelationStatus).HasMaxLength(30);

                entity.Property(e => e.ULocation)
                    .HasColumnName("uLocation")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Account)
                    .WithOne(p => p.UserAccount)
                    .HasForeignKey<UserAccount>(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserAccount_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
