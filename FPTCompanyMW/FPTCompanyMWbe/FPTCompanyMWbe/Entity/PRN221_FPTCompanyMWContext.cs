using System;
using System.Collections.Generic;
using FPTCompanyMWbe.Model.Response;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FPTCompanyMWbe.Models
{
    public partial class PRN221_FPTCompanyMWContext : DbContext
    {
        public PRN221_FPTCompanyMWContext()
        {
        }

        public PRN221_FPTCompanyMWContext(DbContextOptions<PRN221_FPTCompanyMWContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Group> Groups { get; set; } = null!;
        public virtual DbSet<Job> Jobs { get; set; } = null!;
        public virtual DbSet<JobRank> JobRanks { get; set; } = null!;
        public virtual DbSet<Package> Packages { get; set; } = null!;
        public virtual DbSet<Participate> Participates { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<StandardTime> StandardTimes { get; set; } = null!;
        public virtual DbSet<Working> Workings { get; set; } = null!;
        public virtual DbSet<EmployeeInfoResponse> EmployeeInfoResponse { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server =(local); database = PRN221_FPTCompanyMW; uid=sa;pwd=sa123456;Trusted_Connection=True;Encrypt=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__Account__F3DBC57301080AC6");

                entity.ToTable("Account");

                entity.Property(e => e.Username)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.Password)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Usernames)
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountRole",
                        l => l.HasOne<Role>().WithMany().HasForeignKey("RoleId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_AccountRole_Role"),
                        r => r.HasOne<Account>().WithMany().HasForeignKey("Username").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_AccountRole_Account"),
                        j =>
                        {
                            j.HasKey("Username", "RoleId");

                            j.ToTable("AccountRole");

                            j.IndexerProperty<string>("Username").HasMaxLength(150).IsUnicode(false).HasColumnName("username");

                            j.IndexerProperty<int>("RoleId").HasColumnName("roleId");
                        });
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.HasIndex(e => e.AccountId, "UQ__Employee__F267251F4BCDF4C7")
                    .IsUnique();

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("employeeId");

                entity.Property(e => e.AccountId)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("accountId");

                entity.Property(e => e.EmployeeImage)
                    .IsUnicode(false)
                    .HasColumnName("employeeImage");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(100)
                    .HasColumnName("employeeName");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.HasOne(d => d.Account)
                    .WithOne(p => p.Employee)
                    .HasForeignKey<Employee>(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Account");

                entity.HasMany(d => d.JobRanks)
                    .WithMany(p => p.Employees)
                    .UsingEntity<Dictionary<string, object>>(
                        "Salary",
                        l => l.HasOne<JobRank>().WithMany().HasForeignKey("JobRankId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Salary__jobRankI__17C286CF"),
                        r => r.HasOne<Employee>().WithMany().HasForeignKey("EmployeeId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Salary__employee__16CE6296"),
                        j =>
                        {
                            j.HasKey("EmployeeId", "JobRankId").HasName("PK__Salary__3A79E22AE279BA3A");

                            j.ToTable("Salary");

                            j.IndexerProperty<string>("EmployeeId").HasMaxLength(50).IsUnicode(false).HasColumnName("employeeId");

                            j.IndexerProperty<int>("JobRankId").HasColumnName("jobRankId");
                        });
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasKey(e => e.GroupCode);

                entity.ToTable("Group");

                entity.Property(e => e.GroupCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("groupCode");

                entity.Property(e => e.BuId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("buId");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("groupName");

                entity.HasOne(d => d.Bu)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.BuId)
                    .HasConstraintName("FK_Group_Employee");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.HasKey(e => e.JobCode)
                    .HasName("PK__Job__5B60E0DDF7F6F03D");

                entity.ToTable("Job");

                entity.Property(e => e.JobCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("jobCode");

                entity.Property(e => e.JobName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("jobName");
            });

            modelBuilder.Entity<JobRank>(entity =>
            {
                entity.ToTable("JobRank");

                entity.Property(e => e.JobRankId)
                    .ValueGeneratedNever()
                    .HasColumnName("jobRankId");

                entity.Property(e => e.JobCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("jobCode");

                entity.Property(e => e.JobRank1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("jobRank");

                entity.Property(e => e.PackageCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("packageCode");

                entity.HasOne(d => d.JobCodeNavigation)
                    .WithMany(p => p.JobRanks)
                    .HasForeignKey(d => d.JobCode)
                    .HasConstraintName("FK__JobRank__jobCode__12FDD1B2");

                entity.HasOne(d => d.PackageCodeNavigation)
                    .WithMany(p => p.JobRanks)
                    .HasForeignKey(d => d.PackageCode)
                    .HasConstraintName("FK__JobRank__package__13F1F5EB");
            });

            modelBuilder.Entity<Package>(entity =>
            {
                entity.HasKey(e => e.PackageCode)
                    .HasName("PK__Package__03B32A259ED4097B");

                entity.ToTable("Package");

                entity.Property(e => e.PackageCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("packageCode");

                entity.Property(e => e.PackageSalary)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("packageSalary");
            });

            modelBuilder.Entity<Participate>(entity =>
            {
                entity.HasKey(e => new { e.GroupCode, e.EmployeeId });

                entity.ToTable("Participate");

                entity.Property(e => e.GroupCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("groupCode");

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("employeeId");

                entity.Property(e => e.StandardTimeId).HasColumnName("standardTimeId");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Participates)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Participa__emplo__1D7B6025");

                entity.HasOne(d => d.GroupCodeNavigation)
                    .WithMany(p => p.Participates)
                    .HasForeignKey(d => d.GroupCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Participa__group__1C873BEC");

                entity.HasOne(d => d.StandardTime)
                    .WithMany(p => p.Participates)
                    .HasForeignKey(d => d.StandardTimeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Participa__stand__1E6F845E");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId)
                    .ValueGeneratedNever()
                    .HasColumnName("roleId");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("roleName");
            });

            modelBuilder.Entity<StandardTime>(entity =>
            {
                entity.ToTable("StandardTime");

                entity.Property(e => e.StandardTimeId)
                    .ValueGeneratedNever()
                    .HasColumnName("standardTimeId");

                entity.Property(e => e.AfternoonEndTime).HasColumnName("afternoonEndTime");

                entity.Property(e => e.AfternoonStartTime).HasColumnName("afternoonStartTime");

                entity.Property(e => e.MorningEndTime).HasColumnName("morningEndTime");

                entity.Property(e => e.MorningStartTime).HasColumnName("morningStartTime");
            });

            modelBuilder.Entity<Working>(entity =>
            {
                entity.ToTable("Working");

                entity.Property(e => e.WorkingId).HasColumnName("workingId");

                entity.Property(e => e.DateWorking)
                    .HasColumnType("date")
                    .HasColumnName("dateWorking");

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("employeeId");

                entity.Property(e => e.FirstEntryTime).HasColumnName("firstEntryTime");

                entity.Property(e => e.LastExistTime).HasColumnName("lastExistTime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Workings)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Working__employe__251C81ED");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
