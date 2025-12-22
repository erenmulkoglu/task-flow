using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TaskFlow.Core.Entities;


namespace TaskFlow.Data.Context
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<TaskAttachment> TaskAttachments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
                {
                    entity.HasKey(e => e.Id);
                    entity.Property(e => e.Username).IsRequired().HasMaxLength(50);
                    entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                    entity.Property(e => e.PasswordHash).IsRequired();
                    entity.Property(e => e.FirstName).HasMaxLength(50);
                    entity.Property(e => e.LastName).HasMaxLength(50);
                    entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()");

                    entity.HasIndex(e => e.Username).IsUnique();
                    entity.HasIndex(e => e.Email).IsUnique();
                });

            modelBuilder.Entity<TaskItem>(entity =>
           {
               entity.HasKey(e => e.Id);
               entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
               entity.Property(e => e.Description).HasMaxLength(2000);
               entity.Property(e => e.Status).IsRequired();
               entity.Property(e => e.Priority).IsRequired();
               entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()");

               entity.HasOne(e => e.User)
               .WithMany(u => u.Tasks)
               .HasForeignKey(e => e.UserId)
               .OnDelete(DeleteBehavior.Restrict);

               entity.HasOne(e => e.Category)
               .WithMany(c => c.Tasks)
               .HasForeignKey(e => e.CategoryId)
               .OnDelete(DeleteBehavior.SetNull);
           });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Color).HasMaxLength(7);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()");

                entity.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<TaskAttachment>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FileName).IsRequired().HasMaxLength(255);
                entity.Property(e => e.FilePath).IsRequired().HasMaxLength(500);
                entity.Property(e => e.ContentType).HasMaxLength(100);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()");

                entity.HasOne(e => e.Task)
                .WithMany(t => t.Attachments)
                .HasForeignKey(e => e.TaskId)
                .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
