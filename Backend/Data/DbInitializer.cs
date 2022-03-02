using Backend.Models;

namespace Backend.Data
{
    public static class DbInitializer
    {
        public static void Seed(VehicleContext context)
        {
            if (!context.FuelTypes.Any())
            {
                var fuel = new FuelType[]{
                    new FuelType{
                        Type = "Gasoline",
                    },
                    new FuelType{
                        Type = "Diesel",
                    },
                    new FuelType{
                        Type = "Etanol",
                    }
                };

                context.FuelTypes.AddRange(fuel);
                context.SaveChanges();
            }

            if (!context.Equipment.Any())
            {
                var equipment = new VehicleEquipment[]{
                    new VehicleEquipment{
                        Equipment = "GPS",
                    },
                    new VehicleEquipment{
                        Equipment = "Dashcam",
                    }
                };

                context.Equipment.AddRange(equipment);
                context.SaveChanges();
            }

            if (!context.Vehicles.Any())
            {
                var vehicles = new Vehicle[]{
                    new Vehicle
                    {
                        VIN = "Test",
                        LicensePlate = "Test",
                        Model = "Test",
                        Brand = "Test",

                    }
                };

                context.Vehicles.AddRange(vehicles);
                context.SaveChanges();
            }
        }
    }
}