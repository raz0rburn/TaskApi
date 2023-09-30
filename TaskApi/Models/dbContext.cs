using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
#nullable disable

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

        public virtual DbSet<TaskItem> TaskItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
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
