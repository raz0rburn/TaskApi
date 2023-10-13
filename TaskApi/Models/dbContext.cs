using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
#nullable disable
using TaskApi.Entities;
namespace TaskApi.Models
{
    public partial class dbContext : DbContext
    {
        public dbContext()
        {
         
        }

        public dbContext(DbContextOptions<dbContext> options)
            : base(options)
        {


        }
        public DbSet<User> Users { get; set; }

        public virtual DbSet<TaskItem> TaskItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("name=ConnectionStrings:DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Russian_Russia.1251");

            modelBuilder.Entity<TaskItem>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(1024)
                    .IsFixedLength(true);
                entity.Property(e => e.Name)
                    .HasMaxLength(128)
                    .IsFixedLength(true);
                entity.Property(e => e.DueDate)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
                entity.Property(e => e.CreationDate)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
                entity.Property(e => e.CompletionDate)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .HasMaxLength(32)
                    .IsFixedLength(true);
                entity.Property(e => e.LastName)
                    .HasMaxLength(32)
                    .IsFixedLength(true);
                entity.Property(e => e.Patronymic)
                    .HasMaxLength(32)
                    .IsFixedLength(true);
                entity.Property(e => e.Username)
                    .HasMaxLength(32)
                    .IsFixedLength(true);
                entity.Property(e => e.Email)
                    .HasMaxLength(32)
                    .IsFixedLength(true);
                entity.Property(e => e.Password)
                    .HasMaxLength(32)
                    .IsFixedLength(true);
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
