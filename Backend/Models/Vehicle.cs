namespace Backend.Models
{
    public class Vehicle
    {
        public string VIN { get; set; } = null!;
        public string? LicensePlate { get; set; }
        public string? Model { get; set; }
    }
}