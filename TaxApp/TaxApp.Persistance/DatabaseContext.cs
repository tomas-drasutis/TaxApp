using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using TaxApp.Models.Entities;

namespace TaxApp.Persistance
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DbSet<TaxEntity> Taxes { get; set; }
        public DbSet<MunicipalityEntity> Municipalities { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            ChangeTracker.Tracked += OnEntityTracked;
            ChangeTracker.StateChanged += OnEntityStateChanged;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MunicipalityEntity>(municipality =>
            {
                municipality.HasKey(m => m.Id);
                municipality.Property(m => m.Name).IsRequired();
            });

            modelBuilder.Entity<TaxEntity>(tax =>
            {
                tax.HasKey(m => m.Id);

                tax.Property(m => m.PeriodStartDate).IsRequired();
                tax.Property(m => m.PeriodEndDate).IsRequired();
                tax.Property(m => m.Value).IsRequired();
                tax.Property(m => m.Value).HasColumnType("decimal(2,2)");

                tax.Property(m => m.MunicipalityId).IsRequired();
                tax.HasOne(m => m.Municipality)
                    .WithMany(m => m.Taxes)
                    .HasForeignKey(m => m.MunicipalityId);
            });
        }

        private void OnEntityTracked(object sender, EntityTrackedEventArgs e)
        {
            if (!e.FromQuery && e.Entry.State == EntityState.Added && e.Entry.Entity is BaseEntity entity)
            {
                entity.CreatedOn = DateTime.UtcNow;
            }
        }

        private void OnEntityStateChanged(object sender, EntityStateChangedEventArgs e)
        {
            if (e.NewState == EntityState.Modified && e.Entry.Entity is BaseEntity entity)
            {
                entity.ModifiedOn = DateTime.UtcNow;
            }
        }
    }
}
