namespace Backend.Models
{
    public class VehicleEquipment
    {
        public string Equipment { get; set; } = null!;

        public List<Vehicle> VIN { get; set; } = new List<Vehicle>();
    }
}