using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RealEstateRegisteryAPI.Persistence.EF.Models;

public partial class RealEstateRegistryContext : DbContext
{
    public RealEstateRegistryContext()
    {
    }

    public RealEstateRegistryContext(DbContextOptions<RealEstateRegistryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Citizen> Citizens { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<CityLevel> CityLevels { get; set; }

    public virtual DbSet<ContractType> ContractTypes { get; set; }

    public virtual DbSet<Estate> Estates { get; set; }

    public virtual DbSet<GenderType> GenderTypes { get; set; }

    public virtual DbSet<MaritalStatus> MaritalStatuses { get; set; }

    public virtual DbSet<Occupancy> Occupancies { get; set; }

    public virtual DbSet<Occupation> Occupations { get; set; }

    public virtual DbSet<UnitCategory> UnitCategories { get; set; }

    public virtual DbSet<UsageKind> UsageKinds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Citizen>(entity =>
        {
            entity.HasKey(e => e.CitizenId).HasName("PK__Citizen__6E49FA0C80EBCF74");

            entity.ToTable("Citizen");

            entity.HasIndex(e => e.BirthCityId, "IX_Citizen_BirthCity");

            entity.HasIndex(e => e.NationalCode, "UQ_Citizen_NationalCode").IsUnique();

            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Mobile)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.NationalCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ParentName).HasMaxLength(50);

            entity.HasOne(d => d.BirthCity).WithMany(p => p.Citizens)
                .HasForeignKey(d => d.BirthCityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Citizen_BirthCity");

            entity.HasOne(d => d.Gender).WithMany(p => p.Citizens)
                .HasForeignKey(d => d.GenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Citizen_Gender");

            entity.HasOne(d => d.MaritalStatus).WithMany(p => p.Citizens)
                .HasForeignKey(d => d.MaritalStatusId)
                .HasConstraintName("FK_Citizen_Marital");

            entity.HasOne(d => d.Occupation).WithMany(p => p.Citizens)
                .HasForeignKey(d => d.OccupationId)
                .HasConstraintName("FK_Citizen_Occupation");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PK__City__F2D21B76F5EC0755");

            entity.ToTable("City");

            entity.HasIndex(e => e.ParentCityId, "IX_City_Parent");

            entity.HasIndex(e => new { e.ParentCityId, e.CityName }, "UQ_City_Name_Parent").IsUnique();

            entity.Property(e => e.CityId).ValueGeneratedNever();
            entity.Property(e => e.CityName).HasMaxLength(60);
            entity.Property(e => e.IsActive).HasDefaultValue(true, "DF_City_IsActive");

            entity.HasOne(d => d.CityLevel).WithMany(p => p.Cities)
                .HasForeignKey(d => d.CityLevelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_City_Level");

            entity.HasOne(d => d.ParentCity).WithMany(p => p.InverseParentCity)
                .HasForeignKey(d => d.ParentCityId)
                .HasConstraintName("FK_City_Parent");
        });

        modelBuilder.Entity<CityLevel>(entity =>
        {
            entity.HasKey(e => e.CityLevelId).HasName("PK__CityLeve__658881C1BA2D60CD");

            entity.ToTable("CityLevel");

            entity.HasIndex(e => e.CityLevelName, "UQ__CityLeve__9AF0976F2011405E").IsUnique();

            entity.Property(e => e.CityLevelName).HasMaxLength(30);
        });

        modelBuilder.Entity<ContractType>(entity =>
        {
            entity.HasKey(e => e.ContractTypeId).HasName("PK__Contract__68A615653738C93C");

            entity.ToTable("ContractType");

            entity.HasIndex(e => e.ContractTypeName, "UQ__Contract__171591DB61ED893D").IsUnique();

            entity.Property(e => e.ContractTypeName).HasMaxLength(40);
        });

        modelBuilder.Entity<Estate>(entity =>
        {
            entity.HasKey(e => e.EstateId).HasName("PK__Estate__7CE33E871F327EA7");

            entity.ToTable("Estate");

            entity.HasIndex(e => e.CityId, "IX_Estate_City");

            entity.HasIndex(e => e.DeedPlaque, "UQ_Estate_DeedPlaque").IsUnique();

            entity.HasIndex(e => e.ZipCode, "UQ_Estate_ZipCode").IsUnique();

            entity.Property(e => e.AreaSqm).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.DeedPlaque)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FullAddress).HasMaxLength(250);
            entity.Property(e => e.IsActive).HasDefaultValue(true, "DF_Estate_IsActive");
            entity.Property(e => e.Latitude).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Category).WithMany(p => p.Estates)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Estate_Category");

            entity.HasOne(d => d.City).WithMany(p => p.Estates)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Estate_City");

            entity.HasOne(d => d.Usage).WithMany(p => p.Estates)
                .HasForeignKey(d => d.UsageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Estate_Usage");
        });

        modelBuilder.Entity<GenderType>(entity =>
        {
            entity.HasKey(e => e.GenderId).HasName("PK__GenderTy__4E24E9F781C9692B");

            entity.ToTable("GenderType");

            entity.HasIndex(e => e.GenderName, "UQ__GenderTy__F7C17715BCAFDC4F").IsUnique();

            entity.Property(e => e.GenderName).HasMaxLength(20);
        });

        modelBuilder.Entity<MaritalStatus>(entity =>
        {
            entity.HasKey(e => e.MaritalStatusId).HasName("PK__MaritalS__C8B1BA720E35C62C");

            entity.ToTable("MaritalStatus");

            entity.HasIndex(e => e.MaritalStatusName, "UQ__MaritalS__BA58663BAB340CFE").IsUnique();

            entity.Property(e => e.MaritalStatusName).HasMaxLength(20);
        });

        modelBuilder.Entity<Occupancy>(entity =>
        {
            entity.HasKey(e => e.OccupancyId).HasName("PK__Occupanc__E8FD04D60C7A73B8");

            entity.ToTable("Occupancy");

            entity.HasIndex(e => e.CitizenId, "IX_Occupancy_Citizen");

            entity.HasIndex(e => e.EstateId, "IX_Occupancy_Estate");

            entity.HasIndex(e => new { e.CitizenId, e.EstateId, e.ContractTypeId, e.StartDate }, "UQ_Occupancy").IsUnique();

            entity.HasOne(d => d.Citizen).WithMany(p => p.Occupancies)
                .HasForeignKey(d => d.CitizenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Occupancy_Citizen");

            entity.HasOne(d => d.ContractType).WithMany(p => p.Occupancies)
                .HasForeignKey(d => d.ContractTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Occupancy_Contract");

            entity.HasOne(d => d.Estate).WithMany(p => p.Occupancies)
                .HasForeignKey(d => d.EstateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Occupancy_Estate");
        });

        modelBuilder.Entity<Occupation>(entity =>
        {
            entity.HasKey(e => e.OccupationId).HasName("PK__Occupati__891711AD78D0AF97");

            entity.ToTable("Occupation");

            entity.HasIndex(e => e.OccupationName, "UQ__Occupati__18376EA0D4A55A74").IsUnique();

            entity.Property(e => e.OccupationId).ValueGeneratedNever();
            entity.Property(e => e.OccupationName).HasMaxLength(60);
        });

        modelBuilder.Entity<UnitCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__UnitCate__19093A0B914C09B5");

            entity.ToTable("UnitCategory");

            entity.HasIndex(e => e.CategoryName, "UQ__UnitCate__8517B2E0F9372CFD").IsUnique();

            entity.Property(e => e.CategoryId).ValueGeneratedNever();
            entity.Property(e => e.CategoryName).HasMaxLength(40);
        });

        modelBuilder.Entity<UsageKind>(entity =>
        {
            entity.HasKey(e => e.UsageId).HasName("PK__UsageKin__29B197204A9CFF7E");

            entity.ToTable("UsageKind");

            entity.HasIndex(e => e.UsageName, "UQ__UsageKin__E096B921BA1BE990").IsUnique();

            entity.Property(e => e.UsageId).ValueGeneratedNever();
            entity.Property(e => e.UsageName).HasMaxLength(40);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
