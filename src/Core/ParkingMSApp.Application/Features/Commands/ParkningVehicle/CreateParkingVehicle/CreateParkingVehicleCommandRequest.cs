using MediatR;
using ParkingMSApp.Application.Dtos.Response;

namespace ParkingMSApp.Application.Features.Commands.ParkningVehicle.CreateParkingVehicle
{
    public class CreateParkingVehicleCommandRequest : IRequest<ResponseDto<NoContentDto>>
    {

        public string Color { get; set; }
        public string LicensePlate { get; set; }
        public int ModelYear { get; set; }
        public string ModelName { get; set; }
        public bool AutomaticPilot { get; set; }
        public decimal Price { get; set; }
        public int TrunkCapacity { get; set; }
        public bool SpareTire { get; set; }
    }
}
