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
                entity.Property(e => e.Id).HasDefaultValueSql("nextval('\"TaskItem_Id_seq\"'::regclass)");

                entity.Property(e => e.Description)
                    .HasMaxLength(1024)
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .HasMaxLength(128)
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    
    }
}
