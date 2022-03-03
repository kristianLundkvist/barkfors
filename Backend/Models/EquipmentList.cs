namespace Backend.Models
{
    public class EquipmentList
    {
        public int ID { get; set; }
        public string VIN { get; set; } = null!;
        public int EquipmentID { get; set; }
    }
}