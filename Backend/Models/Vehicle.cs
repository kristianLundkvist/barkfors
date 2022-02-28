namespace Backend.Models
{
    public class Vehicle
    {
        public string VIN { get; set; } = null!;
        public string? LicensePlate { get; set; }
        public string? Model { get; set; }
        public string? Brand { get; set; }
        public FuelType? Fuel { get; set; }

        public string? Color { get; set; }

        public List<VehicleEquipment>? Equipment { get; set; }
    }
}