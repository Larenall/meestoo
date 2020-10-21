using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace meestoo
{
    public partial class postgresContext : DbContext
    {
        public postgresContext()
        {
        }

        public postgresContext(DbContextOptions<postgresContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Fact> Fact { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<Info> Info { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserFeedbackReaction> UserFeedbackReaction { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Fact>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("fact_pkey");

                entity.ToTable("fact");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Lat).HasColumnName("lat");

                entity.Property(e => e.Lng).HasColumnName("lng");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.HasKey(e => e.FeedbackId)
                    .HasName("feedback_pkey");

                entity.ToTable("feedback");

                entity.Property(e => e.FeedbackId).HasColumnName("feedback_id")
                .ValueGeneratedOnAdd();

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Karma).HasColumnName("karma");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Feedback)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("feedback_fkey");
            });

            modelBuilder.Entity<UserFeedbackReaction>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("userfeedbackreaction_pkey");


                entity.ToTable("userfeedbackreaction");
                entity.Property(e => e.Id).HasColumnName("id")
                .ValueGeneratedOnAdd();

                entity.Property(e => e.FeedbackId).HasColumnName("feedback_id");
                

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserFeedbackReaction)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("userfeedbackreaction_user_id_fkey");

                entity.HasOne(d => d.Feedback)
                    .WithMany(p => p.UserFeedbackReaction)
                    .HasForeignKey(d => d.FeedbackId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("userfeedbackreaction_feedback_id_fkey");
            });

            modelBuilder.Entity<Info>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("info_pkey");

                entity.ToTable("info");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description).HasColumnName("description");

            });


            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("users_pkey");

                entity.ToTable("users");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.ImgUrl).HasColumnName("imgurl");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
