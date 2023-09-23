using ParkingMSApp.Domain.Common;

namespace ParkingMSApp.Domain.Entities
{
    public class Vehicle : BaseEntity
    {
        public string Color { get; set; }
        public string LicensePlate { get; set; }
        public int ModelYear { get; set; }
        public string ModelName { get; set; }
        public string VehicleClass { get; set; }//discriminator
        public ParkingVehicle ParkingVehicles { get; set; }

    }
}