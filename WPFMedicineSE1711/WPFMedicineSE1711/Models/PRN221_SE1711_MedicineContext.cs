using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace WPFMedicineSE1711.Models
{
    public partial class PRN221_SE1711_MedicineContext : DbContext
    {
        public PRN221_SE1711_MedicineContext()
        {
        }

        public PRN221_SE1711_MedicineContext(DbContextOptions<PRN221_SE1711_MedicineContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GroupMedicine> GroupMedicines { get; set; } = null!;
        public virtual DbSet<Medicine> Medicines { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var ConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(ConnectionString);
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupMedicine>(entity =>
            {
                entity.HasKey(e => e.GroupId);

                entity.ToTable("GroupMedicine");

                entity.Property(e => e.GroupId)
                    .ValueGeneratedNever()
                    .HasColumnName("GroupID");

                entity.Property(e => e.GroupName).HasMaxLength(100);

                entity.Property(e => e.Note).HasMaxLength(500);
            });

            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.ToTable("Medicine");

                entity.Property(e => e.MedicineId)
                    .HasMaxLength(10)
                    .HasColumnName("MedicineID");

                entity.Property(e => e.ExpiriDate).HasColumnType("date");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.MedicineName).HasMaxLength(100);

                entity.Property(e => e.Preserve).HasMaxLength(100);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.UserManual).HasMaxLength(4000);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Medicines)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Medicine_GroupMedicine1");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Medicines)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Medicine_Supplier");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("Supplier");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.Address).HasMaxLength(300);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Fax).HasMaxLength(20);

                entity.Property(e => e.Note).HasMaxLength(500);

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.SupplierName).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    }
}
