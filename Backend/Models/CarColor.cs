namespace Backend.Models
{
    public class CarColor
    {
        public string ColorName { get; set; } = null!;
        public List<Vehicle> VIN { get; set; } = new List<Vehicle>();
    }
}