using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Accounts.Core.Models;
using Microsoft.Data.SqlClient;

namespace Accounts.Core.Context
{
    public partial class AccuteDbContext : DbContext
    {
       

        public AccuteDbContext(DbContextOptions<AccuteDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountContact> AccountContacts { get; set; } = null!;
        public virtual DbSet<AccountControl> AccountControls { get; set; } = null!;
        public virtual DbSet<AccountFiscalYear> AccountFiscalYears { get; set; } = null!;
        public virtual DbSet<AccountHead> AccountHeads { get; set; } = null!;
        public virtual DbSet<AccountHeadType> AccountHeadTypes { get; set; } = null!;
        public virtual DbSet<AccountLedger> AccountLedgers { get; set; } = null!;
        public virtual DbSet<AccountProfile> AccountProfiles { get; set; } = null!;
        public virtual DbSet<AccountSubLedger> AccountSubLedgers { get; set; } = null!;
        public virtual DbSet<AccountTransDetail> AccountTransDetails { get; set; } = null!;
        public virtual DbSet<AccountTransMaster> AccountTransMasters { get; set; } = null!;
        public virtual DbSet<AccountTransType> AccountTransTypes { get; set; } = null!;
        public virtual DbSet<AccountVoucherDetail> AccountVoucherDetails { get; set; } = null!;
        public virtual DbSet<AccountVoucherMaster> AccountVoucherMasters { get; set; } = null!;
        public virtual DbSet<AccountVoucherType> AccountVoucherTypes { get; set; } = null!;
        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<AddressType> AddressTypes { get; set; } = null!;
        public virtual DbSet<Area> Areas { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Currency> Currencies { get; set; } = null!;
        public virtual DbSet<ProductCategory> ProductCategories { get; set; } = null!;
        public virtual DbSet<ProductSubCategory> ProductSubCategories { get; set; } = null!;
        public virtual DbSet<StateProvince> StateProvinces { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=DESKTOP-LGPR2Q2;Initial Catalog=AccountsDB;Integrated Security=True;Encrypt=false");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountContact>(entity =>
            {
                entity.HasKey(e => e.AcContactId)
                    .HasName("PK_Contact");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.AcProfile)
                    .WithMany(p => p.AccountContacts)
                    .HasForeignKey(d => d.AcProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountContact_AccountProfile");
            });

            modelBuilder.Entity<AccountControl>(entity =>
            {
                entity.HasKey(e => e.AcControlId)
                    .HasName("PK_Controls");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.AcHead)
                    .WithMany(p => p.AccountControls)
                    .HasForeignKey(d => d.AcHeadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountControls_AccountHeads");
            });

            modelBuilder.Entity<AccountFiscalYear>(entity =>
            {
                entity.HasKey(e => e.FiscalYearId)
                    .HasName("PK_FiscalYear");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<AccountHead>(entity =>
            {
                entity.HasKey(e => e.AcHeadId)
                    .HasName("PK_Heads");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.AcHeadType)
                    .WithMany(p => p.AccountHeads)
                    .HasForeignKey(d => d.AcHeadTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountHeads_AccountHeadType");
            });

            modelBuilder.Entity<AccountHeadType>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<AccountLedger>(entity =>
            {
                entity.HasKey(e => e.AcLedgerId)
                    .HasName("PK_Ledgers");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.AcControl)
                    .WithMany(p => p.AccountLedgers)
                    .HasForeignKey(d => d.AcControlId)
                    .HasConstraintName("FK_AccountLedger_AccountControls");
            });

            modelBuilder.Entity<AccountProfile>(entity =>
            {
                entity.HasKey(e => e.AcProfileId)
                    .HasName("PK_Profile");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.AcLedger)
                    .WithMany(p => p.AccountProfiles)
                    .HasForeignKey(d => d.AcLedgerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountProfile_AccountLedger");
            });

            modelBuilder.Entity<AccountSubLedger>(entity =>
            {
                entity.HasKey(e => e.AcSubLedgerId)
                    .HasName("PK_SubLedgers");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.AcLedger)
                    .WithMany(p => p.AccountSubLedgers)
                    .HasForeignKey(d => d.AcLedgerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountSubLedger_AccountLedger");
            });

            modelBuilder.Entity<AccountTransDetail>(entity =>
            {
                entity.HasKey(e => e.AcTransDetailId)
                    .HasName("PK_AccountTransactionDetail");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.AcTransMaster)
                    .WithMany(p => p.AccountTransDetails)
                    .HasForeignKey(d => d.AcTransMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountTransDetail_AccountTransMaster");
            });

            modelBuilder.Entity<AccountTransMaster>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.AcTransType)
                    .WithMany(p => p.AccountTransMasters)
                    .HasForeignKey(d => d.AcTransTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountTransMaster_AccountTransType");

                entity.HasOne(d => d.FiscalYear)
                    .WithMany(p => p.AccountTransMasters)
                    .HasForeignKey(d => d.FiscalYearId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountTransMaster_AccountFiscalYear");
            });

            modelBuilder.Entity<AccountTransType>(entity =>
            {
                entity.HasKey(e => e.AcTransTypeId)
                    .HasName("PK_CV");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<AccountVoucherDetail>(entity =>
            {
                entity.HasKey(e => e.AcVoucherId)
                    .HasName("PK_AcVoucher");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.AcVoucherMaster)
                    .WithMany(p => p.AccountVoucherDetails)
                    .HasForeignKey(d => d.AcVoucherMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountVoucherDetail_AccountVoucherMaster");
            });

            modelBuilder.Entity<AccountVoucherMaster>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.AcVoucherType)
                    .WithMany(p => p.AccountVoucherMasters)
                    .HasForeignKey(d => d.AcVoucherTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountVoucherMaster_AccountVoucherType");

                entity.HasOne(d => d.FiscalYear)
                    .WithMany(p => p.AccountVoucherMasters)
                    .HasForeignKey(d => d.FiscalYearId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountVoucherMaster_AccountFiscalYear");
            });

            modelBuilder.Entity<AccountVoucherType>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.AcContact)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.AcContactId)
                    .HasConstraintName("FK_Address_AccountContact");

                entity.HasOne(d => d.AcProfile)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.AcProfileId)
                    .HasConstraintName("FK_Address_AccountProfile");

                entity.HasOne(d => d.AddressType)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.AddressTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Address_AddressType");

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.AreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Address_Area");
            });

            modelBuilder.Entity<AddressType>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Area>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Areas)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Area_City");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.StateProvince)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.StateProvinceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_City_StateProvince");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<ProductSubCategory>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<StateProvince>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.StateProvinces)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StateProvince_Country");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UserName).IsFixedLength();

                entity.Property(e => e.UserPosition).IsFixedLength();
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
