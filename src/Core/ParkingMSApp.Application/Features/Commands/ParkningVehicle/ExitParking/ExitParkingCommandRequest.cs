using MediatR;
using ParkingMSApp.Application.Dtos.ParkingVehicle;
using ParkingMSApp.Application.Dtos.Response;

namespace ParkingMSApp.Application.Features.Commands.ParkningVehicle.ExitParking
{
    public class ExitParkingCommandRequest : IRequest<ResponseDto<ExitParkingViewDto>>
    {
        public string ParkingVehicleId { get; set; }
    }
}
