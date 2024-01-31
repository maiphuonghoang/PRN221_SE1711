using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace ClientPhone.Models
{
    public partial class PRN221_SE1711_Assignment2Context : DbContext
    {
        public PRN221_SE1711_Assignment2Context()
        {
        }

        public PRN221_SE1711_Assignment2Context(DbContextOptions<PRN221_SE1711_Assignment2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<TblPhone> TblPhones { get; set; } = null!;

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
            modelBuilder.Entity<TblPhone>(entity =>
            {
                entity.ToTable("tblPhone");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateofManufacture).HasColumnType("datetime");

                entity.Property(e => e.StopManufacture).HasColumnName("stopManufacture");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
