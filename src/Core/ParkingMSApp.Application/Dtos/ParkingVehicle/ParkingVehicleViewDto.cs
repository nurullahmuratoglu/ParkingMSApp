using ParkingMSApp.Application.Dtos.Vehicle;
using ParkingMSApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMSApp.Application.Dtos.Car
{
    public class ParkingVehicleViewDto
    {
        public int Id { get; set; }
        public VehicleViewDto Vehicles { get; set; }
        
        public DateTime EntryTime { get; set; }
    }
}