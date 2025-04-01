using System;
using System.Collections.Generic;
using CustomerManager.Infrastructure.Persistence.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CustomerManager.Infrastructure.Persistence;

public partial class AppDbContext : IdentityDbContext<IdentityUser>
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<ContactPerson> ContactPeople { get; set; }

    public virtual DbSet<ContactPersonRole> ContactPersonRoles { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerActivity> CustomerActivities { get; set; }

    public virtual DbSet<CustomerNote> CustomerNotes { get; set; }

    public virtual DbSet<CustomerPotential> CustomerPotentials { get; set; }

    public virtual DbSet<CustomerProduct> CustomerProducts { get; set; }

    public virtual DbSet<CustomerType> CustomerTypes { get; set; }

    public virtual DbSet<JobTitle> JobTitles { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductTag> ProductTags { get; set; }

    public virtual DbSet<ProductUnit> ProductUnits { get; set; }

    public virtual DbSet<PurchaseFrequency> PurchaseFrequencies { get; set; }

    public virtual DbSet<SalesCall> SalesCalls { get; set; }

    public virtual DbSet<SalesCallContactType> SalesCallContactTypes { get; set; }

    public virtual DbSet<SalesCallProduct> SalesCallProducts { get; set; }

    public virtual DbSet<SalesCallProductDecisionStatus> SalesCallProductDecisionStatuses { get; set; }

    public virtual DbSet<SalesCallStatus> SalesCallStatuses { get; set; }

    public virtual DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }

    public virtual DbSet<UserProfile> UserProfiles { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Address_Id");

            entity.ToTable("Address", tb => tb.HasTrigger("TRG_Address_SetUpdatedAt"));

            entity.Property(e => e.BuildingNumber).HasMaxLength(10);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.FlatNumber).HasMaxLength(10);
            entity.Property(e => e.Street).HasMaxLength(150);
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);
            entity.Property(e => e.ZipCode).HasMaxLength(20);

            entity.HasOne(d => d.Customer).WithMany(p => p.Addresses).HasForeignKey(d => d.CustomerId);
        });

        modelBuilder.Entity<ContactPerson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ContactPerson_Id");

            entity.ToTable("ContactPerson", tb => tb.HasTrigger("TRG_ContactPerson_SetUpdatedAt"));

            entity.HasIndex(e => e.CustomerId, "IX_ContactPerson_Customer_CustomerId");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);

            entity.HasOne(d => d.Customer).WithMany(p => p.ContactPeople).HasForeignKey(d => d.CustomerId);

            entity.HasOne(d => d.Role).WithMany(p => p.ContactPeople)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_ContactPerson_ContactPersonRole_ContactPersonRoleId");
        });

        modelBuilder.Entity<ContactPersonRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ContactPersonRole_Id");

            entity.ToTable("ContactPersonRole");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.RoleName).HasMaxLength(100);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Customer_Id");

            entity.ToTable("Customer", tb => tb.HasTrigger("TRG_Customer_SetUpdatedAt"));

            entity.HasIndex(e => e.CompanyName, "IX_Customer_CompanyName");

            entity.Property(e => e.CompanyName).HasMaxLength(255);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);

            entity.HasOne(d => d.CustomerActivity).WithMany(p => p.Customers)
                .HasForeignKey(d => d.CustomerActivityId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.CustomerPotential).WithMany(p => p.Customers)
                .HasForeignKey(d => d.CustomerPotentialId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.CustomerType).WithMany(p => p.Customers)
                .HasForeignKey(d => d.CustomerTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<CustomerActivity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CustomerActivity_Id");

            entity.ToTable("CustomerActivity");

            entity.Property(e => e.ActivityName).HasMaxLength(100);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.Description).HasMaxLength(500);
        });

        modelBuilder.Entity<CustomerNote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CustomerNote_Id");

            entity.ToTable("CustomerNote");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerNotes).HasForeignKey(d => d.CustomerId);
        });

        modelBuilder.Entity<CustomerPotential>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CustomerPotential_Id");

            entity.ToTable("CustomerPotential", tb => tb.HasTrigger("TRG_CustomerPotential_SetUpdatedAt"));

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.PotentialName).HasMaxLength(100);
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);
        });

        modelBuilder.Entity<CustomerProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CustomerProduct_Id");

            entity.ToTable("CustomerProduct", tb => tb.HasTrigger("TRG_CustomerProduct_SetUpdatedAt"));

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Quantity).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerProducts)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_CustomerProduct_Customer");

            entity.HasOne(d => d.Product).WithMany(p => p.CustomerProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerProduct_Product");

            entity.HasOne(d => d.PurchaseFrequency).WithMany(p => p.CustomerProducts)
                .HasForeignKey(d => d.PurchaseFrequencyId)
                .HasConstraintName("FK_CustomerProduct_PurchaseFrequency");

            entity.HasOne(d => d.UnitOfMeasure).WithMany(p => p.CustomerProducts)
                .HasForeignKey(d => d.UnitOfMeasureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerProduct_UnitOfMeasure");
        });

        modelBuilder.Entity<CustomerType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CustomerType_Id");

            entity.ToTable("CustomerType", tb => tb.HasTrigger("TRG_CustomerType_SetUpdatedAt"));

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.TypeName).HasMaxLength(100);
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);
        });

        modelBuilder.Entity<JobTitle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_JobTitle_Id");

            entity.ToTable("JobTitle");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.TitleName).HasMaxLength(100);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Product_Id");

            entity.ToTable("Product", tb => tb.HasTrigger("TRG_Product_SetUpdatedAt"));

            entity.HasIndex(e => e.Sku, "IX_Product_SKU").IsUnique();

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Sku)
                .HasMaxLength(50)
                .HasColumnName("SKU");
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);

            entity.HasOne(d => d.BaseUnit).WithMany(p => p.Products)
                .HasForeignKey(d => d.BaseUnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_UnitOfMeasure_BaseUnit");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasMany(d => d.Tags).WithMany(p => p.Products)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductProductTag",
                    r => r.HasOne<ProductTag>().WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Product_ProductTag_Tag"),
                    l => l.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_Product_ProductTag_Product"),
                    j =>
                    {
                        j.HasKey("ProductId", "TagId");
                        j.ToTable("Product_ProductTag");
                    });
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ProductCategory_Id");

            entity.ToTable("ProductCategory");

            entity.Property(e => e.CategoryName).HasMaxLength(100);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.Description).HasMaxLength(500);
        });

        modelBuilder.Entity<ProductTag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ProductTag_Id");

            entity.ToTable("ProductTag");

            entity.HasIndex(e => e.TagName, "IX_ProductTag_TagName").IsUnique();

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.TagName).HasMaxLength(100);
        });

        modelBuilder.Entity<ProductUnit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ProductUnit_Id");

            entity.ToTable("ProductUnit");

            entity.Property(e => e.ConversionFactor).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);

            entity.HasOne(d => d.Product).WithMany(p => p.ProductUnits)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_ProductUnit_Product");

            entity.HasOne(d => d.Unit).WithMany(p => p.ProductUnits)
                .HasForeignKey(d => d.UnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductUnit_UnitOfMeasure");
        });

        modelBuilder.Entity<PurchaseFrequency>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PurchaseFrequency_Id");

            entity.ToTable("PurchaseFrequency");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.FrequencyName).HasMaxLength(50);
        });

        modelBuilder.Entity<SalesCall>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_SalesCall_Id");

            entity.ToTable("SalesCall", tb => tb.HasTrigger("TRG_SalesCall_SetUpdatedAt"));

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.Location).HasMaxLength(250);
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);
            entity.Property(e => e.UserId).HasMaxLength(450);

            entity.HasOne(d => d.ContactPerson).WithMany(p => p.SalesCalls)
                .HasForeignKey(d => d.ContactPersonId)
                .HasConstraintName("FK_SalesCall_ContactPerson");

            entity.HasOne(d => d.ContactType).WithMany(p => p.SalesCalls)
                .HasForeignKey(d => d.ContactTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalesCall_ContactType");

            entity.HasOne(d => d.Customer).WithMany(p => p.SalesCalls)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_SalesCall_Customer");

            entity.HasOne(d => d.Status).WithMany(p => p.SalesCalls)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalesCall_Status");
        });

        modelBuilder.Entity<SalesCallContactType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_SalesCallContactType_Id");

            entity.ToTable("SalesCallContactType");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.TypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<SalesCallProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_SalesCallProduct_Id");

            entity.ToTable("SalesCallProduct", tb => tb.HasTrigger("TRG_SalesCallProduct_SetUpdatedAt"));

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.EstimatedQuantity).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.FollowUpNote).HasMaxLength(500);
            entity.Property(e => e.Note).HasMaxLength(1000);
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);

            entity.HasOne(d => d.Product).WithMany(p => p.SalesCallProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalesCallProduct_Product");

            entity.HasOne(d => d.PurchaseFrequency).WithMany(p => p.SalesCallProducts)
                .HasForeignKey(d => d.PurchaseFrequencyId)
                .HasConstraintName("FK_SalesCallProduct_Frequency");

            entity.HasOne(d => d.SalesCall).WithMany(p => p.SalesCallProducts)
                .HasForeignKey(d => d.SalesCallId)
                .HasConstraintName("FK_SalesCallProduct_SalesCall");

            entity.HasOne(d => d.SalesDecisionStatus).WithMany(p => p.SalesCallProducts)
                .HasForeignKey(d => d.SalesDecisionStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalesCallProduct_DecisionStatus");

            entity.HasOne(d => d.UnitOfMeasure).WithMany(p => p.SalesCallProducts)
                .HasForeignKey(d => d.UnitOfMeasureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalesCallProduct_UnitOfMeasure");
        });

        modelBuilder.Entity<SalesCallProductDecisionStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_SalesCallProductStatus_Id");

            entity.ToTable("SalesCallProductDecisionStatus");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.StatusName).HasMaxLength(50);
        });

        modelBuilder.Entity<SalesCallStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_SalesCallStatus_Id");

            entity.ToTable("SalesCallStatus");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.StatusName).HasMaxLength(50);
        });

        modelBuilder.Entity<UnitOfMeasure>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_UnitOfMeasure_Id");

            entity.ToTable("UnitOfMeasure");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(10);
            entity.Property(e => e.Symbol).HasMaxLength(10);
        });

        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_UserProfile_Id");

            entity.ToTable("UserProfile", tb => tb.HasTrigger("TRG_UserProfile_SetUpdatedAt"));

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);

            entity.HasOne(d => d.JobTitle).WithMany(p => p.UserProfiles).HasForeignKey(d => d.JobTitleId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
