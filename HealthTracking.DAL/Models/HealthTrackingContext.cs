using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HealthTracking.DAL.Models;

public partial class HealthTrackingContext : DbContext
{
    public HealthTrackingContext()
    {
    }

    public HealthTrackingContext(DbContextOptions<HealthTrackingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BodyMetric> BodyMetrics { get; set; }

    public virtual DbSet<Exercise> Exercises { get; set; }

    public virtual DbSet<FoodCategory> FoodCategories { get; set; }

    public virtual DbSet<Meal> Meals { get; set; }

    public virtual DbSet<MealDetail> MealDetails { get; set; }

    public virtual DbSet<Sleep> Sleeps { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Water> Water { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=HealthTracking;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BodyMetric>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__body_met__3213E83F3E0F3F1F");

            entity.ToTable("body_metric");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("type");
            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.Value).HasColumnName("value");

            entity.HasOne(d => d.User).WithMany(p => p.BodyMetrics)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__body_metr__userI__4BAC3F29");
        });

        modelBuilder.Entity<Exercise>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__exercise__3213E83F48D72A39");

            entity.ToTable("exercise");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Activity)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("activity");
            entity.Property(e => e.Calories).HasColumnName("calories");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.Exercises)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__exercise__userId__45F365D3");
        });

        modelBuilder.Entity<FoodCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__food_cat__3213E83F357923C4");

            entity.ToTable("food_category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type");
        });

        modelBuilder.Entity<Meal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__meal__3213E83FA8AC10BE");

            entity.ToTable("meal");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.MealType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("mealType");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.Meals)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__meal__userId__3C69FB99");
        });

        modelBuilder.Entity<MealDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__meal_det__3213E83F0FE9F86F");

            entity.ToTable("meal_detail");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FoodCategoryId).HasColumnName("foodCategoryId");
            entity.Property(e => e.MealId).HasColumnName("mealId");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.FoodCategory).WithMany(p => p.MealDetails)
                .HasForeignKey(d => d.FoodCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__meal_deta__foodC__403A8C7D");

            entity.HasOne(d => d.Meal).WithMany(p => p.MealDetails)
                .HasForeignKey(d => d.MealId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__meal_deta__mealI__3F466844");
        });

        modelBuilder.Entity<Sleep>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__sleep__3213E83F7EC7DC43");

            entity.ToTable("sleep");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.TimeEnd)
                .HasColumnType("datetime")
                .HasColumnName("timeEnd");
            entity.Property(e => e.TimeStart)
                .HasColumnType("datetime")
                .HasColumnName("timeStart");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.Sleeps)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__sleep__userId__4316F928");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user__3213E83F3E100DD3");

            entity.ToTable("user");

            entity.HasIndex(e => e.Username, "UQ__user__F3DBC57297C666BD").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Birthday).HasColumnName("birthday");
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("fullName");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Water>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__water__3213E83FA3754801");

            entity.ToTable("water");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.Water)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__water__userId__48CFD27E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
