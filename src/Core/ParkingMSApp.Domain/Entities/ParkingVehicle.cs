using ParkingMSApp.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingMSApp.Domain.Entities
{
    public class ParkingVehicle:BaseEntity
    {
        public int VehiclesId { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime? ExitTime { get; set; }
        public decimal TotalFee { get; set; }
        public decimal HourFee { get; set; }
        [NotMapped]
        public string HoursParked { get; set; }
        public Vehicle Vehicles { get; set; }
        public VehicleWashService VehicleWashServices { get; set; }
        public TireChangeService TireChangeServices { get; set; }

    }
}
