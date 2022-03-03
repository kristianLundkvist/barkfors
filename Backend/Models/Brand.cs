namespace Backend.Models
{
    public class Brand
    {
        public string BrandName { get; set; } = null!;
        public List<Vehicle> VIN { get; set; } = new List<Vehicle>();
    }
}