using HealthTracking.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthTracking.DAL.Model
{
    public class HealthTrackingContext : IdentityDbContext<AppUser>

    {
        public HealthTrackingContext() { }
        public HealthTrackingContext(DbContextOptions<HealthTrackingContext> options) : base(options) { }

        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealDetail> MealDetails { get; set; }
        public DbSet<FoodCategory> FoodCategories { get; set; }
        public DbSet<Sleep> Sleeps { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Water> Waters { get; set; }
        public DbSet<BodyMetric> BodyMetrics { get; set; }
        public DbSet<UserSetting> UserSettings { get; set; }
        public DbSet<ExerciseActivity> ExerciseActivity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // VERY IMPORTANT for Identity

            modelBuilder.Entity<Meal>()
                .HasOne(m => m.User)
                .WithMany()
                .HasForeignKey(m => m.UserId);

            modelBuilder.Entity<MealDetail>()
                .HasOne(md => md.Meal)
                .WithMany(m => m.MealDetails)
                .HasForeignKey(md => md.MealId);

            modelBuilder.Entity<MealDetail>()
                .HasOne(md => md.FoodCategory)
                .WithMany(fc => fc.MealDetails)
                .HasForeignKey(md => md.FoodCategoryId);

            modelBuilder.Entity<Sleep>()
                .HasOne(s => s.User)
                .WithMany()
                .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<Exercise>()
                .HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Water>()
                .HasOne(w => w.User)
                .WithMany()
                .HasForeignKey(w => w.UserId);

            modelBuilder.Entity<ExerciseActivity>()
                .HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(w=>w.UserId);

            modelBuilder.Entity<BodyMetric>()
                .HasOne(b => b.User)
                .WithMany()
                .HasForeignKey(b => b.UserId);
            modelBuilder.Entity<UserSetting>()
                .HasOne(us => us.user)
                .WithMany()
                .HasForeignKey(us => us.UserId);
            modelBuilder.Entity<UserSetting>()
                .Property(u => u.Food)
                .HasConversion(
                    v => string.Join(";", v),
                    v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList())
                .Metadata.SetValueComparer(new ValueComparer<List<string>>(
                    (c1, c2) => c1.SequenceEqual(c2),
                    c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                    c => c.ToList()));
        }
    }
}
