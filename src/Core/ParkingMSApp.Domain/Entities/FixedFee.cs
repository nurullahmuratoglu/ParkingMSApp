using ParkingMSApp.Domain.Common;

namespace ParkingMSApp.Domain.Entities
{
    public class FixedFee:BaseEntity
    {

        public string VehicleClass { get; set; }
        public decimal HourFee { get; set; }
    }
}
