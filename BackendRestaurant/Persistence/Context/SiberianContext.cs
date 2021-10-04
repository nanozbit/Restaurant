using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using System;

namespace Persistence.Context
{
    public class SiberianContext : DbContext
    {
        public SiberianContext(DbContextOptions<SiberianContext> options) : base(options) { }
        public DbSet<EntityCity> Ciudad { get; set; }
        public DbSet<RestaurantEntity> Restaurante { get; set; }

        public DbContext Restaurants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntityCity>()
                .Property(b => b.FechaCreacion)
                .HasDefaultValueSql("GETDATE()");

        }
    }
}
