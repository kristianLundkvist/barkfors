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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>().HasKey(v => v.VIN);
            modelBuilder.Entity<FuelType>().Property(f => f.ID).ValueGeneratedOnAdd();
            modelBuilder.Entity<VehicleEquipment>().Property(ve => ve.ID).ValueGeneratedOnAdd();
        }
    }
}