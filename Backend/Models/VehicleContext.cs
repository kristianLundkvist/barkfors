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
        public DbSet<EquipmentList> EquipmentLists { get; set; } = null!;
        public DbSet<Brand> BrandSet { get; set; } = null!;
        public DbSet<CarColor> Colors { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>().HasKey(v => v.VIN);

            modelBuilder.Entity<FuelType>(f =>
            {
                f.HasKey(f => f.Type);
                f.HasMany(f => f.VIN).WithOne();
            });

            modelBuilder.Entity<VehicleEquipment>(ve =>
            {
                ve.HasKey(ve => ve.ID);
            });

            modelBuilder.Entity<EquipmentList>(el =>
            {
                el.HasKey(el => el.ID);
            });

            modelBuilder.Entity<Brand>(b =>
            {
                b.HasKey(b => b.BrandName);
                b.HasMany(b => b.VIN).WithOne();
            });

            modelBuilder.Entity<CarColor>(c =>
            {
                c.HasKey(c => c.ColorName);
                c.HasMany(c => c.VIN).WithOne();
            });
        }
    }
}