using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{
    public class VehicleContext : DbContext
    {
        public VehicleContext(DbContextOptions<VehicleContext> options) : base(options)
        { }

        public DbSet<Vehicle> Vehicles { get; set; } = null!;
        public DbSet<FuelType> FuelTypes { get; set; } = null!;
        public DbSet<VehicleEquipment> Equipment { get; set; } = null!;
        public DbSet<Brand> BrandSet { get; set; } = null!;
        public DbSet<CarColor> Colors { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>().HasKey(v => v.VIN);
            modelBuilder.Entity<FuelType>().HasKey(f => f.Type);
            modelBuilder.Entity<FuelType>().HasMany(f => f.VIN).WithOne();
            modelBuilder.Entity<VehicleEquipment>().HasKey(ve => ve.Equipment);
            modelBuilder.Entity<VehicleEquipment>().HasMany(ve => ve.VIN).WithOne();
            modelBuilder.Entity<Brand>().HasKey(b => b.BrandName);
            modelBuilder.Entity<Brand>().HasMany(b => b.VIN).WithOne();
            modelBuilder.Entity<CarColor>().HasKey(c => c.ColorName);
            modelBuilder.Entity<CarColor>().HasMany(c => c.VIN).WithOne();
        }
    }
}