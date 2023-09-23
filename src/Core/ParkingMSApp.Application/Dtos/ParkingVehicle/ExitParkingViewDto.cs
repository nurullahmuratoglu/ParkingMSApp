using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMSApp.Application.Dtos.ParkingVehicle
{
    public class ExitParkingViewDto
    {
        public int Id { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime? ExitTime { get; set; }
        public decimal TotalFee { get; set; }
        public decimal HourFee { get; set; }
        
        public string HoursParked { get; set; }
    }
}
