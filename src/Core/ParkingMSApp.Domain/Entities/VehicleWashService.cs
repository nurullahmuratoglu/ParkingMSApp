using ParkingMSApp.Domain.Common;

namespace ParkingMSApp.Domain.Entities
{
    public class VehicleWashService:BaseEntity
    {
        
        public int ParkingVehicleId { get; set; }
        public ParkingVehicle ParkingVehicle { get; set; }
        public DateTime CreatedDate { get; set; }
        
    }
}
