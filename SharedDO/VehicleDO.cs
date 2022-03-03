namespace SharedDO
{
    public class VehicleDO
    {
        public string VIN { get; set; } = null!;
        public string? LicensePlate { get; set; }
        public string? Model { get; set; }
        public BrandDO? Brand { get; set; }
        public FuelDO? Fuel { get; set; }
        public ColorDO? Color { get; set; }
        public List<VehicleEquipmentDO> Equipment { get; set; } = new List<VehicleEquipmentDO>();
    }
}