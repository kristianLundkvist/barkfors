using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public static class DbInitializer
    {
        public static void Seed(VehicleContext context)
        {
            if (!context.FuelTypes.Any())
            {
                context.FuelTypes.Add(new FuelType
                {
                    Type = "Gasoline",
                });
                context.FuelTypes.Add(new FuelType
                {
                    Type = "Diesel",
                });
                context.FuelTypes.Add(new FuelType
                {
                    Type = "Etanol",
                });

                context.SaveChanges();
            }

            if (!context.Equipment.Any())
            {
                context.Equipment.Add(new VehicleEquipment
                {
                    Equipment = "GPS",
                });
                context.Equipment.Add(new VehicleEquipment
                {
                    Equipment = "Dashcam",
                });

                context.SaveChanges();
            }

            if (!context.BrandSet.Any())
            {
                context.BrandSet.Add(new Brand
                {
                    BrandName = "BMW",
                });
                context.BrandSet.Add(new Brand
                {
                    BrandName = "VW",
                });
                context.BrandSet.Add(new Brand
                {
                    BrandName = "Volvo",
                });

                context.SaveChanges();
            }


            if (!context.Colors.Any())
            {
                context.Colors.Add(new CarColor
                {
                    ColorName = "Red",
                });
                context.Colors.Add(new CarColor
                {
                    ColorName = "Green",
                });
                context.Colors.Add(new CarColor
                {
                    ColorName = "Yellow",
                });

                context.SaveChanges();
            }

            if (!context.Vehicles.Any())
            {
                var temp = new Vehicle
                {
                    VIN = "012345",
                    LicensePlate = "ABC123",
                    Model = "Truck",
                };
                context.Vehicles.Add(temp);
                context.SaveChanges();

                var brand = context.BrandSet.First(b => b.BrandName == "VW");
                context.Entry(brand).State = EntityState.Modified;
                brand.VIN.Add(temp);

                var fuel = context.FuelTypes.First(f => f.Type == "Gasoline");
                context.Entry(fuel).State = EntityState.Modified;
                fuel.VIN.Add(temp);

                var color = context.Colors.First(c => c.ColorName == "Green");
                context.Entry(color).State = EntityState.Modified;
                color.VIN.Add(temp);

                var equipment = context.Equipment.First(e => e.Equipment == "Dashcam");
                context.EquipmentLists.Add(new EquipmentList
                {
                    VIN = temp.VIN,
                    EquipmentID = equipment.ID,
                });

                equipment = context.Equipment.First(e => e.Equipment == "GPS");
                context.EquipmentLists.Add(new EquipmentList
                {
                    VIN = temp.VIN,
                    EquipmentID = equipment.ID,
                });

                context.SaveChanges();

                temp = new Vehicle
                {
                    VIN = "qwerty",
                    LicensePlate = "AAA111",
                    Model = "Car",
                };
                context.Vehicles.Add(temp);
                context.SaveChanges();

                brand = context.BrandSet.First(b => b.BrandName == "VW");
                context.Entry(brand).State = EntityState.Modified;
                brand.VIN.Add(temp);

                fuel = context.FuelTypes.First(f => f.Type == "Gasoline");
                context.Entry(fuel).State = EntityState.Modified;
                fuel.VIN.Add(temp);

                color = context.Colors.First(c => c.ColorName == "Red");
                context.Entry(color).State = EntityState.Modified;
                color.VIN.Add(temp);

                equipment = context.Equipment.First(e => e.Equipment == "Dashcam");
                context.EquipmentLists.Add(new EquipmentList
                {
                    VIN = temp.VIN,
                    EquipmentID = equipment.ID,
                });

                context.SaveChanges();
            }
        }
    }
}