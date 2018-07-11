using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BloggingPlatformBackend.Models
{
    public partial class BloggingPlatformDB : DbContext
    {
        public BloggingPlatformDB()
        {
        }

        public BloggingPlatformDB(DbContextOptions<BloggingPlatformDB> options)
            : base(options)
        {
        }

        public virtual DbSet<BlogPost> BlogPosts { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<PostTags> PostTags { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPost>(entity =>
            {
                entity.HasIndex(e => e.Slug)
                    .HasName("UQ__BlogPost__BC7B5FB6B0D63F8C")
                    .IsUnique();

                entity.Property(e => e.Slug).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasOne(d => d.BlogPost)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.BlogPostID)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Comment__BlogPos__5629CD9C");
            });

            modelBuilder.Entity<PostTags>(entity =>
            {
                entity.HasKey(e => new { e.BlogPostID, e.TagID });

                entity.HasOne(d => d.BlogPost)
                    .WithMany(p => p.PostTags)
                    .HasForeignKey(d => d.BlogPostID)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__PostTags__BlogPo__60A75C0F");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.PostTags)
                    .HasForeignKey(d => d.TagID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PostTags__TagID__619B8048");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasIndex(e => e.TagName)
                    .HasName("UQ__Tag__BDE0FD1DF380243B")
                    .IsUnique();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
