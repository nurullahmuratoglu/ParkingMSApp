using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMSApp.Application.Dtos.Vehicle
{
    public class VehicleViewDto
    {
        public string Color { get; set; }
        public string LicensePlate { get; set; }
        public int ModelYear { get; set; }
        public string ModelName { get; set; }
        public string VehicleClass { get; set; }

    }
}
