namespace Backend.Models
{
    public class FuelType
    {
        public string Type { get; set; } = null!;
        public List<Vehicle> VIN { get; set; } = new List<Vehicle>();
    }
}